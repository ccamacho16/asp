using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Reportes;
using System.Data;

namespace SGCC.Pages
{
    public partial class pgrPlanPagoSimulacion : System.Web.UI.Page
    {

        crPlanPagosSimulacion crp;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["param1"]; ;

            crp = new crPlanPagosSimulacion();

            crp.Database.Tables["tblPlanPagosSimulacion"].SetDataSource(dt);

            crp.SetParameterValue("formapago", (String)Session["param2"]);
            crp.SetParameterValue("monto", (String)Session["param3"]);
            crp.SetParameterValue("cuotas", (String)Session["param4"]);
            crp.SetParameterValue("meses", (String)Session["param5"]);

            crp.SetParameterValue("usuario", (String)Session["usuario"]);
            crp.SetParameterValue("fechaactual", DateTime.Now.ToString("dd/MM/yyyy"));
            crp.SetParameterValue("hora", DateTime.Now.ToLongTimeString());

            crp.SetParameterValue("enombre", (String)Session["enombre"]);

            crp.SetParameterValue("direccion", (String)Session["edireccion"]);
            crp.SetParameterValue("telefono", (String)Session["etelefono"]);
            crp.SetParameterValue("ciudad", (String)Session["eciudad"]);

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