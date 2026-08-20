using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtividadePessoaExplicado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void CadastrarCliente()
        {
            Cliente cliente = new Cliente();

            cliente.Nome = "Lucas";
            cliente.CpfCnpj = "98298";
            cliente.DtNascimento = DateTime.Now;
            cliente.TipoPessoa = "F";
            cliente.Favoritos = "Eletronicos";
            cliente.Altura = 1.63;
            cliente.Peso = 0;
            cliente.LimiteCredito = 1000;
            cliente.CreditoAtual = 200;
            cliente.HistoricaCompra = "";
            cliente.Endereco = "Olímpia";


        }
    }
}
