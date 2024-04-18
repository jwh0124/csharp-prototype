using EntityFramework.Exceptions.PostgreSQL;
using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace iSecureGateway_Suprema.Contexts
{
    public class SupremaContext : DbContext
    {
        public SupremaContext(DbContextOptions<SupremaContext> options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity entity)
                {
                    var now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = now;
                        entity.ModifiedAt = now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entity.ModifiedAt = now;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseExceptionProcessor();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessGroup>()
                .HasMany(e => e.AccessLevels)
                .WithMany(e => e.AccessGroups)
                .UsingEntity<AccessGroupAccessLevel>(
                    l => l.HasOne<AccessLevel>().WithMany(e => e.AccessGroupAccessLevels),
                    r => r.HasOne<AccessGroup>().WithMany(e => e.AccessGroupAccessLevels));

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Authors)
                .WithMany(e => e.Posts)
                .UsingEntity<PostAuthor>(
                    l => l.HasOne<Author>().WithMany(e => e.PostAuthors),
                    r => r.HasOne<Post>().WithMany(e => e.PostAuthors));
        }

        public DbSet<AccessGroup> AccessGroups { get; set; }

        public DbSet<AccessLevel> AccessLevels { get; set; }

        public DbSet<AccessSchedule> AccessSchedules { get; set; }

        public DbSet<AccessGroupAccessLevel> AccessGroupAccessLevels { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<PostAuthor> PostAuthors { get; set; }
    }
}
