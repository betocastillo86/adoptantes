//-----------------------------------------------------------------------
// <copyright file="IReportService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System;
    using System.Threading.Tasks;
    using Adopters.Data.Entities;
    using Beto.Core.Data;

    /// <summary>
    /// Interface of reports service
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Gets all reports depending of the filter
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="isPositive">The is positive.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="creationDateFrom">The creation date from.</param>
        /// <param name="creationDateTo">The creation date to.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the list of reports</returns>
        Task<IPagedList<Report>> GetAll(
            string keyword = null,
            string email = null,
            string name = null,
            int? locationId = null,
            bool? isPositive = null,
            int? userId = null,
            DateTime? creationDateFrom = null,
            DateTime? creationDateTo = null,
            ReportOrderBy orderBy = ReportOrderBy.Recent,
            int page = 0,
            int pageSize = int.MaxValue);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeLocation">if set to <c>true</c> [include location].</param>
        /// <param name="includeUser">if set to <c>true</c> [include user].</param>
        /// <returns>the report</returns>
        Task<Report> GetById(int id, bool includeLocation = false, bool includeUser = false);

        /// <summary>
        /// Gets the report by identifier or friendly name.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeLocation">if set to <c>true</c> [include location].</param>
        /// <param name="includeUser">if set to <c>true</c> [include user].</param>
        /// <returns>the report</returns>
        Task<Report> GetByIdOrFriendlyName(string id, bool includeLocation = false, bool includeUser = false);

        /// <summary>
        /// Inserts the specified report.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <returns>the task</returns>
        Task Insert(Report report);

        /// <summary>
        /// Likes a report.
        /// </summary>
        /// <param name="id">The identifier of the report.</param>
        /// <param name="userId">the user who gives a like</param>
        /// <param name="positive">if set to <c>true</c> [like].</param>
        /// <returns>the count of likes if [likes] is true, or the dislikes if [like] is false</returns>
        Task<int> Like(int id, int userId, bool positive);

        /// <summary>
        /// Updates the specified report.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <returns>the task</returns>
        Task Update(Report report);
    }
}