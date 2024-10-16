using Application.CQRS.Commands.Update;
using Application.CQRS.ViewModels;
using Application.Response;
using AutoMapper;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.Handlers.Update;

public class
    UpdateSimplePlanHandler : IRequestHandler<UpdateSimplePlanCommand, ResponseBase<SimplePlanViewModel>>
{
    private readonly PlanRepository _repository;
    private readonly WorkoutRepository _workoutRepository;
    private readonly PlanWorkoutRepository _planWorkoutRepository;
    private readonly IMapper _mapper;

    public UpdateSimplePlanHandler(
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