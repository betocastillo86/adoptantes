//-----------------------------------------------------------------------
// <copyright file="ServiceRegister.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Infraestructure.Start
{
    using Adopters.Business.Exceptions;
    using Adopters.Data.Core;
    using Autofac;
    using Beto.Core.Data;
    using Beto.Core.Exceptions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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
        }

        /// <summary>
        /// Registers the adopters services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="configuration">The configuration.</param>
        public static void RegisterAdoptersServices(this ContainerBuilder builder, IConfigurationRoot configuration)
        {
            builder.RegisterType<Business.Exceptions.MessageExceptionFinder>()
                .As<IMessageExceptionFinder>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AdoptersContext>()
                .As<IDbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LoggerService>()
                .As<ILoggerService>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EFRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}