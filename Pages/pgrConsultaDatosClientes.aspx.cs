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
    public partial class pgrConsultaDatosClientes : System.Web.UI.Page
    {
        private ConexBD con;       
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new ConexBD();

            String ci = (String)Session["param1"];
            String usuario = (String)Session["usuario"];

            SqlDataAdapter sdadapter = con.rpConsultaDatosCliente(ci);

            dsConsultaDatosCliente ds = new dsConsultaDatosCliente();

            sdadapter.Fill(ds.tblConsultaDatosCliente);

            crConsultaDatosCliente crp = new crConsultaDatosCliente();

            crp.SetDataSource(ds);

            crp.SetParameterValue("usuario", usuario);
            crp.SetParameterValue("fechaactual", DateTime.Now.ToString("dd/MM/yyyy"));

            crp.SetParameterValue("enombre", (String)Session["enombre"]);
            crp.SetParameterValue("direccion", (String)Session["edireccion"]);
            crp.SetParameterValue("telefono", (String)Session["etelefono"]);
            crp.SetParameterValue("ciudad", (String)Session["eciudad"]);

            CrystalReportViewer1.ParameterFieldInfo.Clear();
            CrystalReportViewer1.ReportSource = crp;
        }
    }
}