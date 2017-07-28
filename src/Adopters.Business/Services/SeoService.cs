//-----------------------------------------------------------------------
// <copyright file="SeoService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Adopters.Business.Configuration;
    using Beto.Core.Data.Common;

    /// <summary>
    /// The SEO service
    /// </summary>
    /// <seealso cref="Adopters.Business.Services.ISeoService" />
    public class SeoService : ISeoService
    {
        /// <summary>
        /// The general settings
        /// </summary>
        private readonly IGeneralSettings generalSettings;

        /// <summary>
        /// The report service
        /// </summary>
        private readonly IReportService reportService;

        /// <summary>
        /// The SEO helper
        /// </summary>
        private readonly ISeoHelper seoHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeoService"/> class.
        /// </summary>
        /// <param name="generalSettings">The general settings.</param>
        /// <param name="reportService">The report service.</param>
        /// <param name="seoHelper">The SEO helper.</param>
        public SeoService(
            IGeneralSettings generalSettings,
            IReportService reportService,
            ISeoHelper seoHelper)
        {
            this.generalSettings = generalSettings;
            this.reportService = reportService;
            this.seoHelper = seoHelper;
        }

        /// <summary>
        /// Gets the full route of the element
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="parameters">the routes</param>
        /// <returns>
        /// the full route
        /// </returns>
        public string GetFullRoute(string key, params string[] parameters)
        {
            var route = string.Format(this.GetRoute(key), parameters);
            return $"{this.generalSettings.SiteUrl}{(this.generalSettings.SiteUrl.EndsWith("/") ? string.Empty : "/")}{route}";
        }

        /// <summary>
        /// Gets the route.
        /// </summary>
        /// <param name="key">The key of the route.</param>
        /// <returns>
        /// the value of the route
        /// </returns>
        public string GetRoute(string key)
        {
            var route = string.Empty;
            if (this.GetRoutes().TryGetValue(key, out route))
            {
                return route;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the routes.
        /// </summary>
        /// <returns>
        /// the routes existent on the web site
        /// </returns>
        public IDictionary<string, string> GetRoutes()
        {
            var routes = new Dictionary<string, string>();
            routes.Add("reports", "reportados");
            routes.Add("newreport", "reportar");
            routes.Add("login", "registrarse");
            routes.Add("report", "reportado/{0}");
            routes.Add("home", string.Empty);
            return routes;
        }

        /// <summary>
        /// Gets the sitemap.
        /// </summary>
        /// <returns>the XML Site map</returns>
        public async Task<string> GetSitemap()
        {
            var routes = new List<SitemapRoute>();
            routes.Add(new SitemapRoute { Url = this.generalSettings.SiteUrl });
            routes.Add(new SitemapRoute { Url = this.GetFullRoute("reports") });
            routes.Add(new SitemapRoute { Url = this.GetFullRoute("newreport") });
            routes.Add(new SitemapRoute { Url = this.GetFullRoute("login") });

            var allReports = await this.reportService.GetAll();

            foreach (var report in allReports)
            {
                routes.Add(new SitemapRoute { Url = this.GetFullRoute("report", report.FriendlyName) });
            }

            return this.seoHelper.GetSiteMapXml(routes);
        }
    }
}