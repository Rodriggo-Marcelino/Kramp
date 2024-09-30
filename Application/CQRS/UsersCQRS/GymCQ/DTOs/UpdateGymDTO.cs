namespace Application.CQRS.UsersCQRS.GymCQ.DTOs
{
    public record UpdateGymDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Username { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
