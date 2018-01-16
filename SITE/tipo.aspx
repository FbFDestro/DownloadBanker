<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="tipo.aspx.cs" Inherits="tipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

      <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2><asp:Label ID="lblTipo" runat="server" Text="Label"></asp:Label></h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2>&nbsp;</h2></div>

            </div>

  <!-- conteudo da página -->
        <br />

            <asp:DataList ID="dlTodosCat" runat="server" DataKeyField="id_prod" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="5">
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

                                        </asp:HyperLink></ItemTemplate></asp:DataList><asp:SqlDataSource ID="sqlTodos" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.id_prod, tipo.id_tipo, tipo.nome_tipo, produto.nome_prod, produto.valor_prod, produto.imagem_prod, produto.status_prod FROM tipo INNER JOIN prodtipo ON tipo.id_tipo = prodtipo.id_tipo INNER JOIN produto ON prodtipo.id_prod = produto.id_prod WHERE (produto.status_prod = 1) AND (tipo.id_tipo = @tipo)"><SelectParameters><asp:QueryStringParameter Name="tipo" QueryStringField="cod" /></SelectParameters></asp:SqlDataSource></div>

</asp:Content>
