using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Application.Response;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Persistence;
using MediatR;

namespace Application.ManagerCQ.Handlers
{
    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, ResponseBase<ManagerInfoViewModel?>>
    {
        private readonly KrampDbContext _context;
        private readonly IMapper _mapper;

        public CreateManagerCommandHandler(KrampDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseBase<ManagerInfoViewModel>> Handle(CreateManagerCommand request,
                                                       CancellationToken cancellationToken)
        {
            var manager = _mapper.Map<Manager>(request);
            manager.PasswordHash = request.Password;
            manager.CreatedAt = DateTime.UtcNow;
            manager.RefreshToken = Guid.NewGuid().ToString();
            manager.RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6);

            _context.Managers.Add(manager);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseBase<ManagerInfoViewModel>
            {
                ResponseInfo = null,
                Value = _mapper.Map<ManagerInfoViewModel>(manager)
            };
        }

        //TODO: Validação de email único
        //TODO: Validação de CPF único
        //TODO: Username unico
        //TODO: Encriptar senha
    }
}
