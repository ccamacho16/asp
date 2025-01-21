<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgpConsultaMoraClientes.aspx.cs" Inherits="SGCC.Pages.pgpConsultaMoraClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 99px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> 
        <strong>CLIENTES EN MORA</strong></p>
<table style="width:100%;">
    <tr>
        <td class="style1">A Fecha:</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" style="text-align: center"  
            TextMode="Date"></asp:TextBox>
        </td>
        <td>
        </td>
    </tr>

    <tr>
        <td class="style1">Ofi. Credito:</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="116px" 
                AutoPostBack="True" >
            </asp:DropDownList>
        </td>
        <td>
        </td>
    </tr>

    <tr>
    <td class="style1"></td>
    <td>
       
        <asp:Button ID="Button1" runat="server" Text="Generar" Height="32px" 
                      Width="90px" onclick="Button1_Click" />
       
        </td><td></td>
    </tr>
</table>
</asp:Content>
