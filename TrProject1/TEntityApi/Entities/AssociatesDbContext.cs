using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TEntityApi.Entities;

public partial class AssociatesDbContext : DbContext
{
    public AssociatesDbContext()
    {
    }

    public AssociatesDbContext(DbContextOptions<AssociatesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SivaTrContact> SivaTrContacts { get; set; }

    public virtual DbSet<SivaTrDetail> SivaTrDetails { get; set; }

    public virtual DbSet<SivaTrEducation> SivaTrEducations { get; set; }

    public virtual DbSet<SivaTrSkill> SivaTrSkills { get; set; }

    public virtual DbSet<SivaTrcompany> SivaTrcompanies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:associateserver.database.windows.net,1433;Initial Catalog=AssociatesDb;Persist Security Info=False;User ID=associate;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SivaTrContact>(entity =>
        {
            entity.HasKey(e => e.Lid).HasName("PK__siva.TrC__C6505B39F563B68B");

            entity.ToTable("siva.TrContact");

            entity.HasIndex(e => e.Cid, "UQ__siva.TrC__C1F8DC381937527B").IsUnique();

            entity.Property(e => e.Lid).ValueGeneratedNever();
            entity.Property(e => e.Cid).HasColumnName("CId");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Pincode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pincode");

            entity.HasOne(d => d.CidNavigation).WithOne(p => p.SivaTrContact)
                .HasForeignKey<SivaTrContact>(d => d.Cid)
                .HasConstraintName("FK_C_Id");
        });

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

        modelBuilder.Entity<SivaTrEducation>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__siva.TrE__C1971B533737F425");

            entity.ToTable("siva.TrEducation");

            entity.Property(e => e.Eid).ValueGeneratedNever();
            entity.Property(e => e.Cgpa)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.HdegreeName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PassoutDate)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Startdate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("startdate");
            entity.Property(e => e.Tuniversity)
                .IsUnicode(false)
                .HasColumnName("TUniversity");

            entity.HasOne(d => d.TrEdu).WithMany(p => p.SivaTrEducations)
                .HasForeignKey(d => d.TrEduid)
                .HasConstraintName("FK_Tr_Edu_id");
        });

        modelBuilder.Entity<SivaTrSkill>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__siva.TrS__CA1E5D78A9EAF0C6");

            entity.ToTable("siva.TrSkill");

            entity.Property(e => e.Sid).ValueGeneratedNever();
            entity.Property(e => e.Skill)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skill");

            entity.HasOne(d => d.Trskill).WithMany(p => p.SivaTrSkills)
                .HasForeignKey(d => d.Trskillid)
                .HasConstraintName("FK_Tr_skill_id");
        });

        modelBuilder.Entity<SivaTrcompany>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__siva.Trc__C1FFD8610E81E026");

            entity.ToTable("siva.Trcompany");

            entity.Property(e => e.Cid).ValueGeneratedNever();
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ctype)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CType");
            entity.Property(e => e.Endyear)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("endyear");
            entity.Property(e => e.Startyear)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("startyear");

            entity.HasOne(d => d.Trcompany).WithMany(p => p.SivaTrcompanies)
                .HasForeignKey(d => d.Trcompanyid)
                .HasConstraintName("FK_Tr_company_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
