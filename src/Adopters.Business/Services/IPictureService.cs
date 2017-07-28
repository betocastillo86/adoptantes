//-----------------------------------------------------------------------
// <copyright file="IPictureService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using Adopters.Data.Entities;
    using Beto.Core.Data.Files;

    /// <summary>
    /// Interface of picture service
    /// </summary>
    public interface IPictureService
    {
        /// <summary>
        /// Gets the picture path.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="forceResize">if set to <c>true</c> [force resize].</param>
        /// <param name="mode">the mode of resize</param>
        /// <returns>the path of the resized file</returns>
        string GetPicturePath(File file, int width, int height, bool forceResize = false, ResizeMode mode = ResizeMode.Crop);
    }
}