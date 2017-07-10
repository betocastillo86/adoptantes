//-----------------------------------------------------------------------
// <copyright file="File.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// File Entity
    /// </summary>
    /// <seealso cref="Adopters.Data.Entities.BaseEntity" />
    public partial class File : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class.
        /// </summary>
        public File()
        {
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the reports.
        /// </summary>
        /// <value>
        /// The reports.
        /// </value>
        public virtual ICollection<Report> Reports { get; set; }
    }
}