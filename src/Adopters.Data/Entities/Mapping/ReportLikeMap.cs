//-----------------------------------------------------------------------
// <copyright file="ReportLikeMap.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Report Like Mapping
    /// </summary>
    internal static class ReportLikeMap
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<ReportLike> entity)
        {
            entity.ToTable("ReportLikes");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Report)
                .WithMany(p => p.ReportLikes)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ReportLikes_Reports");

            entity.HasOne(d => d.User)
                .WithMany(p => p.ReportLikes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ReportLikes_Users");
        }
    }
}