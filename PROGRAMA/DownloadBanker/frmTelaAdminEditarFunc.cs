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
    public partial class frmTelaAdminEditarFunc : Form
    {
        acessoAdmin adm = new acessoAdmin();
        acessoFunc func = new acessoFunc();
        acessoAuditoriaAdmin audiA = new acessoAuditoriaAdmin();

        public frmTelaAdminEditarFunc()
        {
            InitializeComponent();
        }

        private void txtNovoSal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void frmTelaAdminEditarFunc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTelaAdminFuncLista funclista = new frmTelaAdminFuncLista();
            funclista.Show();
            this.Hide();
        }

        private void frmTelaAdminEditarFunc_Load(object sender, EventArgs e)
        {
            func.pesquisa(acessoVariaveis.FuncionarioS.ToString());
            txtNome1.Text = func.Nome1_func;
            txtNome2.Text = func.Nome2_func;
            txtSalAtual.Text = func.Sal_func.ToString();
        }

        private void lblSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome1.Text == string.Empty || txtNovoSal.Text == string.Empty || txtSalAtual.Text == string.Empty)
            {
                MessageBox.Show("Por Favor preencha os campos vazios!!!", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (txtNome1.Text == string.Empty)
                    pctFunc.Visible = true;

                if (txtNovoSal.Text == string.Empty)
                    pctNovoSal.Visible = true;

                if (txtSalAtual.Text == string.Empty)
                    pctSalAtual.Visible = true;

            }
            else
            {
                if (txtNovoSal.Text != string.Empty)
                {
                    DialogResult i = MessageBox.Show("Deseja realmente alterar o salario de " + func.Nome1_func + " ?", "Alterar salario", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (i == DialogResult.Yes)
                    {
                        func.alterarSFunc(txtNovoSal.Text.Replace(",", "."), acessoVariaveis.FuncionarioS.ToString());

                        string acao = "EDITOU SALARIO", desc = "Administrador - " + acessoDadosLogado.Codigo.ToString();
                        string dt = DateTime.Now.ToString("dd/MM/yyyy"), hr = DateTime.Now.ToString("HH:mm:ss");
                        audiA.inserir(dt, hr, acessoDadosLogado.Codigo.ToString(), acao, desc);

                        MessageBox.Show("A alteração foi realizada com exito!!", "Alteração concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmTelaAdminFuncLista funclista = new frmTelaAdminFuncLista();
                        funclista.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Digite um novo salario!!", "Salario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtNomeFunc_TextChanged(object sender, EventArgs e)
        {
            pctFunc.Visible = false;
        }

        private void txtSalAtual_TextChanged(object sender, EventArgs e)
        {
            pctSalAtual.Visible = false;
        }

        private void txtNovoSal_TextChanged(object sender, EventArgs e)
        {
            pctNovoSal.Visible = false;
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            frmTelaAdminFuncLista TelaAdmFuncLista = new frmTelaAdminFuncLista();
            this.Hide();
            TelaAdmFuncLista.Show();
        }
    }
}
