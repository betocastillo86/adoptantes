//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// User Entity
    /// </summary>
    /// <seealso cref="Adopters.Data.Entities.BaseEntity" />
    public partial class User : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the facebook identifier.
        /// </summary>
        /// <value>
        /// The facebook identifier.
        /// </value>
        public int FacebookId { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int? LocationId { get; set; }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>
        /// The ip address.
        /// </value>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public short RoleId { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="User"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public virtual ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the report likes.
        /// </summary>
        /// <value>
        /// The report likes.
        /// </value>
        public virtual ICollection<ReportLike> ReportLikes { get; set; }

        /// <summary>
        /// Gets or sets the reports.
        /// </summary>
        /// <value>
        /// The reports.
        /// </value>
        public virtual ICollection<Report> Reports { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public virtual Location Location { get; set; }
    }
}