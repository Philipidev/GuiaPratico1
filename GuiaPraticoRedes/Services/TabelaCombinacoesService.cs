using GuiaPraticoRedes.Models.TabelaCombinacoess;

namespace GuiaPraticoRedes.Services
{
    public static class TabelaCombinacoesService
    {
        private static List<TabelaCombinacoes> Itens = new List<TabelaCombinacoes>();

        public static List<TabelaCombinacoes> Listar() => Itens;

        public static TabelaCombinacoes Inserir(TabelaCombinacoesInsert item)
        {
            //Validar se insere na lista ou se retorna o item na lista
            int ultimoId = 0;
            if (Itens.Any())
                ultimoId = Itens.Select(a => a.Id).Max();
            var novo = new TabelaCombinacoes()
            {
                Carga = item.Carga,
                DistanciaRodoviaNaoPavimento = item.DistanciaRodoviaPavimento,
                DistanciaRodoviaPavimento = item.DistanciaRodoviaPavimento,
                IdVeiculo = item.IdVeiculo,
                IdUser = item.IdUser,
            };
            novo.Id = ultimoId + 1;
            novo.Custo = CalcularCusto(item.IdVeiculo, item.DistanciaRodoviaPavimento, item.DistanciaRodoviaNaoPavimento, item.Carga);
            Itens = Itens.Append(novo).ToList();
            return novo;
        }

        public static void Atualizar(TabelaCombinacoesUpdate item)
        {
            Itens = Itens.Select(a =>
            {
                if (item.Id == a.Id)
                    return new TabelaCombinacoes()
                    {
                        IdVeiculo = item.IdVeiculo,
                        DistanciaRodoviaPavimento = item.DistanciaRodoviaPavimento,
                        DistanciaRodoviaNaoPavimento = item.DistanciaRodoviaPavimento,
                        IdUser = item.IdUser,
                        Custo = CalcularCusto(item.IdVeiculo, item.DistanciaRodoviaPavimento, item.DistanciaRodoviaNaoPavimento, item.Carga),
                        Carga = item.Carga,
                        Id = item.Id,
                    };
                return a;
            }).ToList();
        }

        public static void Excluir(TabelaCombinacoes item)
        {
            Itens = Itens.Where(a => a.Id != item.Id).ToList();
        }

        private static double CalcularCusto(int idVeiculo, double? DistanciaRodoviaPavimento, double? DistanciaRodoviaNaoPavimento, double Carga)
        {
            double custo = 0;
            double distanciaRodada = 0;
            if (DistanciaRodoviaPavimento.HasValue)
            {
                custo = DistanciaRodoviaPavimento.Value * 0.63;
                distanciaRodada += DistanciaRodoviaPavimento.Value;
            }
            if (DistanciaRodoviaNaoPavimento.HasValue)
            {
                custo = DistanciaRodoviaNaoPavimento.Value * 0.72;
                distanciaRodada += DistanciaRodoviaNaoPavimento.Value;
            }

            var fatorMultiplicacao = FatorMultiplicacaoService.Listar().FirstOrDefault(a => a.Id == idVeiculo);
            custo = fatorMultiplicacao.Fator * custo;

            if (Carga > 5)
            {
                double cargaExedida = Carga - 5;
                custo += distanciaRodada * 0.03 * cargaExedida;
            }

            return custo;
        }
    }
}