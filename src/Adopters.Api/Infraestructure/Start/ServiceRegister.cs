//-----------------------------------------------------------------------
// <copyright file="ServiceRegister.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Infraestructure.Start
{
    using Adopters.Api.Infraestructure.Security;
    using Adopters.Business.Configuration;
    using Adopters.Business.Exceptions;
    using Adopters.Business.Security;
    using Adopters.Business.Services;
    using Adopters.Data.Core;
    using Autofac;
    using Beto.Core.Caching;
    using Beto.Core.Data;
    using Beto.Core.Data.Common;
    using Beto.Core.Data.Configuration;
    using Beto.Core.Data.Files;
    using Beto.Core.Data.Users;
    using Beto.Core.EventPublisher;
    using Beto.Core.Exceptions;
    using Beto.Core.Helpers;
    using Beto.Core.Registers;
    using Beto.Core.Web.Security;
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
            //// Settings
            builder.RegisterType<GeneralSettings>()
                .As<IGeneralSettings>()
                .SingleInstance();

            builder.RegisterType<SecuritySettings>()
                .As<ISecuritySettings>()
                .SingleInstance();

            //// Adopters Services

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .SingleInstance();

            builder.RegisterType<ReportService>()
                .As<IReportService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LogService>()
                .As<ILogService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExternalAuthenticationService>()
                .As<IExternalAuthenticationService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<WorkContext>()
                .As<IWorkContext>()
                .InstancePerLifetimeScope();

            //// Core services

            builder.RegisterType<Business.Exceptions.MessageExceptionFinder>()
                .As<IMessageExceptionFinder>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FilesHelper>()
                .As<IFilesHelper>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AdoptersContext>()
                .As<IDbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LoggerService>()
                .As<ILoggerService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthenticationTokenGeneratorJWT>()
                .As<IAuthenticationTokenGenerator>()
                .InstancePerLifetimeScope();

            ////TODO:Pasar a Autofac
            builder.RegisterType<DefaultServiceFactory>()
               .As<IServiceFactory>()
               .InstancePerLifetimeScope();

            builder.RegisterType<MemoryCacheManager>()
               .As<ICacheManager>()
               .InstancePerLifetimeScope();

            builder.RegisterType<Publisher>()
               .As<IPublisher>()
               .InstancePerLifetimeScope();

            builder.RegisterType<SeoHelper>()
               .As<ISeoHelper>()
               .InstancePerLifetimeScope();

            builder.RegisterType<HttpContextHelper>()
                .As<IHttpContextHelper>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SocialAuthenticationService>()
                .As<ISocialAuthenticationService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CorePictureResizerService>()
                .As<ICorePictureResizerService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CoreSettingService>()
                .As<ICoreSettingService>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EFRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}