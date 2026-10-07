using ProjetoCRUD.Models;
using ProjetoCRUD.Services;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoCRUD.Controllers
{
    //Classe de controle com as regra de negocios
    //para manipular o cadasrto de Usuarios

    //Importar a camda Models e Services
    //using NomeProjeto.Models;
    //using NomeProjeto.Services;

    //Importar as bibliotecas do sqlServer
    //using System.Data;
    //using System.Data.SqlClient;
    public class UsuarioController
    {
        //Variavel privada global para armazenar
        //a instancia com a camada de Serviço
        DataBaseService dataBase = new DataBaseService();

        //Desenvolver os métodos Adicionar, Atualizar, Excluir e Consultar

        //Função publica que insere na tabela usuario um novo registro
        //Os dados que serão inseraidos são passado via parametro atraves
        //de um objeto.
        //Os dados são recuperado da tela que informação pelo
        //operador do sistema
        //OBS: Utilizamos parametros para evitar SQL INJECTION
        public int Inserir(Usuario usuario)
        {
            //Criar o comando SQL que será executado
            //informar campo a campo, como executado direto no banco
            //Os parametros são determinado usando @
            //ou seja ira repitir o nome do campo com o @ antes
            string query =
                "INSERT INTO usuario (nome, email, senha) " +
                "VALUES (@nome, @email, @senha)";

            //Instanciar o nosso comando de acordo com a query
            SqlCommand command = new SqlCommand(query);

            //Definir os valores que serão colocados em cada parametro
            //Aqui ocorre a conversão de objeto para sql
            command.Parameters.AddWithValue("@nome", usuario.Nome);
            command.Parameters.AddWithValue("@email", usuario.Email);
            command.Parameters.AddWithValue("@senha", usuario.Senha);

            //Executar o comando dentro da camda de serviço
            //e retornar a qunatidade de linhas afetadas
            //0 - Não executou corretamente
            //1 - Executou com sucesso
            return dataBase.ExecuteSql(command);
        }

        //Função pulblica para atualizar o registro
        public int Alterar(Usuario usuario)
        {
            //Criar o comando SQL para o UPDATE
            string query =
                "UPDATE usuario SET " +
                "nome = @Nome, " +
                "email = @Email, " +
                "senha = @Senha " +
                "WHERE id = @Id";

            //Instanciar o comando
            SqlCommand command = new SqlCommand(query);

            //Definir os parametros
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@Id", usuario.Id);

            //Executar o comando
            return dataBase.ExecuteSql(command);
        }

        //Função publica para excluir o registro
        public int Excluir(int id)
        {
            //Criar o comando SQL para o DELETE
            string query =
                "DELETE FROM usuario " +
                "WHERE id = @Id";

            //Instancio o comando
            SqlCommand command = new SqlCommand(query);

            //Defino os parametros
            command.Parameters.AddWithValue("@Id", id);

            //Executo o comando
            return dataBase.ExecuteSql(command);
        }

        //Encerramos as funções de manutençao INSERT, UPDATE e DELETE
        //E agora vamos para as funções de consulta SELECT

        //Função public para consultar por ID
        //portante ira retornar um objeto Usuario
        public Usuario GetById(int id)
        {
            //Criar o comando SELECT
            string query =
                "SELECT * FROM usuario " +
                "WHERE id = @Id";

            //Instanciar o comando
            SqlCommand command = new SqlCommand(query);

            //Definimos os parametros
            command.Parameters.AddWithValue("@Id", id);

            //Instanciar e executar a consulta de tabela de dados]
            //Em método de consulta não usamos mais o ExecuteSql
            //Agora precisamos do GetDataTable para manipular
            //as informações retornadas
            DataTable dataTable = dataBase.GetDataTable(command);

            //Iremos converter os dados SQL em objeto Usuario

            //Validar se tivemos dados retornados
            //Validar a quantidade de linhas retornadas na consulta
            if (dataTable.Rows.Count > 0)
            {
                //Mapear o objeto Usuario

                //Instanciar o objeto usuario
                Usuario usuario = new Usuario();

                //Vamos mapear o valor retornado de cada coluna
                //para cada atributo, para isso é preciso 
                //ajustar os tipos de dados (int, string, ...)
                //Todo dados é preciso ser convertido de
                //SQL para C#
                //Colocar o mesmo nome da coluna da tabela
                usuario.Id      = (int)dataTable.Rows[0]["id"];
                usuario.Nome    = (string)dataTable.Rows[0]["nome"];
                usuario.Email   = (string)dataTable.Rows[0]["email"];
                usuario.Senha   = (string)dataTable.Rows[0]["senha"];

                //Retorno o objeto mapeado
                return usuario;
            }
            else
                return null; //retornamos um objeto null
        }
    }
}
