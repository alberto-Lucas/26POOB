using System.Collections.Generic;

namespace TesteMVC.Models
{
    //A classe sera criada normalmente
    public class Pessoa
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
    //Criar a classe de coleção para armazenar
    //a lista de objetos Pessoa

    public class PessoaCollection : List<Pessoa>
    {

    }
}
