using Application.CQRS.UsersCQRS.ManagerCQ.ViewModels;

namespace Application.CQRS.UsersCQRS.ManagerCQ.Commands
{
    public record CreateManagerCommand : CreateEntityCommand<ManagerInfoViewModel>
    {
        public string? Surname { get; set; }
        public string? UserBio { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
