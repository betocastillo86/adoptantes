//-----------------------------------------------------------------------
// <copyright file="PostFileModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models.Files
{
    using System.Linq;
    using Adopters.Business.Configuration;
    using FluentValidation;

    /// <summary>
    /// Post File Model Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Adopters.Api.Models.PostFileModel}" />
    public class PostFileModelValidator : AbstractValidator<PostFileModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostFileModelValidator"/> class.
        /// </summary>
        /// <param name="securitySettings">The security settings.</param>
        public PostFileModelValidator(ISecuritySettings securitySettings)
        {
            this.RuleFor(c => c.Files)
                .NotNull();

            this.When(
                c => c.Files != null,
                () =>
            {
                this.RuleFor(c => c.Files.Count)
                .GreaterThan(0)
                .WithMessage("Se debe cargar un archivo");

                this.RuleFor(c => c.Files.Count)
                    .LessThan(2)
                    .WithMessage("Máximo se puede cargar un archivo");

                this.When(
                    x => x.Files.Count == 1,
                    () =>
                    {
                        this.RuleFor(y => y.Files.First().Length)
                            .LessThan(securitySettings.MaxRequestFileUploadMB * 1024 * 1024)
                            .WithMessage($"El archivo excede el tamaño máximo permitido de {securitySettings.MaxRequestFileUploadMB} Mb");
                    });
            });
        }
    }
}