using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {

        public IWorkContext _workContext { get; set; }

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            IWorkContext workContext
             )
            : base(options)
        {
            _workContext = workContext;
        }

        // DbSet tanımlamaları
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Users yapılandırması
    modelBuilder.Entity<User>(entity =>
    {
        entity.HasKey(u => u.Id);
        entity.Property(u => u.FirstName)
              .HasMaxLength(100);
        entity.Property(u => u.LastName)
              .HasMaxLength(100);
        entity.Property(u => u.Username)
              .HasMaxLength(100)
              .IsRequired();
        entity.Property(u => u.Email)
              .HasMaxLength(150)
              .IsRequired();
        entity.Property(u => u.PasswordHash)
              .HasMaxLength(500)
              .IsRequired();
        entity.Property(u => u.IsDeleted)
              .HasDefaultValue(false);
    });

    // Employee yapılandırması
    modelBuilder.Entity<Employee>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name)
              .HasMaxLength(100)
              .IsRequired();
        entity.Property(e => e.LastName)
              .HasMaxLength(100)
              .IsRequired();
        entity.Property(e => e.Email)
              .HasMaxLength(150)
              .IsRequired();
        entity.Property(e => e.DepartmentId)
            .IsRequired();
        entity.Property(e => e.IsDeleted)
              .HasDefaultValue(false);
        entity.HasOne<Department>()  
              .WithMany()
              .HasForeignKey(e => e.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);
    });

    // Department yapılandırması
    modelBuilder.Entity<Department>(entity =>
    {
        entity.HasKey(d => d.Id);
        entity.Property(d => d.Name)
              .HasMaxLength(100)
              .IsRequired();
        entity.Property(d => d.IsDeleted)
              .HasDefaultValue(false);
    });

            // Global query filters
            // modelBuilder.ApplyQueryFilter<IMultiTenant>(t => t.TenantId == _workContext.TenantId);
            modelBuilder.ApplyQueryFilter<ISoftDeletable>(t => t.IsDeleted == false);
        }
    }
}
