using System.Windows.Forms;
using ProvaPOO.Models;

namespace ProvaPOO.Views
{
    //Importar a camada models e controllers
    //using NomeProjeto.Models;
    public partial class frmVisualizar : Form
    {
        //Adicionar parametro no construtor para receber o objeto a ser exebido
        public frmVisualizar(Brinquedo objeto)
        {
            InitializeComponent();
            //Chamar método para exibir os dados do objeto
            ExibirDados(objeto);
        }

        //Método para mapear a tela com o objeto recebido
        void ExibirDados(Brinquedo objeto)
        {
            txtCnpjNome.Text = objeto.CNPJNome;
            txtDescricao.Text = objeto.Descricao;
            txtCodBarras.Text = objeto.CodBarras;
            txtPreco.Text = objeto.Preco.ToString();
            txtCategoria.Text = objeto.Categoria;
            txtIdadeMinima.Text = objeto.IdadeMinima.ToString();
        }
    }
}
