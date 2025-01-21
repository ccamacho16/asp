using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;

namespace SGCC.Pages
{
    public partial class pgAnularCredito : System.Web.UI.Page
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.validarCodCre()) {
                this.MostrarCreditoSiExiste(int.Parse(TextBox1.Text));
         
            }

        }
        public void Siguiente() {
            Button4.Visible = false;
            Button5.Visible = true;
            Button6.Visible = true;
            TextBox1.Enabled = false;
            Label1.Text = "";
            Label2.Text = "";
        }
        public void MostrarCreditoSiExiste(int codcre)
        {
            var dcredito = new List<string>();

            dcredito = con.ConsultarDatosCredito(codcre);
            if (dcredito.Count > 0)
            {
                TextBox2.Text = dcredito.ElementAt(0);
                TextBox3.Text = dcredito.ElementAt(1);
                TextBox4.Text = dcredito.ElementAt(2).Substring(0, 10);
                TextBox5.Text = dcredito.ElementAt(3);
                TextBox6.Text = dcredito.ElementAt(4);
                TextBox7.Text = dcredito.ElementAt(5);
                if (dcredito.ElementAt(6) == "ABIERTO")
                    CheckBox1.Checked = true;
                else
                    CheckBox1.Checked = false;
                this.Siguiente();
            }else{
                this.Label2.Text = "El Codigo de Credito no Existe.";
             
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
                this.Label2.Text = "Por favor ingrese un Numero de Credito.";
            }
            else
            {
                if (!int.TryParse(valor, out a))
                {
                    sw = false;
                    this.Label2.Text = "El Numero de Credito ingresado tiene que ser Numerico.";
                }
            }
            return sw;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgAnularCredito.aspx");
        }

        private void MessageBoxError(string msg)
        {

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {
                if (this.validarCodCre()){
                    if (CheckBox1.Checked == false)
                    {
                        con.ActualizarAnulCredito(int.Parse(TextBox1.Text));
                        this.Label2.Text = "";
                        this.Label1.Text = "El Credito ha sido anulado.";
                        this.Button6.Enabled = false;
                    }
                    else {
                        this.MessageBoxError("Para anular por favor Destickear la opción de Habilitado.");
                    }
                }
            }
        }


    }
}