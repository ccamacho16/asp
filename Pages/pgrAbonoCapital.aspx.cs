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
    public partial class pgrAbonoCapital : System.Web.UI.Page
    {
        private ConexBD con;
        crAbonoCapital crp;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new ConexBD();
                String codcre = (String)Session["param1"];
                String ci = (String)Session["param2"];
                String nomcli = (String)Session["param3"];
                String monto = (String)Session["param4"];
                String nrocuota = (String)Session["param5"];
                String titulo = (String)Session["param6"];

                crp = new crAbonoCapital();

                crp.SetParameterValue("pcodcre", codcre);
                crp.SetParameterValue("pci", ci);
                crp.SetParameterValue("pnombre", nomcli);
                crp.SetParameterValue("pmonto", monto+" Bs.");
                crp.SetParameterValue("pnrocuota", nrocuota);
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