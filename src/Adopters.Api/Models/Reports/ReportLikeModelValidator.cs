//-----------------------------------------------------------------------
// <copyright file="ReportLikeModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models.Reports
{
    using FluentValidation;

    /// <summary>
    /// Report Like Model Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Adopters.Api.Models.ReportLikeModel}" />
    public class ReportLikeModelValidator : AbstractValidator<ReportLikeModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportLikeModelValidator"/> class.
        /// </summary>
        public ReportLikeModelValidator()
        {
            this.RuleFor(c => c)
                .NotNull();

            this.RuleFor(c => c.Positive)
                .NotNull();
        }
    }
}