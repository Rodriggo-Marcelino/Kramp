using System.Text.Json.Serialization;

namespace Application.CQRS.GenericsCQRS.Generic.DTOs;

public record UpdateGenericDTO
{
    [JsonIgnore]
    public Guid Id { get; set; }
}