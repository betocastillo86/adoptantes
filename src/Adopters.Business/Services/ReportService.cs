//-----------------------------------------------------------------------
// <copyright file="ReportService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Adopters.Data.Entities;
    using Beto.Core.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Reports Service
    /// </summary>
    /// <seealso cref="Adopters.Business.Services.IReportService" />
    public class ReportService : IReportService
    {
        /// <summary>
        /// The report repository
        /// </summary>
        private readonly IRepository<Report> reportRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportService"/> class.
        /// </summary>
        /// <param name="reportRepository">The report repository.</param>
        public ReportService(IRepository<Report> reportRepository)
        {
            this.reportRepository = reportRepository;
        }

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
        /// <returns>
        /// the list of reports
        /// </returns>
        public async Task<IPagedList<Report>> GetAll(
            string keyword = null,
            string email = null,
            string name = null,
            int? locationId = default(int?),
            bool? isPositive = default(bool?),
            int? userId = default(int?),
            DateTime? creationDateFrom = default(DateTime?),
            DateTime? creationDateTo = default(DateTime?),
            ReportOrderBy orderBy = ReportOrderBy.Recent,
            int page = 0,
            int pageSize = int.MaxValue)
        {
            var query = this.reportRepository.Table
                .Include(c => c.User)
                .Include(c => c.File)
                .Include(c => c.Location)
                .Where(c => !c.Deleted);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(c => c.Name.Contains(keyword) || c.Description.Contains(keyword) || c.Email.Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(c => c.Email.Contains(email));
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (locationId.HasValue)
            {
                query = query.Where(c => c.LocationId == locationId.Value);
            }

            if (isPositive.HasValue)
            {
                query = query.Where(c => c.Positive.Equals(isPositive.Value));
            }

            if (userId.HasValue)
            {
                query = query.Where(c => c.UserId == userId.Value);
            }

            if (creationDateFrom.HasValue)
            {
                query = query.Where(c => c.CreationDate >= creationDateFrom.Value);
            }

            if (creationDateTo.HasValue)
            {
                query = query.Where(c => c.CreationDate <= creationDateTo.Value);
            }

            switch (orderBy)
            {
                case ReportOrderBy.Name:
                    query = query.OrderBy(c => c.Name);
                    break;

                case ReportOrderBy.Old:
                    query = query.OrderBy(c => c.CreationDate);
                    break;

                default:
                case ReportOrderBy.Recent:
                    query = query.OrderByDescending(c => c.CreationDate);
                    break;

                case ReportOrderBy.Dislikes:
                    query = query.OrderByDescending(c => c.CountDislikes);
                    break;

                case ReportOrderBy.Likes:
                    query = query.OrderByDescending(c => c.CountLikes);
                    break;
            }

            return await new PagedList<Report>().Async(query, page, pageSize);
        }
    }
}