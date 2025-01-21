<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mtPlantilla.Master" AutoEventWireup="true" CodeBehind="pgBackup.aspx.cs" Inherits="SGCC.Pages.pgBackup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 87px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p align="right" style="text-align: right; font-size: x-large; font-family: Aharoni"> BACKUP DATOS</p>
<table style="width:100%;">
           <tr>
              <td class="style1">
                  Archivo</td>
              <td>

                  <asp:TextBox ID="TextBox1" runat="server" style="text-align: left" 
                      Width="159px"></asp:TextBox>

              </td>
              <td>
                  &nbsp;</td>
          </tr>  
          <tr>
              <td class="style1">
                  Ubicación</td>
              <td>
                   
            
                   
                  <asp:TextBox ID="TextBox2" runat="server" Enabled="False" Width="317px"></asp:TextBox>
                  <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                      oncheckedchanged="CheckBox1_CheckedChanged" Text="Habilitar" />
                   
            
                   
              </td>
              <td>
                  &nbsp;</td>
          </tr>   
         
       <tr>
              <td class="style1"></td>
                  
              <td>
                  <asp:Button ID="Button3" runat="server" Text="Generar Backup" Height="32px" 
                      Width="120px" onclick="Button3_Click"  />
                  
              </td>
              <td>
                  </td>
          </tr>   
      </table>
</asp:Content>
