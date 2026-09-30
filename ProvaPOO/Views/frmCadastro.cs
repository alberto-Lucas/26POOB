using ProvaPOO.Controllers;
using ProvaPOO.Models;
using System;
using System.Windows.Forms;

namespace ProvaPOO.Views
{
    //Importar a camada models e controllers
    //using NomeProjeto.Models;
    //using NomeProjeto.Controllers;
    public partial class frmCadastro : Form
    {
        //Criar a instancia global para a camada de negocios
        private BrinquedoController _controller = new BrinquedoController();

        public frmCadastro()
        {
            InitializeComponent();
        }

        //Método para atualizar a lista de registro
        void AtualizarListaRegistros()
        {
            //Limpar a base de dados da lista
            lstRegistros.DataSource = null;
            //Consulta a lista de registros atualizada
            lstRegistros.DataSource = _controller.ListarBrinquedos();
            //Definir qual atributo ou propriedade sera usado para exibir os dados
            lstRegistros.DisplayMember = "CodBarrasDescCategoriaFabricante";
        }

        //Função para recuperar registro selecionado na lista
        //Como é um função e vai retorna um brinquedo 
        //o tipo de dados será Brinquedo
        //Sera usado para a rotina remover e visualizar
        Brinquedo RegistroSelecionado()
        {
            //Usado o as para converter o registro do tipo item para o tipo objeto
            //neste caso de tipo item para brinquedo
            return lstRegistros.SelectedItem as Brinquedo;
        }


        //Método para limpars os campos da tela
        void LimparCmapos()
        {
            txtCnpj.Clear();
            txtNome.Clear();
            txtCodBarras.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtCategoria.Clear();
            txtIdadeMinima.Clear();
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //Criar e instanciar o objeto brinquedo
            Brinquedo brinquedo = new Brinquedo();

            //Mapear o objeto com os dados da tela
            brinquedo.CNPJ = txtCnpj.Text;
            brinquedo.Nome = txtNome.Text;
            brinquedo.CodBarras = txtCodBarras.Text;
            brinquedo.Descricao = txtDescricao.Text;
            brinquedo.Preco = decimal.Parse(txtPreco.Text);
            brinquedo.Categoria = txtCategoria.Text;
            brinquedo.IdadeMinima = int.Parse(txtIdadeMinima.Text);

            //Chamar o método adicionar para salvar o objeto 
            _controller.Adicionar(brinquedo);

            AtualizarListaRegistros();

            LimparCmapos();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //Chama o método remover da camada de negocios
            //e passa o registro selecionado via aprametro
            _controller.Remover(RegistroSelecionado());

            AtualizarListaRegistros();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            //Chamar tela de visualização passando o registro a ser exibido via parametro
            frmVisualizar frm = new frmVisualizar(RegistroSelecionado());
            frm.ShowDialog();
        }
    }
}
