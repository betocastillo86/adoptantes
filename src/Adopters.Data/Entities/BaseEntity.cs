//-----------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    using Beto.Core.Data;

    /// <summary>
    /// Base Entity Class
    /// </summary>
    /// <seealso cref="Beto.Core.Data.IEntity" />
    public class BaseEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}