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
            //Trim() remove espaços vazios
            if (!string.IsNullOrEmpty(txtCodigo.Text.Trim()))
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
            frmUsuarioCadastro frm = new frmUsuarioCadastro(0, null);
            //Validar o retorno da tela de cadastro
            //Se foi OK ou Cancel
            if (frm.ShowDialog() == DialogResult.OK)
                Pesquisar(); //Atualizar a grade com o novo cadastro
        }

        //Função para identificar o registro selecionado 
        //na grade e recuperar essa informação
        //transformando-o em objeto novamente
        //Essa rotina sera nescessaria para as ações
        //Excluir, Alterar e Visualizar
        Usuario RecuperarUsuarioSelecionado()
        {
            //Validar se possui um registro selecionado
            if(dgvRegistros.SelectedRows.Count == 0)
            {
                //Notificar o usuario do sistema
                MessageBox.Show("Nenhum registro selecionado.");
                //Retorno nullo
                return null;
            }
            else
            {
                //retorno o registro selecionado
                //o convertendo de volta para objeto
                return
                    dgvRegistros.SelectedRows[0].
                        DataBoundItem as Usuario;
            }
        }

        //Método para realizar a exclusão do registro
        void Excluir()
        {
            //Recuperar o registro selecionado
            Usuario usuario = RecuperarUsuarioSelecionado();

            //Validar se o usuario selecionado é nullo
            if(usuario != null)
            {
                //Confirmar a exclusão com o usuario
                if(MessageBox.Show(
                    "Deseja realmente excluir o registro?",
                    "Confirmação", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, 
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Só excluimos com a confirmação
                    if (controller.Excluir(usuario.Id) > 0)
                    {
                        MessageBox.Show("Registro excluito com sucesso.");
                        Pesquisar();
                    }
                    else
                        MessageBox.Show("Não foi possível excluir o registro.");
                }
            }
        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            Excluir();
        }

        private void btnAlterar_Click(object sender, System.EventArgs e)
        {
            //Abrir a tela de alteração
            frmUsuarioCadastro frm = 
                new frmUsuarioCadastro(1, RecuperarUsuarioSelecionado());
            //Validar o retorno da tela de alteraçao
            //Se foi OK ou Cancel
            if (frm.ShowDialog() == DialogResult.OK)
                Pesquisar(); //Atualizar a grade com o novo cadastro
        }

        private void btnVisualizar_Click(object sender, System.EventArgs e)
        {
            //Abrir a tela de visualização
            frmUsuarioCadastro frm = 
                new frmUsuarioCadastro(2, RecuperarUsuarioSelecionado());
            frm.ShowDialog();
        }
    }
}
