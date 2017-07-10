//-----------------------------------------------------------------------
// <copyright file="CommentMap.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Comment Map
    /// </summary>
    internal static class CommentMap
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<Comment> entity)
        {
            entity.ToTable("Comments");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.IpAddress)
                .HasColumnType("varchar(20)");

            entity.Property(c => c.Value)
                .HasColumnType("nvarchar(1500)")
                .IsRequired();

            entity.HasOne(c => c.Report)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ReportId)
                .HasConstraintName("FK_Comment_Content")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .HasConstraintName("FK_Comment_User")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.ParentComment)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentCommentId)
                .IsRequired(false)
                .HasConstraintName("FK_Comment_ParentComment")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}