using Application.CQRS.Commands;
using Application.CQRS.DTOs.Create;
using Application.CQRS.Templates;
using Application.CQRS.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Enum;
using Domain.Entity.Training;
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
    private readonly WorkoutExerciseRepository _workoutExerciseRepository;
    private readonly ExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;

    public CreateCompleteWorkoutHandler(
        WorkoutRepository repository,
        IMapper mapper,
        WorkoutExerciseRepository workoutExerciseRepository,
        ExerciseRepository exerciseRepository)
        : base(repository, mapper)
    {
        _mapper = mapper;
        _workoutExerciseRepository = workoutExerciseRepository;
        _exerciseRepository = exerciseRepository;
    }

    protected override void ManipulateEntityBeforeSave(IEnumerable<CreateCompleteWorkoutDTO> request, IEnumerable<Workout> entities)
    {
        var requestList = request.ToList();
        foreach (var entity in entities)
        {
            foreach (var requestData in requestList)
            {
                if (requestData.Name == entity.Name)
                {
                    SetCompleteWorkoutProperties(requestData, entity);
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
            repetitionCount += exercise.Repetitions * exercise.Series;

            var getExercise = _exerciseRepository.GetByIdAsync(exercise.ExerciseId);

            getExercise.Wait();

            if (getExercise.Result != null)
            {
                if (isNotInTheList(targetedMuscles, getExercise.Result.TargetedMuscle))
                {
                    targetedMuscles.Add(getExercise.Result.TargetedMuscle);
                }

                if (isNotInTheList(targetedMuscles, getExercise.Result.SynergistMuscle))
                {
                    targetedMuscles.Add(getExercise.Result.SynergistMuscle);
                }
            }
        }

        entity.RepetitionCount = repetitionCount;
        entity.SeriesCount = seriesCount;
        entity.TargetedMuscles = targetedMuscles;
        entity.CreatedAt = DateTime.UtcNow;
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

    private bool isNotInTheList(List<Muscle> list, Muscle muscle)
    {
        return !list.Contains(muscle);
    }
}