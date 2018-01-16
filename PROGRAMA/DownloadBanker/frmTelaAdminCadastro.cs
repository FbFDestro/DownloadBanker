using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace DownloadBanker
{
    public partial class frmTelaAdminCadastro : Form
    {
        acessoAdmin adm = new acessoAdmin();
        acessoAuditoriaAdmin audiA = new acessoAuditoriaAdmin();
 
        String emailTela, cpfTela;
        DateTime dataCad, dataRecad;



        public frmTelaAdminCadastro()
        {
            InitializeComponent();
        }

        private void lblCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome1.Text == string.Empty  || txtEmail.Text == string.Empty)
            {

                MessageBox.Show("Por favor, preencha todos os campos!", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                acessoPergRespSecreta.Perg = "Sorvete favorito";
                acessoPergRespSecreta.Resp = "Chocolate";

                Random rdm = new Random();
                string Chars = "abcdefghijklmnopqrstuvwxyz1234567890@#!?";
                string lma = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string lmi = "abcdefghijklmnopqrstuvwxyz";
                string nu = "1234567890";
                string ce = "@#!?";

                string senha = Chars[rdm.Next(0, Chars.Length)].ToString().ToUpper();
                senha += lma[rdm.Next(0, lma.Length)].ToString();
                senha += nu[rdm.Next(0, nu.Length)].ToString();
                senha += ce[rdm.Next(0, ce.Length)].ToString();
                senha += lmi[rdm.Next(0, lmi.Length)].ToString();
                senha += Chars[rdm.Next(0, Chars.Length)].ToString().ToUpper();
                senha += ce[rdm.Next(0, ce.Length)].ToString();
                senha += Chars[rdm.Next(0, Chars.Length)].ToString().ToUpper();

                string login = txtNome1.Text;
                login += nu[rdm.Next(0, nu.Length)].ToString();
                login += nu[rdm.Next(0, nu.Length)].ToString();
                login += ce[rdm.Next(0, ce.Length)].ToString();

                #region CPF validação
                cpfTela = mskCPF.Text;
                if (adm.cpfPesq(cpfTela) == true)
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
                if (adm.emailPesq(emailTela) == true)
                {
                    MessageBox.Show("Email ja existente, digite outro!", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                dataCad = DateTime.Now;
                dataRecad = DateTime.Now;
                dataRecad = dataRecad.AddMonths(6);

                adm.cadastrarAdmin(login, senha , "", "", "", txtNome1.Text, txtNome2.Text, mskCPF.Text, txtEmail.Text, acessoPergRespSecreta.Perg.ToString(), acessoPergRespSecreta.Resp.ToString(), dataCad.ToString(), dataRecad.ToString(), "0", "1");

                Email.sendNewCadFunc(txtEmail.Text, txtNome1.Text, login, senha);

                MessageBox.Show("Administrador cadastrado com sucesso! \r\n Seu Login: " + login + " \r\n Sua Senha: " + senha, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmTelaLogin telaLogin = new frmTelaLogin();
                telaLogin.Show();
                this.Hide();

            }
        }
    }
}
