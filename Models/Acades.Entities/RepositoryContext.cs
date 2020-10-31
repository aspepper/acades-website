using Acades.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acades.Entities
{

    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Person> Persons { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<PersonRole> PersonRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var now = DateTime.UtcNow;

            builder.Entity<Person>(p =>
            {
                p.ToTable("Person");
                p.HasKey(e => e.Id);
                p.HasMany(e => e.Users).WithOne(u => u.Person);
                p.HasMany(e => e.Roles).WithOne(u => u.Person);

                p.Property(e => e.Document).HasMaxLength(20).IsRequired(true);
                p.Property(e => e.Name).HasMaxLength(100).IsRequired(true);
                p.Property(e => e.IsDeleted).HasDefaultValue(true);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);
            });

            builder.Entity<User>(p =>
            {
                p.ToTable("User");
                p.HasKey(e => e.Id);
                p.HasOne(e => e.Person)
                .WithMany(p => p.Users)
                .HasForeignKey(s => s.PersonId);

                p.Property(e => e.IsDeleted).HasDefaultValue(true);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);
            });

            builder.Entity<Role>(p =>
            {
                p.ToTable("Role");
                p.HasKey(e => e.Id);
                p.Property(e => e.IsDeleted).HasDefaultValue(true);

                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);
            });

            builder.Entity<PersonRole>(p =>
            {
                p.ToTable("PersonRole");
                p.HasKey(e => e.Id);
                p.HasOne(e => e.Person)
                .WithMany(p => p.Roles)
                .HasForeignKey(s => s.PersonId);
                p.HasOne(e => e.Role)
                .WithMany(p => p.Persons)
                .HasForeignKey(s => s.RoleId);

                p.Property(e => e.IsDeleted).HasDefaultValue(true);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);
            });

        }

    }

}
