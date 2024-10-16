using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create;

public class AddExerciseToWorkoutHandler(WorkoutExerciseRepository repository, IMapper mapper)
    : CreateEntityTemplate<
        WorkoutExercise,
        CreateEntityCommand<WorkoutExercise, AddExerciseToWorkoutDTO, WorkoutExerciseViewModel>,
        AddExerciseToWorkoutDTO,
        WorkoutExerciseViewModel,
        WorkoutExerciseRepository>(repository, mapper)
{
    protected override void ManipulateEntityBeforeSave(IEnumerable<AddExerciseToWorkoutDTO> request, IEnumerable<WorkoutExercise> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreatedAt = DateTime.UtcNow;
        }
    }
}