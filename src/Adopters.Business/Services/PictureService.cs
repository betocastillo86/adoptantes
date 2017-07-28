//-----------------------------------------------------------------------
// <copyright file="PictureService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using Adopters.Data.Entities;
    using Beto.Core.Data.Files;

    /// <summary>
    /// Picture Service
    /// </summary>
    /// <seealso cref="Adopters.Business.Services.IPictureService" />
    public class PictureService : IPictureService
    {
        /// <summary>
        /// The files helper
        /// </summary>
        private readonly IFilesHelper filesHelper;

        /// <summary>
        /// The core picture service
        /// </summary>
        private readonly ICorePictureResizerService corePictureService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PictureService"/> class.
        /// </summary>
        /// <param name="filesHelper">The files helper.</param>
        /// <param name="corePictureService">The core picture service.</param>
        public PictureService(
            IFilesHelper filesHelper,
            ICorePictureResizerService corePictureService)
        {
            this.filesHelper = filesHelper;
            this.corePictureService = corePictureService;
        }

        /// <summary>
        /// Gets the picture path.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="forceResize">if set to <c>true</c> [force resize].</param>
        /// <param name="mode">the mode of resize</param>
        /// <returns>
        /// the path of the resized file
        /// </returns>
        public string GetPicturePath(File file, int width, int height, bool forceResize = false, ResizeMode mode = ResizeMode.Crop)
        {
            var resizedPhysicalPath = this.filesHelper.GetPhysicalPath(file, width, height);

            if (forceResize && !System.IO.File.Exists(resizedPhysicalPath))
            {
                var originalPath = this.filesHelper.GetPhysicalPath(file);
                this.corePictureService.ResizePicture(resizedPhysicalPath, originalPath, width, height, mode);
            }

            return this.filesHelper.GetFullPath(file, null, width, height);
        }
    }
}