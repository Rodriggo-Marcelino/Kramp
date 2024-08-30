using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Application.Response;
using Domain.Entity;
using Infrastructure.Persistence;
using MediatR;

namespace Application.ManagerCQ.Handlers
{
    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, ResponseBase<ManagerInfoViewModel?>>
    {
        private readonly KrampDbContext _context;

        public CreateManagerCommandHandler(KrampDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<ManagerInfoViewModel>> Handle(CreateManagerCommand request,
                                                       CancellationToken cancellationToken)
        {
            var manager = new Manager
            {
                Name = request.Name,
                Surname = request.Surname,
                UserBio = request.UserBio,
                BirthDate = request.BirthDate,
                Username = request.Username,
                PasswordHash = request.Password,
                DocumentNumber = request.DocumentNumber,
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6)
            };

            _context.Managers.Add(manager);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseBase<ManagerInfoViewModel>
            {
                ResponseInfo = null,
                Value = new()
                {
                    Name = manager.Name,
                    Surname = manager.Surname,
                    UserBio = manager.UserBio,
                    BirthDate = manager.BirthDate,
                    Username = manager.Username,
                    RefreshToken = manager.RefreshToken,
                    RefreshTokenExpiryTime = manager.RefreshTokenExpiryTime
                }
            };
        }
    }
}
