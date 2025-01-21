using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;
using SGCC.Reportes;

namespace SGCC.Pages
{
    public partial class pgrIngresosEgresos : System.Web.UI.Page
    {
        private ConexBD con;
        crIngresosEgresos crp;
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                con = new ConexBD();
                String fecha = (String)Session["param1"];
                String tipo = (String)Session["param2"];
                String descrip = (String)Session["param3"];
                String monto = (String)Session["param4"];
                String titulo = (String)Session["param5"]; 

                crp = new crIngresosEgresos();

                crp.SetParameterValue("pfecha", fecha);
                crp.SetParameterValue("ptipo", tipo);
                crp.SetParameterValue("pdescrip", descrip);
                crp.SetParameterValue("pmonto", monto);
                crp.SetParameterValue("ptitulo", titulo);
                
                crp.SetParameterValue("usuario", (String)Session["usuario"]);

                crp.SetParameterValue("enombre", (String)Session["enombre"]);

                crp.SetParameterValue("direccion", (String)Session["edireccion"]);
                crp.SetParameterValue("telefono", (String)Session["etelefono"]);
                crp.SetParameterValue("ciudad", (String)Session["eciudad"]);
                crp.SetParameterValue("fechaactual", DateTime.Now.ToString("dd/MM/yyyy"));
                crp.SetParameterValue("hora", DateTime.Now.ToLongTimeString());


                CrystalReportViewer1.ParameterFieldInfo.Clear();
                CrystalReportViewer1.ReportSource = crp;

            }
            catch (Exception ex)
            {
                this.MessageBoxError("No son correctos los datos que esta ingresando.");
            }
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
        private void MessageBoxError(string msg)
        {

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }
    }
}