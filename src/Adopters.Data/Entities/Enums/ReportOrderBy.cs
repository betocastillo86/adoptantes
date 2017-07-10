//-----------------------------------------------------------------------
// <copyright file="ReportOrderBy.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    /// <summary>
    /// Options of order by with reports
    /// </summary>
    public enum ReportOrderBy
    {
        /// <summary>
        /// Sorts by name
        /// </summary>
        Name,

        /// <summary>
        /// Sorts by creation date
        /// </summary>
        CreationDate,

        /// <summary>
        /// Sort by more dislikes
        /// </summary>
        Dislikes,

        /// <summary>
        /// Sorts by likes
        /// </summary>
        Likes
    }
}