namespace ProvaPOO.Models
{
    //Produto herda de Fabricante
    public class Produto : Fabricante
    {
        public string CodBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public string BarrasDescricao
        {
            get
            {
                return CodBarras + " - " + Descricao;
            }
        }
    }
}
