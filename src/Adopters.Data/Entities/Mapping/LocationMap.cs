//-----------------------------------------------------------------------
// <copyright file="LocationMap.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Location Mapping
    /// </summary>
    internal static class LocationMap
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<Location> entity)
        {
            entity.ToTable("Locations");

            entity.HasKey(c => c.Id);

            entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            entity.Property(e => e.ParentLocationId)
                .IsRequired(false);

            entity.HasOne(c => c.ParentLocation)
                .WithMany(c => c.ChildrenLocations)
                .HasForeignKey(c => c.ParentLocationId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict)
                .HasConstraintName("FK_Location_Location_ParentLocationId");
        }
    }
}