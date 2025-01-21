using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGCC.Pages
{
    public partial class pgpPagosRangoFecha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                Session["param1"] = TextBox1.Text;
                Session["param2"] = TextBox2.Text;
                Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPagosRangoFecha.aspx" + "','_blank'); </script>"));
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