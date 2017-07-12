//-----------------------------------------------------------------------
// <copyright file="ILogService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System.Threading.Tasks;
    using Adopters.Data.Entities;
    using Beto.Core.Data;

    /// <summary>
    /// Interface of log service
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Inserts the specified log level.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <param name="user">The user.</param>
        /// <returns>the value</returns>
        Task Insert(LogLevel logLevel, string shortMessage, string fullMessage = "", User user = null);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the list of logs</returns>
        Task<IPagedList<Log>> GetAll(string keyword, int page = 0, int pageSize = int.MaxValue);
    }
}