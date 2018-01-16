using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownloadBanker
{
    public partial class frmTelaSplash : Form
    {

        acessoInicializações acessarInicializacoes = new acessoInicializações();
        public frmTelaSplash()
        {
            InitializeComponent();
        }

        private void tmrSplash_Tick(object sender, EventArgs e)
        {
            this.Hide();
            tmrSplash.Stop();

            if (acessarInicializacoes.verificarInicializacoes() == true)
            {
                MessageBox.Show("Esta é a primeira vez que você executa o software DownloadBanker. \r\nPor favor, cadastre um administrador!", "Primeira inicialização", MessageBoxButtons.OK, MessageBoxIcon.Information);


                frmTelaAdminCadastro telaAdminCadastro = new frmTelaAdminCadastro();
                telaAdminCadastro.ShowDialog();

                acessarInicializacoes.atualizarInicializacoes();
            }
            else
            {
                frmTelaLogin telaLogin = new frmTelaLogin();
                telaLogin.Show();
                acessarInicializacoes.atualizarInicializacoes();
            }
        }

    }
}
