//-----------------------------------------------------------------------
// <copyright file="ReportsController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using System.Threading.Tasks;
    using Adopters.Api.Models;
    using Adopters.Business.Configuration;
    using Adopters.Business.Services;
    using Beto.Core.Data.Files;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Adopters API Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/reports")]
    public class ReportsController : BaseApiController
    {
        /// <summary>
        /// The files helper
        /// </summary>
        private readonly IFilesHelper filesHelper;

        /// <summary>
        /// The report service
        /// </summary>
        private readonly IReportService reportService;

        /// <summary>
        /// The general settings
        /// </summary>
        private readonly IGeneralSettings generalSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="reportService">The report service.</param>
        /// <param name="filesHelper">The files helper.</param>
        /// <param name="generalSettings">The general settings.</param>
        public ReportsController(
            IMessageExceptionFinder messageExceptionFinder,
            IReportService reportService,
            IFilesHelper filesHelper,
            IGeneralSettings generalSettings) : base(messageExceptionFinder)
        {
            this.reportService = reportService;
            this.filesHelper = filesHelper;
            this.generalSettings = generalSettings;
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>the task</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ReportFilterModel filter)
        {
            var reports = await this.reportService.GetAll(
                filter.Keyword,
                filter.Email,
                filter.Name,
                filter.LocationId,
                filter.IsPositive,
                orderBy: filter.OrderByEnum,
                page: filter.Page,
                pageSize: filter.PageSize);

            var models = reports.ToModels(this.filesHelper, Url.Content, this.generalSettings.SmallPictureWidth, this.generalSettings.SmallPictureHeight);

            return this.Ok(models, reports.HasNextPage, reports.TotalCount);
        }
    }
}