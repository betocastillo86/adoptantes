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
    using Adopters.Business.Exceptions;
    using Adopters.Data.Entities;
    using Beto.Core.Data;
    using Beto.Core.Data.Common;
    using Beto.Core.EventPublisher;
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
        /// The report like repository
        /// </summary>
        private readonly IRepository<ReportLike> reportLikeRepository;

        /// <summary>
        /// The publisher
        /// </summary>
        private readonly IPublisher publisher;

        /// <summary>
        /// The SEO helper
        /// </summary>
        private readonly ISeoHelper seoHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportService"/> class.
        /// </summary>
        /// <param name="reportRepository">The report repository.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="seoHelper">The SEO helper.</param>
        /// <param name="reportLikeRepository">The report like repository.</param>
        public ReportService(
            IRepository<Report> reportRepository,
            IPublisher publisher,
            ISeoHelper seoHelper,
            IRepository<ReportLike> reportLikeRepository)
        {
            this.reportRepository = reportRepository;
            this.publisher = publisher;
            this.seoHelper = seoHelper;
            this.reportLikeRepository = reportLikeRepository;
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

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeLocation">if set to <c>true</c> [include location].</param>
        /// <param name="includeUser">if set to <c>true</c> [include user].</param>
        /// <returns>
        /// the report
        /// </returns>
        public async Task<Report> GetById(int id, bool includeLocation = false, bool includeUser = false)
        {
            var query = this.reportRepository.Table
                .Include(c => c.File)
                .AsQueryable();

            if (includeLocation)
            {
                query = query.Include(c => c.Location);
            }

            if (includeUser)
            {
                query = query.Include(c => c.User);
            }

            return await query.FirstOrDefaultAsync(c => c.Id == id && !c.Deleted);
        }

        /// <summary>
        /// Gets the report by identifier or friendly name.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeLocation">if set to <c>true</c> [include location].</param>
        /// <param name="includeUser">if set to <c>true</c> [include user].</param>
        /// <returns>
        /// the report
        /// </returns>
        public async Task<Report> GetByIdOrFriendlyName(string id, bool includeLocation = false, bool includeUser = false)
        {
            int idInt = 0;

            if (int.TryParse(id, out idInt))
            {
                return await this.GetById(idInt, includeLocation, includeUser);
            }
            else
            {
                var query = this.reportRepository.Table
                    .Include(c => c.File)
                    .AsQueryable();

                if (includeLocation)
                {
                    query = query.Include(c => c.Location);
                }

                if (includeUser)
                {
                    query = query.Include(c => c.User);
                }

                return await query.FirstOrDefaultAsync(c => c.FriendlyName.Equals(id) && !c.Deleted);
            }
        }

        /// <summary>
        /// Inserts the specified report.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task Insert(Report report)
        {
            report.CreationDate = DateTime.Now;

            report.FriendlyName = this.seoHelper.GenerateFriendlyName($"{report.Name} {(report.Positive ? "buen" : "mal")} adoptante", this.reportRepository.Table);

            try
            {
                await this.reportRepository.InsertAsync(report);

                await this.publisher.EntityInserted(report);
            }
            catch (DbUpdateException e)
            {
                if (e.ToString().Contains("'IX_Report_Email'"))
                {
                    throw new AdoptersException(AdopterExceptionCode.UserEmailAlreadyUsed);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Likes a report.
        /// </summary>
        /// <param name="id">The identifier of the report.</param>
        /// <param name="userId">the user who gives a like</param>
        /// <param name="positive">if set to <c>true</c> [like].</param>
        /// <returns>
        /// the count of likes if [likes] is true, or the dislikes if [like] is false
        /// </returns>
        public async Task<int> Like(int id, int userId, bool positive)
        {
            if (!this.reportLikeRepository.Table.Any(c => c.ReportId == id && c.UserId == userId))
            {
                var report = await this.reportRepository.Table.FirstOrDefaultAsync(c => c.Id == id);
                if (report != null)
                {
                    await this.reportLikeRepository.InsertAsync(new ReportLike()
                    {
                        ReportId = id,
                        UserId = userId,
                        Positive = positive,
                        CreationDate = DateTime.Now
                    });

                    var countLikes = this.reportLikeRepository.Table.Count(c => c.Positive == positive && c.ReportId == id);

                    if (positive)
                    {
                        report.CountLikes = countLikes;
                    }
                    else
                    {
                        report.CountDislikes = countLikes;
                    }

                    await this.reportRepository.UpdateAsync(report);

                    return countLikes;
                }
                else
                {
                    throw new AdoptersException(AdopterExceptionCode.RowNotFound);
                }
            }
            else
            {
                throw new AdoptersException(AdopterExceptionCode.UserAlreadyLikedReport);
            }
        }

        /// <summary>
        /// Updates the specified report.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task Update(Report report)
        {
            await this.reportRepository.UpdateAsync(report);

            await this.publisher.EntityUpdated(report);
        }
    }
}