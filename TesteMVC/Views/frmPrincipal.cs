using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteMVC.Views
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Iremos chamar a tela de cadastro de pessoas
            //OBS: Não precisamos adicionar o using
            //da camada views, pois os formularios
            //ja estão na mesma pasta(camada)
            frmPessoaCadastro frm = new frmPessoaCadastro();
            frm.Show();
        }
    }
}
