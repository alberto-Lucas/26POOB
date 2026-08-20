namespace AtividadePessoaExplicado
{
    public class Cliente : Pessoa
    {
        public string Favoritos { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public double LimiteCredito { get; set; }
        public double CreditoAtual { get; set; }
        public string HistoricaCompra { get; set; }
    }
}
