<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">

    	<script src="js/components/slideshow.js"></script>
        <script src="js/components/slideshow-fx.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">


    <div class="uk-container uk-container-center">



	<div class="categorias">

		<div class="uk-grid uk-grid-collapse">
		<a class="CatTipos uk-width-xlarge-4-10 uk-width-large-1-1 uk-width-medium-1-1" href="#categorias">Selecione um tipo</a>
		<a class="CatAudios uk-width-xlarge-1-10 uk-width-large-1-6 uk-width-medium-1-3" href="/tipo.aspx?cod=1">Áudio</a>
		<a class="CatImagens uk-width-xlarge-1-10 uk-width-large-1-6 uk-width-medium-1-3" href="/tipo.aspx?cod=2">Imagens</a>
		<a class="CatProgramas uk-width-xlarge-1-10 uk-width-large-1-6 uk-width-medium-1-3" href="/tipo.aspx?cod=3">Programas</a>
		<a class="CatTextos uk-width-xlarge-1-10 uk-width-large-1-6 uk-width-medium-1-3" href="/tipo.aspx?cod=4">Textos</a>
		<a class="CatVideos uk-width-xlarge-1-10 uk-width-large-1-6 uk-width-medium-1-3" href="/tipo.aspx?cod=5">Vídeos</a>
		<a class="CatOutros uk-width-xlarge-1-10 uk-width-large-1-6 uk-width-medium-1-3" href="/tipo.aspx?cod=6">Outros</a>
		</div>
	</div>





        <div class="tituloDivisao">ÚLTIMOS PUBLICADOS</div>
		<div class="linhaDivisao"></div>

              <asp:DataList ID="dlUltimosP" runat="server" DataKeyField="id_prod" RepeatColumns="4" RepeatDirection="Horizontal" CellSpacing="5">

                                <ItemTemplate>
                                     
                                    <asp:HyperLink ID="hlItens" runat="server" NavigateUrl='<%# Eval("id_prod", "Produto.aspx?cod={0}") %>'>

                                    <asp:Image ID="imgProd" runat="server" ImageUrl='<%# Eval("imagem_prod") %>' />

                           

                                    <div class="tituloProd"><asp:Label ID="nome_prodLabel" runat="server" Text='<%# Eval("nome_prod") %>' /></div>

       
                                    <div class="precoProd">R$ <asp:Label ID="valor_prodLabel" runat="server" Text='<%# Eval("valor_prod") %>' /></div>

                                        </asp:HyperLink></ItemTemplate></asp:DataList><asp:SqlDataSource ID="sqlUltimos" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_prod, id_user, nome_prod, valor_prod, sobre_prod, contem_prod, imagem_prod, arquivo_prod, status_prod, tamanho_prod FROM produto WHERE (status_prod = 1) order by id_prod desc limit 4"></asp:SqlDataSource>

     <div class="tituloDivisao">ÚLTIMOS PUBLICADOS EM TEXTOS <div class="lerMaisDiv"><a href="\Tipo.aspx?cod=4">ver mais</a></div></div><div class="linhaDivisao"></div>

      <asp:DataList ID="dlUltimosPTextos" runat="server" DataKeyField="id_prod" RepeatColumns="4" RepeatDirection="Horizontal" CellSpacing="5"><ItemTemplate>
                                     
                                    <asp:HyperLink ID="hlItens" runat="server" NavigateUrl='<%# Eval("id_prod", "Produto.aspx?cod={0}") %>'>

                                    <asp:Image ID="imgProd" runat="server" ImageUrl='<%# Eval("imagem_prod") %>' />

                           

                                    <div class="tituloProd"><asp:Label ID="nome_prodLabel" runat="server" Text='<%# Eval("nome_prod") %>' /></div>

       
                                    <div class="precoProd">R$ <asp:Label ID="valor_prodLabel" runat="server" Text='<%# Eval("valor_prod") %>' /></div>

                                        </asp:HyperLink></ItemTemplate></asp:DataList><asp:SqlDataSource ID="sqlUltimosPT" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.id_prod, produto.id_user, produto.nome_prod, produto.valor_prod, produto.sobre_prod, produto.contem_prod, produto.imagem_prod, produto.arquivo_prod, produto.status_prod, produto.tamanho_prod, tipo.id_tipo FROM produto INNER JOIN prodtipo ON produto.id_prod = prodtipo.id_prod INNER JOIN tipo ON prodtipo.id_tipo = tipo.id_tipo WHERE (tipo.id_tipo = 4) and (produto.status_prod = 1) order by produto.id_prod desc limit 4"></asp:SqlDataSource>



         <div class="tituloDivisao">ÚLTIMOS PUBLICADOS EM ÁUDIOS <div class="lerMaisDiv"><a href="\Tipo.aspx?cod=1">ver mais</a></div></div><div class="linhaDivisao"></div>

      <asp:DataList ID="dlUA" runat="server" DataKeyField="id_prod" RepeatColumns="4" RepeatDirection="Horizontal" CellSpacing="5"><ItemTemplate>
                                     
                                    <asp:HyperLink ID="hlItens" runat="server" NavigateUrl='<%# Eval("id_prod", "Produto.aspx?cod={0}") %>'>

                                    <asp:Image ID="imgProd" runat="server" ImageUrl='<%# Eval("imagem_prod") %>' />

                           

                                    <div class="tituloProd"><asp:Label ID="nome_prodLabel" runat="server" Text='<%# Eval("nome_prod") %>' /></div>

       
                                    <div class="precoProd">R$ <asp:Label ID="valor_prodLabel" runat="server" Text='<%# Eval("valor_prod") %>' /></div>

                                        </asp:HyperLink></ItemTemplate></asp:DataList><asp:SqlDataSource ID="sqlUltimosPA" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.id_prod, produto.id_user, produto.nome_prod, produto.valor_prod, produto.sobre_prod, produto.contem_prod, produto.imagem_prod, produto.arquivo_prod, produto.status_prod, produto.tamanho_prod, tipo.id_tipo FROM produto INNER JOIN prodtipo ON produto.id_prod = prodtipo.id_prod INNER JOIN tipo ON prodtipo.id_tipo = tipo.id_tipo WHERE (tipo.id_tipo = 1) and (produto.status_prod = 1) order by produto.id_prod desc limit 4"></asp:SqlDataSource>



        
         <div class="tituloDivisao">ÚLTIMOS PUBLICADOS EM VÍDEOS <div class="lerMaisDiv"><a href="\Tipo.aspx?cod=5">ver mais</a></div></div><div class="linhaDivisao"></div>

      <asp:DataList ID="dlUV" runat="server" DataKeyField="id_prod" RepeatColumns="4" RepeatDirection="Horizontal" CellSpacing="5"><ItemTemplate>
                                     
                                    <asp:HyperLink ID="hlItens" runat="server" NavigateUrl='<%# Eval("id_prod", "Produto.aspx?cod={0}") %>'>

                                    <asp:Image ID="imgProd" runat="server" ImageUrl='<%# Eval("imagem_prod") %>' />

                           

                                    <div class="tituloProd"><asp:Label ID="nome_prodLabel" runat="server" Text='<%# Eval("nome_prod") %>' /></div>

       
                                    <div class="precoProd">R$ <asp:Label ID="valor_prodLabel" runat="server" Text='<%# Eval("valor_prod") %>' /></div>

                                        </asp:HyperLink></ItemTemplate></asp:DataList><asp:SqlDataSource ID="sqlUltimosPV" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.id_prod, produto.id_user, produto.nome_prod, produto.valor_prod, produto.sobre_prod, produto.contem_prod, produto.imagem_prod, produto.arquivo_prod, produto.status_prod, produto.tamanho_prod, tipo.id_tipo FROM produto INNER JOIN prodtipo ON produto.id_prod = prodtipo.id_prod INNER JOIN tipo ON prodtipo.id_tipo = tipo.id_tipo WHERE (tipo.id_tipo = 5) and (produto.status_prod = 1) order by produto.id_prod desc limit 4"></asp:SqlDataSource>



            <div class="tituloDivisao">ÚLTIMOS PUBLICADOS EM IMAGENS <div class="lerMaisDiv"><a href="\Tipo.aspx?cod=2">ver mais</a></div></div><div class="linhaDivisao"></div>

      <asp:DataList ID="dlUI" runat="server" DataKeyField="id_prod" RepeatColumns="4" RepeatDirection="Horizontal" CellSpacing="5"><ItemTemplate>
                                     
                                    <asp:HyperLink ID="hlItens" runat="server" NavigateUrl='<%# Eval("id_prod", "Produto.aspx?cod={0}") %>'>

                                    <asp:Image ID="imgProd" runat="server" ImageUrl='<%# Eval("imagem_prod") %>' />

                           

                                    <div class="tituloProd"><asp:Label ID="nome_prodLabel" runat="server" Text='<%# Eval("nome_prod") %>' /></div>

       
                                    <div class="precoProd">R$ <asp:Label ID="valor_prodLabel" runat="server" Text='<%# Eval("valor_prod") %>' /></div>

                                        </asp:HyperLink></ItemTemplate></asp:DataList><asp:SqlDataSource ID="sqlUltimosPI" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.id_prod, produto.id_user, produto.nome_prod, produto.valor_prod, produto.sobre_prod, produto.contem_prod, produto.imagem_prod, produto.arquivo_prod, produto.status_prod, produto.tamanho_prod, tipo.id_tipo FROM tipo INNER JOIN prodtipo ON tipo.id_tipo = prodtipo.id_tipo INNER JOIN produto ON prodtipo.id_prod = produto.id_prod WHERE (tipo.id_tipo = 2) and (produto.status_prod = 1) order by produto.id_prod desc limit 4"></asp:SqlDataSource>


        
            <div class="tituloDivisao">ÚLTIMOS PUBLICADOS EM PROGRAMAS <div class="lerMaisDiv"><a href="\Tipo.aspx?cod=3">ver mais</a></div></div><div class="linhaDivisao"></div>

      <asp:DataList ID="dlUP" runat="server" DataKeyField="id_prod" RepeatColumns="4" RepeatDirection="Horizontal" CellSpacing="5"><ItemTemplate>
                                     
                                    <asp:HyperLink ID="hlItens" runat="server" NavigateUrl='<%# Eval("id_prod", "Produto.aspx?cod={0}") %>'>

                                    <asp:Image ID="imgProd" runat="server" ImageUrl='<%# Eval("imagem_prod") %>' />

                           

                                    <div class="tituloProd"><asp:Label ID="nome_prodLabel" runat="server" Text='<%# Eval("nome_prod") %>' /></div>

       
                                    <div class="precoProd">R$ <asp:Label ID="valor_prodLabel" runat="server" Text='<%# Eval("valor_prod") %>' /></div>

                                        </asp:HyperLink></ItemTemplate></asp:DataList><asp:SqlDataSource ID="sqlUltimosPP" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.id_prod, produto.id_user, produto.nome_prod, produto.valor_prod, produto.sobre_prod, produto.contem_prod, produto.imagem_prod, produto.arquivo_prod, produto.status_prod, produto.tamanho_prod, tipo.id_tipo FROM produto INNER JOIN prodtipo ON produto.id_prod = prodtipo.id_prod INNER JOIN tipo ON prodtipo.id_tipo = tipo.id_tipo WHERE (tipo.id_tipo = 3) and (produto.status_prod = 1) order by produto.id_prod desc limit 4"></asp:SqlDataSource>


             <div class="tituloDivisao">ÚLTIMOS PUBLICADOS EM OUTROS <div class="lerMaisDiv"><a href="\Tipo.aspx?cod=6">ver mais</a></div></div><div class="linhaDivisao"></div>

      <asp:DataList ID="dlUO" runat="server" DataKeyField="id_prod" RepeatColumns="4" RepeatDirection="Horizontal" CellSpacing="5"><ItemTemplate>
                                     
                                    <asp:HyperLink ID="hlItens" runat="server" NavigateUrl='<%# Eval("id_prod", "Produto.aspx?cod={0}") %>'>

                                    <asp:Image ID="imgProd" runat="server" ImageUrl='<%# Eval("imagem_prod") %>' />

                           

                                    <div class="tituloProd"><asp:Label ID="nome_prodLabel" runat="server" Text='<%# Eval("nome_prod") %>' /></div>

       
                                    <div class="precoProd">R$ <asp:Label ID="valor_prodLabel" runat="server" Text='<%# Eval("valor_prod") %>' /></div>

                                        </asp:HyperLink></ItemTemplate></asp:DataList><asp:SqlDataSource ID="sqlUltimosPO" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.id_prod, produto.id_user, produto.nome_prod, produto.valor_prod, produto.sobre_prod, produto.contem_prod, produto.imagem_prod, produto.arquivo_prod, produto.status_prod, produto.tamanho_prod, tipo.id_tipo FROM produto INNER JOIN prodtipo ON produto.id_prod = prodtipo.id_prod INNER JOIN tipo ON prodtipo.id_tipo = tipo.id_tipo WHERE (tipo.id_tipo = 6) and (produto.status_prod = 1) order by produto.id_prod desc limit 4"></asp:SqlDataSource>









</div>
</asp:Content>

