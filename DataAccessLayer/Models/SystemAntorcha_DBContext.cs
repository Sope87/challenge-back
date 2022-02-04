using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class SystemAntorcha_DBContext : DbContext
    {
        public SystemAntorcha_DBContext()
        {
        }

        public SystemAntorcha_DBContext(DbContextOptions<SystemAntorcha_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Name=AntorchaDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Professor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ProfessorId).HasColumnName("professor_id");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ProfessorId)
                    .HasConstraintName("FK_Student_Professor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
