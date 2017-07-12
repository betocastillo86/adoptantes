//-----------------------------------------------------------------------
// <copyright file="LocationExtensions.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Adopters.Data.Entities;

    /// <summary>
    /// Location Extensions
    /// </summary>
    public static class LocationExtensions
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the model</returns>
        public static LocationModel ToModel(this Location entity)
        {
            return new LocationModel { Id = entity.Id, Name = entity.Name };
        }

        /// <summary>
        /// To the models.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>the list</returns>
        public static IList<LocationModel> ToModels(this IEnumerable<Location> entities)
        {
            return entities.Select(LocationExtensions.ToModel).ToList();
        }
    }
}