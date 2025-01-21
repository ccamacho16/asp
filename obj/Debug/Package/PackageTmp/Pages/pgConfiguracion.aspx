<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgConfiguracion.aspx.cs" Inherits="SGCC.Pages.pgConfiguracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> CONFIG. PARAMETROS</p>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" 
        DataSourceID="SqlDataSource1" DefaultMode="Insert">
        <EditItemTemplate>
            ID:
            <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
            <br />
            Entidad:
            <asp:TextBox ID="EntidadTextBox" runat="server" Text='<%# Bind("Entidad") %>' />
            <br />
            Tipo:
            <asp:TextBox ID="TipoTextBox" runat="server" Text='<%# Bind("Tipo") %>' />
            <br />
            Valor1:
            <asp:TextBox ID="Valor1TextBox" runat="server" Text='<%# Bind("Valor1") %>' />
            <br />
            Valor2:
            <asp:TextBox ID="Valor2TextBox" runat="server" Text='<%# Bind("Valor2") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Actualizar" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="style1">
                <tr>
                    <td>
                        Entidad</td>
                    <td>
                        <asp:TextBox ID="EntidadTextBox" runat="server" Text='<%# Bind("Entidad") %>' 
                            Width="100px" onkeyup="this.value=this.value.toUpperCase()"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tipo</td>
                    <td>
                        <asp:TextBox ID="TipoTextBox" runat="server" Text='<%# Bind("Tipo") %>' Width="100px" onkeyup="this.value=this.value.toUpperCase()"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Valor1</td>
                    <td>
                        <asp:TextBox ID="Valor1TextBox" runat="server" Text='<%# Bind("Valor1") %>' Width="170px" onkeyup="this.value=this.value.toUpperCase()"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Valor2</td>
                    <td>
                        <asp:TextBox ID="Valor2TextBox" runat="server" Text='<%# Bind("Valor2") %>' Width="170px" onkeyup="this.value=this.value.toUpperCase()"/>
                    </td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insertar" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </InsertItemTemplate>
        <ItemTemplate>
            ID:
            <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
            <br />
            Entidad:
            <asp:Label ID="EntidadLabel" runat="server" Text='<%# Bind("Entidad") %>' />
            <br />
            Tipo:
            <asp:Label ID="TipoLabel" runat="server" Text='<%# Bind("Tipo") %>' />
            <br />
            Valor1:
            <asp:Label ID="Valor1Label" runat="server" Text='<%# Bind("Valor1") %>' />
            <br />
            Valor2:
            <asp:Label ID="Valor2Label" runat="server" Text='<%# Bind("Valor2") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Editar" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Eliminar" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="Nuevo" />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conexsgcc %>" 
        DeleteCommand="DELETE FROM [tblMaster] WHERE [ID] = @ID" 
        InsertCommand="INSERT INTO [tblMaster] ([Entidad], [Tipo], [Valor1], [Valor2]) VALUES (@Entidad, @Tipo, @Valor1, @Valor2)" 
        SelectCommand="SELECT * FROM [tblMaster] WHERE [Entidad] <> 'RUBROS' ORDER BY [Entidad], [Tipo], [Valor1]" 
        UpdateCommand="UPDATE [tblMaster] SET [Entidad] = @Entidad, [Tipo] = @Tipo, [Valor1] = @Valor1, [Valor2] = @Valor2 WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Entidad" Type="String" />
            <asp:Parameter Name="Tipo" Type="String" />
            <asp:Parameter Name="Valor1" Type="String" />
            <asp:Parameter Name="Valor2" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Entidad" Type="String" />
            <asp:Parameter Name="Tipo" Type="String" />
            <asp:Parameter Name="Valor1" Type="String" />
            <asp:Parameter Name="Valor2" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <center>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" Visible="False" />
            <asp:BoundField DataField="Entidad" HeaderText="Entidad" 
                SortExpression="Entidad" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
            <asp:BoundField DataField="Valor1" HeaderText="Valor1" 
                SortExpression="Valor1" />
            <asp:BoundField DataField="Valor2" HeaderText="Valor2" 
                SortExpression="Valor2" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    </center>

</asp:Content>
