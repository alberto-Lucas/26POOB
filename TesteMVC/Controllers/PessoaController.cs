using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    //Classe normal para manipulação de objeto
    //Lembrando que é preciso importar
    //as camada nescessaria para usala
    //importamos pelo Using
    //usamos o nome do projeto e o nome da pasta
    //ex: usgin TesteMVC.Models;
    //após isso conseguimos acessar o conteudo da camada
    //de modelo
    public class PessoaController
    {
        //Criar uma fonte de dados para simualr
        //uma tabela de banco de dados
        PessoaCollection tabela = new PessoaCollection();

        //Caso ja estivesse a conexão com o banco de dados
        //variamos os insert e select diretamente na tabela

        //Seguir com a implementação normal
        public void Adicionar(Pessoa pessoa)
        {
            tabela.Add(pessoa);
        }

        public void Remover(Pessoa pessoa)
        {
            tabela.Remove(pessoa);
        }

        public PessoaCollection ListarPessoas()
        {
            return tabela;
        }
    }
}
