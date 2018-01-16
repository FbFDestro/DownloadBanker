<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="Comprar.aspx.cs" Inherits="Comprar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

    <!-- inicio box geral -->
     <div id="boxGeral" class="uk-container uk-container-center"> 

          <!-- inicio grid geral -->
         	<div class="uk-grid uk-grid-collapse">
                

                 <!-- inicio box esquerda -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloEsquerda">Confirmar compra</h2>

                       <div id="boxEsquerda" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">
    
                            <!-- conteudo box esquerda -->  
                                
                                
                                   <div id="imgTelaProdutosComp" style="height:180px; font-size: 14px;">
                     <asp:Image ID="imgProduto" runat="server" style=" float:left;max-height: 140px;max-width: 190px;margin-left: 20px;margin-bottom: 20px;margin-top: 20px;border: 1px solid #515151;border-bottom: 2px solid #f0082e;border-radius: 4px;" Height="140px" Width="190px"/>
                      <div style="float: left;margin-left: 20px;margin-bottom: 20px;margin-top: 20px;">
                           <h3 class="tituloCompra"><asp:Label ID="lblProdNome" runat="server" Text="Produto"></asp:Label></h3>
                          <div class="distribuidorArquivo"><div class="uk-icon-user"></div> DISTRIBUIDOR - <asp:LinkButton ID="lblDistribuidor" CssClass="linkDistribuidor" runat="server" Text="Distribuidor"></asp:LinkButton></div>
                          <div id="tamanhoArquivo"><div class="uk-icon-hdd-o"></div> Tamanho do arquvio (zip/rar) - <asp:Label ID="lblTamanho" runat="server" Text="Tamanho"></asp:Label></div>                  
                           <div id="precoArquivo" style="font-size: 30px;color: #f0082e;margin-top: 20px;">R$ <asp:Label ID="lblPreco" runat="server" Text="Preço"></asp:Label></div>
                      </div>
                 </div>                          
                                
                            </div>

                       </div>

                 </div>
                   <!-- fim box esquerda -->


                  <!-- inicio box direita -->
                 <div class="uk-width-1-2">

                     <h2 class="tituloDireita">Informações</h2>

                       <div id="boxDireita" class="uk-container uk-container-center">

	                        <div class="uk-grid uk-grid-match uk-grid-small">

                               
                                   <div class="uk-width-2-5 saldoDispL">Saldo disponível</div> <div class="uk-width-3-5 saldoDispP">R$&nbsp; <asp:Label ID="lblSaldoDisp" runat="server" Text="00,00"></asp:Label></div>
                                    <div class="uk-width-2-5 valProdL">Valor do produto</div> <div class="uk-width-3-5 valProdP">R$&nbsp; <asp:Label ID="lblValProd" runat="server" Text="00,00"></asp:Label></div>
                                   <hr class="uk-width-1-1 linhaDivCompra"/> 
                                   <div class="uk-width-2-5 novoSaldoL"> Novo saldo</div> <div class="uk-width-3-5 novoSaldoP">R$&nbsp; 
                                       <asp:Label ID="lblNovoSaldoP" ForeColor="Blue" runat="server" Text="00,00"></asp:Label>
                                        <asp:Label ID="lblNovoSaldoN" ForeColor="Red" runat="server" Text="00,00"></asp:Label>
                                       </div>
                                  
                               

                                   <div class="uk-width-1-1 pnlConfCompra"> 
                                       <asp:Panel ID="pnlConfCompra" runat="server"> <div class="uk-width-1-3"><asp:Button Width="180px" ID="btnConfirmar" runat="server" Text="CONFIRMAR COMPRA" OnClick="btnConfirmar_Click" /></div>
</asp:Panel>
                                       </div>
                                <div class="uk-width-1-1 pnlSaldoInsuficiente"> 
                                    <asp:Panel ID="pnlSaldoInsuficiente" runat="server">
                                        <hr />
                                        Saldo insuficiente, <a href="#" class="linkCred">baixe o app Android para adicionar</a></asp:Panel>
                                       </div>

                                    
                               


                            <!-- conteudo box direita -->        
                                
                    <asp:SqlDataSource ID="SqlComprar" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.id_prod, produto.id_user, produto.nome_prod, produto.valor_prod, produto.sobre_prod, produto.contem_prod, produto.imagem_prod, produto.arquivo_prod, produto.status_prod, produto.tamanho_prod, usuario.id_user AS Expr1, usuario.nome_user FROM produto INNER JOIN usuario ON produto.id_user = usuario.id_user WHERE (produto.id_prod = @cod)" InsertCommand="INSERT INTO venda(id_user, valor_venda, data_venda,down_venda) VALUES (@user,@valor,@data,&quot;BtabWm62FSFXmG7Cl9kLyg==&quot;)">
                        <InsertParameters>
                            <asp:Parameter Name="user" />
                            <asp:Parameter Name="valor" />
                            <asp:Parameter Name="data" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:Parameter Name="cod" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                                   <asp:SqlDataSource ID="sqlProdVenda" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO prodvenda(id_venda, id_prod) VALUES (@idV, @idP)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM venda">
                                       <InsertParameters>
                                           <asp:Parameter Name="idV" />
                                           <asp:Parameter Name="idP" />
                                       </InsertParameters>
                                   </asp:SqlDataSource>

                                   <asp:SqlDataSource ID="sqlTransacaoDono" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO transacao(id_user, id_tipoTransacao, valor_transacao,data_transacao) VALUES (@id, @tipoTrans, @valor,@data)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM transacao">
                                       <InsertParameters>
                                           <asp:Parameter Name="id" />
                                           <asp:Parameter Name="tipoTrans" />
                                           <asp:Parameter Name="valor" />
                                           <asp:Parameter Name="data" />
                                       </InsertParameters>
                                   </asp:SqlDataSource>
                                   <asp:SqlDataSource ID="sqlTransacaoComprador" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO transacao(id_user, id_tipoTransacao, valor_transacao,data_transacao) VALUES (@id, @tipoTrans, @valor,@data)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM transacao where id_user = @id">
                                       <InsertParameters>
                                           <asp:Parameter Name="id" />
                                           <asp:Parameter Name="tipoTrans" />
                                           <asp:Parameter Name="valor" />
                                           <asp:Parameter Name="data" />
                                       </InsertParameters>
                                       <SelectParameters>
                                           <asp:Parameter Name="id" />
                                       </SelectParameters>
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

                                   <br />

                            </div>
                           
                     </div>

                  </div>
                  <!-- fim box direita -->

            </div>
         <!-- fim grid geral -->

       </div> <!-- fim box geral -->



</asp:Content>
