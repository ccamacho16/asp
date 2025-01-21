using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;

namespace SGCC.Pages
{
    public partial class pgBackup : System.Web.UI.Page
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
                if (!IsPostBack) {
                    TextBox1.Text = "backup" + DateTime.Now.ToString("ddMMyy") + ".bak";
                    TextBox2.Text = "D:\\Respaldos\\";
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String nombre = TextBox1.Text;
            String dir = TextBox2.Text;
            if (this.validarCampos(nombre, dir))
            {

                String msj = "";
                msj = con.GenerarBackup(dir, nombre);
                if (msj.Length > 0)
                {
                    MessageBoxError(msj);
                }
                else
                {
                    //MessageBoxOK("El backup se ha generado correctamente.");
                    System.Diagnostics.Process.Start("explorer", dir);
                }
            }
        }
        public Boolean validarCampos(String nombre, String dir) {
            Boolean sw = true;
            if ((nombre.Length == 0) || (dir.Length == 0))
            {
                sw = false;
                MessageBoxError("No se permiten campos vacios.");
            }
            return sw;
        }

        private void MessageBoxOK(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "Mensaje");

        }

        private void MessageBoxError(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                TextBox2.Enabled = true;
            }
            else {
                TextBox2.Enabled = false;
            }

        }
    }
}