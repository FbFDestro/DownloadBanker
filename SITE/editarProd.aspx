<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="editarProd.aspx.cs" Inherits="editarProd" %>



<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

    <!-- inicio box geral -->
     <div id="boxGeral" class="uk-container uk-container-center"> 

          <!-- inicio grid geral -->
         	<div class="uk-grid uk-grid-collapse">
                

                 <!-- inicio box esquerda -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloEsquerda">EDITAR SEU PRODUTO</h2>

                       <div id="boxEsquerda" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">
    
                             <div class="uk-width-1-1"><asp:TextBox ID="txtTitulo" placeholder="Título do arquívo" runat="server"></asp:TextBox></div>
                             <div class="uk-width-1-2"><asp:TextBox ID="txtPreco" placeholder="Preço (R$)" runat="server" ClientIDMode="Static"></asp:TextBox></div>
                             <div class="uk-width-1-2"> <asp:TextBox ID="txtTamanhoArqui" placeholder="Tamanho (ex: 256MB)" runat="server"></asp:TextBox></div>
                                
                                
                            <!-- conteudo box esquerda -->                            
                                
                            </div>

                       </div>

                 </div>


                   <!-- fim box esquerda -->


                  <!-- inicio box direita -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloDireita">&nbsp; &nbsp;</h2>

                       <div id="boxDireita" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">

                                <div class="uk-width-1-6"><p class="pUp">IMAGEM >></p></div>
                                <div class="uk-width-5-6"><asp:FileUpload ID="flImagem"  runat="server" /></div>
                                 <div class="uk-width-1-6 imgAtualLabel">ATUAL >> </div> 
                                  <div class="uk-width-2-6"><asp:Image ID="img" runat="server" CssClass="imgEditarProd" /></div>
                                



                            <!-- conteudo box direita -->        
                                
                            </div>
                           
                     </div>

                  </div>
                  <!-- fim box direita -->

                 <div class="uk-width-1-1">
                 <div id="boxCentro" class="uk-container uk-container-center">
                 <div class="uk-grid uk-grid-match uk-grid-small">

                  

                  <div class="uk-width-1-1"><textarea id="descricao" runat="server"><h1 style="text-align: center;"><img style="float: right;" src="imgs/DownloadBanker.png" alt="Logo" width="231" height="32" /></h1>
<h1 style="text-align: left;">DESCREVA O SEU PRODUTO</h1></textarea></div>
                    
                  <div class="uk-width-1-1"><textarea id="lista" runat="server"><h2><strong>Fa&ccedil;a uma lista do que cont&eacute;m o seu arquivo.</strong></h2>
<p><strong>Exemplo:</strong></p>
<ul>
<li>Arquivo 1 (txt)</li>
<li>Arquivo 2 (png)</li>
<li>Arquivo 3 (mp3)</li>
</ul></textarea></div>

                     <div class="uk-width-2-10"> <asp:Button ID="btnVoltar" CssClass="btnProd" runat="server" Text="VOLTAR" OnClick="btnVoltar_Click" /></div>
                    <div class="uk-width-2-10"> <asp:Button ID="btnPublicar" CssClass="btnProd" runat="server" Text="EDITAR" OnClick="btnPublicar_Click" />
                        <asp:SqlDataSource ID="sqlCarregaProd" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_prod, id_user, nome_prod, valor_prod, sobre_prod, contem_prod, imagem_prod, arquivo_prod, status_prod, tamanho_prod FROM produto WHERE (id_prod = @codProd)">
                            <SelectParameters>
                                <asp:SessionParameter Name="codProd" SessionField="codProdSel" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                     </div>

                 </div>
                 </div>
                 </div>

                 <asp:SqlDataSource ID="sqlEditar" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [produto]" UpdateCommand="UPDATE produto SET nome_prod = @titulo, valor_prod = @preco, sobre_prod = @desc , contem_prod = @lista, tamanho_prod = @tamanho, imagem_prod = @imagem WHERE (id_prod = @codProd)">
                     <UpdateParameters>
                         <asp:Parameter Name="titulo" />
                         <asp:Parameter Name="tamanho" />
                         <asp:Parameter Name="preco" />
                         <asp:Parameter Name="imagem" />
                         <asp:Parameter Name="lista" />
                         <asp:Parameter Name="desc" />
                         <asp:SessionParameter Name="codProd" SessionField="codProdSel" />
                     </UpdateParameters>
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

            </div>
         <!-- fim grid geral -->

       </div> <!-- fim box geral -->



</asp:Content>

