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
    public partial class frmTelaAuditoria : Form
    {
        acessoAuditoriaFunc audiF = new acessoAuditoriaFunc();
        acessoAuditoriaAdmin audiA = new acessoAuditoriaAdmin();
        acessoAuditoriaUsu audiU = new acessoAuditoriaUsu();
        int retirarL;
        string query, status;
        public frmTelaAuditoria()
        {
            InitializeComponent();
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            if(acessoDadosLogado.Tipo == "Administrador")
            {
                frmAdminPrincipal admPrincipal = new frmAdminPrincipal();
                this.Hide();
                admPrincipal.Show();
            }
            if (acessoDadosLogado.Tipo == "Funcionário")
            {
                frmTelaFuncPrincipal funcPrincipal = new frmTelaFuncPrincipal();
                this.Hide();
                funcPrincipal.Show();
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedIndex == 0)
            {
                //adm
                gvExibir.DataSource = audiA.Log();
                txtFiltro.Text = "";
                carregar("Admin");
            }
            if (cmbFiltro.SelectedIndex == 1)
            {
                //func
                gvExibir.DataSource = audiF.Log();
                txtFiltro.Text = "";
                carregar("Funcionario");
            }
            if (cmbFiltro.SelectedIndex == 2)
            {
                //usu
                gvExibir.DataSource = audiU.Log();
                txtFiltro.Text = "";
                carregar("Usuario");
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedIndex == 0)
            {
                //adm
                gvExibir.DataSource = audiA.pesqAdmin(txtFiltro.Text);//pesq like adm
                carregar("Admin");
            }
            if (cmbFiltro.SelectedIndex == 1)
            {
                //func
                gvExibir.DataSource = audiF.pesqFunc(txtFiltro.Text);//pesq like func
                carregar("Funcionario");
            }
            if (cmbFiltro.SelectedIndex == 2)
            {
                //usu
                gvExibir.DataSource = audiU.pesqUsu(txtFiltro.Text);//pesq like usu
                carregar("Usuario");
            }
        }

        private void carregar(string autor)
        {
            gvExibir.Columns[0].HeaderText = "Cod. Auditoria";
            gvExibir.Columns[0].Width = 100;
            gvExibir.Columns[1].HeaderText = "Nome " + autor;
            gvExibir.Columns[1].Width = 100;
            gvExibir.Columns[2].HeaderText = "Ação do " + autor;
            gvExibir.Columns[2].Width = 110;
            gvExibir.Columns[3].HeaderText = "Descrição";
            gvExibir.Columns[3].Width = 110;
            gvExibir.Columns[4].HeaderText = "Data";
            gvExibir.Columns[4].Width = 110;
            gvExibir.Columns[5].HeaderText = "Hora";
            gvExibir.Columns[5].Width = 110;

           
        }

        }

      
        
    }

