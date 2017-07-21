//-----------------------------------------------------------------------
// <copyright file="LocationFilterModelValidator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using Beto.Core.Web.Api.Models;
    using FluentValidation;

    /// <summary>
    /// Location Filter Model Validator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Adopters.Api.Models.LocationFilterModel}" />
    public class LocationFilterModelValidator : AbstractValidator<LocationFilterModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationFilterModelValidator"/> class.
        /// </summary>
        public LocationFilterModelValidator()
        {
            this.AddBaseFilterValidations();
        }
    }
}