using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;
using System.Data.SqlClient;
using SGCC.Reportes;

namespace SGCC.Pages
{
    
    public partial class pgrFlujoCaja : System.Web.UI.Page
    {
        private ConexBD con;
        crFlujoCaja crp;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new ConexBD();


            String usuario = (String)Session["usuario"];

            String fecha1 = (String)Session["param1"];
            String fecha2 = (String)Session["param2"];

            String saldoant = con.GetSaldoAnteriorFC(fecha1);

            SqlDataAdapter sdadapter = con.rpFlujoCaja(fecha1, fecha2, saldoant);

            dsFlujoCaja ds = new dsFlujoCaja();

            sdadapter.Fill(ds.tblFlujoCaja);

            crp = new crFlujoCaja();

            crp.SetDataSource(ds);

            crp.SetParameterValue("usuario", usuario);
            crp.SetParameterValue("fechaactual", DateTime.Now.ToString("dd/MM/yyyy"));
            crp.SetParameterValue("hora", DateTime.Now.ToLongTimeString());
            crp.SetParameterValue("enombre", (String)Session["enombre"]);

            crp.SetParameterValue("direccion", (String)Session["edireccion"]);
            crp.SetParameterValue("telefono", (String)Session["etelefono"]);
            crp.SetParameterValue("ciudad", (String)Session["eciudad"]);

            crp.SetParameterValue("fechaini", fecha1);
            crp.SetParameterValue("fechafin", fecha2);

            crp.SetParameterValue("saldoant", saldoant);

            CrystalReportViewer1.ParameterFieldInfo.Clear();
            CrystalReportViewer1.ReportSource = crp; 
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (crp != null)
            {
                if (crp.IsLoaded)
                {
                    crp.Close();
                    crp.Dispose();
                }

            }
        }
    }
}