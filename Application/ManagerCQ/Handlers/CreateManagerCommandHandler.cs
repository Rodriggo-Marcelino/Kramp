using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entity;
using Infrastructure.Persistence;
using MediatR;

namespace Application.ManagerCQ.Handlers
{
    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, ResponseBase<ManagerInfoViewModel?>>
    {
        private readonly IAuthService _authService;
        private readonly KrampDbContext _context;
        private readonly IMapper _mapper;

        public CreateManagerCommandHandler(IAuthService authService, KrampDbContext context, IMapper mapper)
        {
            _authService = authService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseBase<ManagerInfoViewModel?>> Handle(CreateManagerCommand request,
                                                       CancellationToken cancellationToken)
        {
            var manager = _mapper.Map<Manager>(request);

         
            manager.PasswordHash = request.Password;

            manager.CreatedAt = DateTime.UtcNow;
            manager.RefreshToken = Guid.NewGuid().ToString();
            manager.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            _context.Managers.Add(manager);
            _context.SaveChanges();

            var managerInfoVm = _mapper.Map<ManagerInfoViewModel>(manager);
            managerInfoVm.TokenJWT = _authService.GenerateJWT(manager.DocumentNumber!, manager.Username!);

            return new ResponseBase<ManagerInfoViewModel?>
            {
                ResponseInfo = null,
                Value = managerInfoVm
            };
        }
    }
}
