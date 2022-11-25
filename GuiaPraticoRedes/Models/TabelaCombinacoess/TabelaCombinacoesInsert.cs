namespace GuiaPraticoRedes.Models.TabelaCombinacoess
{
    public class TabelaCombinacoesInsert
    {
        public double? DistanciaRodoviaPavimento { get; set; }
        public double? DistanciaRodoviaNaoPavimento { get; set; }
        public Guid? IdUser { get; set; }
        public int IdVeiculo { get; set; }
        public double Carga { get; set; }
    }
}