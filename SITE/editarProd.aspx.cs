using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class editarProd : System.Web.UI.Page
{

    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["logado"] == "S")
            {

                try
                {
                    DataView dv;

                    dv = (DataView)sqlCarregaProd.Select(DataSourceSelectArguments.Empty);


                    txtTitulo.Text =cripto.Decrypt(dv.Table.Rows[0]["nome_prod"].ToString());
                    txtPreco.Text = cripto.Decrypt(dv.Table.Rows[0]["valor_prod"].ToString()).Replace(".",",");
                    txtTamanhoArqui.Text = cripto.Decrypt(dv.Table.Rows[0]["tamanho_prod"].ToString());
                    lista.InnerHtml = cripto.Decrypt(dv.Table.Rows[0]["contem_prod"].ToString());
                    descricao.InnerHtml = cripto.Decrypt(dv.Table.Rows[0]["sobre_prod"].ToString());
                    img.ImageUrl = cripto.Decrypt(dv.Table.Rows[0]["imagem_prod"].ToString());
                    Session["arquivoUrl"] = cripto.Decrypt(dv.Table.Rows[0]["arquivo_prod"].ToString());

                }
                catch
                {
                }
            }
            else
            {
                Response.Redirect("LogCad.aspx");
            }

        }
    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("meusProdutos.aspx");
    }
    protected void btnPublicar_Click(object sender, EventArgs e)
    {

        sqlEditar.UpdateParameters["titulo"].DefaultValue =cripto.Encrypt(txtTitulo.Text);
        sqlEditar.UpdateParameters["tamanho"].DefaultValue = cripto.Encrypt(txtTamanhoArqui.Text);
        sqlEditar.UpdateParameters["preco"].DefaultValue = cripto.Encrypt(txtPreco.Text).Replace(',', '.');
        sqlEditar.UpdateParameters["desc"].DefaultValue = cripto.Encrypt(descricao.InnerHtml);
        sqlEditar.UpdateParameters["lista"].DefaultValue = cripto.Encrypt(lista.InnerHtml);


        String nomeArq, urlBD;

        nomeArq = flImagem.FileName;
        urlBD = "";

        if (nomeArq != "")
        {
            flImagem.SaveAs(Server.MapPath("~\\imagensProd\\" + nomeArq));

            urlBD = "~\\imagensProd\\" + nomeArq;

        }
        else
        {
            urlBD = img.ImageUrl;

        }



        if (txtPreco.Text == string.Empty || txtTamanhoArqui.Text == string.Empty || txtTitulo.Text == string.Empty || descricao.InnerText == string.Empty || lista.InnerText == string.Empty)
        {
            string camposVazios;

            camposVazios = "UIkit.notify({message : 'Preencha todos os campos',status  : 'danger',timeout :6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "vaziosNod", camposVazios, true);


        }
        else
        {


            try
            {
                sqlEditar.UpdateParameters["imagem"].DefaultValue = cripto.Encrypt(urlBD);

                sqlEditar.Update();


                sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
                sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
                sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
                sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("UPDATE");
                sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("ALTERAÇÃO DE PRODUTO");

                sqlAud.Insert();

                Session["editadoAgr"] = "Sim";
                Response.Redirect("meusProdutos.aspx");

            }
            catch
            {
                string cadastroErro;

                cadastroErro = "UIkit.notify({message : 'A edição falhou. Tente mais tarde!',status  : 'warning',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "erroCad", cadastroErro, true);


            }

        }
    }
}