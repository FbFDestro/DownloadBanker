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
    public partial class frmMudarSenha : Form
    {
        public frmMudarSenha()
        {
            InitializeComponent();
        }

        bool lMai, lMin, num, sim, letras;
        int forca;
        string senha, senha1, senha2, senha3;
        DateTime data, redata;

        acessoFunc func = new acessoFunc();
        acessoAdmin adm = new acessoAdmin();

        private void txtNovaSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            lMai = lMin = num = sim = letras = false;
            forca = 0;
        }

        private void lblSalvar_Click(object sender, EventArgs e)
        {
            if (txtSenhaAtual.Text == String.Empty || txtNovaSenha.Text == string.Empty || txtConfirma.Text == string.Empty)
            {
                MessageBox.Show("Favor preencher todos os campos!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!letras)
                {
                    MessageBox.Show("Senha deve ser pelo menos moderada e conter de 6 a 12 caracteres", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtSenhaAtual.Text != senha)
                {
                    MessageBox.Show("Senha atual incorreta", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lblForca.Text == "Fraca")
                {
                    MessageBox.Show("Senha deve ser pelo menos moderada", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtNovaSenha.Text != txtConfirma.Text)
                {
                    MessageBox.Show("As senhas não conferem", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtNovaSenha.Text == senha1 || txtNovaSenha.Text == senha2 || txtNovaSenha.Text == senha3)
                {
                    MessageBox.Show("Use uma senha nova", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    data = DateTime.Now;
                    redata = DateTime.Now;
                    redata = redata.AddMonths(6);

                    if (acessoDadosLogado.Tipo == "Administrador")
                    {
                        adm.mudarSenha(txtNovaSenha.Text, senha, senha1, senha2, data.ToString(), redata.ToString(), acessoDadosLogado.Codigo.ToString());
                        MessageBox.Show("Dados alterados com sucesso", "Alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmAdminPrincipal admPrinc = new frmAdminPrincipal();
                        this.Hide();
                        admPrinc.ShowDialog();
                    }
                    if (acessoDadosLogado.Tipo == "Funcionário")
                    {
                        func.mudarSenha(txtNovaSenha.Text, senha, senha1, senha2, data.ToString(), redata.ToString(), acessoDadosLogado.Codigo.ToString());
                        MessageBox.Show("Dados alterados com sucesso", "Alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmTelaFuncPrincipal funcPrinc = new frmTelaFuncPrincipal();
                        this.Hide();
                        funcPrinc.ShowDialog();
                    }

                   
                }
            }
        }

        private void frmMudarSenha_Load(object sender, EventArgs e)
        {
            progressForca.ForeColor = Color.Red;
            txtSenhaAtual.Focus();

            if(acessoDadosLogado.Tipo == "Administrador")
            {
                if (adm.pesquisa(acessoDadosLogado.Codigo))
                {
                    senha = adm.Pass_admin;
                    senha1 = adm.Pass1_admin;
                    senha2 = adm.Pass2_admin;
                    senha3 = adm.Pass3_admin;
                    data = adm.DataCad_admin;
                    redata = adm.DataRecad_admin;
                }
            }

            if (acessoDadosLogado.Tipo == "Funcionário")
            {
                if (func.pesquisa(acessoDadosLogado.Codigo))
                {
                    senha = func.Pass_func;
                    senha1 = func.Pass1_func;
                    senha2 = func.Pass2_func;
                    senha3 = func.Pass3_func;
                    data = func.DataCad_func;
                    redata = func.DataRecad_func;
                }
            }

            
        }

        private void txtNovaSenha_TextChanged(object sender, EventArgs e)
        {

            if (txtNovaSenha.Text.Length < 6)
            {
                letras = false;
            }
            else
            {
                letras = true;
                try
                {
                    for (int i = 0; i < txtNovaSenha.Text.Length; i++)
                    {
                        if (char.IsLower(txtNovaSenha.Text[i]))
                        {
                            lMin = true;
                        }
                        else
                        {
                            if (char.IsUpper(txtNovaSenha.Text[i]))
                            {
                                lMai = true;
                            }
                            else
                            {
                                if (char.IsNumber(txtNovaSenha.Text[i]))
                                {
                                    num = true;
                                }
                                else
                                {
                                    if (!char.IsWhiteSpace(txtNovaSenha.Text[i]))
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
