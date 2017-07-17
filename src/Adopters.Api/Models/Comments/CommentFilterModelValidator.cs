//-----------------------------------------------------------------------
// <copyright file="CommentFilterModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using Beto.Core.Web.Api.Models;
    using FluentValidation;

    /// <summary>
    /// Comment Filter Model Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Adopters.Api.Models.CommentFilterModel}" />
    public class CommentFilterModelValidator : AbstractValidator<CommentFilterModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentFilterModelValidator"/> class.
        /// </summary>
        public CommentFilterModelValidator()
        {
            this.AddBaseFilterValidations();

            this.RuleFor(c => c.Keyword)
                .MinimumLength(5)
                .MaximumLength(80);
        }
    }
}