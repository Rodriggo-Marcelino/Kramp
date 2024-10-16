using Domain.Entity.Enum;

namespace Application.CQRS.ViewModels
{
    public record ProfessionalViewModel : UserViewModel
    {
        public Job Job { get; set; }
    }
}