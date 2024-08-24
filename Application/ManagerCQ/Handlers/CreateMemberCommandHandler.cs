﻿

using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using Domain.Entity;
using Infrastructure.Persistence;
using MediatR;

namespace Application.ManagerCQ.Handlers
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
                DocumentNumber = request.DocumentNumber,
                PasswordHash = request.Password,
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
                DocumentNumber = member.DocumentNumber,
                RefreshToken = member.RefreshToken,
                RefreshTokenExpiryTime = member.RefreshTokenExpiryTime
            };
        }
    }
}
