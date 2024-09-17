using System.Text.Json.Serialization;
using Application.MemberCQ.ViewModels;
using Application.Response;
using MediatR;

namespace Application.MemberCQ.Commands;

public class UpdateMemberCommand : IRequest<ResponseBase<MemberInfoViewModel>>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Username { get; set; }
    public string? DocumentNumber { get; set; }
}