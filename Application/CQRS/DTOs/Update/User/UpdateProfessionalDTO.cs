using Domain.Entity.Enum;

namespace Application.CQRS.DTOs.Update.User
{
    public record UpdateProfessionalDTO : UpdateUserDTO
    {
        public Job Job { get; set; }
    }
}