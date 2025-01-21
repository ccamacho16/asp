<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtLogin.Master" AutoEventWireup="true" CodeBehind="pgLogin.aspx.cs" Inherits="SGCC.Pages.pgLogin" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <center>
    <div style="background-position: center center; background-image: url('../Imagenes/unnamed.png');     background-repeat: no-repeat;">

    <br />
    <br />
        <br />
        <br />
        <br />
    <br />
    <br /> 
    <br /> 
    <br /> 

   
        <table style="border-style: solid; border-width: 1px; padding: 1px 4px; width:29%;">


            <tr>
                <td class="style4">
                    <span class="style1">Usuario</span> </td>
                <td style="text-align: left">
                    <asp:TextBox ID="TextBox1" runat="server" Width="150px" 
                        style="text-align: left"></asp:TextBox>
                </td>
            
            </tr>
            <tr>
                <td class="style1">
                    Contraseña</td>
                <td style="text-align: left">
                    <asp:TextBox ID="TextBox2" runat="server" style="text-align: left" 
                        Width="150px" TextMode="Password"></asp:TextBox>
                </td>
            
            </tr>
            
        </table>
   <br />
    <asp:Button ID="Button1" runat="server" Height="30px" Text="Ingresar" 
        Width="80px" onclick="Button1_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" style="color: #FF3300"></asp:Label>
    <br />
    </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
       <br />
    <div align="center">    
    © Crisvelco Corporation, Reservados todos los derechos.
    </div>
</center>
</asp:Content>
