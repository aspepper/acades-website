using Acades.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acades.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
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
    }
}
