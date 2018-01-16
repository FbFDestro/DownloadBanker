<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="Pesquisa.aspx.cs" Inherits="Pesquisa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

      <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2>PESQUISA POR: <asp:Label ID="lblPesq" runat="server" Text="Label"></asp:Label></h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2>&nbsp;</h2></div>

            </div>

  <!-- conteudo da página -->
        <br />

            <asp:DataList ID="dlTodosCat" runat="server" DataKeyField="id_prod" RepeatColumns="4" RepeatDirection="Horizontal" CellSpacing="5">
              <FooterTemplate>
                    <asp:ImageButton ID="imgAnterior" runat="server" ImageUrl="~/imgs/ant.png" OnClick="imgAnterior_Click" />
            &nbsp;
                    <asp:ImageButton ID="imgProx" runat="server" ImageUrl="~/imgs/prox.png" OnClick="imgProx_Click" />
        </FooterTemplate>
                  <ItemTemplate>
                    <asp:HyperLink ID="hlItens" runat="server" NavigateUrl='<%# Eval("id_prod", "Produto.aspx?cod={0}") %>'>

                                    <asp:Image ID="imgProd" runat="server" ImageUrl='<%# Eval("imagem_prod") %>' />

                           

                                    <div class="tituloProd"><asp:Label ID="nome_prodLabel" runat="server" Text='<%# Eval("nome_prod") %>' /></div>

       
                                    <div class="precoProd">R$ <asp:Label ID="valor_prodLabel" runat="server" Text='<%# Eval("valor_prod") %>' /></div>

                                        </asp:HyperLink></ItemTemplate></asp:DataList><asp:Label ID="lblNada" runat="server" Text="NENHUM PRODUTO FOI ENCONTRADO" Visible="False"></asp:Label><asp:SqlDataSource ID="sqlPesq" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM produto WHERE (status_prod = 1) order by id_prod desc"></asp:SqlDataSource></div>

</asp:Content>
