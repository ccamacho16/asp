<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgReimprimirPlanPago.aspx.cs" Inherits="SGCC.Pages.pgReimprimirPlanPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 221px;
        }
        .style3
        {
            width: 110px;
        }
        .style5
        {
            width: 113px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> REIMPRIMIR PLAN PAGO</p>

<table style="width:100%;">
    <tr>
        <td class="style5">CI Cliente</td>
        <td class="style3">
            <asp:TextBox ID="TextBox2" runat="server" Width="106px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="→" onclick="Button1_Click" />
            <asp:TextBox ID="TextBox1" runat="server" Width="271px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style5">Credito</td>
        <td class="style2" colspan="2">
            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="153px" 
                Enabled="False"  AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
            </asp:DropDownList>
        </td>
        <td></td>
    </tr>

</table>
<table style="width:100%;">
    <tr>
        <td class="style5">Credito</td>
        <td>
            <asp:TextBox ID="TextBox7" runat="server" Enabled="False" Width="90px"  style="text-align: right" ></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="style5">Fecha Credito</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" Enabled="False"  
                style="text-align: center" Width="90px" ></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="style5">Monto</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server" Enabled="False" Width="90px" style="text-align: right"></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="style5">Forma Pago</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" Enabled="False" Width="110px"></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="style5">Garantia</td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server" Enabled="False" Width="110px"></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="style5">Nro. Cuotas</td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server" Enabled="False" Width="90px" style="text-align: right"></asp:TextBox>
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="style5"></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td class="style5"></td>
        <td>
            <asp:Button ID="Button2" runat="server" Text="Siguiente" Height="32px" 
                Width="90px" onclick="Button2_Click" />
            <asp:Button ID="Button4" runat="server" Text="Volver" Height="32px" 
                      Width="90px" onclick="Button4_Click" Visible="False"/>
            <asp:Button ID="Button3" runat="server" Text="Reimprimir" Height="32px" 
                Visible="False" onclick="Button3_Click" />
        </td>
        <td></td>
    </tr>
</table>
</asp:Content>
