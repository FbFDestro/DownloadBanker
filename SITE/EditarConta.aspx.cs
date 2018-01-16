using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EditarConta : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["logado"] == "S")
        {


        if (!IsPostBack)
        {

                sqlPesquisa.SelectParameters["idUser"].DefaultValue = Session["idUser"].ToString();


                try
                {
                    DataView dv;

                    dv = (DataView)sqlPesquisa.Select(DataSourceSelectArguments.Empty);


                    txtLogin.Text =cripto.Decrypt(dv.Table.Rows[0]["login_user"].ToString());
                    Session["loginAntigo"] = cripto.Decrypt(dv.Table.Rows[0]["login_user"].ToString());
                    txtNomeCompleto.Text = cripto.Decrypt(dv.Table.Rows[0]["nome_user"].ToString());
                    txtEmail.Text = cripto.Decrypt(dv.Table.Rows[0]["email_user"].ToString());
                    Session["emailAntigo"] = cripto.Decrypt(dv.Table.Rows[0]["email_user"].ToString());
                    txtCpf.Text = cripto.Decrypt(dv.Table.Rows[0]["cpf_user"].ToString());
                    Session["cpfAntigo"] = cripto.Decrypt(dv.Table.Rows[0]["cpf_user"].ToString());



                    if (cripto.Decrypt(dv.Table.Rows[0]["sexo_user"].ToString()) == "M")
                    {
                        rblSexo.Items[0].Selected = true;
                    }
                    else
                    {

                        rblSexo.Items[1].Selected = true;
                    }


                }
                catch
                {
                }

            Session["sexo"] = "N";

        }

        }
        else
        {
            Response.Redirect("LogCad.aspx");
        }

        }
    protected void EDITAR_Click(object sender, EventArgs e)
    {

        if (rblSexo.Items[0].Selected == true || rblSexo.Items[1].Selected == true)
        {
            Session["sexo"] = "S";
        }


        if (txtCpf.Text == string.Empty || txtEmail.Text == string.Empty ||
            txtLogin.Text == string.Empty || txtNomeCompleto.Text == string.Empty ||
           Session["sexo"] == "N")
        {

            string camposVazios;

            camposVazios = "UIkit.notify({message : 'Preencha todos os campos',status  : 'danger',timeout :0,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "vaziosNod", camposVazios, true);

        }
        else if (ValidarEmail(txtEmail.Text) == false)
        {

            string emailInvalido;

            emailInvalido = "UIkit.notify({message : 'Email inválido',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "emailNod", emailInvalido, true);

        }
        else
        {

            sqlLoginCheckU.SelectParameters["login"].DefaultValue = cripto.Encrypt(txtLogin.Text);
            sqlEmailCheckU.SelectParameters["email"].DefaultValue = cripto.Encrypt(txtEmail.Text);
            sqlCpfCheckU.SelectParameters["cpf"].DefaultValue = cripto.Encrypt(txtCpf.Text);

            DataView dvLoginU;
            dvLoginU = (DataView)sqlLoginCheckU.Select(DataSourceSelectArguments.Empty);

            DataView dvEmailU;
            dvEmailU = (DataView)sqlEmailCheckU.Select(DataSourceSelectArguments.Empty);

            DataView dvCpfU;
            dvCpfU = (DataView)sqlCpfCheckU.Select(DataSourceSelectArguments.Empty);

            if (dvLoginU.Table.Rows.Count == 1 && txtLogin.Text != Session["loginAntigo"].ToString())
            {
                string loginCadastrado;

                loginCadastrado = "UIkit.notify({message : 'Login já cadastrado',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "logCad", loginCadastrado, true);



            }
            else if (dvEmailU.Table.Rows.Count == 1 && txtEmail.Text != Session["emailAntigo"].ToString())
            {

                string emailCadastrado;

                emailCadastrado = "UIkit.notify({message : 'Email já cadastrado',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "emailCad", emailCadastrado, true);


            }
            else if (dvCpfU.Table.Rows.Count == 1 && txtCpf.Text != Session["cpfAntigo"].ToString())
            {
                string cpfCadastrado;

                cpfCadastrado = "UIkit.notify({message : 'CPF já cadastrado',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "cpfCad", cpfCadastrado, true);

            }
            else if (CPF.Validar(txtCpf.Text) == false)
            {
                string cpfIn;

                cpfIn = "UIkit.notify({message : 'CPF inválido!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "cpf", cpfIn, true);

            }

            else
            {
                try
                {
                    sqlAlterarDados.UpdateParameters["codUser"].DefaultValue = Session["idUser"].ToString();

                    sqlAlterarDados.UpdateParameters["login"].DefaultValue = cripto.Encrypt(txtLogin.Text);
                    sqlAlterarDados.UpdateParameters["nome"].DefaultValue = cripto.Encrypt(txtNomeCompleto.Text);
                    sqlAlterarDados.UpdateParameters["email"].DefaultValue = cripto.Encrypt(txtEmail.Text);
                    sqlAlterarDados.UpdateParameters["cpf"].DefaultValue = cripto.Encrypt(txtCpf.Text);
                    sqlAlterarDados.UpdateParameters["sexo"].DefaultValue = cripto.Encrypt(rblSexo.SelectedValue);

                    sqlAlterarDados.Update();


                    // AUDITORIA
                    sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
                    sqlAud.InsertParameters["hora"].DefaultValue =cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
                    sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
                    sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("UPDATE");
                    sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("CONTA ALTERADA");

                    sqlAud.Insert();


                    Session["loginAntigo"] = txtLogin.Text;
                    Session["emailAntigo"] = txtEmail.Text;
                    Session["cpfAntigo"] = txtCpf.Text;
                    Session["atualizadoAgora"] = "Sim";
                    Session["nomeCadastrado"] = txtNomeCompleto.Text;


                    string contaAlterada = "UIkit.notify({message : 'Informações alteradas com sucesso',status  : 'success',timeout :6000,pos: 'bottom-right'});";

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "sucesso", contaAlterada, true);

                }
                catch
                {

                    string cadastroErro;

                    cadastroErro = "UIkit.notify({message : 'A alteração falhou. Tente mais tarde!',status  : 'warning',timeout : 6000,pos: 'bottom-right'});";

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


    protected void btnSenhaConf_Click(object sender, EventArgs e)
    {
        if (txtPass.Text == string.Empty || txtPassAntigo.Text == string.Empty || txtPassConfirm.Text == string.Empty)
        {
            string camposVazios;

            camposVazios = "UIkit.notify({message : 'Preencha todos os campos',status  : 'danger',timeout :0,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "vaziosNod", camposVazios, true);


        }
        else if (txtPass.Text != txtPassConfirm.Text)
        {
            string senhasDiferentes;

            senhasDiferentes = "UIkit.notify({message : 'As senhas não coincidem',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "senhaNod", senhasDiferentes, true);
        }
        else if (verificarForca(txtPass.Text) == 1)
        {
            string senhasFraca;

            senhasFraca = "UIkit.notify({message : 'Sua senha é muito fraca',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "senhaNodF", senhasFraca, true);

        }
        else
        {

            try
            {               

                DataView dvS;

                dvS = (DataView)sqlAlterarSenha.Select(DataSourceSelectArguments.Empty);


                Session["senhaAntiga"] = cripto.Decrypt(dvS.Table.Rows[0]["pass_user"].ToString());

                if (Session["senhaAntiga"].ToString() == txtPassAntigo.Text)
                {

                    
                    sqlAlterarSenha.UpdateParameters["novaSenha"].DefaultValue = cripto.Encrypt(txtPass.Text);

                    sqlAlterarSenha.Update();

                    // AUDITORIA
                    sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
                    sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
                    sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
                    sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("UPDATE");
                    sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("SENHA ALTERADA");

                    sqlAud.Insert();



                    string senhaAlterada = "UIkit.notify({message : 'Senha alterada com sucesso',status  : 'success',timeout :6000,pos: 'bottom-right'});";

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "sucesso", senhaAlterada, true);

                }
                else
                {
                    string camposVazios;

                    camposVazios = "UIkit.notify({message : 'Digite a sua senha antiga corretamente',status  : 'danger',timeout :0,pos: 'bottom-right'});";

                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "vaziosNod", camposVazios, true);


                }


            }
            catch
            {

                string senhaErro = "UIkit.notify({message : 'Algum erro ocorreu. Tente mais tarde!',status  : 'warning',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "erroCad", senhaErro, true);

            }
        }
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
                return 1; // 1 SE fraca
            }
            else
            {
                return 0; // 0 SE permite cadastro

            }
        }
    }

    protected void btnExConf_Click(object sender, EventArgs e)
    {

        sqlExcluirConta.Update();


        // AUDITORIA
        sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
        sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
        sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
        sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("UPDATE");
        sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("CONTA DESATIVADA");


        sqlAud.Insert();


        Session.Abandon();

        

        Session["apagou"] = "sim";
        Response.Redirect("Default.aspx");



    }

}