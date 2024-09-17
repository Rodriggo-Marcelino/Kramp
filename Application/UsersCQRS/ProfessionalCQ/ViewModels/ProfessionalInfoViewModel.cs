using Application.GenericsCQRS.User;
using Domain.Entity.Enum;

namespace Application.ProfessionalCQ.ViewModels
{
    public record ProfessionalInfoViewModel : UserGenericViewModel
    {
        public Job Job { get; set; }
    }
}
