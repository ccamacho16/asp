using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGCC.Pages
{
    public partial class mtPlantilla : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = "Usuario: " + (String)Session["usuario"];
            this.Label2.Text = " - " + (String)Session["enombre"];
            //MenuItem mnuItem1 = new MenuItem();
            if ((String)Session["TipoUsuario"] == "2") // CAJERA
            {

                MenuItem entidad = NavigationMenu.FindItem("Entidad");
                NavigationMenu.Items.Remove(entidad);

                MenuItem procesos = NavigationMenu.FindItem("Procesos");

                MenuItem creditos = NavigationMenu.FindItem("Procesos/Credito");
                MenuItem creditosalternos = NavigationMenu.FindItem("Procesos/Creditos Alternos");
                procesos.ChildItems.Remove(creditos);
                procesos.ChildItems.Remove(creditosalternos);

                //NavigationMenu.Items.Remove(procesos);

                MenuItem administrar = NavigationMenu.FindItem("Administrar");
                NavigationMenu.Items.Remove(administrar);

                MenuItem reportes = NavigationMenu.FindItem("Reportes");

                MenuItem porcentajepagos = NavigationMenu.FindItem("Reportes/Porcentaje Pagos Cred.");
                MenuItem desemxoficial = NavigationMenu.FindItem("Reportes/Desembolsos x Ofi. Credito");
                MenuItem RepLibroDiario = NavigationMenu.FindItem("Reportes/Libro Diario");
                MenuItem RepSaldoCapital = NavigationMenu.FindItem("Reportes/Saldo Capital");
                MenuItem RepDetalleCredito = NavigationMenu.FindItem("Reportes/Detalle de Creditos [CSV]");
                MenuItem ImpCredito = NavigationMenu.FindItem("Reportes/Imprimir Credito");
                MenuItem HitoricoCreMora = NavigationMenu.FindItem("Reportes/Historico Credito-Mora");

                reportes.ChildItems.Remove(porcentajepagos);
                reportes.ChildItems.Remove(desemxoficial);
                reportes.ChildItems.Remove(RepLibroDiario);
                reportes.ChildItems.Remove(RepSaldoCapital);
                reportes.ChildItems.Remove(RepDetalleCredito);
                reportes.ChildItems.Remove(ImpCredito);
                reportes.ChildItems.Remove(HitoricoCreMora);

            }
            if ((String)Session["TipoUsuario"] == "3") // OFICIAL DE CREDITO
            {
                MenuItem entidad = NavigationMenu.FindItem("Entidad");
                MenuItem OficialCredito = NavigationMenu.FindItem("Entidad/OficialCredito");
                MenuItem usuarios = NavigationMenu.FindItem("Entidad/Usuarios");
                entidad.ChildItems.Remove(OficialCredito);
                entidad.ChildItems.Remove(usuarios);

                MenuItem Transaccciones = NavigationMenu.FindItem("Transacciones");
                NavigationMenu.Items.Remove(Transaccciones);

                MenuItem administrar = NavigationMenu.FindItem("Administrar");
                NavigationMenu.Items.Remove(administrar);

                MenuItem reportes = NavigationMenu.FindItem("Reportes");
                MenuItem pagos = NavigationMenu.FindItem("Reportes/Pagos Realizados");
                
                MenuItem desembolso = NavigationMenu.FindItem("Reportes/Desembolsos");
                //MenuItem desemxoficial = NavigationMenu.FindItem("Reportes/Desembolsos x Ofi. Credito");

                MenuItem otrosIngEgre = NavigationMenu.FindItem("Reportes/Otros Ingresos-Egresos");

                MenuItem librodiario = NavigationMenu.FindItem("Reportes/Libro Diario");
                MenuItem flujocaja = NavigationMenu.FindItem("Reportes/Flujo de Caja");
                MenuItem RepSaldoCapital = NavigationMenu.FindItem("Reportes/Saldo Capital");
                MenuItem Caja = NavigationMenu.FindItem("Reportes/Caja");
                MenuItem detallecredito = NavigationMenu.FindItem("Reportes/Detalle de Creditos [CSV]");

                reportes.ChildItems.Remove(pagos);
                
                reportes.ChildItems.Remove(desembolso);
                //reportes.ChildItems.Remove(desemxoficial);
                reportes.ChildItems.Remove(otrosIngEgre);
                reportes.ChildItems.Remove(RepSaldoCapital);
                reportes.ChildItems.Remove(Caja);

                reportes.ChildItems.Remove(librodiario);
                reportes.ChildItems.Remove(flujocaja);
                reportes.ChildItems.Remove(detallecredito);
            }               
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Session["usuario"] = null;
            Session.Contents.RemoveAll();
        }
    }
}