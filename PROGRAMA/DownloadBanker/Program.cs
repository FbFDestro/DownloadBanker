using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace DownloadBanker
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StreamReader arq = new StreamReader(@Application.StartupPath + "\\CONFIG.txt");

            dadosConexao.Ip = arq.ReadLine();
            dadosConexao.Usu = arq.ReadLine();
            dadosConexao.Senha = arq.ReadLine();

            arq.Close();

            if (Conexao.criar_Conexao() == false)
            {
                Application.Run(new frmTesteIP());

            }
            else
            {
                Conexao2.criar_Conexao();
                Application.Run(new frmTelaSplash());
            }

           


        }
    }
}
