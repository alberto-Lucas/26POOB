using System.Collections.Generic;

namespace VendaPOO
{
    public class ProdutoExecucao
    {
        //Lista de produtos
        private List<Produto> listaProdutos = 
            new List<Produto>();

        public void Adicionar(Produto produto)
        {
            listaProdutos.Add(produto);
        }

        //objeto: recebe a pocisão em memoria da
        //informação a ser manipulada
        //Ex: objeto possui o OxF3.....
        public void Remover(Produto objeto) 
        {
            listaProdutos.Remove(objeto);
        }

        public List<Produto> ListarProdutos()
        {
            return listaProdutos;
        }

        public float TotalProdutos()
        {
            float total = 0;

            for (int i = 0; i < listaProdutos.Count; i++)
                total += listaProdutos[i].Total;

            return total;
        }
    }
}
