<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="EditarConta.aspx.cs" Inherits="EditarConta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
    <script src="js/jquery.maskedinput.js"></script>
    <script src="js/components/tooltip.js"></script>
     <script src="js/forcaSenha.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

    
     <div id="boxGeral" class="uk-container uk-container-center">

         	<div class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2">
                     <h2 class="tituloEsquerda">Editar a minha conta</h2>

                       <div id="boxEsquerda" class="uk-container uk-container-center">

	                       <div class="uk-grid uk-grid-match uk-grid-small">

                              <div class="uk-width-1-1"><asp:TextBox name="user" ID="txtLogin" placeholder="Seu usuário" runat="server"></asp:TextBox></div>
                              <div class="uk-width-1-1"><asp:TextBox name="user" ID="txtNomeCompleto" placeholder="Seu nome completo" runat="server"></asp:TextBox></div>
                              <div class="uk-width-1-1"><asp:TextBox name="user" ID="txtEmail" placeholder="Seu e-mail" runat="server" CssClass="txtEmail"></asp:TextBox></div>
                              <div class="uk-icon-info-circle uk-icon-small iconeEmailInvalido" data-uk-tooltip="{animation: 'true', pos:'bottom', delay:'300'}" title="Email inválido"></div>
                              <div class="uk-width-1-1"><asp:TextBox name="user" ID="txtCpf" placeholder="Seu CPF" runat="server" CssClass="txtCpf"></asp:TextBox></div>
                              <div class="uk-width-1-1 uk-form">
                                <div class="cadSex">
                                 SEXO
                                 <asp:RadioButtonList ID="rblSexo" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="opSex">
                                     <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                                     <asp:ListItem Value="F">Feminino</asp:ListItem>
                                 </asp:RadioButtonList>
                                    </div>
                             </div>

                             <div class="uk-width-1-3"><asp:Button ID="btnEditar" runat="server" Text="SALVAR" OnClick="EDITAR_Click" /></div>

                            </div>

                        </div>
                 </div>


                  <asp:SqlDataSource ID="sqlPesquisa" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user FROM usuario WHERE (id_user = @idUser)">
                     <SelectParameters>
                         <asp:Parameter Name="idUser" />
                     </SelectParameters>
                 </asp:SqlDataSource>
                 <asp:SqlDataSource ID="sqlAlterarDados" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM usuario" UpdateCommand="UPDATE usuario SET login_user = @login, nome_user = @nome, email_user = @email, cpf_user = @cpf, sexo_user = @sexo WHERE (id_user = @codUser)">
                     <UpdateParameters>
                         <asp:Parameter Name="login" />
                         <asp:Parameter Name="nome" />
                         <asp:Parameter Name="email" />
                         <asp:Parameter Name="cpf" />
                         <asp:Parameter Name="sexo" />
                         <asp:Parameter Name="codUser" />
                     </UpdateParameters>
                 </asp:SqlDataSource>
                 <asp:SqlDataSource ID="sqlAlterarSenha" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT pass_user FROM usuario WHERE (id_user = @codUser)" UpdateCommand="UPDATE usuario SET pass_user = @novaSenha WHERE (id_user = @codUser)">
                     <SelectParameters>
                         <asp:SessionParameter Name="codUser" SessionField="idUser" />
                     </SelectParameters>
                     <UpdateParameters>
                         <asp:SessionParameter Name="codUser" SessionField="idUser" />
                         <asp:Parameter Name="novaSenha" />
                     </UpdateParameters>
                 </asp:SqlDataSource>
                 <asp:SqlDataSource ID="sqlExcluirConta" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [usuario]" UpdateCommand="UPDATE usuario SET status_user = 0 WHERE (id_user = @codUser)">
                     <UpdateParameters>
                         <asp:SessionParameter Name="codUser" SessionField="idUser" />
                     </UpdateParameters>
                 </asp:SqlDataSource>

                 <asp:SqlDataSource ID="sqlEmailCheckU" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user FROM usuario WHERE (email_user = @email)">
                     <SelectParameters>
                         <asp:Parameter Name="email" />
                     </SelectParameters>
                 </asp:SqlDataSource>
                 <asp:SqlDataSource ID="sqlCpfCheckU" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user FROM usuario WHERE (cpf_user = @cpf)">
                     <SelectParameters>
                         <asp:Parameter Name="cpf" />
                     </SelectParameters>
                 </asp:SqlDataSource>
                 <asp:SqlDataSource ID="sqlLoginCheckU" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user FROM usuario WHERE (login_user = @login)">
                     <SelectParameters>
                         <asp:Parameter Name="login" />
                     </SelectParameters>
                 </asp:SqlDataSource>


                 <div class="uk-width-1-2">
                     <h2 class="tituloDireita">Mudar a minha senha</h2>

                       <div id="boxDireita" class="uk-container uk-container-center">

	                         <div class="uk-grid uk-grid-match uk-grid-small">

                                  <div class="uk-width-1-1"> <asp:TextBox ID="txtPassAntigo" name="senha" placeholder="Sua senha atual" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox></div>
                                  <div class="uk-width-1-1"> <asp:TextBox ID="txtPass" name="senha" placeholder="Sua nova senha" runat="server" TextMode="Password" CssClass="txtSenha"></asp:TextBox></div>
                                <div class="uk-icon-info-circle uk-icon-small iconeSenhaForca" data-uk-tooltip="{animation: 'true', pos:'bottom', delay:'300'}" title="Fraca! Saiba mais."></div>
         <div class="uk-width-1-1"> 
            <section class="dicaSenha">
                <h4>Para uma senha adequada, siga:</h4>
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
                                 <div class="uk-width-1-3"> <asp:Button ID="btnSenhaConf" runat="server" Text="Confirmar" OnClick="btnSenhaConf_Click" /></div>

                                 <div class="uk-width-1-1">
                                           <div class="apagarConta">
                                               <a href="#" id="apagarConta"><i class="uk-icon-remove uk-icon-small"></i> Apagar a minha conta</a>
                                               <div class="btnsConfApagar">
                                                    <asp:Button ID="btnExConf" CssClass="btnConfApagar" runat="server" Text="Confirmar" OnClick="btnExConf_Click" />
                                                   <a href="#" class="btnCancApagar">Cancelar</a>
                                               </div>
                                          </div>
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

                 </div>

     </div>

         </div>

</asp:Content>

