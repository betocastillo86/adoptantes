//-----------------------------------------------------------------------
// <copyright file="SecuritySettings.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Configuration
{
    using System;
    using Adopters.Business.Services.Extensions;
    using Beto.Core.Data.Configuration;

    /// <summary>
    /// Security Settings
    /// </summary>
    /// <seealso cref="Adopters.Business.Configuration.ISecuritySettings" />
    public class SecuritySettings : ISecuritySettings
    {
        /// <summary>
        /// The setting service
        /// </summary>
        private readonly ICoreSettingService settingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecuritySettings"/> class.
        /// </summary>
        /// <param name="coreSettingService">The core setting service.</param>
        public SecuritySettings(ICoreSettingService coreSettingService)
        {
            this.settingService = coreSettingService;
        }

        /// <summary>
        /// Gets the authentication audience.
        /// </summary>
        /// <value>
        /// The authentication audience.
        /// </value>
        public string AuthenticationAudience => this.settingService.Get<string>("SecuritySettings.AuthenticationAudience");

        /// <summary>
        /// Gets the authentication issuer.
        /// </summary>
        /// <value>
        /// The authentication issuer.
        /// </value>
        public string AuthenticationIssuer => this.settingService.Get<string>("SecuritySettings.AuthenticationIssuer");

        /// <summary>
        /// Gets the authentication secret key.
        /// </summary>
        /// <value>
        /// The authentication secret key.
        /// </value>
        public string AuthenticationSecretKey => this.settingService.Get<string>("SecuritySettings.AuthenticationSecretKey");

        /// <summary>
        /// Gets the expiration token minutes.
        /// </summary>
        /// <value>
        /// The expiration token minutes.
        /// </value>
        public int ExpirationTokenMinutes => this.settingService.Get<int>("SecuritySettings.ExpirationTokenMinutes");

        /// <summary>
        /// Gets the maximum request file upload in MB.
        /// </summary>
        /// <value>
        /// The maximum request file upload in MB.
        /// </value>
        public int MaxRequestFileUploadMB => this.settingService.Get<int>("SecuritySettings.MaxRequestFileUploadMB");

        /// <summary>
        /// Gets the facebook API key.
        /// </summary>
        /// <value>
        /// The facebook API key.
        /// </value>
        public string FacebookApiKey => this.settingService.Get<string>("SecuritySettings.FacebookApiKey");
    }
}