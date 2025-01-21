using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;
using SGCC.Reportes;
using System.Data.SqlClient;

namespace SGCC.Pages
{
    public partial class pgrCaja : System.Web.UI.Page
    {

        private ConexBD con;
        crCaja crp;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new ConexBD();

            String pfecha = (String)Session["param1"];

            if (DateTime.Now.ToString("yyyy-MM-dd") == pfecha)
            {
                con.ActualizaTotalFlujoCaja(Convert.ToDateTime(pfecha));
            }

            String usuario = (String)Session["usuario"];
            SqlDataAdapter sdadapter = con.rpConsultaCaja(pfecha);

            dsCaja ds = new dsCaja();

            sdadapter.Fill(ds.tblCaja);

            crp = new crCaja();

            crp.SetDataSource(ds);

            crp.SetParameterValue("usuario", usuario);
            crp.SetParameterValue("fechaactual", DateTime.Now.ToString("dd/MM/yyyy"));
            crp.SetParameterValue("afecha", (String)Session["param1"]);
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