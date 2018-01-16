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
    public partial class frmTelaFuncEditarPerfil : Form
    {


        string sexo;
        bool lMai, lMin, num, sim, letras;
        int forca;
        acessoFunc funcionario = new acessoFunc();
        acessoCEP cep = new acessoCEP();
        Criptografia cripto = new Criptografia("ETEP");
        acessoAuditoriaFunc audiF = new acessoAuditoriaFunc();
        public frmTelaFuncEditarPerfil()
        {
            InitializeComponent();
        }

        private void frmTelaFuncEditarPerfil_FormClosed(object sender, FormClosedEventArgs e)
        {
           
                frmTelaFuncPrincipal telaFuncPrinc = new frmTelaFuncPrincipal();
                telaFuncPrinc.Show();
           
        }

        public void limCep()
        {

            txtComp.Clear();
            txtNum.Clear();
            txtEnd.Clear();
        }

        public String limparCEP(String cep)
        {
            String tmp;

            tmp = cep.Remove(2, 1);

            tmp = tmp.Remove(5, 1);

            return tmp;
        }

        

        private void mskdCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void lblSalvar_Click(object sender, EventArgs e)
        {
            if (txtSenhaAtual.Text == string.Empty || txtNome1.Text == string.Empty || txtEmail.Text == string.Empty || mskCPF.Text == string.Empty ||
                mskCep.Text == string.Empty || rdFem.Checked == false && rdMasc.Checked == false ||
                txtEnd.Text == string.Empty || txtNum.Text == string.Empty || txtBairro.Text == string.Empty ||
                mskCelular.Text == string.Empty || mskDataNasc.Text == string.Empty)
            {
                MessageBox.Show("Por Favor preencha os campos vazios!!!", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (txtNome1.Text == string.Empty)
                    pctUsuario.Visible = true;

                if (txtEmail.Text == string.Empty)
                    pctEmail.Visible = true;

                if (mskCPF.Text == string.Empty)
                    pctCPF.Visible = true;

                if (mskCep.Text == string.Empty)
                    pctCEP.Visible = true;

                if (rdFem.Checked == false && rdMasc.Checked == false)
                    pctSexo.Visible = true;

                if (txtEnd.Text == string.Empty)
                    pctEnd.Visible = true;

                if (txtNum.Text == string.Empty)
                    pctNum.Visible = true;

                if (txtSenha.Text == string.Empty)
                    pctSenha.Visible = true;

                if (txtConfirSenha.Text == string.Empty)
                    pctConfirSenha.Visible = true;

                if (txtBairro.Text == string.Empty)
                    pctBairro.Visible = true;

                if (mskCelular.Text == string.Empty)
                    pctCelular.Visible = true;

                if (mskDataNasc.Text == string.Empty)
                    pctDataNasc.Visible = true;

                if (txtSenhaAtual.Text == string.Empty)
                    pctSenhaAtual.Visible = true;
            }
            else
            {

                if (txtSenha.Text == string.Empty)
                {
                    txtSenha.Text = txtSenhaAtual.Text;
                    txtConfirSenha.Text = txtSenhaAtual.Text;
                }

                if (!letras)
                {
                    MessageBox.Show("Senha deve pelo menos moderada e conter 6 - 12 caracteres", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtSenhaAtual.Text != funcionario.Pass_func)
                {
                    MessageBox.Show("Senha atual incorreta", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lblForca.Text == "Fraca")
                {
                    MessageBox.Show("Senha deve ser pelo menos moderada", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

             
                if (txtSenha.Text == funcionario.Pass1_func || txtSenha.Text == funcionario.Pass2_func || txtSenha.Text == funcionario.Pass3_func)
                {
                    MessageBox.Show("Use uma senha nova", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    if (txtSenhaAtual.Text == acessoDadosLogado.Senha)
                    {
                        if (txtSenha.Text == txtConfirSenha.Text)
                        {
                            if (rdMasc.Checked == true)
                            {
                                sexo = "M";
                            }
                            if (rdFem.Checked == true)
                            {
                                sexo = "F";
                            }
                            try
                            {
                                string acao = "ALTEROU PERFIL", desc = "Funcionario - " + acessoDadosLogado.Codigo.ToString();
                                string dt = DateTime.Now.ToString("dd/MM/yyyy"), hr = DateTime.Now.ToString("HH:mm:ss");
                                audiF.inserir(dt, hr, acessoDadosLogado.Codigo.ToString(), acao, desc);

                                funcionario.alterar(txtLogin.Text, txtSenha.Text, txtNome1.Text, txtNome2.Text, mskDataNasc.Text, mskCelular.Text, txtEmail.Text, mskCPF.Text, sexo, mskCep.Text, txtBairro.Text, txtEnd.Text, txtNum.Text, txtComp.Text, acessoDadosLogado.Codigo);
                                acessoDadosLogado.Senha = txtSenha.Text;
                                MessageBox.Show("Dados alterados com sucesso!!!", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Close();

                            }
                            catch { MessageBox.Show("Alguma informação unica ja foi ultilizada!!", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                        }
                    }
                    else { MessageBox.Show("A Senha atual não coincide!!!", "Senhas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                }
            }
        }

        private void frmTelaFuncEditarPerfil_Load(object sender, EventArgs e)
        {
            funcionario.pesquisa(acessoDadosLogado.Codigo);
            txtLogin.Text = funcionario.Login_func;
            txtNome1.Text = funcionario.Nome1_func;
            txtNome2.Text = funcionario.Nome2_func;
            mskCelular.Text = funcionario.Tel_func;
            mskDataNasc.Text = funcionario.DataNasc_func.ToShortDateString();
            txtEmail.Text = funcionario.Email_func;
            mskCPF.Text = funcionario.Cpf_func;
            txtBairro.Text = funcionario.Bairro_func;
            if (funcionario.Sexo_func == "M")
            {
                rdMasc.Checked = true;
                rdFem.Checked = false;
            }
            if (funcionario.Sexo_func == "F")
            {
                rdFem.Checked = true;
                rdMasc.Checked = false;
            }
            mskCep.Text = funcionario.Cep_func;
            txtEnd.Text = funcionario.Logradouro_func;
            txtBairro.Text = funcionario.Bairro_func;
            txtNum.Text = funcionario.Numero_func;
            txtComp.Text = funcionario.Complemento_func;
        }

        private void mskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void mskCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            pctUsuario.Visible = false;
        }

        private void mskDataNasc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            pctDataNasc.Visible = false;
        }

        private void mskCelular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            pctCelular.Visible = false;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            pctEmail.Visible = false;
        }

        private void mskCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCPF.Visible = false;
        }

        private void mskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCep.Visible = false;
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            pctBairro.Visible = false;
        }

        private void txtEnd_TextChanged(object sender, EventArgs e)
        {
            pctEnd.Visible = false;
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            pctNum.Visible = false;
        }

        private void rdFem_CheckedChanged(object sender, EventArgs e)
        {
            pctSexo.Visible = false;
        }

        private void rdMasc_CheckedChanged(object sender, EventArgs e)
        {
            pctSexo.Visible = false;
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            pctLogin.Visible = false;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            pctSenha.Visible = false;

            if (txtSenha.Text.Length < 6)
            {
                letras = false;
            }
            else
            {
                letras = true;
                try
                {
                    for (int i = 0; i < txtSenha.Text.Length; i++)
                    {
                        if (char.IsLower(txtSenha.Text[i]))
                        {
                            lMin = true;
                        }
                        else
                        {
                            if (char.IsUpper(txtSenha.Text[i]))
                            {
                                lMai = true;
                            }
                            else
                            {
                                if (char.IsNumber(txtSenha.Text[i]))
                                {
                                    num = true;
                                }
                                else
                                {
                                    if (!char.IsWhiteSpace(txtSenha.Text[i]))
                                    {
                                        sim = true;
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }
            Forcaa();
        }



        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            lMai = lMin = num = sim = letras = false;
            forca = 0;
        }

        private void txtConfirSenha_TextChanged(object sender, EventArgs e)
        {
            pctConfirSenha.Visible = false;
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            if (acessoVariaveis.Tipo_user == "Funcionário")
            {
                frmTelaFuncPrincipal telaFuncPrincipal = new frmTelaFuncPrincipal();
                this.Hide();
                telaFuncPrincipal.Show();
            }
        }

        private void mskCep_TextChanged(object sender, EventArgs e)
        {
            mskCep.BackColor = Color.White;
            // para cep's existentes
            if (mskCep.MaskFull == true && mskCep.Text != "00.000-000")
            {
                if (cep.buscaEndereco(limparCEP(mskCep.Text)) == true)
                {
                    txtEnd.Text = cep.Logradouro;
                    txtBairro.Text = cep.Bairro;

                    dadosCEP.ZonaRural = "S";
                }
                else
                {
                    limCep();
                }
            }
            else
            {
                // para cep's de zona rural
                if (mskCep.Text != "  .   -" && mskCep.Text != "00.000-000")
                {
                    if (cep.buscaEndereco(limparCEP(mskCep.Text)) == true)
                    {

                        txtEnd.Text = cep.Logradouro;

                        txtBairro.Text = cep.Bairro;

                        mskCep.Text = "00.000-000";
                        dadosCEP.ZonaRural = "Z";
                    }
                    else
                    {
                        // limCep();
                    }
                }
            }
        
    }

        private void mskCep_KeyPress_1(object sender, KeyPressEventArgs e)
        { 
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
       
        }

        private void Forcaa()
        {
            if (!letras)
            {
                progressForca.Value = 0;
                lblForca.Text = "";
            }
            else
            {
                if (!sim && !lMai && !lMin && !num)
                {
                    progressForca.Value = 0;
                    lblForca.Text = "";
                    return;
                }

                if (sim && lMai && lMin && num)
                {
                    progressForca.Value = 100;
                    lblForca.Text = "Forte";
                    lblForca.ForeColor = Color.Green;
                    return;
                }

                if (sim)
                    forca++;
                if (num)
                    forca++;
                if (lMai)
                    forca++;
                if (lMin)
                    forca++;

                if (forca < 3)
                {
                    progressForca.Value = 33;
                    lblForca.Text = "Fraca";
                    lblForca.ForeColor = Color.Red;
                }
                else
                {
                    progressForca.Value = 66;
                    lblForca.Text = "Moderada";
                    lblForca.ForeColor = Color.Orange;
                }
            }

        }


    
}
}
