using Application.CQRS.GenericsCQRS.User.ViewModel;

namespace Application.CQRS.UsersCQRS.GymCQ.ViewModels
{
    public record GymInfoViewModel : TokenViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Username { get; set; }

        //TODO: Address deve aparecer para o Cliente
    }
}
