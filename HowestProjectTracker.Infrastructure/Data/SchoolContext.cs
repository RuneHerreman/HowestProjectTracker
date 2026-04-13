using System;
using System.Collections.Generic;
using HowestProjectTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HowestProjectTracker.Infrastructure.Data;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Help> Helps { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsCourse> StudentsCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("pk_courses");
        });

        modelBuilder.Entity<Help>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__help__3213E83FCD1EE5C8");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("pk_students");

            entity.Property(e => e.Email).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Gender).IsFixedLength();
            entity.Property(e => e.Paid).HasDefaultValue(0);
        });

        modelBuilder.Entity<StudentsCourse>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.CourseId }).HasName("pk_students_courses");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentsCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk2_students_courses");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk1_students_courses");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
