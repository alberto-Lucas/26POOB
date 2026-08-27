using System.Collections.Generic;

namespace CadastroPOO
{
    public class UsuarioExecucao
    {
        //Simular uma tabela de banco de dados
        //Armazenando os cadastro apenas em memoria

        //Criar uma Lista de usuario para salvar os cadastros
        private List<Usuario> listaUsuario = 
            new List<Usuario>();

        public void Adicionar(Usuario usuario)
        {
            //Vamos adicionar o objeto na lista
            listaUsuario.Add(usuario);
        }

        public void Remover(Usuario usuario)
        {
            //Vamos adicionar o objeto na lista
            listaUsuario.Remove(usuario);
        }

        public List<Usuario> ListarUsuarios()
        {
            //Retorna todos os usuario
            //cadastrados
            return listaUsuario;
        }

        public List<Usuario> Pesquisar(string nome)
        {
            //Realizar uma consulta na lista semelhante
            //a um select com like no banco de dados
            //EX: SELECT * FROM usuario WHERE nome LIKE '%nome%'
            //Usaremos o método FindAll do tipo de dados List<>
            //para realizar esta consulta
            //--------------------------------------------------
            //Para realizar esata consulta iremos utilizar o recurso
            //lambda (=>) serve para forçar um apontamente em memoria
            //assim criamos uma variavel e filtramos os dados
            //diretamente da memoria, e será retorna apenas
            //o resultado do filtro
            //No uso de lambda é comum que a variavel é chamada de X
            //--------------------------------------------------
            //Implementar o lambda onde o X, será um objeto individual
            //da lista, e acessaremos o atributos dessejado desse objeto
            //E ja iremos retornar o resultado do filtro
            //--------------------------------------------------
            //Observação importante!
            //como o LIKE no banco de dados caso o valor do parametro
            //seja vazio irá retorna todos os cadastros

            return listaUsuario.FindAll(x => x.Nome.Contains(nome));
        }
    }
}
