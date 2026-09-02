using System;
using System.Collections.Generic;

namespace VendaPOO
{
    public class Venda
    {
        public DateTime DataHora { get; set; }
        public string Vendedor { get; set; }
        public string Cliente { get; set; }
        public string FormaPagamento { get; set; }
        public float  ValorPago { get; set; }
        //A classe produto se torna o tipo de dado Produto
        //mais de um produto se torna uma lista de Produtos
        //Comparando a banco de dados
        //seria a FK da tabela
        public List<Produto> Itens { get; set; }

        //Propriedade que retorna o valor total da venda
        //a somatoria dos totais dos produtos
        public float Total
        {
            get
            {
                //Variavel auxiliar do calculo
                float total = 0;

                //Loop de todos os itens da venda
                for(int i = 0; i < Itens.Count; i++)
                    //Total do iten atual
                    total += Itens[i].Total;

                //Retorna a somatoria dos totais
                return total;
            }
        }

    }
}
