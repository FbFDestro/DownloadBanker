using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class meusProdutos : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvProduto.DataSource = listarProd();
            gvProduto.DataBind();
        }

        if (Session["logado"] == "S")
        {
            if (!IsPostBack)
            {

                Session["carregarOuPes"] = "C";
            }


            if (Session["publicadoAgr"] == "Sim")
            {
                Session["publicadoAgr"] = "Não";

                string publi = "UIkit.notify({message : 'Produto publicado com sucesso!',status  : 'success',timeout :6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "publi", publi, true);
            }

            if (Session["editadoAgr"] == "Sim")
            {
                Session["editadoAgr"] = "Não";

                string edit = "UIkit.notify({message : 'Produto editado com sucesso!',status  : 'success',timeout :6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "edit", edit, true);
            }


        }
        else
        {
            Response.Redirect("LogCad.aspx");

        }
    }



    public DataTable listarProd()
    {
        DataView listarP;


        listarP = (DataView)SqlCarrega.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));
        novaTabela.Columns.Add("tamanho_prod", typeof(string));


        for (int i = 0; i < listarP.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listarP.Table.Rows[i]["id_prod"].ToString();
            linha["nome_prod"] = cripto.Decrypt(listarP.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listarP.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');
            linha["tamanho_prod"] = cripto.Decrypt(listarP.Table.Rows[i]["tamanho_prod"].ToString());

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;




    }

    public DataTable listarProdP()
    {
        DataView listarPp;


        listarPp = (DataView)SqlCarrega.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));
        novaTabela.Columns.Add("tamanho_prod", typeof(string));


        novaTabela.DefaultView.RowFilter = "nome_prod like '" + txtPesq.Text + "%'";

        for (int i = 0; i < listarPp.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listarPp.Table.Rows[i]["id_prod"].ToString();
            linha["nome_prod"] = cripto.Decrypt(listarPp.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listarPp.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');
            linha["tamanho_prod"] = cripto.Decrypt(listarPp.Table.Rows[i]["tamanho_prod"].ToString());

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }



    protected void gvProduto_SelectedIndexChanged(object sender, EventArgs e)
    {

        Session["codProdSel"] = gvProduto.Rows[gvProduto.SelectedIndex].Cells[1].Text;

        Response.Redirect("editarProd.aspx");

    }
    protected void btnPesq_Click(object sender, EventArgs e)
    {
        if (txtPesq.Text != string.Empty)
        {

            gvPesq.DataSource = listarProdP();
            gvPesq.DataBind();

            gvProduto.Visible = false;
            gvPesq.Visible = true;



            Session["carregarOuPes"] = "P";

        }
        else
        {
            gvProduto.Visible = true;
            gvPesq.Visible = false;
            Session["carregarOuPes"] = "C";
        }


    }


    protected void btnLimpar_Click(object sender, EventArgs e)
    {
        gvProduto.Visible = true;
        gvPesq.Visible = false;
        Session["carregarOuPes"] = "C";
        txtPesq.Text = string.Empty;
        gvProduto.DataSource = listarProd();
        gvProduto.DataBind();
    }
    protected void gvPesq_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["codProdSel"] = gvPesq.Rows[gvPesq.SelectedIndex].Cells[1].Text;

        Response.Redirect("EditarProd.aspx");
        
    }
    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        if (Session["carregarOuPes"] == "C")
        {
            foreach (GridViewRow linha in gvProduto.Rows)
            {
                CheckBox op;

                op = (CheckBox)linha.FindControl("chkOpP");

                if (op.Checked == true)
                {
                    sqlExcluir.UpdateParameters["COD"].DefaultValue =
                        linha.Cells[1].Text;

                    sqlExcluir.Update();

                    // AUDITORIA
                    sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
                    sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
                    sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
                    sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("UPDATE");
                    sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("EXCLUSÃO DE PRODUTO");


                    sqlAud.Insert();



                }
            }

            gvProduto.DataSource = listarProd();
            gvProduto.DataBind();

        }
        else
        {

            foreach (GridViewRow linha in gvPesq.Rows)
            {
                CheckBox op;

                op = (CheckBox)linha.FindControl("chkOpPesq");

                if (op.Checked == true)
                {
                    sqlExcluir.UpdateParameters["COD"].DefaultValue =
                        linha.Cells[1].Text;

                    sqlExcluir.Update();
                }
            }

            gvProduto.DataSource = listarProd();
            gvProduto.DataBind();

        }

    }

    protected void gvProduto_PreRender(object sender, EventArgs e)
    {
        try
        {
            gvProduto.UseAccessibleHeader = true;
            gvProduto.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch { }
 
    }
    protected void gvPesq_PreRender(object sender, EventArgs e)
    {
        try { 
        gvPesq.UseAccessibleHeader = true;
        gvPesq.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch { }
    }

}
