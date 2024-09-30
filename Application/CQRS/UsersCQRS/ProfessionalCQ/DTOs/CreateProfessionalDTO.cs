using Application.CQRS.GenericsCQRS.User.Commands;

namespace Application.CQRS.UsersCQRS.ProfessionalCQ.DTO
{
    public record CreateProfessionalDTO : CreateUserDTO
    {
        public string? Job { get; set; }
    }
}