using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGCC.Pages
{
    public partial class pgpConsultaEstadoCredito : System.Web.UI.Page
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

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length > 0)
            {
                Session["param1"] = TextBox1.Text;
                Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrConsultaEstadoCredito.aspx" + "','_blank'); </script>"));
            }

        }
    }
}