using Domain.Entity.Enum;

namespace Application.CQRS.DTOs.Update
{
    public record UpdateProfessionalDTO : UpdateUserDTO
    {
        public Job Job { get; set; }
    }
}