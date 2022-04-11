using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        { }
        public DbSet<MapTeacherSubjectTeam> MapTeacherSubjectTeams { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Teams> Teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MapTeacherSubjectTeam>(entity =>
            {
                entity.HasKey(e => new {e.TeamId, e.TeacherId, e.SubjectId})
                    .HasName("pk_MapTeacherSubjectTeams");
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasOne<Subjects>(s => s.SubjectNavigation)
                        .WithMany(c => c.MapTeacherSubjectTeams)
                        .HasForeignKey(e => e.SubjectId)
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_MapTeacherSubjectTeams_Subjects");
                entity.HasOne<Teachers>(s => s.TeacherNavigation)
                       .WithMany(c => c.MapTeacherSubjectTeams)
                       .HasForeignKey(e => e.TeacherId)
                       .OnDelete(DeleteBehavior.NoAction)
                       .HasConstraintName("fk_MapTeacherSubjectTeams_Teachers");
                entity.HasOne<Teams>(s => s.TeamNavigation)
                       .WithMany(c => c.MapTeacherSubjectTeams)
                       .HasForeignKey(e => e.TeamId)
                       .OnDelete(DeleteBehavior.NoAction)
                       .HasConstraintName("fk_MapTeacherSubjectTeams_Teams");
            }
            );
            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(c => c.Id)
                        .HasName("pk_Subjects");
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            }
            );
            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(c => c.Id)
                        .HasName("pk_Teachers");
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne<Teams>(s => s.TeamNavigation)
                        .WithMany(c => c.Teachers)
                        .HasForeignKey(e => e.TeamId)
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_Teachers_Teams");
            }
          );
            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(c => c.Id)
                        .HasName("pk_Teams");
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            }
          );
        }
    }
}
