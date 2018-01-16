using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inicio : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["logado"] == "S")
        {
            phLogado.Visible = true;
            phLogadoC.Visible = true;
            phVisitante.Visible = false;
        }
        else
        {
            phLogado.Visible = false;
            phLogadoC.Visible = false;
            phVisitante.Visible = true;
        }


    }


    protected void LinkPerfil_Click(object sender, EventArgs e)
    {
        Session["idUserEscolhido"] = Session["idUser"];
        Response.Redirect("PerfilUsuario.aspx"); 
    }
    protected void linkEntre_Click(object sender, EventArgs e)
    {
        Session["logOuCad"] = "L";
        Response.Redirect("LogCad.aspx");  
    }
    protected void linkCad_Click(object sender, EventArgs e)
    {
        Session["logOuCad"] = "C";
        Response.Redirect("LogCad.aspx");
    }
  
    protected void sairConta_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
      

        if (txtPesq.Text == null)
        {
            


            string erroPes = "UIkit.notify({message : 'Digite um nome para pesquisar!',status  : 'danger',timeout :6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "pes", erroPes, true);

        }
        else
        {
            Session["nomePesq"] = txtPesq.Text;

            Response.Redirect("Pesquisa.aspx");

        }

    }
}
