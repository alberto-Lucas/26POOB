using System.Windows.Forms;
using ProjetoCRUD.Controllers;
using ProjetoCRUD.Models;

namespace ProjetoCRUD.Views
{
    public partial class frmUsuarioSelecao : Form
    {
        //Importar as camadas de modelo e de controle
        //using NomeProjeto.Controllers;
        //using NomeProjeto.Models;

        //Criar a instanciar com a camada de controle
        UsuarioController controller = new UsuarioController();
        public frmUsuarioSelecao()
        {
            InitializeComponent();

            //Ao abrir a tela, ja ira pesquisar
            //A apresentar todos os registros cadastrados
            Pesquisar();
        }

        //Criar o nosso método de pesquisa
        void Pesquisar()
        {
            //Primeiro é preciso limpar a grade atual
            dgvRegistros.DataSource = null;

            //Realizar as condicionais
            //Codigo, Nome, Email ou todos se vazio
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                //No caso do GetById retorna apenas um registro
                //Então o método retorno um objeto Usuario
                //Porém a grade esperar uma fonte de dados
                //do tipo lista
                //Neste caso temos o Usuario collection
                //Então temos que adicionar o retorno na lista de usuario
                //Vincular a lista na grade
                
                //Salvo o Usuario retornado na consulta
                Usuario retorno = controller.GetById(int.Parse(txtCodigo.Text));
                //Instancia a lista de usuarios
                UsuarioCollection usuarios = new UsuarioCollection();
                //Adicionar o retorno a lista
                usuarios.Add(retorno);
                //Vinculo a lista a grade
                dgvRegistros.DataSource = usuarios;
            }                
            else
            if (!string.IsNullOrEmpty(txtNome.Text))
                dgvRegistros.DataSource =
                    controller.GetByName(txtNome.Text);
            else
            if (!string.IsNullOrEmpty(txtEmail.Text))
                dgvRegistros.DataSource =
                    controller.GetByEmail(txtEmail.Text);
            else
                dgvRegistros.DataSource = controller.GetAll();
        }

        private void btnPesquisar_Click(object sender, System.EventArgs e)
        {
            Pesquisar();
        }

        private void btnAdicionar_Click(object sender, System.EventArgs e)
        {
            //Abrir a tela de cadastro
            frmUsuarioCadastro frm = new frmUsuarioCadastro();
            //Validar o retorno da tela de cadastro
            //Se foi OK ou Cancel
            if (frm.ShowDialog() == DialogResult.OK)
                Pesquisar(); //Atualizar a grade com o novo cadastro
        }
    }
}
