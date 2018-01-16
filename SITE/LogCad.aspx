<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="LogCad.aspx.cs" Inherits="LogCad" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" runat="Server">
    <script src="js/jquery.maskedinput.js"></script>
    <script src="js/components/tooltip.js"></script>
    <script src="js/forcaSenha.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" runat="Server">

    <div id="boxGeral" class="uk-container uk-container-center">

        <div class="uk-grid uk-grid-collapse">

            <div class="uk-width-1-2">

                <h2 class="tituloEsquerda">Entrar na minha conta</h2>

                <div id="boxEsquerda" class="uk-container uk-container-center">

                    <div class="uk-grid uk-grid-match uk-grid-small">

                        <div class="uk-width-1-1">
                            <asp:TextBox name="user" ID="txtLoginLog" placeholder="Seu usuário" runat="server"></asp:TextBox></div>
                        <div class="uk-width-1-1">
                            <asp:TextBox ID="txtSenhaLog" name="senha" placeholder="Sua senha" runat="server" TextMode="Password"></asp:TextBox></div>
                        <div class="uk-width-1-3">
                            <asp:Button ID="btnLoginLog" runat="server" Text="ENTRAR" OnClick="btnLogin_Click" />
                            <asp:TextBox ID="txtCaptcha" runat="server" placeholder="DIGITE O CÓDIGO"></asp:TextBox>
                        </div>
                        <div class="uk-width-2-3 esqueciSenhaBar">
                            <asp:LinkButton ID="lbEsqueciSenhaLog" runat="server" OnClick="lbEsqueciSenhaLog_Click">Esqueci a minha senha</asp:LinkButton>
                        </div>
                        <!-- Captcha -->

                        <asp:Panel ID="pnlCaptcha" runat="server">


                            <div class="uk-width-1-1 captcha">
                                <cc1:CaptchaControl ID="Captcha1" CssClass="imgCap" runat="server" CaptchaBackgroundNoise="high" CaptchaLength="5"
                                    CaptchaHeight="60" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                    FontColor="#f0082e" NoiseColor="#585858" />


                                <asp:ImageButton CssClass="relCap" ImageUrl="~/refresh.png" runat="server" CausesValidation="false" />



                                <asp:Button ID="btnSubmit" CssClass="btnCap" runat="server" Text="ENTRAR" OnClick="btnLogin_Click" />

                            </div>
                              <asp:CustomValidator ErrorMessage="" OnServerValidate="ValidateCaptcha" ID="erroCap" runat="server" /> 

                        </asp:Panel>
                        <!-- Captcha -->
                       
                    </div>


                     <asp:Panel ID="pnlEsqueci" runat="server">

                        <div class="uk-width-1-1"><h4 class="esqueciTitulo">Recupere a sua senha!</h4></div>
                            
                            <asp:TextBox CssClass="uk-width-1-1" name="user" ID="txtEmailEsqueci" placeholder="Seu e-mail" runat="server"></asp:TextBox>
                         
                           <asp:Button CssClass="uk-width-1-3" ID="btnEnviarEsqueci" runat="server" Text="ENVIAR" OnClick="btnEnviarEsqueci_Click"/>

                         <asp:SqlDataSource ID="sqlEmailEsqueci" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user, status_user FROM usuario WHERE (email_user = @email)">
                             <SelectParameters>
                                 <asp:Parameter Name="email" />
                             </SelectParameters>
                         </asp:SqlDataSource>

                        </asp:Panel>


                    <asp:Panel ID="pnlImgAnuncio" runat="server">
                    <div class="uk-width-1-1">
                        <img id="imgAnuncioAppPequeno" src="imgs/anuncioAppPequeno.jpg" alt="Baixar o app android" />
                    </div>
                    </asp:Panel>

                    <asp:SqlDataSource ID="sqlLogin" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="MySql.Data.MySqlClient" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user, status_user FROM usuario WHERE (login_user = @login) AND (pass_user = @senha)">
                        <SelectParameters>
                            <asp:Parameter Name="login" />
                            <asp:Parameter Name="senha" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                </div>

            </div>


            <div class="uk-width-1-2">
                <h2 class="tituloDireita">Fazer o meu cadastro</h2>

                <div id="boxDireita" class="uk-container uk-container-center">

                    <div class="uk-grid uk-grid-match uk-grid-small">

                        <div class="uk-width-1-1">
                            <asp:TextBox name="user" ID="txtLoginCad" placeholder="Seu usuário" runat="server"></asp:TextBox></div>
                        <div class="uk-width-1-1">
                            <asp:TextBox ID="txtSenhaCad" name="senha" placeholder="Sua senha" runat="server" TextMode="Password" CssClass="txtSenha"></asp:TextBox></div>
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
                        <div class="uk-width-1-1">
                            <asp:TextBox ID="txtConfSenhaCad" name="senha" placeholder="Confirme a sua senha" runat="server" TextMode="Password" CssClass="txtSenhaConf"></asp:TextBox>
                        </div>
                        <div class="uk-icon-info-circle uk-icon-small iconeSenhaDiferente" data-uk-tooltip="{animation: 'true', pos:'bottom', delay:'300'}" title="As senhas não coincidem"></div>
                        <div class="uk-width-1-1">
                            <asp:TextBox name="user" ID="txtNomeCad" placeholder="Seu nome completo" runat="server"></asp:TextBox></div>
                        <div class="uk-width-1-1">
                            <asp:TextBox name="user" ID="txtEmailCad" placeholder="Seu e-mail" runat="server" CssClass="txtEmail"></asp:TextBox></div>
                        <div class="uk-icon-info-circle uk-icon-small iconeEmailInvalido" data-uk-tooltip="{animation: 'true', pos:'bottom', delay:'300'}" title="Email inválido"></div>
                        <div class="uk-width-1-1">
                            <asp:TextBox name="user" ID="txtCpfCad" placeholder="Seu CPF" runat="server" CssClass="txtCpf"></asp:TextBox></div>
                        <div class="uk-width-1-1 uk-form">
                            <div class="cadSex">
                                SEXO
             <asp:RadioButtonList ID="rblSexoCad" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="rblSexo_SelectedIndexChanged" CssClass="opSex">
                 <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                 <asp:ListItem Value="F">Feminino</asp:ListItem>
             </asp:RadioButtonList>
                            </div>
                        </div>

                        <div class="uk-width-1-3">
                            <asp:Button ID="CADASTRAR" CssClass="btnCadastro" runat="server" Text="CADASTRAR" OnClick="CADASTRAR_Click" /></div>
                        <div class="uk-width-2-3 uk-form termosUso">
                            <asp:LinkButton ID="lbTermosUso" runat="server">Termos de uso *</asp:LinkButton>
                        </div>

                        <div class="uk-width-1-1">
                            <p class="termosUsoAcc">
                                * Ao efetuar o cadastro, você confirma estar ciênte sobre
             os termos de uso e os aceita.
                            </p>
                        </div>


                        <asp:SqlDataSource ID="sqlCadastro" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="MySql.Data.MySqlClient" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user, status_user FROM usuario" InsertCommand="INSERT INTO usuario(login_user, pass_user, nome_user, email_user, cpf_user, sexo_user, status_user) VALUES (@login, @senha, @nome, @email, @cpf, @sexo, &quot;1&quot;)">
                            <InsertParameters>
                                <asp:Parameter Name="login" />
                                <asp:Parameter Name="senha" />
                                <asp:Parameter Name="nome" />
                                <asp:Parameter Name="email" />
                                <asp:Parameter Name="cpf" />
                                <asp:Parameter Name="sexo" />
                            </InsertParameters>
                        </asp:SqlDataSource>



                        <asp:SqlDataSource ID="sqlLoginCheck" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user, status_user FROM usuario WHERE (login_user = @login)">
                            <SelectParameters>
                                <asp:Parameter Name="login" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sqlEmailCheck" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user,status_user FROM usuario WHERE (email_user = @email)">
                            <SelectParameters>
                                <asp:Parameter Name="email" />
                            </SelectParameters>
                        </asp:SqlDataSource>





                        <asp:SqlDataSource ID="sqlCpfCheck" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT id_user, login_user, pass_user, nome_user, email_user, cpf_user, sexo_user, status_user FROM usuario WHERE (cpf_user = @cpf)">
                            <SelectParameters>
                                <asp:Parameter Name="cpf" />
                            </SelectParameters>
                        </asp:SqlDataSource>



                        <br />



                        <br />



                    </div>



                </div>

            </div>

        </div>

    </div>

</asp:Content>

