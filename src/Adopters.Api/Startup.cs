//-----------------------------------------------------------------------
// <copyright file="Startup.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api
{
    using System.IO;
    using Adopters.Api.Infraestructure.Start;
    using Adopters.Api.Infraestructure.UI;
    using Autofac;
    using Beto.Core.Web.Api.Filters;
    using Beto.Core.Web.Middleware;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.ResponseCompression;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Start class of project
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMiddleware<ExceptionsMiddleware>();

            app.InitDatabase(env);

            app.AddJWTAuthorization(env, loggerFactory);

            if (env.IsDevelopment())
            {
                app.UseCors("AdoptersPolicy");
            }

            app.UseResponseCompression();

            app.Use(async (context, next) =>
            {
                await next();
            
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api"))
                {
                    context.Request.Path = "/index.html";
                    context.Response.StatusCode = 200;
            
                    await next();
                }
            });

            app.UseStaticFiles();

            //app.UseDefaultFiles();

            app.UseMvc();

            this.CreateJavascriptFile(app);
        }

        /// <summary>
        /// Configures the container of AUTOFAC
        /// </summary>
        /// <param name="builder">container builder</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAdoptersServices(this.Configuration);
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(new FluentValidatorAttribute());
            })
            .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.RegisterAdoptersServices(this.Configuration);

            services.AddCors(c => c.AddPolicy(
                "AdoptersPolicy",
                builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression();
        }

        /// <summary>
        /// Creates the <c>javascript</c> file.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void CreateJavascriptFile(IApplicationBuilder builder)
        {
            var javascriptGenerator = (IJavascriptConfigurationGenerator)builder.ApplicationServices.GetService(typeof(IJavascriptConfigurationGenerator));
            javascriptGenerator.CreateJavascriptConfigurationFile();
        }
    }
}