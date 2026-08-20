using System;

namespace AtividadePessoaExplicado
{
    public class Fornecedor
    {
        public string RazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public float Estoque { get; set; }
        public float Desconto { get; set; }
        public float CompraMinima { get; set; }
        public DateTime DataPagamento { get; set; }
        public string RegimeTributario { get; set; }
    }
}
