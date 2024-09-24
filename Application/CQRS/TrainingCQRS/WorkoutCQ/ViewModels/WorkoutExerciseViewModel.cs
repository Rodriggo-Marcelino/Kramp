﻿namespace Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels
{
    public record WorkoutExerciseViewModel
    {
        public Guid ExerciseId { get; set; }
        public int RestTimeInSeconds { get; set; }
        public int ExerciseTimeInSeconds { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
    }
}