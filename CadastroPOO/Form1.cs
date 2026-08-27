using System;
using System.Windows.Forms;

namespace CadastroPOO
{
    public partial class Form1 : Form
    {
        //Instancar a classe de execução
        //Será global para ser acessada por qualquer
        //método dentro da tela
        UsuarioExecucao usuarioExecucao = 
            new UsuarioExecucao();
        public Form1()
        {
            InitializeComponent();
        }

        //Métod para atualizar a lista de cadastros na tela
        void AtualizarListaUsuario()
        {
            //Limpando a alista atual
            lstRegistros.DataSource = null;
            //Popular com os registros
            lstRegistros.DataSource =
                usuarioExecucao.ListarUsuarios();
            //Definos qual atributo será usado para exibir o cadastro
            //Digitar exatamente igual o nome do atributo
            lstRegistros.DisplayMember = "CPFNomeEmail";
        }

        //Método para adicionar novo cadastro
        void AdicionarUsuario()
        {
            //Instanciar o nosso objeto usuario
            Usuario usuario = new Usuario();
            //Mapear o objeto com as informações da tela
            usuario.CPF = txtCPF.Text;
            usuario.Nome = txtNome.Text;
            usuario.DtNascimento = dtpDtNascimento.Value;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtSenha.Text;

            //Chamar o método adicionar da classe de execução
            usuarioExecucao.Adicionar(usuario);

            //Atualizamos a tela
            AtualizarListaUsuario();

            //Limpar os campos
            txtCPF.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            dtpDtNascimento.Value = DateTime.Now;
        }

        //Método para recuperar o registro selecionado no ListBox
        Usuario RecuperarUsuarioSelecionado()
        {
            //Recuperar o registro da listBox
            //e transformação em objeto novamente
            //para isso usamos o recurso AS
            //as = converter regitro para objeto desejado
            //Quando carrega o objeto na lista
            //ele se torna do tipo Item
            //então é preciso converter de Item para Objeto 
            //novamente
            return lstRegistros.SelectedItem as Usuario;
        }

        //Método para remover o usuário selecionado da lista
        void RemoverUsuario()
        {
            //Chamar o método remover
            //da classe de execução
            //e passar o usuario selecionado via parametro
            usuarioExecucao.Remover(RecuperarUsuarioSelecionado());
            //Atualizar a lista
            AtualizarListaUsuario();
        }

        //Método para exibir os dados do usuário selecionado
        void ExibirUsuario()
        {
            //Variavel do tipo usuario
            //para armazenar o usuario selecionado
            Usuario usuario;

            //Atribuo o usuario selecionado
            usuario = RecuperarUsuarioSelecionado();

            //Mapear a tela com os dados do objeto
            txtExibeCPFNome.Text = usuario.CPFNome;
            txtExibeIdade.Text = usuario.Idade.ToString();
            txtExibeEmail.Text = usuario.Email;
            txtExibeSenha.Text = usuario.Senha;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarUsuario();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            RemoverUsuario();
        }

        private void lstRegistros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExibirUsuario();
        }
    }
}
