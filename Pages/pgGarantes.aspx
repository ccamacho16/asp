<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgGarantes.aspx.cs" Inherits="SGCC.Pages.pgGarantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 129px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> GARANTES</p>
<table style="width:100%;">
          <tr>
              <td class="style1">
                  CI</td>
              <td>
                   <asp:TextBox ID="TextBox1" runat="server" style="text-align: left" 
                      Width="123px" ></asp:TextBox>
                   <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" Width="123px" 
                       Enabled="False">
                      <asp:ListItem Value="BEN">Beni</asp:ListItem>
                      <asp:ListItem Value="CBB">Cochabamba</asp:ListItem>
                      <asp:ListItem Value="LPZ">La Paz</asp:ListItem>
                      <asp:ListItem Value="ORU">Oruro</asp:ListItem>
                      <asp:ListItem Value="PAN">Pando</asp:ListItem>
                      <asp:ListItem Value="POT">Potosi</asp:ListItem>
                      <asp:ListItem Value="SRZ">Santa Cruz</asp:ListItem>
                      <asp:ListItem Value="SUC">Sucre</asp:ListItem>
                      <asp:ListItem Value="TJA">Tarija</asp:ListItem>
                </asp:DropDownList>
              </td>
              <td>
                  &nbsp;</td>
          </tr>   
          <tr>
              <td class="style1">
                  Nombre Completo</td>
              <td>
                  <asp:TextBox ID="TextBox2" runat="server" style="text-align: left" 
                      Width="350px" onkeyup="this.value=this.value.toUpperCase()" 
                      Enabled="False"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>     
          <tr>
              <td class="style1">
                  Dirección Dom.</td>
              <td>
                   <asp:TextBox ID="TextBox3" runat="server" style="text-align: left" 
                      Width="350px" onkeyup="this.value=this.value.toUpperCase()" Enabled="False"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style1">
                  Telf./Celular</td>
              <td>
                   <asp:TextBox ID="TextBox4" runat="server" style="text-align: left" 
                      Width="250px" Enabled="False" ></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>   
       <tr>
              <td class="style1"></td>
                  
              <td>
                  <asp:Button ID="Button1" runat="server" Text="Siguiente" Height="32px" 
                      Width="90px" onclick="Button1_Click"/>
                  <asp:Button ID="Button2" runat="server" Text="Volver" Height="32px" 
                      Width="90px"  Visible="False" onclick="Button2_Click"/>
                  <asp:Button ID="Button3" runat="server" Text="Guardar" Height="32px" 
                      Width="90px" Font-Bold="True" Visible="False" onclick="Button3_Click"/>
                  
              </td>
              <td>
                  </td>
          </tr>   
      </table>
     <br />
     <br />
     <asp:Label ID="Label2" runat="server" style="color: #FF0000"></asp:Label>
</asp:Content>
