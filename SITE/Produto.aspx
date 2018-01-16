<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="Produto.aspx.cs" Inherits="Produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
    	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">
    <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2>
                     <asp:Label ID="lblNomeProduto" runat="server" Text="Nome Produto"></asp:Label></h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2>&nbsp;</h2></div>

            </div>
       
                 <div id="imgTelaProdutos" style="height:180px; font-size: 14px;">
                     <asp:Image ID="imgProduto" runat="server" style=" float:left;max-height: 140px;max-width: 190px;margin-left: 20px;margin-bottom: 20px;margin-top: 20px;border: 1px solid #515151;border-bottom: 2px solid #f0082e;border-radius: 4px;" Height="140px" Width="190px"/>
                      <div style="float: left;margin-left: 20px;margin-bottom: 20px;margin-top: 20px;">
                          <div class="distribuidorArquivo"><div class="uk-icon-user"></div> DISTRIBUIDOR - <asp:LinkButton ID="lblDistribuidor" CssClass="linkDistribuidor" runat="server" Text="Distribuidor" OnClick="lblDistribuidor_Click"></asp:LinkButton></div>
                          <div id="tamanhoArquivo"><div class="uk-icon-hdd-o"></div> Tamanho do arquvio (zip) - <asp:Label ID="lblTamanho" runat="server" Text="Tamanho"></asp:Label></div>                  
                           <div id="precoArquivo" style="font-size: 30px;color: #f0082e;margin-top: 20px;">R$ <asp:Label ID="lblPreco" runat="server" Text="Preço"></asp:Label></div>
                          <asp:Button width="120px" ID="btnComprar" runat="server" Text="COMPRAR" CssClass="btnProd" OnClick="btnComprar_Click" />
                          <asp:Button width="120px" ID="btnEditar" CssClass="btnProd" runat="server" Text="EDITAR" OnClick="btnEditar_Click" />
                           <asp:Button width="160px" ID="btnMinhasCompras" CssClass="btnProd" runat="server" Text="MINHAS COMPRAS" OnClick="btnMinhasCompras_Click" />
        
                            </div>
                 </div>
       
                <div>
                    <asp:SqlDataSource ID="SqlProduto" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.id_prod, produto.id_user, produto.nome_prod, produto.valor_prod, produto.sobre_prod, produto.contem_prod, produto.imagem_prod, produto.arquivo_prod, produto.status_prod, produto.tamanho_prod, usuario.id_user AS Expr1, usuario.nome_user FROM produto INNER JOIN usuario ON produto.id_user = usuario.id_user WHERE (produto.id_prod = @cod)">
                        <SelectParameters>
                            <asp:SessionParameter Name="cod" SessionField="prodEscolhido" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="sqlVendido" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT venda.id_venda, venda.id_user, produto.id_prod FROM venda INNER JOIN prodvenda ON venda.id_venda = prodvenda.id_venda INNER JOIN produto ON prodvenda.id_prod = produto.id_prod WHERE (produto.id_prod = @idProd) AND (venda.id_user = @idUser)">
                        <SelectParameters>
                            <asp:Parameter Name="idProd" />
                            <asp:Parameter Name="idUser" />
                        </SelectParameters>
                    </asp:SqlDataSource>

            </div>
                <div id="infoProduto" style="margin-top: 30px;">
                 <ul class="uk-tab" data-uk-tab="{connect:'#tabProd'}">  
                     <li class="uk-active"><a href="#"><div class="uk-icon-list-ul"></div> SOBRE O PRODUTO</a></li>  
                     <li><a href="#" ><div class="uk-icon-folder-open-o"></div>  ESTE ARQUIVO CONTÉM</a></li>     
                 </ul>  

                 <ul id="tabProd" class="uk-switcher uk-margin">  
                     <li>
                        <asp:Label ID="lblSobre" runat="server" Text="Label"></asp:Label>
                     </li>  
                     <li>   
                        <asp:Label ID="lblContem" runat="server" Text="Label"></asp:Label>
                     </li>  
                 </ul>
                    </div>
        </div>
</asp:Content>

