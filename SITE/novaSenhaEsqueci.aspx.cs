using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class novaSenhaEsqueci : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnMudar_Click(object sender, EventArgs e)
    {

        if (txtCpf.Text == string.Empty || txtEmail.Text == string.Empty || txtLogin.Text == string.Empty || txtNome.Text == string.Empty || txtPass.Text == string.Empty || txtPassConfirm.Text == string.Empty)
        {
            string camposLogin = "UIkit.notify({message : 'Por favor, preencha todos os campos!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", camposLogin, true);

        }
        else if (txtPass.Text != txtPassConfirm.Text)
        {
            string senhasDiferentes;

            senhasDiferentes = "UIkit.notify({message : 'As senhas não coincidem',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "senhaNod", senhasDiferentes, true);
        }
        else if (verificarForca(txtPass.Text) == 1)
        {
            string senhasPequena;

            senhasPequena = "UIkit.notify({message : 'Sua senha deve ter pelo menos 6 digitos',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "senhaNodPe", senhasPequena, true);

        }
        else
        {


            try
            {

                sqlEsqueci.SelectParameters["cpf"].DefaultValue = cripto.Encrypt(txtCpf.Text);

                DataView dv;

                dv = (DataView)sqlEsqueci.Select(DataSourceSelectArguments.Empty);

                if (dv.Table.Rows.Count == 0)
                {
                    string erroN = "UIkit.notify({message : 'Os dados não coincidem com nenhum cadastro',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginErro", erroN, true);

                }
                else
                {

                    Session["loginNE"] = cripto.Decrypt(dv.Table.Rows[0]["login_user"].ToString()).ToLower();
                    Session["nomeNE"] = cripto.Decrypt(dv.Table.Rows[0]["nome_user"].ToString()).ToLower();
                    Session["emailNE"] = cripto.Decrypt(dv.Table.Rows[0]["email_user"].ToString()).ToLower();
                    Session["cpfNE"] = cripto.Decrypt(dv.Table.Rows[0]["cpf_user"].ToString()).ToLower();

                    if (txtCpf.Text.ToLower() != Session["cpfNE"].ToString() || txtEmail.Text.ToLower() != Session["emailNE"].ToString() ||
                        txtLogin.Text.ToLower() != Session["loginNE"].ToString() ||
                        txtNome.Text.ToLower() != Session["nomeNE"].ToString())
                    {

                        string erroN = "UIkit.notify({message : 'Os dados não coincidem com nenhum cadastro',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginErro", erroN, true);


                    }
                    else
                    {
                        sqlEsqueci.UpdateParameters["novaSenha"].DefaultValue = cripto.Encrypt(txtPassConfirm.Text);
                        sqlEsqueci.UpdateParameters["cpf"].DefaultValue = cripto.Encrypt(txtCpf.Text);

                        sqlEsqueci.Update();


                        // AUDITORIA
                        sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
                        sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
                        sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
                        sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("UPDATE");
                        sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("SENHA RECUPERADA/ALTERADA");

                        sqlAud.Insert();


                        Session["novaSenhaOK"] = "S";

                        Response.Redirect("LogCad.aspx");


                    }

                }

            }
            catch
            {
                string erroNe = "UIkit.notify({message : 'Os dados não coincidem com nenhum cadastro',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginErro", erroNe, true);

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

}