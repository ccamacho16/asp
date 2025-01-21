<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgCobranzas.aspx.cs" Inherits="SGCC.Pages.pgCobranzas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 81px;
            height: 26px;
        }
        .style13
        {
            width: 125px;
            height: 26px;
        }
        .style19
        {
            width: 63px;
        }
        .style22
        {
            width: 315px;
        }
        .style25
        {
            width: 51px;
        }
        .style26
        {
            width: 93px;
        }
        .style27
        {
            height: 26px;
        }
        .style28
        {
            width: 116px;
            height: 26px;
        }
        .style29
        {
            width: 60px;
            height: 26px;
        }
        .style30
        {
            width: 83px;
            height: 26px;
        }
        .style31
        {
            width: 123px;
            height: 26px;
        }
        .style32
        {
            width: 57px;
            height: 26px;
        }
        .style33
        {
            color: #546E96;
        }
        </style>
        <script type="text/javascript" src="/Archivos/JSmycode.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> COBRANZAS</p>
<table style="width:100%;">

    <tr>
        <td class="style19">
            CI Cliente</td>
        <td class="style26">
            <asp:TextBox ID="TextBox1" runat="server" Width="86px" ></asp:TextBox>
        </td>
        <td class="style22">
            <asp:Button ID="Button1" runat="server" Text="→" onclick="Button1_Click" />
           
            <asp:TextBox ID="TextBox12" runat="server" Width="271px" Enabled="False"></asp:TextBox>
           
        </td>
        <td class="style25">
            Credito</td>
        <td>
           
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                Height="20px" Width="177px" 
                 Enabled="False" 
                >

            </asp:DropDownList>
           
        </td>
    <td>    
            Fecha</td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server" Enabled="False" Width="104px" style="text-align: center"></asp:TextBox>
          
        </td>
    </tr>
    
    <tr>
        <td colspan="3">
            <asp:Button ID="Button2" runat="server" Height="32px" Width="158px" 
                Text="↓ Siguiente" onclick="Button2_Click" Enabled="False" />
            <asp:Button ID="Button3" runat="server" Height="32px" Width="158px" 
                Text="↑ Volver" onclick="Button3_Click" Visible="False" />
            </td>
    

      
 
                <td>
           </td>
        <td>
           
        </td>
                        <td>
           </td>
          
    </tr>


    <tr>
        <td colspan="3">
            &nbsp;</td>
    

      
 
                <td>
                    &nbsp;</td>
        <td>
           
            &nbsp;</td>
                        <td>
                            &nbsp;</td>
          
    </tr>


</table>
<table runat="server" id="tbldatoscuotas" style="width:100%;" >
    <tr>
        <td class="style3">
            Nro.
            Credito</td>
        <td class="style28">
           
            <asp:TextBox ID="TextBox2" runat="server" Width="90px" Enabled="False" style="text-align:right"></asp:TextBox>
           
        </td>
        <td class="style29">
           
            Monto</td>
        <td class="style13">
            
            <asp:TextBox ID="TextBox6" runat="server" Width="100px" Enabled="False" style="text-align:right"></asp:TextBox>
            
        </td>
        <td class="style30" >
           
            Forma Pago</td>
        <td class="style31">
            <asp:TextBox ID="TextBox5" runat="server" Width="100px" Enabled="False"></asp:TextBox>
            </td>
        <td class="style32">
            Cuotas</td>
        <td class="style31">
            <asp:TextBox ID="TextBox13" runat="server" Enabled="False" Width="65px" style="text-align:right"></asp:TextBox>
            </td>
        <td class="style27">
            Mora</td>
        <td class="style27">
            <asp:TextBox ID="TextBox3" runat="server" Enabled="False" Width="40px" 
                TextMode="Number" AutoPostBack="True"
                style="text-align:right; color: #FF0000;" 
                ontextchanged="TextBox3_TextChanged">0</asp:TextBox>
            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                oncheckedchanged="CheckBox2_CheckedChanged" />
            </td>

    </tr>
   
    
</table>

    <table runat="server" id="tblpagcuotas" >
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Pago Cuota&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Cuotas&nbsp;
            <asp:TextBox ID="TextBox14" runat="server" Enabled="False" Width="70px" style="text-align:right"></asp:TextBox>
         &nbsp;&nbsp;&nbsp;&nbsp;<span class="style33"><strong>Monto Total</strong></span>&nbsp;
                <asp:TextBox ID="TextBox4" runat="server" Enabled="False" Width="70px" 
                    style="text-align:right; font-weight: 700; color: #546E96;"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" Height="32px" Text="Aplicar Pago" 
                    Width="122px" OnClientClick = "Confirmacion()" onclick="Button4_Click" 
                    style="margin-right: 0px" />
                <asp:Button ID="Button5" runat="server" Height="32px" Text="▒ Print" 
                    Enabled="False" onclick="Button5_Click" />
            </td>

        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" 
        AutoGenerateColumns="false" onrowdatabound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Nro" HeaderText="Nro" ItemStyle-Width="40"/>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" ItemStyle-Width="80"/>
            <asp:BoundField DataField="Capital" HeaderText="Capital" ItemStyle-Width="80"/>
            <asp:BoundField DataField="Interes" HeaderText="Interes" ItemStyle-Width="80"/>
            <asp:BoundField DataField="SaldoCapital" HeaderText="Saldo Capital" ItemStyle-Width="110"/>
            <asp:BoundField DataField="TotalBs" HeaderText="Total Bs" ItemStyle-Width="80"/>
            <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-Width="80"/>
        </Columns>        
    </asp:GridView>
</asp:Content>
