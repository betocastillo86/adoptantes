//-----------------------------------------------------------------------
// <copyright file="NotificationMap.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Notification Mapping
    /// </summary>
    internal static class NotificationMap
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<Notification> entity)
        {
            entity.ToTable("Notifications");

            entity.HasKey(c => c.Id);

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(300);

            entity.Property(t => t.SystemText)
                .HasMaxLength(2000);

            entity.Property(t => t.EmailSubject)
                .HasMaxLength(500);

            entity.Property(t => t.Tags)
                .HasMaxLength(3000);
        }
    }
}