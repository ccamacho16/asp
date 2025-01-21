using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGCC.Pages
{
    public partial class pgpConsultaCaja : System.Web.UI.Page
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
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox1.Text;


            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrCaja.aspx" + "','_blank'); </script>"));          
        }
    }
}