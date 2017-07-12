//-----------------------------------------------------------------------
// <copyright file="EnsureSeedingExtension.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Migrations.Seeding
{
    using Adopters.Data.Core;

    /// <summary>
    /// Ensure seeding extension
    /// </summary>
    public static class EnsureSeedingExtension
    {
        /// <summary>
        /// Ensures the seeding of the database
        /// </summary>
        /// <param name="context">The context.</param>
        public static void EnsureSeeding(this AdoptersContext context)
        {
            if (context.AllMigrationsApplied())
            {
                EnsureSeedingExtension.Seed(context);
            }
        }

        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        private static void Seed(AdoptersContext context)
        {
            SeedSettings.Seed(context);
            SeedLocations.Seed(context);
            SeedFiles.Seed(context);
            SeedUsers.Seed(context);
            SeedReports.Seed(context);
        }
    }
}