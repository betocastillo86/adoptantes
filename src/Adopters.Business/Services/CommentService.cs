//-----------------------------------------------------------------------
// <copyright file="CommentService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Adopters.Business.Configuration;
    using Adopters.Business.Exceptions;
    using Adopters.Data.Entities;
    using Beto.Core.Data;
    using Beto.Core.EventPublisher;
    using Beto.Core.Helpers;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Comment Service
    /// </summary>
    /// <seealso cref="Adopters.Business.Services.ICommentService" />
    public class CommentService : ICommentService
    {
        /// <summary>
        /// The comment repository
        /// </summary>
        private readonly IRepository<Comment> commentRepository;

        /// <summary>
        /// The general settings
        /// </summary>
        private readonly IGeneralSettings generalSettings;

        /// <summary>
        /// The HTTP context helpers
        /// </summary>
        private readonly IHttpContextHelper httpContextHelper;

        /// <summary>
        /// The publisher
        /// </summary>
        private readonly IPublisher publisher;

        /// <summary>
        /// The report repository
        /// </summary>
        private readonly IRepository<Report> reportRepository;

        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IRepository<User> userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentService"/> class.
        /// </summary>
        /// <param name="commentRepository">The comment repository.</param>
        /// <param name="reportRepository">The report repository.</param>
        /// <param name="generalSettings">The general settings.</param>
        /// <param name="httpContextHelper">The HTTP context helpers.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="userRepository">The user repository.</param>
        public CommentService(
            IRepository<Comment> commentRepository,
            IRepository<Report> reportRepository,
            IGeneralSettings generalSettings,
            IHttpContextHelper httpContextHelper,
            IPublisher publisher,
            IRepository<User> userRepository)
        {
            this.commentRepository = commentRepository;
            this.reportRepository = reportRepository;
            this.generalSettings = generalSettings;
            this.httpContextHelper = httpContextHelper;
            this.publisher = publisher;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Deletes the specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task Delete(Comment comment)
        {
            comment.Deleted = true;
            comment.ModifiedDate = DateTime.Now;

            if (comment.ParentCommentId.HasValue)
            {
                comment.ParentComment.CountSubcomments = this.commentRepository.Table.Count(c => c.ParentCommentId == comment.ParentCommentId && !c.Deleted) - 1;
            }

            await this.commentRepository.UpdateAsync(comment);

            await this.UpdateReportComments(comment);

            await this.publisher.EntityDeleted(comment);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="getUser">if set to <c>true</c> [get user].</param>
        /// <param name="getParent">if set to <c>true</c> [get parent].</param>
        /// <param name="getReport">if set to <c>true</c> [get report].</param>
        /// <returns>
        /// the comment
        /// </returns>
        public async Task<Comment> GetById(int id, bool getUser = true, bool getParent = true, bool getReport = false)
        {
            var query = this.commentRepository.Table;

            if (getUser)
            {
                query = query.Include(c => c.User);
            }

            if (getReport)
            {
                query = query.Include(c => c.Report);
            }

            if (getParent)
            {
                query = query.Include(c => c.ParentComment);
            }

            return await query.FirstOrDefaultAsync(c => c.Id == id && !c.Deleted);
        }

        /// <summary>
        /// Inserts the specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task Insert(Comment comment)
        {
            comment.CreationDate = DateTime.Now;

            comment.IpAddress = this.httpContextHelper.GetCurrentIpAddress();

            if (comment.ParentCommentId.HasValue)
            {
                var parentComment = this.commentRepository.Table.FirstOrDefault(c => c.Id == comment.ParentCommentId);
                if (parentComment != null)
                {
                    parentComment.CountSubcomments = this.commentRepository.Table.Count(c => c.ParentCommentId == parentComment.Id) + 1;
                }
                else
                {
                    throw new AdoptersException("ParentComment", AdopterExceptionCode.InvalidForeignKey);
                }
            }

            try
            {
                ////Se guarda y se actualizan los comentarios padre
                await this.commentRepository.InsertAsync(comment);

                await this.UpdateReportComments(comment);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is System.Data.SqlClient.SqlException)
                {
                    var inner = (System.Data.SqlClient.SqlException)e.InnerException;

                    if (inner.Number == 547)
                    {
                        string target = string.Empty;

                        if (inner.Message.IndexOf("FK_Comment_User") != -1)
                        {
                            target = "User";
                        }
                        else if (inner.Message.IndexOf("FK_Comment_ParentComment") != -1)
                        {
                            target = "ParentComment";
                        }
                        else if (inner.Message.IndexOf("FK_Comment_Content") != -1)
                        {
                            target = "Report";
                        }
                        else
                        {
                            throw;
                        }

                        throw new AdoptersException(target, AdopterExceptionCode.InvalidForeignKey);
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ////Notifica el evento de inserción del comentario
            await this.publisher.EntityInserted(comment);
        }

        /// <summary>
        /// Searches the specified key.
        /// </summary>
        /// <param name="keyword">the keyword</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="parentCommentId">The parent comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="reportId">The report identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the comments
        /// </returns>
        public async Task<IPagedList<Comment>> Search(
            string keyword = null,
            CommentOrderBy orderBy = CommentOrderBy.Recent,
            int? parentCommentId = default(int?),
            int? userId = null,
            int? reportId = null,
            int page = 0,
            int pageSize = int.MaxValue)
        {
            var query = this.commentRepository.Table
                .Include(c => c.User)
                .Include(c => c.ParentComment)
                .Where(c => !c.Deleted);

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.Value.Contains(keyword));
            }

            ////filters by parent comment
            if (parentCommentId.HasValue)
            {
                query = query.Where(c => c.ParentCommentId == parentCommentId.Value);
            }

            if (userId.HasValue)
            {
                query = query.Where(c => c.UserId == userId.Value);
            }

            if (reportId.HasValue)
            {
                query = query.Where(c => c.ReportId == reportId.Value);
            }

            switch (orderBy)
            {
                case CommentOrderBy.Recent:
                default:
                    query = query.OrderByDescending(c => c.CreationDate);
                    break;

                case CommentOrderBy.MostCommented:
                    query = query.OrderByDescending(c => c.CountSubcomments);
                    break;
            }

            return await new PagedList<Comment>().Async(query, page, pageSize);
        }

        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>the task</returns>
        public async Task Update(Comment comment)
        {
            comment.ModifiedDate = DateTime.Now;

            try
            {
                await this.commentRepository.UpdateAsync(comment);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is System.Data.SqlClient.SqlException)
                {
                    var inner = (System.Data.SqlClient.SqlException)e.InnerException;

                    if (inner.Number == 547)
                    {
                        string target = string.Empty;

                        if (inner.Message.IndexOf("FK_Comment_User") != -1)
                        {
                            target = "User";
                        }
                        else if (inner.Message.IndexOf("FK_Comment_ParentComment") != -1)
                        {
                            target = "ParentComment";
                        }
                        else if (inner.Message.IndexOf("FK_Comment_Content") != -1)
                        {
                            target = "Content";
                        }
                        else
                        {
                            throw;
                        }

                        throw new AdoptersException(target, AdopterExceptionCode.InvalidForeignKey);
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            await this.publisher.EntityUpdated(comment);
        }

        /// <summary>
        /// Updates the report comments.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>the task</returns>
        private async Task UpdateReportComments(Comment comment)
        {
            if (comment.ReportId.HasValue)
            {
                var report = this.reportRepository.Table.FirstOrDefault(c => c.Id == comment.ReportId.Value);
                report.CountComments = this.commentRepository.Table.Count(c => c.ReportId == comment.ReportId.Value && !c.Deleted);
                await this.reportRepository.UpdateAsync(report);
            }
        }
    }
}