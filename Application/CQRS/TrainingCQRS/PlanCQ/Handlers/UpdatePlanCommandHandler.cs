using Application.CQRS.TrainingCQRS.PlanCQ.Commands;
using Application.CQRS.TrainingCQRS.PlanCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.TrainingCQRS.PlanCQ.Handlers;

public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, ResponseBase<PlanInfoViewModel>>
{
    private readonly PlanRepository _repository;
    private readonly IMapper _mapper;

    public UpdatePlanCommandHandler(PlanRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseBase<PlanInfoViewModel>> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        Plan? oldPlan = await _repository.GetByIdAsync(request.Id);

        if (oldPlan == null)
        {
            throw new Exception("Plan not found.");
        }

        Plan newPlan = _mapper.Map(request, oldPlan);
        newPlan.UpdatedAt = DateTime.Now;

        await _repository.UpdateAsync(newPlan, cancellationToken);

        PlanInfoViewModel planInfoVm = _mapper.Map<PlanInfoViewModel>(newPlan);

        return new ResponseBase<PlanInfoViewModel>
        {
            ResponseInfo = null,
            Value = planInfoVm
        };

    }
}