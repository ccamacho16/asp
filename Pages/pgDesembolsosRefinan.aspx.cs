using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;

namespace SGCC.Pages
{
    public partial class pgDesembolsosRefinan : System.Web.UI.Page
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.validarCodCre())
            {
                this.MostrarCreditoSiExiste(int.Parse(TextBox1.Text));
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

        public void SiguienteYaDesembolsado()
        {
            Button4.Visible = false;
            Button5.Visible = true;
            Button6.Visible = false;
            Button7.Visible = true;
            TextBox1.Enabled = false;
        }

        public void MostrarCreditoSiExiste(int codcre)
        {
            var dcredito = new List<string>();
            //String fdes = "";
            dcredito = con.ConsultaDatosCreditoDesR(codcre);
            if (dcredito.Count > 0)
            {
                TextBox2.Text = dcredito.ElementAt(0);
                TextBox3.Text = dcredito.ElementAt(1);
                TextBox4.Text = dcredito.ElementAt(2);
                TextBox5.Text = dcredito.ElementAt(3);
                TextBox6.Text = dcredito.ElementAt(4);
                TextBox7.Text = dcredito.ElementAt(5);
                TextBox8.Text = dcredito.ElementAt(8);
                TextBox9.Text = dcredito.ElementAt(9);

                if (TextBox8.Text.Equals(""))
                    this.Siguiente();
                else
                    this.SiguienteYaDesembolsado();
            }
            else
            {
                this.MessageBoxError("El Codigo de Credito no Existe.");
            }
        }

        public void Siguiente()
        {
            Button4.Visible = false;
            Button5.Visible = true;
            Button6.Visible = true;
            TextBox1.Enabled = false;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgDesembolsosRefinan.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {
                if (TextBox8.Text.Length == 0)
                {
                    con.ActualizarFechaDes(int.Parse(TextBox1.Text), DateTime.Now.Date);
                    TextBox8.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                }
                Session["param1"] = TextBox1.Text;
                Session["param2"] = TextBox8.Text;
                Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrComprobantePrestamo.aspx" + "','_blank'); </script>"));
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox1.Text;
            Session["param2"] = TextBox8.Text;
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrComprobantePrestamo.aspx" + "','_blank'); </script>"));
        }

    }
}