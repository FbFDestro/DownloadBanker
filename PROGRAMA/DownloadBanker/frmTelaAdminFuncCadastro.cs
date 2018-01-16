using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DownloadBanker
{
    public partial class frmTelaAdminFuncCadastro : Form
    {

        acessoFunc func = new acessoFunc();
        acessoCEP cep = new acessoCEP();
        Criptografia cripto = new Criptografia("ETEP");
        acessoAuditoriaAdmin audiA = new acessoAuditoriaAdmin();
        string sexo, cpf, emailTela, cpfTela, perg, resp;
        DateTime dataCad, dataRecad;
        public frmTelaAdminFuncCadastro()
        {
            InitializeComponent();
        }

        private void frmTelaAdminFuncCadastro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lnkCep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBuscaCEP tela = new frmBuscaCEP();
            tela.ShowDialog();
            if (dadosCEP.ZonaRural == "S")
                mskdCep.Text = dadosCEP.Cep;
            else
            {
                mskdCep.Text = "00.000-000";
            }

            txtNum.Text = dadosCEP.Num;
            txtComp.Text = dadosCEP.Comple;
            txtEnd.Text = dadosCEP.Rua;
        }

        private void lblCadastrar_Click(object sender, EventArgs e)
        {

            if (txtSalario.Text == string.Empty || txtNome1.Text == string.Empty || txtNome2.Text == string.Empty ||
                mskCelular.Text == string.Empty || txtEmail.Text == string.Empty || 
                mskCPF.Text == string.Empty || rdFem.Checked == false && rdMasc.Checked == false || 
                mskdCep.Text == string.Empty || txtBairro.Text == string.Empty || 
                txtEnd.Text == string.Empty || txtNum.Text == string.Empty || mskDataNasc.Text == string.Empty ||
                cmbPerg.Text == string.Empty || txtResp.Text == string.Empty)
            {
                MessageBox.Show("Por Favor preencha todos os campos!!", "Cadastrar Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (txtSalario.Text == string.Empty)
                    pctSalario.Visible = true;

                if (txtNome1.Text == string.Empty)
                    pctNome1.Visible = true;

                if (txtNome2.Text == string.Empty)
                    pctNome2.Visible = true;

                if (mskCelular.Text == string.Empty)
                    pctCelular.Visible = true;

                if (txtEmail.Text == string.Empty)
                    pctEmail.Visible = true;

                if (mskCPF.Text == string.Empty)
                    mskCPF.ForeColor = Color.Red;

                if (rdFem.Checked == false && rdMasc.Checked == false)
                    pctSexo.Visible = true;

                if (mskdCep.Text == string.Empty)
                    pctCEP.Visible = true;

                if (txtBairro.Text == string.Empty)
                    pctBairro.Visible = true;

                if (txtEnd.Text == string.Empty)
                    pctEnd.Visible = true;

                if (txtNum.Text == string.Empty)
                    pctNum.Visible = true;

                if (mskDataNasc.Text == string.Empty)
                    pctDataNasc.Visible = true;

                if (cmbPerg.Text == string.Empty)
                    pctPerg.Visible = true;

                if (txtResp.Text == string.Empty)
                    pctResp.Visible = true;
            }
            else
            {
                if (rdMasc.Checked == true)
                {
                    sexo = "M";
                }
                if (rdFem.Checked == true)
                {
                    sexo = "F";
                }

                Random rdm = new Random();
                string Chars = "abcdefghijklmnopqrstuvwxyz1234567890@#!?";
                string lma = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string lmi = "abcdefghijklmnopqrstuvwxyz";
                string nu = "1234567890";
                string ce = "@#!?";

                string login = txtNome1.Text;
                login += nu[rdm.Next(0, nu.Length)].ToString();
                login += nu[rdm.Next(0, nu.Length)].ToString();
                login += ce[rdm.Next(0, ce.Length)].ToString();

                string senha = Chars[rdm.Next(0, Chars.Length)].ToString().ToUpper();
                senha += lma[rdm.Next(0, lma.Length)].ToString();
                senha += nu[rdm.Next(0, nu.Length)].ToString();
                senha += ce[rdm.Next(0, ce.Length)].ToString();
                senha += lmi[rdm.Next(0, lmi.Length)].ToString();
                senha += Chars[rdm.Next(0, Chars.Length)].ToString().ToUpper();
                senha += ce[rdm.Next(0, ce.Length)].ToString();
                senha += Chars[rdm.Next(0, Chars.Length)].ToString().ToUpper();

                perg = cmbPerg.Text;

                resp = txtResp.Text;

                #region CPF validação
                cpfTela = mskCPF.Text;
                if (func.cpf_pesq(cpfTela) == true)
                {
                    MessageBox.Show("CPF ja existente, digite outro!", "CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                } if (!validar.ValidaCPF.IsCpf(mskCPF.Text))
                {
                    MessageBox.Show("CPF invalido, digite outro!", "CNPJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                #region Email validação
                emailTela = txtEmail.Text;

                if (!Classes.Validacao.ValidacaoEmail(emailTela))
                {
                    MessageBox.Show("Favor inserir um email valido");
                    return;
                }
                if (func.emailPesq(emailTela) == true)
                {
                    MessageBox.Show("Email ja existente, digite outro!", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                dataCad = DateTime.Now;
                dataRecad = DateTime.Now;
                dataRecad = dataRecad.AddMonths(6);

                func.cadastrarFunc(login, senha, "0", "0", "0", txtNome1.Text, txtNome2.Text, mskDataNasc.Text, dataCad.ToString(), dataRecad.ToString(), mskCelular.Text, txtEmail.Text, mskCPF.Text,
                                         sexo, mskdCep.Text, txtBairro.Text, txtEnd.Text, txtNum.Text, txtComp.Text, txtSalario.Text, perg, resp, "0", "1");

                string acao = "CADASTRO FUNCIONARIO", desc = "Administrador - " + acessoDadosLogado.Codigo.ToString(); 
                string dt = DateTime.Now.ToString("dd/MM/yyyy"), hr = DateTime.Now.ToString("HH:mm:ss");
                audiA.inserir(dt, hr, acessoDadosLogado.Codigo.ToString(), acao, desc);

                Email.sendNewCadFunc(txtEmail.Text, txtNome1.Text, login, senha);

                MessageBox.Show("Funcionário cadastrado com sucesso! \r\n Seu Login: " + login + " \r\n Sua Senha: " + senha, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmTelaAdminFuncLista frmadmf = new frmTelaAdminFuncLista();
                this.Hide();
                frmadmf.Show();
            }
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

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminPrincipal adm = new frmAdminPrincipal();
            adm.ShowDialog();
        }

        private void mskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void frmTelaAdminFuncCadastro_Load(object sender, EventArgs e)
        {

        }

        private void mskdCep_TextChanged(object sender, EventArgs e)
        {
            mskdCep.BackColor = Color.White;
            // para cep's existentes
            if (mskdCep.MaskFull == true && mskdCep.Text != "00.000-000")
            {
                if (cep.buscaEndereco(limparCEP(mskdCep.Text)) == true)
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
                if (mskdCep.Text != "  .   -" && mskdCep.Text != "00.000-000")
                {
                    if (cep.buscaEndereco(limparCEP(mskdCep.Text)) == true)
                    {
                       
                        txtEnd.Text = cep.Logradouro;
                        
                        txtBairro.Text = cep.Bairro;
                        
                        mskdCep.Text = "00.000-000";
                        dadosCEP.ZonaRural = "Z";
                    }
                    else
                    {
                        // limCep();
                    }
                }
            }
        }

        private void mskdCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
