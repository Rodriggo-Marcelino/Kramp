namespace Domain.Abstractions
{
    public interface IAuthService
    {
        string GenerateJWT(string documentNumber, string username);
    }
}
