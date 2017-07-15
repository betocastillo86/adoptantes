//-----------------------------------------------------------------------
// <copyright file="GeneralSettings.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Configuration
{
    using Adopters.Business.Services.Extensions;
    using Beto.Core.Data.Configuration;

    /// <summary>
    /// General Settings
    /// </summary>
    /// <seealso cref="Adopters.Business.Configuration.IGeneralSettings" />
    public class GeneralSettings : IGeneralSettings
    {
        /// <summary>
        /// The setting service
        /// </summary>
        private readonly ICoreSettingService settingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSettings"/> class.
        /// </summary>
        /// <param name="coreSettingService">The core setting service.</param>
        public GeneralSettings(ICoreSettingService coreSettingService)
        {
            this.settingService = coreSettingService;
        }

        /// <summary>
        /// Gets the width of the big picture.
        /// </summary>
        /// <value>
        /// The width of the big picture.
        /// </value>
        public int BigPictureWidth => this.settingService.Get<int>("GeneralSettings.BigPictureWidth");

        /// <summary>
        /// Gets the height of the big picture.
        /// </summary>
        /// <value>
        /// The height of the big picture.
        /// </value>
        public int BigPictureHeight => this.settingService.Get<int>("GeneralSettings.BigPictureHeight");

        /// <summary>
        /// Gets the width of the small picture.
        /// </summary>
        /// <value>
        /// The width of the small picture.
        /// </value>
        public int SmallPictureWidth => this.settingService.Get<int>("GeneralSettings.SmallPictureWidth");

        /// <summary>
        /// Gets the height of the small picture.
        /// </summary>
        /// <value>
        /// The height of the small picture.
        /// </value>
        public int SmallPictureHeight => this.settingService.Get<int>("GeneralSettings.SmallPictureHeight");

        /// <summary>
        /// Gets the default width of the picture.
        /// </summary>
        /// <value>
        /// The default width of the picture.
        /// </value>
        public int DefaultPictureWidth => this.settingService.Get<int>("GeneralSettings.DefaultPictureWidth");

        /// <summary>
        /// Gets the default height of the picture.
        /// </summary>
        /// <value>
        /// The default height of the picture.
        /// </value>
        public int DefaultPictureHeight => this.settingService.Get<int>("GeneralSettings.DefaultPictureHeight");

        /// <summary>
        /// Gets the body base HTML.
        /// </summary>
        /// <value>
        /// The body base HTML.
        /// </value>
        public string BodyBaseHtml => this.settingService.Get<string>("GeneralSettings.BodyBaseHtml");

        /// <summary>
        /// Gets the site URL.
        /// </summary>
        /// <value>
        /// The site URL.
        /// </value>
        public string SiteUrl => this.settingService.Get<string>("GeneralSettings.SiteUrl");
    }
}