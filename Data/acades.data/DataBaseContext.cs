using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using acades.entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace acades.data
{
    //public class DataBaseContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>

    public class DataBaseContext: DbContext
    {
        public int? UserId { get; } = null;

        public DataBaseContext()
        { }

        public DataBaseContext([NotNullAttribute] DbContextOptions options)
            : base(options)
        { }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var now = DateTime.UtcNow;

            builder.Entity<Person>(p =>
            {
                p.ToTable("Person");
                p.HasKey(e => e.Id);
                p.Property(e => e.Document).HasMaxLength(20).IsRequired(true);
                p.Property(e => e.Name).HasMaxLength(100).IsRequired(true);
                p.Property(e => e.IsDeleted).HasDefaultValue(true);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);
            });

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
        }

    }
}
