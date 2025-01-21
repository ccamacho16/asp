<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgUsuarios.aspx.cs" Inherits="SGCC.Pages.pgUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> USUARIOS</p>

    <asp:FormView ID="FormView1" runat="server" 
         AllowPaging="True" 
        DataKeyNames="usuario" DataSourceID="SqlDataSource1" DefaultMode="Insert" 
            style="text-align: left" oniteminserted="FormView1_ItemInserted" 
        oniteminserting="FormView1_ItemInserting">
        <EditItemTemplate>
            usuario:
            <asp:Label ID="usuarioLabel1" runat="server" Text='<%# Eval("usuario") %>' />
            <br />
            contrasena:
            <asp:TextBox ID="contrasenaTextBox" runat="server" Text='<%# Bind("contrasena") %>' />
            <br />
            nombre:
            <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
            <br />
            tipo:
            <asp:TextBox ID="tipoTextBox" runat="server" Text='<%# Bind("tipo") %>' />
            <br />
            estado:
            <asp:CheckBox ID="estadoCheckBox" runat="server" 
                Checked='<%# Bind("estado") %>' />
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
                        Usuario:</td>
                    <td>
                        <asp:TextBox ID="usuarioTextBox" runat="server" Text='<%# Bind("usuario") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        Contrasena:</td>
                    <td>
                        <asp:TextBox ID="contrasenaTextBox" runat="server" 
                            Text='<%# Bind("contrasena") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="nombreTextBox" runat="server" Text='<%# Bind("nombre") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        Tipo:
                    </td>
                    <td>
                        <asp:TextBox ID="tipoTextBox" runat="server" Text='<%# Bind("tipo") %>' 
                            Width="51px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Estado:
                    </td>
                    <td>
                        <asp:CheckBox ID="estadoCheckBox" runat="server" 
                            Checked='<%# Bind("estado") %>' />
                    </td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insertar"/>
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </InsertItemTemplate>
        <ItemTemplate>
            usuario:
            <asp:Label ID="usuarioLabel" runat="server" Text='<%# Eval("usuario") %>' />
            <br />
            contrasena:
            <asp:Label ID="contrasenaLabel" runat="server" Text='<%# Bind("contrasena") %>' />
            <br />
            nombre:
            <asp:Label ID="nombreLabel" runat="server" Text='<%# Bind("nombre") %>' />
            <br />
            tipo: 
            <asp:Label ID="tipoLabel" runat="server" Text='<%# Bind("tipo") %>' />
            <br />
            estado:
            <asp:CheckBox ID="estadoCheckBox" runat="server" Checked='<%# Bind("estado") %>' Enabled="false" />
            <br />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Editar" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Eliminar" />
            &nbsp;<br />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conexsgcc %>" 
        DeleteCommand="DELETE FROM [tblUsuarios] WHERE [usuario] = @usuario" 
        InsertCommand="INSERT INTO [tblUsuarios] ([usuario], [contrasena], [nombre], [tipo], [estado]) VALUES (@usuario, @contrasena, @nombre, @tipo, @estado)" 
        SelectCommand="SELECT * FROM [tblUsuarios] WHERE [tipo] <> 1  ORDER BY [usuario]" 
        UpdateCommand="UPDATE [tblUsuarios] SET [contrasena] = @contrasena, [nombre] = @nombre, [tipo] = @tipo, [estado] = @estado WHERE [usuario] = @usuario">
        <DeleteParameters>
            <asp:Parameter Name="usuario" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="usuario" Type="String" />
            <asp:Parameter Name="contrasena" Type="String" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="tipo" Type="String" />
            <asp:Parameter Name="estado" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="contrasena" Type="String" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="tipo" Type="String" />
            <asp:Parameter Name="estado" Type="Boolean" />
            <asp:Parameter Name="usuario" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
        <br />
        <center>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="usuario" DataSourceID="SqlDataSource1" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ButtonType="Button" />
            <asp:BoundField DataField="usuario" HeaderText="Usuario" ReadOnly="True" 
                SortExpression="usuario" />
            <asp:BoundField DataField="contrasena" HeaderText="Contrasena" 
                SortExpression="contrasena" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" 
                SortExpression="nombre" />
            <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo" />
            <asp:CheckBoxField DataField="estado" HeaderText="Estado" 
                SortExpression="estado" />
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
    <br />
    </center>
</asp:Content>
