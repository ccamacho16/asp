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
    public partial class pgrConsultaMoraClientes : System.Web.UI.Page
    {
        private ConexBD con;
        crConsultaMoraClientes crp;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new ConexBD();

            
            String usuario = (String)Session["usuario"];
            SqlDataAdapter sdadapter = con.rpConsultaMoraClientes((String)Session["param1"], (String)Session["param2"]);

            dsConsultaMoraClientes ds = new dsConsultaMoraClientes();

            sdadapter.Fill(ds.tblConsultaMoraClientes);

            crp = new crConsultaMoraClientes();

            crp.SetDataSource(ds);

            crp.SetParameterValue("usuario", usuario);
            crp.SetParameterValue("fechaactual", DateTime.Now.ToString("dd/MM/yyyy"));
            crp.SetParameterValue("hora", DateTime.Now.ToLongTimeString());
            crp.SetParameterValue("afecha", (String)Session["param1"]);
            //crp.SetParameterValue("aoficred", (String)Session["param2"]);

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