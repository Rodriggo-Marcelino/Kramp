﻿using Application.CQRS.GenericsCQRS.Generic.ViewModel;
using Domain.Entity.Enum;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels
{
    public record ExerciseViewModel : GenericViewModelBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Muscle TargetedMuscle { get; set; }
        public Muscle SynergistMuscle { get; set; }
        public string? Photo { get; set; }
        public string? Video { get; set; }
    }
}