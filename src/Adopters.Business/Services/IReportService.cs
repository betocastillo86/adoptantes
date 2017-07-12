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
    }
}