using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataEntities.Entities;

public partial class ProductManagementDbContext : DbContext
{
    public ProductManagementDbContext()
    {
    }

    public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-CKS69BE;database=ProductManagementDB;Trusted_Connection=true;Trust Server Certificate=true ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__6DB38D6E596BEC6A");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Category_Name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Product__A3420A57BD534B56");

            entity.ToTable("Product");

            entity.Property(e => e.PId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("P_Id");
            entity.Property(e => e.About)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Product_Name");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
