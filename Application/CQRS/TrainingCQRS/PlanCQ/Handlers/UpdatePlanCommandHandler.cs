using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity.Training;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Handlers;

public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, ResponseBase<PlanInfoViewModel>>
{
    private readonly PlanRepository _repository;
    private readonly WorkoutRepository _workoutRepository;
    private readonly IMapper _mapper;
    private readonly KrampDbContext _context;

    public UpdatePlanCommandHandler(
        PlanRepository repository,
        IMapper mapper,
        WorkoutRepository workoutRepository,
        KrampDbContext context)
    {
        _repository = repository;
        _mapper = mapper;
        _workoutRepository = workoutRepository;
        _context = context;
    }

    public async Task<ResponseBase<PlanInfoViewModel>> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        //TODO: Fix DbUpdateConcurrencyException
        Plan? plan = await _repository.GetByIdAsync(request.Id);

        if (plan == null)
        {
            throw new Exception("Plan not found.");
        }

        Plan newPlan = new Plan
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            UpdatedAt = DateTime.UtcNow,
        };

        _context.Entry(newPlan).State = EntityState.Detached;

        if (!request.Workouts.Any())
        {
            throw new Exception("Workouts cannot be null");
        }

        IEnumerable<Workout> workouts = await _workoutRepository.FindAllByIdAsync(request.Workouts);
        List<PlanWorkout> planWorkouts = SaveAllPlanWorkouts(workouts, newPlan);
        newPlan.Workouts = planWorkouts;

        await _repository.UpdateAsync(newPlan, cancellationToken);

        PlanInfoViewModel planInfoVm = _mapper.Map<PlanInfoViewModel>(newPlan);

        return new ResponseBase<PlanInfoViewModel>
        {
            ResponseInfo = null,
            Value = planInfoVm
        };

    }

    private List<PlanWorkout> SaveAllPlanWorkouts(IEnumerable<Workout> workouts, Plan newPlan)
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
        }

        return planWorkouts;
    }
}