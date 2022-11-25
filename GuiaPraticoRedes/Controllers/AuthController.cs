using GuiaPraticoRedes.Models.Users;
using GuiaPraticoRedes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuiaPraticoRedes.Controllers
{
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
            
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = AuthService.ValidateUser(userLogin.Email, userLogin.Senha);
            if (user == null)
            {
                return Unauthorized(new { message = "Usuário ou senha inválidos" });
            }
            var token = AuthService.GenerateToken(userLogin.Email, user.Id);
            return Ok(new { token = token });
        }
        
        [HttpPost]
        [Route("register")]
        [Authorize]
        public IActionResult Register([FromBody] UserLogin userLogin)
        {
            var user = UserService.Inserir(userLogin);
            return Ok(user);
        }
    }
}
