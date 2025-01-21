<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgCreditosAlternos.aspx.cs" Inherits="SGCC.Pages.pgCreditosAlternos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
    .style1
    {
        width: 94px;
    }
    .style2
    {
            width: 134px;
        }
        .style6
        {
            width: 117px;
        }
        .style8
        {
            width: 70px;
        }
        .style9
        {
            width: 88px;
        }
        .style10
        {
            width: 55px;
        }
        .style11
        {
            width: 121px;
        }
        .style15
        {
            width: 116px;
        }
        .style17
        {
            width: 93px;
        }
        .style18
        {
            width: 91px;
        }
        .style19
        {
            width: 106px;
        }
        .style20
        {
            width: 87px;
        }
        .style21
        {
            width: 48px;
        }
    </style>
    <script type="text/javascript" src="/Archivos/JSmycode.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni">CRÉDITOS ALTERNOS</p>
       

        <table style="width:100%;">
        <tr>

        <td class="style1" >Tipo Crédito</td>
        <td class="style2" colspan="2">
            <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" 
                Width="156px"  AutoPostBack="True" >
                <asp:ListItem Value="1">REPROGRAMACION</asp:ListItem>
                <asp:ListItem Value="2">REFINANCIAMIENTO</asp:ListItem>
                <asp:ListItem Value="3">DIFERIMIENTO</asp:ListItem>
            </asp:DropDownList>
            </td>
        
        <td class="style11" ></td>
        <td class="style8" ></td>
        <td class="style6" ></td>
        <td class="style10" ></td>
        <td></td>

        </tr>

        <tr>

        <td class="style1" >Crédito</td>
        <td class="style15" >
                   <asp:TextBox ID="TextBox1" runat="server" style="text-align: right" 
                      Width="100px" TextMode="Number"></asp:TextBox>
            </td>
        <td class="style9" >
                <asp:Button ID="Button4" runat="server" Height="32px" Width="100px" 
                    Text="↓ Consultar" onclick="Button4_Click"/>
                <asp:Button ID="Button2" runat="server" Height="32px" Width="100px" 
                    Text="↑ Volver" onclick="Button2_Click" />
        </td>
        <td class="style11" ></td>
        <td class="style8" ></td>
        <td class="style6" ></td>
        <td class="style10" ></td>
        <td></td>
        </tr>
        </table>

        <table runat="server" id="tbldatoscre"  style="width:100%;">

        <tr>

        <td class="style17" >Cliente:</td>
        <td class="style6"  >
            
            <asp:TextBox ID="TextBox9" runat="server" Width="100px" Enabled="false"></asp:TextBox>

        </td>
        <td  colspan = "4">
            <asp:TextBox ID="TextBox10" runat="server" Width="382px" Enabled="false"></asp:TextBox>
            </td> 
       
        <td class="style21"  ></td>
        <td></td>
        </tr>


        <tr>

        <td class="style17" >Ofi. Credito:</td>
        <td class="style6"  >
            
            
            <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="104px" 
                       AutoPostBack="True" onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                        >
                   </asp:DropDownList>

        </td>
        <td  colspan = "4">
            <asp:TextBox ID="TextBox12" runat="server" Width="382px" Enabled="false"></asp:TextBox>
            </td> 
       
        <td class="style21"  ></td>
        <td></td>
        </tr>


        <tr>

        <td class="style17"  >Forma Pago</td>
        <td class="style6"  >
             <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" 
                 Width="104px"  AutoPostBack="True" 
                 onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="7">Semanal</asp:ListItem>
                <asp:ListItem Value="15">Quincenal</asp:ListItem>
                <asp:ListItem Value="30">Mensual</asp:ListItem>
            </asp:DropDownList>
            </td>
        <td class="style18"  >Plazo (Meses)</td>
        <td class="style19"  >
        <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="90px" AutoPostBack="True"
                onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                style="margin-left: 0px" >
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
        <td class="style20"  >Nro. Cuotas</td>
        <td class="style6" >
                           <asp:TextBox ID="TextBox6" runat="server" 
                      Width="86px" style="text-align:right" TextMode="Number" Enabled="False"></asp:TextBox>
        </td>
        <td class="style21"  ></td>
        <td></td>
        </tr>


        <tr>

        <td class="style17">Interes (%)</td>
        <td class="style6">
            <asp:DropDownList ID="DropDownList6" runat="server" Height="20px" Width="90px" 
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
        <td class="style18"  >Gastos Adm.</td>
        <td class="style19">
                        <asp:TextBox ID="TextBox5" runat="server" 
                      Width="86px" style="text-align:right; color: #FF0000;" TextMode="Number"></asp:TextBox>
        </td>
        <td class="style20" >Fecha</td>
        <td  colspan = "2">
                   <asp:TextBox ID="TextBox7" runat="server" style="text-align: center" 
                      Width="124px" TextMode="Date" ></asp:TextBox>
        </td>
        

        
        <td  ></td>      
        </tr>

        <tr>

        <td class="style17" >Capital</td>
        <td class="style6"  >
                   <asp:TextBox ID="TextBox2" runat="server" style="text-align:right"
                      Width="86px" TextMode="Number" Enabled="False"></asp:TextBox>
            </td>
        <td class="style18"  >Adicional</td>
        <td class="style19"  >
                   <asp:TextBox ID="TextBox3" runat="server" style="text-align: right" 
                      Width="86px" TextMode="Number" AutoPostBack="True" ontextchanged="TextBox3_TextChanged" ></asp:TextBox>
        </td>
        <td class="style20"  >Re-Finan</td>
        <td class="style6"  >
                           <asp:TextBox ID="TextBox4" runat="server" style="text-align: right" 
                      Width="86px" TextMode="Number" AutoPostBack="True" ontextchanged="TextBox4_TextChanged"></asp:TextBox>
        </td>
        <td class="style21"  ><b>Total</b></td>
        <td>
                                   <asp:TextBox ID="TextBox8" runat="server" style="text-align: right; font-weight: 700;" 
                      Width="86px"  Enabled="false"></asp:TextBox>
        </td>
        </tr>
        </table>

 
      <table runat="server" id="tblbotones" style="width:100%;">
      <tr>
      <td style="text-align: center">
          
          
          <asp:Button 
              ID="Button1" runat="server" Height="32px" Width="120px" Text="↓ Generar" onclick="Button1_Click" 
              />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
          <asp:Button ID="Button9" runat="server" Height="32px" Width="90px" 
              Text="Guardar" Enabled="False" OnClientClick = "Confirmacion()" onclick="Button9_Click" />

          <asp:Button ID="Button10" runat="server" Height="32px" ImageUrl="~/Imagenes/print.png"
              Enabled="False" Text="▤ Print" Width="66px" onclick="Button10_Click" />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button11" runat="server" Height="32px" Text=" ☼ New" 
               Enabled="False" Width="66px" onclick="Button11_Click"/>
          

      </td>
      </tr>
      </table>

    &nbsp;
        
     <br />
     <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" 
        AutoGenerateColumns="false" onrowdatabound="GridView1_RowDataBound" >
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
