using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Comprar : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    Double valorCarteira = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["idLinkProdCompra"] = "";
        Session["logadoAgora"] = "N";


        valorCarteira = carteira(); // pega o valor do saldo descriptografada

        try
        {

            lblSaldoDisp.Text = valorCarteira.ToString("0.00");

        }
        catch
        {

        }


        try
        {
            SqlComprar.SelectParameters["cod"].DefaultValue = Session["prodEscolhido"].ToString();

            if (Request.QueryString["cod"] != null)
            {
                Session["prodEscolhido"] = Request.QueryString["cod"];

            }


            DataView dvProduto;

            dvProduto = (DataView)SqlComprar.Select(DataSourceSelectArguments.Empty);

            if (cripto.Decrypt(dvProduto.Table.Rows[0]["imagem_prod"].ToString()) == "IMGURL")
            {
                imgProduto.ImageUrl = "imgs/semArquivos.png";
            }
            else
            {
                imgProduto.ImageUrl = cripto.Decrypt(dvProduto.Table.Rows[0]["imagem_prod"].ToString());
            }

            Session["idDono"] = dvProduto.Table.Rows[0]["id_user"].ToString();

            lblProdNome.Text = cripto.Decrypt(dvProduto.Table.Rows[0]["nome_prod"].ToString());
            lblDistribuidor.Text = cripto.Decrypt(dvProduto.Table.Rows[0]["nome_user"].ToString());
            lblTamanho.Text = cripto.Decrypt(dvProduto.Table.Rows[0]["tamanho_prod"].ToString());
            lblPreco.Text = cripto.Decrypt(dvProduto.Table.Rows[0]["valor_prod"].ToString()).Replace(".", ",");

            lblValProd.Text = lblPreco.Text;

        }
        catch
        { }



        // calculo saldo

        double novoSaldo;
        novoSaldo = Convert.ToDouble(lblSaldoDisp.Text) - Convert.ToDouble(lblValProd.Text);

        if (novoSaldo >= 0)
        {
            lblNovoSaldoP.Visible = true;
            pnlConfCompra.Visible = true;

            lblNovoSaldoN.Visible = false;
            pnlSaldoInsuficiente.Visible = false;

            lblNovoSaldoP.Text = novoSaldo.ToString();

        }
        else
        {
            lblNovoSaldoP.Visible = false;
            pnlConfCompra.Visible = false;

            lblNovoSaldoN.Visible = true;
            pnlSaldoInsuficiente.Visible = true;

            lblNovoSaldoN.Text = novoSaldo.ToString();

        }


    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        try
        {

            SqlComprar.InsertParameters["user"].DefaultValue = Session["idUser"].ToString(); // comprador
            SqlComprar.InsertParameters["valor"].DefaultValue = cripto.Encrypt(lblValProd.Text.Replace(",", "."));
            SqlComprar.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));

            SqlComprar.Insert();

            DataView dvVenda;

            dvVenda = (DataView)sqlProdVenda.Select(DataSourceSelectArguments.Empty);

            Session["idVenda"] = dvVenda.Table.Rows.Count;

            sqlProdVenda.InsertParameters["idV"].DefaultValue = Session["idVenda"].ToString();
            sqlProdVenda.InsertParameters["idP"].DefaultValue = Session["prodEscolhido"].ToString();

            sqlProdVenda.Insert();



            // 1 = TIPO Adição de créditos
            // 2 = TIPO Remoção de créditos
            // 3 = tipo COMPRA
            // 4 = tipo VENDA

            sqlTransacaoComprador.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
            sqlTransacaoComprador.InsertParameters["tipoTrans"].DefaultValue = "3"; // 3 = tipo COMPRA
            sqlTransacaoComprador.InsertParameters["valor"].DefaultValue = cripto.Encrypt("-" + lblValProd.Text.Replace(",", "."));
            sqlTransacaoComprador.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));


            sqlTransacaoComprador.Insert();

            // AUDITORIA
            sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
            sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
            sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
            sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("INSERT");
            sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("COMPRA EFETUADA");

            sqlAud.Insert();




            sqlTransacaoDono.InsertParameters["id"].DefaultValue = Session["idDono"].ToString();
            sqlTransacaoDono.InsertParameters["tipoTrans"].DefaultValue = "4"; // 4 = tipo VENDA
            sqlTransacaoDono.InsertParameters["valor"].DefaultValue = cripto.Encrypt(lblValProd.Text.Replace(",", "."));
            sqlTransacaoDono.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));


            sqlTransacaoDono.Insert();

            Session["comprado"] = "s";

            Response.Redirect("minhasCompras.aspx");




        }
        catch { }


    }



    public Double carteira()
    {
        DataView listarTran;

        sqlTransacaoComprador.SelectParameters["id"].DefaultValue = Session["idUser"].ToString();


        listarTran = (DataView)sqlTransacaoComprador.Select(DataSourceSelectArguments.Empty);

        DataTable novaTabela = new DataTable();

        novaTabela.Columns.Add("id_transacao", typeof(int));
        novaTabela.Columns.Add("id_user", typeof(int));
        novaTabela.Columns.Add("id_tipoTransacao", typeof(int));
        novaTabela.Columns.Add("valor_transacao", typeof(double));

        double val = 0;

        for (int i = 0; i < listarTran.Table.Rows.Count; i++)
        {
            DataRow linha = novaTabela.NewRow();

            linha["id_transacao"] = listarTran.Table.Rows[i]["id_transacao"].ToString();
            linha["id_user"] = listarTran.Table.Rows[i]["id_user"].ToString();
            linha["id_tipoTransacao"] = listarTran.Table.Rows[i]["id_tipoTransacao"].ToString();
            linha["valor_transacao"] = cripto.Decrypt(listarTran.Table.Rows[i]["valor_transacao"].ToString()).Replace('.', ',');

            val += Convert.ToDouble(cripto.Decrypt(listarTran.Table.Rows[i]["valor_transacao"].ToString()).Replace('.', ','));
            novaTabela.Rows.Add(linha);
        }

        return val;

    }

}