//-----------------------------------------------------------------------
// <copyright file="SeoController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using System.Threading.Tasks;
    using Adopters.Business.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The SEO Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class SeoController : Controller
    {
        /// <summary>
        /// The SEO service
        /// </summary>
        private readonly ISeoService seoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeoController"/> class.
        /// </summary>
        /// <param name="seoService">The SEO service.</param>
        public SeoController(ISeoService seoService)
        {
            this.seoService = seoService;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>the action</returns>
        [Route("sitemap.xml")]
        public async Task<IActionResult> Get()
        {
            var xml = await this.seoService.GetSitemap();
            return this.Content(xml, "text/xml");
        }
    }
}