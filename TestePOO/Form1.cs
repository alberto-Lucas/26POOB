using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestePOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //Nosso primeiro é acessar o classe
            //para criar o objeto Pessoa
            //realizando um instancia
            //Dividida em 5 partes
            //Tipo de Dado: Nome da Classe
            //Nome Varial: variavel q se tornara o obejto
            //o Sinal de igual = para atribuir a instancia a variavel
            //a palavra reservada new: instanciar a classe na memoria
            //o Construtor a classe: Repete o nome da
            //classe e adiciona parenteses: Pessoa()

            Pessoa pessoa = new Pessoa();
            //Para preencher os atributos do objeto
            //é preciso utilizar o objto adicionar um ponto .
            //e selecionar o atributo desejado
            //pessoa.Nome = txtNome.Text;
            pessoa.CPF = txtCPF.Text;
            pessoa.DtNascimento = dtpDtNascimento.Value;

            //Enviamos o objeto criado via parametro
            //Semelhante a enviar um arquivo compactado por email
            ExibirDados(pessoa);
        }

        //Método que recebe o objeto e coloca as informações na tela
        void ExibirDados(Pessoa pessoa)
        {
            //Mapear o objeto para tela
            txtNomeObj.Text = pessoa.Nome;
            txtCPFObj.Text = pessoa.CPF;
            txtDtNascimentoObj.Text = 
                pessoa.DtNascimento.ToShortDateString();

            lblTexto.Text = pessoa.GetBoasVindas();

            lblTexto.Text = pessoa.CpfNome;
        }
    }
}
