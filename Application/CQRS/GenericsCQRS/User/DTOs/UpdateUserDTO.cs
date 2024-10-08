using System.Text.Json.Serialization;
using Application.CQRS.GenericsCQRS.Generic.DTOs;

namespace Application.CQRS.GenericsCQRS.User.DTOs;

public record UpdateUserDTO : UpdateGenericDTO
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserBio { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Username { get; set; }
    public string? DocumentNumber { get; set; }
}