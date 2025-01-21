using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;
using System.Data;
using System.Collections;

namespace SGCC.Pages
{
    public partial class pgCreditosAlternos : System.Web.UI.Page
    {
        private ConexBD con;
        //private DataTable dt;
        static DataTable dt;
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

                    this.ListTodosOfiCred();
                    DropDownList4.SelectedIndex = 0;
                    TextBox12.Text = DropDownList4.SelectedValue;

                    this.tbldatoscre.Visible = false;
                    this.tblbotones.Visible = false;
                    Button2.Visible = false;

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

        private void ListTodosOfiCred()
        {
            Hashtable h = con.TodosOfiCred();
            ListItem newItem;
            foreach (String cod in h.Keys)
            {
                newItem = new ListItem();
                newItem.Text = cod;
                newItem.Value = h[cod].ToString();
                DropDownList4.Items.Add(newItem);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
   
                DateTime fecha = DateTime.Now;
                fecha = fecha.AddDays(Convert.ToInt16(DropDownList1.SelectedValue));
                TextBox7.Text = fecha.ToString("yyyy-MM-dd");
                TextBox6.Text = "" + this.CalcularCuotas();
            
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

        private void MessageBoxOK(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "Mensaje");

        }

        private void MessageBoxError(string msg)
        {
            //System.Windows.Forms.MessageBox.Show(msg, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        public Boolean validarcodcredito()
        {
            Boolean sw = true;
            String valor = TextBox1.Text;
            if ((valor.Length == 0) || (int.Parse(valor) < 0))
            {
                sw = false;
                MessageBoxError("Por favor ingrese un Codigo de Cliente valido.");
            }
            return sw;
        }
        
        protected void Button4_Click(object sender, EventArgs e)
        { 
            if (this.validarcodcredito()){

                int idcab = int.Parse(TextBox1.Text);
                Boolean sw = this.MostrarDatosCreditoSiExiste(idcab);

                if (sw)
                {
                    this.bloquearDatosConsulta();
                    this.cambioTipoCredito();
                    this.tbldatoscre.Visible = true;
                    this.tblbotones.Visible = true;

                }
               

            }
        }

        public void cambioTipoCredito() {
            TextBox4.Text = "0";
            if (DropDownList2.SelectedValue != "2")
            {
                TextBox4.Enabled = false;
                TextBox5.Enabled = true;
            }
            else
            {
                TextBox4.Enabled = true;
                TextBox5.Enabled = false;
            }

            if (DropDownList2.SelectedValue != "3")
            {
                DropDownList6.Enabled = true;                
            }
            else
            {
                DropDownList6.Enabled = false;                
            }   
        }

        public Boolean MostrarDatosCreditoSiExiste(int codcre)
        {
            var dcredito = new List<string>();
            Boolean sw = false;
            dcredito = con.ConsultarDatosCredito(codcre);
            if (dcredito.Count > 0)
            {

                TextBox2.Text = ""+con.GetSaldoCapital(codcre);
                
                if (TextBox2.Text != "0")
                {
                        //TextBox2.Text = "" + con.GetSaldoCapital(codcre);

                        TextBox9.Text = dcredito.ElementAt(0);
                        TextBox10.Text = dcredito.ElementAt(1);
                        DropDownList1.ClearSelection();
                        DropDownList1.Items.FindByText((String)dcredito.ElementAt(4)).Selected = true; //forma de pago
                        DropDownList1_SelectedIndexChanged(this, new EventArgs());

                        DropDownList3.ClearSelection();
                        DropDownList3.Items.FindByText((String)dcredito.ElementAt(8)).Selected = true; //plazo

                        TextBox5.Text = "0";
                        TextBox6.Text = dcredito.ElementAt(5);

                        DropDownList6.ClearSelection();
                        DropDownList6.Items.FindByText((String)dcredito.ElementAt(9)).Selected = true; //interes


                        //TextBox3.Text = "" + con.GetSumInteresSaldo(codcre);
                        TextBox3.Text = "" + this.CalcularInteresesAnt(codcre, Int32.Parse(DropDownList1.SelectedValue));

                        TextBox4.Text = "0";

                        TextBox8.Text = "" + (Int32.Parse(TextBox2.Text) + Int32.Parse(TextBox3.Text));
                }
                else {
                    //MessageBoxError("Credito no habilitado, por que no tiene ni una cuota pagada.");
                        TextBox9.Text = dcredito.ElementAt(0);
                        TextBox10.Text = dcredito.ElementAt(1);

                        TextBox2.Text = dcredito.ElementAt(3);

                        DropDownList1.ClearSelection();
                        DropDownList1.Items.FindByText((String)dcredito.ElementAt(4)).Selected = true;
                        DropDownList1_SelectedIndexChanged(this, new EventArgs());

                        DropDownList3.ClearSelection();
                        DropDownList3.Items.FindByText((String)dcredito.ElementAt(8)).Selected = true;

                        TextBox5.Text = "0";
                        TextBox6.Text = dcredito.ElementAt(5);

                        DropDownList6.ClearSelection();
                        DropDownList6.Items.FindByText((String)dcredito.ElementAt(9)).Selected = true;


                        //TextBox3.Text = "" + con.GetSumInteresSaldo(codcre);
                        TextBox3.Text = "" + this.CalcularInteresesAnt(codcre, Int32.Parse(DropDownList1.SelectedValue));

                        TextBox4.Text = "0";

                        TextBox8.Text = "" + (Int32.Parse(TextBox2.Text) + Int32.Parse(TextBox3.Text));

                }

                sw = true;

            }
            else
            {
                MessageBoxError("No existe ningun Credito con el número Ingresado.");
            }
            return sw;

        }


        public int CalcularInteresesAnt(int idcreant, int formapago){
            DataTable dt_ant = con.ConsultaPlaPagoCredito(idcreant);

            int cfilas = dt_ant.Rows.Count;
            int p = 0;
            int c = 0;
            int interes = 0;
            DateTime fecha = new DateTime();
            
            while (p < cfilas)
            {

                if (dt_ant.Rows[p][6].ToString() == "")
                {
                    fecha = DateTime.Parse(dt_ant.Rows[p][1].ToString());
                    if (DateTime.Now < fecha)
                    {
                        interes = interes + CalculoInteresPagoTotal(DateTime.Now, fecha, int.Parse(dt_ant.Rows[p][3].ToString()), formapago);
                    }
                    else {
                        // si la fecha actual es mayor o igual a la fecha programada.
                        interes = interes + int.Parse(dt_ant.Rows[p][3].ToString());
                    }
                    c++;
                }
                p++;
            }

            // Esto es para que el sistema cobre por los dias que la mora supera el plan de pagos.
            // Ejemplo el plan de pagos era ENE a ABR y el cliente aparecene JUN, el sistema cobra ABR y JUN
            /*if (DateTime.Now > fecha)
            {
                interes = interes + this.CalculoInteresDiasDemas(fecha, DateTime.Now, interes, c, formapago);
            } */  

            return interes;
        }
        //ufpag = Ultima fecha de Pago       fapag = fecha actual de Pago. 
        public int CalculoInteresDiasDemas(DateTime ufpag, DateTime fapag, int interes, int cuotas, int formapago)
        {
            int Interes = 0;
            Double InteresxDia = (((double)interes / (double)cuotas) / (double)formapago);
            TimeSpan ts = fapag - ufpag;
            int dias = ts.Days - 1;
            if (dias > 0)
                Interes = Convert.ToInt32(Math.Round(InteresxDia * (double)dias,0));
            return (Interes);
        }


        public int CalculoInteresPagoTotal(DateTime fpag, DateTime fprog, int montointeres, int formapago)
        {

            //fpag = DateTime.Parse("25/05/2020");

            Double InteresDia = ((double)montointeres / (double)formapago);

            TimeSpan ts = fprog - fpag;

            int dias = formapago - (ts.Days + 1);

            if (dias > 0)
            {
                Double Interes = (((double)dias) * InteresDia);
                return Convert.ToInt32(Math.Round(Interes, 0));
            }
            else
            {
                return 0;
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if ((TextBox3.Text.Length == 0) || (TextBox4.Text.Length == 0))
            {
                this.MessageBoxError("Por favor ingrese un valor Numerico correcto.");
                TextBox3.Text = "0";
                TextBox8.Text = "0";
                TextBox3.Focus();
            }else{
                TextBox8.Text = "" + (Int32.Parse(TextBox2.Text) + Int32.Parse(TextBox3.Text) + Int32.Parse(TextBox4.Text));                
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e){
            if ((TextBox3.Text.Length == 0) || (TextBox4.Text.Length == 0))
            {
                this.MessageBoxError("Por favor ingrese un valor Numerico correcto.");
                TextBox4.Text = "0";
                TextBox8.Text = "0";
                TextBox4.Focus();
            }
            else
            {
                TextBox8.Text = "" + (Int32.Parse(TextBox2.Text) + Int32.Parse(TextBox3.Text) + Int32.Parse(TextBox4.Text));
            }
        }

        public void bloquearDatosConsulta()
        {
            DropDownList2.Enabled = false;
            TextBox1.Enabled = false;
            Button4.Visible = false;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DropDownList2.Enabled = true;
            TextBox1.Enabled = true;
            TextBox1.Text = "";

            DropDownList2.SelectedIndex = 0;

            Button4.Visible = true;
            Button2.Visible = false;

            this.tbldatoscre.Visible = false;
            this.tblbotones.Visible = false;

            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        public int CalcularCuotas()
        {
            int valor = 0;
            if (DropDownList1.SelectedValue == "7")
            {
                valor = int.Parse(DropDownList3.SelectedValue) * 4;
            }
            else
            {
                if (DropDownList1.SelectedValue == "15")
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

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox6.Text = "" + this.CalcularCuotas();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.GenPlanPagos();
            Button9.Enabled = true;
            Button10.Visible = true;
            Button11.Visible = true;
            if (DropDownList2.SelectedValue == "3")
            {
                TextBox5.Text = "0";
            }
            else {
                TextBox5.Text = this.CalcularGastosAdm();                
            }
        }

        void GenPlanPagos()
        {

            dt.Clear();

            int cuotas = this.cuotasplanpagos();
            int numreg = Convert.ToInt16(TextBox6.Text);
            Double interes = (double)(((double)Convert.ToInt32(DropDownList6.SelectedValue) / (double)100) / (double)cuotas);
            int monto = Convert.ToInt16(TextBox8.Text);
            int montopaso = monto;

            int vnro, vcapital, vinteres, vinteres_paso, vscapital, vtotal, adicional;
            vscapital = monto;
            adicional = 0;
      
            DateTime vfecha = Convert.ToDateTime(TextBox7.Text);

            Boolean sw = false;

            vnro = 1;
            vcapital = Convert.ToInt32(Math.Round((double)(monto / numreg)));

            int c = 1;
            while (vnro <= numreg)
            {               
                vtotal = 0;

                vinteres = Convert.ToInt32(Math.Round(((double)montopaso * interes))) + adicional;

                if (sw == false)
                {
                    vinteres_paso = this.calcularInteres(DateTime.Now, vfecha, Convert.ToInt16(DropDownList1.SelectedValue), vinteres);

                    int diferencia = vinteres_paso - vinteres;

                    if (diferencia > 0)
                    {
                        adicional = Convert.ToInt32(Decimal.Round((decimal)((decimal)diferencia / (decimal)numreg)));

                        vinteres = vinteres + adicional;
                    }                    
                }
                else {
                    if (DropDownList1.SelectedValue == "30")
                    {
                        vfecha = vfecha.AddMonths(1);
                    }
                    else 
                    {
                        vfecha = vfecha.AddDays(Convert.ToInt16(DropDownList1.SelectedValue));
                    }
                }

                sw = true;

                vscapital = vscapital - vcapital;
                vtotal = vcapital + vinteres;
                if (vnro == numreg)
                {
                    vtotal = vtotal + vscapital;
                    vcapital = vcapital + vscapital;
                    //vinteres = Convert.ToInt32(Math.Round(((double)vcapital * interes)));
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

        public int cuotasplanpagos()
        {
            int p = Convert.ToInt16(DropDownList1.SelectedValue);
            int cuotas = 0;
            if (p == 7)
                cuotas = 4;
            if (p == 15)
                cuotas = 2;
            if (p == 30)
                cuotas = 1;
            return cuotas;
        }

        public int calcularInteres(DateTime fechaIni, DateTime FechaFin, int fpago, int interes)
        {
            TimeSpan dias = FechaFin - fechaIni;

            Double InteresDia = ((double)interes / (double)fpago);

            Double r = (InteresDia * ((double)dias.Days + 1));

            return Convert.ToInt32(Math.Round(r, 0));

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {
                //int a = 0;
                var dcredito = new List<string>();
                dcredito = con.ConsultarDatosCredito(Int32.Parse(TextBox1.Text));

                String codcli = dcredito.ElementAt(0);
                String codgar = dcredito.ElementAt(10);
                String refper = dcredito.ElementAt(11);
                String reflab = dcredito.ElementAt(12);

                int oficre = int.Parse(DropDownList4.SelectedItem.Text);
                String nomoficre = TextBox12.Text;

                /*int oficre = int.Parse((String)dcredito.ElementAt(13));
                String nomoficre = dcredito.ElementAt(14);*/

                String forpago = DropDownList1.SelectedItem.Text;
                int monto = int.Parse(TextBox8.Text);
                int plazo = int.Parse(DropDownList3.SelectedItem.Text);
                int nrocuota = int.Parse(TextBox6.Text);
                String garantia = dcredito.ElementAt(7);
                String descgarantia = dcredito.ElementAt(15);
                int interes = int.Parse(DropDownList6.SelectedItem.Text);

                int gasadm = int.Parse(TextBox5.Text);

                String tipocred = DropDownList2.SelectedItem.Text;
                String usuario = (String)Session["usuario"];

                int capital = Int32.Parse(TextBox2.Text);
                int adicional = Int32.Parse(TextBox3.Text);

                int idcabant = Int32.Parse(TextBox1.Text);

                String comentario = "CreditoAnt: " + idcabant + " ; Capital: " + capital + " ; Adicional: " + adicional + " ; Monto Refin: " + TextBox4.Text + " ; Total: " + TextBox8.Text;

                //----------------------------------------------------
                TextBox1.Text = con.InsertCredito(codcli, DateTime.Now, codgar, refper, reflab, oficre, nomoficre, forpago, monto, plazo, nrocuota, garantia, interes, gasadm, usuario, dt, tipocred, comentario, TextBox4.Text, descgarantia);
                int idcabnew = Int32.Parse(TextBox1.Text);

                con.ActualizaPagadoCreAlt(DateTime.Now, idcabant, idcabnew, capital, adicional, tipocred, gasadm);
                //----------------------------------------------------

                Session["param1"] = TextBox1.Text;
                Session["param2"] = "ABIERTO";

                Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>"));


                this.bloquearguardar();

                this.Button10.Enabled = true;
                this.Button11.Enabled = true;
            }
            //int b = 0;
        }

        void bloquearguardar() {
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button4.Enabled = false;
            Button9.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList6.Enabled = false;
            TextBox5.Enabled = false;
            TextBox7.Enabled = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;

        }

        public String CalcularGastosAdm()
        {
            Double gastosadm = Convert.ToDouble((String)Session["vgastosadm"]);
            Double valor = Convert.ToDouble(TextBox8.Text) * gastosadm;
            return "" + Math.Round(valor, 0);
        }


        protected void Button10_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox1.Text;
            Session["param2"] = "ABIERTO";

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>"));
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgCreditosAlternos.aspx");
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox12.Text = DropDownList4.SelectedValue;
        }
    }
}