//-----------------------------------------------------------------------
// <copyright file="ReportFilterModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using System;
    using Adopters.Data.Entities;
    using Beto.Core.Web.Api;

    /// <summary>
    /// Report Filter Model
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.BaseFilterModel" />
    public class ReportFilterModel : BaseFilterModel
    {
        public ReportFilterModel()
        {
            this.MaxPageSize = 40;
            this.ValidOrdersBy = Enum.GetNames(typeof(ReportOrderBy));
        }

        /// <summary>
        /// Gets or sets the filter by keyword. Searches in name, email and description.
        /// </summary>
        /// <value>
        /// The keyword.
        /// </value>
        public string Keyword { get; set; }

        /// <summary>
        /// Gets or sets the name. Searches by name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email. Searches by email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the is positive. Searches by positive or negative rating.
        /// </summary>
        /// <value>
        /// The is positive.
        /// </value>
        public bool? IsPositive { get; set; }

        /// <summary>
        /// Gets or sets the location identifier. Searches by location.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int? LocationId { get; set; }
    }
}