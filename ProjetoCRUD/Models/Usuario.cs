using System.Collections.Generic;

namespace ProjetoCRUD.Models
{
    //As classes de Model geralmente são um espelho
    //da tabela do banco de dados
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    //Criar uma nova classe para ser a coleção de objeto
    //Ou seja uma lista de objeto Usuario
    //Para isso é preciso importar a bibliteca de Lista
    //using System.Collections.Generic;
    public class UsuarioCollection : List<Usuario> { }
}
