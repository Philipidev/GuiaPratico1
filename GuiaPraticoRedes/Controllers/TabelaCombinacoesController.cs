using GuiaPraticoRedes.Extensions;
using GuiaPraticoRedes.Models.TabelaCombinacoess;
using GuiaPraticoRedes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json;

namespace GuiaPraticoRedes.Controllers
{
    [Authorize]
    public class TabelaCombinacoesController : ControllerBase
    {
        public TabelaCombinacoesController()
        {
        }

        [HttpGet("api/[controller]")]
        public IEnumerable<TabelaCombinacoes> GetAll()
        {
            return TabelaCombinacoesService.Listar();
        }

        [HttpGet("api/[controller]/{Id}")]
        public TabelaCombinacoes Get(int Id)
        {
            return TabelaCombinacoesService.Listar().FirstOrDefault(a => a.Id == Id);
        }

        [HttpPost("api/[controller]")]
        public TabelaCombinacoes Insert(TabelaCombinacoesInsert input)
        {
            if (input.IdUser == null)
            {
                var idUsuario = User.Identity.ObterIdUsuario();
                input.IdUser = idUsuario;
            }
            return TabelaCombinacoesService.Inserir(input);
        }

        [HttpGet("api/[controller]/receiveInfoEmail")]
        public ActionResult ReceiveInfoEmail()
        {
            var idUsuario = User.Identity.ObterIdUsuario();
            var user = UserService.Obter(idUsuario);
            if (user == null)
                return NotFound("Usuário não encontrado");
            var objsToSerialize = TabelaCombinacoesService.Listar().Where(a => a.IdUser == user.Id);
            string jsonObj = JsonConvert.SerializeObject(objsToSerialize, Formatting.Indented);

            EmailService.EnviarEmail(user.Email, "Dados viagens", jsonObj);
            return Ok();
        }
    }
}