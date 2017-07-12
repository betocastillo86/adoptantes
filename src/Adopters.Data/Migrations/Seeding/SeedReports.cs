//-----------------------------------------------------------------------
// <copyright file="SeedReports.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Migrations.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Adopters.Data.Core;
    using Adopters.Data.Entities;

    /// <summary>
    /// Seed Reports
    /// </summary>
    public static class SeedReports
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Seed(AdoptersContext context)
        {
            var user = context.Users.FirstOrDefault();
            var location = context.Locations.FirstOrDefault();
            var file = context.Files.FirstOrDefault();

            var list = new List<Report>();

            list.Add(new Report() { Name = "Reporte de prueba 1", Description = "Reporte de prueba 1", Email = "reporte@prueba.com", UserId = user.Id, LocationId = location.Id, CountComments = 1, CountDislikes = 2, CountLikes = 3, CreationDate = DateTime.Now, Deleted = true, FacebookProfile = "facebook", Positive = true, TwitterProfile = "twitter", FileId = file.Id });
            list.Add(new Report() { Name = "Reporte de prueba 2", Description = "Reporte de prueba 2", Email = "reporte@prueba.com", UserId = user.Id, LocationId = location.Id, CountComments = 1, CountDislikes = 2, CountLikes = 3, CreationDate = DateTime.Now, Deleted = true, FacebookProfile = "facebook", Positive = true, TwitterProfile = "twitter", FileId = file.Id });

            foreach (var item in list)
            {
                if (!context.Reports.Any(c => c.Name.Equals(item.Name)))
                {
                    context.Reports.Add(item);
                }
            }

            context.SaveChanges();
        }
    }
}