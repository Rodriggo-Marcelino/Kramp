using System.Text.Json.Serialization;
using Application.ProfessionalCQ.ViewModels;
using Application.Response;
using Domain.Entity.Enum;
using MediatR;

namespace Application.ProfessionalCQ.Commands;

public class UpdateProfessionalCommand : IRequest<ResponseBase<ProfessionalInfoViewModel>>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Username { get; set; }
    
    // Deve-se criar outra requisição para Job e Document Number??
    public Job Job { get; set; } 
    public string? DocumentNumber { get; set; }
}