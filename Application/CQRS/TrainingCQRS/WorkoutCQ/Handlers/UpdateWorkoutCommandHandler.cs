using Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Training;
using Infrastructure.Persistence;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Handlers;

public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand, ResponseBase<WorkoutInfoViewModel>>
{
    private readonly WorkoutRepository _repository;
    private readonly ExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;
    private readonly KrampDbContext _context;

    public UpdateWorkoutCommandHandler(
        WorkoutRepository repository,
        IMapper mapper,
        ExerciseRepository exerciseRepository,
        KrampDbContext context)
    {
        _repository = repository;
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
        _context = context;
    }

    public async Task<ResponseBase<WorkoutInfoViewModel>> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
    {
        Workout? oldWorkout = await _repository.GetByIdAsync(request.Id);

        if (oldWorkout == null)
        {
            throw new Exception("Workout not found");
        }

        var newWorkout = _mapper.Map(request, oldWorkout);
        newWorkout.TargetedMuscles = oldWorkout.TargetedMuscles;
        newWorkout.CreatedAt = DateTime.UtcNow;
        newWorkout.UpdatedAt = DateTime.UtcNow;

        if (!request.Exercises.Any())
        {
            throw new Exception("Exercises cannot be null");
        }

        IEnumerable<Exercise> exercises = await _exerciseRepository
            .FindAllByIdAsync(request.Exercises);

        SaveAllTargetedMuscles(newWorkout, exercises);

        List<WorkoutExercise> workoutExercises = SaveAllWorkoutExercises(exercises, newWorkout);

        newWorkout.SeriesCount = CountSeries(workoutExercises);
        newWorkout.RepetitionCount = CountRepetitions(workoutExercises);
        newWorkout.Exercises = workoutExercises;

        await _repository.UpdateAsync(newWorkout, cancellationToken);

        var workoutInfoVm = _mapper.Map<WorkoutInfoViewModel>(newWorkout);
        workoutInfoVm.TargetedMuscles = newWorkout.TargetedMuscles;
        workoutInfoVm.Exercises = newWorkout.Exercises.ToList();

        return new ResponseBase<WorkoutInfoViewModel>
        {
            ResponseInfo = null,
            Value = workoutInfoVm
        };
    }

    private List<WorkoutExercise> SaveAllWorkoutExercises(IEnumerable<Exercise> exercises, Workout newWorkout)
    {
        List<WorkoutExercise> workoutExercises = new List<WorkoutExercise>();
        foreach (Exercise exercise in exercises)
        {
            workoutExercises.Add(new WorkoutExercise
            {
                ExerciseId = exercise.Id,
                Exercise = exercise,
                WorkoutId = newWorkout.Id,
                Workout = newWorkout,
            });
        }
        return workoutExercises;
    }

    protected int CountSeries(List<WorkoutExercise> workoutExercises) => workoutExercises.Sum(e => e.Series);

    protected int CountRepetitions(List<WorkoutExercise> workoutExercises) => workoutExercises.Sum(e => e.Repetitions);

    protected void SaveAllTargetedMuscles(Workout workout, IEnumerable<Exercise> exercises)
    {
        foreach (var exercise in exercises)
        {
            workout.TargetedMuscles.Add(exercise.TargetedMuscle);
        }
    }
}