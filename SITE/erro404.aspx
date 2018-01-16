<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="erro404.aspx.cs" Inherits="erro400" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

      <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2>PÁGINA NÃO ENCONTRADO</h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2>&nbsp;</h2></div>

            </div>

  <!-- conteudo da página -->
        
          <div class="erroBd">
        <img src="imgs/erro404.png" alt="Erro na conexão" />
              <h3>A PÁGINA QUE VOCÊ PROCURA NÃO EXISTE.</h3>
              <h4><a href="Default.aspx"><img src="imgs/incio.png" /> VOLTAR PARA A PÁGINA INICIAL</a></h4>

              <hr />

              <br />
              <asp:TextBox ID="txtpesqu" CssClass="pesq404" runat="server" Width="316px" placeholder="Procure o que deseja"></asp:TextBox>
                            <asp:Button ID="btnpesqu" CssClass="btnProd" runat="server" OnClick="btnpesqu_Click" Text="PESQUISAR" Width="158px" />


          </div>

         </div>

</asp:Content>

