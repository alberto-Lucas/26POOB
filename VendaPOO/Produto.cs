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
                    PrecoUnitario.ToString("0.00") + " = " +
                    (Quantidade * PrecoUnitario).ToString("0.00") +
                    " Desonto de: R$ " + Desconto.ToString("0.00") +
                    " Valor Total: R$: " + Total.ToString("0.00");
                
                //Ex: Mouse - 2 x 55,50 = 111,00
                //Desconto R$ 10 Valor Total R$ 101,00
            }
        }
    }
}
