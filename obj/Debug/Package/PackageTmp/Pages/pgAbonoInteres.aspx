<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgAbonoInteres.aspx.cs" Inherits="SGCC.Pages.pgAbonoInteres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 130px;
        }
    </style>
    <script type="text/javascript" src="/Archivos/JSmycode.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> ABONO A INTERES</p>
<table style="width:100%;">
          <tr>
              <td class="style1">
                  Cod. Credito</td>
              <td class="style4">
                   <asp:TextBox ID="TextBox1" runat="server" style="text-align: right" 
                      Width="90px" ></asp:TextBox>
              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>   
          <tr>
              <td class="style1">
                  CI Cliente</td>
              <td class="style4">
                  <asp:TextBox ID="TextBox2" runat="server" style="text-align: left" 
                      Width="123px" Enabled="False"></asp:TextBox>
              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>     
          <tr>
              <td class="style1">
                  Nombre Cliente</td>
              <td class="style2" colspan="2">
                   <asp:TextBox ID="TextBox3" runat="server" style="text-align: left" 
                      Width="350px" Enabled="False"></asp:TextBox>
              </td>
      
                                <td>
                                    &nbsp;</td>
          </tr>

          <tr>
              <td class="style1">
                  <strong>Monto a Abonar</strong></td>
              <td class="style4">
                   <asp:TextBox ID="TextBox4" runat="server" style="text-align: right" TextMode="Number"
                      Width="90px" Enabled="False"></asp:TextBox>
              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>

          <tr>
              <td class="style1">
                  <strong>Nro Cuota</strong></td>
              <td class="style4">
                   <asp:TextBox ID="TextBox5" runat="server" style="text-align: right" TextMode="Number"
                      Width="90px" Enabled="False" ></asp:TextBox>
              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>    
  
       <tr>
              <td class="style1"></td>
                  
              <td align = "left" class="style4">
                  <asp:Button ID="Button4" runat="server" Text="Siguiente" Height="32px" 
                      Width="90px" onclick="Button4_Click"/>
                  <asp:Button ID="Button5" runat="server" Text="Volver" Height="32px" 
                      Width="90px"  Visible="False" onclick="Button5_Click"/>
                  <asp:Button ID="Button6" runat="server" Text="Guardar" Height="32px" 
                      Width="110px"  Visible="False" OnClientClick = "Confirmacion()" onclick="Button6_Click" 
                      />
                  
                  
              </td>
              <td>
                  </td>
          </tr>                             
      </table>
</asp:Content>
