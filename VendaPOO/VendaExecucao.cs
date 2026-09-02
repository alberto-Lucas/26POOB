using System.Collections.Generic;

namespace VendaPOO
{
    public class VendaExecucao
    {
        private List<Venda> listaVenda = new List<Venda>();

        public void Adicionar(Venda venda)
        {
            listaVenda.Add(venda);
        }

        public void Remover(Venda venda)
        {
            listaVenda.Remove(venda);
        }

        public List<Venda> ListaVendas()
        {
            return listaVenda;
        }
    }
}
