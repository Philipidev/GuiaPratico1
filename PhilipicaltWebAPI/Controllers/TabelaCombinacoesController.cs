using Microsoft.AspNetCore.Mvc;
using GuiaPratico1.Model.TabelaCombinacoess;
using GuiaPratico1.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace GuiaPratico1.Controllers
{
    public class TabelaCombinacoesController : ControllerBase
    {
        private readonly ITabelaCombinacoesService tabelaCombinacoesService;

        public TabelaCombinacoesController(ITabelaCombinacoesService tabelaCombinacoesService)
        {
            this.tabelaCombinacoesService = tabelaCombinacoesService;
        }

        [HttpGet("api/[controller]")]
        public IEnumerable<TabelaCombinacoesModel> GetAll()
        {
            return tabelaCombinacoesService.Obter();
        }

        [HttpGet("api/[controller]/{Id}")]
        public TabelaCombinacoesModel Get(int Id)
        {
            return tabelaCombinacoesService.Obter().FirstOrDefault(a => a.Id == Id);
        }

        [HttpPost("api/[controller]")]
        public TabelaCombinacoesModel Insert(TabelaCombinacoesInsertModel input)
        {
            return tabelaCombinacoesService.Inserir(input);
        }

        [HttpPut("api/[controller]")]
        public ActionResult Update(TabelaCombinacoesUpdateModel input)
        {
            if (!tabelaCombinacoesService.Obter().Any(i => i.Id == input.Id))
                return NotFound();
            tabelaCombinacoesService.Atualizar(input);
            return Ok();
        }
    }
}