//-----------------------------------------------------------------------
// <copyright file="CorePictureResizerService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using Beto.Core.Data.Files;
    using Huellitas.Business.Extensions;
    using ImageSharp;
    using ImageSharp.Processing;

    /// <summary>
    /// Service of resize images
    /// </summary>
    /// <seealso cref="Beto.Core.Data.Files.IPictureResizerService" />
    public class CorePictureResizerService : ICorePictureResizerService
    {
        /// <summary>
        /// The log service
        /// </summary>
        private readonly ILogService logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorePictureResizerService"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public CorePictureResizerService(
            ILogService logService)
        {
            this.logService = logService;
        }

        /// <summary>
        /// Resizes the picture.
        /// </summary>
        /// <param name="resizedPath">The resized path.</param>
        /// <param name="originalPath">The original path.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void ResizePicture(string resizedPath, string originalPath, int width, int height)
        {
            try
            {
                using (var image = Image.Load(originalPath))
                {
                    var resizeOptions = new ResizeOptions()
                    {
                        Size = new SixLabors.Primitives.Size { Width = width, Height = height },
                        Mode = ResizeMode.Crop
                    };

                    image
                        .AutoOrient()
                        .Resize(resizeOptions)
                        .Save(resizedPath);
                }
            }
            catch (System.Exception e)
            {
                this.logService.Error(e);
            }
        }

        /// <summary>
        /// Resizes the picture.
        /// </summary>
        /// <param name="contentFile">The content file.</param>
        /// <param name="resizedPath">The resized path.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void ResizePicture(byte[] contentFile, string resizedPath, int width, int height)
        {
            try
            {
                using (var image = Image.Load(contentFile))
                {
                    var resizeOptions = new ResizeOptions()
                    {
                        Size = new SixLabors.Primitives.Size { Width = width, Height = height },
                        Mode = ResizeMode.Crop
                    };

                    image
                        .AutoOrient()
                        .Resize(resizeOptions)
                        .Save(resizedPath);
                }
            }
            catch (System.Exception e)
            {
                this.logService.Error(e);
            }
        }
    }
}