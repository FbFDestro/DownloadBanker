using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DownloadBanker
{
    public partial class frmTelaFuncPrincipal : Form
    {
        public frmTelaFuncPrincipal()
        {
            InitializeComponent();
        }

        private void frmTelaFuncPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            frmTelaFuncClientes cliente = new frmTelaFuncClientes();
            cliente.Show();
            this.Hide();
        }

        private void lblProdutos_Click(object sender, EventArgs e)
        {
            frmTelaFuncProdutos prod = new frmTelaFuncProdutos();
            prod.Show();
            this.Hide();
        }

        private void lblEditarPerfil_Click(object sender, EventArgs e)
        {
            frmTelaFuncEditarPerfil editperf = new frmTelaFuncEditarPerfil();
            editperf.Show();
            this.Hide();
            
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            //string path = "D:";

            //MysqlBackup_Restore(path, "backup");

            ////corre uma thread com o processo que faz o backup ou restore
            //Thread t = new Thread(delegate() { MySqlProcess(path); });
            //t.Start();
            
            frmTelaLogin login = new frmTelaLogin();
            login.Show();
            this.Hide();
        }

        private void lblGerarQRCode_Click(object sender, EventArgs e)
        {
            frmTelaGerarQRCode qr = new frmTelaGerarQRCode();
            this.Hide();
            qr.Show();
        }

        private static void MysqlBackup_Restore(string path, string type)
        {
            //Caminho onde o mysql esta instalado
            string cmd = "\"C:/Arquivos de programas/MySQL/MySQL Server 5.1/bin/";

            //create a bath file to run the script database.
            StreamWriter sw = File.CreateText(path + "\\MySqlbackup.cmd");
            //sw.WriteLine("c:");
            sw.WriteLine("c:");
            sw.WriteLine("cd\\");
            sw.WriteLine("cd " + cmd);

            if (type == "backup")
            {
                //se for backup
                sw.WriteLine("mysqldump.exe -uroot -pALUNOS --databases agencia_viagens > " + path + "\\MySqlbackup.sql\"");
            }
            else
            {
                //se for restore
                sw.WriteLine("mysql.exe -uroot -pALUNOS < \"" + path + "\\MySqlbackup.sql\"");
            }

            sw.Close();
        }

        private static void MySqlProcess(string Path)
        {
            //cria o processo a correr o MySqlbackup.cmd
            Process.Start(Path + "\\MySqlbackup.cmd");
        }

        private void lblAuditoria_Click(object sender, EventArgs e)
        {
            frmTelaAuditoria frmTelaAuditoria = new frmTelaAuditoria();
            this.Hide();
            frmTelaAuditoria.Show();
        }

        private void lblBackUp_Click(object sender, EventArgs e)
        {
            frmBackUp telaBack = new frmBackUp();
            this.Hide();
            telaBack.Show();
        }

        private void lblBackUp_Click_1(object sender, EventArgs e)
        {
            frmBackUp telaBack = new frmBackUp();
            this.Hide();
            telaBack.Show();
        }
    }
}
