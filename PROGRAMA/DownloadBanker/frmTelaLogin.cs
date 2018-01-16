using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DownloadBanker
{    
    public partial class frmTelaLogin : Form
    {
   
        acessoLogin acessarLogin = new acessoLogin();
        acessoFunc func = new acessoFunc();
        acessoAdmin admin = new acessoAdmin();
        Criptografia cripto = new Criptografia("ETEP");
        Boolean teste;

        string tipo, login, senha;

        public frmTelaLogin()
        {
            InitializeComponent();
        }

        private void frmTelaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                logar();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lblEntrar_Click(object sender, EventArgs e)
        {
            logar();
        }

        private void rdFunc_CheckedChanged(object sender, EventArgs e)
        {
            tipo = "Funcionário";
            acessoVariaveis.Tipo_user = "Funcionário";
            pctTipo.Visible = false;
            rdAdm.Checked = false;
        }

        private void rdAdm_CheckedChanged(object sender, EventArgs e)
        {
            tipo = "Administrador";
            acessoVariaveis.Tipo_user = "Administrador";
            pctTipo.Visible = false;
            rdFunc.Checked = false;
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTelaLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            pctUsuario.Visible = false;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            pctSenha.Visible = false;
        }

        public void logar()
        {
            if (tipo == null || txtLogin.Text == string.Empty || txtSenha.Text == string.Empty)
            {
                MessageBox.Show("Por favor, preencha todos os campos", "Campos vazios!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txtSenha.Text == string.Empty)
                    pctSenha.Visible = true;

                if (txtLogin.Text == string.Empty)
                    pctUsuario.Visible = true;

                if (tipo == null)
                    pctTipo.Visible = true;

            }
            else
            {
                if (tipo == "Administrador")
                {
                    login = cripto.Encrypt(txtLogin.Text);
                    senha = cripto.Encrypt(txtSenha.Text);

                    teste = acessarLogin.loginAdmin(login, senha);

                    if (acessarLogin.loginAdmin(login, senha) == false)
                    {
                        MessageBox.Show("Nenhum administrador cadastrado com este login", "Erro ao entrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (txtSenha.Text != acessarLogin.Senha_admin)
                        {
                            MessageBox.Show("A senha digitada é uma senha invalida!", "Erro ao entrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            acessoDadosLogado.Codigo = acessarLogin.Cod_admin.ToString();
                            acessoDadosLogado.Login = txtLogin.Text;
                            acessoDadosLogado.Nome = acessarLogin.Nome1_admin;
                            acessoDadosLogado.Senha = txtSenha.Text;
                            acessoDadosLogado.Tipo = "Administrador";

                            if ( 
                                admin.FirstTime(acessoDadosLogado.Codigo.ToString()) == true)             // --> Verifica a validação do primeiro acesso
                            {
                                txtLogin.Clear();
                                txtSenha.Clear();
                                MessageBox.Show("Este é o seu primeiro login, favor alterar senha.", "Primeira Vez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmMudarSenha mudSenha = new frmMudarSenha();
                                this.Hide();
                                mudSenha.ShowDialog();
                                return;
                            }

                            if (admin.checa6meses(acessoDadosLogado.Codigo.ToString()) == true)       // --> Verifica a validade da senha
                            {
                                txtLogin.Clear();
                                txtSenha.Clear();
                                MessageBox.Show("A sua senha expirou. Favor alterar senha.", "Senha Expirada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmMudarSenha mudSenha = new frmMudarSenha();
                                this.Hide();
                                mudSenha.ShowDialog();
                                return;
                            }
                            else
                            {
                                frmAdminPrincipal telaAdminPrincipal = new frmAdminPrincipal();
                                this.Hide();
                                telaAdminPrincipal.Show();
                            }

                        }
                    }
                }
                else if (tipo == "Funcionário")
                {
                    login = cripto.Encrypt(txtLogin.Text);
                    senha = cripto.Encrypt(txtSenha.Text);

                    if (acessarLogin.loginFuncionario(login, senha) == false)
                    {
                        MessageBox.Show("Nenhum funcionário cadastrado com este login", "Erro ao entrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (txtSenha.Text != acessarLogin.Senha_func)
                        {
                            MessageBox.Show("A senha digitada é uma senha invalida!", "Erro ao entrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            acessoDadosLogado.Codigo = acessarLogin.Cod_func.ToString();
                            acessoDadosLogado.Login = txtLogin.Text;
                            acessoDadosLogado.Nome = acessarLogin.Nome1_func;
                            acessoDadosLogado.Senha = txtSenha.Text;
                            acessoDadosLogado.Tipo = "Funcionário";

                            if (
                                func.FirstTime(acessoDadosLogado.Codigo.ToString()) == true)             // --> Verifica a validação do primeiro acesso
                            {
                                txtLogin.Clear();
                                txtSenha.Clear();
                                MessageBox.Show("Este é o seu primeiro login, favor alterar senha.", "Primeira Vez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmMudarSenha mudSenha = new frmMudarSenha();
                                this.Hide();
                                mudSenha.ShowDialog();
                                return;
                            }

                            if (func.checa6meses(acessoDadosLogado.Codigo.ToString()) == true)       // --> Verifica a validade da senha
                            {
                                txtLogin.Clear();
                                txtSenha.Clear();
                                MessageBox.Show("A sua senha expirou. Favor alterar senha.", "Senha Expirada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmMudarSenha mudSenha = new frmMudarSenha();
                                this.Hide();
                                mudSenha.ShowDialog();
                                return;
                            }
                            else
                            {
                                frmTelaFuncPrincipal telaFuncPrincipal = new frmTelaFuncPrincipal();
                                this.Hide();
                                telaFuncPrincipal.Show();
                            }
                        }

                    }
                }
            }
        }

        private void lnkSenhaEsqueci_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEsqueceuSenha EsquecSenha = new frmEsqueceuSenha();
            this.Hide();
            EsquecSenha.Show();
        }

        
    }
}
