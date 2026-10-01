using System.Data;
using System.Data.SqlClient;

namespace ProjetoCRUD.Services
{
    //Precisamos importar as bibliotecas do SQLSERVER
    //O SQLSERVER possui bibliotecas nativas do C#
    //então é somente importar as biblitecas
    //using System.Data;
    //using System.Data.SqlClient;
    public class DataBaseService
    {
        //Função privada que cria uma nova conexão com o BD
        private SqlConnection GetConnection()
        {
            //Variavel para armazenar a instancia da conexão
            SqlConnection connection = new SqlConnection();

            //Definir a string de conexão
            //Ou seja os dados para conectar no banco de dados
            //OBS: CUIDADO AO COMPARTILHAR ESTA STRING
            //Constituida em 3 partes
            //DataSource = Host/NomeServiço
            //Catalog = Nome do Banco
            //Autenticação = Por usuario e senha ou autenticação do windows
            //A invertida \ é um operador matematico
            //para ser considera um texto usamos duas barras juntas \\
            //Atenção ao colocar o ponto e virgula(;) do final de cada parametro
            connection.ConnectionString =
                "Data Source=.\\SQLEXPRESS;" +
                "Initial Catalog=ProjetoCRUD;" +
                "Integrated Security=SSPI;"; //Autenticação do Windows

            //Abrir a conexão com o banco de dados
            connection.Open();

            //Retorna a conexão aberta
            return connection;
        }

        //Método publicos responsavel pela execução de comando
        //no banco de dados

        //Método de execução de manutenção
        //INSERT, UPDATE e DELETE
        //Está execução retorna a quantidade de linhas afetadas
        public int ExecuteSql(SqlCommand command)
        {
            //Command é o comando a ser executado
            //INSERT, UPDATE ou DELETE
            //Realizo a conexão com o banco
            command.Connection = GetConnection();

            //Executar o comando dentro do Banco de Dados
            //NonQuery significa que não possui 
            //um retorno de select
            //Ou seja está função não realizada nenhum tipo de SELECT
            return command.ExecuteNonQuery();
        }

        //Função publica para executar comando de consulta (SELECT)
        //Retorna uma tabela de dados com todas as linhas
        //e colunas da consulta
        public DataTable GetDataTable(SqlCommand command)
        {
            //Instancia o objeto dataTable
            //que ira armazenar o resultado da consulta
            DataTable dataTable = new DataTable();

            //Vincular a conexão do banco com o comando
            command.Connection = GetConnection();

            //Instancia o objeto que ira executar a consulta
            //O objeto ira receber o comando via parametro
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            //Recuperar os dados da conexão e vincular ao dataTable
            adapter.Fill(dataTable);

            //Retornar o dataTable com o resultado do SELECT
            return dataTable;
        }
    }
}
