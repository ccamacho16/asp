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
    public partial class pgCaja : System.Web.UI.Page
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
                    //this.cargarGastos();
                }

                this.CargarDatosCaja();
            }
        }

        private void Message(string msg)
        {
            //System.Windows.Forms.MessageBox.Show(msg, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        void siguiente()
        {
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

        Boolean validarDatos()
        {

            Boolean sw = true;

            if ((TextBox2.Text.Length == 0) || (TextBox3.Text.Length == 0))
            {
                sw = false;
                this.Message("ERROR: NO se permiten campos vacios.");
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
            Response.Redirect("pgCaja.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string msj = "";

            if (this.validarDatos())
            {
                String usuario = (String)Session["usuario"];
                msj = con.insertarCaja(Convert.ToDateTime(TextBox1.Text), ""+DropDownList1.SelectedValue, TextBox2.Text, TextBox3.Text.Replace('.', ','), usuario);
                 
                if (msj.Length == 0)
                {
                    this.Button3.Enabled = false;
                   
                     //this.GenerarReporte(Convert.ToDateTime(TextBox1.Text).ToString("dd/MM/yyyy"), DropDownList1.SelectedValue, TextBox2.Text, TextBox3.Text + " Bs.", "COMPROBANTE DE EGRESO");

                    this.Message("El " + DropDownList1.SelectedValue + " se guardo con Exito.");

                    this.CargarDatosCaja();
                }
                else
                    Label2.Text = msj;
            }
        }

        public void CargarDatosCaja() {

            con.ActualizaTotalFlujoCaja(Convert.ToDateTime(TextBox1.Text));


            DataTable dt1 = con.ConsultaDatosCaja(Convert.ToDateTime(TextBox1.Text), "Ingreso");
            GridView1.DataSource = dt1;
            GridView1.DataBind();

            String monto = "";
            decimal d1 = 0;

            for (int i = 0; i < dt1.Rows.Count; i++ )
            {
                monto =  dt1.Rows[i]["Monto"].ToString();
                d1 = d1 + Convert.ToDecimal(monto);
            }

            Label5.Text = "" + d1;


           
            DataTable dt2 = con.ConsultaDatosCaja(Convert.ToDateTime(TextBox1.Text), "Egreso");
            GridView2.DataSource = dt2;
            GridView2.DataBind();

            decimal d2 = 0;

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                monto = dt2.Rows[i]["Monto"].ToString();
                d2 = d2 + Convert.ToDecimal(monto);
            }

            Label6.Text = "" + d2;

            Label8.Text = "" + (d1 - d2);
        
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

            }
        }

    }
}