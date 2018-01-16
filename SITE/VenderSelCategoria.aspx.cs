using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class VenderSelCategoria : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            lbCategoria.DataSource = listarCat();
            lbCategoria.DataBind();
        }



        if (Session["logado"] == "S")
        {
            try
            {
                
                lblTipoTitulo.Text = Session["nomeTipoArquivo"].ToString();

                DataView dvCriar;

                dvCriar = (DataView)sqlCriarCat.Select(DataSourceSelectArguments.Empty);

                Session["idNovaCat"] = dvCriar.Table.Rows.Count + 1;

            }
            catch { }

        }
        else
        {
            Response.Redirect("LogCad.aspx");
        }
    }

    public DataTable listarCat()
    {
        DataView listarCa;


        listarCa = (DataView)sqlCarregarTipo.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();
        

        novaTabela.Columns.Add("id_cat", typeof(int));
        novaTabela.Columns.Add("nome_cat", typeof(string));


        for (int i = 0; i < listarCa.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_cat"] = listarCa.Table.Rows[i]["id_cat"].ToString();
            linha["nome_cat"] = cripto.Decrypt(listarCa.Table.Rows[i]["nome_cat"].ToString());
           
            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }


    protected void btnCriar_Click(object sender, EventArgs e)
    {
        if (txtNovaCat.Text != string.Empty)
        {
            sqlCriarCat.InsertParameters["tituloNovaCategoria"].DefaultValue = cripto.Encrypt(txtNovaCat.Text);
            Session["tituloNovaCategoria"] = txtNovaCat.Text;
            sqlCriarCat.Insert();
            sqlCriarTipoCat.Insert();



            // AUDITORIA
            sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
            sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
            sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
            sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("INSERT");
            sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("CADASTRO DE NOVA CATEGORIA");


            sqlAud.Insert();

            Session["nomeCategoriaArquivo"] = txtNovaCat.Text;
            Session["idCategoriaArquivo"] = Session["idNovaCat"];


            Response.Redirect("VenderSelGenero.aspx");

        }
        else
        {
            string cria = "UIkit.notify({message : 'Por favor, digite um nome!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "campoCria", cria, true);

        }

    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
     Response.Redirect("VenderSelTipo.aspx");
    }

    protected void btnProsseguir_Click(object sender, EventArgs e)
    {
        if (lbCategoria.SelectedItem != null)
        {

            Session["idCategoriaArquivo"] = lbCategoria.SelectedItem.Value;
            Session["nomeCategoriaArquivo"] = lbCategoria.SelectedItem.Text;

            Response.Redirect("VenderSelGenero.aspx");
        }
        else
        {
            string seleciona = "UIkit.notify({message : 'Por favor, selecione uma categoria!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "selecionaCat", seleciona, true);
        }
    }
}