using System.Collections;
using Application.CQRS.GenericsCQRS.Generic.Commands;
using Application.CQRS.GenericsCQRS.Generic.Handlers;
using Application.CQRS.TrainingCQRS.WorkoutCQ.DTOs;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Enum;
using Domain.Entity.Training;
using MediatR;
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
    private readonly ExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateCompleteWorkoutTemplate(
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

    protected override void ManipulateEntityBeforeSave(IEnumerable<CreateCompleteWorkoutDTO> request, IEnumerable<Workout> entities)
    {
        foreach (var entity in entities)
        {
            while (request.GetEnumerator().MoveNext())
            {
                var currDto = request.GetEnumerator().Current;
                if (currDto.Name == entity.Name)
                {
                    SetCompleteWorkoutProperties(currDto, entity);
                }
            }
        }
    }

    protected override void ManipulateEntityAfterSave(IEnumerable<CreateCompleteWorkoutDTO> request, IEnumerable<Workout> entities)
    {
        foreach (var workout in entities)
        {
            foreach (var dto in request)
            {
                if (dto.Name == workout.Name)
                {
                    foreach (var exercise in dto.Exercises)
                    {
                        exercise.WorkoutId = workout.Id;
                    }
                    
                    SaveAllExercisesInWorkout(dto.Exercises);
                }
            }
        }
    }

    protected override ResponseBase<IEnumerable<CompleteWorkoutViewModel>> CreateResponse(IEnumerable<Workout>? entityList)
    {
        var viewModels = _mapper.Map<IEnumerable<CompleteWorkoutViewModel>>(entityList);

        viewModels = InsertExercisesInViewModel(viewModels, entityList);
        
        return new ResponseBase<IEnumerable<CompleteWorkoutViewModel>>(new ResponseInfo(), viewModels);
    }
    
    private void SetCompleteWorkoutProperties(CreateCompleteWorkoutDTO dto, Workout entity)
    {
        var seriesCount = 0;
        var repetitionCount = 0;
        var targetedMuscles = new List<Muscle>();
        
        foreach (var exercise in dto.Exercises)
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

    private void SaveAllExercisesInWorkout(IEnumerable<AddExerciseToWorkoutDTO> dto)
    {
        var command = new
            CreateEntityCommand<WorkoutExercise, AddExerciseToWorkoutDTO, WorkoutExerciseViewModel>(dto);
        _mediator.Send(command);
    }

    private IEnumerable<CompleteWorkoutViewModel> InsertExercisesInViewModel(
        IEnumerable<CompleteWorkoutViewModel> viewModels, IEnumerable<Workout>? entityList)
    {
        var updatedViewModels = new List<CompleteWorkoutViewModel>();
        
        foreach (var workout in entityList)
        {
            var workoutExercises = _workoutExerciseRepository
                .FindAllAsync(exercise =>
                    exercise.WorkoutId == workout.Id)
                .Result
                .ToList();

            foreach (var viewModel in viewModels)
            {
                if (viewModel.Name == workout.Name)
                {
                    viewModel.Exercises = _mapper.Map<List<WorkoutExerciseViewModel>>(workoutExercises);
                    updatedViewModels.Add(viewModel);
                }
            }
        }
        
        return updatedViewModels;
    }
}