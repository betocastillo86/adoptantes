//-----------------------------------------------------------------------
// <copyright file="ReportsController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Adopters.Api.Models;
    using Adopters.Business.Configuration;
    using Adopters.Business.Exceptions;
    using Adopters.Business.Extensions;
    using Adopters.Business.Security;
    using Adopters.Business.Services;
    using Adopters.Data.Entities;
    using Beto.Core.Data;
    using Beto.Core.Data.Files;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Beto.Core.Web.Api.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Adopters API Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/reports")]
    public class ReportsController : BaseApiController
    {
        /// <summary>
        /// The file service
        /// </summary>
        private readonly IFileService fileService;

        /// <summary>
        /// The files helper
        /// </summary>
        private readonly IFilesHelper filesHelper;

        /// <summary>
        /// The general settings
        /// </summary>
        private readonly IGeneralSettings generalSettings;

        /// <summary>
        /// The picture service
        /// </summary>
        private readonly IPictureService pictureService;

        /// <summary>
        /// The report service
        /// </summary>
        private readonly IReportService reportService;

        /// <summary>
        /// The work context
        /// </summary>
        private readonly IWorkContext workContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="reportService">The report service.</param>
        /// <param name="filesHelper">The files helper.</param>
        /// <param name="generalSettings">The general settings.</param>
        /// <param name="workContext">The work context.</param>
        /// <param name="pictureService">The picture service.</param>
        /// <param name="fileService">the file service</param>
        public ReportsController(
            IMessageExceptionFinder messageExceptionFinder,
            IReportService reportService,
            IFilesHelper filesHelper,
            IGeneralSettings generalSettings,
            IWorkContext workContext,
            IPictureService pictureService,
            IFileService fileService) : base(messageExceptionFinder)
        {
            this.reportService = reportService;
            this.filesHelper = filesHelper;
            this.generalSettings = generalSettings;
            this.workContext = workContext;
            this.pictureService = pictureService;
            this.fileService = fileService;
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

        /// <summary>
        /// Gets the specified report by identifier or friendlyName
        /// </summary>
        /// <param name="id">The identifier or friendlyName.</param>
        /// <returns>the action</returns>
        [HttpGet]
        [Route("{id}", Name = "Get_Report_Id")]
        public async Task<IActionResult> Get(string id)
        {
            var report = await this.reportService.GetByIdOrFriendlyName(id, true, true);

            if (report != null)
            {
                var model = report.ToModel(this.filesHelper, Url.Content, this.generalSettings.BigPictureWidth, this.generalSettings.BigPictureHeight);
                return this.Ok(model);
            }
            else
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the result</returns>
        [Authorize]
        [HttpPost]
        [RequiredModel]
        public async Task<IActionResult> Post([FromBody] ReportModel model)
        {
            var report = new Report()
            {
                Description = model.Description,
                Email = model.Email,
                FacebookProfile = model.FacebookProfile,
                FileId = model.Image?.Id,
                LocationId = model.Location?.Id,
                Name = model.Name,
                Positive = model.Positive,
                TwitterProfile = model.TwitterProfile,
                UserId = this.workContext.CurrentUserId
            };

            try
            {
                await this.reportService.Insert(report);

                if (report.FileId.HasValue)
                {
                    var file = await this.fileService.GetById(report.FileId.Value);
                    this.pictureService.GetPicturePath(file, this.generalSettings.BigPictureWidth, this.generalSettings.BigPictureHeight, true, ResizeMode.Pad);
                    this.pictureService.GetPicturePath(file, this.generalSettings.SmallPictureWidth, this.generalSettings.SmallPictureHeight, true, ResizeMode.BoxPad);
                }

                var createdUri = this.Url.Link("Get_Report_Id", new BaseModel() { Id = report.Id });
                return this.Created(createdUri, new BaseModel { Id = report.Id });
            }
            catch (AdoptersException e)
            {
                if (e.Code == AdopterExceptionCode.UserEmailAlreadyUsed)
                {
                    return this.BadRequest(e.Code, "Email");
                }
                else
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>the action result</returns>
        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        [RequiredModel]
        public async Task<IActionResult> Put(int id, [FromBody] ReportModel model)
        {
            var report = await this.reportService.GetById(id);

            if (report != null)
            {
                if (this.workContext.CurrentUser.IsAdmin() || report.UserId == this.workContext.CurrentUserId)
                {
                    var fileChanged = report.FileId != model.Image?.Id;

                    report.Name = model.Name;
                    report.Description = model.Description;
                    report.Email = model.Email;
                    report.FileId = model.Image?.Id;
                    report.LocationId = model.Location?.Id;
                    report.Positive = model.Positive;
                    report.TwitterProfile = model.TwitterProfile;
                    report.FacebookProfile = model.FacebookProfile;

                    try
                    {
                        await this.reportService.Update(report);

                        if (fileChanged && report.FileId.HasValue)
                        {
                            var file = await this.fileService.GetById(report.FileId.Value);
                            this.pictureService.GetPicturePath(file, this.generalSettings.BigPictureWidth, this.generalSettings.BigPictureHeight, true);
                            this.pictureService.GetPicturePath(file, this.generalSettings.SmallPictureWidth, this.generalSettings.SmallPictureHeight, true);
                        }

                        return this.Ok();
                    }
                    catch (AdoptersException e)
                    {
                        if (e.Code == AdopterExceptionCode.UserEmailAlreadyUsed)
                        {
                            return this.BadRequest(e.Code, "Email");
                        }
                        else
                        {
                            throw e;
                        }
                    }
                }
                else
                {
                    return this.Forbid();
                }
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}