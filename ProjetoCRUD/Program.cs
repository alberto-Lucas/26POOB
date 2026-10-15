using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoCRUD.Views;

namespace ProjetoCRUD
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //A linha que chama a primeira tela a ser exibida
            //Para abrir a frmPrincipal 
            //pricisamos importar a camada Views
            //using NomeProjeto.Views;
            //Agora só definir a tela desejada
            Application.Run(new frmPrincipal());
        }
    }
}
