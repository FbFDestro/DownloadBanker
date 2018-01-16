<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="minhasCompras.aspx.cs" Inherits="minhasCompras" %>


<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">
    <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2><div class="uk-icon-file-archive-o iconMeusProd"></div> MINHAS COMPRAS</h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2><div class="uk-grid uk-grid-collapse">

                    <div class="uk-width-5-10"><asp:TextBox ID="txtPesq" runat="server" placeholder="PESQUISE PELO NOME"></asp:TextBox></div>
                    <div class="uk-width-3-10"><asp:Button ID="btnPesq" runat="server" Text="PESQUISAR" OnClick="btnPesq_Click" ClientIDMode="Static"/></div>
                    <div class="uk-width-2-10"><asp:Button ID="btnLimpar" runat="server" OnClick="btnLimpar_Click" Text="LIMPAR" /></div>  
                                                         
                  </div></h2></div>

            </div>


                <br />
                <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="False" CssClass="uk-table uk-table-hover uk-table-striped" OnPreRender="gvVendas_PreRender" GridLines="None" OnSelectedIndexChanged="gvVendas_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="id_venda" HeaderText="CÓDIGO DA VENDA" SortExpression="id_venda"  Visible="true"/>
                        <asp:BoundField DataField="id_user" HeaderText="id_user" SortExpression="id_user" Visible="false"/>
                           <asp:BoundField DataField="nome_prod" HeaderText="PRODUTO" SortExpression="nome_prod" />
                        <asp:TemplateField HeaderText="DATA DA COMPRA" SortExpression="data_venda">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("data_venda") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("data_venda","{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VALOR" SortExpression="valor_venda">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("valor_venda") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("valor_venda","{0:C}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:BoundField DataField="down_venda" HeaderText="DOWNLOADS" SortExpression="down_venda" Visible="true" />
                      

                        <asp:CommandField SelectText="DOWNLOAD" ShowSelectButton="True" >

                        <ControlStyle CssClass="editBtn" />
                        </asp:CommandField>

                        

                    </Columns>
                 
                </asp:GridView>

                <asp:GridView ID="gvPesq" runat="server" CssClass="uk-table" AutoGenerateColumns="False" Visible="False" OnPreRender="gvPesq_PreRender" GridLines="None" OnSelectedIndexChanged="gvPesq_SelectedIndexChanged">
                    <Columns>
                          <asp:BoundField DataField="id_venda" HeaderText="CÓDIGO DA VENDA" SortExpression="id_venda" />
                        <asp:BoundField DataField="id_user" HeaderText="id_user" SortExpression="id_user" Visible="false" />
                        <asp:BoundField DataField="nome_prod" HeaderText="PRODUTO" SortExpression="nome_prod" ></asp:BoundField>
                        <asp:TemplateField HeaderText="DATA DA COMPRA" SortExpression="data_venda">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("data_venda") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("data_venda","{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VALOR" SortExpression="valor_venda">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("valor_venda") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("valor_venda","{0:C}") %>'></asp:Label>
                            </ItemTemplate>
                        
                        </asp:TemplateField>

                        <asp:BoundField DataField="down_venda" HeaderText="DOWNLOADS" SortExpression="down_venda" Visible="true" />
                      

                        <asp:CommandField SelectText="DOWNLOAD" ShowSelectButton="True" >
                          <ControlStyle CssClass="editBtn" />
                          </asp:CommandField>
                          
                        </Columns>
                    
                     </asp:GridView>


                <asp:SqlDataSource ID="SqlCarrega" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT venda.id_venda, venda.id_user, venda.down_venda, produto.nome_prod, venda.data_venda, venda.valor_venda FROM venda INNER JOIN prodvenda ON venda.id_venda = prodvenda.id_venda INNER JOIN produto ON prodvenda.id_prod = produto.id_prod WHERE (venda.id_user = @id) ORDER BY venda.id_venda DESC" UpdateCommand="UPDATE venda SET down_venda = @down WHERE (id_venda = @id)" >
                    <SelectParameters>
                        <asp:Parameter Name="id" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="down" />
                        <asp:Parameter Name="id" />
                    </UpdateParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="sqlArquivo" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT venda.id_venda, produto.arquivo_prod FROM venda INNER JOIN prodvenda ON venda.id_venda = prodvenda.id_venda INNER JOIN produto ON prodvenda.id_prod = produto.id_prod WHERE (venda.id_venda = @idVenda)">
                    <SelectParameters>
                        <asp:Parameter Name="idVenda" />
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

                * SÓ SÃO PERMITIDOS 2 DOWNLOAD POR ARQUIVO
        <br />
                <asp:Button ID="btnDown" CssClass="btnProd" Width="150px" runat="server" Text="DOWNLOAD" Visible="false" OnClick="btnDown_Click" />

         </div>

</asp:Content>
