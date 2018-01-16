using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Pesquisa : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {
        
         
            lblPesq.Text = Session["nomePesq"].ToString();

            if (!IsPostBack)
            {


                paginacao("");

            }

    }

    public void paginacao(string tipo)
    {

        int tamanhoPagina = 8;
        int registroInicio = 0;

        if (ViewState["RegistroInicio"] != null)
        {
            registroInicio = (int)ViewState["registroInicio"];
        }

        if (tipo == "Proximo")
        {
            registroInicio += tamanhoPagina;

        } if (tipo == "Anterior" && registroInicio > 0)
        {
            registroInicio -= tamanhoPagina;
        }


        DataTable listaDataProd = new DataTable();
        DataTable listaProdDescripto = listarTudo();


        listaDataProd = listaProdDescripto.Clone();

        listaDataProd.DefaultView.RowFilter = "nome_prod like '" + Session["nomePesq"].ToString() + "%'";



        for (int i = registroInicio; i < (registroInicio + tamanhoPagina); i++)
        {
            if (i < listaProdDescripto.Rows.Count)
            {
                listaDataProd.ImportRow(listaProdDescripto.Rows[i]);
            }
        }

        if (tipo == "Proximo" && listaDataProd.Rows.Count == 0 && registroInicio > 0)
        {

            registroInicio -= tamanhoPagina;
            for (int i = registroInicio; i < (registroInicio + tamanhoPagina); i++)
            {
                if (i < listaProdDescripto.Rows.Count)
                {

                    listaDataProd.ImportRow(listaProdDescripto.Rows[i]);

                }

            }
        }


        dlTodosCat.DataSource = listaDataProd;
        dlTodosCat.DataBind();

        ViewState.Add("registroInicio", registroInicio);

    }

    public DataTable listarTudo()
    {
        DataView listar;


        listar = (DataView)sqlPesq.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();
       

        novaTabela.Columns.Add("id_prod", typeof(int));
        novaTabela.Columns.Add("imagem_prod", typeof(string));
        novaTabela.Columns.Add("nome_prod", typeof(string));
        novaTabela.Columns.Add("valor_prod", typeof(double));

        novaTabela.DefaultView.RowFilter = "nome_prod like '" + Session["nomePesq"].ToString() + "%'";


        for (int i = 0; i < listar.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_prod"] = listar.Table.Rows[i]["id_prod"].ToString();
            linha["imagem_prod"] = cripto.Decrypt(listar.Table.Rows[i]["imagem_prod"].ToString());
            linha["nome_prod"] = cripto.Decrypt(listar.Table.Rows[i]["nome_prod"].ToString());
            linha["valor_prod"] = cripto.Decrypt(listar.Table.Rows[i]["valor_prod"].ToString()).Replace('.', ',');

            novaTabela.Rows.Add(linha);
        }

     

        return novaTabela;
    }




    protected void imgAnterior_Click(object sender, ImageClickEventArgs e)
    {
        paginacao("Anterior");
    }
    protected void imgProx_Click(object sender, ImageClickEventArgs e)
    {
        paginacao("Proximo");
    }
}