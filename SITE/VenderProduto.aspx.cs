using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class VenderProduto : System.Web.UI.Page
{
    Criptografia cripto = new Criptografia("ETEP");
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (Session["logado"] == "S")
        {
              try
            {  
                lblTipo.Text = Session["nomeTipoArquivo"].ToString();
                lblCat.Text = Session["nomeCategoriaArquivo"].ToString();
                lblGen.Text = Session["nomeGeneroArquivo"].ToString();
            }
            catch{}



        }
        else
        {
            Response.Redirect("LogCad.aspx");

        }
    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {

       
        Response.Redirect("VenderSelGenero.aspx");


    }
    protected void btnPublicar_Click(object sender, EventArgs e)
    {
        sqlPublicar.InsertParameters["titulo"].DefaultValue = cripto.Encrypt(txtTitulo.Text);
        sqlPublicar.InsertParameters["tamanho"].DefaultValue = cripto.Encrypt(txtTamanhoArqui.Text);
        sqlPublicar.InsertParameters["preco"].DefaultValue = cripto.Encrypt(txtPreco.Text.Replace(',','.'));
        sqlPublicar.InsertParameters["descricao"].DefaultValue = cripto.Encrypt(HttpUtility.HtmlEncode(descricao.InnerText));
        sqlPublicar.InsertParameters["lista"].DefaultValue = cripto.Encrypt(HttpUtility.HtmlEncode(lista.InnerText));
        
      


        String nomeArqI, urlBDI;

        nomeArqI = flImagem.FileName;
        urlBDI = "";

        if (nomeArqI != "")
        {
            flImagem.SaveAs(Server.MapPath("~\\imagensProd\\" + nomeArqI));

            urlBDI = "~\\imagensProd\\" + nomeArqI;

        }
        else
        {
            string imgVazios;

           imgVazios = "UIkit.notify({message : 'Inserir uma imagem é obrigatório!',status  : 'danger',timeout :6000,pos: 'bottom-right'});";

           ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "imgNod", imgVazios, true);


        }


        String nomeArqA, urlBDA;

        nomeArqA = flArquivo.FileName;
        urlBDA = "";

        if (nomeArqA != "")
        {
            flImagem.SaveAs(Server.MapPath("~\\arquivosProd\\" + nomeArqA));

            urlBDA = "~\\arquivosProd\\" + nomeArqA;

        }
        else
        {
            string arVazios;

           arVazios = "UIkit.notify({message : 'Inserir um arquivo é obrigatório!',status  : 'danger',timeout :6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "arNod", arVazios, true);


        }




        if (txtPreco.Text == string.Empty || txtTamanhoArqui.Text == string.Empty || txtTitulo.Text == string.Empty || descricao.InnerText == string.Empty || lista.InnerText == string.Empty || nomeArqI == string.Empty || nomeArqA == string.Empty)
        {
            string camposVazios;

            camposVazios = "UIkit.notify({message : 'Preencha todos os campos',status  : 'danger',timeout :6000,pos: 'bottom-right'});";

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "vaziosNod", camposVazios, true);


        }
        else
        {

            try
            {
                sqlPublicar.InsertParameters["imagem"].DefaultValue = cripto.Encrypt(urlBDI);
                sqlPublicar.InsertParameters["arquivo"].DefaultValue = cripto.Encrypt(urlBDA);

                DataView dv;

                dv = (DataView)sqlPublicar.Select(DataSourceSelectArguments.Empty);

                Session["idNovoProd"] = dv.Table.Rows.Count + 1;


                sqlPublicar.Insert();
                sqlProdTipo.Insert();


                // AUDITORIA
                sqlAud.InsertParameters["data"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("yyyy/MM/dd"));
                sqlAud.InsertParameters["hora"].DefaultValue = cripto.Encrypt(DateTime.Now.ToString("HH:mm:ss"));
                sqlAud.InsertParameters["id"].DefaultValue = Session["idUser"].ToString();
                sqlAud.InsertParameters["acao"].DefaultValue = cripto.Encrypt("INSERT");
                sqlAud.InsertParameters["desc"].DefaultValue = cripto.Encrypt("PUBLICAÇÃO DE PRODUTO");


                sqlAud.Insert();


                Session["publicadoAgr"] = "Sim";
                Response.Redirect("meusProdutos.aspx");

            }
            catch
            {
                string cadastroErro;

                cadastroErro = "UIkit.notify({message : 'A públicação falhou. Tente mais tarde!',status  : 'warning',timeout : 6000,pos: 'bottom-right'});";

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "erroCad", cadastroErro, true);


            }

        }


    }
}