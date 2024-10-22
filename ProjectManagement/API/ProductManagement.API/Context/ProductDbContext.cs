using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Models;

namespace ProductManagement.API.Context;

public partial class ProductDbContext : DbContext
{
    public ProductDbContext()
    {
    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }
    public ProductDetails ProductDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0BCB686165");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValue(new DateTime(2024, 10, 4, 12, 33, 6, 602, DateTimeKind.Local).AddTicks(3234));
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__5CD6CB2B");
        });
        modelBuilder.Entity<ProductDetails>().HasNoKey(); // No primary key, just a query model
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

