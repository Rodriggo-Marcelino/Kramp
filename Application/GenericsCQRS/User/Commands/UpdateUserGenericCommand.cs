using System.Text.Json.Serialization;

namespace Application.GenericsCQRS.User.Commands;

public record UpdateUserGenericCommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Username { get; set; }
    public string? DocumentNumber { get; set; }
};