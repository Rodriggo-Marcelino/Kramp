using Application.ProfessionalCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using MediatR;

namespace Application.ProfessionalCQ.Commands
{
    public record CreateProfessionalCommand : IRequest<ResponseBase<ProfessionalInfoViewModel>>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserBio { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Job Job { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
