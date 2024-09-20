using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Handlers;

public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, ResponseBase<PlanInfoViewModel?>>
{
    private readonly IAuthService _authService;
    private readonly PlanRepository _repository;
    private readonly IMapper _mapper;

    public CreatePlanCommandHandler(IAuthService authService, PlanRepository repository, IMapper mapper)
    {
        _authService = authService;
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseBase<PlanInfoViewModel?>> Handle(CreatePlanCommand request,
        CancellationToken cancellationToken)
    {
        Plan plan = _mapper.Map<Plan>(request);

        await _repository.AddAsync(plan, cancellationToken);

        PlanInfoViewModel planInfoVm = _mapper.Map<PlanInfoViewModel>(plan);

        return new ResponseBase<PlanInfoViewModel?>
        {
            ResponseInfo = null,
            Value = planInfoVm
        };
    }
}