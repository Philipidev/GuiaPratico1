using GuiaPratico1.Model.FatorMultiplicacaos;
using GuiaPratico1.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace GuiaPratico1.Services.Implementacao
{
    public class FatorMultiplicacaoService : IFatorMultiplicacaoService
    {
        private static List<FatorMultiplicacaoModel> Itens = new List<FatorMultiplicacaoModel>();

        public FatorMultiplicacaoService()
        {
            Itens.Add(new FatorMultiplicacaoModel()
            {
                Id = 1,
                Fator = 1,
                Veiculo = "Veiculo Urbano de carga (VUC)"
            });
            Itens.Add(new FatorMultiplicacaoModel()
            {
                Id = 2,
                Fator = 1.05,
                Veiculo = "Caminhao 3/4"
            });
            Itens.Add(new FatorMultiplicacaoModel()
            {
                Id = 3,
                Fator = 1.08,
                Veiculo = "Caminhao toco"
            });
            Itens.Add(new FatorMultiplicacaoModel()
            {
                Id = 4,
                Fator = 1.13,
                Veiculo = "Carreta simples"
            });
            Itens.Add(new FatorMultiplicacaoModel()
            {
                Id = 5,
                Fator = 1.19,
                Veiculo = "Carreta eixo estendido"
            });
        }

        public void Atualizar(FatorMultiplicacaoModel item)
        {
            Itens = Itens.Select(a =>
            {
                if (item.Id == a.Id)
                    return item;
                return a;
            }).ToList();
        }

        public List<FatorMultiplicacaoModel> Obter()
        {
            return Itens;
        }

        public void Redefinir(List<FatorMultiplicacaoModel> item)
        {
            Itens = item;
        }
    }
}