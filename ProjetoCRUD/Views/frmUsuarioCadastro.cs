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

        //Para reutilizar a tela para as rotinas de 
        //Alterar e Visualizar
        //Precisamos adicionar 2 parametros na chamada tela
        //um parametro para definir o tipo ação
        //0 = Cadastrar
        //1 = Alterar
        //2 = Visualizar
        //Receber no segundo parametro o objeto do cadastro
        //a ser carregado
        //Definir as variaveis para salvar as informações
        //do parametro
        int acao;
        Usuario usuarioSelecionado;
        public frmUsuarioCadastro(
            int acaoDaTela, Usuario usuario)
        {
            InitializeComponent();

            //Carregar os parametros
            acao = acaoDaTela;
            usuarioSelecionado = usuario;

            //Personalizar a tela de acordo com a acao
            CarregarTela();
        }
        
        void CarregarTela()
        {
            //Validar a ação nescessaria
            if (acao == 0)
                this.Text = "Cadastrar Usuário";
            else
            {
                //Mapeamento do objeto para tela
                CarregarDados();

                if (acao == 1)
                    this.Text = "Alterar Usuário";
                else
                {
                    this.Text = "Visualizar Usuário";
                    //Como a ideia é só visulizar
                    //Desabilitamos os campos
                    DesabilitarCampos();
                }
            }
        }

        //Método para carregar os dados
        void CarregarDados()
        {
            //Mapear o objeto na tela
            txtCodigo.Text = usuarioSelecionado.Id.ToString();
            txtNome.Text = usuarioSelecionado.Nome;
            txtEmail.Text = usuarioSelecionado.Email;
            txtSenha.Text = usuarioSelecionado.Senha;
        }

        //Método para desabilitar os campos da tela
        void DesabilitarCampos()
        {
            //Transformar os campos de texto em somente leitura
            txtNome.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtSenha.ReadOnly = true;

            //Ocultar os campos Salvar e Cancelar
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
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

            //Vamos adicionar a opção de alterar
            //Então faremos ou o Inserir ou o Alterar
            //para isso vamos precisar armazenar o retorno
            int retorno = 0;

            if(acao == 0)
                retorno = controller.Inserir(usuario);
            else
            {
                //Carregar o Codigo do usuario no objeto
                //Nescessario para aplicar o WHERE no UPDATE
                usuario.Id = int.Parse(txtCodigo.Text);

                retorno = controller.Alterar(usuario);
            }

            if (retorno > 0)
            {
                MessageBox.Show("Usuário salvo com sucess!");

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
                MessageBox.Show("Falha ao salvar o cadastro.");

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
