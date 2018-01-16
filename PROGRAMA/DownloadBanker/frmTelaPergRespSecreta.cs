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
    public partial class frmTelaPergRespSecreta : Form
    {
        acessoFunc func = new acessoFunc();
        acessoAdmin admin = new acessoAdmin();
        public frmTelaPergRespSecreta()
        {
            InitializeComponent();
        }

        private void frmTelaPergRespSecreta_Load(object sender, EventArgs e)
        {
            
        }
        private void lblConfir_Click(object sender, EventArgs e)
        {
            if(acessoPergRespSecreta.Identi == "ft6m")
            {

            }
        }

        
    }
}
