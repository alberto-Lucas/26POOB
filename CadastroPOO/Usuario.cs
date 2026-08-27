namespace CadastroPOO
{
    public class Usuario : Pessoa
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public string CPFNomeEmail
        {
            get
            {
                return CPFNome + " - " + Email;
            }
        }
    }
}
