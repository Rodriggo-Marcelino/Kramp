using Application.CQRS.GenericsCQRS.User.Commands;
using Domain.Entity.Enum;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.DTOs
{
    public record CreateProfessionalDTO : CreateUserDTO
    {
        public Job Job { get; set; }
    }
}