using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;

namespace SGCC.Pages
{
    public partial class pgpDetalleCreditosCSV : System.Web.UI.Page
    {
        private ConexBD con;    
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new ConexBD();
            if ((String)Session["usuario"] == null)
            {
                Response.Redirect("pgError.aspx");
            }
            else
            {

                if (!IsPostBack)
                {
                    TextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String csv = con.rpDetalleCreditoCSV(TextBox1.Text, TextBox2.Text);
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=DetalleCredito.csv");
                Response.Charset = "";
                Response.ContentType = "application/text";
                Response.Output.Write(csv);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                this.MessageBoxError("No son correctos los datos que esta ingresando.");
            }
        }
        private void MessageBoxError(string msg)
        {
            //System.Windows.Forms.MessageBox.Show(msg, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }
    }
}