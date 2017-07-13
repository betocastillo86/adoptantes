//-----------------------------------------------------------------------
// <copyright file="ReportMap.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Report Mapping
    /// </summary>
    internal static class ReportMap
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<Report> entity)
        {
            entity.ToTable("Reports");

            entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasName("IX_Report_Email");

            entity.HasIndex(e => e.FriendlyName)
                    .IsUnique()
                    .HasName("IX_Report_FriendlyName");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.Description).IsRequired();

            entity.Property(e => e.FriendlyName)
                .IsRequired()
                .HasColumnType("varchar(250)");

            entity.Property(e => e.Email).HasColumnType("varchar(150)");

            entity.Property(e => e.FacebookProfile).HasColumnType("varchar(500)");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            entity.Property(e => e.TwitterProfile).HasColumnType("varchar(500)");

            entity.HasOne(d => d.File)
                .WithMany()
                .HasForeignKey(d => d.FileId)
                .HasConstraintName("FK_Reports_Files");

            entity.HasOne(d => d.Location)
                .WithMany()
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Reports_Locations");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Reports_Users");
        }
    }
}