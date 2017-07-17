//-----------------------------------------------------------------------
// <copyright file="CommentModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using FluentValidation;

    /// <summary>
    /// Comment Model Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Adopters.Api.Models.Comments.CommentModel}" />
    public class CommentModelValidator : AbstractValidator<CommentModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentModelValidator"/> class.
        /// </summary>
        public CommentModelValidator()
        {
            this.RuleFor(c => c.Value)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(400);

            this.When(
                c => c.Id == 0 && !c.ParentCommentId.HasValue && !c.ReportId.HasValue,
                () =>
                {
                    this.RuleFor(c => c.ReportId)
                        .NotNull()
                        .WithMessage("Campo opcional no ingresado. Debe tener ReportId o ParentCommentId");

                    this.RuleFor(c => c.ParentCommentId)
                        .NotNull()
                        .WithMessage("Campo opcional no ingresado. Debe tener ReportId o ParentCommentId");
                });
        }
    }
}