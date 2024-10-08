﻿using System.Text.Json.Serialization;
using Application.CQRS.GenericsCQRS.Generic.DTOs;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.DTOs
{
    public record UpdateExerciseInWorkoutDTO : UpdateGenericDTO
    {
        public Guid WorkoutId { get; set; }
        public Guid ExerciseId { get; set; }
        public int RestTimeInSeconds { get; set; }
        public int ExerciseTimeInSeconds { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
    }
}