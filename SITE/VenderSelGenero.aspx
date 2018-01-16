<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="VenderSelGenero.aspx.cs" Inherits="VenderSelGenero" %>


<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

    <!-- inicio box geral -->
     <div id="boxGeral" class="uk-container uk-container-center"> 

          <!-- inicio grid geral -->
         	<div class="uk-grid uk-grid-collapse">
                

                 <!-- inicio box esquerda -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloEsquerda"><div class="uk-icon-file"></div> &nbsp;GÊNEROS DE CATEGORIA >> <asp:Label ID="lblCategoriaTitulo" runat="server" Text="Label"></asp:Label></h2>

                       <div id="boxEsquerda" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">
    
                            <!-- conteudo box esquerda -->  

                                  <div class="uk-width-1-1 selCat">Selecione o gênero em que seu produto se encaixa: </div>
                                
                      <asp:ListBox ID="lbGenero" runat="server"  DataTextField="nome_genero" DataValueField="id_genero" CssClass="listCats"></asp:ListBox>

                                   <div class="uk-width-1-3"> <asp:Button ID="btnVoltar" runat="server" Text="VOLTAR" OnClick="btnVoltar_Click" /></div>
           <div class="uk-width-1-3"> <asp:Button ID="btnProsseguir" runat="server" Text="PROSSEGUIR" OnClick="btnProsseguir_Click" />    </div>                     
                                
                            </div>

                       </div>

                 </div>
                   <!-- fim box esquerda -->


                  <!-- inicio box direita -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloDireita">Crie um novo gênero</h2>

                       <div id="boxDireita" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">

                            <!-- conteudo box direita -->    
                                
                                 <div class="uk-width-1-1 selCat">Caso necessário, crie um novo gênero:</div>    

                                 
               <div class="uk-width-2-3">  <asp:TextBox ID="txtNovoGenero" placeholder="Nome do gênero" runat="server"></asp:TextBox><br /></div>
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



    <asp:SqlDataSource ID="sqlCarregarGenero" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT genero.id_genero, genero.nome_genero FROM genero INNER JOIN categoriagenero ON genero.id_genero = categoriagenero.id_genero INNER JOIN categoria ON categoriagenero.id_cat = categoria.id_cat WHERE (categoria.id_cat = @cat)">
        <SelectParameters>
            <asp:SessionParameter Name="cat" SessionField="idCategoriaArquivo" />
        </SelectParameters>
    </asp:SqlDataSource>

    



    <asp:SqlDataSource ID="sqlCriarGen" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO genero(id_genero, nome_genero) VALUES (@idGen, @titGen)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM genero">
        <InsertParameters>
            <asp:SessionParameter Name="idGen" SessionField="idNovoGen" />
            <asp:Parameter Name="titGen" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlCriarCatGen" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO categoriagenero(id_cat, id_genero) VALUES (@idCat,@idGen)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM categoriagenero">
        <InsertParameters>
            <asp:SessionParameter Name="idCat" SessionField="idCategoriaArquivo" />
            <asp:SessionParameter Name="idGen" SessionField="idGeneroArquivo" />
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