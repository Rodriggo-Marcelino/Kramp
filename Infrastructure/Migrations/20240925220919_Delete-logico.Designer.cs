﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(KrampDbContext))]
    [Migration("20240925220919_Delete-logico")]
    partial class Deletelogico
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Generics.UserGeneric", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeDocument")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entity.Training.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SynergistMuscle")
                        .HasColumnType("int");

                    b.Property<int>("TargetedMuscle")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Video")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("exercise");
                });

            modelBuilder.Entity("Domain.Entity.Training.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("training_plan");
                });

            modelBuilder.Entity("Domain.Entity.Training.PlanWorkout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("plan_workout");
                });

            modelBuilder.Entity("Domain.Entity.Training.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("RepetitionCount")
                        .HasColumnType("int");

                    b.Property<int>("SeriesCount")
                        .HasColumnType("int");

                    b.Property<string>("TargetedMuscles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("workout");
                });

            modelBuilder.Entity("Domain.Entity.Training.WorkoutExercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExerciseTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<int>("RestTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("workout_exercise");
                });

            modelBuilder.Entity("Domain.Entity.User.Gym", b =>
                {
                    b.HasBaseType("Domain.Entity.Generics.UserGeneric");

                    b.Property<string>("Description")
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240)");

                    b.ToTable("gym");
                });

            modelBuilder.Entity("Domain.Entity.User.Manager", b =>
                {
                    b.HasBaseType("Domain.Entity.Generics.UserGeneric");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserBio")
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240)");

                    b.ToTable("manager");
                });

            modelBuilder.Entity("Domain.Entity.User.Member", b =>
                {
                    b.HasBaseType("Domain.Entity.Generics.UserGeneric");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserBio")
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240)");

                    b.ToTable("member");
                });

            modelBuilder.Entity("Domain.Entity.User.Professional", b =>
                {
                    b.HasBaseType("Domain.Entity.Generics.UserGeneric");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Job")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserBio")
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240)");

                    b.ToTable("professional");
                });

            modelBuilder.Entity("Domain.Entity.Generics.UserGeneric", b =>
                {
                    b.HasOne("Domain.Entity.Training.Plan", null)
                        .WithMany("Users")
                        .HasForeignKey("PlanId");

                    b.HasOne("Domain.Entity.Training.Workout", null)
                        .WithMany("Users")
                        .HasForeignKey("WorkoutId");
                });

            modelBuilder.Entity("Domain.Entity.Training.PlanWorkout", b =>
                {
                    b.HasOne("Domain.Entity.Training.Plan", "Plan")
                        .WithMany("Workouts")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Training.Workout", "Workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Domain.Entity.Training.WorkoutExercise", b =>
                {
                    b.HasOne("Domain.Entity.Training.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Training.Workout", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Domain.Entity.User.Gym", b =>
                {
                    b.HasOne("Domain.Entity.Generics.UserGeneric", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entity.User.Gym", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.User.Manager", b =>
                {
                    b.HasOne("Domain.Entity.Generics.UserGeneric", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entity.User.Manager", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.User.Member", b =>
                {
                    b.HasOne("Domain.Entity.Generics.UserGeneric", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entity.User.Member", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.User.Professional", b =>
                {
                    b.HasOne("Domain.Entity.Generics.UserGeneric", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entity.User.Professional", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Training.Plan", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("Domain.Entity.Training.Workout", b =>
                {
                    b.Navigation("Exercises");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}