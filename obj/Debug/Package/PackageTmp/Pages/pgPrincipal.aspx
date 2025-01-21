<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgPrincipal.aspx.cs" Inherits="SGCC.Pages.pgPrincipal" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 464px;
            height: 356px;
        }

    
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <br />
    <strong>Objetivo

    <br />
    </strong>
    <br />
    Es apoyar la gestión de crédito y cobranza, respecto a la administración del crédito asignado al cliente y la recuperación de la obligación del cliente con la empresa.<br />
    <img class="style1" 
        src="../Imagenes/04_odontologia%20lucrativa_ortodontiaSPO%20v51%20n2.png" /><br />
    <br />
    <br />
    <div align="center">    
    © Crisvelco Corporation, Reservados todos los derechos.
    </div>
    --%>
    <div align="right">
    <asp:Button ID="Button1" runat="server" Text=" Inicio " 
        onclick="Button1_Click" BorderStyle="None" BackColor="#465767" 
            BorderColor="#465767" ForeColor="White" style="text-align: center" />
    <asp:Button ID="Button2" runat="server" Text="  Mora " 
        onclick="Button2_Click" BorderStyle="Double" 
            style="padding-left: 0px; text-align: center;" BackColor="#465767" 
            BorderColor="#465767" ForeColor="White" />
    <asp:Button ID="Button3" runat="server" Text=" Pagos " 
        onclick="Button3_Click" BorderStyle="Double" BackColor="#465767" 
            BorderColor="#465767" ForeColor="White" style="text-align: center" />
     <asp:Button ID="Button4" runat="server" Text="Graficos" 
       BorderStyle="Double" BackColor="#465767" 
            BorderColor="#465767" ForeColor="White" style="text-align: center" 
            onclick="Button4_Click" Enabled="False" Visible="False" />
    </div>
    <div>
        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
        <asp:View ID="View1" runat="server">
            <br />
            
            <img class="style1" 
                src="../Imagenes/04_odontologia%20lucrativa_ortodontiaSPO%20v51%20n2.png" /><br />
            <br />
            <br />
            <div align="center">    
            © Crisvelco Corporation, Reservados todos los derechos.
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <br />
            <div style="width: 100%; height: 400px; overflow: scroll">
            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" 
                AutoGenerateColumns="false" Font-Size="Smaller" 
                    onrowdatabound="GridView1_RowDataBound" >
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Credito" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="codcli" HeaderText="Cliente" ItemStyle-Width="60"/>
                    <asp:BoundField DataField="ext" HeaderText="" ItemStyle-Width="20"/>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" ItemStyle-Width="230"/>
                    <asp:BoundField DataField="telf" HeaderText="Telefono" ItemStyle-Width="70"/>
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" ItemStyle-Width="60"/>
                    <asp:BoundField DataField="oficre" HeaderText="OfiCre" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="cuota" HeaderText="Cuota" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="diasretraso" HeaderText="Dias" ItemStyle-Width="30"/>
                    <asp:BoundField DataField="capital" HeaderText="Capital" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="interes" HeaderText="Interes" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="mora" HeaderText="Mora" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-Width="40"/>

                </Columns>        
            </asp:GridView>

            </div>
            <br />
            <b>Num. Registros:</b>             
            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
            <br />
        </asp:View>
        <asp:View ID="View3" runat="server">
            <br />
            <div style="width: 100%; height: 400px; overflow: scroll">
            <asp:GridView ID="GridView2" runat="server" HorizontalAlign="Center" 
                AutoGenerateColumns="false" Font-Size="Smaller" 
                    onrowdatabound="GridView2_RowDataBound" >
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Credito" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="codcli" HeaderText="Cliente" ItemStyle-Width="60"/>
                    <asp:BoundField DataField="ext" HeaderText="" ItemStyle-Width="20"/>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" ItemStyle-Width="230"/>
                    <asp:BoundField DataField="telf" HeaderText="Telefono" ItemStyle-Width="70"/>
                    <asp:BoundField DataField="fechaprog" HeaderText="Fecha" ItemStyle-Width="60"/>
                    <asp:BoundField DataField="oficre" HeaderText="OfiCre" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="forpago" HeaderText="FormaPago" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="cuota" HeaderText="Cuota" ItemStyle-Width="30"/>
                    <asp:BoundField DataField="capital" HeaderText="Capital" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="interes" HeaderText="Interes" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-Width="40"/>
                    <asp:BoundField DataField="estado" HeaderText="Estado" ItemStyle-Width="40"/>

                </Columns>        
            </asp:GridView>

            </div>
            <br />
            <b>Num. Registros:</b>             
            <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
            <br />
        </asp:View>
        <asp:View ID="View4" runat="server">
            <br />

       
            
          

        </asp:View>

        </asp:MultiView>
    </div>

    
</asp:Content>
