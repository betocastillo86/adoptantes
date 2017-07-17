//-----------------------------------------------------------------------
// <copyright file="ICommentService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System.Threading.Tasks;
    using Adopters.Data.Entities;
    using Beto.Core.Data;

    /// <summary>
    /// Interface of comment service
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Deletes the specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>the task</returns>
        Task Delete(Comment comment);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="getUser">if set to <c>true</c> [get user].</param>
        /// <param name="getParent">if set to <c>true</c> [get parent].</param>
        /// <param name="getReport">if set to <c>true</c> [get report].</param>
        /// <returns>the comment</returns>
        Task<Comment> GetById(int id, bool getUser = true, bool getParent = true, bool getReport = false);

        /// <summary>
        /// Inserts the specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>the task</returns>
        Task Insert(Comment comment);

        /// <summary>
        /// Searches the specified key.
        /// </summary>
        /// <param name="keyword">The key.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="parentCommentId">The parent comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="reportId">The report identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the comments</returns>
        Task<IPagedList<Comment>> Search(
            string keyword = null,
            CommentOrderBy orderBy = CommentOrderBy.Recent,
            int? parentCommentId = default(int?),
            int? userId = null,
            int? reportId = null,
            int page = 0,
            int pageSize = int.MaxValue);

        /// <summary>
        /// Updates the specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>the task</returns>
        Task Update(Comment comment);
    }
}