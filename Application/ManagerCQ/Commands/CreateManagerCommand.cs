using Application.ManagerCQ.ViewModels;
using MediatR;
using Domain.Entity.Enum;

namespace Application.ManagerCQ.Commands
{
    public record CreateManagerCommand : IRequest<ManagerInfoViewModel>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserBio { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Username { get; set; }
        public Document TypeDocument { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Password { get; set; }
    }
}
