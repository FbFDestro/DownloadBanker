<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="VenderSelTipo.aspx.cs" Inherits="VenderSelTipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

      <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2>Selecione o tipo de produto</h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2>&nbsp;</h2></div>

            </div>

           <div id="venderSelTipo" class="uk-grid uk-grid-match uk-grid-medium">





                        <div class="uk-width-1-1">
                            <div id="selecionarTipo">
                                <a href="#">Antes de criar um anúncio, é necessario selecionar o tipo de arquivo, a categoria e o gênero ao qual o seu produto pertence:</a> 
                            </div>
                       </div>




                    <div class="uk-width-1-2">       
         <asp:LinkButton ID="linkAudio" runat="server" OnClick="linkAudio_Click" CssClass="linkTipo">
               <div class="imgTipos"><img src="imgs/icones/audioI.png" alt="Áudios" /></div><div class="textoTipos">Áudio</div>

         </asp:LinkButton>    
                    </div>
                   
                   <div class="uk-width-1-2">
             <asp:LinkButton ID="linkImagens" runat="server" OnClick="linkImagens_Click" CssClass="linkTipo">
              <div class="imgTipos"><img src="imgs/icones/fotosI.png" alt="Imagens" /></div><div class="textoTipos">Imagens</div>
             </asp:LinkButton>
                    </div>
                   
                   <div class="uk-width-1-2">
              <asp:LinkButton ID="linkProgramas" runat="server" OnClick="linkProgramas_Click" CssClass="linkTipo">
               <div class="imgTipos"><img src="imgs/icones/programaI.png" alt="Programas" /></div><div class="textoTipos">Programas</div>

              </asp:LinkButton>
           
             </div>
                   
                   <div class="uk-width-1-2">
             <asp:LinkButton ID="linkTextos" runat="server" OnClick="linkTextos_Click" CssClass="linkTipo">
                  <div class="imgTipos"><img src="imgs/icones/textoI.png" alt="Textos" /></div><div class="textoTipos">Textos</div>

             </asp:LinkButton>
          
             </div>
                   
                   <div class="uk-width-1-2">
              <asp:LinkButton ID="LinkVideos" runat="server" OnClick="LinkVideos_Click" CssClass="linkTipo">
                  <div class="imgTipos"><img src="imgs/icones/videoI.png" alt="Vídeos" /></div><div class="textoTipos">Vídeos</div>


              </asp:LinkButton>
            
             </div>
                   
                   <div class="uk-width-1-2">
              <asp:LinkButton ID="LinkOutros" runat="server" OnClick="LinkOutros_Click" CssClass="linkTipo">
                    <div class="imgTipos"><img src="imgs/icones/outroI.png" alt="Outros" /></div><div class="textoTipos">Outros</div>

              </asp:LinkButton>
                 </div>



           </div>
        

         </div>

</asp:Content>
