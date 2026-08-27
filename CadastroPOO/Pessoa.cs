using System;

namespace CadastroPOO
{
    public class Pessoa
    {
        //Atributos
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string CPF { get; set; }

        //Propriedades
        public string CPFNome
        {
            get 
            {
                return CPF + " - " + Nome;
            }
        }

        public int Idade
        {
            get
            {
                //Calcular a idade da Pessoa
                //Combase na data atual e na data de nascimento
                //Primeiro precisamos recuperar a 
                //data e hora atual do computador
                //Now retorna a data e hora da maquina
                //OBS: Se a data ou hora da maquina
                //estiver errado a variavel estara com 
                //o valor errado
                DateTime dataAtual = DateTime.Now;

                //Agra iremos calcular a idade cheia
                //ou seja usando o ano atual - o ano de nascimento
                int idade = dataAtual.Year - DtNascimento.Year;

                //Calcular com base no mes e no dia
                if(dataAtual.Month < DtNascimento.Month ||
                    (dataAtual.Month == DtNascimento.Month &&
                    dataAtual.Day < DtNascimento.Day))
                {
                    //Caso caia na validação
                    //É preciso remover um ano da idade
                    idade--;
                }

                return idade;
            }
        }
    }
}
