//-----------------------------------------------------------------------
// <copyright file="DbContextExtensions.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Core
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// Database context extensions
    /// </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        /// Validates if All migrations were applied.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>if the migrations were applied</returns>
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
    }
}