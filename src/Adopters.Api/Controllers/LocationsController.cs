//-----------------------------------------------------------------------
// <copyright file="LocationsController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using Adopters.Api.Models;
    using Adopters.Business.Services;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Locations Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/locations")]
    public class LocationsController : BaseApiController
    {
        /// <summary>
        /// The location service
        /// </summary>
        private readonly ILocationService locationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationsController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="locationService">The location service.</param>
        public LocationsController(
            IMessageExceptionFinder messageExceptionFinder,
            ILocationService locationService) : base(messageExceptionFinder)
        {
            this.locationService = locationService;
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>the contents</returns>
        [HttpGet]
        public IActionResult Get([FromQuery]LocationFilterModel filter)
        {
            var locations = this.locationService.GetAll(
                    filter.Name,
                    filter.ParentId,
                    filter.Page,
                    filter.PageSize);

            var models = locations.ToModels();

            return this.Ok(models, locations.HasNextPage, locations.TotalCount);
        }
    }
}