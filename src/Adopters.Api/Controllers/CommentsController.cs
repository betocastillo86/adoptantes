//-----------------------------------------------------------------------
// <copyright file="CommentsController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using System.Threading.Tasks;
    using Adopters.Api.Models;
    using Adopters.Business.Exceptions;
    using Adopters.Business.Extensions;
    using Adopters.Business.Security;
    using Adopters.Business.Services;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Beto.Core.Web.Api.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Comments controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/comments")]
    public class CommentsController : BaseApiController
    {
        /// <summary>
        /// The comment service
        /// </summary>
        private readonly ICommentService commentService;

        /// <summary>
        /// The work context
        /// </summary>
        private readonly IWorkContext workContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="commentService">The comment service.</param>
        /// <param name="workContext">The work context.</param>
        public CommentsController(
            IMessageExceptionFinder messageExceptionFinder,
            ICommentService commentService,
            IWorkContext workContext) : base(messageExceptionFinder)
        {
            this.commentService = commentService;
            this.workContext = workContext;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the action</returns>
        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await this.commentService.GetById(id);
            if (comment != null)
            {
                if (!comment.CanUserDeleteComment(this.workContext.CurrentUser))
                {
                    return this.Forbid();
                }

                await this.commentService.Delete(comment);

                return this.Ok();
            }
            else
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>the filter</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CommentFilterModel filter)
        {
            var comments = await this.commentService.Search(
                    filter.Keyword,
                    filter.OrderByEnum,
                    filter.ParentId,
                    filter.UserId,
                    filter.ReportId,
                    filter.Page,
                    filter.PageSize);

            var models = comments.ToModels(
                this.workContext.CurrentUser,
                this.commentService,
                contentUrlFunction: Url.Content,
                loadFirstComments: filter.WithChildren);

            return this.Ok(models, comments.HasNextPage, comments.TotalCount);
        }

        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the action</returns>
        [HttpPost]
        [Authorize]
        [RequiredModel]
        public async Task<IActionResult> Post([FromBody]CommentModel model)
        {
            var comment = model.ToEntity();
            comment.UserId = this.workContext.CurrentUserId;

            try
            {
                await this.commentService.Insert(comment);
            }
            catch (AdoptersException e)
            {
                return this.BadRequest(e);
            }

            return this.Ok(new BaseModel() { Id = comment.Id });
        }
    }
}