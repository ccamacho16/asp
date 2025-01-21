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
    public partial class pgrSaldoCapital : System.Web.UI.Page
    {
        private ConexBD con;       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new ConexBD();

                String fecha1 = (String)Session["param1"];
                String fecha2 = (String)Session["param2"];

                SqlDataAdapter sdadapter = con.rpSaldoCapital(fecha1, fecha2);

                dsSaldoCapital ds = new dsSaldoCapital();

                sdadapter.Fill(ds.tblSaldoCapital);

                crSaldoCapital crp = new crSaldoCapital();

                crp.SetDataSource(ds);

                crp.SetParameterValue("usuario", (String)Session["usuario"]);

                crp.SetParameterValue("enombre", (String)Session["enombre"]);

                crp.SetParameterValue("direccion", (String)Session["edireccion"]);
                crp.SetParameterValue("telefono", (String)Session["etelefono"]);
                crp.SetParameterValue("ciudad", (String)Session["eciudad"]);
                crp.SetParameterValue("fechaactual", DateTime.Now.ToString("dd/MM/yyyy"));

                crp.SetParameterValue("fechaini", fecha1);
                crp.SetParameterValue("fechafin", fecha2);

                CrystalReportViewer1.ParameterFieldInfo.Clear();
                CrystalReportViewer1.ReportSource = crp;
            }
            catch (Exception ex)
            {
                this.MessageBoxError("No son correctos los datos que esta ingresando.");
            }
        }

        private void MessageBoxError(string msg)
        {

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }
    }
}