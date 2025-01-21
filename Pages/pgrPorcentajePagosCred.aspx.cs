using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Reportes;
using System.Data;
using SGCC.Clases;
using System.Data.SqlClient;

namespace SGCC.Pages
{
    public partial class pgrPorcentajePagosCred : System.Web.UI.Page
    {
        private ConexBD con;
        crPorcentajePagosCred crp;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new ConexBD();

            SqlDataAdapter sdadapter = con.rpPorcentajePagosCred();

            dsPorcentajePagosCred ds = new dsPorcentajePagosCred();

            sdadapter.Fill(ds.tblPorcentajePagosCred);

         
            crp = new crPorcentajePagosCred();

            crp.SetDataSource(ds);


            crp.SetParameterValue("usuario", (String)Session["usuario"]);
            crp.SetParameterValue("fechaactual", DateTime.Now.ToString("dd/MM/yyyy"));

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