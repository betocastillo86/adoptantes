//-----------------------------------------------------------------------
// <copyright file="IExternalAuthenticationService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System;
    using System.Threading.Tasks;
    using Adopters.Data.Entities;

    /// <summary>
    /// Interface of external authentication
    /// </summary>
    public interface IExternalAuthenticationService
    {
        /// <summary>
        /// Tries the authentication with a social network.
        /// </summary>
        /// <param name="socialNetwork">The social network.</param>
        /// <param name="token">The token.</param>
        /// <param name="token2">The token2.</param>
        /// <returns>Tuple with a boolean if is true the user already existed and the user authenticated.</returns>
        Task<Tuple<bool, User>> TryAuthenticate(SocialLoginType socialNetwork, string token, string token2);
    }
}