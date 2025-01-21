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
    public partial class pgrConsultaMoraHistorico : System.Web.UI.Page
    {
        private ConexBD con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new ConexBD();

            String usuario = (String)Session["usuario"];
            SqlDataAdapter sdadapter = con.rpConsultaMoraHistorico((String)Session["param1"]);


            dsConsultaMoraHistorico ds = new dsConsultaMoraHistorico();

            sdadapter.Fill(ds.tblConsultaMoraHistorico);

            crConsultaMoraHistorico crp = new crConsultaMoraHistorico();

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