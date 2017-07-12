//-----------------------------------------------------------------------
// <copyright file="BaseReportModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using FluentValidation;

    /// <summary>
    /// Base report model rules of validation
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Adopters.Api.Models.BaseReportModel}" />
    public class BaseReportModelValidator : AbstractValidator<BaseReportModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReportModelValidator"/> class.
        /// </summary>
        public BaseReportModelValidator()
        {
            this.RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(150)
                .MinimumLength(10);

            this.RuleFor(c => c.Email)
                .Empty()
                .EmailAddress();

            this.RuleFor(c => c.Description)
                .NotEmpty()
                .MinimumLength(100)
                .MaximumLength(1500);

            this.RuleFor(c => c.FacebookProfile)
                .Empty()
                .Matches(@"#\b(([\w-]+://?|www[.])[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|/)))#iS");

            this.RuleFor(c => c.TwitterProfile)
                .Empty()
                .Matches(@"#\b(([\w-]+://?|www[.])[^\s()<>]+(?:\([\w\d]+\)|([^[:punct:]\s]|/)))#iS");
        }
    }
}