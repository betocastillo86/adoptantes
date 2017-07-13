//-----------------------------------------------------------------------
// <copyright file="ReportLikesController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using System.Threading.Tasks;
    using Adopters.Api.Models;
    using Adopters.Business.Exceptions;
    using Adopters.Business.Security;
    using Adopters.Business.Services;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Beto.Core.Web.Api.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Report Likes Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/reports/{id:int}/like")]
    public class ReportLikesController : BaseApiController
    {
        /// <summary>
        /// The report service
        /// </summary>
        private readonly IReportService reportService;

        /// <summary>
        /// The work context
        /// </summary>
        private readonly IWorkContext workContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportLikesController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="reportService">The report service.</param>
        /// <param name="workContext">The work context.</param>
        public ReportLikesController(
            IMessageExceptionFinder messageExceptionFinder,
            IReportService reportService,
            IWorkContext workContext) : base(messageExceptionFinder)
        {
            this.reportService = reportService;
            this.workContext = workContext;
        }

        /// <summary>
        /// Posts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>the action</returns>
        [Authorize]
        [HttpPost]
        [RequiredModel]
        public async Task<IActionResult> Post(int id, [FromBody] ReportLikeModel model)
        {
            var report = await this.reportService.GetById(id);

            if (report != null)
            {
                try
                {
                    var likes = await this.reportService.Like(id, this.workContext.CurrentUserId, model.Positive);

                    return this.Ok(new
                    {
                        CountLikes = model.Positive ? likes : report.CountLikes,
                        CountDislikes = model.Positive ? report.CountDislikes : likes
                    });
                }
                catch (AdoptersException e)
                {
                    return this.BadRequest(e);
                }
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}