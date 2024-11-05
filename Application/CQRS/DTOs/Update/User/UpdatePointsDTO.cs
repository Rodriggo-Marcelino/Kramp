namespace Application.CQRS.DTOs.Update.User;

public record UpdatePointsDTO : UpdateGenericDTO
{
    public int Points { get; set; }
}