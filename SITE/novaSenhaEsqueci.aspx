<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="novaSenhaEsqueci.aspx.cs" Inherits="novaSenhaEsqueci" %>


<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
    <script src="js/jquery.maskedinput.js"></script>
    <script src="js/components/tooltip.js"></script>
    <script src="js/forcaSenha.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

    <!-- inicio box geral -->
     <div id="boxGeral" class="uk-container uk-container-center"> 

          <!-- inicio grid geral -->
         	<div class="uk-grid uk-grid-collapse">
                

                 <!-- inicio box esquerda -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloEsquerda">CADASTRAR UMA NOVA SENHA</h2>

                       <div id="boxEsquerda" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">
    
                            <!-- conteudo box esquerda -->  
              <div id="confirmarDados"><h5><div class="uk-icon-exclamation-triangle uk-icon-small"></div>
            CONFIRME SEUS DADOS:</h5></div>                  
          <div class="uk-width-1-1"><asp:TextBox name="user" ID="txtLogin" placeholder="Seu usuário" runat="server"></asp:TextBox></div>                          
          <div class="uk-width-1-1"><asp:TextBox name="user" ID="txtNome" placeholder="Seu nome completo" runat="server"></asp:TextBox></div>
          <div class="uk-width-1-1"><asp:TextBox name="user" ID="txtEmail" placeholder="Seu e-mail" runat="server" CssClass="txtEmail"></asp:TextBox></div>
          <div class="uk-width-1-1"><asp:TextBox name="user" ID="txtCpf" placeholder="Seu CPF" runat="server" CssClass="txtCpf"></asp:TextBox></div>
        
                            </div>

                       </div>

                 </div>
                   <!-- fim box esquerda -->


                  <!-- inicio box direita -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloDireita">&nbsp;</h2>

                       <div id="boxDireita" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">

        <div id="confirmarDados"><h5><div class="uk-icon-lock uk-icon-small"></div>
             DIGITE UMA NOVA SENHA:</h5></div>     

                            <!-- conteudo box direita -->       
                                   <div class="uk-width-1-1"> 
                                       <asp:SqlDataSource ID="sqlEsqueci" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user, status_user FROM usuario WHERE (cpf_user = @cpf)" UpdateCommand="UPDATE usuario SET pass_user = @novaSenha WHERE (cpf_user = @cpf)">
                                           <SelectParameters>
                                               <asp:Parameter Name="cpf" />
                                           </SelectParameters>
                                           <UpdateParameters>
                                               <asp:Parameter Name="novaSenha" />
                                               <asp:Parameter Name="cpf" />
                                           </UpdateParameters>
                                       </asp:SqlDataSource>
                                       <asp:TextBox ID="txtPass" name="senha" placeholder="Sua nova senha" runat="server" TextMode="Password" CssClass="txtSenha"></asp:TextBox></div>
                                <div class="uk-icon-info-circle uk-icon-small iconeSenhaForca" data-uk-tooltip="{animation: 'true', pos:'bottom', delay:'300'}" title="Fraca! Saiba mais."></div>
         <div class="uk-width-1-1"> 
            <section class="dicaSenha">
                <h4>Para uma senha adequada, siga:/h4>
             <ul>
                 <li>No mínimo 6 caracteres;</li>
                 <li>Letras minúsculas;</li>
                 <li>Letras maiúisculas;</li>
                 <li>Números;</li>
                 <li>Caracteres especiais.</li>
             </ul>
                </section>
         </div>
                                   <div class="uk-width-1-1"> <asp:TextBox ID="txtPassConfirm" name="senha" placeholder="Confirme a sua nova senha" runat="server" TextMode="Password" CssClass="txtSenhaConf"></asp:TextBox></div>
                              <div class="uk-icon-info-circle uk-icon-small iconeSenhaDiferente" data-uk-tooltip="{animation: 'true', pos:'bottom', delay:'300'}" title="As senhas não coincidem"></div> 
                             
                                  <div class="uk-width-1-3"><asp:Button ID="btnMudar" runat="server" Text="SALVAR" OnClick="btnMudar_Click"/> 
                                
                            </div>
                           
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

                  </div>
                  <!-- fim box direita -->

            </div>
         <!-- fim grid geral -->

       </div> <!-- fim box geral -->



</asp:Content>

