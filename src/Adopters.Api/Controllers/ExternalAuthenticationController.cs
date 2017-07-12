//-----------------------------------------------------------------------
// <copyright file="ExternalAuthenticationController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Adopters.Api.Infraestructure.Security;
    using Adopters.Api.Models;
    using Adopters.Business.Configuration;
    using Adopters.Business.Exceptions;
    using Adopters.Business.Services;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Beto.Core.Web.Security;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// External authentication Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/auth/external")]
    public class ExternalAuthenticationController : BaseApiController
    {
        /// <summary>
        /// The external authentication service
        /// </summary>
        private readonly IExternalAuthenticationService externalAuthenticationService;

        /// <summary>
        /// The authentication token generator
        /// </summary>
        private readonly IAuthenticationTokenGenerator authenticationTokenGenerator;

        /// <summary>
        /// The security settings
        /// </summary>
        private readonly ISecuritySettings securitySettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalAuthenticationController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="externalAuthenticationService">The external authentication service.</param>
        /// <param name="authenticationTokenGenerator">The authentication token generator.</param>
        /// <param name="securitySettings">The security settings.</param>
        public ExternalAuthenticationController(
            IMessageExceptionFinder messageExceptionFinder,
            IExternalAuthenticationService externalAuthenticationService,
            IAuthenticationTokenGenerator authenticationTokenGenerator,
            ISecuritySettings securitySettings) : base(messageExceptionFinder)
        {
            this.externalAuthenticationService = externalAuthenticationService;
            this.authenticationTokenGenerator = authenticationTokenGenerator;
            this.securitySettings = securitySettings;
        }

        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the action</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExternalAuthenticationModel model)
        {
            try
            {
                var tuple = await this.externalAuthenticationService.TryAuthenticate(model.SocialNetwork, model.Token, model.Token2);
                var user = tuple.Item2;
                var userExisted = tuple.Item1;

                IList<Claim> claims;
                var identity = AuthenticationTokenGeneratorJWT.GetIdentity(user, out claims);

                var configParams = new Dictionary<string, string>();
                configParams.Add("secretkey", this.securitySettings.AuthenticationSecretKey);
                configParams.Add("expirationMinutes", this.securitySettings.ExpirationTokenMinutes.ToString());
                configParams.Add("issuer", this.securitySettings.AuthenticationIssuer);
                configParams.Add("audience", this.securitySettings.AuthenticationAudience);

                var token = this.authenticationTokenGenerator.GenerateToken(identity, claims, DateTimeOffset.Now, configParams);
                var userModel = new AuthenticatedUserModel()
                {
                    Email = user.Email,
                    Name = user.Name,
                    Id = user.Id,
                    Token = token,
                    FacebookId = user.FacebookId,
                    Role = user.Role,
                    Location = user.Location != null ? user.Location.ToModel() : null
                };

                return this.Ok(userModel);
            }
            catch (AdoptersException e)
            {
                return this.BadRequest(e);
            }
        }
    }
}