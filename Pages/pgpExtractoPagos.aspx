<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgpExtractoPagos.aspx.cs" Inherits="SGCC.Pages.pgpExtractoPagos" %>
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
    <strong>EXTRACTO DE PAGOS</strong></p>
<table style="width:100%;">
    <tr>
    <td class="style1">Num. Credito:</td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" style="text-align: right" 
            TextMode="Number" Width="87px"></asp:TextBox>
        </td><td></td>
    </tr>
    <tr>
    <td class="style1"></td>
    <td>
       
        <asp:Button ID="Button1" runat="server" Text="Generar" Height="32px" 
                      Width="90px" onclick="Button1_Click"/>
       
        </td><td></td>
    </tr>
</table>
</asp:Content>