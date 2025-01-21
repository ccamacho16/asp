using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;

namespace SGCC.Pages
{
    public partial class pgRegistrarEgresos : System.Web.UI.Page
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
                    this.cargarGastos();
                }
            }
        }

        public void cargarGastos()
        {
            DropDownList1.Items.Clear();
            var dgastos = new List<string>();
            dgastos = con.ConsultaValor_EntidadTipo("GASTOS", "AGENCIA");
            foreach (String gasto in dgastos)
            {
                DropDownList1.Items.Add(gasto);
            }
         
        }
        
        void siguiente() {
            Button1.Visible = false;
            Button2.Visible = true;
            Button3.Visible = true;

            TextBox1.Enabled = false;
            DropDownList1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = false;
            this.Label2.Text = "";
            //this.Label1.Text = "";
        }

        void volver()
        {
            Button1.Visible = true;
            Button2.Visible = false;
            Button3.Visible = false;

            TextBox1.Enabled = true;
            DropDownList1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            this.Label2.Text = "";
            //this.Label1.Text = "";

        }

        Boolean validarDatos() {

            Boolean sw = true;

            if ((TextBox2.Text.Length == 0)||(TextBox3.Text.Length == 0)){
                sw = false;
                this.Message("ERROR: NO se permiten campos vacios.");
                //this.Label2.Text = "NO se permiten campos vacios.";
            }

            return sw;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (this.validarDatos())
            {
                this.siguiente();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {           
            Response.Redirect("pgRegistrarEgresos.aspx");
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
                msj = con.InsertarEgresos(Convert.ToDateTime(TextBox1.Text), "EGRESO: " + DropDownList1.SelectedValue, TextBox2.Text, "0.0", TextBox3.Text.Replace('.', ','));

                if (msj.Length == 0)
                {
                    //Label1.Text = "El Gasto ingresado se guardo con Exito";
                    this.Button3.Enabled = false;
                    if (CheckBox1.Checked)
                        this.GenerarReporte(Convert.ToDateTime(TextBox1.Text).ToString("dd/MM/yyyy"), DropDownList1.SelectedValue, TextBox2.Text, TextBox3.Text + " Bs.", "COMPROBANTE DE EGRESO");
                    else
                        this.Message("El Egreso se guardo con Exito.");
                }
                else
                    Label2.Text = msj;
            }
        }
        public void GenerarReporte(String fecha, String tipo, String descrip, String monto, String titulo)
        {
            Session["param1"] = fecha;
            Session["param2"] = tipo;
            Session["param3"] = descrip;
            Session["param4"] = monto;
            Session["param5"] = titulo;
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrIngresosEgresos.aspx" + "','_blank'); </script>"));
        }

    }
}