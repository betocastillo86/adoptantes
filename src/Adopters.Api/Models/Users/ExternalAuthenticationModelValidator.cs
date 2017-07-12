//-----------------------------------------------------------------------
// <copyright file="ExternalAuthenticationModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using FluentValidation;

    /// <summary>
    /// External Authentication Model Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Adopters.Api.Models.ExternalAuthenticationModel}" />
    public class ExternalAuthenticationModelValidator : AbstractValidator<ExternalAuthenticationModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalAuthenticationModelValidator"/> class.
        /// </summary>
        public ExternalAuthenticationModelValidator()
        {
            this.RuleFor(c => c.SocialNetwork)
                .NotNull();

            this.RuleFor(c => c.Token)
                .NotEmpty();
        }
    }
}