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
    public partial class frmTelaAdminFuncLista : Form
    {
        acessoFunc acessarFuncionario = new acessoFunc();
        acessoAuditoriaAdmin audiA = new acessoAuditoriaAdmin();
        string CodFunc;
        int retirarL;
        public frmTelaAdminFuncLista()
        {
            InitializeComponent();
        }

        private void frmTelaAdminFuncLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            frmAdminPrincipal AdminPrincipal = new frmAdminPrincipal();
            this.Hide();
            AdminPrincipal.ShowDialog();
        }

        private void lblAdicionar_Click(object sender, EventArgs e)
        {
            frmTelaAdminFuncCadastro AdminFuncCadastro = new frmTelaAdminFuncCadastro();
            this.Hide();
            AdminFuncCadastro.ShowDialog();
        }

        private void txtPesqFunc_TextChanged(object sender, EventArgs e)
        {
            acessarFuncionario.pesq(txtPesqFunc.Text);

            gvExibirFunc.DataSource = acessarFuncionario.TabelaFiltro;
        }

        private void frmTelaAdminFuncLista_Load(object sender, EventArgs e)
        {
            try
            {
                gvExibirFunc.DataSource = acessarFuncionario.listarFunc();

                gvExibirFunc.Columns[0].HeaderText = "Codigo do Funcionário";
                gvExibirFunc.Columns[0].Width = 50;

                gvExibirFunc.Columns[6].HeaderText = "Nome";
                gvExibirFunc.Columns[6].Width = 110;

                gvExibirFunc.Columns[7].HeaderText = "Sobrenome";
                gvExibirFunc.Columns[7].Width = 150;

                gvExibirFunc.Columns[12].HeaderText = "Email";
                gvExibirFunc.Columns[12].Width = 160;

                gvExibirFunc.Columns[13].HeaderText = "CPF";
                gvExibirFunc.Columns[13].Width = 90;

                gvExibirFunc.Columns[20].HeaderText =  "Salario";
                gvExibirFunc.Columns[20].Width = 95;

                gvExibirFunc.Columns[1].Visible = false;
                gvExibirFunc.Columns[2].Visible = false;
                gvExibirFunc.Columns[3].Visible = false;
                gvExibirFunc.Columns[4].Visible = false;
                gvExibirFunc.Columns[5].Visible = false;
                gvExibirFunc.Columns[8].Visible = false;
                gvExibirFunc.Columns[9].Visible = false;
                gvExibirFunc.Columns[10].Visible = false;
                gvExibirFunc.Columns[11].Visible = false;
                gvExibirFunc.Columns[14].Visible = false;
                gvExibirFunc.Columns[15].Visible = false;
                gvExibirFunc.Columns[16].Visible = false;
                gvExibirFunc.Columns[17].Visible = false;
                gvExibirFunc.Columns[18].Visible = false;
                gvExibirFunc.Columns[19].Visible = false;
                gvExibirFunc.Columns[21].Visible = false;
                gvExibirFunc.Columns[22].Visible = false;
                gvExibirFunc.Columns[23].Visible = false;
                gvExibirFunc.Columns[24].Visible = false;

                retirarL = gvExibirFunc.Rows.Count;
                gvExibirFunc.Rows[retirarL].Visible = false;
            }
            catch {  }
        }

        private void lblDeletar_Click(object sender, EventArgs e)
        {
            if (CodFunc != null)
            {
                DialogResult result = MessageBox.Show("Você tem certeza que deseja desativar este funcionario?", "Excluir funcionario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        acessarFuncionario.desativarFunc(CodFunc);

                        string acao = "DESATIVOU FUNCIONARIO", desc = "Administrador - " + acessoDadosLogado.Codigo.ToString();
                        string dt = DateTime.Now.ToString("dd/MM/yyyy"), hr = DateTime.Now.ToString("HH:mm:ss");
                        audiA.inserir(dt, hr, acessoDadosLogado.Codigo.ToString(), acao, desc);

                        MessageBox.Show("Funcionario desativado com sucesso!", "Funcionario desativado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gvExibirFunc.DataSource = acessarFuncionario.listarFunc();
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("A desativação do funcionario foi cancelada!", "Exclusão cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionario!", "Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gvExibirFunc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;

            i = Convert.ToInt32(gvExibirFunc.CurrentCell.RowIndex.ToString());

            CodFunc = gvExibirFunc.Rows[i].Cells[0].Value.ToString();
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            acessoVariaveis.FuncionarioS = CodFunc;

            if (acessoVariaveis.FuncionarioS == null)
            {
                MessageBox.Show("Selecione um funcionário", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmTelaAdminEditarFunc AdmEditFunc = new frmTelaAdminEditarFunc();
                this.Hide();
                AdmEditFunc.ShowDialog();
            }
        }
    }
}
