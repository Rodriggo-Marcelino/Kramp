namespace Application.GymCQ.ViewModels
{
    public record GymInfoViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Username { get; set; }

        //TODO: Address deve aparecer para o Cliente

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
