using Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Enum;
using Domain.Entity.Training;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Handlers;

public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand, ResponseBase<WorkoutInfoViewModel>>
{
    private readonly WorkoutRepository _repository;
    private readonly ExerciseRepository _exerciseRepository;
    private readonly WorkoutExerciseRepository _workoutExerciseRepository;
    private readonly IMapper _mapper;

    public UpdateWorkoutCommandHandler(
        WorkoutRepository repository,
        IMapper mapper,
        ExerciseRepository exerciseRepository,
        WorkoutExerciseRepository workoutExerciseRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _exerciseRepository = exerciseRepository;
        _workoutExerciseRepository = workoutExerciseRepository;
    }

    public async Task<ResponseBase<WorkoutInfoViewModel>> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
    {
        List<WorkoutExercise> workoutExercises = new List<WorkoutExercise>();
        Workout? oldWorkout = await _repository.GetByIdAsync(request.Id);

        if (oldWorkout == null)
        {
            throw new Exception("Workout not found");
        }

        var newWorkout = _mapper.Map(request, oldWorkout);
        newWorkout.TargetedMuscles = oldWorkout.TargetedMuscles;
        newWorkout.CreatedAt = DateTime.UtcNow;
        newWorkout.UpdatedAt = DateTime.UtcNow;

        if (request.Exercises.Any())
        {
            IEnumerable<Exercise> exercises = await _exerciseRepository.FindAllByIdAsync(request.Exercises);
            SaveAllTargetedMuscles(newWorkout, exercises);
            workoutExercises = await SaveAllWorkoutExercises(exercises, newWorkout);

            newWorkout.SeriesCount = CountSeries(workoutExercises);
            newWorkout.RepetitionCount = CountRepetitions(workoutExercises);
            newWorkout.Exercises = workoutExercises;
        }

        await _repository.UpdateAsync(newWorkout, cancellationToken);

        var workoutInfoVm = _mapper.Map<WorkoutInfoViewModel>(newWorkout);
        workoutInfoVm.TargetedMuscles = newWorkout.TargetedMuscles;

        return new ResponseBase<WorkoutInfoViewModel>
        {
            ResponseInfo = null,
            Value = workoutInfoVm
        };
    }

    private async Task<List<WorkoutExercise>> SaveAllWorkoutExercises(IEnumerable<Exercise> exercises, Workout newWorkout)
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
                Series = 3,
                Repetitions = 12,
                RestTimeInSeconds = 60,
                ExerciseTimeInSeconds = 20
            });

            await _workoutExerciseRepository.AddAsync(workoutExercises.Last(), default);
        }
        return workoutExercises;
    }

    protected int CountSeries(List<WorkoutExercise> workoutExercises) => workoutExercises.Sum(e => e.Series);

    protected int CountRepetitions(List<WorkoutExercise> workoutExercises) => workoutExercises.Sum(e => e.Repetitions);

    protected void SaveAllTargetedMuscles(Workout workout, IEnumerable<Exercise> exercises)
    {
        workout.TargetedMuscles = new List<Muscle>();

        foreach (var exercise in exercises)
        {
            workout.TargetedMuscles.Add(exercise.TargetedMuscle);
        }
    }
}