using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Configurations;
using StudentManagementAPI.Extensions;
using StudentManagementAPI.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class StudentManagementContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        { }
        public DbSet<MapTeacherSubjectTeam> MapTeacherSubjectTeams { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<NewsFeed> NewsFeeds { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            ConstructSeedingData(modelBuilder);

            modelBuilder.Entity<MapTeacherSubjectTeam>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.TeacherId, e.SubjectId })
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

                //entity.HasOne<Teams>(s => s.TeamNavigation)
                //        .WithMany(c => c.Teachers)
                //        .HasForeignKey(e => e.TeamId)
                //        .OnDelete(DeleteBehavior.NoAction)
                //        .HasConstraintName("fk_Teachers_Teams");

                entity.HasOne<Subjects>(s => s.SubjectNavigation)
                       .WithMany(c => c.Teachers)
                       .HasForeignKey(e => e.SubjectId)
                       .OnDelete(DeleteBehavior.NoAction)
                       .HasConstraintName("fk_Teachers_Subject");

            }
          );
            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(c => c.Id)
                        .HasName("pk_Students");
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(c => c.TeamNavigation)
                     .WithMany(c => c.Students)
                     .HasForeignKey(e => e.TeamId)
                     .HasConstraintName("fk_team_student");

            }
         );
            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(c => c.Id)
                        .HasName("pk_Teams");
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasOne<Teachers>(s => s.TeachersNavigation)
                        .WithMany(c => c.Teams)
                        .HasForeignKey(e => e.TeacherId)
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_Teams_Teachers");


            }
          );

            modelBuilder.Entity<NewsFeed>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_newFeed");
            });

            modelBuilder.Entity<Comment>(e =>
            {
                e.HasKey(e => new { e.NewsFeedId, e.UserId, e.CreatedAt });
                e.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                e.HasOne(c => c.NewsFeedNavigation)
                    .WithMany(c => c.Comments)
                    .HasForeignKey(e => e.NewsFeedId)
                    .HasConstraintName("fk_newFeed_Comment");
                e.HasOne(c => c.UserNavigation)
                    .WithMany(c => c.Comments)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("fk_newFeed_User");

            });
            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_semester");
            });

            modelBuilder.Entity<TestType>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_testType");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => new { e.SemesterId, e.StudentId, e.TestTypeId, e.SubjectId })
                    .HasName("pk_score");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne<Semester>(e => e.SemesterNavigation)
                    .WithMany(e => e.Scores)
                    .HasForeignKey(e => e.SemesterId)
                    .HasConstraintName("fk_score_semester");
                entity.HasOne<Subjects>(e => e.SubjectNavigation)
                    .WithMany(e => e.Scores)
                    .HasForeignKey(e => e.SubjectId)
                    .HasConstraintName("fk_score_subject");
                entity.HasOne<TestType>(e => e.TestTypeNavigation)
                    .WithMany(e => e.Scores)
                    .HasForeignKey(e => e.TestTypeId)
                    .HasConstraintName("fk_score_testtype");
                entity.HasOne<Students>(e => e.StudentNavigation)
                   .WithMany(e => e.Scores)
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("fk_score_student");

            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(e => e.Source)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreateAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasOne(c => c.UserNavigation)
                 .WithMany(c => c.Homeworks)
                 .HasForeignKey(e => e.UserId)
                 .HasConstraintName("fk_homework_user");


            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.Property(e => e.Sources)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

                entity.HasKey(e => new { e.HomeworkId, e.UserId, e.CreatedAt });
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasOne(c => c.HomeworkNavigation)
                   .WithMany(c => c.Exercises)
                   .HasForeignKey(e => e.HomeworkId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("fk_homework_execrise");
                entity.HasOne(c => c.UserNavigation)
                    .WithMany(c => c.Exercises)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_user_execrise");
            });



            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(x => x.UserId);
        }

        private void ConstructSeedingData(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SemeterSeeding());
            modelBuilder.ApplyConfiguration(new TestTypeSeeding());
        }
    }
}
