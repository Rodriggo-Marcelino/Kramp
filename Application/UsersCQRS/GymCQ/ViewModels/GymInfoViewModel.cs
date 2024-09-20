namespace Application.GymCQ.ViewModels
{
    public record GymInfoViewModel : TokenViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Username { get; set; }

        //TODO: Address deve aparecer para o Cliente
    }
}
