using GuiaPratico1.Model;
using GuiaPratico1.Model.TabelaCombinacoess;
using System.Collections.Generic;

namespace GuiaPratico1.Services.Interface
{
    public interface ITabelaCombinacoesService
    {
        void Atualizar(TabelaCombinacoesUpdateModel item);

        void Excluir(TabelaCombinacoesModel item);

        TabelaCombinacoesModel Inserir(TabelaCombinacoesInsertModel item);

        List<TabelaCombinacoesModel> Obter();
    }
}