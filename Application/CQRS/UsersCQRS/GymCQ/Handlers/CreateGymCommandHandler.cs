using Application.CQRS.UsersCQRS.GymCQ.Commands;
using Application.CQRS.UsersCQRS.GymCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity.User;
using MediatR;
using Services.Repositories;

namespace Application.CQRS.UsersCQRS.GymCQ.Handlers
{
    public class CreateGymCommandHandler : IRequestHandler<CreateGymCommand, ResponseBase<GymInfoViewModel?>>
    {
        private readonly IAuthService _authService;
        private readonly GymRepository _repository;
        private readonly IMapper _mapper;

        public CreateGymCommandHandler(IAuthService authService, GymRepository repository, IMapper mapper)
        {
            _authService = authService;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<GymInfoViewModel?>> Handle(CreateGymCommand request,
            CancellationToken cancellationToken)
        {
            Gym gym = _mapper.Map<Gym>(request);
            gym.PasswordHash = request.Password;
            gym.CreatedAt = DateTime.UtcNow;
            gym.RefreshToken = Guid.NewGuid().ToString();
            gym.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            await _repository.AddAsync(gym);

            GymInfoViewModel gymInfoVm = _mapper.Map<GymInfoViewModel>(gym);
            gymInfoVm.TokenJWT = _authService.GenerateJWT(gym.DocumentNumber!, gym.Username!);

            return new ResponseBase<GymInfoViewModel?>
            {
                ResponseInfo = null,
                Value = gymInfoVm
            };
        }
    }
}