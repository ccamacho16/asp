using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SGCC.Clases;
using System.Web.UI.DataVisualization.Charting;

namespace SGCC.Pages
{
    public partial class pgPrincipal : System.Web.UI.Page
    {
        //private DataTable dt1;
        //private DataTable dt2;

        static DataTable dt1;
        static DataTable dt2;
        
        private ConexBD con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new ConexBD();

            if ((String)Session["usuario"] == null)
            {
                Response.Redirect("pgError.aspx");
            }
            else
            {
                if (!IsPostBack) {

                    this.CargarGraficoDesembolso();

                    dt1 = new DataTable();
                    dt1.Columns.Add("ID", typeof(int));
                    dt1.Columns.Add("codcli", typeof(string));
                    dt1.Columns.Add("ext", typeof(string));
                    dt1.Columns.Add("nombre", typeof(string));
                    dt1.Columns.Add("telf", typeof(string));
                    dt1.Columns.Add("fecha", typeof(string));
                    dt1.Columns.Add("oficre", typeof(string));
                    dt1.Columns.Add("cuota", typeof(string));
                    dt1.Columns.Add("diasretraso", typeof(int));
                    dt1.Columns.Add("capital", typeof(int));
                    dt1.Columns.Add("interes", typeof(int));
                    dt1.Columns.Add("mora", typeof(int));
                    dt1.Columns.Add("total", typeof(int));

                    dt2 = new DataTable();
                    dt2.Columns.Add("ID", typeof(int));
                    dt2.Columns.Add("codcli", typeof(string));
                    dt2.Columns.Add("ext", typeof(string));
                    dt2.Columns.Add("nombre", typeof(string));
                    dt2.Columns.Add("telf", typeof(string));
                    dt2.Columns.Add("fechaprog", typeof(string));
                    dt2.Columns.Add("oficre", typeof(string));
                    dt2.Columns.Add("forpago", typeof(string));
                    dt2.Columns.Add("cuota", typeof(string));
                    dt2.Columns.Add("capital", typeof(int));
                    dt2.Columns.Add("interes", typeof(int));
                    dt2.Columns.Add("total", typeof(int));
                    dt2.Columns.Add("estado", typeof(string));

                    
                    
                }
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;

            Button1.BorderStyle = BorderStyle.None;
            Button2.BorderStyle = BorderStyle.Double;
            Button3.BorderStyle = BorderStyle.Double;
            Button4.BorderStyle = BorderStyle.Double;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;

            Button1.BorderStyle = BorderStyle.Double;
            Button2.BorderStyle = BorderStyle.None;
            Button3.BorderStyle = BorderStyle.Double;
            Button4.BorderStyle = BorderStyle.Double;

            this.CargarListadoMora();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;

            Button1.BorderStyle = BorderStyle.Double;
            Button2.BorderStyle = BorderStyle.Double;
            Button3.BorderStyle = BorderStyle.None;
            Button4.BorderStyle = BorderStyle.Double;

            this.CargarPagosProg();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;

            Button1.BorderStyle = BorderStyle.Double;
            Button2.BorderStyle = BorderStyle.Double;
            Button3.BorderStyle = BorderStyle.Double;
            Button4.BorderStyle = BorderStyle.None;

        }

        void CargarListadoMora() {

            dt1.Clear();

            String fecha = DateTime.Now.ToString("dd/MM/yyyy");
            dt1 = con.ConsultaClientesMoraIni(fecha);

            GridView1.DataSource = dt1;
            GridView1.DataBind();

            Label1.Text = ""+dt1.Rows.Count;
        }

        void CargarPagosProg()
        {
            dt2.Clear();

            String fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
            String fecha2 = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy");

            dt2 = con.PagosProgFechaIni(fecha1, fecha2);

            GridView2.DataSource = dt2;
            GridView2.DataBind();

            Label2.Text = "" + dt2.Rows.Count;
        }

        void CargarGraficoDesembolso()
        {
            /*
            DataTable dt = con.graDesembolsoOficial();
      

            String[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++ )
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);

               
            }

            Chart1.Series[0].Points.DataBindXY(x,y);
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Series[0].ChartType = SeriesChartType.StackedBar;
            */
     

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Right;

            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Left;

            }
        }



    }
}   