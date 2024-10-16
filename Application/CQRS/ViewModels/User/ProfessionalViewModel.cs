using Domain.Entity.Enum;

namespace Application.CQRS.ViewModels.User
{
    public record ProfessionalViewModel : UserViewModel
    {
        public Job Job { get; set; }
    }
}