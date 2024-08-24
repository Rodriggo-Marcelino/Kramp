using Application.GymCQ.Commands;
using Application.GymCQ.ViewModels;
using Domain.Entity;
using Infrastructure.Persistence;
using MediatR;

namespace Application.GymCQ.Handlers
{
    public class CreateGymCommandHandler : IRequestHandler<CreateGymCommand, GymInfoViewModel>
    {
        private readonly KrampDbContext _context;

        public CreateGymCommandHandler(KrampDbContext context)
        {
            _context = context;
        }

        public async Task<GymInfoViewModel> Handle(CreateGymCommand request,
                                                   CancellationToken cancellationToken)
        {
            var gym = new Gym
            {
                Name = request.Name,
                Description = request.Description,
                Username = request.Username,
                PasswordHash = request.Password,
                DocumentNumber = request.DocumentNumber,
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpiryTime = DateTime.UtcNow.AddMonths(6)
            };

            _context.Gyms.Add(gym);
            await _context.SaveChangesAsync(cancellationToken);

            return new GymInfoViewModel
            {
                Name = gym.Name,
                Description = gym.Description,
                Username = gym.Username,
                RefreshToken = gym.RefreshToken,
                RefreshTokenExpiryTime = gym.RefreshTokenExpiryTime
            };
        }
    }
}
