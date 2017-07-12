//-----------------------------------------------------------------------
// <copyright file="ExternalAuthenticationService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Adopters.Business.Exceptions;
    using Adopters.Data.Entities;
    using Beto.Core.Data;
    using Beto.Core.Data.Users;

    /// <summary>
    /// External Authentication Service
    /// </summary>
    /// <seealso cref="Adopters.Business.Services.IExternalAuthenticationService" />
    public class ExternalAuthenticationService : IExternalAuthenticationService
    {
        /// <summary>
        /// The social authentication service
        /// </summary>
        private readonly ISocialAuthenticationService socialAuthenticationService;

        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IRepository<User> userRepository;

        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalAuthenticationService"/> class.
        /// </summary>
        /// <param name="socialAuthenticationService">The social authentication service.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="userService">The user service.</param>
        public ExternalAuthenticationService(
            ISocialAuthenticationService socialAuthenticationService,
            IRepository<User> userRepository,
            IUserService userService)
        {
            this.socialAuthenticationService = socialAuthenticationService;
            this.userRepository = userRepository;
            this.userService = userService;
        }

        /// <summary>
        /// Tries the authentication with a social network.
        /// </summary>
        /// <param name="socialNetwork">The social network.</param>
        /// <param name="token">The token.</param>
        /// <param name="token2">The token2.</param>
        /// <returns>
        /// Tuple with a boolean if is true the user already existed and the user authenticated.
        /// </returns>
        /// <exception cref="AdoptersException">
        /// Error trying to login
        /// </exception>
        public async Task<Tuple<bool, User>> TryAuthenticate(SocialLoginType socialNetwork, string token, string token2)
        {
            bool userExisted = false;
            string socialId = string.Empty;
            string email = string.Empty;
            string name = string.Empty;

            ////Intenta realizar la autenticación por cualquiera de las redes y actualiza los datos
            switch (socialNetwork)
            {
                case SocialLoginType.Facebook:
                    var facebookUser = await this.socialAuthenticationService.GetFacebookUser(token);
                    if (string.IsNullOrEmpty(facebookUser.Error))
                    {
                        socialId = facebookUser.Id.ToString();
                        email = facebookUser.Email;
                        name = facebookUser.Name;
                    }
                    else
                    {
                        throw new AdoptersException(AdopterExceptionCode.ErrorTryingExternalLogin, facebookUser.Error);
                    }

                    break;

                default:
                    throw new AdoptersException(AdopterExceptionCode.InvalidExternalAuthenticationProvider);
            }

            User user = null;

            switch (socialNetwork)
            {
                case SocialLoginType.Facebook:
                    user = this.userRepository.Table.FirstOrDefault(u => u.FacebookId == socialId);
                    break;
            }

            ////Si el usuario ya está registrado lo retorna
            if (user != null)
            {
                userExisted = true;
                return Tuple.Create<bool, User>(userExisted, user);
            }
            else
            {
                userExisted = false;

                ////Consulta para validar si el usuario ya está registrado previamente con el mismo correo para asociarle la red
                ////Unicamente cuando el correo no es nulo ni vacio
                if (!string.IsNullOrEmpty(email))
                {
                    user = this.userRepository.Table.FirstOrDefault(c => c.Email.Equals(email));
                }

                bool toCreate = user == null;
                ////Si el usuario definitivamente no existe lo crea
                if (user == null)
                {
                    ////Crea un objeto base para ser guardado
                    user = new User()
                    {
                        Name = name,
                        Email = email,
                        Role = Role.Public
                    };

                    toCreate = true;
                }

                switch (socialNetwork)
                {
                    case SocialLoginType.Facebook:
                        user.FacebookId = socialId;
                        break;

                    default:
                        break;
                }

                if (toCreate)
                {
                    userExisted = false;
                    await this.userService.Insert(user);
                }
                else
                {
                    userExisted = true;
                    await this.userService.Update(user);
                }

                return Tuple.Create<bool, User>(userExisted, user);
            }
        }
    }
}