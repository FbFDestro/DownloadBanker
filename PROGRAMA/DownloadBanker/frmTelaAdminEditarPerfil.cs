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
    public partial class frmTelaAdminEditarPerfil : Form
    {
        acessoAdmin admin = new acessoAdmin();
        acessoAuditoriaAdmin audiA = new acessoAuditoriaAdmin();
  
        Criptografia cripto = new Criptografia("ETEP");

        bool lMai, lMin, num, sim, letras;
        int forca;
        string senha, senha1, senha2, senha3, emailTela, cpfTela;
        public frmTelaAdminEditarPerfil()
        {
            InitializeComponent();
        }

        private void frmTelaAdminEditarPerfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmTelaAdministradorEditarP_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (acessoVariaveis.Tipo_user == "Administrador")
            {
                frmAdminPrincipal frmadminprinc = new frmAdminPrincipal();
                frmadminprinc.Show();
            }
            
        }

        

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
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
            if (acessoVariaveis.Tipo_user == "Administrador")
            {
                if (txtSenhaAtual.Text == string.Empty || txtNome1.Text == string.Empty || txtEmail.Text == string.Empty || txtLogin.Text == string.Empty)
                {
                    MessageBox.Show("Por Favor preencha os campos vazios!!!", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    if (txtSenha.Text == string.Empty)
                    {
                        txtSenha.Text = txtSenhaAtual.Text;
                        txtConfirSenha.Text = txtSenhaAtual.Text;
                    }

                    if (txtSenha.Text == txtConfirSenha.Text)
                    {
                        if (txtSenhaAtual.Text == admin.Pass_admin)
                        {
                            string acao = "ALTEROU PERFIL", desc = "Administrador - " + acessoDadosLogado.Codigo.ToString();
                            string dt = DateTime.Now.ToString("dd/MM/yyyy"), hr = DateTime.Now.ToString("HH:mm:ss");
                            audiA.inserir(dt, hr, acessoDadosLogado.Codigo.ToString(), acao, desc);

                            admin.alterar(txtLogin.Text, txtSenha.Text, txtNome1.Text, txtNome2.Text, mskCPF.Text, txtEmail.Text, acessoDadosLogado.Codigo);

                            MessageBox.Show("Dados alterados com sucesso!!!", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Hide();
                            frmAdminPrincipal adm = new frmAdminPrincipal();
                            adm.Show();
                        }
                        else { MessageBox.Show("A senha atual nao coincide!!!", "Senhas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                       
                    }
                    else
                    {
                        MessageBox.Show("As Senhas não coincidem!!!", "Senhas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }

        }

        private void pnlAdminPerfil_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTelaAdminEditarPerfil_Load(object sender, EventArgs e)
        {
           
            if (acessoVariaveis.Tipo_user == "Administrador")
            {

                admin.pesquisa(acessoDadosLogado.Codigo);
                txtNome1.Text = admin.Nome1_admin;
                txtNome2.Text = admin.Nome2_admin;
                mskCPF.Text = admin.Cpf_admin;
                txtEmail.Text = admin.Email_admin;
                txtLogin.Text = admin.Login_admin;

            }
        
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            frmAdminPrincipal TelaAdmPrincipal = new frmAdminPrincipal();
            this.Hide();
            TelaAdmPrincipal.Show();
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

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            lMai = lMin = num = sim = letras = false;
            forca = 0;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
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
    }
}
