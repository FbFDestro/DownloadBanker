using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DownloadBanker
{
    public partial class frmTesteIP : Form
    {
        public frmTesteIP()
        {
            InitializeComponent();
        }

        private void lblConectar_Click(object sender, EventArgs e)
        {
            dadosConexao.Ip = txtIP.Text;
            dadosConexao.Usu = txtUsu.Text;
            dadosConexao.Senha = txtSenha.Text;

            File.WriteAllText(@Application.StartupPath + "\\CONFIG.txt", String.Empty);


            StreamWriter arq = new StreamWriter(@Application.StartupPath + "\\CONFIG.txt", true, Encoding.ASCII);

            arq.WriteLine(dadosConexao.Ip);
            arq.WriteLine(dadosConexao.Usu);
            arq.WriteLine(dadosConexao.Senha);

            arq.Close();


            if (Conexao.criar_Conexao() == false)
            {

                this.Hide();
                frmTesteIP teste = new frmTesteIP();
                teste.ShowDialog();

            }
            else
            {
                Conexao2.criar_Conexao();
                this.Hide();
                frmTelaSplash testeC = new frmTelaSplash();
                testeC.ShowDialog();

            }
        }
    }
}
