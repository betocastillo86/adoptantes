//-----------------------------------------------------------------------
// <copyright file="CommentFilterModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using System;
    using Adopters.Data.Entities;
    using Beto.Core.Web.Api;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Comment Filter Model
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.BaseFilterModel" />
    public class CommentFilterModel : BaseFilterModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentFilterModel"/> class.
        /// </summary>
        public CommentFilterModel()
        {
            this.MaxPageSize = 30;
            this.ValidOrdersBy = Enum.GetNames(typeof(CommentOrderBy));
        }

        /// <summary>
        /// Gets or sets the keyword.
        /// </summary>
        /// <value>
        /// The keyword.
        /// </value>
        public string Keyword { get; set; }

        /// <summary>
        /// Gets or sets the order by enum.
        /// </summary>
        /// <value>
        /// The order by enum.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public CommentOrderBy OrderByEnum
        {
            get
            {
                return !string.IsNullOrEmpty(this.OrderBy) ? (CommentOrderBy)Enum.Parse(typeof(CommentOrderBy), this.OrderBy, true) : CommentOrderBy.Recent;
            }

            set
            {
                this.OrderBy = value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        public int? ReportId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [with children].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [with children]; otherwise, <c>false</c>.
        /// </value>
        public bool WithChildren { get; set; }
    }
}