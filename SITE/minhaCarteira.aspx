<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="minhaCarteira.aspx.cs" Inherits="minhaCarteira" %>


<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">
    <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2><div class="uk-icon-file-archive-o iconMeusProd"></div> MINHA CARTEIRA</h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2><div class="uk-grid uk-grid-collapse">

                    <div class="uk-width-5-10"> <asp:DropDownList ID="ddlTipoTrans" runat="server">
                        <asp:ListItem> </asp:ListItem>
                        <asp:ListItem Value="1">Adição de créditos</asp:ListItem>
                        <asp:ListItem Value="2">Remoção de créditos</asp:ListItem>
                        <asp:ListItem Value="3">Compra</asp:ListItem>
                        <asp:ListItem Value="4">Venda</asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="uk-width-3-10"><asp:Button ID="btnPesq" runat="server" Text="FILTRAR" OnClick="btnPesq_Click" ClientIDMode="Static"/></div>
                    <div class="uk-width-2-10"><asp:Button ID="btnLimpar" runat="server" OnClick="btnLimpar_Click" Text="LIMPAR" /></div>  
                                                         
                  </div></h2></div>

            </div>


                <br />
                <asp:GridView ID="gvCarteira" runat="server" AutoGenerateColumns="False" CssClass="uk-table uk-table-hover uk-table-striped" OnPreRender="gvCarteira_PreRender" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="nome_tipo" HeaderText="TIPO" SortExpression="nome_tipo" />
                        <asp:TemplateField HeaderText="DATA" SortExpression="data_transacao">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("data_transacao") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("data_transacao","{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VALOR" SortExpression="valor_transacao">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("valor_transacao") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("valor_transacao","{0:R$ #,##0.00}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                 
                </asp:GridView>

                <asp:GridView ID="gvPesq" runat="server" CssClass="uk-table" AutoGenerateColumns="False" Visible="False" OnPreRender="gvPesq_PreRender" GridLines="None">
                    <Columns>
                          <asp:BoundField DataField="nome_tipo" HeaderText="NOME" SortExpression="nome_tipo" />
                          <asp:TemplateField HeaderText="DATA" SortExpression="data_transacao">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("data_transacao") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("data_transacao","{0:d}") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="VALOR" SortExpression="valor_transacao">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("valor_transacao") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Bind("valor_transacao","{0:R$ #,##0.00}") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                      

                        </Columns>
                    
                     </asp:GridView>


              <h3 style="text-align:center;"><asp:Label ID="lblNada" runat="server" Text="NENHUM DADO ENCONTRADO" Visible="false"></asp:Label></h3> 
              <h4 style="text-align:right;">SALDO TOTAL &nbsp;&nbsp; R$: <asp:Label ID="lblSaldo" runat="server" Text="Label"></asp:Label></h4>
        

                <br />
                                   <asp:SqlDataSource ID="sqlCarteira" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO transacao(id_user, id_tipoTransacao, valor_transacao) VALUES (@id, @tipoTrans, @valor)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT tipotransacao.nome_tipo, transacao.data_transacao, transacao.valor_transacao, transacao.id_transacao, transacao.id_user, transacao.id_tipoTransacao FROM transacao INNER JOIN tipotransacao ON transacao.id_tipoTransacao = tipotransacao.id_tipotransacao WHERE (transacao.id_user = @id) order by transacao.id_transacao desc">
                                       <InsertParameters>
                                           <asp:Parameter Name="id" />
                                           <asp:Parameter Name="tipoTrans" />
                                           <asp:Parameter Name="valor" />
                                       </InsertParameters>
                                       <SelectParameters>
                                           <asp:Parameter Name="id" />
                                       </SelectParameters>
                                   </asp:SqlDataSource>

                                   <asp:SqlDataSource ID="sqlCarteiraFiltro" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" InsertCommand="INSERT INTO transacao(id_user, id_tipoTransacao, valor_transacao) VALUES (@id, @tipoTrans, @valor)" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT tipotransacao.nome_tipo, transacao.data_transacao, transacao.valor_transacao, transacao.id_transacao, transacao.id_user, transacao.id_tipoTransacao FROM transacao INNER JOIN tipotransacao ON transacao.id_tipoTransacao = tipotransacao.id_tipotransacao WHERE (transacao.id_user = @id) and transacao.id_tipoTransacao=@tipoT order by transacao.id_transacao desc">
                                       <InsertParameters>
                                           <asp:Parameter Name="id" />
                                           <asp:Parameter Name="tipoTrans" />
                                           <asp:Parameter Name="valor" />
                                       </InsertParameters>
                                       <SelectParameters>
                                           <asp:Parameter Name="id" />
                                           <asp:Parameter Name="tipoT" />
                                       </SelectParameters>
                                   </asp:SqlDataSource>

         </div>

</asp:Content>
