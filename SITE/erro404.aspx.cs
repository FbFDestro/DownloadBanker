using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class erro400 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnpesqu_Click(object sender, EventArgs e)
    {

        if (txtpesqu.Text == null)
        {



            string erroPes = "UIkit.notify({message : 'Digite um nome para pesquisar!',status  : 'danger',timeout :6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "pes", erroPes, true);

        }
        else
        {
            Session["nomePesq"] = txtpesqu.Text;

            Response.Redirect("Pesquisa.aspx");

        }
    }
}