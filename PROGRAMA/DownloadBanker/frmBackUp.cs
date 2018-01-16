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
    public partial class frmBackUp : Form
    {
        public frmBackUp()
        {
            InitializeComponent();
        }

       

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("c:\\DownBankerBackupTemp"))
            { }
            else
            {
                Directory.CreateDirectory("c:\\DownBankerBackupTemp");
            }
            string path = "c:\\DownBankerBackupTemp";

            MysqlBackup_Restore(path, "backup");

            //corre uma thread com o processo que faz o backup ou restore
            System.Threading.Thread.Sleep(420);

            //quando executar fara o codigo seguinte
            //exemplo do path

            //corre uma thread com o processo que faz o backup ou restore
            Thread t = new Thread(delegate() { MySqlProcess(path, "backup"); });
            t.Start();
        }


        private void btnRec_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("c:\\DownBankerBackupTemp"))
            { }
            else
            {
                Directory.CreateDirectory("c:\\DownBankerBackupTemp");
            }

            opnSelecionarBackup.InitialDirectory = Backup.Local_backup;
            opnSelecionarBackup.Filter = "SQL Files (.sql)|*.sql";
            DialogResult dr = opnSelecionarBackup.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string caminhoArq = opnSelecionarBackup.FileName.Replace("/", "\\");
                File.Copy(caminhoArq, "c:\\DownBankerBackupTemp\\restaurar.sql");
                MysqlBackup_Restore("c:\\DownBankerBackupTemp", "restore");

                //corre uma thread com o processo que faz o backup ou restore
                System.Threading.Thread.Sleep(420);
                Thread t = new Thread(delegate() { MySqlProcess("c:\\DownBankerBackupTemp", "restore"); });
                t.Start();
            }
            else
            {
                Directory.Delete("c:\\DownBankerBackupTemp");
            }
        }


        private static void MysqlBackup_Restore(string path, string type)
        {

            //Caminho onde o mysql esta instalado
            string cmd = "\"C:/Arquivos de programas/MySQL/MySQL Server 5.1/bin/";

            //create a bath file to run the script database.
            StreamWriter sw = File.CreateText(path + "\\DownBankerBackup.cmd");
            //sw.WriteLine("c:");
            sw.WriteLine("c:");
            sw.WriteLine("cd\\");
            sw.WriteLine("cd " + cmd);

            string caminhoTemporario;
            string arquivoTemporario;

            if (type == "backup")
            {
                string dt = System.DateTime.Now.ToString().Replace("/", "_").Replace(":", "-").Replace(" ", "--");
                arquivoTemporario = "DownBankerBackup" + dt;
                caminhoTemporario = path + "\\DownBankerBackup" + dt + ".sql";

                Backup.Data_backup = dt;
                //se for backup
                sw.WriteLine("mysqldump.exe -uroot -pALUNOS --databases downloadbankercripto > " + caminhoTemporario);
                sw.WriteLine("");
            }
            else
            {
                arquivoTemporario = "c:\\DownBankerBackupTemp\\restaurar.sql";
                //se for restore
                sw.WriteLine("mysql -uroot -pALUNOS < " + arquivoTemporario);
                sw.WriteLine("");
            }

            sw.Close();
        }

        private static void MySqlProcess(string Path, string tipo)
        {
            //cria o processo a correr o MySqlbackup.cmd
            Process.Start(Path + "\\DownBankerBackup.cmd");

            System.Threading.Thread.Sleep(420);
            if (tipo == "restore")
            {
                System.Threading.Thread.Sleep(420);
                File.Delete("c:\\DownBankerBackupTemp\\restaurar.sql");
                File.Delete("c:\\DownBankerBackupTemp\\DownBankerBackup.cmd");

                Directory.Delete("c:\\DownBankerBackupTemp");
            }

            System.Threading.Thread.Sleep(420);
            if (tipo == "backup")
            {
                //cria o processo a correr o MySqlbackup.cmd
                Process.Start(Path + "\\DownBankerBackup.cmd");

                string caminhoTemporario;
                string arquivoTemporario;
                string path = "c:\\DownBankerBackupTemp";
                caminhoTemporario = path + "\\DownBankerBackup" + Backup.Data_backup + ".sql";
                arquivoTemporario = "DownBankerBackup" + Backup.Data_backup;

                int count2 = 0;

                while (count2 != 1)
                {
                    try
                    {
                        File.Move(caminhoTemporario, Backup.Local_backup + arquivoTemporario + ".sql");

                        File.Delete("c:\\DownBankerBackupTemp\\restaurar.sql");
                        File.Delete("c:\\DownBankerBackupTemp\\DownBankerBackup.cmd");

                        Directory.Delete("c:\\DownBankerBackupTemp");
                        count2 = 1;
                    }
                    catch
                    {
                        count2 = 0;
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (acessoVariaveis.Tipo_user == "Funcionário")
            {
                frmTelaFuncPrincipal telaFuncPrincipal = new frmTelaFuncPrincipal();
                this.Hide();
                telaFuncPrincipal.Show();
            }
            else
            {
                frmAdminPrincipal telaAdminPrincipal = new frmAdminPrincipal();
                this.Hide();
                telaAdminPrincipal.Show();
            }
        }

    }
}
