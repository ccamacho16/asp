using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;

namespace SGCC.Pages
{
    public partial class pgCastigarCliente : System.Web.UI.Page
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
 

                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.validarci())
            {

                this.Siguiente();
                this.MostrarClieSiExiste(TextBox1.Text);
            }
        }
        void Siguiente()
        {
            this.Label2.Text = "";
            //this.Label1.Text = "";
            Button5.Visible = true;
            Button6.Visible = true;
            Button4.Visible = false;

            TextBox1.Enabled = false;
            DropDownList2.Enabled = true;
 
        }
        public Boolean validarci()
        {
            Boolean sw = true;
            String valor = TextBox1.Text;
            if (valor.Length == 0)
            {
                sw = false;
                this.Message("ERROR: Por favor ingrese un Valor.");
            }
            else
            {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    sw = false;
                    this.Message("ERROR: La cantidad de caractes, NO es correcta.");
                }
            }
            return sw;
        }

        private void Message(string msg)
        {
            //System.Windows.Forms.MessageBox.Show(msg, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        public void MostrarClieSiExiste(String ci)
        {
            var dcliente = new List<string>();

            dcliente = con.ConsultarClienteCastigo(ci);
            if (dcliente.Count > 0)
            {
                //nuevocli = false;
                DropDownList1.SelectedValue = dcliente.ElementAt(1); ;
                TextBox2.Text = dcliente.ElementAt(2);
                TextBox3.Text = dcliente.ElementAt(3);
                TextBox4.Text = dcliente.ElementAt(4);
                TextBox5.Text = dcliente.ElementAt(5);
                TextBox6.Text = dcliente.ElementAt(6);
                TextBox7.Text = dcliente.ElementAt(7);
                DropDownList2.SelectedValue = dcliente.ElementAt(8);

           
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgCastigarCliente.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string msj = "";
            msj = con.ActualizarClienteEstado(TextBox1.Text, DropDownList2.SelectedValue);
            Label2.Text = msj;
            if (msj.Length == 0)
            {
                this.Message("El Cliente ha cambio de Estado");
                Button6.Enabled = false;
                DropDownList2.Enabled = false;
            }
            else
                Label2.Text = msj;
        }

    }
}