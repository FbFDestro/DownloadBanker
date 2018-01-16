<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="minhasVendas.aspx.cs" Inherits="minhasVendas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">
    <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2><div class="uk-icon-file-archive-o iconMeusProd"></div> MINHAS VENDAS</h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2><div class="uk-grid uk-grid-collapse">

                    <div class="uk-width-5-10"><asp:TextBox ID="txtPesq" runat="server" placeholder="PESQUISE PELO NOME"></asp:TextBox></div>
                    <div class="uk-width-3-10"><asp:Button ID="btnPesq" runat="server" Text="PESQUISAR" OnClick="btnPesq_Click" ClientIDMode="Static"/></div>
                    <div class="uk-width-2-10"><asp:Button ID="btnLimpar" runat="server" OnClick="btnLimpar_Click" Text="LIMPAR" /></div>  
                                                         
                  </div></h2></div>

            </div>


                <br />
                <asp:GridView ID="gvVendas" runat="server" AutoGenerateColumns="False" CssClass="uk-table uk-table-hover uk-table-striped" OnPreRender="gvVendas_PreRender" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="id_user" HeaderText="id_user" SortExpression="id_user" Visible="False" />
                        <asp:BoundField DataField="nome_prod" HeaderText="PRODUTO" SortExpression="nome_prod" />
                        <asp:TemplateField HeaderText="DATA DA VENDA" SortExpression="data_venda">
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
                    </Columns>
                 
                </asp:GridView>

                <asp:GridView ID="gvPesq" runat="server" CssClass="uk-table" AutoGenerateColumns="False" Visible="False" OnPreRender="gvPesq_PreRender" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="id_user" HeaderText="id_user" SortExpression="id_user" Visible="False" />
                        <asp:BoundField DataField="nome_prod" HeaderText="PRODUTO" SortExpression="nome_prod" ></asp:BoundField>
                        <asp:TemplateField HeaderText="DATA DA VENDA" SortExpression="data_venda">
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
                        </Columns>
                    
                     </asp:GridView>


                <asp:SqlDataSource ID="SqlCarrega" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT venda.id_venda, produto.id_user, produto.nome_prod, venda.data_venda, venda.valor_venda FROM venda INNER JOIN prodvenda ON venda.id_venda = prodvenda.id_venda INNER JOIN produto ON prodvenda.id_prod = produto.id_prod WHERE (produto.id_user = @id) order by venda.id_venda desc" >
                    <SelectParameters>
                        <asp:Parameter Name="id" />
                    </SelectParameters>
                </asp:SqlDataSource>

                

         </div>

</asp:Content>


