//-----------------------------------------------------------------------
// <copyright file="ExternalAuthenticationModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Adopters.Data.Entities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// External Authentication Model
    /// </summary>
    public class ExternalAuthenticationModel
    {
        /// <summary>
        /// Gets or sets the social network.
        /// </summary>
        /// <value>
        /// The social network.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public SocialLoginType SocialNetwork { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the token2.
        /// </summary>
        /// <value>
        /// The token2.
        /// </value>
        public string Token2 { get; set; }
    }
}