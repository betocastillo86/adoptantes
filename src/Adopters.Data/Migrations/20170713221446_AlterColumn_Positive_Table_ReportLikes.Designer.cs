﻿// <auto-generated/>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Adopters.Data.Core;

namespace Adopters.Data.Migrations
{
    [DbContext(typeof(AdoptersContext))]
    [Migration("20170713221446_AlterColumn_Positive_Table_ReportLikes")]
    partial class AlterColumn_Positive_Table_ReportLikes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Adopters.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountSubcomments");

                    b.Property<DateTime>("CreationDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("IpAddress")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("ParentCommentId");

                    b.Property<int?>("ReportId");

                    b.Property<int>("UserId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(1500)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCommentId");

                    b.HasIndex("ReportId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Adopters.Data.Entities.EmailNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<string>("Cc")
                        .HasColumnName("CC")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ScheduledDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("SentDate")
                        .HasColumnType("datetime");

                    b.Property<short>("SentTries");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ToName")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("EmailNotifications");
                });

            modelBuilder.Entity("Adopters.Data.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Adopters.Data.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ParentLocationId");

                    b.HasKey("Id");

                    b.HasIndex("ParentLocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Adopters.Data.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("FullMessage")
                        .HasColumnName("FullMessage");

                    b.Property<string>("IpAddress")
                        .HasMaxLength(100);

                    b.Property<short>("LogLevelId");

                    b.Property<string>("PageUrl")
                        .HasMaxLength(500);

                    b.Property<string>("ShortMessage")
                        .IsRequired()
                        .HasColumnName("ShortMessage");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Adopters.Data.Entities.Notification", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Active");

                    b.Property<bool>("Deleted");

                    b.Property<string>("EmailHtml");

                    b.Property<string>("EmailSubject")
                        .HasMaxLength(500);

                    b.Property<bool>("IsEmail");

                    b.Property<bool>("IsSystem");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("SystemText")
                        .HasMaxLength(2000);

                    b.Property<string>("Tags")
                        .HasMaxLength(3000);

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Adopters.Data.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountComments");

                    b.Property<int>("CountDislikes");

                    b.Property<int>("CountLikes");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FacebookProfile")
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("FileId");

                    b.Property<string>("FriendlyName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("Positive");

                    b.Property<string>("TwitterProfile")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("IX_Report_Email");

                    b.HasIndex("FileId");

                    b.HasIndex("FriendlyName")
                        .IsUnique()
                        .HasName("IX_Report_FriendlyName");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Adopters.Data.Entities.ReportLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("Positive");

                    b.Property<int>("ReportId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.HasIndex("UserId");

                    b.ToTable("ReportLikes");
                });

            modelBuilder.Entity("Adopters.Data.Entities.SystemSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_SystemSetting");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("Adopters.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FacebookId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<short>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("IX_Users");

                    b.HasIndex("LocationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Adopters.Data.Entities.Comment", b =>
                {
                    b.HasOne("Adopters.Data.Entities.Comment", "ParentComment")
                        .WithMany("Children")
                        .HasForeignKey("ParentCommentId")
                        .HasConstraintName("FK_Comment_ParentComment");

                    b.HasOne("Adopters.Data.Entities.Report", "Report")
                        .WithMany("Comments")
                        .HasForeignKey("ReportId")
                        .HasConstraintName("FK_Comment_Content");

                    b.HasOne("Adopters.Data.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Comment_User");
                });

            modelBuilder.Entity("Adopters.Data.Entities.Location", b =>
                {
                    b.HasOne("Adopters.Data.Entities.Location", "ParentLocation")
                        .WithMany("ChildrenLocations")
                        .HasForeignKey("ParentLocationId")
                        .HasConstraintName("FK_Location_Location_ParentLocationId");
                });

            modelBuilder.Entity("Adopters.Data.Entities.Log", b =>
                {
                    b.HasOne("Adopters.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Log_User")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Adopters.Data.Entities.Report", b =>
                {
                    b.HasOne("Adopters.Data.Entities.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .HasConstraintName("FK_Reports_Files");

                    b.HasOne("Adopters.Data.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_Reports_Locations");

                    b.HasOne("Adopters.Data.Entities.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Reports_Users");
                });

            modelBuilder.Entity("Adopters.Data.Entities.ReportLike", b =>
                {
                    b.HasOne("Adopters.Data.Entities.Report", "Report")
                        .WithMany("ReportLikes")
                        .HasForeignKey("ReportId")
                        .HasConstraintName("FK_ReportLikes_Reports");

                    b.HasOne("Adopters.Data.Entities.User", "User")
                        .WithMany("ReportLikes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ReportLikes_Users");
                });

            modelBuilder.Entity("Adopters.Data.Entities.User", b =>
                {
                    b.HasOne("Adopters.Data.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_Users_Locations");
                });
        }
    }
}