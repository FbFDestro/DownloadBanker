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
    public partial class frmAdminPrincipal : Form
    {
        public frmAdminPrincipal()
        {
            InitializeComponent();
        }

        private void frmAdminPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblFunc_Click(object sender, EventArgs e)
        {
            frmTelaAdminFuncLista telaAdminFuncLista = new frmTelaAdminFuncLista();
            this.Hide();
            telaAdminFuncLista.Show();
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            frmTelaAdminClientes telaAdminClientes = new frmTelaAdminClientes();
            this.Hide();
            telaAdminClientes.Show();
        }

        private void lblProdutos_Click(object sender, EventArgs e)
        {
            frmTelaAdminProdutos telaAdminProd = new frmTelaAdminProdutos();
            this.Hide();
            telaAdminProd.Show();
        }

        private void lblEditarPerfil_Click(object sender, EventArgs e)
        {
            frmTelaAdminEditarPerfil telaEditPerfil = new frmTelaAdminEditarPerfil();
            this.Hide();
            telaEditPerfil.Show();
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
       
            frmTelaLogin login = new frmTelaLogin();
            this.Hide();
            login.Show();
        }

        private void lblAuditoria_Click(object sender, EventArgs e)
        {
            frmTelaAuditoria aud = new frmTelaAuditoria();
            this.Hide();
            aud.Show();
        }

        private void lblGerarQRCode_Click(object sender, EventArgs e)
        {
            frmTelaGerarQRCode qr = new frmTelaGerarQRCode();
            this.Hide();
            qr.Show();
        }

  
        private void lblBackUp_Click(object sender, EventArgs e)
        {
            frmBackUp telaBack = new frmBackUp();
            this.Hide();
            telaBack.Show();
        }

     
    }
}
