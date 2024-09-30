using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using AutoMapper;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Handlers;

public class
    UpdateSimplePlanCommandHandler : IRequestHandler<UpdateSimplePlanCommand, ResponseBase<SimplePlanViewModel>>
{
    private readonly PlanRepository _repository;
    private readonly WorkoutRepository _workoutRepository;
    private readonly PlanWorkoutRepository _planWorkoutRepository;
    private readonly IMapper _mapper;

    public UpdateSimplePlanCommandHandler(
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

    public async Task<ResponseBase<SimplePlanViewModel>> Handle(UpdateSimplePlanCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}