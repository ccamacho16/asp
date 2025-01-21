using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SGCC.Pages
{
    public partial class pgSimulacion : System.Web.UI.Page
    {
        //private DataTable dt;
        //static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["usuario"] == null)
            {
                Response.Redirect("pgError.aspx");
            }
            else
            {
                
                if (!IsPostBack)
                {

                    TextBox11.Text = "200";


                    DateTime fecha = DateTime.Now;
                    fecha = fecha.AddDays(7);
                    TextBox1.Text = fecha.ToString("yyyy-MM-dd");


                    DataTable dt = new DataTable();

                    dt.Columns.Add("Nro", typeof(int));
                    dt.Columns.Add("Fecha", typeof(string));
                    dt.Columns.Add("Capital", typeof(int));
                    dt.Columns.Add("Interes", typeof(int));
                    dt.Columns.Add("SaldoCapital", typeof(int));
                    dt.Columns.Add("TotalBs", typeof(int));

                    ViewState["miDataTable"] = dt;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(TextBox11.Text, out x))
            {
                if (Convert.ToInt32(TextBox11.Text) >= 200)
                {
                    TextBox13.Text = "" + this.CalcularCuotas();
                    this.GenPlanPagos();

                    this.Button2.Enabled = true;
                }
                else
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('El monto Ingresado tiene que ser >= 200', 3)</script>"));
                }
            }
            else {
                Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('El monto no tiene un valor numerico.', 3)</script>"));
            }
        }

        public int CalcularCuotas()
        {
            int valor = 0;
            if (DropDownList2.SelectedValue == "7")
            {
                valor = int.Parse(DropDownList3.SelectedValue) * 4;
            }
            else
            {
                if (DropDownList2.SelectedValue == "15")
                {
                    valor = int.Parse(DropDownList3.SelectedValue) * 2;
                }
                else
                {
                    valor = int.Parse(DropDownList3.SelectedValue);
                }
            }
            return valor;
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            }
        }
        public int cuotasplanpagos()
        {
            int p = Convert.ToInt32(DropDownList2.SelectedValue);
            int cuotas = 0;
            if (p == 7)
                cuotas = 4;
            if (p == 15)
                cuotas = 2;
            if (p == 30)
                cuotas = 1;
            return cuotas;
        }
        void GenPlanPagos()
        {

            DataTable dt = ViewState["miDataTable"] as DataTable;

            dt.Clear();

            int cuotas = this.cuotasplanpagos();
            int numreg = Convert.ToInt32(TextBox13.Text);
            Double interes = (double)(((double)Convert.ToInt32(DropDownList6.SelectedValue) / (double)100) / (double)cuotas);
            int monto = Convert.ToInt32(TextBox11.Text);
            int montopaso = monto;

            int vnro, vcapital, vinteres, vscapital, vtotal, vinteres_paso, adicional;
            vscapital = monto;
            adicional = 0;

            DateTime vfecha;
           
            vfecha = Convert.ToDateTime(TextBox1.Text);

            Boolean sw = false;

            vnro = 1;
            vcapital = Convert.ToInt32(Math.Round((double)(monto / numreg)));




            int c = 1;
            while (vnro <= numreg)
            {
                // Aumenta los dias de la Forma de Pago.
                vtotal = 0;

                vinteres = Convert.ToInt32(Math.Round(((double)montopaso * interes))) + adicional;


                if (sw == false)
                {
                    vinteres_paso = this.calcularInteres(DateTime.Now, vfecha, Convert.ToInt32(DropDownList2.SelectedValue), vinteres);

                    int diferencia = vinteres_paso - vinteres;

                    if (diferencia > 0)
                    {
                        adicional = Convert.ToInt32(Decimal.Round((decimal)((decimal)diferencia / (decimal)numreg)));

                        vinteres = vinteres + adicional;
                    }
                }
                else
                {
                    if (DropDownList2.SelectedValue == "30")
                    {
                        vfecha = vfecha.AddMonths(1);
                    }
                    else
                    {
                        vfecha = vfecha.AddDays(Convert.ToInt32(DropDownList2.SelectedValue));
                    }
                }

                sw = true;
                
                
                vscapital = vscapital - vcapital;
                vtotal = vcapital + vinteres;
                if (vnro == numreg)
                {
                    vtotal = vtotal + vscapital;
                    vcapital = vcapital + vscapital;                
                    vscapital = 0;
                }
                dt.Rows.Add(vnro, vfecha.ToString("dd-MM-yyyy"), vcapital, vinteres, vscapital, vtotal);

                if (c == cuotas)
                {
                    montopaso = vscapital;
                    c = 1;
                }
                else
                {
                    c++;
                }

                vnro++;
            }



            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();

            DateTime fecha = DateTime.Now;
            fecha = fecha.AddDays(Convert.ToInt32(DropDownList2.SelectedValue));                
            TextBox1.Text = fecha.ToString("yyyy-MM-dd");
        }

        public int calcularInteres(DateTime fechaIni, DateTime FechaFin, int fpago, int interes){
            //int r = 0;
            TimeSpan dias = FechaFin - fechaIni;

            Double InteresDia = ((double)interes / (double)fpago);

            Double r = (InteresDia * ((double)dias.Days + 1));

            return Convert.ToInt32(Math.Round(r, 0));

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState["miDataTable"] as DataTable;

            Session["param1"] = dt;
            Session["param2"] = DropDownList2.SelectedItem.Text;
            Session["param3"] = TextBox11.Text;
            Session["param4"] = TextBox13.Text;
            Session["param5"] = DropDownList3.SelectedItem.Text;
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoSimulacion.aspx" + "','_blank'); </script>"));

            this.Button2.Enabled = false;
        }
    }
}

/*

namespace SGCC.Pages
{
    public partial class pgSimulacion : System.Web.UI.Page
    {
        //private DataTable dt;
        //static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["usuario"] == null)
            {
                Response.Redirect("pgError.aspx");
            }
            else
            {
                
                if (!IsPostBack)
                {

                    TextBox11.Text = "200";


                    DateTime fecha = DateTime.Now;
                    fecha = fecha.AddDays(7);
                    TextBox1.Text = fecha.ToString("yyyy-MM-dd");
                    
                    
                    dt = new DataTable();

                    dt.Columns.Add("Nro", typeof(int));
                    dt.Columns.Add("Fecha", typeof(string));
                    dt.Columns.Add("Capital", typeof(int));
                    dt.Columns.Add("Interes", typeof(int));
                    dt.Columns.Add("SaldoCapital", typeof(int));
                    dt.Columns.Add("TotalBs", typeof(int));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(TextBox11.Text, out x))
            {
                if (Convert.ToInt32(TextBox11.Text) >= 200)
                {
                    TextBox13.Text = "" + this.CalcularCuotas();
                    this.GenPlanPagos();

                    this.Button2.Enabled = true;
                }
                else
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('El monto Ingresado tiene que ser >= 200', 3)</script>"));
                }
            }
            else {
                Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('El monto no tiene un valor numerico.', 3)</script>"));
            }
        }

        public int CalcularCuotas()
        {
            int valor = 0;
            if (DropDownList2.SelectedValue == "7")
            {
                valor = int.Parse(DropDownList3.SelectedValue) * 4;
            }
            else
            {
                if (DropDownList2.SelectedValue == "15")
                {
                    valor = int.Parse(DropDownList3.SelectedValue) * 2;
                }
                else
                {
                    valor = int.Parse(DropDownList3.SelectedValue);
                }
            }
            return valor;
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
            }
        }
        public int cuotasplanpagos()
        {
            int p = Convert.ToInt32(DropDownList2.SelectedValue);
            int cuotas = 0;
            if (p == 7)
                cuotas = 4;
            if (p == 15)
                cuotas = 2;
            if (p == 30)
                cuotas = 1;
            return cuotas;
        }
        void GenPlanPagos()
        {

            dt.Clear();

            int cuotas = this.cuotasplanpagos();
            int numreg = Convert.ToInt32(TextBox13.Text);
            Double interes = (double)(((double)Convert.ToInt32(DropDownList6.SelectedValue) / (double)100) / (double)cuotas);
            int monto = Convert.ToInt32(TextBox11.Text);
            int montopaso = monto;

            int vnro, vcapital, vinteres, vscapital, vtotal, vinteres_paso, adicional;
            vscapital = monto;
            adicional = 0;

            DateTime vfecha;
           
            vfecha = Convert.ToDateTime(TextBox1.Text);

            Boolean sw = false;

            vnro = 1;
            vcapital = Convert.ToInt32(Math.Round((double)(monto / numreg)));




            int c = 1;
            while (vnro <= numreg)
            {
                // Aumenta los dias de la Forma de Pago.
                vtotal = 0;

                vinteres = Convert.ToInt32(Math.Round(((double)montopaso * interes))) + adicional;


                if (sw == false)
                {
                    vinteres_paso = this.calcularInteres(DateTime.Now, vfecha, Convert.ToInt32(DropDownList2.SelectedValue), vinteres);

                    int diferencia = vinteres_paso - vinteres;

                    if (diferencia > 0)
                    {
                        adicional = Convert.ToInt32(Decimal.Round((decimal)((decimal)diferencia / (decimal)numreg)));

                        vinteres = vinteres + adicional;
                    }
                }
                else
                {
                    if (DropDownList2.SelectedValue == "30")
                    {
                        vfecha = vfecha.AddMonths(1);
                    }
                    else
                    {
                        vfecha = vfecha.AddDays(Convert.ToInt32(DropDownList2.SelectedValue));
                    }
                }

                sw = true;
                
                
                vscapital = vscapital - vcapital;
                vtotal = vcapital + vinteres;
                if (vnro == numreg)
                {
                    vtotal = vtotal + vscapital;
                    vcapital = vcapital + vscapital;                
                    vscapital = 0;
                }
                dt.Rows.Add(vnro, vfecha.ToString("dd-MM-yyyy"), vcapital, vinteres, vscapital, vtotal);

                if (c == cuotas)
                {
                    montopaso = vscapital;
                    c = 1;
                }
                else
                {
                    c++;
                }

                vnro++;
            }



            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();

            DateTime fecha = DateTime.Now;
            fecha = fecha.AddDays(Convert.ToInt32(DropDownList2.SelectedValue));                
            TextBox1.Text = fecha.ToString("yyyy-MM-dd");
        }

        public int calcularInteres(DateTime fechaIni, DateTime FechaFin, int fpago, int interes){
            //int r = 0;
            TimeSpan dias = FechaFin - fechaIni;

            Double InteresDia = ((double)interes / (double)fpago);

            Double r = (InteresDia * ((double)dias.Days + 1));

            return Convert.ToInt32(Math.Round(r, 0));

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["param1"] = dt;
            Session["param2"] = DropDownList2.SelectedItem.Text;
            Session["param3"] = TextBox11.Text;
            Session["param4"] = TextBox13.Text;
            Session["param5"] = DropDownList3.SelectedItem.Text;
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoSimulacion.aspx" + "','_blank'); </script>"));

            this.Button2.Enabled = false;
        }
    }
}
*/