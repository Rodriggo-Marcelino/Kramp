using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Training;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Handlers;

public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, ResponseBase<PlanInfoViewModel>>
{
    private readonly PlanRepository _repository;
    private readonly WorkoutRepository _workoutRepository;
    private readonly PlanWorkoutRepository _planWorkoutRepository;
    private readonly IMapper _mapper;

    public UpdatePlanCommandHandler(
        PlanRepository repository,
        IMapper mapper,
        WorkoutRepository workoutRepository,
        PlanWorkoutRepository planWorkoutRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _workoutRepository = workoutRepository;
        _planWorkoutRepository = planWorkoutRepository;
    }

    public async Task<ResponseBase<PlanInfoViewModel>> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        List<PlanWorkout> planWorkouts = new List<PlanWorkout>();
        Plan? oldPlan = await _repository.GetByIdAsync(request.Id);

        if (oldPlan == null)
        {
            throw new Exception("Plan not found.");
        }

        var newPlan = _mapper.Map(request, oldPlan);

        if (request.Workouts.Any())
        {
            IEnumerable<Workout> workouts = await _workoutRepository.FindAllByIdAsync(request.Workouts);
            planWorkouts = await SaveAllPlanWorkouts(workouts, newPlan);

            newPlan.Workouts = planWorkouts;
        }

        await _repository.UpdateAsync(newPlan, cancellationToken);

        PlanInfoViewModel planInfoVm = _mapper.Map<PlanInfoViewModel>(newPlan);

        return new ResponseBase<PlanInfoViewModel>
        {
            ResponseInfo = null,
            Value = planInfoVm
        };

    }

    private async Task<List<PlanWorkout>> SaveAllPlanWorkouts(IEnumerable<Workout> workouts, Plan newPlan)
    {
        List<PlanWorkout> planWorkouts = new List<PlanWorkout>();

        foreach (Workout workout in workouts)
        {
            planWorkouts.Add(new PlanWorkout
            {
                PlanId = newPlan.Id,
                Plan = newPlan,
                WorkoutId = workout.Id,
                Workout = workout
            });

            await _planWorkoutRepository.AddAsync(planWorkouts.Last(), default);
        }

        return planWorkouts;
    }
}