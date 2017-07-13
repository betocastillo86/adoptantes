//-----------------------------------------------------------------------
// <copyright file="ReportLikeModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    /// <summary>
    /// Like Report Model
    /// </summary>
    public class ReportLikeModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ReportLikeModel"/> is like.
        /// </summary>
        /// <value>
        ///   <c>true</c> if like; otherwise, <c>false</c>.
        /// </value>
        public bool Positive { get; set; }
    }
}