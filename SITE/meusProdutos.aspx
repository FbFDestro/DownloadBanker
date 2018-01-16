<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.master" AutoEventWireup="true" CodeFile="meusProdutos.aspx.cs" Inherits="meusProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phCabecalho" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phConteudo" Runat="Server">

      <div id="boxGeral" class="uk-container uk-container-center">
    			
          	<div id="cabecalhoPaginaInteira" class="uk-grid uk-grid-collapse">

                 <div class="uk-width-1-2 tituloEsquerdaI"><h2><div class="uk-icon-file-archive-o iconMeusProd"></div> MEUS PRODUTOS</h2></div>
               
                    <div class="uk-width-1-2 tituloDireitaI"><h2><div class="uk-grid uk-grid-collapse">

                    <div class="uk-width-5-10"><asp:TextBox ID="txtPesq" runat="server" placeholder="PESQUISE PELO NOME"></asp:TextBox></div>
                    <div class="uk-width-3-10"><asp:Button ID="btnPesq" runat="server" Text="PESQUISAR" OnClick="btnPesq_Click" ClientIDMode="Static"/></div>
                    <div class="uk-width-2-10"><asp:Button ID="btnLimpar" runat="server" OnClick="btnLimpar_Click" Text="LIMPAR" /></div>  
                                                         
                  </div></h2></div>

            </div>


                <br />
                <asp:GridView ID="gvProduto" runat="server" AutoGenerateColumns="False" DataKeyNames="id_prod" OnSelectedIndexChanged="gvProduto_SelectedIndexChanged" CssClass="uk-table uk-table-hover uk-table-striped" OnPreRender="gvProduto_PreRender" GridLines="None">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="uk-width-1-10" HeaderText="Selecionar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkOpP" CssClass="uk-form" runat="server" />
                            </ItemTemplate>
             
            <ItemStyle CssClass="uk-width-1-10"></ItemStyle>
             
                        </asp:TemplateField>
                        <asp:BoundField DataField="id_prod" ItemStyle-CssClass="uk-width-1-10" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="id_prod" >
            <ItemStyle CssClass="uk-width-1-10"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="nome_prod"  ItemStyle-CssClass="uk-width-5-10" HeaderText="Produto" SortExpression="nome_prod" >
          
            <ItemStyle CssClass="uk-width-5-10"></ItemStyle>
          
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Preço" SortExpression="valor_prod">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("valor_prod") %>'></asp:TextBox>
                            </EditItemTemplate> 
                            <ItemTemplate>
                                R$
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("valor_prod") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="uk-width-1-10" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="tamanho_prod" ItemStyle-CssClass="uk-width-1-10" HeaderText="Tamanho" SortExpression="tamanho_prod" >
            <ItemStyle CssClass="uk-width-1-10"></ItemStyle>
                        </asp:BoundField>
                        <asp:CommandField EditText="EDITAR" ItemStyle-CssClass="uk-width-1-10" SelectText="EDITAR" ShowSelectButton="True" >
                        <ControlStyle CssClass="editBtn" />
            <ItemStyle CssClass="uk-width-1-10"></ItemStyle>
                        </asp:CommandField>
                    </Columns>
                 
                </asp:GridView>

                <asp:GridView ID="gvPesq" runat="server" CssClass="uk-table" AutoGenerateColumns="False" DataKeyNames="id_prod" OnSelectedIndexChanged="gvPesq_SelectedIndexChanged" Visible="False" OnPreRender="gvPesq_PreRender" GridLines="None">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="uk-width-1-10" HeaderText="Selecionar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkOpPesq" CssClass="uk-form" runat="server" />
                            </ItemTemplate>

            <ItemStyle CssClass="uk-width-1-10"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id_prod" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="id_prod" />
                        <asp:BoundField DataField="nome_prod" ItemStyle-CssClass="uk-width-5-10" HeaderText="Produto" SortExpression="nome_prod" >
            <ItemStyle CssClass="uk-width-5-10"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Preço" SortExpression="valor_prod">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("valor_prod") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                R$
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("valor_prod") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="uk-width-1-10" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="tamanho_prod" ItemStyle-CssClass="uk-width-1-10" HeaderText="Tamanho" SortExpression="tamanho_prod" >
            <ItemStyle CssClass="uk-width-1-10"></ItemStyle>
                        </asp:BoundField>
                        <asp:CommandField EditText="EDITAR" ItemStyle-CssClass="uk-width-1-10" SelectText="EDITAR" ShowSelectButton="True" >
                        <ControlStyle CssClass="editBtn" />
            <ItemStyle CssClass="uk-width-1-10"></ItemStyle>
                        </asp:CommandField>
                        </Columns>
                    
                     </asp:GridView>


                <asp:SqlDataSource ID="SqlCarrega" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT produto.* FROM produto WHERE (id_user = @idUSER) AND (status_prod = 1) order by id_prod desc" >
                    <SelectParameters>
                        <asp:SessionParameter Name="idUSER" SessionField="idUser" />
                    </SelectParameters>
                </asp:SqlDataSource>

                
                 <asp:SqlDataSource ID="sqlExcluir" runat="server" ConnectionString="<%$ ConnectionStrings:downloadbankerConnectionString %>" ProviderName="<%$ ConnectionStrings:downloadbankerConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [produto]" UpdateCommand="UPDATE produto SET status_prod = 0 WHERE (id_prod = @COD)">
                     <UpdateParameters>
                         <asp:Parameter Name="COD" />
                     </UpdateParameters>
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

                <asp:Button ID="btnExcluir" CssClass="btnExProd" runat="server" OnClick="btnExcluir_Click" Text="Excluir" />

                

         </div>

</asp:Content>

