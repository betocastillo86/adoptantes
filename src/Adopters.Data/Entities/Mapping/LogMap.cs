﻿//-----------------------------------------------------------------------
// <copyright file="LogMap.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Log Mapping
    /// </summary>
    internal static class LogMap
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<Log> entity)
        {
            entity.ToTable("Logs");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.ShortMessage)
                .HasColumnName("ShortMessage")
                .IsRequired();

            entity.Property(c => c.IpAddress)
                .HasMaxLength(100);

            entity.Property(c => c.PageUrl)
                .HasMaxLength(500);

            entity.Property(c => c.FullMessage)
                .HasColumnName("FullMessage");

            entity.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade)
                .HasConstraintName("FK_Log_User");
        }
    }
}