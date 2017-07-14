//-----------------------------------------------------------------------
// <copyright file="SeedSettings.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Migrations.Seeding
{
    using System.Collections.Generic;
    using System.Linq;
    using Adopters.Data.Core;
    using Adopters.Data.Entities;

    /// <summary>
    /// Seed settings class
    /// </summary>
    public static class SeedSettings
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Seed(AdoptersContext context)
        {
            var list = new List<SystemSetting>();

            list.Add(new SystemSetting() { Name = "GeneralSettings.BigPictureWidth", Value = "800" });
            list.Add(new SystemSetting() { Name = "GeneralSettings.BigPictureHeight", Value = "800" });
            list.Add(new SystemSetting() { Name = "GeneralSettings.SmallPictureWidth", Value = "500" });
            list.Add(new SystemSetting() { Name = "GeneralSettings.SmallPictureHeight", Value = "500" });
            list.Add(new SystemSetting() { Name = "SecuritySettings.AuthenticationAudience", Value = "theaudienceofadopters" });
            list.Add(new SystemSetting() { Name = "SecuritySettings.AuthenticationIssuer", Value = "adoptantes.com" });
            list.Add(new SystemSetting() { Name = "SecuritySettings.AuthenticationSecretKey", Value = "thesecretkeyofjwt" });
            list.Add(new SystemSetting() { Name = "SecuritySettings.ExpirationTokenMinutes", Value = "14000" });
            list.Add(new SystemSetting() { Name = "SecuritySettings.MaxRequestFileUploadMB", Value = "3" });
            list.Add(new SystemSetting() { Name = "GeneralSettings.DefaultPictureWidth", Value = "1500" });
            list.Add(new SystemSetting() { Name = "GeneralSettings.DefaultPictureHeight", Value = "1500" });

            foreach (var item in list)
            {
                if (!context.SystemSettings.Any(c => c.Name.Equals(item.Name)))
                {
                    context.SystemSettings.Add(item);
                }
            }

            context.SaveChanges();
        }
    }
}