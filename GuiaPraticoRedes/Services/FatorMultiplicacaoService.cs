using GuiaPraticoRedes.Models.FatorMultiplicacaos;

namespace GuiaPraticoRedes.Services
{
    public static class FatorMultiplicacaoService
    {
        private static List<FatorMultiplicacao> Itens = new List<FatorMultiplicacao>()
        {
           new FatorMultiplicacao()
            {
                Id = 1,
                Fator = 1,
                Veiculo = "Veiculo Urbano de carga (VUC)"
            },new FatorMultiplicacao()
            {
                Id = 2,
                Fator = 1.05,
                Veiculo = "Caminhao 3/4"
            },
           new FatorMultiplicacao()
            {
                Id = 3,
                Fator = 1.08,
                Veiculo = "Caminhao toco"
            },
           new FatorMultiplicacao()
            {
                Id = 4,
                Fator = 1.13,
                Veiculo = "Carreta simples"
            },
           new FatorMultiplicacao(){
                Id = 5,
                Fator = 1.19,
                Veiculo = "Carreta eixo estendido"
            }
        };

        public static void Atualizar(FatorMultiplicacao item)
        {
            Itens = Itens.Select(a =>
            {
                if (item.Id == a.Id)
                    return item;
                return a;
            }).ToList();
        }

        public static List<FatorMultiplicacao> Listar()
        {
            return Itens;
        }

        public static void Redefinir(List<FatorMultiplicacao> item)
        {
            Itens = item;
        }
    }
}