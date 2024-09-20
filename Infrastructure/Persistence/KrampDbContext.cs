using Domain.Entity;
using Domain.Entity.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class KrampDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<UserGeneric> Users { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<TrainingGeneric> Trainings { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
