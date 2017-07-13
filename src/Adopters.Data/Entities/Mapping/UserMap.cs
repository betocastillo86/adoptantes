//-----------------------------------------------------------------------
// <copyright file="UserMap.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// User Mapping
    /// </summary>
    internal static class UserMap
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users");

            entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasName("IX_Users");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            entity.Property(e => e.FacebookId)
                .IsRequired()
                .HasColumnType("varchar(50)");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnType("varchar(150)");

            entity.HasOne(d => d.Location)
                .WithMany()
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Users_Locations");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.IpAddress).HasColumnType("varchar(50)");
        }
    }
}