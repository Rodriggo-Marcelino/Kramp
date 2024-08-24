using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Domain.Entity;
using Domain.Entity.Enum;
using Infrastructure.Persistence;
using MediatR;

namespace Application.ManagerCQ.Handlers
{
    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, ManagerInfoViewModel>
    {
        private readonly KrampDbContext _context;

        public CreateManagerCommandHandler(KrampDbContext context)
        {
            _context = context;
        }

        public async Task<ManagerInfoViewModel> Handle(CreateManagerCommand request,
                                                       CancellationToken cancellationToken)
        {
            var manager = new Manager
            {
                Name = request.Name,
                Surname = request.Surname,
                UserBio = request.UserBio,
                BirthDate = request.BirthDate,
                Username = request.Username,
                TypeDocument = Document.CPF,
                DocumentNumber = request.DocumentNumber,
                PasswordHash = request.Password,
                CreatedAt = DateTime.Now,
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpiryTime = DateTime.Now.AddMonths(6)
            };

            _context.Managers.Add(manager);
            await _context.SaveChangesAsync(cancellationToken);

            return new ManagerInfoViewModel
            {
                Name = manager.Name,
                Surname = manager.Surname,
                UserBio = manager.UserBio,
                BirthDate = manager.BirthDate,
                Username = manager.Username,
                DocumentNumber = manager.DocumentNumber,
                RefreshToken = manager.RefreshToken,
                RefreshTokenExpiryTime = manager.RefreshTokenExpiryTime
            };
        }
    }
}
