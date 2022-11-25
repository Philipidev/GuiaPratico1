namespace GuiaPraticoRedes.Models.TabelaCombinacoess
{
    public class TabelaCombinacoes
    {
        public int Id { get; set; }
        public Guid? IdUser { get; set; }
        public double? DistanciaRodoviaPavimento { get; set; }
        public double? DistanciaRodoviaNaoPavimento { get; set; }
        public int IdVeiculo { get; set; }
        public double Carga { get; set; }
        public double Custo { get; set; }
    }
}