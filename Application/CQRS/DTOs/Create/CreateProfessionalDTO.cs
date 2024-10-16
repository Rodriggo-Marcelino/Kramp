using Domain.Entity.Enum;

namespace Application.CQRS.DTOs.Create
{
    public record CreateProfessionalDTO : CreateUserDTO
    {
        public Job Job { get; set; }
    }
}