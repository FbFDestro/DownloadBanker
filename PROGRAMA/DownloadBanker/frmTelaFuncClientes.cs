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
    public partial class frmTelaFuncClientes : Form
    {
        acessoUsuario acessarUsuario = new acessoUsuario();
        acessoAuditoriaFunc audiF = new acessoAuditoriaFunc();
        string CodUsu;
        int retirarL;
        public frmTelaFuncClientes()
        {
            InitializeComponent();
        }

        private void frmTelaFuncClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmTelaFuncClientes_Load(object sender, EventArgs e)
        {
            try
            {
                gvExibirClientes.DataSource = acessarUsuario.listarTudo();

                gvExibirClientes.Columns[0].HeaderText = "Código";
                gvExibirClientes.Columns[0].Width = 100;

                gvExibirClientes.Columns[3].HeaderText = "Nome Usuario";
                gvExibirClientes.Columns[3].Width = 259;

                gvExibirClientes.Columns[4].HeaderText = "Email";
                gvExibirClientes.Columns[4].Width = 200;

                gvExibirClientes.Columns[5].HeaderText = "CPF";
                gvExibirClientes.Columns[5].Width = 100;

                gvExibirClientes.Columns[1].Visible = false;
                gvExibirClientes.Columns[2].Visible = false;
                gvExibirClientes.Columns[6].Visible = false;
                gvExibirClientes.Columns[7].Visible = false;

                retirarL = gvExibirClientes.Rows.Count;
                gvExibirClientes.Rows[retirarL].Visible = false;
            }
            catch { }
        }

        private void txtPesqCli_TextChanged(object sender, EventArgs e)
        {
            acessarUsuario.pesquisaNomeFiltro(txtPesqCli.Text);

            gvExibirClientes.DataSource = acessarUsuario.TabelaFiltro;
        }

        private void gvExibirClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;

            i = Convert.ToInt32(gvExibirClientes.CurrentCell.RowIndex.ToString());

            CodUsu = gvExibirClientes.Rows[i].Cells[0].Value.ToString();

        }

        private void lblDeletar_Click(object sender, EventArgs e)
        {
            if (CodUsu != null)
            {
                DialogResult result = MessageBox.Show("Você tem certeza que deseja desativar este funcionario?", "Excluir funcionario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        acessarUsuario.desativarUser(CodUsu);



                        string acao = "DESATIVOU CLIENTE", desc = "Funcionario - " + acessoDadosLogado.Codigo.ToString();
                        string dt = DateTime.Now.ToString("dd/MM/yyyy"), hr = DateTime.Now.ToString("HH:mm:ss");
                        audiF.inserir(dt, hr, acessoDadosLogado.Codigo.ToString(), acao, desc);


                        MessageBox.Show("Funcionario desativado com sucesso!", "Funcionario desativado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gvExibirClientes.DataSource = acessarUsuario.listarTudo();
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

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            frmTelaFuncPrincipal frmTelaFuncPrincipal = new frmTelaFuncPrincipal();
            this.Hide();
            frmTelaFuncPrincipal.ShowDialog();
        }
    }
}
