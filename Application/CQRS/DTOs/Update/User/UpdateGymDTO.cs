namespace Application.CQRS.DTOs.Update.User
{
    public record UpdateGymDTO : UpdateGenericDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Username { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
