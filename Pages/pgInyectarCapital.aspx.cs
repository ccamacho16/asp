using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;

namespace SGCC.Pages
{
    public partial class pgInyectarCapital : System.Web.UI.Page
    {
        private ConexBD con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["usuario"] == null)
            {
                Response.Redirect("pgError.aspx");
            }
            else
            {
                con = new ConexBD();
                if (!IsPostBack)
                {
                    TextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                  
                }
            }
        }

        private void Message(string msg)
        {
            //System.Windows.Forms.MessageBox.Show(msg, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string msj = "";
            if (this.validarDatos())
            {
                msj = con.InyectarCapital(Convert.ToDateTime(TextBox1.Text), "INYECCION CAPITAL", TextBox2.Text, TextBox3.Text.Replace('.', ','), "0.0");

                if (msj.Length == 0)
                {
                    this.Button3.Enabled = false;
                    this.Message("El Capital Inyectado se guardo con Exito.");
                }
                else
                {
                    Label2.Text = msj;
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.validarDatos())
            {
                this.siguiente();
            }
        }

        Boolean validarDatos()
        {

            Boolean sw = true;

            if ((TextBox2.Text.Length == 0) || (TextBox2.Text.Length == 0))
            {
                sw = false;
                this.Message("ERROR: NO se permiten campos vacios.");
                //this.Label2.Text = "NO se permiten campos vacios.";
            }

            return sw;
        }

        void siguiente()
        {
            Button1.Visible = false;
            Button2.Visible = true;
            Button3.Visible = true;

            TextBox1.Enabled = false;
    
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;

            this.Label2.Text = "";
            //this.Label1.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgInyectarCapital.aspx");
        }
    }
}