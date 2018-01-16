using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class minhaCarteira : System.Web.UI.Page
{

    Criptografia cripto = new Criptografia("ETEP");
    Double valorCarteira = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["logado"] == "S")
        {

            valorCarteira = carteiraVal();

        if (!IsPostBack)
        {
            gvCarteira.DataSource = carteiraSel();
            gvCarteira.DataBind();


            Session["carregarOuPes"] = "C";
        }

        try
        { 
            lblSaldo.Text = valorCarteira.ToString();
        }
        catch {}

            }
            else{

                Response.Redirect("LogCad.aspx");
            }
    }

  


    public Double carteiraVal()
    {
        DataView listarTran;

        sqlCarteira.SelectParameters["id"].DefaultValue = Session["idUser"].ToString();


        listarTran = (DataView)sqlCarteira.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_transacao", typeof(int));
        novaTabela.Columns.Add("id_user", typeof(int));
        novaTabela.Columns.Add("id_tipoTransacao", typeof(int));
        novaTabela.Columns.Add("nome_tipo", typeof(string));
        novaTabela.Columns.Add("valor_transacao", typeof(double));
        novaTabela.Columns.Add("data_transacao", typeof(DateTime));

        double val = 0;

        for (int i = 0; i < listarTran.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_transacao"] = listarTran.Table.Rows[i]["id_transacao"].ToString();
            linha["id_user"] = listarTran.Table.Rows[i]["id_user"].ToString();
            linha["id_tipoTransacao"] = listarTran.Table.Rows[i]["id_tipoTransacao"].ToString();
            linha["nome_tipo"] = cripto.Decrypt(listarTran.Table.Rows[i]["nome_tipo"].ToString());
            linha["valor_transacao"] = cripto.Decrypt(listarTran.Table.Rows[i]["valor_transacao"].ToString()).Replace('.', ',');
            linha["data_transacao"] = cripto.Decrypt(listarTran.Table.Rows[i]["data_transacao"].ToString());


            val += Convert.ToDouble(cripto.Decrypt(listarTran.Table.Rows[i]["valor_transacao"].ToString()).Replace('.', ','));
            novaTabela.Rows.Add(linha);
        }

        return val;

    }


    public DataTable carteiraSel()
    {
        DataView listarTran;

        sqlCarteira.SelectParameters["id"].DefaultValue = Session["idUser"].ToString();


        listarTran = (DataView)sqlCarteira.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_transacao", typeof(int));
        novaTabela.Columns.Add("id_user", typeof(int));
        novaTabela.Columns.Add("id_tipoTransacao", typeof(int));
        novaTabela.Columns.Add("nome_tipo", typeof(string));
        novaTabela.Columns.Add("valor_transacao", typeof(double));
        novaTabela.Columns.Add("data_transacao", typeof(DateTime));

        for (int i = 0; i < listarTran.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_transacao"] = listarTran.Table.Rows[i]["id_transacao"].ToString();
            linha["id_user"] = listarTran.Table.Rows[i]["id_user"].ToString();
            linha["id_tipoTransacao"] = listarTran.Table.Rows[i]["id_tipoTransacao"].ToString();
            linha["nome_tipo"] = cripto.Decrypt(listarTran.Table.Rows[i]["nome_tipo"].ToString());
            linha["valor_transacao"] = cripto.Decrypt(listarTran.Table.Rows[i]["valor_transacao"].ToString()).Replace('.', ',');
            linha["data_transacao"] = cripto.Decrypt(listarTran.Table.Rows[i]["data_transacao"].ToString());

          novaTabela.Rows.Add(linha);
        }

        return novaTabela;

    }


    public DataTable carteiraSelFILTO()
    {
        DataView listarTran;

        sqlCarteiraFiltro.SelectParameters["id"].DefaultValue = Session["idUser"].ToString();
        sqlCarteiraFiltro.SelectParameters["tipoT"].DefaultValue = ddlTipoTrans.SelectedValue.ToString();



        listarTran = (DataView)sqlCarteiraFiltro.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_transacao", typeof(int));
        novaTabela.Columns.Add("id_user", typeof(int));
        novaTabela.Columns.Add("id_tipoTransacao", typeof(int));
        novaTabela.Columns.Add("nome_tipo", typeof(string));
        novaTabela.Columns.Add("valor_transacao", typeof(double));
        novaTabela.Columns.Add("data_transacao", typeof(DateTime));

        for (int i = 0; i < listarTran.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_transacao"] = listarTran.Table.Rows[i]["id_transacao"].ToString();
            linha["id_user"] = listarTran.Table.Rows[i]["id_user"].ToString();
            linha["id_tipoTransacao"] = listarTran.Table.Rows[i]["id_tipoTransacao"].ToString();
            linha["nome_tipo"] = cripto.Decrypt(listarTran.Table.Rows[i]["nome_tipo"].ToString());
            linha["valor_transacao"] = cripto.Decrypt(listarTran.Table.Rows[i]["valor_transacao"].ToString()).Replace('.', ',');
            linha["data_transacao"] = cripto.Decrypt(listarTran.Table.Rows[i]["data_transacao"].ToString());

            novaTabela.Rows.Add(linha);
        }


        return novaTabela;

    }



    protected void btnPesq_Click(object sender, EventArgs e)
    {
       
        if (ddlTipoTrans.Text != string.Empty)
        {

          
            gvPesq.DataSource = carteiraSelFILTO();
            gvPesq.DataBind();


            if(gvPesq.Rows.Count == 0)
            {

                lblNada.Visible = true;
            }else
            {
                lblNada.Visible = false;
            }

            gvCarteira.Visible = false;
            gvPesq.Visible = true;

            Session["carregarOuPes"] = "P";

           
        }
        else
        {
            gvCarteira.Visible = true;
            gvPesq.Visible = false;
            Session["carregarOuPes"] = "C";
        }




    }

    protected void btnLimpar_Click(object sender, EventArgs e)
    {
        gvCarteira.Visible = true;
        gvPesq.Visible = false;
        Session["carregarOuPes"] = "C";
        ddlTipoTrans.Text = string.Empty;
        gvCarteira.DataSource = carteiraSel();
        gvCarteira.DataBind();

        lblNada.Visible = false;

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

    protected void gvCarteira_PreRender(object sender, EventArgs e)
    {
        try
        {
            gvCarteira.UseAccessibleHeader = true;
            gvCarteira.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch { }
    }
}