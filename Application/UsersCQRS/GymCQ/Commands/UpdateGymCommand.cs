using Application.GymCQ.ViewModels;
using Application.Response;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.GymCQ.Commands;

public class UpdateGymCommand : IRequest<ResponseBase<GymInfoViewModel>>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Username { get; set; }
    public string? DocumentNumber { get; set; }

    // TODO: Address deve fazer parte do Input
    // public Address Address { get; set; }
}