//-----------------------------------------------------------------------
// <copyright file="LogService.cs" company="Gabriel Castillo">
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
    using Beto.Core.Helpers;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Log Service
    /// </summary>
    /// <seealso cref="Adopters.Business.Services.ILogService" />
    public class LogService : ILogService
    {
        /// <summary>
        /// The context helpers
        /// </summary>
        private readonly IHttpContextHelper contextHelpers;

        /// <summary>
        /// The log repository
        /// </summary>
        private readonly IRepository<Log> logRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        /// <param name="logRepository">The log repository.</param>
        /// <param name="contextHelpers">The context helpers.</param>
        public LogService(
            IRepository<Log> logRepository,
            IHttpContextHelper contextHelpers)
        {
            this.logRepository = logRepository;
            this.contextHelpers = contextHelpers;
        }

        /// <summary>
        /// Inserts the specified log level.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <param name="user">The user.</param>
        /// <returns>the value</returns>
        public async Task Insert(LogLevel logLevel, string shortMessage, string fullMessage = "", User user = null)
        {
            var log = new Log()
            {
                CreationDate = DateTime.Now,
                FullMessage = fullMessage,
                ShortMessage = shortMessage,
                IpAddress = this.contextHelpers.GetCurrentIpAddress(),
                PageUrl = this.contextHelpers.GetThisPageUrl(true),
                UserId = user != null ? user.Id : (int?)null,
                LogLevel = logLevel
            };

            await this.logRepository.InsertAsync(log);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the list of logs
        /// </returns>
        public async Task<IPagedList<Log>> GetAll(string keyword, int page = 0, int pageSize = int.MaxValue)
        {
            var query = this.logRepository.Table
                .Include(c => c.User)
                .AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.FullMessage.Contains(keyword) || c.ShortMessage.Contains(keyword));
            }

            query = query.OrderByDescending(c => c.CreationDate);

            return await new PagedList<Log>().Async(query, page, pageSize);
        }
    }
}