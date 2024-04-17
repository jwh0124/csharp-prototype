using EntityFramework.Exceptions.PostgreSQL;
using iSecureGateway_Suprema.Commons.Base;
using iSecureGateway_Suprema.Models;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<AccessGroup> AccessGroups { get; set; }

        public DbSet<AccessLevel> AccessLevels { get; set; }

        public DbSet<AccessSchedule> AccessSchedules { get; set; }
    }
}
