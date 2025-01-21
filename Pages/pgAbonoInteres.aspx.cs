using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;

namespace SGCC.Pages
{
    public partial class pgAbonoInteres : System.Web.UI.Page
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
                if (!IsPostBack) { }
            }
        }

        private void MessageBoxOK(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "Mensaje");

        }

        private void MessageBoxError(string msg)
        {

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        public void Siguiente()
        {
            Button4.Visible = false;
            Button5.Visible = true;
            Button6.Visible = true;

            TextBox1.Enabled = false;

            TextBox4.Enabled = true;
            TextBox4.Text = "0";
            TextBox5.Enabled = true;
            TextBox5.Text = "0";
        }

        public void MostrarCreditoSiExiste(int codcre)
        {
            var dcredito = new List<string>();
            //String fdes = "";
            dcredito = con.ConsultarDatosCredito(codcre);
            if (dcredito.Count > 0)
            {
                TextBox2.Text = dcredito.ElementAt(0);
                TextBox3.Text = dcredito.ElementAt(1);

                this.Siguiente();
            }
            else
            {
                this.MessageBoxError("El Codigo de Credito no Existe.");
            }
        }

        public Boolean validarCodCre()
        {
            Boolean sw = true;
            String valor = TextBox1.Text;
            int a = 0;
            if (valor.Length == 0)
            {
                sw = false;
                this.MessageBoxError("Por favor ingrese un Numero de Credito.");

            }
            else
            {
                if (!int.TryParse(valor, out a))
                {
                    sw = false;
                    this.MessageBoxError("El Numero de Credito ingresado tiene que ser Numerico.");
                }
            }
            return sw;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.validarCodCre())
            {
                this.MostrarCreditoSiExiste(int.Parse(TextBox1.Text));
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgAbonoCapital.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {

                if ((TextBox4.Text.Length > 0) && (TextBox5.Text.Length > 0))
                {
                    if ((Int32.Parse(TextBox4.Text) > 0) && (Int32.Parse(TextBox5.Text) > 0))
                    {
                        //MODIFICAR
                        int interes = con.GetInteresNroCuota(Int32.Parse(TextBox1.Text), Int32.Parse(TextBox5.Text));

                        if (interes >= Int32.Parse(TextBox4.Text))
                        {
                            //MODIFICAR
                            con.ActualizarInteresCuota(Int32.Parse(TextBox1.Text), Int32.Parse(TextBox5.Text), Int32.Parse(TextBox4.Text));

                            Session["param1"] = TextBox1.Text; //codcre
                            Session["param2"] = TextBox2.Text;   //ci cliente
                            Session["param3"] = TextBox3.Text;   //nombre cliente
                            Session["param4"] = TextBox4.Text;  //monto a abonar
                            Session["param5"] = TextBox5.Text;  //nro cuota 
                            Session["param6"] = "ABONO A INTERES";
                            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrAbonoCapital.aspx" + "','_blank'); </script>"));
                        }
                        else
                        {
                            this.MessageBoxError("El monto a abonar es mayor que el interes.");
                        }
                    }
                    else
                    {
                        this.MessageBoxError("Existen valores incorrectos.");
                    }
                }
                else
                {
                    this.MessageBoxError("Existen valores incorrectos.");
                }
            }
        }
    }
}