using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Produto : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["logado"] == "S")
        {

        }
        else
        {

            btnMinhasCompras.Visible = false;
        }

        if (!IsPostBack)
        {
            try
            {

                if (Request.QueryString["cod"] != null)
                {
                    Session["prodEscolhido"] = Request.QueryString["cod"];
                }


                DataView dvProduto;

                dvProduto = (DataView)SqlProduto.Select(DataSourceSelectArguments.Empty);

                if (cripto.Decrypt(dvProduto.Table.Rows[0]["imagem_prod"].ToString()) == "IMGURL")
                {
                    imgProduto.ImageUrl = "imgs/semArquivos.png";
                }
                else
                {
                    imgProduto.ImageUrl = cripto.Decrypt(dvProduto.Table.Rows[0]["imagem_prod"].ToString());
                }
                Session["idDonoProd"] = dvProduto.Table.Rows[0]["id_user"].ToString();

                lblNomeProduto.Text = cripto.Decrypt(dvProduto.Table.Rows[0]["nome_prod"].ToString());
                lblDistribuidor.Text = cripto.Decrypt(dvProduto.Table.Rows[0]["nome_user"].ToString());
                lblTamanho.Text = cripto.Decrypt(dvProduto.Table.Rows[0]["tamanho_prod"].ToString());
                lblPreco.Text = cripto.Decrypt(dvProduto.Table.Rows[0]["valor_prod"].ToString()).Replace(".", ",");
                lblSobre.Text = HttpUtility.HtmlDecode(cripto.Decrypt(dvProduto.Table.Rows[0]["sobre_prod"].ToString()));
                lblContem.Text = HttpUtility.HtmlDecode(cripto.Decrypt(dvProduto.Table.Rows[0]["contem_prod"].ToString()));

       


                    if (Session["idUser"].ToString() == Session["idDonoProd"].ToString())
                    {
                        btnComprar.Visible = false;
                        btnMinhasCompras.Visible = false;
                        btnEditar.Visible = true;

                    }
                    else
                    {
                         sqlVendido.SelectParameters["idUser"].DefaultValue = Session["idUser"].ToString();
                         sqlVendido.SelectParameters["idProd"].DefaultValue = Session["prodEscolhido"].ToString();

                         DataView dVen;
                         dVen = (DataView)sqlVendido.Select(DataSourceSelectArguments.Empty);

                         if (dVen.Table.Rows.Count != 0)
                         {
                        btnComprar.Visible = false;
                        btnEditar.Visible = false;
                        btnMinhasCompras.Visible = true;

                     } else {

                        btnComprar.Visible = true;
                        btnEditar.Visible = false;
                        btnMinhasCompras.Visible = false;
                    }


                    }

            }
            catch
            { }

            if (Session["idUser"] == null || Session["idUser"].ToString() == "")
            {
                btnComprar.Visible = true;
                btnEditar.Visible = false;
            }
        }


    }

    protected void btnComprar_Click(object sender, EventArgs e)
    {

        if (Session["logado"] != "S") { 

         //   Session["idLinkProdCompra"] = Session["prodEscolhido"];
            Response.Redirect("LogCad.aspx");

        }
        try
        {
            Response.Redirect("Comprar.aspx?cod=" + Session["prodEscolhido"].ToString(), false);
        }
        catch { }
    }


    protected void lblDistribuidor_Click(object sender, EventArgs e)
    {
        DataView dvProduto;

        dvProduto = (DataView)SqlProduto.Select(DataSourceSelectArguments.Empty);

        Session["idUserEscolhido"] = dvProduto.Table.Rows[0]["id_user"].ToString();

        Response.Redirect("PerfilUsuario.aspx");
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        Session["codProdSel"] = Session["prodEscolhido"];

        Response.Redirect("editarProd.aspx");
    }

    protected void btnMinhasCompras_Click(object sender, EventArgs e)
    {
        Response.Redirect("minhasCompras.aspx");
    }
}