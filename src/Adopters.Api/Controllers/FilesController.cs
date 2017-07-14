//-----------------------------------------------------------------------
// <copyright file="FilesController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using System.Threading.Tasks;
    using Adopters.Api.Models;
    using Adopters.Business.Services;
    using Adopters.Data.Entities;
    using Beto.Core.Data.Common;
    using Beto.Core.Data.Files;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Beto.Core.Web.Api.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Files Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/files")]
    public class FilesController : BaseApiController
    {
        /// <summary>
        /// The SEO helper
        /// </summary>
        private readonly ISeoHelper seoHelper;

        /// <summary>
        /// The files helper
        /// </summary>
        private readonly IFilesHelper filesHelper;

        /// <summary>
        /// The file service
        /// </summary>
        private readonly IFileService fileService;

        /// <summary>
        /// The picture service
        /// </summary>
        private readonly IPictureService pictureService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilesController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="seoHelper">The SEO helper.</param>
        /// <param name="filesHelper">The files helper.</param>
        /// <param name="fileService">The file service.</param>
        /// <param name="pictureService">The picture service.</param>
        public FilesController(
            IMessageExceptionFinder messageExceptionFinder,
            ISeoHelper seoHelper,
            IFilesHelper filesHelper,
            IFileService fileService,
            IPictureService pictureService) : base(messageExceptionFinder)
        {
            this.seoHelper = seoHelper;
            this.filesHelper = filesHelper;
            this.fileService = fileService;
            this.pictureService = pictureService;
        }

        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the file id and thumbnail Url</returns>
        [HttpPost]
        [Authorize]
        [RequiredModel]
        public async Task<IActionResult> Post(PostFileModel model)
        {
            var file = new File();

            foreach (var dataFile in model.Files)
            {
                file.Name = model.Name ?? System.IO.Path.GetFileNameWithoutExtension(dataFile.FileName);
                file.FileName = string.Concat(this.seoHelper.GenerateFriendlyName(file.Name), System.IO.Path.GetExtension(dataFile.FileName));
                file.MimeType = this.filesHelper.GetContentTypeByFileName(file.FileName);

                using (var streamFile = dataFile.OpenReadStream())
                {
                    var fileBinary = new byte[streamFile.Length];
                    streamFile.Read(fileBinary, 0, fileBinary.Length);
                    await this.fileService.Insert(file, fileBinary);
                }
            }

            var thumbnail = this.pictureService.GetPicturePath(file, 200, 200, true);

            return this.Ok(new { Id = file.Id, Thumbnail = thumbnail });
        }
    }
}