using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;

namespace SGCC.Pages
{
    public partial class pgGarantes : System.Web.UI.Page
    {

        private ConexBD con;
        //private Boolean nuevogaran;
        //private static Boolean nuevogaran;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if ((String)Session["usuario"] == null)
            {
                Response.Redirect("pgError.aspx");
            }
            else
            {
                con = new ConexBD();
                if (!IsPostBack) { }
            }      
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.validarci())
            {
                this.Siguiente();
                this.MostrarGaranSiExiste(TextBox1.Text);
            }
            
        }

        public Boolean MostrarGaranSiExiste(String ci)
        {
            var dgarante = new List<string>();

            dgarante = con.ConsultarGarante(ci);
            if (dgarante.Count > 0)
            {
                ViewState["nuevogaran"] = false;
                DropDownList1.SelectedValue = dgarante.ElementAt(1); ;
                TextBox2.Text = dgarante.ElementAt(2);
                TextBox3.Text = dgarante.ElementAt(3);
                TextBox4.Text = dgarante.ElementAt(4);

            }
            return (bool)ViewState["nuevogaran"];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Volver();
        }

        public Boolean validarci() {
            Boolean sw = true;
            String valor = TextBox1.Text;

            if (valor.Length == 0)
            {
                sw = false;
                //this.Label2.Text = "Por favor ingrese un Valor.";
                this.Message("ERROR: Por favor ingrese un Valor.");
            }
            else {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    sw = false;
                    //this.Label2.Text = "La cantidad de caractes, no es correcta";
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            String msj = "";
            if (this.datosvalidos() == true)
            {
                if ((bool)ViewState["nuevogaran"])
                {
                    msj = con.InsertarGarante(TextBox1.Text, DropDownList1.SelectedValue, TextBox2.Text, TextBox3.Text, TextBox4.Text);
                    Label2.Text = msj;
                    if (msj.Length == 0)
                    {
                        this.Message("El Garante se guardo con Exito");                        
                    }
                }
                else
                {
                    msj = con.ActualizarGarante(TextBox1.Text, DropDownList1.SelectedValue, TextBox2.Text, TextBox3.Text, TextBox4.Text);
                    Label2.Text = msj;
                    if (msj.Length == 0)
                    {
                        this.Message("El Garante se actualizo con Exito");                        
                    }
                }
                this.bloquear();
            }
            else
            {
                this.Message("ERROR: Existen datos incorrectos.");                
            }
        }
        void bloquear()
        {
            TextBox1.Enabled = false;

            DropDownList1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;

            Button3.Enabled = false;
        }
        public Boolean datosvalidos()
        {

            if ((TextBox2.Text.Length == 0) || (TextBox3.Text.Length == 0) || (TextBox4.Text.Length == 0))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        void Siguiente()
        {
            this.Label2.Text = "";
            Button2.Visible = true;
            Button3.Visible = true;
            TextBox1.Enabled = false;
            DropDownList1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
            Button1.Visible = false;
            ViewState["nuevogaran"] = true;
        }
        void Volver()
        {
            Button2.Visible = false;
            Button3.Enabled = true;
            Button3.Visible = false;
            TextBox1.Enabled = true;
            TextBox1.Text = "";
            DropDownList1.Enabled = false;
            TextBox2.Enabled = false; TextBox2.Text = "";
            TextBox3.Enabled = false; TextBox3.Text = "";
            TextBox4.Enabled = false; TextBox4.Text = "";
            this.Label2.Text = "";
            DropDownList1.SelectedIndex = 6;
            Button1.Visible = true;
        }
    }
}