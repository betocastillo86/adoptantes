//-----------------------------------------------------------------------
// <copyright file="ServiceRegister.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Infraestructure.Start
{
    using Adopters.Data.Core;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using Beto.Core.Exceptions;
    using Adopters.Business.Exceptions;

    /// <summary>
    /// Service Register of dependencies
    /// </summary>
    public static class ServiceRegister
    {
        /// <summary>
        /// Registers the adopters services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void RegisterAdoptersServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<AdoptersContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IMessageExceptionFinder, MessageExceptionFinder>();
        }
    }
}