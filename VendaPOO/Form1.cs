using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendaPOO
{
    public partial class Form1 : Form
    {
        //Instanciar as classe de execução
        ProdutoExecucao produtoExecucao = new ProdutoExecucao();
        VendaExecucao vendaExecucao = new VendaExecucao();

        public Form1()
        {
            InitializeComponent();
        }

        //Exibir os produtos
        void AtualizarRegistros()
        {
            //Limpar a lista
            lstRegistros.DataSource = null;

            //Carregar a fonte de dados da lista
            //com a nossa lista de objeto produto
            lstRegistros.DataSource = 
                produtoExecucao.ListarProdutos();

            //Definir o atributo a ser exibido
            lstRegistros.DisplayMember = "Informacao";

            //Atualizar o valor total
            lblTotalVenda.Text = 
                "R$ " + produtoExecucao.TotalProdutos().ToString("0.00");
            //ToString("0.00") usado para aplicar uma mascara
            //Ex: o numero 5 ficaria 5.00
        }

        //Adicionar produto
        void AdicionarProduto()
        {
            //Primeiro instanciamos o objeto produto
            Produto produto = new Produto();

            //Mapeamos o objeto com as informações em tela
            produto.Descricao = txtDescricao.Text;
            produto.PrecoUnitario = float.Parse(txtPrecoUnitario.Text);
            produto.Quantidade = int.Parse(txtQuantidade.Text);
            produto.Desconto = float.Parse(txtDesconto.Text);
            //OBS: Não estamos tratando os dados informados
            //pois não é o foco no momento
            //inserir um valor errado pode gerar erros

            produtoExecucao.Adicionar(produto);

            AtualizarRegistros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarProduto();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //Recuperar o registro selecionado na listBox
            Produto produtoSelecionado;

            //AS serve para converter o registro do
            //tipo Item para Objeto Produto
            //Ou seja quando a listBox é populada
            //o Objeto é converte para o tipo Item
            //então precisamos converter de Item para Objeto
            //novamente
            produtoSelecionado = 
                lstRegistros.SelectedItem as Produto;

            //Chamar o método remover
            produtoExecucao.Remover(produtoSelecionado);

            AtualizarRegistros();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //Monta a venda
            Venda venda = new Venda();

            //Mapear os dados da venda
            venda.DataHora = DateTime.Now;
            venda.Vendedor = txtVendedor.Text;
            venda.Cliente = txtCliente.Text;
            venda.FormaPagamento = txtFormaPagamento.Text;
            venda.ValorPago = float.Parse(txtValorPago.Text);
            //Vinculamos os produtos a venda
            venda.Itens = produtoExecucao.ListarProdutos();

            //Atualiza o troco
            txtTroco.Text =
                (venda.ValorPago - venda.Total).ToString("0.00");
        }
    }
}
