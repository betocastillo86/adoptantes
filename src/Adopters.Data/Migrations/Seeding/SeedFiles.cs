//-----------------------------------------------------------------------
// <copyright file="SeedFiles.cs" company="Gabriel Castillo">
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
    /// Seed Files
    /// </summary>
    public static class SeedFiles
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Seed(AdoptersContext context)
        {
            var list = new List<File>();

            list.Add(new File() { FileName = "mi archivo.jpg", MimeType = "image/jpg", Name = "archivo" });

            foreach (var item in list)
            {
                if (!context.Files.Any(c => c.Name.Equals(item.Name)))
                {
                    context.Files.Add(item);
                }
            }

            context.SaveChanges();
        }
    }
}