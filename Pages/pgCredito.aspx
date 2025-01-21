<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgCredito.aspx.cs" Inherits="SGCC.Pages.pgCredito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 106px;
        }
        .style3
        {
            width: 96px;
        }
        .style4
        {
            width: 365px;
        }
        .style5
        {
            width: 62px;
        }
        .style7
        {
            width: 114px;
        }
        .style9
        {
            width: 89px;
        }
        .style11
        {
            width: 83px;
        }
        .style13
        {
            width: 116px;
        }
        .style14
        {
            width: 104px;
        }
        .style15
        {
            width: 133px;
        }
        .style16
        {
            width: 79px;
        }
    </style>
    <script type="text/javascript" src="/Archivos/JSmycode.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> CREDITO</p>
<table style="width:100%;">
          <tr>
              <td class="style3">
                  Codigo</td>
              <td class="style2">
                   <asp:TextBox ID="TextBox1" runat="server" style="text-align: left" 
                      Width="100px" Enabled="False" ></asp:TextBox>
              </td>              
              <td class="style4" align ="right">
                  Fecha&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox9" runat="server" 
                      style="text-align: center" Enabled="False"></asp:TextBox>
              &nbsp;&nbsp;
              </td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>   
          <tr>
              <td class="style3">
                  Cliente</td>
              <td class="style2">
                  <asp:TextBox ID="TextBox3" runat="server" Width="100px" TextMode="Number" 
                      ></asp:TextBox>
              </td>
              <td class="style4">
                  <asp:Button ID="Button1" runat="server" Text="→" onclick="Button1_Click" />
                  <asp:TextBox ID="TextBox4" runat="server" Width="310px" Enabled="False"></asp:TextBox>
              </td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>     
          <tr>
              <td class="style3">
                  Garante</td>
              <td class="style2">
                   <asp:TextBox ID="TextBox5" runat="server" Width="100px" TextMode="Number"></asp:TextBox>
              </td>
              <td class="style4">
                  <asp:Button ID="Button2" runat="server" Text="→" onclick="Button2_Click" />
                  <asp:TextBox ID="TextBox6" runat="server" Width="310px" Enabled="False"></asp:TextBox>
              </td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>
          <tr>
              <td class="style3">
                  Ref. Personal</td>
              <td class="style4" colspan ="2">
                  <asp:TextBox ID="TextBox8" runat="server" Width="460px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
              </td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>
          <tr>
              <td class="style3">
                  Ref. Laboral</td>

              <td class="style4" colspan = "2">
                  <asp:TextBox ID="TextBox12" runat="server" Width="460px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
              </td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>
          <tr>
              <td class="style3">
                  Desc. Garantia</td>

              <td class="style4" colspan = "2">
                  <asp:TextBox ID="TextBox2" runat="server" Width="460px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
              </td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>
          <tr>
              <td class="style3">
                  Ofi. Credito</td>
              <td class="style2">
                   <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="104px" 
                       AutoPostBack="True" 
                       onselectedindexchanged="DropDownList1_SelectedIndexChanged"   >
                   </asp:DropDownList>
              </td>
              <td class="style4">
                  <asp:TextBox ID="TextBox10" runat="server" Width="349px" Enabled="False"></asp:TextBox>
              </td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
          </tr>           

                               
      </table>

        <table style="width:100%;">
        <tr>
        <td class="style3">Forma de Pago</td>
        <td class="style15">
            <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="104px"  AutoPostBack="True"
                onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem Value="7">Semanal</asp:ListItem>
                <asp:ListItem Value="15">Quincenal</asp:ListItem>
                <asp:ListItem Value="30">Mensual</asp:ListItem>
            </asp:DropDownList>
            </td>
        <td class="style16">Monto</td>
        <td class="style13">
            <asp:TextBox ID="TextBox11" runat="server" Width="84px" 
                style="text-align:right" TextMode="Number"></asp:TextBox>
            </td>
        <td class="style9">Plazo (Meses)</td>
        <td class="style14">
        
            <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="88px" AutoPostBack="True"
                onselectedindexchanged="DropDownList3_SelectedIndexChanged" >
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
        
            </td>
        <td class="style11">Nro. Cuotas</td>
        <td>
           
            <asp:TextBox ID="TextBox13" runat="server" Width="100px" 
                style="text-align:right" TextMode="Number" Enabled="False"></asp:TextBox>
           
            </td>
        </tr>
        <tr>
        <td class="style3">Garantia</td>
        <td class="style15">
            <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="104px" 
                AutoPostBack="True" onselectedindexchanged="DropDownList4_SelectedIndexChanged"> 
<%--                <asp:listitem>personal</asp:listitem>
                <asp:listitem>prendatario</asp:listitem>
                <asp:listitem>custodia</asp:listitem>--%>
            </asp:DropDownList>
            </td>
        <td class="style16">Interes (%)</td>
        <td class="style13">
            <asp:DropDownList ID="DropDownList6" runat="server" Height="20px" Width="88px" 
                style="text-align: right">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
            </asp:DropDownList>

            </td>
        <td class="style9">
            Gastos Adm.</td>

        <td class="style7" >
            <asp:TextBox ID="TextBox14" runat="server" Width="86px" style="text-align:right" Enabled="False" ></asp:TextBox>
            </td>
        <td class="style11" >
            Fecha</td>
            <td >
                <asp:TextBox ID="TextBox15" runat="server" TextMode="Date" Width="133px" ></asp:TextBox>
            </td>

        </tr>

        </table>
      <table style="width:100%;">
      <tr>
      <td style="text-align: center">
          
          
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button4" runat="server" Height="32px" Width="120px" Text="↓ Generar" 
              onclick="Button4_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
          <asp:Button ID="Button9" runat="server" Height="32px" Width="90px" 
              Text="Guardar" OnClientClick = "Confirmacion()" onclick="Button9_Click" Enabled="False" />
          <asp:Button ID="Button10" runat="server" Height="32px" ImageUrl="~/Imagenes/print.png"
              Enabled="False" onclick="Button10_Click" Text="▤ Imprimir" Width="88px" />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button11" runat="server" Height="32px" Text=" ☼ Nuevo" 
              onclick="Button11_Click" Enabled="False" Width="86px"/>
          

      </td>
      </tr>
      </table>
&nbsp;
        
     <br />

     <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" 
        AutoGenerateColumns="false" onrowdatabound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Nro" HeaderText="Nro" ItemStyle-Width="40"/>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" ItemStyle-Width="80"/>
            <asp:BoundField DataField="Capital" HeaderText="Capital" ItemStyle-Width="80"/>
            <asp:BoundField DataField="Interes" HeaderText="Interes" ItemStyle-Width="80"/>
            <asp:BoundField DataField="SaldoCapital" HeaderText="Saldo Capital" ItemStyle-Width="110"/>
            <asp:BoundField DataField="TotalBs" HeaderText="Total Bs" ItemStyle-Width="80"/>
        </Columns>        
    </asp:GridView>
      <table style="width:100%;">
      <tr>
      <td style="text-align: center">
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          </td>
      </tr>
      </table>
     <br />
     
</asp:Content>
