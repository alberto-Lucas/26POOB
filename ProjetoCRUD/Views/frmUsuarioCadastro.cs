using System.Windows.Forms;
using ProjetoCRUD.Controllers;
using ProjetoCRUD.Models;

namespace ProjetoCRUD.Views
{
    public partial class frmUsuarioCadastro : Form
    {
        //Importar as camadas de modelo e de controle
        //using NomeProjeto.Controllers;
        //using NomeProjeto.Models;

        //Criar a instanciar com a camada de controle
        UsuarioController controller = new UsuarioController();

        public frmUsuarioCadastro()
        {
            InitializeComponent();
        }

        void Salvar()
        {
            //Maper os dados da tela em um objeto 
            //Instanciar o objeto Usuario
            Usuario usuario = new Usuario();

            //Mapear as informações
            usuario.Nome  = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtSenha.Text;

            //Executar a rotina de cadastro
            //na camada de controle
            //Ou seja, vamos chamar o método Inserir
            //e passar o objeto via parametro
            //E validar o retorno
            //0 = Falha na execução
            //1 = Cadastro realizado com sucesso
            if(controller.Inserir(usuario) > 0)
            {
                MessageBox.Show("Usuário cadastro com sucess!");

                //Retorna para a tela anterior (tela que chamou o cadastro)
                //Que deu tudo certo
                //Assim a tela que chamar o cadastro
                //Pode validar se deu tudo certo
                DialogResult = DialogResult.OK;
            }
            else
            {
                //Caso o retorno for 0 de falha
                //Notificar o usuario
                MessageBox.Show("Falha ao realizar o cadastro.");

                //Aqui não definimos o retorno da tela
                //Pois o usuário pode tentar novamente
            }
        }

        void Cancelar()
        {
            //Validar se o usuário desejar cancelar/sair da tela

            string msg = "Deseja cancelar o cadastro?";

            //Validação do usuário
            //Ou seja uma mensagem de sim ou não
            //MessageBoxButtons.YesNo define que tela tera o Botão Sim e Não
            //MessageBoxIcon.Question define o icone de interrogação
            //MessageBoxDefaultButton.Button2 defini que o segundo botão
            //será o padrão, neste o caso o botão Não
            //isso serve para caso o usuário aperte Enter sem ler a mensagem
            //Nao perca o cadastro
            //DialogResult.Yes valida se o usuario clicou em Sim
            if (MessageBox.Show(msg, "Confirmação", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) 
                    == DialogResult.Yes)
            {
                //Se o usuário clicou em Sim
                //Vamos fechar a tela e marcar que o retorno é o Cancelar
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            Salvar();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Cancelar();
        }
    }
}
