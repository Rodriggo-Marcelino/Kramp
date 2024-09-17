using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity;
using MediatR;
using Services.Repositories;

namespace Application.ManagerCQ.Handlers
{
    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, ResponseBase<ManagerInfoViewModel?>>
    {
        private readonly IAuthService _authService;
        private readonly ManagerRepository _repository;
        private readonly IMapper _mapper;

        public CreateManagerCommandHandler(IAuthService authService, ManagerRepository repository, IMapper mapper)
        {
            _authService = authService;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<ManagerInfoViewModel?>> Handle(CreateManagerCommand request,
                                                       CancellationToken cancellationToken)
        {
            Manager manager = _mapper.Map<Manager>(request);
            
            manager.PasswordHash = request.Password;
            manager.CreatedAt = DateTime.UtcNow;
            manager.RefreshToken = Guid.NewGuid().ToString();
            manager.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            await _repository.AddAsync(manager, cancellationToken);

            ManagerInfoViewModel managerInfoVm = _mapper.Map<ManagerInfoViewModel>(manager);
            managerInfoVm.TokenJWT = _authService.GenerateJWT(manager.DocumentNumber!, manager.Username!);

            return new ResponseBase<ManagerInfoViewModel?>
            {
                ResponseInfo = null,
                Value = managerInfoVm
            };
        }
    }
}
