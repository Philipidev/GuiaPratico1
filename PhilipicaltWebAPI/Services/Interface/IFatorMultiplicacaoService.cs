using GuiaPratico1.Model.FatorMultiplicacaos;
using System.Collections.Generic;

namespace GuiaPratico1.Services.Interface
{
    public interface IFatorMultiplicacaoService
    {
        void Atualizar(FatorMultiplicacaoModel item);

        List<FatorMultiplicacaoModel> Obter();

        void Redefinir(List<FatorMultiplicacaoModel> item);
    }
}