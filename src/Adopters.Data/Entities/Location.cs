//-----------------------------------------------------------------------
// <copyright file="Location.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Location Entity
    /// </summary>
    /// <seealso cref="Adopters.Data.Entities.BaseEntity" />
    public partial class Location : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Location"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent location identifier.
        /// </summary>
        /// <value>
        /// The parent location identifier.
        /// </value>
        public int? ParentLocationId { get; set; }

        /// <summary>
        /// Gets or sets the parent location.
        /// </summary>
        /// <value>
        /// The parent location.
        /// </value>
        public virtual Location ParentLocation { get; set; }

        /// <summary>
        /// Gets or sets the children locations.
        /// </summary>
        /// <value>
        /// The children locations.
        /// </value>
        public virtual IList<Location> ChildrenLocations { get; set; }
    }
}