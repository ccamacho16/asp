<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgpPagosRangoFecha.aspx.cs" Inherits="SGCC.Pages.pgpPagosRangoFecha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 102px;
        }
        .style2
        {
            width: 196px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> 
        <strong>PAGOS REALIZADOS</strong></p>
<table style="width:100%;">
    <tr>
    <td class="style1">Fecha Inicial</td>
    <td class="style2">
        <asp:TextBox ID="TextBox1" runat="server" style="text-align: center"  TextMode="Date"></asp:TextBox>
        </td><td></td>
    </tr>
    <tr>
    <td class="style1">Fecha Final</td>
    <td class="style2">
        <asp:TextBox ID="TextBox2" runat="server" style="text-align: center"  TextMode="Date"></asp:TextBox>
        </td><td></td>
    </tr>

    <tr>
    <td></td>
    <td>
       
        <asp:Button ID="Button1" runat="server" Text="Generar" Height="32px" 
                      Width="90px" onclick="Button1_Click" />
       
        </td><td></td>
    </tr>
</table>
</asp:Content>
