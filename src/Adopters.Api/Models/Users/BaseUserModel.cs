//-----------------------------------------------------------------------
// <copyright file="BaseUserModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    /// <summary>
    /// Base User Model
    /// </summary>
    /// <seealso cref="Adopters.Api.Models.BaseModel" />
    public class BaseUserModel : BaseModel
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
        /// Gets or sets the facebook identifier.
        /// </summary>
        /// <value>
        /// The facebook identifier.
        /// </value>
        public string FacebookId { get; set; }
    }
}