using Microsoft.EntityFrameworkCore;
using StellarPayRoll.Core.Models.Entities;
using StellarPayRoll.Data.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace StellarPayRoll.Data.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations<AppDBContext>();
            modelBuilder.ConfigureDeletableEntities();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            this.AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();

            this.AddAuditInfo();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private const string IsDeletedProperty = "IsDeleted";

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[IsDeletedProperty] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[IsDeletedProperty] = true;
                        break;
                }
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}
