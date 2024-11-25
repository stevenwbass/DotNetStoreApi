using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StoreData.Models;

public partial class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<Productstatus> Productstatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.HasIndex(e => e.Name, "category_unique_name").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("image");

            entity.Property(e => e.Id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.Base64Bytes).HasColumnType("mediumtext");
            entity.Property(e => e.Url).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.ProductStatusId, "Product_productstatus_FK");

            entity.HasIndex(e => e.Name, "Product_unique_name").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.ProductStatusId).HasColumnType("int(10) unsigned");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedOn)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.ProductStatus).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductStatusId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Product_productstatus_FK");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product_category");

            entity.HasIndex(e => e.CategoryId, "product_category_category_FK");

            entity.HasIndex(e => e.ProductId, "product_category_product_FK");

            entity.Property(e => e.CategoryId).HasColumnType("int(10) unsigned");
            entity.Property(e => e.ProductId).HasColumnType("int(10) unsigned");

            entity.HasOne(d => d.Category).WithMany()
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("product_category_category_FK");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("product_category_product_FK");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product_image");

            entity.HasIndex(e => e.ImageId, "NewTable_image_FK");

            entity.HasIndex(e => e.ProductId, "NewTable_product_FK");

            entity.Property(e => e.ImageId).HasColumnType("int(10) unsigned");
            entity.Property(e => e.ProductId).HasColumnType("int(10) unsigned");

            entity.HasOne(d => d.Image).WithMany()
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("NewTable_image_FK");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("NewTable_product_FK");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product_variant");

            entity.HasIndex(e => e.ProductStatusId, "Product_productstatus_FK");

            entity.Property(e => e.Id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ParentProductId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("parent_product_id");
            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.ProductStatusId).HasColumnType("int(10) unsigned");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedOn)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.ProductStatus).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductStatusId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Product_variant_productstatus_FK");
        });

        modelBuilder.Entity<Productstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productstatus");

            entity.HasIndex(e => e.Name, "ProductStatus_unique_name").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(10) unsigned");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
