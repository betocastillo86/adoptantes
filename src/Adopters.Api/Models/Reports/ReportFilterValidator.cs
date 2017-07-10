//-----------------------------------------------------------------------
// <copyright file="ReportFilterValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using Beto.Core.Web.Api.Models;
    using FluentValidation;

    /// <summary>
    /// Report Filter Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Adopters.Api.Models.ReportFilterModel}" />
    public class ReportFilterValidator : AbstractValidator<ReportFilterModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportFilterValidator"/> class.
        /// </summary>
        public ReportFilterValidator()
        {
            this.AddBaseFilterValidations();
        }
    }
}