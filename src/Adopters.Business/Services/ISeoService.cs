//-----------------------------------------------------------------------
// <copyright file="ISeoService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of SEO service
    /// </summary>
    public interface ISeoService
    {
        /// <summary>
        /// Gets the full route.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>the route</returns>
        string GetFullRoute(string key, params string[] parameters);

        /// <summary>
        /// Gets the route.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>the route</returns>
        string GetRoute(string key);

        /// <summary>
        /// Gets the routes.
        /// </summary>
        /// <returns>the routes</returns>
        IDictionary<string, string> GetRoutes();

        /// <summary>
        /// Gets the sitemap.
        /// </summary>
        /// <returns>The XML Site map</returns>
        Task<string> GetSitemap();
    }
}