<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="PerfilUsuario.aspx.cs" Inherits="PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

     <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2>PERFIL DO USUARIO</h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2>&nbsp;</h2></div>

            </div>
             <div id="InfoUser">
                   <asp:Image ID="imgUserPerfil" style="max-width: 120px; max-height: 140px;" runat="server" Height="140px" Width="120px" />
                   <div id="statususer">Status: <asp:Label ID="lblStatusUser" runat="server" Text="Status"></asp:Label></div>
                   <asp:Label ID="lblNomeUserPerfil" style=" margin-left: 20px;" runat="server" Text="NOME"></asp:Label>
                   <asp:SqlDataSource ID="SqlInfoUser" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, nome_user, sexo_user, status_user FROM usuario WHERE (id_user = @cod)">
                       <SelectParameters>
                           <asp:SessionParameter Name="cod" SessionField="idUserEscolhido" />
                       </SelectParameters>
                   </asp:SqlDataSource>
             </div>
             <div id="ProdUserPerfil">
                  
                   <h1>PRODUTOS DESTE USUARIO:</h1>
                       <div id="ImgProdPerfil" class="uk-container uk-container-center">
                           <div class="prod">
                             <div><asp:ImageButton class="imgProdTPerfil" ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" Height="140px" Width="190px" /></div>
                             <div class="padlink"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton></div>
                           </div>
                           <div class="prod">
                             <div><asp:ImageButton class="imgProdTPerfil" ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" Height="140px" Width="190px" /></div>
                             <div class="padlink"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">LinkButton</asp:LinkButton></div>
                           </div>
                           <div class="prod">
                             <div><asp:ImageButton class="imgProdTPerfil" ID="ImageButton3" runat="server" OnClick="ImageButton3_Click" Height="140px" Width="190px" /></div>
                             <div class="padlink"><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">LinkButton</asp:LinkButton></div>
                           </div>
                           <div class="prod">
                             <div><asp:ImageButton class="imgProdTPerfil" ID="ImageButton4" runat="server" OnClick="ImageButton4_Click" Height="140px" Width="190px" /></div>
                             <div class="padlink"><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">LinkButton</asp:LinkButton></div>
                           </div>
                           <div class="prod">
                             <div><asp:ImageButton class="imgProdTPerfil" ID="ImageButton5" runat="server" OnClick="ImageButton5_Click" Height="140px" Width="190px" /></div>
                             <div class="padlink"><asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">LinkButton</asp:LinkButton></div>
                           </div>
                       </div>
                 <asp:SqlDataSource ID="SqlProdUser" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_prod, id_user, nome_prod, valor_prod, sobre_prod, contem_prod, imagem_prod, arquivo_prod, status_prod FROM produto WHERE (id_user = @cod) AND (status_prod = 1) ORDER BY id_prod DESC">
                     <SelectParameters>
                         <asp:SessionParameter Name="cod" SessionField="idUserEscolhido" />
                     </SelectParameters>
                   </asp:SqlDataSource>
            </div>
         

         </div>

</asp:Content>

