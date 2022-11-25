using GuiaPraticoRedes.Models.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GuiaPraticoRedes.Services
{
    public static class AuthService
    {
        public static Usuarios? ValidateUser(string email, string senha)
        {
            if (email == "admin" && senha == "admin")
            {
                return new Usuarios()
                {
                    Id = Guid.NewGuid(),
                    Senha = senha,
                    Email = "admin@gmail.com"
                };
            }
            var user = UserService.ObterPorLoginSenha(email, senha);
            return user;
        }

        public static string GenerateToken(string login, Guid Id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Config.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login),
                    new Claim(ClaimTypes.NameIdentifier, Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
