using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class VenderSelGenero : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            lbGenero.DataSource = listarCat();
            lbGenero.DataBind();
        }

        if (Session["logado"] == "S")
        {
            try
            {

                lblCategoriaTitulo.Text = Session["nomeCategoriaArquivo"].ToString();

                DataView dv, dvCriar;

                dv = (DataView)sqlCarregarGenero.Select(DataSourceSelectArguments.Empty);
                dvCriar = (DataView)sqlCriarGen.Select(DataSourceSelectArguments.Empty);

                Session["idNovoGen"] = dvCriar.Table.Rows.Count + 1;

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


        listarCa = (DataView)sqlCarregarGenero.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();


        novaTabela.Columns.Add("id_genero", typeof(int));
        novaTabela.Columns.Add("nome_genero", typeof(string));


        for (int i = 0; i < listarCa.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_genero"] = listarCa.Table.Rows[i]["id_genero"].ToString();
            linha["nome_genero"] = cripto.Decrypt(listarCa.Table.Rows[i]["nome_genero"].ToString());

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }



    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("VenderSelCategoria.aspx");
    }
    protected void btnProsseguir_Click(object sender, EventArgs e)
    {
        if (lbGenero.SelectedItem != null)
        {

            Session["idGeneroArquivo"] = lbGenero.SelectedItem.Value;
            Session["nomeGeneroArquivo"] = lbGenero.SelectedItem.Text;

              Response.Redirect("VenderProduto.aspx");
        }
        else
        {
            string seleciona = "UIkit.notify({message : 'Por favor, selecione um gênero!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "selecionaGen", seleciona, true);
        }
    }
    protected void btnCriar_Click(object sender, EventArgs e)
    {
        if (txtNovoGenero.Text != string.Empty)
        {
            sqlCriarGen.InsertParameters["titGen"].DefaultValue = cripto.Encrypt(txtNovoGenero.Text);
            Session["tituloNovaCategoria"] = txtNovoGenero.Text;
            Session["nomeGeneroArquivo"] = txtNovoGenero.Text;
            Session["idGeneroArquivo"] = Session["idNovoGen"];


            sqlCriarGen.Insert();
            sqlCriarCatGen.Insert();

            // AUDITORIA
            sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
            sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
            sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
            sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("INSERT");
            sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("CADASTRO DE NOVO GÊNERO");


            sqlAud.Insert();


            Response.Redirect("VenderProduto.aspx");

        }
        else
        {
            string cria = "UIkit.notify({message : 'Por favor, digite um nome!',status  : 'danger',timeout : 6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "campoCria", cria, true);

        }
    }
}