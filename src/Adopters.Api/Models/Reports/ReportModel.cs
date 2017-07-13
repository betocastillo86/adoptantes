//-----------------------------------------------------------------------
// <copyright file="ReportModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using System;

    /// <summary>
    /// Base Report Model
    /// </summary>
    /// <seealso cref="Adopters.Api.Models.BaseModel" />
    public class ReportModel : BaseModel
    {
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
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>
        /// The name of the friendly.
        /// </value>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the file identifier.
        /// </summary>
        /// <value>
        /// The file identifier.
        /// </value>
        public FileModel Image { get; set; }

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
        public LocationModel Location { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public BaseUserModel User { get; set; }

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
    }
}