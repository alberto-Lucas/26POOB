namespace ProvaPOO.Models
{
    public class Brinquedo : Produto
    {
        public string Categoria { get; set; }
        public int IdadeMinima { get; set; }

        public string CodBarrasDescCategoria
        {
            get
            {
                return CodBarras + " - " + Categoria;
            }
        }

        public string CodBarrasDescCategoriaFabricante
        {
            get
            {
                return CodBarrasDescCategoria + " - " + Nome ;
            }
        }
    }
}
