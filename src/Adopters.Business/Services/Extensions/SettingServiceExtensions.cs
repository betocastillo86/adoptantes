//-----------------------------------------------------------------------
// <copyright file="SettingServiceExtensions.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services.Extensions
{
    using Adopters.Data.Entities;
    using Beto.Core.Data.Configuration;

    /// <summary>
    /// Setting Service Extensions
    /// </summary>
    public static class SettingServiceExtensions
    {
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="settingService">The setting service.</param>
        /// <param name="key">The key.</param>
        /// <returns>the value of the setting</returns>
        public static TValue Get<TValue>(this ICoreSettingService settingService, string key)
        {
            return settingService.GetCachedSetting<TValue, SystemSetting>(key);
        }
    }
}