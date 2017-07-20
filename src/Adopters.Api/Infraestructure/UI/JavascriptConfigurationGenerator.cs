//-----------------------------------------------------------------------
// <copyright file="JavascriptConfigurationGenerator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Infraestructure.UI
{
    using System;
    using System.IO;
    using System.Linq;
    using Adopters.Business.Configuration;
    using Adopters.Data.Entities;
    using Beto.Core.Caching;
    using Beto.Core.Data;
    using Microsoft.AspNetCore.Hosting;
    using Newtonsoft.Json;

    /// <summary>
    /// JS Configuration Generator
    /// </summary>
    /// <seealso cref="Adopters.Api.Infraestructure.UI.IJavascriptConfigurationGenerator" />
    public class JavascriptConfigurationGenerator : IJavascriptConfigurationGenerator
    {
        /// <summary>
        /// The security settings
        /// </summary>
        private readonly ISecuritySettings securitySettings;

        /// <summary>
        /// The general settings
        /// </summary>
        private readonly IGeneralSettings generalSettings;

        /// <summary>
        /// The cache manager
        /// </summary>
        private readonly ICacheManager cacheManager;

        /// <summary>
        /// The system setting repository
        /// </summary>
        private readonly IRepository<SystemSetting> systemSettingRepository;

        /// <summary>
        /// The environment
        /// </summary>
        private readonly IHostingEnvironment env;

        /// <summary>
        /// Initializes a new instance of the <see cref="JavascriptConfigurationGenerator"/> class.
        /// </summary>
        /// <param name="securitySettings">The security settings.</param>
        /// <param name="generalSettings">The general settings.</param>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="systemSettingRepository">The system setting repository.</param>
        /// <param name="env">The environment.</param>
        public JavascriptConfigurationGenerator(
            ISecuritySettings securitySettings,
            IGeneralSettings generalSettings,
            ICacheManager cacheManager,
            IRepository<SystemSetting> systemSettingRepository,
            IHostingEnvironment env)
        {
            this.securitySettings = securitySettings;
            this.generalSettings = generalSettings;
            this.cacheManager = cacheManager;
            this.systemSettingRepository = systemSettingRepository;
            this.env = env;
        }

        /// <summary>
        /// Creates the <c>javascript</c> configuration file.
        /// </summary>
        public void CreateJavascriptConfigurationFile()
        {
            this.cacheManager.Clear();

            var isDebug = false;

#if DEBUG
            isDebug = true;
#endif

            ////Actualiza la llave de cache del javascript
            var key = "GeneralSettings.ConfigJavascriptCacheKey";
            var cacheKey = this.systemSettingRepository.Table.FirstOrDefault(c => c.Name.Equals(key));

            this.SaveFile(false, this.GetFrontJson(isDebug, cacheKey?.Value));

            if (cacheKey == null)
            {
                this.systemSettingRepository.Insert(new SystemSetting() { Name = key, Value = Guid.NewGuid().ToString() });
            }
            else
            {
                cacheKey.Value = Guid.NewGuid().ToString();
                this.systemSettingRepository.Update(cacheKey);
            }

            ////Clears cache after creating file because of the javascript cache key
            this.cacheManager.Clear();
        }

        /// <summary>
        /// Gets the front JSON.
        /// </summary>
        /// <param name="isDebug">if set to <c>true</c> [is debug].</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <returns>the JSON</returns>
        private string GetFrontJson(bool isDebug, string cacheKey)
        {
            var config = new
            {
                general = new
                {
                    siteUrl = this.generalSettings.SiteUrl,
                    configJavascriptCacheKey = cacheKey
                },
                security = new
                {
                    facebookApiKey = this.securitySettings.FacebookApiKey,
                }
            };

            return JsonConvert.SerializeObject(config);
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="isAdmin">if set to <c>true</c> [is admin].</param>
        /// <param name="jsonString">The JSON string.</param>
        private void SaveFile(bool isAdmin, string jsonString)
        {
            ////If does not exist the directory. It creates it.
            var filename = $"{env.ContentRootPath}/wwwroot/js/{(isAdmin ? "admin" : "front")}.configuration.js";
            var directory = System.IO.Path.GetDirectoryName(filename);

            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            using (var stream = new FileStream(filename, FileMode.Create))
            {
                using (var sw = new System.IO.StreamWriter(stream))
                {
                    sw.Write($"var app = app || {{}}; app.Settings = {jsonString.ToString()}");
                }
            }
        }
    }
}