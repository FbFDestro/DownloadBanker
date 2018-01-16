using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class minhasVendas : System.Web.UI.Page
{

    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvVendas.DataSource = listarVendas();
            gvVendas.DataBind();

            Session["carregarOuPes"] = "C";
        }

    }

    public DataTable listarVendas()
    {
        DataView listarV;

        SqlCarrega.SelectParameters["id"].DefaultValue = Session["idUser"].ToString();

        listarV = (DataView)SqlCarrega.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_user", typeof(int));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("data_venda", typeof(DateTime));
        novaTabela.Columns.Add("valor_venda", typeof(double));


        for (int i = 0; i < listarV.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_user"] = listarV.Table.Rows[i]["id_user"].ToString();
            linha["nome_prod"] = cripto.Decrypt(listarV.Table.Rows[i]["nome_prod"].ToString());
            linha["data_venda"] = cripto.Decrypt(listarV.Table.Rows[i]["data_venda"].ToString());
            linha["valor_venda"] = cripto.Decrypt(listarV.Table.Rows[i]["valor_venda"].ToString()).Replace('.', ',');
            
            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }



    public DataTable listarVendasP()
    {
        DataView listarVP;

        SqlCarrega.SelectParameters["id"].DefaultValue = Session["idUser"].ToString();

        listarVP = (DataView)SqlCarrega.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_user", typeof(int));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("data_venda", typeof(DateTime));
        novaTabela.Columns.Add("valor_venda", typeof(double));

        novaTabela.DefaultView.RowFilter = "nome_prod like '" + txtPesq.Text + "%'";

        for (int i = 0; i < listarVP.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_user"] = listarVP.Table.Rows[i]["id_user"].ToString();
            linha["nome_prod"] = cripto.Decrypt(listarVP.Table.Rows[i]["nome_prod"].ToString());
            linha["data_venda"] = cripto.Decrypt(listarVP.Table.Rows[i]["data_venda"].ToString());
            linha["valor_venda"] = cripto.Decrypt(listarVP.Table.Rows[i]["valor_venda"].ToString()).Replace('.', ',');

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }

    protected void gvVendas_PreRender(object sender, EventArgs e)
    {
        try
        {
            gvVendas.UseAccessibleHeader = true;
            gvVendas.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch { }
    }
    protected void gvPesq_PreRender(object sender, EventArgs e)
    {
        try
        {
            gvPesq.UseAccessibleHeader = true;
            gvPesq.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch { }
    }

         protected void btnPesq_Click(object sender, EventArgs e)
    {
        if (txtPesq.Text != string.Empty)
        {

            gvPesq.DataSource = listarVendasP();
            gvPesq.DataBind();

            gvVendas.Visible = false;
            gvPesq.Visible = true;

            Session["carregarOuPes"] = "P";

        }
        else
        {
            gvVendas.Visible = true;
            gvPesq.Visible = false;
            Session["carregarOuPes"] = "C";
        }

}

    protected void btnLimpar_Click(object sender, EventArgs e)
    {
        gvVendas.Visible = true;
        gvPesq.Visible = false;
        Session["carregarOuPes"] = "C";
        txtPesq.Text = string.Empty;
        gvVendas.DataSource = listarVendas();
        gvVendas.DataBind();
    }
}