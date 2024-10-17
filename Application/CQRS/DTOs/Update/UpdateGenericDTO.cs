using System.Text.Json.Serialization;

namespace Application.CQRS.DTOs.Update;

public record UpdateGenericDTO
{
    [JsonIgnore]
    public Guid Id { get; set; }
}