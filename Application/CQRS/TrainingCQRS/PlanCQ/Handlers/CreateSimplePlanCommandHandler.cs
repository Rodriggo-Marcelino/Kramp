using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Handlers;

public class CreateSimplePlanCommandHandler : IRequestHandler<CreateSimplePlanCommand, ResponseBase<SimplePlanViewModel?>>
{
    private readonly IAuthService _authService;
    private readonly PlanRepository _repository;
    private readonly WorkoutRepository _workoutRepository;
    private readonly IMapper _mapper;

    public CreateSimplePlanCommandHandler(
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

    public async Task<ResponseBase<SimplePlanViewModel?>> Handle(CreateSimplePlanCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}