﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownloadBanker
{
    public partial class frmTelaAdminProdutos : Form
    {

        acessoProduto acessoProd = new acessoProduto();
        acessoAuditoriaAdmin audiA = new acessoAuditoriaAdmin();
        string CodProd;
        int retirarL;

        public frmTelaAdminProdutos()
        {
            InitializeComponent();
        }

        private void frmTelaAdminProdutos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gvExibirProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
           
            i = Convert.ToInt32(gvExibirProd.CurrentCell.RowIndex.ToString());

            CodProd = gvExibirProd.Rows[i].Cells[0].Value.ToString();
        }

        private void lblDeletar_Click(object sender, EventArgs e)
        {
            if (CodProd != null)
            {
                DialogResult result = MessageBox.Show("Você tem certeza que deseja desativar este produto?", "Excluir usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string acao = "DESATIVOU PRODUTO", desc = "Administrador - " + acessoDadosLogado.Codigo.ToString();
                        string dt = DateTime.Now.ToString("dd/MM/yyyy"), hr = DateTime.Now.ToString("HH:mm:ss");
                        audiA.inserir(dt, hr, acessoDadosLogado.Codigo.ToString(), acao, desc);

                        acessoProd.desativarProd(CodProd);
                        MessageBox.Show("Produto desativado com sucesso!", "Produto desativado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gvExibirProd.DataSource = acessoProd.listarTudo();
                    }
                    catch { }
                }
                else
                {

                    MessageBox.Show("A desativação do produto foi cancelada!", "Exclusão cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Selecione um produto!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPesqProd_TextChanged(object sender, EventArgs e)
        {
            acessoProd.pesquisaNomeFiltro(txtPesqProd.Text);

            gvExibirProd.DataSource = acessoProd.TabelaFiltro;
        }

        private void frmTelaAdminProdutos_Load(object sender, EventArgs e)
        {
          
            try
            {
                gvExibirProd.DataSource = acessoProd.listarTudo();

                gvExibirProd.Columns[0].HeaderText = "Codigo do Produto";
                gvExibirProd.Columns[0].Width = 100;

                gvExibirProd.Columns[1].HeaderText = "Codigo do Usuario";
                gvExibirProd.Columns[1].Width = 100;

                gvExibirProd.Columns[2].HeaderText = "Nome Produto";
                gvExibirProd.Columns[2].Width = 259;

                gvExibirProd.Columns[3].HeaderText = "Preço";
                gvExibirProd.Columns[3].Width = 100;

                gvExibirProd.Columns[7].HeaderText = "Tamanho do Produto";
                gvExibirProd.Columns[7].Width = 100;

                gvExibirProd.Columns[4].Visible = false;
                gvExibirProd.Columns[5].Visible = false;
                gvExibirProd.Columns[6].Visible = false;
            
         

                retirarL = gvExibirProd.Rows.Count;
                gvExibirProd.Rows[retirarL].Visible = false;

            }
            catch
            {

            }
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
      
                frmAdminPrincipal telaAdminPrincipal = new frmAdminPrincipal();
                this.Hide();
                telaAdminPrincipal.Show();
         
        }

        private void gvExibirProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
