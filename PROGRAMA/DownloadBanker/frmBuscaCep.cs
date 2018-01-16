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
    public partial class frmBuscaCEP : Form
    {
        acessoCEP cep = new acessoCEP();
        int nao_cep, nao_bairro;
        DataTable tb;
        String num_bairro_novo;

        public frmBuscaCEP()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void cmbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbCidades.DataSource = cep.listaCidade(cmbUF.Text);
                cmbCidades.DisplayMember = "loc_nosub";
                cmbCidades.ValueMember = "loc_nu_sequencial";
                cmbCidades.Text = "São José dos Campos";

                cmbUF.BackColor = Color.White;
            }
            catch { }
        }

        private void cmbCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBairro.DataSource = cep.listaBairro(cmbCidades.SelectedValue.ToString());
                cmbBairro.DisplayMember = "bai_no";
                cmbBairro.ValueMember = "bai_nu_sequencial";

                cmbCidades.BackColor = Color.White;
            }
            catch { }
        }

        private void frmTelaBuscaCEP_Load(object sender, EventArgs e)
        {
            cmbUF.Text = "SP";
            cmbTipoLogradouro.DataSource = cep.tipoLogradouro();
            cmbTipoLogradouro.DisplayMember = "tipologradouro";

            cmbTipoLogradouro.Text = "";
        }

        private void cmbBairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                num_bairro_novo = cmbBairro.SelectedValue.ToString();
                cmbBairro.BackColor = Color.White;
            }
            catch { }
        }
        public String limparCEP(String cep)
        {
            String tmp;

            tmp = cep.Remove(2, 1);

            tmp = tmp.Remove(5, 1);

            return tmp;
        }
        private void mskCep_TextChanged(object sender, EventArgs e)
        {
            if (mskCep.MaskFull == true)
            {
                if (cep.buscaEndereco(limparCEP(mskCep.Text)) == true && nao_cep == 1)
                {
                   // lblCepCadastrado.Visible = true;
                    lblConfirmar.Enabled = false;
                    mskCep.Clear();
                }
                else
                {
                    lblConfirmar.Enabled = true;
                   // lblCepCadastrado.Visible = false;
                }
            }
        }

        private void cmbTipoLogradouro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTipoLogradouro.BackColor = Color.White;

            if (cmbBairro.SelectedValue != null)
            {
                tb = cep.buscaCEP(cmbBairro.SelectedValue.ToString(), cmbCidades.SelectedValue.ToString(), cmbTipoLogradouro.Text);
                cmbRuas.DataSource = tb;
                cmbRuas.DisplayMember = "log_no";

                cmbRuas.Text = "";
                mskCep.Clear();

                if (tb.Rows.Count == 0)
                {
                    nao_cep = 1;
                }
            }
        }

        private void cmbRuas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nao_cep = 0;
                cep.cepEncontrado(cmbBairro.SelectedValue.ToString(), cmbCidades.SelectedValue.ToString(), cmbTipoLogradouro.Text, cmbRuas.Text);

                if (cep.Status == "S")
                {
                    dadosCEP.ZonaRural = "S";
                    mskCep.Text = cep.Cep;
                }
                else
                {
                    dadosCEP.ZonaRural = "Z";
                    dadosCEP.Cep = cep.Cep;
                    mskCep.Text = "00.000-000";
                }

                cmbRuas.BackColor = Color.White;
            }
            catch { }
        }

        private void cmbBairro_Leave(object sender, EventArgs e)
        {
            if (cep.buscarBairro(cmbUF.Text, cmbCidades.SelectedValue.ToString(), cmbBairro.Text) == false)
            {
                nao_cep = 1;
                nao_bairro = 1;
            }
            else
            {
                nao_bairro = 0;
                nao_cep = 0;
            }
        }

        private void cmbRuas_TextChanged(object sender, EventArgs e)
        {
            nao_cep = 1;
            cmbRuas.BackColor = Color.White;
        }

        private void cmbBairro_TextChanged(object sender, EventArgs e)
        {
            cmbBairro.BackColor = Color.White;
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            dadosCEP.Cep = string.Empty;
            dadosCEP.Num = string.Empty;
            dadosCEP.Comple = string.Empty;
            dadosCEP.Bairro = string.Empty;
            dadosCEP.Cidade = string.Empty;
            dadosCEP.Rua = string.Empty;
            dadosCEP.Tipo = string.Empty;
            dadosCEP.Uf = string.Empty;
            Close();
        }

        private void lblConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbUF.Text == string.Empty || cmbCidades.Text == string.Empty || cmbBairro.Text == string.Empty ||
                cmbTipoLogradouro.Text == string.Empty || cmbRuas.Text == string.Empty)
            {
                if (cmbUF.Text == string.Empty)
                    cmbUF.BackColor = Color.Red;

                if (cmbCidades.Text == string.Empty)
                    cmbCidades.BackColor = Color.Red;

                if (cmbBairro.Text == string.Empty)
                    cmbBairro.BackColor = Color.Red;

                if (cmbTipoLogradouro.Text == string.Empty)
                    cmbTipoLogradouro.BackColor = Color.Red;

                if (cmbRuas.Text == string.Empty)
                    cmbRuas.BackColor = Color.Red;

                MessageBox.Show("Favor preencher os campos em vermelho !!");
            }
            else
            {
                if (mskCep.Text != "00.000-000")
                {
                    if (chkZonaRural.Checked == true || mskCep.MaskFull == true)
                    {
                        if (nao_cep == 1)
                        {
                            if (mskCep.MaskFull == false)
                            {
                                mskCep.Text = "00.000-000";
                            }

                            // so cadastra se não existir o bairro
                            if (nao_bairro == 1)
                                cep.cadastrarBairro(cmbUF.Text, cmbCidades.SelectedValue.ToString(), cmbBairro.Text);
                            ///////////////////////////////////////

                            cep.buscarBairro(cmbUF.Text, cmbCidades.SelectedValue.ToString(), cmbBairro.Text);

                            num_bairro_novo = cep.Bai_nu_sequencial.ToString();

                            // verifica se foi selecionado zona rural
                            if (chkZonaRural.Checked == false)
                                cep.cadastrarCEP(cmbUF.Text, cmbCidades.SelectedValue.ToString(), cmbRuas.Text, cmbRuas.Text, num_bairro_novo, limparCEP(mskCep.Text), cmbTipoLogradouro.Text, "S", cmbRuas.Text);
                            else
                            {
                                cep.cadastrarCEPZonaRural(cmbUF.Text, cmbCidades.SelectedValue.ToString(), cmbRuas.Text, cmbRuas.Text, num_bairro_novo, cmbTipoLogradouro.Text, "Z", cmbRuas.Text);
                                dadosCEP.Cep = cep.buscarNumCep();
                            }

                        }

                        if (chkZonaRural.Checked == false)
                        {
                            dadosCEP.Bairro = cmbBairro.Text;
                            dadosCEP.Cep = limparCEP(mskCep.Text);
                            dadosCEP.Num = txtNum.Text;
                            dadosCEP.Comple = txtComplemento.Text;
                            dadosCEP.Cidade = cmbCidades.Text;
                            dadosCEP.Rua = cmbRuas.Text;
                            dadosCEP.Tipo = cmbTipoLogradouro.Text;
                            dadosCEP.Uf = cmbUF.Text;
                            dadosCEP.ZonaRural = "S";
                        }
                        else
                        {
                            dadosCEP.Bairro = cmbBairro.Text;
                            dadosCEP.Num = txtNum.Text;
                            dadosCEP.Comple = txtComplemento.Text;
                            dadosCEP.Cidade = cmbCidades.Text;
                            dadosCEP.Rua = cmbRuas.Text;
                            dadosCEP.Tipo = cmbTipoLogradouro.Text;
                            dadosCEP.Uf = cmbUF.Text;
                            dadosCEP.ZonaRural = "Z";
                        }

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Favor preencher o CEP ou escolher Zona Rural");
                    }
                }
                else
                {
                    mskCep.Clear();
                }
            }
        }

        private void chkZonaRural_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZonaRural.Checked == true)
            {
                mskCep.Enabled = false;
            }
            else
            {
                mskCep.Enabled = true;
            }
        }


    }
}
