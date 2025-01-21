using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;
using System.Data;

namespace SGCC.Pages
{
    public partial class pgReimprimirPlanPago : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.validarcodcliente())
            {
                DataTable dt = con.ConsultaCabCobranza(TextBox2.Text);
                if (dt.Rows.Count > 0)
                {                    
                    DropDownList1.Enabled = true;
                    DropDownList1.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        TextBox1.Text = row[1].ToString();
                        ListItem newItem = new ListItem();
                        newItem.Text = row[3].ToString();
                        newItem.Value = row[2].ToString();
                        DropDownList1.Items.Add(newItem);
                    }
                    this.CargarDatosCredito();
                }
                else
                {
                    MessageBoxError("El codigo de Cliente NO tiene creditos vigentes.");
                    TextBox2.Text = "";
                }
               
                
            }    
        }

        public Boolean validarcodcliente()
        {
            Boolean sw = true;
            String valor = TextBox2.Text;
            if ((valor.Length == 0) || (valor.Length < 7) || (valor.Length > 10))
            {
                sw = false;
                MessageBoxError("Por favor ingrese un Codigo de Cliente valido.");
            }
            return sw;
        }

        private void MessageBoxOK(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "Mensaje");

        }

        private void MessageBoxError(string msg)
        {            
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarDatosCredito();
            
        }

        public void CargarDatosCredito() {
            int idcab = int.Parse(DropDownList1.SelectedValue);

            var dcredito = new List<string>();

            dcredito = con.ConsultarDatosCredito(idcab);
            if (dcredito.Count > 0)
            {
                TextBox7.Text = "" + idcab;
                TextBox3.Text = dcredito.ElementAt(2).Substring(0, 10);
                TextBox4.Text = dcredito.ElementAt(3);
                TextBox5.Text = dcredito.ElementAt(4);
                TextBox6.Text = dcredito.ElementAt(5);
                TextBox8.Text = dcredito.ElementAt(7);

            }
            else {
                this.MessageBoxError("El codigo de Cliente NO tiene creditos vigentes.");   
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (this.validarcodcliente()){
                if (TextBox7.Text.Length > 0)
                {
                    this.Siguiente();
                }
                else {
                    MessageBoxError("Por favor ingrese un Codigo de Cliente valido.");
                }
            }
        }



        public void Siguiente() {
            Button1.Enabled = false;
            Button2.Visible = false;
            Button3.Visible = true;
            Button4.Visible = true;
            TextBox2.Enabled = false;
            DropDownList1.Enabled = false;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgReimprimirPlanPago.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox7.Text;
            Session["param2"] = "ABIERTO";
          
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>"));
        }
    }
}