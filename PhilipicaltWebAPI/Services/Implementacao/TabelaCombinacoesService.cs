using GuiaPratico1.Model.TabelaCombinacoess;
using GuiaPratico1.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace GuiaPratico1.Services.Implementacao
{
    public class TabelaCombinacoesService : ITabelaCombinacoesService
    {
        private static List<TabelaCombinacoesModel> Itens = new List<TabelaCombinacoesModel>();
        private readonly IFatorMultiplicacaoService fatorMultiplicacaoService;

        public TabelaCombinacoesService(IFatorMultiplicacaoService fatorMultiplicacaoService)
        {
            this.fatorMultiplicacaoService = fatorMultiplicacaoService;
        }

        public List<TabelaCombinacoesModel> Obter() => Itens;

        public TabelaCombinacoesModel Inserir(TabelaCombinacoesInsertModel item)
        {
            //Validar se insere na lista ou se retorna o item na lista
            int ultimoId = 0;
            if (Itens.Any())
                ultimoId = Itens.Select(a => a.Id).Max();
            var novo = new TabelaCombinacoesModel()
            {
                Carga = item.Carga,
                DistanciaRodoviaNaoPavimento = item.DistanciaRodoviaPavimento,
                DistanciaRodoviaPavimento = item.DistanciaRodoviaPavimento,
                IdVeiculo = item.IdVeiculo,
            };
            novo.Id = ultimoId + 1;
            novo.Custo = CalcularCusto(item.IdVeiculo, item.DistanciaRodoviaPavimento, item.DistanciaRodoviaNaoPavimento, item.Carga);
            Itens = Itens.Append(novo).ToList();
            return novo;
        }

        public void Atualizar(TabelaCombinacoesUpdateModel item)
        {
            Itens = Itens.Select(a =>
            {
                if (item.Id == a.Id)
                    return new TabelaCombinacoesModel()
                    {
                        IdVeiculo = item.IdVeiculo,
                        DistanciaRodoviaPavimento = item.DistanciaRodoviaPavimento,
                        DistanciaRodoviaNaoPavimento = item.DistanciaRodoviaPavimento,
                        Custo = CalcularCusto(item.IdVeiculo, item.DistanciaRodoviaPavimento, item.DistanciaRodoviaNaoPavimento, item.Carga),
                        Carga = item.Carga,
                        Id = item.Id,
                    };
                return a;
            }).ToList();
        }

        public void Excluir(TabelaCombinacoesModel item)
        {
            Itens = Itens.Where(a => a.Id != item.Id).ToList();
        }

        private double CalcularCusto(int idVeiculo, double? DistanciaRodoviaPavimento, double? DistanciaRodoviaNaoPavimento, double Carga)
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

            var fatorMultiplicacao = fatorMultiplicacaoService.Obter().FirstOrDefault(a => a.Id == idVeiculo);
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