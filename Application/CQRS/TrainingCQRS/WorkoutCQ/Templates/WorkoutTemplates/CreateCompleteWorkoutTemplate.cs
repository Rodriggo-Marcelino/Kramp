using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.TrainingCQRS.WorkoutCQ.DTOs;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using AutoMapper;
using Domain.Entity.Training;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Templates.WorkoutTemplates;

public class CreateCompleteWorkoutTemplate
    : CreateEntityHandler<
        Workout,
        CreateEntityCommand<Workout, CreateCompleteWorkoutDTO, CompleteWorkoutViewModel>,
        CreateCompleteWorkoutDTO,
        CompleteWorkoutViewModel,
        WorkoutRepository>
{
    private readonly WorkoutRepository _repository;
    private readonly WorkoutExerciseRepository _workoutExerciseRepository;
    private readonly IMapper _mapper;

    public CreateCompleteWorkoutTemplate(
        WorkoutRepository repository,
        IMapper mapper,
        WorkoutExerciseRepository workoutExerciseRepository
    ) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _workoutExerciseRepository = workoutExerciseRepository;
    }


}