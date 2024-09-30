using Application.CQRS.GenericsCQRS.User.DTOs;
using Domain.Entity.Enum;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.DTOs
{
    public record UpdateProfessionalDTO : UpdateUserDTO
    {
        public Job Job { get; set; }
    }
}