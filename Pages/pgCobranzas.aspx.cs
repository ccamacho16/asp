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
    public partial class pgCobranzas : System.Web.UI.Page
    {
        private ConexBD con;
        static DataTable dt;
        static int sSaldoCapital;
        static int sInteres;
        static int sfilaPlanPago;
        /*private DataTable dt;
        private int sSaldoCapital;
        private int sInteres;
        private int sfilaPlanPago;*/
    
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
                    sSaldoCapital = 0;
                    sfilaPlanPago = 0;
                    sInteres = 0;
                    dt = new DataTable();
                    this.tbldatoscuotas.Visible = false;
                    this.tblpagcuotas.Visible = false;

                    TextBox8.Text = DateTime.Now.ToString("dd-MM-yyyy");
                }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.validarcodcliente()){

                DataTable dt = con.ConsultaCabCobranza(TextBox1.Text);
                DropDownList2.Enabled = true;
                DropDownList2.Items.Clear();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        TextBox12.Text = row[1].ToString();
                        ListItem newItem = new ListItem();
                        newItem.Text = row[3].ToString();
                        newItem.Value = row[2].ToString();
                        DropDownList2.Items.Add(newItem);
                    }
                }
                else {
                    TextBox12.Text = "";
                    DropDownList2.Enabled = false;
                    MessageBoxError("El codigo de Cliente NO tiene creditos vigentes.");
                    TextBox1.Text = "";

                }
                Button2.Enabled = true;
            }
            
        }

        public Boolean validarcodcliente() {
            Boolean sw = true;
            String valor = TextBox1.Text;
            if ((valor.Length == 0) || (valor.Length < 7) || (valor.Length > 10))
            {
                sw = false;
                MessageBoxError("Por favor ingrese un Codigo de Cliente valido.");
            }
            return sw;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {            
            if (this.validarcodcliente())
            {
                this.bloquearCabCobranza();
                int idcab = int.Parse(DropDownList2.SelectedValue);
                Boolean sw = this.MostrarDatosCreditoSiExiste(idcab);
                if (sw){
                    this.CargarPlanPagos(idcab);
                   
                            
                }
                this.tbldatoscuotas.Visible = true;
                this.tblpagcuotas.Visible = true;
                TextBox14.Text = "0";
                TextBox3.Text = "0";
                TextBox4.Text = "0";
                
                Button3.Visible = true;
                Button2.Visible = false;

                DropDownList1.Enabled = true;

            }
        }

        public void CargarPlanPagos(int idcab) {
            //DataTable dt = con.ConsultaPlaPagoCredito(idcab);
            dt = con.ConsultaPlaPagoCredito(idcab);
            GridView1.DataSource = dt;
            this.CargarCuotasFaltantes(dt);
            GridView1.DataBind(); 
        }

        public void CargarPlanPagosCobrar(int idcab)
        {
            //DataTable dt = con.ConsultaPlaPagoCredito(idcab);
            dt = con.ConsultaPlaPagoCredito(idcab);
            GridView1.DataSource = dt;
            //this.CargarCuotasFaltantes(dt);
            GridView1.DataBind();
        }

        public void CargarCuotasFaltantes(DataTable dt)
        {            
            DropDownList1.Items.Clear();
            int c = 1;
            String cad = " Cuota";

            ListItem blanco = new ListItem();
            blanco.Text = "----";
            blanco.Value = "0";
            DropDownList1.Items.Add(blanco);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row[6].ToString() == "")
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = c+cad;
                        newItem.Value = ""+c;
                        DropDownList1.Items.Add(newItem);
                        cad = " Cuotas";
                        c++;
                    }
                }
            }

        }

        public Boolean MostrarDatosCreditoSiExiste(int codcre)
        {
            var dcredito = new List<string>();
            Boolean sw = false;
            dcredito = con.ConsultarDatosCredito(codcre);
            Console.WriteLine(dcredito);
            if (dcredito.Count > 0)
            {
                TextBox2.Text = DropDownList2.SelectedValue;
                TextBox6.Text = dcredito.ElementAt(3);
                TextBox5.Text = dcredito.ElementAt(4);
                TextBox13.Text = dcredito.ElementAt(5);
                sw = true;
            }
            return sw;

        }

        public void bloquearCabCobranza(){
            TextBox1.Enabled = false;
            DropDownList2.Enabled = false;
        }

        public void desbloquearCabCobranza()
        {
            TextBox1.Enabled = true;
            TextBox12.Text = "";
            DropDownList2.Enabled = true;
            DropDownList2.Items.Clear();
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
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
            }
        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            Button2.Visible = true;
            Button2.Enabled = false;
            Button3.Visible = false;
            Button4.Enabled = true;
            Button5.Enabled = false;
            this.tbldatoscuotas.Visible = false;
            this.tblpagcuotas.Visible = false;
            this.desbloquearCabCobranza();
            GridView1.DataSource = null;
            GridView1.DataBind();

            TextBox3.Text = "0";
            TextBox3.Enabled = false;
            CheckBox2.Checked = false;
            CheckBox2.Enabled = true;

            TextBox1.Text = "";
        }


        //**************
        // *** COMBO BOX
        //**************
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idcab = int.Parse(DropDownList2.SelectedValue);
            this.CargarPlanPagosCobrar(idcab);

            int c = 1;
            int cuotas = int.Parse(DropDownList1.SelectedValue);
            int maycuotas = this.valorMayorCuotas();
            int monto = 0;
            int mora = 0;
            int interes = 0;
            DateTime fecha;
            DataTable dt1 = new DataTable();
            dt1 = dt;
            if (cuotas > 0)
            {

                if (dt.Rows.Count > 0) // SI TIENE DATOS.
                {
                            if(cuotas == maycuotas){ //PAGO  TODAS LAS CUOTAS
                            
                                        int cfilas = dt.Rows.Count;
                                        int p = 0;
                                        Boolean sw = true;
                                        Boolean sw1 = true;
                                        //-----------------
                                        while (p < cfilas){
                                        //-----------------
                                                if (dt.Rows[p][6].ToString() == ""){ // NO ESTA PAGADO


                                                    if (sw)
                                                    {
                                                                    // EN LA PRIMERA CUOTA PAGA TODO        

                                                                    int xsuma = 0;
                                                                    for (int x = p; x < cfilas; x++)
                                                                    {
                                                                        xsuma = xsuma + int.Parse(dt.Rows[x][2].ToString());
                                                                    }
                                                                    monto = xsuma;

                                                                    sSaldoCapital = monto;

                                                                    fecha = DateTime.Parse(dt.Rows[p][1].ToString());
                                                                    
                                                                    

                                                                    if (DateTime.Now < fecha)
                                                                    {
                                                                        //---------------

                                                                        /*int nroDias = this.PlanPagoValorNumerico();
                                                                        var cabCred = con.ConsultarDatosCredito(idcab);
                                                                        DateTime fechaDif = fecha.AddDays(nroDias*(-1));
                                                                        DateTime fechaCre = DateTime.Parse(cabCred.ElementAt(2));
                                                                        if (fechaCre == fechaDif)
                                                                        {
                                                                            interes = interes + CalculoInteresPagoTotal(DateTime.Now, fecha, int.Parse(dt.Rows[p][3].ToString()), this.PlanPagoValorNumerico(), 0);
                                                                        }
                                                                        else {
                                                                            TimeSpan diferencia = fechaDif.Subtract(fechaCre);
                                                                            int diferenciaDias = (int) diferencia.TotalDays;
                                                                            interes = interes + CalculoInteresPagoTotal(DateTime.Now, fecha, int.Parse(dt.Rows[p][3].ToString()), this.PlanPagoValorNumerico(), diferenciaDias);
                                                                        }*/

                                                                        //---------------
                                                                        interes = interes + CalculoInteresPagoTotal(DateTime.Now, fecha, int.Parse(dt.Rows[p][3].ToString()), this.PlanPagoValorNumerico(), 0);
                                                                        sw1 = false;
                                                                    }else{
                                                                        interes = interes + int.Parse(dt.Rows[p][3].ToString());
                                                                        mora = mora + this.calculoMora(DateTime.Now, fecha);
                                                                    }                                                                    
                                                                    
                                                                    sfilaPlanPago = p+1;
 
                                                                    sw = false;
                                            
                                                        }else {
                                                                if (sw1)
                                                                {
                                                                        fecha = DateTime.Parse(dt.Rows[p][1].ToString());
                                                                        //if (fecha < DateTime.Now)
                                                                        if (DateTime.Now >= fecha)
                                                                        {
                                                                            mora = mora + this.calculoMora(DateTime.Now, fecha);
                                                                            interes = interes + int.Parse(dt.Rows[p][3].ToString());
                                                                        }
                                                                        else
                                                                        {

                                                                            interes = interes + CalculoInteresPagoTotal(DateTime.Now, fecha, int.Parse(dt.Rows[p][3].ToString()), this.PlanPagoValorNumerico(), 0);
                                                                            sw1 = false;
                                                                        }
                                                                }
                                                        }
                                                }                                   
                                                p++;
                                        }

                                        monto = monto + interes;
                                        sInteres = interes;
                            }
                            else{ // PAGO CUOTAS NORMALES
                                       // en el caso de que quiere pagar menor a todas las cuotas
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            if (row[6].ToString() == "")
                                            {
                                                if (c <= cuotas)
                                                {
                                                    monto = monto + int.Parse(row[5].ToString());
                                                    fecha = DateTime.Parse(row[1].ToString());
                                                    if (fecha < DateTime.Now){
                                                        mora = mora + this.calculoMora(DateTime.Now, fecha);
                                                        
                                                    }
                                                }
                                                c++;
                                            }
                                        }
                            }
                }
                TextBox14.Text = "" + monto;
                if (CheckBox2.Checked)
                {
                    TextBox4.Text = "" + (monto + int.Parse(TextBox3.Text) );
                }
                else {
                    TextBox3.Text = "" + mora;
                    TextBox4.Text = "" + (monto + mora);                    
                }

            }
            else
            {
                TextBox14.Text = "0";
                TextBox4.Text = "0";
                TextBox3.Text = "0";
            }
        }

        public int calculoMora(DateTime fpag, DateTime fprog) {
            TimeSpan ts = fpag - fprog;

            Double multamora = Convert.ToDouble((String)Session["vmultamora"]);
            Double paso = (((double)ts.Days) * multamora);

            //--------------------------
            //REVISA SI EXISTEN DIAS FERIADOS. UN FERIADO NUNCA CAE UN DOMINGO.
            int diasN = 0;
            diasN = con.DiasFeriados(fprog.ToString("dd/MM/yyyy"), fpag.ToString("dd/MM/yyyy"));

            //--------------------------
            //CUANDO LA CUOTA CAE UN DIA DOMINGO
            int dia = (int)fprog.DayOfWeek;
            if (dia == 0){
                diasN = diasN + 1;
            }
            paso = paso - (multamora * ((double)diasN));
            //--------------------------

            int monto = 0;

            if (paso > 0){
                monto = Convert.ToInt32(Math.Round(paso, 0));
            }

            return monto;
        }

        public int CalculoInteresPagoTotal(DateTime fpag, DateTime fprog, int montointeres, int formapago, int diasAdicionales) {

            Double InteresDia = ((double)montointeres / (double)formapago);

            TimeSpan ts = fprog - fpag;

            int dias = formapago - (ts.Days + 1);

            //---------------------
            dias = dias + diasAdicionales;
            //---------------------
            
            if (dias > 0){
                Double Interes = (((double)dias) * InteresDia);
                return Convert.ToInt32(Math.Round(Interes, 0));
            }else{
                return 0;
            }
        }

        public int PlanPagoValorNumerico() {
            int n = 0;
            String formapago = TextBox5.Text;
            if (formapago == "Semanal"){
                n = 7;
            }
            if (formapago == "Quincenal")
            {
                n = 15;
            }
            if (formapago == "Mensual")
            {
                n = 30;
            }
            return n;
        }
        //**********************
        // *** BOTON GUARDAR ***
        //**********************
        protected void Button4_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Si")
            {
                this.DropDownList1_SelectedIndexChanged(sender, e);
                int idcab = int.Parse(DropDownList2.SelectedValue);
                /*this.CargarPlanPagosCobrar(idcab);*/

                int c = 1;
                int cuotas = int.Parse(DropDownList1.SelectedValue);
                if (cuotas > 0){
                        //int idcab = int.Parse(DropDownList2.SelectedValue);
                        int maycuotas = this.valorMayorCuotas();
                        int mora = 0;
                        DateTime fecha;

                        int nro = 1;
                        if (cuotas > 0)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                con.BorrarDetCreditoPaso(((String)Session["usuario"]));

                                if (cuotas == maycuotas)
                                {
                                    // CUANDO ES UN PAGO TOTAL
                                    con.ActualizarPagoTodo(idcab, sfilaPlanPago, true, DateTime.Now.Date, sSaldoCapital, int.Parse(TextBox3.Text), sInteres, ((String)Session["usuario"]));

                                }
                                else
                                {
                                    // CUANDO ES UN PAGO PARCIAL
                                    int numfilas = dt.Rows.Count;
                                    foreach (DataRow row in dt.Rows)
                                    {
                                                if (row[6].ToString() == "") // Se cumple apartir de la primera cuota no Pagada
                                                {
                                                    if (c <= cuotas) // Controla la cantidad de cuotas que tiene el pago
                                                    {
                                                        fecha = DateTime.Parse(row[1].ToString());
                                                        mora = 0;

                                                        if (CheckBox2.Checked)
                                                        {
                                                            if (c == 1)
                                                                mora = int.Parse(TextBox3.Text);
                                                        }
                                                        else
                                                        {
                                                            if (fecha < DateTime.Now)
                                                            { // La fecha de pago es menor a la actual?
                                                                mora = this.calculoMora(DateTime.Now, fecha);
                                                            }
                                                        }



                                                        con.ActualizarPago(idcab, nro, true, DateTime.Now.Date, mora, ((String)Session["usuario"]));

                                                        //la siguiente condicion se da, cuando el pago realizado es de la ultima cuota del credito.
                                                        if (int.Parse(row[0].ToString()) == int.Parse(TextBox13.Text))
                                                        {
                                                            con.ActualizarCreditoPagado(idcab);

                                                        }
                                                    }
                                                    c++;

                                                }
                                                nro++;
                                    }
                                    //MessageBoxOK("El pago afecto a las cuotas correspondientes.");
                                }
                            }
                        }

                        dt = con.ConsultaPlaPagoCredito(idcab);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        Session["param1"] = TextBox2.Text;

                        //Response.Write("<script> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>");
                        Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrComprobantePagoCuotas.aspx" + "','_blank'); </script>"));

                        Button4.Enabled = false;
                        Button5.Enabled = true;
                }else{
                    this.MessageBoxError("Por favor seleccionar un número de cuotas a pagar.");
                }
            }
        }

        public int valorMayorCuotas() {
            int d = 0;
            foreach (ListItem item in DropDownList1.Items)
            {
                if (int.Parse(item.Value) > d) {
                    d = int.Parse(item.Value);
                }
            }

            return d;
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBox2.Checked)
            {
                CheckBox2.Enabled = false;
                TextBox3.Enabled = true;
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (TextBox3.Text.Length == 0)
            {
                this.MessageBoxError("Por favor ingrese un valor Numerico correcto.");
                TextBox3.Focus();
            }
            else
            {
                TextBox4.Text = "" + (int.Parse(TextBox14.Text) + int.Parse(TextBox3.Text));               
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox2.Text;

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrComprobantePagoCuotas.aspx" + "','_blank'); </script>"));
        }


    }
}