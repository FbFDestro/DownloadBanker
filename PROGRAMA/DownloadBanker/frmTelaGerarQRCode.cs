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
    public partial class frmTelaGerarQRCode : Form
    {

        acessoQR qr = new acessoQR();
        acessoAuditoriaAdmin audiA = new acessoAuditoriaAdmin();
        acessoAuditoriaFunc audiF = new acessoAuditoriaFunc();

        int idQR, controle;
        public frmTelaGerarQRCode()
        {
            InitializeComponent();
        }

        private void lblGerarC_Click(object sender, EventArgs e)
        {
            if (controle == 0)
            {
                if (txtValor.Text != string.Empty)
                {
                    Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    idQR = qr.listarCartao().Rows.Count + 1;
                    pctQRCode.Image = qrcode.Draw(idQR.ToString(), 50);
                    controle = 1;
                }
                else
                { MessageBox.Show("Por Favor insira um valor ao cartão.", "Gerar Cartão", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation); }

            }
            else { MessageBox.Show("Você ja gerou um Cartão.", "Gerar Cartão", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation); }
        }

        private void lblSalvarC_Click(object sender, EventArgs e)
        {
            if (controle == 1)
            {
                acessoDadosQR.Codigo = (qr.listarCartao().Rows.Count + 1).ToString();
                acessoDadosQR.Valor = txtValor.Text;

                qr.cadastrarCartao(txtValor.Text, "1");

                if(acessoDadosLogado.Tipo == "Administrador")
                {
                    string acao = "SALVOU QR", desc = "Administrador - " + acessoDadosLogado.Codigo.ToString();
                    string dt = DateTime.Now.ToString("dd/MM/yyyy"), hr = DateTime.Now.ToString("HH:mm:ss");
                    audiA.inserir(dt, hr, acessoDadosLogado.Codigo.ToString(), acao, desc);
                }
                else
                {
                    string acao = "SALVOU QR", desc = "Funcionario - " + acessoDadosLogado.Codigo.ToString();
                    string dt = DateTime.Now.ToString("dd/MM/yyyy"), hr = DateTime.Now.ToString("HH:mm:ss");
                    audiF.inserir(dt, hr, acessoDadosLogado.Codigo.ToString(), acao, desc);
                }
                salvarImg.salvarImgCapturada(pctQRCode.Image);

                controle = 0;
            }
            else { MessageBox.Show("É preciso gerar um Cartão antes de poder salva-lo.", "Salvar Cartão", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation); }
        }

        private void frmTelaGerarQRCode_Load(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if(acessoDadosLogado.Tipo == "Administrador")
            {
                this.Hide();
                frmAdminPrincipal adm = new frmAdminPrincipal();
                adm.ShowDialog();
            }
            if (acessoDadosLogado.Tipo == "Funcionário")
            {
                this.Hide();
                frmTelaFuncPrincipal func = new frmTelaFuncPrincipal();
                func.ShowDialog();
            }
        }
    }
}
