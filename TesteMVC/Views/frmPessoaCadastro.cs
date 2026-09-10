using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMVC.Models;
using TesteMVC.Controllers;

namespace TesteMVC.Views
{
    //Primeira coisa a fazer
    //quando estamos trabalhando com programação 
    //em camada
    //importar pelo usgin
    //as camadas nescessarias
    //neste caso a camada de controle
    //e a camada de modelo
    //using TesteMVC.Models;
    //using TesteMVC.Controllers;
    public partial class frmPessoaCadastro : Form
    {
        //Criar a variavel global para a instancia
        //da camada de controle
        PessoaController pessoaController =
            new PessoaController();

        public frmPessoaCadastro()
        {
            InitializeComponent();
        }

        void AtualizarLista()
        {
            lstRegistros.DataSource = null;
            lstRegistros.DataSource =
                pessoaController.ListarPessoas();
            lstRegistros.DisplayMember = "Nome";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();

            pessoa.Nome = txtNome.Text;
            pessoa.CPF  = txtCPF.Text;

            pessoaController.Adicionar(pessoa);

            AtualizarLista();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Pessoa pessoaSelecionada;

            pessoaSelecionada = 
                lstRegistros.SelectedItem as Pessoa;

            pessoaController.Remover(pessoaSelecionada);

            AtualizarLista();
        }
    }
}
