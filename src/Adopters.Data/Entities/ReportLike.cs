//-----------------------------------------------------------------------
// <copyright file="ReportLike.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    using System;

    /// <summary>
    /// Report Like Entity
    /// </summary>
    /// <seealso cref="Adopters.Data.Entities.BaseEntity" />
    public partial class ReportLike : BaseEntity
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        public int ReportId { get; set; }

        /// <summary>
        /// Gets or sets the positive.
        /// </summary>
        /// <value>
        /// The positive.
        /// </value>
        public int Positive { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the report.
        /// </summary>
        /// <value>
        /// The report.
        /// </value>
        public virtual Report Report { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual User User { get; set; }
    }
}