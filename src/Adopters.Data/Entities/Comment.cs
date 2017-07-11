//-----------------------------------------------------------------------
// <copyright file="Comment.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Comments entity
    /// </summary>
    public partial class Comment : BaseEntity
    {
        /// <summary>
        /// The children
        /// </summary>
        private ICollection<Comment> children;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        public int? ReportId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the parent comment identifier.
        /// </summary>
        /// <value>
        /// The parent comment identifier.
        /// </value>
        public int? ParentCommentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Comment"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the IP address.
        /// </summary>
        /// <value>
        /// The IP address.
        /// </value>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the count comments.
        /// </summary>
        /// <value>
        /// The count comments.
        /// </value>
        public int CountSubcomments { get; set; }

        /// <summary>
        /// Gets or sets the comments1.
        /// </summary>
        /// <value>
        /// The comments1.
        /// </value>
        public virtual ICollection<Comment> Children
        {
            get { return this.children ?? (this.children = new List<Comment>()); }
            protected set { this.children = value; }
        }

        /// <summary>
        /// Gets or sets the comment1.
        /// </summary>
        /// <value>
        /// The comment1.
        /// </value>
        public virtual Comment ParentComment { get; set; }

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