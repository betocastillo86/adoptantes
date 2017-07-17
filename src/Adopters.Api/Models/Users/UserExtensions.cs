//-----------------------------------------------------------------------
// <copyright file="UserExtensions.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Adopters.Data.Entities;

    /// <summary>
    /// User Extensions
    /// </summary>
    public static class UserExtensions
    {
        /// <summary>
        /// To the base user model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the model</returns>
        public static BaseUserModel ToBaseModel(this User entity)
        {
            return new BaseUserModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                FacebookId = entity.FacebookId
            };
        }

        /// <summary>
        /// To the base user models.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>the list</returns>
        public static IList<BaseUserModel> ToBaseUserModels(this IEnumerable<User> entities)
        {
            return entities.Select(ToBaseModel).ToList();
        }
    }
}