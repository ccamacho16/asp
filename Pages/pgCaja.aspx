<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgCaja.aspx.cs" Inherits="SGCC.Pages.pgCaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni">CAJA</p>

<table style="width:100%;">
          <tr>
              <td class="style1">
                  Fecha</td>
              <td>
                   
                  <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" Width="127px" 
                      Enabled="False"></asp:TextBox>
                   
              </td>
              <td>
                  &nbsp;</td>
          </tr>   
          <tr>
              <td class="style1">
                  Tipo</td>
              <td>
                  
                  <asp:DropDownList ID="DropDownList1" runat="server">

                     <asp:ListItem Value="Ingreso">Ingreso</asp:ListItem>
                     <asp:ListItem Value="Egreso">Egreso</asp:ListItem>
                    
                  </asp:DropDownList>
                  
              </td>
              <td>
                  &nbsp;</td>
          </tr>     
          <tr>
              <td class="style1" >
                  Concepto</td>
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
                      Width="90px" onclick="Button1_Click"  />
                  <asp:Button ID="Button2" runat="server" Text="Volver" Height="32px" 
                      Width="90px"  Visible="False" onclick="Button2_Click"  />
                  <asp:Button ID="Button3" runat="server" Text="Guardar" Height="32px" 
                      Width="90px" Font-Bold="True" Visible="False" onclick="Button3_Click" />
                  
              </td>
              <td>
                  </td>
          </tr>   
      </table>
     <br />
     <asp:Label ID="Label2" runat="server" style="color: #FF0000"></asp:Label>

     <br />
         <asp:Label ID="Label7" runat="server" 
        style="font-weight: 700; color: #339933; font-size: small" Text="SALDO:  "></asp:Label>
&nbsp;<asp:Label ID="Label8" runat="server" 
        style="color: #000000; font-weight: 700; font-size: small"></asp:Label>
    <br />
     <br />
    <asp:Label ID="Label3" runat="server" style="font-weight: 700; color: #336699;" 
        Text="INGRESO"></asp:Label>
    :&nbsp;
    <asp:Label ID="Label5" runat="server" style="font-weight: 700; color: #000000"></asp:Label>
    <br />
        <asp:GridView ID="GridView1" runat="server"  
        AutoGenerateColumns="false" onrowdatabound="GridView1_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="Concepto" HeaderText="Concepto" ItemStyle-Width="250"/>
            <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-Width="80"/>
        </Columns>        
    </asp:GridView>
    <br />
    <asp:Label ID="Label4" runat="server" style="font-weight: 700; color: #336699;" 
        Text="EGRESO"></asp:Label>
    :&nbsp;
    <asp:Label ID="Label6" runat="server" style="font-weight: 700; color: #000000"></asp:Label>
    <br />
        <asp:GridView ID="GridView2" runat="server" 
        AutoGenerateColumns="false" onrowdatabound="GridView2_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="Concepto" HeaderText="Concepto" ItemStyle-Width="250"/>
            <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-Width="80"/>
        </Columns>        
    </asp:GridView>
    <br />



</asp:Content>
