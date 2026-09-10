using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMVC.Views;

namespace TesteMVC
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
            //Aqui é definido a primeira tela
            //a ser executada
            //o Program.cs não está na mesma camada(pasta)
            //da tela frmPrincipal
            //que está na camada de apresentação
            Application.Run(new frmPrincipal());
        }
    }
}
