//-----------------------------------------------------------------------
// <copyright file="MigrationsDbContext.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    /// <summary>
    /// Migrations DB Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Infrastructure.IDbContextFactory{Adopters.Data.Core.AdoptersContext}" />
    public class MigrationsDbContext : IDbContextFactory<AdoptersContext>
    {
        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="options">Information about the environment an application is running in.</param>
        /// <returns>
        /// An instance of <typeparamref name="TContext" />.
        /// </returns>
        public AdoptersContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<AdoptersContext>();
            builder.UseSqlServer("Server=localhost;Database=Adopters;User Id=sa;Password=Temporal1;MultipleActiveResultSets=false");
            return new AdoptersContext(builder.Options);
        }
    }
}