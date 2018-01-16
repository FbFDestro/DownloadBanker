<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="VenderSelCategoria.aspx.cs" Inherits="VenderSelCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

    <!-- inicio box geral -->
     <div id="boxGeral" class="uk-container uk-container-center"> 

          <!-- inicio grid geral -->
         	<div class="uk-grid uk-grid-collapse">
                

                 <!-- inicio box esquerda -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloEsquerda"><div class="uk-icon-file"></div> &nbsp;CATEGORIAS DE TIPO >> <asp:Label ID="lblTipoTitulo" runat="server" Text="Label"></asp:Label></h2></h2>

                       <div id="boxEsquerda" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">
    
                            <!-- conteudo box esquerda -->  

                                  <div class="uk-width-1-1 selCat">Selecione a categoria em que seu produto se encaixa: </div>
                                
                      <asp:ListBox ID="lbCategoria" runat="server"  DataTextField="nome_cat" DataValueField="id_cat" CssClass="listCats"></asp:ListBox>

                                   <div class="uk-width-1-3"> <asp:Button ID="btnVoltar" runat="server" Text="VOLTAR" OnClick="btnVoltar_Click" /></div>
           <div class="uk-width-1-3"> <asp:Button ID="btnProsseguir" runat="server" Text="PROSSEGUIR" OnClick="btnProsseguir_Click" />    </div>                     
                                
                            </div>

                       </div>

                 </div>
                   <!-- fim box esquerda -->


                  <!-- inicio box direita -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloDireita">Crie uma nova categoria</h2>

                       <div id="boxDireita" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">

                            <!-- conteudo box direita -->    
                                
                                 <div class="uk-width-1-1 selCat">Caso necessário, crie uma nova categoria:</div>    

                                 
               <div class="uk-width-2-3">  <asp:TextBox ID="txtNovaCat" placeholder="Nome da categoria" runat="server"></asp:TextBox><br /></div>
               <div class="uk-width-1-3"> <asp:Button ID="btnCriar" runat="server" Text="CONTINUAR" OnClick="btnCriar_Click" /></div>
                                

                                <br />

                                 <div class="uk-width-1-1"><img id="imgAnuncioApp" src="imgs/anuncioApp.jpg" alt="Baixe o app android" /> </div>


                            </div>
                           
                     </div>

                  </div>
                  <!-- fim box direita -->

            </div>
         <!-- fim grid geral -->

       </div> <!-- fim box geral -->



    <asp:SqlDataSource ID="sqlCarregarTipo" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT categoria.id_cat, categoria.nome_cat FROM categoria INNER JOIN tipocategoria ON categoria.id_cat = tipocategoria.id_cat INNER JOIN tipo ON tipocategoria.id_tipo = tipo.id_tipo WHERE (tipocategoria.id_tipo = @tipo)">
        <SelectParameters>
            <asp:SessionParameter Name="tipo" SessionField="idTipoArquivo" />
        </SelectParameters>
    </asp:SqlDataSource>

    



    <asp:SqlDataSource ID="sqlCriarCat" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO categoria(id_cat, nome_cat) VALUES (@idNovaCategoria, @tituloNovaCategoria)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM categoria">
        <InsertParameters>
            <asp:QueryStringParameter Name="idNovaCategoria" QueryStringField="idNovaCategoria" />
            <asp:Parameter Name="tituloNovaCategoria" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlCriarTipoCat" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO tipocategoria(id_tipo, id_cat) VALUES (@idTipo,@idCat)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM tipocategoria">
        <InsertParameters>
            <asp:SessionParameter Name="idTipo" SessionField="idTipoArquivo" />
            <asp:SessionParameter Name="idCat" SessionField="idNovaCat" />
        </InsertParameters>
    </asp:SqlDataSource>

    



                 <asp:SqlDataSource ID="sqlAud" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO auditoriau(data_audU, hora_audU, id_user, acao_audU, desc_audU) VALUES (@data,@hora,@id,@acao,@desc)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [auditoriau]">
                     <InsertParameters>
                         <asp:Parameter Name="data" />
                         <asp:Parameter Name="hora" />
                         <asp:Parameter Name="id" />
                         <asp:Parameter Name="acao" />
                         <asp:Parameter Name="desc" />
                     </InsertParameters>
                 </asp:SqlDataSource>

                



</asp:Content>