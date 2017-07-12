//-----------------------------------------------------------------------
// <copyright file="IGeneralSettings.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Configuration
{
    /// <summary>
    /// Interface of General Settings
    /// </summary>
    public interface IGeneralSettings
    {
        /// <summary>
        /// Gets the width of the big picture.
        /// </summary>
        /// <value>
        /// The width of the big picture.
        /// </value>
        int BigPictureWidth { get; }

        /// <summary>
        /// Gets the height of the big picture.
        /// </summary>
        /// <value>
        /// The height of the big picture.
        /// </value>
        int BigPictureHeight { get; }

        /// <summary>
        /// Gets the width of the small picture.
        /// </summary>
        /// <value>
        /// The width of the small picture.
        /// </value>
        int SmallPictureWidth { get; }

        /// <summary>
        /// Gets the height of the small picture.
        /// </summary>
        /// <value>
        /// The height of the small picture.
        /// </value>
        int SmallPictureHeight { get; }
    }
}