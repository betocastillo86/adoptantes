//-----------------------------------------------------------------------
// <copyright file="AdoptersContext.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Core
{
    using Adopters.Data.Entities;
    using Adopters.Data.Entities.Mapping;
    using Beto.Core.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Adopters Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="Beto.Core.Data.IDbContext" />
    public partial class AdoptersContext : DbContext, IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdoptersContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public AdoptersContext(DbContextOptions<AdoptersContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public virtual DbSet<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the email notifications.
        /// </summary>
        /// <value>
        /// The email notifications.
        /// </value>
        public virtual DbSet<EmailNotification> EmailNotifications { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public virtual DbSet<File> Files { get; set; }

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>
        /// The locations.
        /// </value>
        public virtual DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the logs.
        /// </summary>
        /// <value>
        /// The logs.
        /// </value>
        public virtual DbSet<Log> Logs { get; set; }

        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        public virtual DbSet<Notification> Notifications { get; set; }

        /// <summary>
        /// Gets or sets the report likes.
        /// </summary>
        /// <value>
        /// The report likes.
        /// </value>
        public virtual DbSet<ReportLike> ReportLikes { get; set; }

        /// <summary>
        /// Gets or sets the reports.
        /// </summary>
        /// <value>
        /// The reports.
        /// </value>
        public virtual DbSet<Report> Reports { get; set; }

        /// <summary>
        /// Gets or sets the system settings.
        /// </summary>
        /// <value>
        /// The system settings.
        /// </value>
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().Map();
            modelBuilder.Entity<EmailNotification>().Map();
            modelBuilder.Entity<File>().Map();
            modelBuilder.Entity<Location>().Map();
            modelBuilder.Entity<Log>().Map();
            modelBuilder.Entity<Notification>().Map();
            modelBuilder.Entity<ReportLike>().Map();
            modelBuilder.Entity<Report>().Map();
            modelBuilder.Entity<SystemSetting>().Map();
            modelBuilder.Entity<User>().Map();
        }
    }
}