namespace Application.CQRS.UsersCQRS.GymCQ.DTOs
{
    public record CreateGymDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
