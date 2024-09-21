using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.Training;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Handlers;

public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, ResponseBase<PlanInfoViewModel?>>
{
    private readonly IAuthService _authService;
    private readonly PlanRepository _repository;
    private readonly WorkoutRepository _workoutRepository;
    private readonly IMapper _mapper;

    public CreatePlanCommandHandler(
        IAuthService authService,
        PlanRepository repository,
        WorkoutRepository workoutRepository,
        IMapper mapper)
    {
        _authService = authService;
        _repository = repository;
        _mapper = mapper;
        _workoutRepository = workoutRepository;
    }

    public async Task<ResponseBase<PlanInfoViewModel?>> Handle(CreatePlanCommand request,
        CancellationToken cancellationToken)
    {
        Plan plan = new Plan
        {
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        if (!request.Workouts.Any())
        {
            throw new Exception("Workouts cannot be null");
        }

        IEnumerable<Workout> workouts = await _workoutRepository.FindAllByIdAsync(request.Workouts);

        List<PlanWorkout> planWorkouts = SaveAllPlanWorkouts(workouts, plan);

        plan.Workouts = planWorkouts;

        await _repository.AddAsync(plan, cancellationToken);

        PlanInfoViewModel planInfoVm = new PlanInfoViewModel
        {
            Name = plan.Name,
            Description = plan.Description,
            StartDate = plan.StartDate,
            EndDate = plan.EndDate,
            Workouts = workouts.ToList()
        };

        return new ResponseBase<PlanInfoViewModel?>
        {
            ResponseInfo = null,
            Value = planInfoVm
        };
    }

    protected List<PlanWorkout> SaveAllPlanWorkouts(IEnumerable<Workout> workouts, Plan plan)
    {
        List<PlanWorkout> planWorkouts = new List<PlanWorkout>();

        foreach (var workout in workouts)
        {
            planWorkouts.Add(new PlanWorkout
            {
                PlanId = plan.Id,
                Plan = plan,
                WorkoutId = workout.Id,
                Workout = workout
            });
        }

        return planWorkouts;
    }


}