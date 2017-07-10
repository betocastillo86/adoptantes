//-----------------------------------------------------------------------
// <copyright file="Report.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Report Entity
    /// </summary>
    /// <seealso cref="Adopters.Data.Entities.BaseEntity" />
    public partial class Report : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Report"/> class.
        /// </summary>
        public Report()
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the file identifier.
        /// </summary>
        /// <value>
        /// The file identifier.
        /// </value>
        public int? FileId { get; set; }

        /// <summary>
        /// Gets or sets the facebook profile.
        /// </summary>
        /// <value>
        /// The facebook profile.
        /// </value>
        public string FacebookProfile { get; set; }

        /// <summary>
        /// Gets or sets the twitter profile.
        /// </summary>
        /// <value>
        /// The twitter profile.
        /// </value>
        public string TwitterProfile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Report"/> is positive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if positive; otherwise, <c>false</c>.
        /// </value>
        public bool Positive { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int? LocationId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the count likes.
        /// </summary>
        /// <value>
        /// The count likes.
        /// </value>
        public int CountLikes { get; set; }

        /// <summary>
        /// Gets or sets the count dislikes.
        /// </summary>
        /// <value>
        /// The count dislikes.
        /// </value>
        public int CountDislikes { get; set; }

        /// <summary>
        /// Gets or sets the count comments.
        /// </summary>
        /// <value>
        /// The count comments.
        /// </value>
        public int CountComments { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Report"/> is deleted.
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
        /// Gets or sets the file.
        /// </summary>
        /// <value>
        /// The file.
        /// </value>
        public virtual File File { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual User User { get; set; }
    }
}