using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PerfilUsuario : System.Web.UI.Page
{

    Criptografia cripto = new Criptografia("ETEP");

    int numeroSorteado, qtdProdutos, qtdNumerosIguais;
    Random sequenciaProdutos = new Random();
    int[] pilhaProdutos = new int[5];


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataView dvInfoUser;

            dvInfoUser = (DataView)SqlInfoUser.Select(DataSourceSelectArguments.Empty);

            lblNomeUserPerfil.Text = cripto.Decrypt(dvInfoUser.Table.Rows[0]["nome_user"].ToString());

            if (dvInfoUser.Table.Rows[0]["status_user"].ToString() == "1")
            {
                lblStatusUser.ForeColor = System.Drawing.Color.Green;
                lblStatusUser.Text = "Ativa";
            }
            else
            {
                lblStatusUser.ForeColor = System.Drawing.Color.Red;
                lblStatusUser.Text = "Desativada";
            }
         
                if (cripto.Decrypt(dvInfoUser.Table.Rows[0]["sexo_user"].ToString()) == "F")
                {
                    imgUserPerfil.ImageUrl = "imgs/semImagemMulher.png";
                }
                if (cripto.Decrypt(dvInfoUser.Table.Rows[0]["sexo_user"].ToString()) == "M")
                {
                    imgUserPerfil.ImageUrl = "imgs/semImagemHomem.png";
                }
           

            DataView dvProdUser;

            dvProdUser = (DataView)SqlProdUser.Select(DataSourceSelectArguments.Empty);

            ImageButton1.ImageUrl = "imgs/semArquivos.png";
            LinkButton1.Text = "SEM ARQUIVO";
            ImageButton2.ImageUrl = "imgs/semArquivos.png";
            LinkButton2.Text = "SEM ARQUIVO";
            ImageButton3.ImageUrl = "imgs/semArquivos.png";
            LinkButton3.Text = "SEM ARQUIVO";
            ImageButton4.ImageUrl = "imgs/semArquivos.png";
            LinkButton4.Text = "SEM ARQUIVO";
            ImageButton5.ImageUrl = "imgs/semArquivos.png";
            LinkButton5.Text = "SEM ARQUIVO";

            if (dvProdUser.Table.Rows.Count != 0)
            {
                qtdProdutos = dvProdUser.Table.Rows.Count;
                if (qtdProdutos >= 5)
                {
                    for (int i = 0; i < 5; )
                    {
                        qtdNumerosIguais = 0;
                        numeroSorteado = sequenciaProdutos.Next(qtdProdutos);

                        for (int j = 0; j < i; j++)
                        {
                            if (numeroSorteado == pilhaProdutos[j])
                                qtdNumerosIguais++;
                        }

                        if (qtdNumerosIguais == 0)
                        {
                            pilhaProdutos[i] = numeroSorteado;
                            i++;
                        }
                    }
                }
                else
                {
                    pilhaProdutos[0] = 0;
                    pilhaProdutos[1] = 1;
                    pilhaProdutos[2] = 2;
                    pilhaProdutos[3] = 3;
                    pilhaProdutos[4] = 4;
                }
            }




            try
            {
                ImageButton1.ImageUrl = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[0]]["imagem_prod"].ToString());
                LinkButton1.Text = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[0]]["nome_prod"].ToString());
                Session["codProd1"] = dvProdUser.Table.Rows[pilhaProdutos[0]]["id_prod"].ToString();

                ImageButton2.ImageUrl = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[1]]["imagem_prod"].ToString());
                LinkButton2.Text = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[1]]["nome_prod"].ToString());
                Session["codProd2"] = dvProdUser.Table.Rows[pilhaProdutos[1]]["id_prod"].ToString();

                ImageButton3.ImageUrl = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[2]]["imagem_prod"].ToString());
                LinkButton3.Text = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[2]]["nome_prod"].ToString());
                Session["codProd3"] = dvProdUser.Table.Rows[pilhaProdutos[2]]["id_prod"].ToString();

                ImageButton4.ImageUrl = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[3]]["imagem_prod"].ToString());
                LinkButton4.Text = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[3]]["nome_prod"].ToString());
                Session["codProd4"] = dvProdUser.Table.Rows[pilhaProdutos[3]]["id_prod"].ToString();

                ImageButton5.ImageUrl = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[4]]["imagem_prod"].ToString());
                LinkButton5.Text = cripto.Decrypt(dvProdUser.Table.Rows[pilhaProdutos[4]]["nome_prod"].ToString());
                Session["codProd5"] = dvProdUser.Table.Rows[pilhaProdutos[4]]["id_prod"].ToString();
            }

            catch { }
        }
        
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["codProd1"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else{
            Session["prodEscolhido"] = Session["codProd1"];
            Response.Redirect("Produto.aspx");
        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["codProd2"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else
        {
            Session["prodEscolhido"] = Session["codProd2"];
            Response.Redirect("Produto.aspx");
        }
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["codProd3"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else
        {
            Session["prodEscolhido"] = Session["codProd3"];
            Response.Redirect("Produto.aspx");
        }
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["codProd4"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else
        {
            Session["prodEscolhido"] = Session["codProd4"];
            Response.Redirect("Produto.aspx");
        }
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["codProd5"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else
        {
            Session["prodEscolhido"] = Session["codProd5"];
            Response.Redirect("Produto.aspx");
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["codProd1"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else
        {
            Session["prodEscolhido"] = Session["codProd1"];
            Response.Redirect("Produto.aspx");
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (Session["codProd2"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else
        {
            Session["prodEscolhido"] = Session["codProd2"];
            Response.Redirect("Produto.aspx");
        }
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (Session["codProd3"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else
        {
            Session["prodEscolhido"] = Session["codProd3"];
            Response.Redirect("Produto.aspx");
        }
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        if (Session["codProd4"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else
        {
            Session["prodEscolhido"] = Session["codProd4"];
            Response.Redirect("Produto.aspx");
        }
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        if (Session["codProd5"] == null)
        {
            string semArquivo = "UIkit.notify({message : 'Sem Arquivo!!!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "loginCampos", semArquivo, true);
        }
        else
        {
            Session["prodEscolhido"] = Session["codProd5"];
            Response.Redirect("Produto.aspx");
        }
    }
}