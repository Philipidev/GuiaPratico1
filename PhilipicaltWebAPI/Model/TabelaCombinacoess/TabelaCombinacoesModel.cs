using System.Text.Json.Serialization;

namespace GuiaPratico1.Model.TabelaCombinacoess
{
    public class TabelaCombinacoesModel
    {
        public int Id { get; set; }
        public double? DistanciaRodoviaPavimento { get; set; }
        public double? DistanciaRodoviaNaoPavimento { get; set; }
        public int IdVeiculo { get; set; }
        public double Carga { get; set; }
        public double Custo { get; set; }
    }
}