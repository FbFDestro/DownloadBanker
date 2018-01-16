<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="erro500.aspx.cs" Inherits="erro400" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

      <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2>ERRO DE CONEXÃO AO BANCO DE DADOS</h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2>&nbsp;</h2></div>

            </div>

  <!-- conteudo da página -->
        
          <div class="erroBd">
        <img src="imgs/erroBD.png" alt="Erro na conexão" />
              <h3>TENTE NOVAMENTE MAIS TARDE, OBRIGADO.</h3>
          </div>

         </div>

</asp:Content>

