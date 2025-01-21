using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;
using System.Windows.Forms;

namespace SGCC.Pages
{
    public partial class pgOfiCredito : System.Web.UI.Page
    {
        private ConexBD con;
        //private Boolean nuevooficred;
        //private static Boolean nuevooficred;

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
            this.Siguiente();
            if (TextBox1.Text.Length == 0)
            {

                this.HabParaNuevoOfiCred();
                ViewState["nuevooficred"] = true;
            }
            else
            {
                if (this.MostrarOfiCredSiExiste(int.Parse(TextBox1.Text)) == false)
                {
                    this.Volver();                    
                    this.Message("ERROR: El codigo ingresado no corresponde a ningún Oficial de Crédito.");
                }
                else {
                    ViewState["nuevooficred"] = false;
                }
                
            }
        }
        void HabParaNuevoOfiCred() {
            TextBox1.Text = con.GetIdOfiCred();
            CheckBox1.Enabled = false;
            CheckBox1.Checked = true;

        }

        public Boolean MostrarOfiCredSiExiste(int id) {
            Boolean sw = false;
            var doficre = new List<string>();

            doficre = con.ConsultarOfiCred(id);
            if (doficre.Count > 0)
            {
                
                TextBox2.Text = doficre.ElementAt(1);
                DropDownList1.SelectedValue = doficre.ElementAt(2); 
                TextBox3.Text = doficre.ElementAt(3);
                TextBox4.Text = doficre.ElementAt(4);
                TextBox5.Text = doficre.ElementAt(5);
                String v = doficre.ElementAt(6);
                if (v == "True")
                    CheckBox1.Checked = true;
                else
                    CheckBox1.Checked = false;

                sw = true;

            }

            return sw;
        }

        void Siguiente()
        {
            this.Label2.Text = "";
            Button2.Visible = true;
            Button3.Visible = true;
            TextBox1.Enabled = false;
            TextBox2.Enabled = true;
            DropDownList1.Enabled = true;            
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
            TextBox5.Enabled = true;
            Button1.Visible = false;
            CheckBox1.Enabled = true;
        }
        void Volver()
        {
            Button2.Visible = false;
            Button3.Enabled = true;
            Button3.Visible = false;
            TextBox1.Enabled = true;
            TextBox1.Text = "";
            TextBox2.Enabled = false; TextBox2.Text = "";
            DropDownList1.Enabled = false;            
            TextBox3.Enabled = false; TextBox3.Text = "";
            TextBox4.Enabled = false; TextBox4.Text = "";
            TextBox5.Enabled = false; TextBox5.Text = "";
            this.Label2.Text = "";
            DropDownList1.SelectedIndex = 6;
            Button1.Visible = true;
            ViewState["nuevooficred"] = false;
            CheckBox1.Enabled = false;
            CheckBox1.Checked = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Volver();
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
                if ((bool)ViewState["nuevooficred"])
                {
                    msj = con.InsertarOfiCredito(Int32.Parse(TextBox2.Text), DropDownList1.SelectedValue, TextBox3.Text, TextBox4.Text, TextBox5.Text, CheckBox1.Checked);
                    Label2.Text = msj;
                    if (msj.Length == 0)
                    {
                        this.Message("El Oficial de Credito se guardo con Exito.");
                        
                    }
                }
                else
                {
                    msj = con.ActualizarOfiCredito(Int32.Parse(TextBox1.Text), Int32.Parse(TextBox2.Text), DropDownList1.SelectedValue, TextBox3.Text, TextBox4.Text, TextBox5.Text, CheckBox1.Checked);
                    Label2.Text = msj;
                    if (msj.Length == 0)
                    {
                        this.Message("El Oficial de Credito se actualizo con Exito.");
                    }
                }
                this.bloquear();
            }
            else
            {
                this.Message("ERROR: Existen datos incorrectos.");
                
            }            
        }
        public Boolean datosvalidos()
        {

            if ((TextBox2.Text.Length == 0) || (TextBox3.Text.Length == 0) || (TextBox4.Text.Length == 0) || (TextBox5.Text.Length == 0))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        void bloquear()
        {
            TextBox1.Enabled = false;

            DropDownList1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            TextBox5.Enabled = false;
            CheckBox1.Enabled = false;
            Button3.Enabled = false;
        }
    }
}