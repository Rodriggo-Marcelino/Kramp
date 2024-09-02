namespace Domain.Abstractions
{
    public interface IAuthService
    {
        public void GenerateJWT(string DocumentNumber, string password);
    }
}
