using Acades.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Acades.Entities
{

    public class RepositoryContext : DbContext
    {


        public RepositoryContext()
        { }

        public RepositoryContext(DbContextOptions<RepositoryContext>  options) : base(options)
        { }

        public DbSet<Person> Persons { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<PersonRole> PersonRoles { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<FileType> FileTypes { get; set; }

        public DbSet<PdfServiceRegister> PDFServiceRegisters { get; set; }

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
                p.Property(e => e.IsDeleted).HasDefaultValue(false);
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

                p.Property(e => e.UserName).HasMaxLength(30).IsRequired();
                p.Property(e => e.IsDeleted).HasDefaultValue(false);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);
            });

            builder.Entity<Role>(p =>
            {
                p.ToTable("Role");
                p.HasKey(e => e.Id);
                p.Property(e => e.Description).HasMaxLength(100).IsRequired();
                p.Property(e => e.NormalizedName).HasMaxLength(50).IsRequired();
                p.Property(e => e.IsAdm).HasDefaultValue(false); ;
                p.Property(e => e.Area).HasMaxLength(30).IsRequired();
                p.Property(e => e.IsVisible).HasDefaultValue(true);
                p.Property(e => e.IsDeleted).HasDefaultValue(false);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);

                p.HasIndex(e => e.NormalizedName).IsUnique();
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

                p.Property(e => e.IsDeleted).HasDefaultValue(false);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);
            });

            builder.Entity<File>(p =>
            {
                p.ToTable("File");
                p.HasKey(e => e.Id);
                p.HasOne(e => e.Person)
                .WithMany(p => p.Files)
                .HasForeignKey(s => s.PersonId);
                p.HasOne(e => e.FileType)
                .WithMany(p => p.Files)
                .HasForeignKey(s => s.FileTypeId);

                p.Property(e => e.IsDeleted).HasDefaultValue(false);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);
            });

            builder.Entity<FileType>(p =>
            {
                p.ToTable("FileType");
                p.HasKey(e => e.Id);

                p.Property(e => e.IsDeleted).HasDefaultValue(false);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);
            });

            builder.Entity<PdfServiceRegister>(p =>
            {
                p.ToTable("PdfServiceRegister");
                p.HasKey(e => e.Id);

                p.Property(e => e.UserId).IsRequired(false);

                p.Property(e => e.GeneratedDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.FileName).HasMaxLength(200).IsRequired(true);
                p.Property(e => e.FilePdfUrl).HasMaxLength(200).IsRequired(false);
                p.Property(e => e.OwnerName).HasMaxLength(50);
                p.Property(e => e.OwnerEmail).HasMaxLength(100);
                p.Property(e => e.OwnerDocument).HasMaxLength(20);
                p.Property(e => e.PrintCustomerData).HasDefaultValue(false);
                p.Property(e => e.IPSource).HasMaxLength(15);
                p.Property(e => e.Error).HasColumnType("nvarchar(MAX)");

                p.Property(e => e.IsDeleted).HasDefaultValue(false);
                p.Property(e => e.InsertDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.InsertUser).HasDefaultValue(1);
                p.Property(e => e.UpdateDate).HasDefaultValue(DateTime.Now);
                p.Property(e => e.UpdateUser).HasDefaultValue(1);

            });

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=acades.database.windows.net;Database=acades-prd;User=Administrador;Password=L0g1t3ch#2021;Integrated Security=false");
        }

    }

}
