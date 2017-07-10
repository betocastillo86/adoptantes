//-----------------------------------------------------------------------
// <copyright file="AdoptersController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Controllers
{
    using Adopters.Api.Models;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Beto.Core.Web.Api.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Adopters API Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/reports")]
    public class ReportsController : BaseApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdoptersController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        public ReportsController(IMessageExceptionFinder messageExceptionFinder) : base(messageExceptionFinder)
        {

        }

        [HttpGet]
        public IActionResult Get([FromQuery] ReportFilterModel filter)
        {
            if (this.ModelState.IsValid)
            {
                //var validator = new BaseFilterModelValidator();
                //var x = validator.Validate(filter);
                return this.Ok(new { Response = "Completed" });
            }
            else
            {
                return this.BadRequest(this.ModelState);
            }
        }
    }
}