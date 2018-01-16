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
    public partial class frmEsqueceuSenha : Form
    {
        acessoAdmin adm = new acessoAdmin();
        acessoFunc func = new acessoFunc();
        public frmEsqueceuSenha()
        {
            InitializeComponent();
        }

        private void lblEnviar_Click(object sender, EventArgs e)
        {
            if (mskCPF.Text == String.Empty || txtEmail.Text == String.Empty)
            {
                MessageBox.Show("Favor preencher todos os campos!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string nome, login, senha;
            if (func.esqueceu(txtEmail.Text, mskCPF.Text))
            {
                nome = func.Nome1_func;
                login = func.Login_func;
                senha = func.Pass_func;
                Email.sendForgotPass(txtEmail.Text, nome, login, senha);
                MessageBox.Show("Login e Senha enviados para o seu email", "Esqueceu Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmTelaLogin TelaLogin = new frmTelaLogin();
                TelaLogin.ShowDialog();
                this.Hide();

            }
            if (adm.esqueceu(txtEmail.Text, mskCPF.Text))
            {
                nome = adm.Nome1_admin;
                login = adm.Login_admin;
                senha = adm.Pass_admin;
                Email.sendForgotPass(txtEmail.Text, nome, login, senha);
                MessageBox.Show("Login e Senha enviados para o seu email", "Esqueceu Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmTelaLogin TelaLogin = new frmTelaLogin();
                TelaLogin.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Cpf ou email invalido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            frmTelaLogin login = new frmTelaLogin();
            this.Hide();
            login.Show();
        }
    }
}
