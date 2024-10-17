using Application.CQRS.Commands;
using Application.CQRS.DTOs.Update.Training;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels.Training;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update.Training;

public class UpdateExerciseInWorkoutHandler(WorkoutExerciseRepository repository, IMapper mapper)
    : UpdateEntityTemplate<
        WorkoutExercise,
        UpdateEntityCommand<WorkoutExercise, UpdateExerciseInWorkoutDTO, WorkoutExerciseViewModel>,
        UpdateExerciseInWorkoutDTO,
        WorkoutExerciseViewModel,
        WorkoutExerciseRepository>(repository, mapper);