using Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.Enum;
using Domain.Entity.Training;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Handlers;

public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, ResponseBase<WorkoutInfoViewModel?>>
{
    private readonly IAuthService _authService;
    private readonly WorkoutRepository _repository;
    private readonly WorkoutExerciseRepository _workoutExerciseRepository;
    private readonly ExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;

    public CreateWorkoutCommandHandler
        (
        IAuthService authService,
        WorkoutRepository repository,
        IMapper mapper,
        WorkoutExerciseRepository workoutExerciseRepository,
        ExerciseRepository exerciseRepository
        )
    {
        _authService = authService;
        _repository = repository;
        _mapper = mapper;
        _workoutExerciseRepository = workoutExerciseRepository;
        _exerciseRepository = exerciseRepository;
    }

    public async Task<ResponseBase<WorkoutInfoViewModel?>> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
    {
        Workout workout = new Workout
        {
            Name = request.Name,
            Description = request.Description,
            Period = request.Period,
            TargetedMuscles = new List<Muscle>(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        if (!request.Exercises.Any())
        {
            throw new Exception("Exercises cannot be null");
        }

        IEnumerable<Exercise> exercises = await _exerciseRepository
            .FindAllByIdAsync(request.Exercises);

        saveAllTargetedMuscles(workout, exercises);

        List<WorkoutExercise> workoutExercises = SaveAllWorkoutExercises(exercises, workout);

        workout.Exercises = workoutExercises;

        await _repository.AddAsync(workout, cancellationToken);

        WorkoutInfoViewModel workoutInfoVm = new WorkoutInfoViewModel
        {
            Name = workout.Name,
            Description = workout.Description,
            Period = workout.Period.ToString(),
            SeriesCount = countSeries(workoutExercises),
            RepetitionCount = countRepetitions(workoutExercises),
            TargetedMuscles = workout.TargetedMuscles,
            Exercises = exercises.ToList()
        };

        return new ResponseBase<WorkoutInfoViewModel?>
        {
            ResponseInfo = null,
            Value = workoutInfoVm
        };
    }

    protected List<WorkoutExercise> SaveAllWorkoutExercises(IEnumerable<Exercise> exercises, Workout workout)
    {
        List<WorkoutExercise> workoutExercises = new List<WorkoutExercise>();

        foreach (var exercise in exercises)
        {
            workoutExercises.Add(new WorkoutExercise
            {
                ExerciseId = exercise.Id,
                Exercise = exercise,
                WorkoutId = workout.Id,
                Workout = workout,
                RestTimeInSeconds = 30,
                ExerciseTimeInSeconds = 30,
                Series = 3,
                Repetitions = 12,
            });
        }

        return workoutExercises;
    }

    protected int countSeries(List<WorkoutExercise> workoutExercises)
    {
        return workoutExercises.Sum(e => e.Series);
    }

    protected int countRepetitions(List<WorkoutExercise> workoutExercises)
    {
        return workoutExercises.Sum(e => e.Repetitions);
    }

    protected void saveAllTargetedMuscles(Workout workout, IEnumerable<Exercise> exercises)
    {
        foreach (var exercise in exercises)
        {
            workout.TargetedMuscles.Add(exercise.TargetedMuscle);
        }
    }
}