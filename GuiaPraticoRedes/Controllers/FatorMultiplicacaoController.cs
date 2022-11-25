using GuiaPraticoRedes.Extensions;
using GuiaPraticoRedes.Models.FatorMultiplicacaos;
using GuiaPraticoRedes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GuiaPraticoRedes.Controllers
{
    [Authorize]
    public class FatorMultiplicacaoController : ControllerBase
    {
        public FatorMultiplicacaoController()
        {
        }

        [HttpGet("api/[controller]")]
        public IEnumerable<FatorMultiplicacao> GetAll()
        {
            return FatorMultiplicacaoService.Listar();
        }

        [HttpPut("api/[controller]")]
        public ActionResult Update(FatorMultiplicacao input)
        {
            if (!FatorMultiplicacaoService.Listar().Any(i => i.Id == input.Id))
                return NotFound();
            FatorMultiplicacaoService.Atualizar(input);
            return Ok();
        }

        [HttpGet("api/[controller]/receiveInfoEmail")]
        public ActionResult ReceiveInfoEmail()
        {
            var idUsuario = User.Identity.ObterIdUsuario();
            var user = UserService.Obter(idUsuario);
            if (user == null)
                return NotFound("Usuário não encontrado");

            var objsToSerialize = FatorMultiplicacaoService.Listar();
            string jsonObj = JsonConvert.SerializeObject(objsToSerialize, Formatting.Indented);

            EmailService.EnviarEmail(user.Email, "Dados tabela valores", jsonObj);
            return Ok();
        }
    }
}