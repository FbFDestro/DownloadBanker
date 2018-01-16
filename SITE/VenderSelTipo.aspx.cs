using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VenderSelTipo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["logado"] == "S")
        {
        }
        else
        {
            Response.Redirect("LogCad.aspx");

        }

    }


    protected void linkAudio_Click(object sender, EventArgs e)
    {
        Session["idTipoArquivo"] = "1";
        Session["nomeTipoArquivo"] = "Áudios";
        Response.Redirect("VenderSelCategoria.aspx");
    }
    protected void linkImagens_Click(object sender, EventArgs e)
    {
        Session["idTipoArquivo"] = "2";
        Session["nomeTipoArquivo"] = "Imagens";
        Response.Redirect("VenderSelCategoria.aspx");
    }
    protected void linkProgramas_Click(object sender, EventArgs e)
    {
        Session["idTipoArquivo"] = "3";
        Session["nomeTipoArquivo"] = "Programas";
        Response.Redirect("VenderSelCategoria.aspx");
    }
    protected void linkTextos_Click(object sender, EventArgs e)
    {
        Session["idTipoArquivo"] = "4";
        Session["nomeTipoArquivo"] = "Textos";
        Response.Redirect("VenderSelCategoria.aspx");
    }
    protected void LinkVideos_Click(object sender, EventArgs e)
    {
        Session["idTipoArquivo"] = "5";
        Session["nomeTipoArquivo"] = "Vídeos";
        Response.Redirect("VenderSelCategoria.aspx");
    }
    protected void LinkOutros_Click(object sender, EventArgs e)
    {
        Session["idTipoArquivo"] = "6";
        Session["nomeTipoArquivo"] = "Outros";
        Response.Redirect("VenderSelCategoria.aspx");
    }


}