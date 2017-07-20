//-----------------------------------------------------------------------
// <copyright file="ISecuritySettings.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Configuration
{
    /// <summary>
    /// Interface of security
    /// </summary>
    public interface ISecuritySettings
    {
        /// <summary>
        /// Gets the authentication audience.
        /// </summary>
        /// <value>
        /// The authentication audience.
        /// </value>
        string AuthenticationAudience { get; }

        /// <summary>
        /// Gets the authentication issuer.
        /// </summary>
        /// <value>
        /// The authentication issuer.
        /// </value>
        string AuthenticationIssuer { get; }

        /// <summary>
        /// Gets the authentication secret key.
        /// </summary>
        /// <value>
        /// The authentication secret key.
        /// </value>
        string AuthenticationSecretKey { get; }

        /// <summary>
        /// Gets the expiration token minutes.
        /// </summary>
        /// <value>
        /// The expiration token minutes.
        /// </value>
        int ExpirationTokenMinutes { get; }

        /// <summary>
        /// Gets the maximum request file upload in MB.
        /// </summary>
        /// <value>
        /// The maximum request file upload in MB.
        /// </value>
        int MaxRequestFileUploadMB { get; }

        /// <summary>
        /// Gets the facebook API key.
        /// </summary>
        /// <value>
        /// The facebook API key.
        /// </value>
        string FacebookApiKey { get; }
    }
}