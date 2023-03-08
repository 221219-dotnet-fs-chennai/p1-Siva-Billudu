using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Entities;

public partial class AssociatesDbContext : DbContext
{
    public AssociatesDbContext()
    {
    }

    public AssociatesDbContext(DbContextOptions<AssociatesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SivaTrDetail> SivaTrDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:associateserver.database.windows.net,1433;Initial Catalog=AssociatesDb;Persist Security Info=False;User ID=associate;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SivaTrDetail>(entity =>
        {
            entity.HasKey(e => e.TrId).HasName("PK_Tr_Id");

            entity.ToTable("siva.TrDetails");

            entity.Property(e => e.TrId).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("website");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
