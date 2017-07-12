//-----------------------------------------------------------------------
// <copyright file="AuthenticationTokenGeneratorJWT.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Infraestructure.Security
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using Adopters.Data.Entities;
    using Beto.Core.Web.Security;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Authentication token generator of JWT
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Security.IAuthenticationTokenGenerator" />
    public class AuthenticationTokenGeneratorJWT : IAuthenticationTokenGenerator
    {
        /// <summary>
        /// Gets the identity.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="claims">The claims.</param>
        /// <returns>The identity</returns>
        public static GenericIdentity GetIdentity(User user, out IList<Claim> claims)
        {
            var genericIdentity = new GenericIdentity(user.Id.ToString(), "Token");
            claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
            return genericIdentity;
        }

        /// <summary>
        /// Generates the token for authenticate a user
        /// </summary>
        /// <param name="genericIdentity">The generic identity.</param>
        /// <param name="claims">The claims.</param>
        /// <param name="generationDate">The date when the key is generation. Usually you can use DateTimeOffset.Now</param>
        /// <param name="configParams">configuration parameters depending of type of authentication</param>
        /// <returns>
        /// The generated token for authentication
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// any of the parameters are invalid
        /// </exception>
        public GeneratedAuthenticationToken GenerateToken(GenericIdentity genericIdentity, IList<Claim> claims, DateTimeOffset generationDate, IDictionary<string, string> configParams)
        {
            if (!configParams.ContainsKey("secretkey"))
            {
                throw new ArgumentNullException("configParams.secretKey");
            }
            else if (!configParams.ContainsKey("expirationMinutes"))
            {
                throw new ArgumentNullException("configParams.expirationMinutes");
            }
            else if (!configParams.ContainsKey("issuer"))
            {
                throw new ArgumentNullException("configParams.issuer");
            }
            else if (!configParams.ContainsKey("audience"))
            {
                throw new ArgumentNullException("configParams.audience");
            }

            var identity = new ClaimsIdentity(genericIdentity, claims);

            var now = generationDate;
            var nowDate = new DateTime(now.Ticks);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configParams["secretkey"]));

            var expirationTime = TimeSpan.FromMinutes(Convert.ToInt32(configParams["expirationMinutes"]));

            var jwt = new JwtSecurityToken(
                issuer: configParams["issuer"],
                audience: configParams["audience"],
                claims: claims,
                expires: nowDate.Add(expirationTime),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new GeneratedAuthenticationToken() { AccessToken = encodedJwt, Expires = (int)expirationTime.TotalSeconds };
        }
    }
}