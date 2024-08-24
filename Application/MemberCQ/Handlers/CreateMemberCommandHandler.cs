using Application.MemberCQ.Commands;
using Application.MemberCQ.ViewModels;
using Domain.Entity;
using Infrastructure.Persistence;
using MediatR;

namespace Application.MemberCQ.Handlers
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, MemberInfoViewModel>
    {
        private readonly KrampDbContext _context;

        public CreateMemberCommandHandler(KrampDbContext context)
        {
            _context = context;
        }

        public async Task<MemberInfoViewModel> Handle(CreateMemberCommand request,
                                                      CancellationToken cancellationToken)
        {
            var member = new Member
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

            _context.Members.Add(member);
            await _context.SaveChangesAsync(cancellationToken);

            return new MemberInfoViewModel
            {
                Name = member.Name,
                Surname = member.Surname,
                UserBio = member.UserBio,
                BirthDate = member.BirthDate,
                Username = member.Username,
                RefreshToken = member.RefreshToken,
                RefreshTokenExpiryTime = member.RefreshTokenExpiryTime
            };
        }
    }
}
