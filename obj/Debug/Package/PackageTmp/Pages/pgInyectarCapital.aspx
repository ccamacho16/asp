<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgInyectarCapital.aspx.cs" Inherits="SGCC.Pages.pgInyectarCapital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 155px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni">INYECTAR CAPITAL</p>

<table style="width:100%;">
          <tr>
              <td class="style1">
                  Fecha</td>
              <td>
                   
                  <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" Width="127px"></asp:TextBox>
                   
              </td>
              <td>
                  &nbsp;</td>
          </tr>   
        
          <tr>
              <td class="style1" >
                  Nombre Socio</td>
              <td>
                  
                  <asp:TextBox ID="TextBox2" runat="server" Width="424px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                  
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style1">
                  Monto</td>
              <td>

                  <asp:TextBox ID="TextBox3" runat="server" TextMode="Number" step="0.01" Width="76px" 
                      style="text-align: right"></asp:TextBox>

              </td>
              <td>
                  &nbsp;</td>
          </tr>   
      
       <tr>
              <td class="style1"></td>
                  
              <td>
                  <asp:Button ID="Button1" runat="server" Text="Siguiente" Height="32px" 
                      Width="90px" onclick="Button1_Click"   />
                  <asp:Button ID="Button2" runat="server" Text="Volver" Height="32px" 
                      Width="90px"  Visible="False" onclick="Button2_Click"  />
                  <asp:Button ID="Button3" runat="server" Text="Guardar" Height="32px" 
                      Width="90px" Font-Bold="True" Visible="False" onclick="Button3_Click"  />
                  
              </td>
              <td>
                  </td>
          </tr>   
      </table>
     <br />
     <br />
     <asp:Label ID="Label2" runat="server" style="color: #FF0000"></asp:Label>

</asp:Content>
