//-----------------------------------------------------------------------
// <copyright file="SeedUsers.cs" company="Gabriel Castillo">
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
    /// Seed Users of database
    /// </summary>
    public static class SeedUsers
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Seed(AdoptersContext context)
        {
            var list = new List<User>();

            list.Add(new Entities.User() { Name = "Administrador", Email = "admin@admin.com", CreationDate = DateTime.Now, FacebookId = "123", Role = Role.Admin });

            foreach (var item in list)
            {
                if (!context.Users.Any(c => c.Email.Equals(item.Email)))
                {
                    context.Users.Add(item);
                }
            }

            context.SaveChanges();
        }
    }
}