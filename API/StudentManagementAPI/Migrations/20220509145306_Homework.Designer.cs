﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Migrations
{
    [DbContext(typeof(StudentManagementContext))]
    [Migration("20220509145306_Homework")]
    partial class Homework
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            RoleId = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserToken");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                            ConcurrencyStamp = "ca600487-f853-4824-9f7c-9c6a032abcf6",
                            Description = "Administrator role",
                            Name = "admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("StudentManagementAPI.Models.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            AccessFailedCount = 0,
                            Birthday = new DateTime(2000, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "33192962-fa02-40a0-b54a-a2566d73ac6c",
                            Email = "tuanhoan@gmail.com",
                            EmailConfirmed = true,
                            FullName = "Tuấn Hoàn",
                            LockoutEnabled = false,
                            NormalizedEmail = "tuanhoan@gmail.com",
                            NormalizedUserName = "tuanhoan",
                            PasswordHash = "AQAAAAEAACcQAAAAEOxYWxdGyeuo1bQpG7oIQu8umDnJXaUCss2G/5dEjfkD86LOPYlkCFsb4TZgaaR0bw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "tuanhoan"
                        });
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Comment", b =>
                {
                    b.Property<int>("NewsFeedId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgSources")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NewsFeedId", "UserId", "CreatedAt");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Exercise", b =>
                {
                    b.Property<int>("HomeworkId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sources")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HomeworkId", "UserId", "CreatedAt");

                    b.HasIndex("UserId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Homework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.MapTeacherSubjectTeam", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("NumberOfLesson")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TeamId", "TeacherId", "SubjectId")
                        .HasName("pk_MapTeacherSubjectTeams");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("MapTeacherSubjectTeams");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.NewsFeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("pk_newFeed");

                    b.ToTable("NewsFeeds");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Score", b =>
                {
                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TestTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<double>("Point")
                        .HasColumnType("float");

                    b.HasKey("SemesterId", "StudentId", "TestTypeId", "SubjectId")
                        .HasName("pk_score");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TestTypeId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeEnd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeStart")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("pk_semester");

                    b.ToTable("Semesters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Học Kì 1",
                            TimeEnd = "2/15/2023 12:00:00 AM",
                            TimeStart = "9/4/2022 12:00:00 AM"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Học Kì 2",
                            TimeEnd = "6/5/2023 12:00:00 AM",
                            TimeStart = "2/20/2023 12:00:00 AM"
                        });
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("pk_Students");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Subjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AvoidLastLesson")
                        .HasColumnType("bit");

                    b.Property<string>("Block")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("LabId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("RequriedSpacing")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("pk_Subjects");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Teachers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("HasChildren")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkipDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("pk_Teachers");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.HasIndex("SubjectId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("pk_Teams");

                    b.HasIndex("TeacherId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.TestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ScoreFactor")
                        .HasColumnType("float");

                    b.Property<string>("TestName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("pk_testType");

                    b.ToTable("TestTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ScoreFactor = 1.0,
                            TestName = "15P"
                        },
                        new
                        {
                            Id = 2,
                            ScoreFactor = 2.0,
                            TestName = "60P"
                        },
                        new
                        {
                            Id = 3,
                            ScoreFactor = 3.0,
                            TestName = "Học Kì"
                        });
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Comment", b =>
                {
                    b.HasOne("StudentManagementAPI.Models.NewsFeed", "NewsFeedNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("NewsFeedId")
                        .HasConstraintName("fk_newFeed_Comment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementAPI.Models.AppUser", "UserNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_newFeed_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NewsFeedNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Exercise", b =>
                {
                    b.HasOne("StudentManagementAPI.Models.Homework", "HomeworkNavigation")
                        .WithMany("Exercises")
                        .HasForeignKey("HomeworkId")
                        .HasConstraintName("fk_homework_execrise")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudentManagementAPI.Models.AppUser", "UserNavigation")
                        .WithMany("Exercises")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_execrise")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HomeworkNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Homework", b =>
                {
                    b.HasOne("StudentManagementAPI.Models.AppUser", "UserNavigation")
                        .WithMany("Homeworks")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_homework_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.MapTeacherSubjectTeam", b =>
                {
                    b.HasOne("StudentManagementAPI.Models.Subjects", "SubjectNavigation")
                        .WithMany("MapTeacherSubjectTeams")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("fk_MapTeacherSubjectTeams_Subjects")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudentManagementAPI.Models.Teachers", "TeacherNavigation")
                        .WithMany("MapTeacherSubjectTeams")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("fk_MapTeacherSubjectTeams_Teachers")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StudentManagementAPI.Models.Teams", "TeamNavigation")
                        .WithMany("MapTeacherSubjectTeams")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("fk_MapTeacherSubjectTeams_Teams")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SubjectNavigation");

                    b.Navigation("TeacherNavigation");

                    b.Navigation("TeamNavigation");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Score", b =>
                {
                    b.HasOne("StudentManagementAPI.Models.Semester", "SemesterNavigation")
                        .WithMany("Scores")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("fk_score_semester")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementAPI.Models.Students", "StudentNavigation")
                        .WithMany("Scores")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("fk_score_student")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementAPI.Models.Subjects", "SubjectNavigation")
                        .WithMany("Scores")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("fk_score_subject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementAPI.Models.TestType", "TestTypeNavigation")
                        .WithMany("Scores")
                        .HasForeignKey("TestTypeId")
                        .HasConstraintName("fk_score_testtype")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SemesterNavigation");

                    b.Navigation("StudentNavigation");

                    b.Navigation("SubjectNavigation");

                    b.Navigation("TestTypeNavigation");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Students", b =>
                {
                    b.HasOne("StudentManagementAPI.Models.AppUser", "AppUser")
                        .WithOne("StudentNavigation")
                        .HasForeignKey("StudentManagementAPI.Models.Students", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementAPI.Models.Teams", "TeamNavigation")
                        .WithMany("Students")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("fk_team_student")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("TeamNavigation");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Teachers", b =>
                {
                    b.HasOne("StudentManagementAPI.Models.AppUser", "AppUser")
                        .WithOne("TeacherNavigation")
                        .HasForeignKey("StudentManagementAPI.Models.Teachers", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagementAPI.Models.Subjects", "SubjectNavigation")
                        .WithMany("Teachers")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("fk_Teachers_Subject")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("SubjectNavigation");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Teams", b =>
                {
                    b.HasOne("StudentManagementAPI.Models.Teachers", "TeachersNavigation")
                        .WithMany("Teams")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("fk_Teams_Teachers")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("TeachersNavigation");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.AppUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Exercises");

                    b.Navigation("Homeworks");

                    b.Navigation("StudentNavigation");

                    b.Navigation("TeacherNavigation");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Homework", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.NewsFeed", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Semester", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Students", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Subjects", b =>
                {
                    b.Navigation("MapTeacherSubjectTeams");

                    b.Navigation("Scores");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Teachers", b =>
                {
                    b.Navigation("MapTeacherSubjectTeams");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.Teams", b =>
                {
                    b.Navigation("MapTeacherSubjectTeams");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentManagementAPI.Models.TestType", b =>
                {
                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
