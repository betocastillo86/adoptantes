//-----------------------------------------------------------------------
// <copyright file="DatabaseInitialization.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Infraestructure.Start
{
    using Adopters.Data.Core;
    using Adopters.Data.Migrations.Seeding;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// Database initialization class for startup
    /// </summary>
    public static class DatabaseInitialization
    {
        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public static void InitDatabase(this IApplicationBuilder app, IHostingEnvironment env)
        {
            var context = (AdoptersContext)app.ApplicationServices.GetService(typeof(AdoptersContext));
            context.Database.EnsureCreated();
            context.EnsureSeeding();
        }
    }
}