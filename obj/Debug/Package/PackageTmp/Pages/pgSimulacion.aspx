<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgSimulacion.aspx.cs" Inherits="SGCC.Pages.pgSimulacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 109px;
        }
        .style3
        {
            width: 39px;
        }
        .style10
        {
            width: 64px;
        }
        .style15
        {
            width: 69px;
        }
        .style16
        {
            width: 75px;
        }
        .style17
        {
            width: 68px;
        }
        .style18
        {
            width: 41px;
        }
        .style21
        {
            width: 73px;
        }
        .style22
        {
            width: 66px;
        }
        .style23
        {
            width: 59px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> SIMULACION</p>
        <table style="width:100%;">
        <tr>
        <td class="style16">Forma Pago</td>
        <td class="style1">
            <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="93px" 
                style="margin-left: 0px" AutoPostBack="True"
                onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem Value="7">Semanal</asp:ListItem>
                <asp:ListItem Value="15">Quincenal</asp:ListItem>
                <asp:ListItem Value="30">Mensual</asp:ListItem>
            </asp:DropDownList>
            </td>
        <td class="style3">Monto</td>
        <td class="style21">
            <asp:TextBox ID="TextBox11" runat="server" Width="58px" 
                style="text-align:right" TextMode="Number"  FilterType="Numbers" 
                Height="19px"></asp:TextBox>
            </td>
        <td class="style17">Plazo (Mes)</td>
        <td class="style22">
        
            <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="48px" >
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
        <td class="style10">Interes (%)</td>
        <td class="style15">
           
            
            <asp:DropDownList ID="DropDownList6" runat="server" Height="20px" Width="52px" 
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
        <td class="style18">Cuotas</td>
        <td class="style23">
           
            <asp:TextBox ID="TextBox13" runat="server" Width="43px" 
                style="text-align:right" TextMode="Number" Enabled="False" Height="19px"></asp:TextBox>
           
            </td>
        <td class="style18">Fecha</td>
        <td>
           
            <asp:TextBox ID="TextBox1" runat="server" Width="130px" 
                style="text-align:right" TextMode="Date"></asp:TextBox>
           
            </td>
        </tr>

        </table>
        <br>
        <div align="center">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1"  Height="32px" runat="server" 
        Text="↓ Generar Plan Pago" onclick="Button1_Click" Width="208px" />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="Button2" runat="server" Height="32px" Text="▤ Imprimir" 
                onclick="Button2_Click" Enabled="False"/>
        </div>
    <br>
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
</asp:Content>
