using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;

public partial class minhasCompras : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvCompras.DataSource = listarVendas();
            gvCompras.DataBind();




            Session["carregarOuPes"] = "C";
        }

        try
        {
            if (Session["comprado"] == "s")
            {
                Session["comprado"] = "n";

                string publi = "UIkit.notify({message : 'Compra efetuada com sucesso!',status  : 'success',timeout :6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "publi", publi, true);
            }
        }
        catch { }



    }

    public DataTable listarVendas()
    {
        DataView listarV;

        SqlCarrega.SelectParameters["id"].DefaultValue = Session["idUser"].ToString();

        listarV = (DataView)SqlCarrega.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();


        novaTabela.Columns.Add("id_venda", typeof(int));
        novaTabela.Columns.Add("down_venda", typeof(string));
        novaTabela.Columns.Add("id_user", typeof(int));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("data_venda", typeof(DateTime));
        novaTabela.Columns.Add("valor_venda", typeof(double));


        for (int i = 0; i < listarV.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_venda"] = listarV.Table.Rows[i]["id_venda"].ToString();
            linha["id_user"] = listarV.Table.Rows[i]["id_user"].ToString();
            linha["down_venda"] = cripto.Decrypt(listarV.Table.Rows[i]["down_venda"].ToString());
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

        novaTabela.Columns.Add("id_venda", typeof(int));
        novaTabela.Columns.Add("down_venda", typeof(string));
        novaTabela.Columns.Add("id_user", typeof(int));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("data_venda", typeof(DateTime));
        novaTabela.Columns.Add("valor_venda", typeof(double));

        novaTabela.DefaultView.RowFilter = "nome_prod like '" + txtPesq.Text + "%'";

        for (int i = 0; i < listarVP.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_venda"] = listarVP.Table.Rows[i]["id_venda"].ToString();
            linha["id_user"] = listarVP.Table.Rows[i]["id_user"].ToString();
            linha["down_venda"] = cripto.Decrypt(listarVP.Table.Rows[i]["down_venda"].ToString());
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
            gvCompras.UseAccessibleHeader = true;
            gvCompras.HeaderRow.TableSection = TableRowSection.TableHeader;
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

            gvCompras.Visible = false;
            gvPesq.Visible = true;

            Session["carregarOuPes"] = "P";

        }
        else
        {
            gvCompras.Visible = true;
            gvPesq.Visible = false;
            Session["carregarOuPes"] = "C";
        }

    }

    protected void btnLimpar_Click(object sender, EventArgs e)
    {
        gvCompras.Visible = true;
        gvPesq.Visible = false;
        Session["carregarOuPes"] = "C";
        txtPesq.Text = string.Empty;
        gvCompras.DataSource = listarVendas();
        gvCompras.DataBind();
    }

    protected void gvVendas_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codVendaSel"] = gvCompras.Rows[gvCompras.SelectedIndex].Cells[0].Text;
        Session["downVendaSel"] = gvCompras.Rows[gvCompras.SelectedIndex].Cells[5].Text;

       

        try
        {
            sqlArquivo.SelectParameters["idVenda"].DefaultValue = Session["codVendaSel"].ToString();


            DataView dvA;

            dvA = (DataView)sqlArquivo.Select(DataSourceSelectArguments.Empty);

                Session["arquivoUrl"] = cripto.Decrypt(dvA.Table.Rows[0]["arquivo_prod"].ToString());

                }
                catch
                {
                }

        int down = Convert.ToInt32(Session["downVendaSel"].ToString());



        if (down < 2)
        {


            SqlCarrega.UpdateParameters["id"].DefaultValue = Session["codVendaSel"].ToString();
            SqlCarrega.UpdateParameters["down"].DefaultValue = cripto.Encrypt((down + 1).ToString());

            SqlCarrega.Update();

            // AUDITORIA
            sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
            sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
            sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
            sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("UPDATE");
            sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("DOWNLOAD EFETUADO");

            sqlAud.Insert();


            gvCompras.DataSource = listarVendas();
          gvCompras.DataBind();



            btnDown.Visible = true;
          
           Session["baixarJa"] = "S";
            

        }
        else
        {
            string publi = "UIkit.notify({message : 'O limite de download ja foi atingido!',status  : 'danger',timeout :6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "publi", publi, true);
          

        }

    }

    protected void gvPesq_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codVendaSel"] = gvPesq.Rows[gvPesq.SelectedIndex].Cells[0].Text;
        Session["downVendaSel"] = gvPesq.Rows[gvPesq.SelectedIndex].Cells[5].Text;



        try
        {
            sqlArquivo.SelectParameters["idVenda"].DefaultValue = Session["codVendaSel"].ToString();


            DataView dvA;

            dvA = (DataView)sqlArquivo.Select(DataSourceSelectArguments.Empty);

            Session["arquivoUrl"] = cripto.Decrypt(dvA.Table.Rows[0]["arquivo_prod"].ToString());

        }
        catch
        {
        }

        int down = Convert.ToInt32(Session["downVendaSel"].ToString());



        if (down < 2)
        {


            SqlCarrega.UpdateParameters["id"].DefaultValue = Session["codVendaSel"].ToString();
            SqlCarrega.UpdateParameters["down"].DefaultValue = cripto.Encrypt((down + 1).ToString());

            SqlCarrega.Update();


            // AUDITORIA
            sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
            sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
            sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
            sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("UPDATE");
            sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("DOWNLOAD EFETUADO");

            sqlAud.Insert();


            gvPesq.DataSource = listarVendas();
            gvPesq.DataBind();



            btnDown.Visible = true;

            Session["baixarJa"] = "S";


        }
        else
        {
            string publi = "UIkit.notify({message : 'O limite de download ja foi atingido!',status  : 'danger',timeout :6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "publi", publi, true);


        }

    }

    protected void btnDown_Click(object sender, EventArgs e)
    {
        try
        {

            if (Session["baixarJa"] == "S")
            {
                btnDown.Visible = false;
                Session["baixarJa"] = "N";

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Session["arquivoUrl"].ToString() + "");
                Response.TransmitFile(Server.MapPath(Session["arquivoUrl"].ToString()));
                Response.End();
            }


        }
        catch
        {

        }
    }
}