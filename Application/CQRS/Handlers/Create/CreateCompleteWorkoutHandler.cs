using Application.CQRS.Commands.Create;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Enum;
using Domain.Entity.Training;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.Handlers.Create;

public class CreateCompleteWorkoutHandler
    : CreateEntityTemplate<
        Workout,
        CreateEntityCommand<Workout, CreateCompleteWorkoutDTO, CompleteWorkoutViewModel>,
        CreateCompleteWorkoutDTO,
        CompleteWorkoutViewModel,
        WorkoutRepository>
{
    private readonly WorkoutRepository _repository;
    private readonly WorkoutExerciseRepository _workoutExerciseRepository;
    private readonly ExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateCompleteWorkoutHandler(
        WorkoutRepository repository,
        IMapper mapper,
        WorkoutExerciseRepository workoutExerciseRepository,
        ExerciseRepository exerciseRepository,
        IMediator mediator)
        : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _workoutExerciseRepository = workoutExerciseRepository;
        _exerciseRepository = exerciseRepository;
        _mediator = mediator;
    }

    protected override void ManipulateEntityBeforeSave(CreateCompleteWorkoutDTO data, Workout entity)
    {
        var seriesCount = 0;
        var repetitionCount = 0;
        var targetedMuscles = new List<Muscle>();

        foreach (var exercise in data.Exercises)
        {
            seriesCount += exercise.Series;
            repetitionCount += exercise.Repetitions;

            var getExercise = _exerciseRepository.GetByIdAsync(exercise.ExerciseId);

            getExercise.Wait();

            if (getExercise.Result != null)
            {
                targetedMuscles.Add(getExercise.Result.TargetedMuscle);
                targetedMuscles.Add(getExercise.Result.SynergistMuscle);
            }
        }

        entity.RepetitionCount = repetitionCount;
        entity.SeriesCount = seriesCount;
        entity.TargetedMuscles = targetedMuscles;
        entity.CreatedAt = DateTime.UtcNow;
    }

    protected override void ManipulateEntityAfterSave(CreateCompleteWorkoutDTO data, Workout entity)
    {
        var command = new
            CreateEntityCommand<WorkoutExercise, AddExerciseToWorkoutDTO, WorkoutExerciseViewModel>(data.Exercises);
        _mediator.Send(command);
    }

    protected override ResponseBase<CompleteWorkoutViewModel> CreateResponse(Workout entity)
    {
        var viewModel = _mapper.Map<CompleteWorkoutViewModel>(entity);
        var workoutExercises = _workoutExerciseRepository
            .FindAllAsync(exercise =>
                exercise.WorkoutId == entity.Id)
            .Result
            .ToList();
        viewModel.Exercises = _mapper.Map<List<WorkoutExerciseViewModel>>(workoutExercises);
        return new ResponseBase<CompleteWorkoutViewModel>(new ResponseInfo(), viewModel);
    }
}