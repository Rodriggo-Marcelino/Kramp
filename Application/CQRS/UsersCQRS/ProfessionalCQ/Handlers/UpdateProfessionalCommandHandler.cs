using Application.CQRS.UsersCQRS.ProfessionalCQ.Commands;
using Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.Handlers;

public class UpdateProfessionalCommandHandler : IRequestHandler<UpdateProfessionalCommand, ResponseBase<ProfessionalInfoViewModel>>
{
    private readonly ProfessionalRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProfessionalCommandHandler(ProfessionalRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseBase<ProfessionalInfoViewModel>> Handle(UpdateProfessionalCommand request, CancellationToken cancellationToken)
    {
        Professional? oldProfessional = await _repository.GetByIdAsync(request.Id);

        if (oldProfessional == null)
        {
            throw new Exception("Professional not found.");
        }

        Professional newProfessional = _mapper.Map(request, oldProfessional);

        await _repository.UpdateAsync(newProfessional, cancellationToken);

        ProfessionalInfoViewModel professionalInfoVm = _mapper.Map<ProfessionalInfoViewModel>(newProfessional);

        return new ResponseBase<ProfessionalInfoViewModel>
        {
            ResponseInfo = null,
            Value = professionalInfoVm
        };
    }
}