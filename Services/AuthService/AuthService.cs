using Domain.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Services.AuthService
{
    public class AuthService(IConfiguration configuration) : IAuthService
    {
        private readonly IConfiguration _configuration = configuration;
        public void GenerateJWT(string DocumentNumber, string password)
        {

            var issuer = _configuration["Jwt:Issuer"];

        }
    }
}
