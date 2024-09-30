using Application.CQRS.GenericsCQRS.User.ViewModel;
using Domain.Entity.Enum;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.ViewModels
{
    public record ProfessionalViewModel : UserViewModel
    {
        public Job Job { get; set; }
    }
}