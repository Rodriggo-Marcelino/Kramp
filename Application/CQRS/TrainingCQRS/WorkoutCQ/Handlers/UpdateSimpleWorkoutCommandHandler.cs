using Application.CQRS.TrainingCQRS.WorkoutCQ.Commands;
using Application.CQRS.TrainingCQRS.WorkoutCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Enum;
using Domain.Entity.Training;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.WorkoutCQ.Handlers;

public class
    UpdateSimpleWorkoutCommandHandler : IRequestHandler<UpdateSimpleWorkoutCommand,
    ResponseBase<SimpleWorkoutViewModel>>
{
    private readonly WorkoutRepository _repository;
    private readonly ExerciseRepository _exerciseRepository;
    private readonly WorkoutExerciseRepository _workoutExerciseRepository;
    private readonly IMapper _mapper;

    public UpdateSimpleWorkoutCommandHandler(
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

    public async Task<ResponseBase<SimpleWorkoutViewModel>> Handle(UpdateSimpleWorkoutCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private async Task<List<WorkoutExercise>> SaveAllWorkoutExercises(IEnumerable<Exercise> exercises,
        Workout newWorkout)
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

            await _workoutExerciseRepository.AddAsync(workoutExercises.Last());
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