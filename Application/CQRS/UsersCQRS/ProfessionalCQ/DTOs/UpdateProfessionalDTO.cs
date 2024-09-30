using Application.CQRS.GenericsCQRS.User.Commands;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.DTOs
{
    public record UpdateProfessionalDTO : UpdateUserDTO
    {
        public string? Job { get; set; }
    }
}