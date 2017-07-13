//-----------------------------------------------------------------------
// <copyright file="ReportModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using FluentValidation;

    /// <summary>
    /// Base report model rules of validation
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Adopters.Api.Models.ReportModel}" />
    public class ReportModelValidator : AbstractValidator<ReportModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportModelValidator"/> class.
        /// </summary>
        public ReportModelValidator()
        {
            this.RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(150)
                .MinimumLength(10);

            this.RuleFor(c => c.Email)
                .EmailAddress();

            this.RuleFor(c => c.Description)
                .NotEmpty()
                .MinimumLength(100)
                .MaximumLength(1500);

            this.RuleFor(c => c.FacebookProfile)
                .Matches(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)");

            this.RuleFor(c => c.TwitterProfile)
                .Matches(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)");
        }
    }
}