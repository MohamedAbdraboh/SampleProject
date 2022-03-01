namespace Sample.App.DAL
{
    using Sample.App.Domain.Models.V1;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // One-to-One Relationships
            builder.Entity<User>()
                .HasOne<UserContactCard>(s => s.UserContact)
                .WithOne(ucc => ucc.User)
                .HasForeignKey<UserContactCard>(ucc => ucc.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // One-to-Many Relationships
            builder.Entity<SubStatus>()
                .HasOne<Status>(ss => ss.Status)
                .WithMany(s => s.SubStatuses)
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasOne<Status>(u => u.Status)
                .WithMany(s => s.Users)
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>()
                .HasOne<SubStatus>(u => u.SubStatus)
                .WithMany(ss => ss.Users)
                .HasForeignKey(s => s.SubStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>().HasOne<ProjectType>(u => u.ProjectType)
                .WithMany(u => u.Projects).HasForeignKey(l => l.ProjectTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Project>().HasOne<User>(u => u.CreatedBy)
                .WithMany(u => u.CreatedByProjects).HasForeignKey(l => l.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Project>().HasOne<User>(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedByProjects).HasForeignKey(cs => cs.ModifiedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Project>().HasOne<Status>(cs => cs.Status)
                .WithMany(s => s.Projects).HasForeignKey(cs => cs.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Project>().HasOne<SubStatus>(cs => cs.SubStatus)
                .WithMany(ss => ss.Projects).HasForeignKey(cs => cs.SubStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProjectType>().HasOne<User>(u => u.CreatedBy)
                .WithMany(u => u.CreatedByProjectTypes).HasForeignKey(l => l.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProjectType>().HasOne<User>(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedByProjectTypes).HasForeignKey(cs => cs.ModifiedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProjectType>().HasOne<Status>(cs => cs.Status)
                .WithMany(s => s.ProjectTypes).HasForeignKey(cs => cs.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ProjectType>().HasOne<SubStatus>(cs => cs.SubStatus)
                .WithMany(ss => ss.ProjectTypes).HasForeignKey(cs => cs.SubStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Tag>().HasOne<User>(u => u.CreatedBy)
                .WithMany(u => u.CreatedByTags).HasForeignKey(l => l.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Tag>().HasOne<User>(u => u.ModifiedBy)
                .WithMany(u => u.ModifiedByTags).HasForeignKey(cs => cs.ModifiedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Tag>().HasOne<Status>(cs => cs.Status)
                .WithMany(s => s.Tags).HasForeignKey(cs => cs.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Tag>().HasOne<SubStatus>(cs => cs.SubStatus)
                .WithMany(ss => ss.Tags).HasForeignKey(cs => cs.SubStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-Many Relationships
            builder.Entity<ProjectTag>()
                .HasKey(pcs => new { pcs.ProjectId, pcs.TagId });
        }


        #region DBSets
        public DbSet<User> Users { get; set; }
        public DbSet<UserContactCard> ContactCards { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<SubStatus> SubStatuses { get; set; }

        // Many-to-Many DBSets
        public DbSet<ProjectTag> ProjectTags { get; set; }
        #endregion
    }
}