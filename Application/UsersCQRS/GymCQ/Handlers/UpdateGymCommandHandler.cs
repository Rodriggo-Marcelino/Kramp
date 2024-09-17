using Application.GymCQ.Commands;
using Application.GymCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Services.Repositories;

namespace Application.GymCQ.Handlers;

public class UpdateGymCommandHandler : IRequestHandler<UpdateGymCommand, ResponseBase<GymInfoViewModel>>
{
    private readonly GymRepository _repository;
    private readonly IMapper _mapper;
    
    public UpdateGymCommandHandler(GymRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<ResponseBase<GymInfoViewModel>> Handle(UpdateGymCommand request, CancellationToken cancellationToken)
    {
        Gym? oldGym = await _repository.GetByIdAsync(request.Id);
        
        if(oldGym == null)
        {
            throw new Exception("Gym not found.");
        }

        Gym newGym = _mapper.Map(request, oldGym);
        
        newGym.RefreshToken = Guid.NewGuid().ToString();
        newGym.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);
        
        await _repository.UpdateAsync(newGym, cancellationToken);
        
        GymInfoViewModel gymInfoVm = _mapper.Map<GymInfoViewModel>(newGym);

        return new ResponseBase<GymInfoViewModel>
        {
            ResponseInfo = null,
            Value = gymInfoVm
        };
    }
}