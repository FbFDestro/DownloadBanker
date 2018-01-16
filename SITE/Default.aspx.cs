using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{

    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "DownloadBanker - Compra e venda de arquivos.";
        Page.MetaDescription = "DESCRIÇÃO";
        Page.MetaKeywords = "KEYWORDS";

        dlUltimosP.DataSource = listarUltimos();
        dlUltimosP.DataBind();

        dlUltimosPTextos.DataSource = listarUltimosPT();
        dlUltimosPTextos.DataBind();

        dlUA.DataSource = listarUltimosPA();
        dlUA.DataBind();

        dlUV.DataSource = listarUltimosPV();
        dlUV.DataBind();

        dlUI.DataSource = listarUltimosPI();
        dlUI.DataBind();

        dlUP.DataSource = listarUltimosPP();
        dlUP.DataBind();

        dlUO.DataSource = listarUltimosPO();
        dlUO.DataBind();


        try
        {

            if (Session["logadoAgora"] == "S")
            {
                Session["logadoAgora"] = "N";

                int posicaoDoEspaco = Session["nomeUser"].ToString().IndexOf(" ");
                string nome;

                if (posicaoDoEspaco == -1)
                {
                    nome = Session["nomeUser"].ToString();
                }
                else
                {
                    nome = Session["nomeUser"].ToString().Substring(0, posicaoDoEspaco);
                }

                string bemVindo = "UIkit.notify({message : 'Seja bem vindo, " + nome + "!',status  : 'success',timeout :6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "sucesso", bemVindo, true);

            }

        }
        catch { }

    }


    public DataTable listarUltimos()
    {
        DataView listarUlti;


        listarUlti = (DataView)sqlUltimos.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("imagem_prod", typeof(string));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));

        for (int i = 0; i < listarUlti.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listarUlti.Table.Rows[i]["id_prod"].ToString();
            linha["imagem_prod"] = cripto.Decrypt(listarUlti.Table.Rows[i]["imagem_prod"].ToString());
            linha["nome_prod"] = cripto.Decrypt(listarUlti.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listarUlti.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }
    public DataTable listarUltimosPT()
    {
        DataView listarUltiPT;


        listarUltiPT = (DataView)sqlUltimosPT.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("imagem_prod", typeof(string));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));

        for (int i = 0; i < listarUltiPT.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listarUltiPT.Table.Rows[i]["id_prod"].ToString();
            linha["imagem_prod"] = cripto.Decrypt(listarUltiPT.Table.Rows[i]["imagem_prod"].ToString());
            linha["nome_prod"] = cripto.Decrypt(listarUltiPT.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listarUltiPT.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }
    public DataTable listarUltimosPA()
    {
        DataView listarUltiPA;


        listarUltiPA = (DataView)sqlUltimosPA.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("imagem_prod", typeof(string));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));

        for (int i = 0; i < listarUltiPA.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listarUltiPA.Table.Rows[i]["id_prod"].ToString();
            linha["imagem_prod"] = cripto.Decrypt(listarUltiPA.Table.Rows[i]["imagem_prod"].ToString());
            linha["nome_prod"] = cripto.Decrypt(listarUltiPA.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listarUltiPA.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }
    public DataTable listarUltimosPV()
    {
        DataView listarUltiPV;


        listarUltiPV = (DataView)sqlUltimosPV.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("imagem_prod", typeof(string));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));

        for (int i = 0; i < listarUltiPV.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listarUltiPV.Table.Rows[i]["id_prod"].ToString();
            linha["imagem_prod"] = cripto.Decrypt(listarUltiPV.Table.Rows[i]["imagem_prod"].ToString());
            linha["nome_prod"] = cripto.Decrypt(listarUltiPV.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listarUltiPV.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }
    public DataTable listarUltimosPI()
    {
        DataView listarUltiPI;


        listarUltiPI = (DataView)sqlUltimosPI.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("imagem_prod", typeof(string));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));

        for (int i = 0; i < listarUltiPI.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listarUltiPI.Table.Rows[i]["id_prod"].ToString();
            linha["imagem_prod"] = cripto.Decrypt(listarUltiPI.Table.Rows[i]["imagem_prod"].ToString());
            linha["nome_prod"] = cripto.Decrypt(listarUltiPI.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listarUltiPI.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }
    public DataTable listarUltimosPP()
    {
        DataView listarUltiPP;


        listarUltiPP = (DataView)sqlUltimosPP.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("imagem_prod", typeof(string));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));

        for (int i = 0; i < listarUltiPP.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listarUltiPP.Table.Rows[i]["id_prod"].ToString();
            linha["imagem_prod"] = cripto.Decrypt(listarUltiPP.Table.Rows[i]["imagem_prod"].ToString());
            linha["nome_prod"] = cripto.Decrypt(listarUltiPP.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listarUltiPP.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }


    public DataTable listarUltimosPO()
    {
        DataView listarUltiPO;


        listarUltiPO = (DataView)sqlUltimosPO.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("imagem_prod", typeof(string));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));

        for (int i = 0; i < listarUltiPO.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listarUltiPO.Table.Rows[i]["id_prod"].ToString();
            linha["imagem_prod"] = cripto.Decrypt(listarUltiPO.Table.Rows[i]["imagem_prod"].ToString());
            linha["nome_prod"] = cripto.Decrypt(listarUltiPO.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listarUltiPO.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');

            novaTabela.Rows.Add(linha);
        }

        return novaTabela;
    }

}