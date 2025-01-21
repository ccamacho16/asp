<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgAnularCredito.aspx.cs" Inherits="SGCC.Pages.pgAnularCredito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 129px;
        }
        .style3
        {
            width: 104px;
        }
        .style4
        {
            width: 397px;
        }
    </style>
    <script type="text/javascript" src="/Archivos/JSmycode.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> 
    ANULAR CREDITO</p>
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
              <td class="style4">
                   <asp:TextBox ID="TextBox3" runat="server" style="text-align: left" 
                      Width="350px" Enabled="False"></asp:TextBox>
              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>
          <tr>
              <td class="style1">
                  Fecha 
                  Credito</td>
              <td class="style4">
                   <asp:TextBox ID="TextBox4" runat="server" style="text-align: center" 
                      Width="123px" Enabled="False"></asp:TextBox>
              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>

          <tr>
              <td class="style1">
                  Monto</td>
              <td class="style4">
                   <asp:TextBox ID="TextBox5" runat="server" style="text-align: right" 
                      Width="90px" Enabled="False" ></asp:TextBox>
              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>    
          <tr>
              <td class="style1">
                  Forma Pago</td>
              <td class="style4">
                   <asp:TextBox ID="TextBox6" runat="server" style="text-align: left" 
                      Width="123px" Enabled="False" ></asp:TextBox>
              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>   
                    <tr>
              <td class="style1">
                  Nro Cuotas</td>
              <td class="style4">
                   <asp:TextBox ID="TextBox7" runat="server" style="text-align: right" 
                      Width="90px" Enabled="False" ></asp:TextBox>
              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>  
         
                    <tr>
              <td class="style1">
                  Habilitado</td>
              <td class="style4">

                  <asp:CheckBox ID="CheckBox1" runat="server" />

              </td>
              <td class="style3">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>                     
       <tr>
              <td class="style1"></td>
                  
              <td align = "left">
                  <asp:Button ID="Button4" runat="server" Text="Siguiente" Height="32px" 
                      Width="90px" onclick="Button4_Click" />
                  <asp:Button ID="Button5" runat="server" Text="Volver" Height="32px" 
                      Width="90px"  Visible="False" onclick="Button5_Click" />
                  <asp:Button ID="Button6" runat="server" Text="Guardar" Height="32px" 
                      Width="90px" Font-Bold="True" Visible="False" OnClientClick = "Confirmacion()" onclick="Button6_Click" />
                  
              </td>
              <td>
                  </td>
          </tr>                             
      </table>
     <br />
     <br />
     <asp:Label ID="Label1" runat="server" style="color: #009900"></asp:Label>
     <asp:Label ID="Label2" runat="server" style="color: #FF0000"></asp:Label>

</asp:Content>
