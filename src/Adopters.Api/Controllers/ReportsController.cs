//-----------------------------------------------------------------------
// <copyright file="ReportsController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using Adopters.Api.Models;
    using Adopters.Data.Entities;
    using Beto.Core.Data;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Adopters API Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/reports")]
    public class ReportsController : BaseApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        public ReportsController(IMessageExceptionFinder messageExceptionFinder) : base(messageExceptionFinder)
        {
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>the action</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] ReportFilterModel filter)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(new { Response = "Completed" });
            }
            else
            {
                return this.BadRequest(this.ModelState);
            }
        }
    }
}