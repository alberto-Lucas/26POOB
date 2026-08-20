using System;

namespace AtividadePessoaExplicado
{
    public class Pessoa
    {
        public string Nome { get; set; } //Nome ou Nome Fantasia
        public string CpfCnpj { get; set; } //CPF ou CNPJ
        public DateTime DtNascimento { get; set; }//Nascimento
        public string TipoPessoa { get; set; } //Fisica ou Juridica
        public string Endereco { get; set; }
    }
}
