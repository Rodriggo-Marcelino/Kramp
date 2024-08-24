using Application.MemberCQ.ViewModels;
using MediatR;

namespace Application.MemberCQ.Commands
{
    public record CreateMemberCommand : IRequest<MemberInfoViewModel>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserBio { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
