//-----------------------------------------------------------------------
// <copyright file="CommentNotifications.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Subscribers.Notifications
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Adopters.Business.Security;
    using Adopters.Business.Services;
    using Adopters.Data.Entities;
    using Beto.Core.Data;
    using Beto.Core.Data.Notifications;
    using Beto.Core.EventPublisher;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Comment notifications
    /// </summary>
    /// <seealso cref="Huellitas.Business.EventPublisher.ISubscriber{Huellitas.Business.EventPublisher.EntityInsertedMessage{Huellitas.Data.Entities.Comment}}" />
    public class CommentNotifications : ISubscriber<EntityInsertedMessage<Comment>>
    {
        /// <summary>
        /// The comment repository
        /// </summary>
        private readonly IRepository<Comment> commentRepository;

        /// <summary>
        /// The comment service
        /// </summary>
        private readonly ICommentService commentService;

        /// <summary>
        /// The content service
        /// </summary>
        private readonly IReportService reportService;

        /// <summary>
        /// The notification service
        /// </summary>
        private readonly INotificationService notificationService;

        /// <summary>
        /// The SEO service
        /// </summary>
        private readonly ISeoService seoService;

        /// <summary>
        /// The work context
        /// </summary>
        private readonly IWorkContext workContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentNotifications"/> class.
        /// </summary>
        /// <param name="reportService">The report service.</param>
        /// <param name="commentService">The comment service.</param>
        /// <param name="seoService">The SEO service.</param>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="workContext">The work context.</param>
        /// <param name="commentRepository">The comment repository.</param>
        public CommentNotifications(
            IReportService reportService,
            ICommentService commentService,
            ISeoService seoService,
            INotificationService notificationService,
            IWorkContext workContext,
            IRepository<Comment> commentRepository)
        {
            this.reportService = reportService;
            this.commentService = commentService;
            this.seoService = seoService;
            this.notificationService = notificationService;
            this.workContext = workContext;
            this.commentRepository = commentRepository;
        }

        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task HandleEvent(EntityInsertedMessage<Comment> message)
        {
            if (message.Entity.ReportId.HasValue)
            {
                await this.NotifyCommentOnReport(message.Entity);
            }
            else
            {
                await this.NotifySubcomment(message.Entity);
            }
        }

        /// <summary>
        /// Notifies the content of the comment
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>the task</returns>
        private async Task NotifyCommentOnReport(Comment comment)
        {
            Report report = comment.Report;

            if (comment.Report == null || comment.Report.User == null)
            {
                report = await this.reportService.GetById(comment.ReportId.Value, includeUser: true);
            }

            var reportUrl = this.seoService.GetFullRoute("report", report.FriendlyName);

            var parameters = new List<NotificationParameter>();
            parameters.Add("Report.Name", report.Name);
            parameters.Add("Report.Url", reportUrl);

            await this.notificationService.NewNotification(
                report.User,
                this.workContext.CurrentUser,
                NotificationType.NewCommentOnReport,
                reportUrl,
                parameters);
        }

        /// <summary>
        /// Notifies the child comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns>the task</returns>
        private async Task NotifySubcomment(Comment comment)
        {
            var parentComment = await this.commentService.GetById(comment.ParentCommentId.Value, getReport: true, getUser: true);

            var reportUrl = this.seoService.GetFullRoute("report", parentComment.Report.FriendlyName);

            var parameters = new List<NotificationParameter>();
            parameters.Add("Report.Name", parentComment.Report.Name);
            parameters.Add("Report.Url", reportUrl);

            if (parentComment.UserId != this.workContext.CurrentUserId)
            {
                ////Notifica al dueño del comentario padre
                await this.notificationService.NewNotification(
                    parentComment.User,
                    this.workContext.CurrentUser,
                    NotificationType.NewSubcommentOnMyComment,
                    reportUrl,
                    parameters);
            }

            ////Notifica a los otros que comentaron
            var others = this.commentRepository.Table
                .Include(c => c.User)
                .Where(c => c.ParentCommentId == parentComment.Id && c.UserId != parentComment.UserId && c.UserId != this.workContext.CurrentUserId)
                .Select(c => c.User)
                .Distinct()
                .ToList();

            await this.notificationService.NewNotification(
                others,
                this.workContext.CurrentUser,
                NotificationType.NewSubcommentOnSomeoneElseComment,
                reportUrl,
                parameters);
        }
    }
}