namespace VendaPOO
{
    public class Produto
    {
        public string Descricao { get; set; }
        public float PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public float Desconto { get; set; }

        //Propriedade que retorna o total calculado
        // (quantidade x preço unitario) - desconto
        public float Total
        {
            get
            {
                return (Quantidade * PrecoUnitario) - Desconto;
            }
        }

        //Propriedade para concaternar as informações
        public string Informacao
        {
            get
            {
                return 
                    Descricao + " - " + 
                    Quantidade.ToString() + " x " +
                    PrecoUnitario.ToString() + " = " +
                    Total.ToString();
                
                //Ex: Mouse - 2 x 55,50 = 111,00
            }
        }
    }
}
