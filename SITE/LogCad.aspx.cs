using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LogCad : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            pnlEsqueci.Visible = false;
        }

        if (captcha.tentativaSenha > 2)
        {

            pnlCaptcha.Visible = true;
            btnLoginLog.Visible = false;
            txtCaptcha.Visible = true;

        }
        else
        {
            pnlCaptcha.Visible = false;
            txtCaptcha.Visible = false;
            btnLoginLog.Visible = true;



        }

        try
        {

            if (Session["novaSenhaOK"] == "S")
            {
                Session["novaSenhaOK"] = "N";

                string senhaAlt = "UIkit.notify({message : 'Senha alterada com sucesso!',status  : 'success',timeout :6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "sucesso", senhaAlt, true);

                txtLoginLog.Focus();

            }

        }
        catch { }



        if (Session["logOuCad"] != null)
        {
            if (Session["logOuCad"].ToString() == "L")
            {
                txtLoginLog.Focus();
            }
            else if (Session["logOuCad"].ToString() == "C")
            {
                txtLoginCad.Focus();
            }
            else
            {
                Session["logOuCad"] = "N";
            }
        }
    }


    protected void ValidateCaptcha(object sender, ServerValidateEventArgs e)
    {
        Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
        e.IsValid = Captcha1.UserValidated;
        if (e.IsValid)
        {
            btnLogin_Click(sender, e);
        }
        else
        {
            if (captcha.tentativaSenha != 3)
            {
                string capErro = "UIkit.notify({message : 'Por favor, digite o código captcha corretamente!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", capErro, true);
            }
            txtCaptcha.Text = "";
        }
    }

    // CAPTCHA FIM

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtLoginLog.Text == string.Empty || txtSenhaLog.Text == string.Empty)
        {
            string camposLogin = "UIkit.notify({message : 'Por favor, preencha todos os campos!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", camposLogin, true);

        }
        else
        {
            try
            {
                sqlLogin.SelectParameters["login"].DefaultValue = cripto.Encrypt(txtLoginLog.Text);
                sqlLogin.SelectParameters["senha"].DefaultValue = cripto.Encrypt(txtSenhaLog.Text);

                DataView dv;

                dv = (DataView)sqlLogin.Select(DataSourceSelectArguments.Empty);

                try
                {
                    Session["status"] = dv.Table.Rows[0]["status_user"].ToString();
                }
                catch { }

                if (dv.Table.Rows.Count == 0)
                {
                    string erroLogin = "UIkit.notify({message : 'Login ou senha incorretos',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginErro", erroLogin, true);


                    captcha.tentativaSenha += 1;


                }
                else if (Session["status"].ToString() != "1")
                {
                    string desativoLogin = "UIkit.notify({message : 'Esta conta foi desativada!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "desativoLog", desativoLogin, true);

                }
                else
                {
                    Session["idUser"] = dv.Table.Rows[0]["id_user"].ToString();
                    Session["nomeUser"] = cripto.Decrypt(dv.Table.Rows[0]["nome_user"].ToString());

                    Session["logado"] = "S";

                    Session["logadoAgora"] = "S";
                    captcha.tentativaSenha = 0;

                   
                        Response.Redirect("Default.aspx");
                  

                }
            }
            catch
            {
                string bugLogin = "UIkit.notify({message : 'O login falhou, por favor, tente mais tarde!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "bugLog", bugLogin, true);

            }
        }
    }
    protected void CADASTRAR_Click(object sender, EventArgs e)
    {

        if (rblSexoCad.Items[0].Selected == true || rblSexoCad.Items[1].Selected == true)
        {
            Session["sexo"] = "S";
        }


        if (txtCpfCad.Text == string.Empty || txtEmailCad.Text == string.Empty ||
            txtLoginCad.Text == string.Empty || txtNomeCad.Text == string.Empty ||
           txtSenhaCad.Text == string.Empty || txtConfSenhaCad.Text == string.Empty ||
           Session["sexo"] == "N")
        {

            string camposVazios;

            camposVazios = "UIkit.notify({message : 'Por favor, preencha todos os campos!',status  : 'danger',timeout :6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "vaziosNod", camposVazios, true);

        }
        else if (txtSenhaCad.Text != txtConfSenhaCad.Text)
        {
            string senhasDiferentes;

            senhasDiferentes = "UIkit.notify({message : 'As senhas não coincidem',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "senhaNod", senhasDiferentes, true);
        }
        else if (verificarForca(txtSenhaCad.Text) == 1)
        {
            string senhasPequena;

            senhasPequena = "UIkit.notify({message : 'Sua senha deve ter pelo menos 6 digitos',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "senhaNodPe", senhasPequena, true);

        }
        else if (verificarForca(txtSenhaCad.Text) == 2)
        {
            string senhasF;

            senhasF = "UIkit.notify({message : 'Sua esta muito fraca',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "senhaF", senhasF, true);

        }
        else if (ValidarEmail(txtEmailCad.Text) == false)
        {

            string emailInvalido;

            emailInvalido = "UIkit.notify({message : 'Email inválido',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "emailNod", emailInvalido, true);

        }
        else if (CPF.Validar(txtCpfCad.Text) == false)
        {
            string cpfIn;

            cpfIn = "UIkit.notify({message : 'CPF inválido!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "cpf", cpfIn, true);

        }
        else
        {
            sqlLoginCheck.SelectParameters["login"].DefaultValue = cripto.Encrypt(txtLoginCad.Text);
            sqlEmailCheck.SelectParameters["email"].DefaultValue = cripto.Encrypt(txtEmailCad.Text);
            sqlCpfCheck.SelectParameters["cpf"].DefaultValue = cripto.Encrypt(txtCpfCad.Text);

            DataView dvLogin;
            dvLogin = (DataView)sqlLoginCheck.Select(DataSourceSelectArguments.Empty);

            DataView dvEmail;
            dvEmail = (DataView)sqlEmailCheck.Select(DataSourceSelectArguments.Empty);

            DataView dvCpf;
            dvCpf = (DataView)sqlCpfCheck.Select(DataSourceSelectArguments.Empty);

            if (dvLogin.Table.Rows.Count == 1)
            {
                string loginCadastrado;

                loginCadastrado = "UIkit.notify({message : 'Login já cadastrado',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "logCad", loginCadastrado, true);

            }
            else if (dvEmail.Table.Rows.Count == 1)
            {

                string emailCadastrado;

                emailCadastrado = "UIkit.notify({message : 'Email já cadastrado',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "emailCad", emailCadastrado, true);


            }
            else if (dvCpf.Table.Rows.Count == 1)
            {
                string cpfCadastrado;

                cpfCadastrado = "UIkit.notify({message : 'CPF já cadastrado',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "cpfCad", cpfCadastrado, true);

            }

            else
            {
                try
                {


                    sqlCadastro.InsertParameters["login"].DefaultValue = cripto.Encrypt(txtLoginCad.Text);
                    sqlCadastro.InsertParameters["senha"].DefaultValue = cripto.Encrypt(txtSenhaCad.Text);
                    sqlCadastro.InsertParameters["nome"].DefaultValue = cripto.Encrypt(txtNomeCad.Text);
                    sqlCadastro.InsertParameters["email"].DefaultValue = cripto.Encrypt(txtEmailCad.Text);
                    sqlCadastro.InsertParameters["cpf"].DefaultValue = cripto.Encrypt(txtCpfCad.Text);
                    sqlCadastro.InsertParameters["sexo"].DefaultValue = cripto.Encrypt(rblSexoCad.SelectedValue);



                    sqlCadastro.Insert();




                    Session["nomeCadastrado"] = txtNomeCad.Text;


                    string cadastroEfetuado;

                    int posicaoDoEspaco = Session["nomeCadastrado"].ToString().IndexOf(" ");
                    string nome;

                    if (posicaoDoEspaco == -1)
                    {
                        nome = Session["nomeCadastrado"].ToString();
                    }
                    else
                    {
                        nome = Session["nomeCadastrado"].ToString().Substring(0, posicaoDoEspaco);
                    }

                    cadastroEfetuado = "UIkit.notify({message : 'Cadastro efetuado. Bem vindo " + nome.ToLower() + "!',status  : 'success',timeout : 6000,pos: 'bottom-right'});";

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "cadEf", cadastroEfetuado, true);

                    txtLoginLog.Text = txtLoginCad.Text;
                    txtConfSenhaCad.Text = string.Empty;
                    txtCpfCad.Text = string.Empty;
                    txtEmailCad.Text = string.Empty;
                    txtLoginCad.Text = string.Empty;
                    txtNomeCad.Text = string.Empty;
                    txtSenhaCad.Text = string.Empty;
                    rblSexoCad.Items[1].Selected = false;
                    rblSexoCad.Items[0].Selected = true;
                    txtSenhaLog.Focus();


                }
                catch
                {

                    string cadastroErro;

                    cadastroErro = "UIkit.notify({message : 'O cadastro falhou. Tente mais tarde!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "erroCad", cadastroErro, true);


                }

            }

        }

    }

    public static bool ValidarEmail(string strEmail)
    {
        string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void rblSexo_SelectedIndexChanged(object sender, EventArgs e)
    {

        Session["sexo"] = "S";

    }


    public static int verificarForca(string senha)
    {

        int qtdLetras;
        int qtdLetMai = 0, qtdLetMin = 0, qtdNum = 0, qtdCar = 0;

        qtdLetras = senha.Length;

        if (qtdLetras < 6)
        {
            return 1; // 1 SE menos 6 digitos
        }
        else
        {

            for (int i = 0; i < qtdLetras; i++)
            {
                if (char.IsLower(senha[i]))
                {
                    qtdLetMin = 1;
                }
                else
                {
                    if (char.IsUpper(senha[i]))
                    {
                        qtdLetMai = 1;
                    }
                    else
                    {
                        if (char.IsNumber(senha[i]))
                        {
                            qtdNum = 1;
                        }
                        else
                        {
                            if (!char.IsWhiteSpace(senha[i]))
                            {
                                qtdCar = 1;
                            }
                        }
                    }
                }
            }


            if (qtdCar + qtdLetMai + qtdLetMin + qtdNum <= 1)
            {
                return 2; // 1 SE fraca
            }
            else
            {
                return 0; // 0 SE permite cadastro

            }
        }
    }


    protected void lbEsqueciSenhaLog_Click(object sender, EventArgs e)
    {
        pnlEsqueci.Visible = true;
        pnlImgAnuncio.Visible = false;
    }
    protected void btnEnviarEsqueci_Click(object sender, EventArgs e)
    {
        if (txtEmailEsqueci.Text != string.Empty)
        {

            sqlEmailEsqueci.SelectParameters["email"].DefaultValue = cripto.Encrypt(txtEmailEsqueci.Text);

            DataView dvEmailEsqueci;
            dvEmailEsqueci = (DataView)sqlEmailEsqueci.Select(DataSourceSelectArguments.Empty);

            if (dvEmailEsqueci.Table.Rows.Count == 1)
            {
                try
                {
                    string nome = cripto.Decrypt(dvEmailEsqueci.Table.Rows[0]["nome_user"].ToString());
                    string url = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
                    Email.enviarEsqueciSenha(txtEmailEsqueci.Text, nome, url);

                   string emailEfetuado = "UIkit.notify({message : 'E-mail enviado!',status  : 'success',timeout : 6000,pos: 'bottom-right'});";

                   ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "cadEf", emailEfetuado, true);




                }
                catch {

                    string emErro;

                    emErro = "UIkit.notify({message : 'Algo deu errado. Tente mais tarde!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "emCad", emErro, true);

                
                }

            }
            else
            {
                string emailNCadastrado = "UIkit.notify({message : 'Nenhum usúario cadastrado com esse e-mail!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "emailCad", emailNCadastrado, true);
                txtEmailEsqueci.Text = "";
            }

        }
        else
        {
            string camposVazio = "UIkit.notify({message : 'Por favor, preencha um e-mail!',status  : 'danger',timeout :6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "vaziosNod", camposVazio, true);
        }

    }

}