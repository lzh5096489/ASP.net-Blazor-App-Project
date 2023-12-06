using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StarTedSystem.Entities;

namespace StarTedSystem.DAL;

public partial class StarTedContext : DbContext
{
    public StarTedContext()
    {
    }

    public StarTedContext(DbContextOptions<StarTedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=StarTED;TrustServerCertificate=True;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");
      

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK_dbo.Clubs");

            entity.HasIndex(e => e.EmployeeId, "IX_EmployeeID");

            entity.Property(e => e.ClubId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClubID");
            entity.Property(e => e.ClubName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Fee).HasColumnType("money");

            entity.HasOne(d => d.Employee).WithMany(p => p.Clubs)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_dbo.Clubs_dbo.Employees_EmployeeID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_dbo.Employees");

            entity.HasIndex(e => e.PositionId, "IX_PositionID");

            entity.HasIndex(e => e.ProgramId, "IX_ProgramID");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.DateHired).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LoginId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LoginID");
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.ProgramId).HasColumnName("ProgramID");
            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}