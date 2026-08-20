using System;

namespace TestePOO
{
    //Primeira coisa ao criar uma classe
    //é deixa-la publica
    //ou seja trocar o internal por public
    public class Pessoa
    {
        //Agora é definir os atributos
        //ex: Nome, Idade, Altura, Peso...
        //Para criação usamos 4 partes
        //Nivel acesso: Public ou Private
        //Tipo de Dado: String, Int, Boolean...
        //O Nome do atributo (Começar com Maiuscula)
        //Definir o tipo de registro: Get e Set
        //Get: é recuperar a informação salva
        //Set: definir a informação do atributo

        public string Nome { get; set; }

        //Atalho para criação de atributos
        //digite prop e aperte tab
        public string CPF { get; set; }
        public DateTime DtNascimento { get; set; }

        public string GetBoasVindas()
        {
            return "Boas-Vindas, " + Nome;
        }

        //Criar um construtor personalizado
        //Ira devifinir um valor padrão ao instanciar a classe
        //O construtor possui apenas duas partes
        //o nivel de acesso q obrigatoriamente precisa ser public
        //e o nome da propria classe seguida de parenteses
        //não definimos nenhum tipo de dados
        
        public Pessoa()
        {
            //Definir um valor padrão para cada atributo
            Nome = "Desconhecido";
            CPF = "12345678901";
            DtNascimento = DateTime.Now; //Data e Hora atual
        }

        //Iremos criar uma priedade q retorno e cpf e nome
        //Ela será somente leitura, ou seja
        //tera apenas o get
        public string CpfNome
        {
            get
            {
                return CPF + " - " + Nome;
            }
        }
    }
}
