using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.PgSql;

public partial class CourseProjectContext : DbContext
{
    public CourseProjectContext()
    {
    }

    public CourseProjectContext(DbContextOptions<CourseProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocCollection> DocCollections { get; set; }

    public virtual DbSet<DocItem> DocItems { get; set; }

    public virtual DbSet<EnumLanguage> EnumLanguages { get; set; }

    public virtual DbSet<EnumState> EnumStates { get; set; }

    public virtual DbSet<SysRole> SysRoles { get; set; }

    public virtual DbSet<SysUser> SysUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=shaxzod71319#;Database=CourseProject");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_collection_pkey");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");

            entity.HasOne(d => d.State).WithMany(p => p.DocCollections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<DocItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_item_pkey");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Collection).WithMany(p => p.DocItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_collecion_id");

            entity.HasOne(d => d.State).WithMany(p => p.DocItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<EnumLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_language_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<EnumState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_state_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<SysRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_role_pkey");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");

            entity.HasOne(d => d.State).WithMany(p => p.SysRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        modelBuilder.Entity<SysUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_user_pkey");

            entity.HasIndex(e => e.PhoneNumber, "sys_user_unique_index_phone_number")
                .IsUnique()
                .HasFilter("(phone_number IS NOT NULL)");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Role).WithMany(p => p.SysUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_id");

            entity.HasOne(d => d.State).WithMany(p => p.SysUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
