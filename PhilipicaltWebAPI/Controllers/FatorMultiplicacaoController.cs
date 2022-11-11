using Microsoft.AspNetCore.Mvc;
using GuiaPratico1.Model.FatorMultiplicacaos;
using GuiaPratico1.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace GuiaPratico1.Controllers
{
    public class FatorMultiplicacaoController : ControllerBase
    {
        private readonly IFatorMultiplicacaoService fatorMultiplicacaoService;

        public FatorMultiplicacaoController(IFatorMultiplicacaoService fatorMultiplicacaoService)
        {
            this.fatorMultiplicacaoService = fatorMultiplicacaoService;
        }

        [HttpGet("api/[controller]")]
        public IEnumerable<FatorMultiplicacaoModel> GetAll()
        {
            return fatorMultiplicacaoService.Obter();
        }

        [HttpPut("api/[controller]")]
        public ActionResult Update(FatorMultiplicacaoModel input)
        {
            if (!fatorMultiplicacaoService.Obter().Any(i => i.Id == input.Id))
                return NotFound();
            fatorMultiplicacaoService.Atualizar(input);
            return Ok();
        }
    }
}