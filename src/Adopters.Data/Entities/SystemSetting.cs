//-----------------------------------------------------------------------
// <copyright file="SystemSetting.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    /// <summary>
    /// System Setting Entity
    /// </summary>
    /// <seealso cref="Adopters.Data.Entities.BaseEntity" />
    public partial class SystemSetting : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
    }
}