<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgDesembolsosRefinan.aspx.cs" Inherits="SGCC.Pages.pgDesembolsosRefinan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 726px;
        }
        .style4
        {
            width: 723px;
        }
        .style7
        {
            width: 171px;
        }
    .style8
    {
        width: 120px;
    }
    .style9
    {
            width: 209px;
        }
    .style10
    {
        width: 120px;
        font-weight: bold;
    }
    </style>
    <script type="text/javascript" src="/Archivos/JSmycode.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> DESEMBOLSOS REFINANCIAMIENTO</p>
<table style="width:100%;">
          <tr>
              <td class="style9">
                  Cod. Credito</td>
              <td class="style7">
                   <asp:TextBox ID="TextBox1" runat="server" style="text-align: right" 
                      Width="90px" ></asp:TextBox>
              </td>
              <td class="style8">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>   
          <tr>
              <td class="style9">
                  CI Cliente</td>
              <td class="style7">
                  <asp:TextBox ID="TextBox2" runat="server" style="text-align: left" 
                      Width="123px" Enabled="False"></asp:TextBox>
              </td>
              <td class="style8">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>     
          <tr>
              <td class="style9">
                  Nombre Cliente</td>
              <td class="style2" colspan="3">
                   <asp:TextBox ID="TextBox3" runat="server" style="text-align: left" 
                      Width="350px" Enabled="False"></asp:TextBox>
              </td>
      
                    
          </tr>
          <tr>
              <td class="style9">
                  Fecha 
                  Credito</td>
              <td class="style7">
                   <asp:TextBox ID="TextBox4" runat="server" style="text-align: center" 
                      Width="123px" Enabled="False"></asp:TextBox>
              </td>
              <td class="style8">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>

          <tr>
              <td class="style9">
                  Monto</td>
              <td class="style7">
                   <asp:TextBox ID="TextBox5" runat="server" style="text-align: right" 
                      Width="90px" Enabled="False" ></asp:TextBox>
             
              </td>
              <td class="style10">
                  Monto Ref.:</td>
                                <td class="style7">
                                    <asp:TextBox ID="TextBox9" runat="server" 
                                        style="text-align: right; font-weight: 700; color: #00CC00;" Width="85px" 
                                        Enabled="False"></asp:TextBox>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>    
          <tr>
              <td class="style9">
                  Forma Pago</td>
              <td class="style7">
                   <asp:TextBox ID="TextBox6" runat="server" style="text-align: left" 
                      Width="123px" Enabled="False" ></asp:TextBox>
              </td>
              <td class="style8">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>   
                    <tr>
              <td class="style9">
                  Nro Cuotas</td>
              <td class="style7">
                   <asp:TextBox ID="TextBox7" runat="server" style="text-align: right" 
                      Width="90px" Enabled="False" ></asp:TextBox>
              </td>
              <td class="style8">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>  
         
                    <tr>
              <td class="style9">
                  F. Desembolso</td>
              <td class="style7">

                  <asp:TextBox ID="TextBox8" runat="server" Width="123px" 
                      style="text-align: center" Enabled="False"></asp:TextBox>
                        </td>
              <td class="style8">
                  &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>                     
       <tr>
              <td class="style9"></td>
                  
              <td align = "left" class="style4" colspan ="3">
                  <asp:Button ID="Button4" runat="server" Text="Siguiente" Height="32px" 
                      Width="90px" onclick="Button4_Click" />
                  <asp:Button ID="Button5" runat="server" Text="Volver" Height="32px" 
                      Width="90px"  Visible="False" onclick="Button5_Click" />
                  <asp:Button ID="Button6" runat="server" Text="Desembolsar" Height="32px" 
                      Width="110px"  Visible="False" OnClientClick = "Confirmacion()" onclick="Button6_Click" />
                  
                  <asp:Button ID="Button7" runat="server" Height="32px" Visible="False" 
                      Text="Re-Imprimir" onclick="Button7_Click" />
                  
              </td>

              <td align = "left" class="style4">
                  &nbsp;</td>

          </tr>                             
      </table>
</asp:Content>
