using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SGCC.Clases;
using System.Collections;
using System.ComponentModel;


namespace SGCC.Pages
{
    public partial class pgCredito : System.Web.UI.Page
    {
        private ConexBD con;
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
                con = new ConexBD();
                if (!IsPostBack)
                {
                    this.ListTodosOfiCred();

                    this.CargarFormaPago();
                    TextBox11.Text = "200";

                    TextBox9.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    DropDownList1.SelectedIndex = 0;
                    TextBox10.Text = DropDownList1.SelectedValue;
                    TextBox13.Text = "" + this.CalcularCuotas();

                    DateTime fecha = DateTime.Now;
                    fecha = fecha.AddDays(7);
                    TextBox15.Text = fecha.ToString("yyyy-MM-dd");

                   // dt = new DataTable();
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
            var dcliente = new List<string>();
            String valor = TextBox3.Text;

            if (valor.Length > 0)
            {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    this.MessageBoxError("La cantidad de caractes, no es correcta");
                }
                else {
                    dcliente = con.ConsultarCliente(valor);
                    if (dcliente.Count > 0)
                    {
                        bool sw = con.ConsultarEsClienteCastigado(valor);
                        if (sw == false){
                            TextBox4.Text = dcliente.ElementAt(2);
                        }else{
                            this.MessageBoxError("El cliente esta CASTIGADO por incumplimiento de PAGO.");
                        }
                    }
                    else
                    {
                        this.MessageBoxError("El cliente no Existe.");
                    }
                    
                }
            }
            else
            {
                this.MessageBoxError("Ingrese un Codigo de Cliente.");
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

        private void CargarFormaPago() {

            DropDownList4.Items.Clear();
            var dgarantias = new List<string>();
            dgarantias = con.ConsultaValor_EntidadTipo("GARANTIA", "GENERAL");
            foreach (String garantia in dgarantias)
            {

                DropDownList4.Items.Add(garantia);

            }
            DropDownList4.SelectedValue = "Personal";

            /*DropDownList4.Items.Clear();
            Hashtable h = con.ConsultaDatosMasterEntidad("GARANTIA");
            ListItem newItem;
            foreach (String cod in h.Values)
            {
                newItem = new ListItem();
                newItem.Text = cod;
                newItem.Value = cod;
                DropDownList4.Items.Add(newItem);
            }

            DropDownList4.SelectedValue = "Personal";*/

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var dgarante = new List<string>();
            String valor = TextBox5.Text;


            if (valor.Length > 0)
            {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    this.MessageBoxError("La cantidad de caractes, no es correcta");
                }
                else {                    
                    dgarante = con.ConsultarGarante(valor);
                    if (dgarante.Count > 0)
                    {
                        TextBox6.Text = dgarante.ElementAt(2);
                    }
                    else
                    {
                        this.MessageBoxError("El Garante no Existe.");
                    }
                }
            }
            else
            {
                this.MessageBoxError("Ingrese un Codigo de Garante.");
            }
            
        }

        private void ListTodosOfiCred() {
            Hashtable h = con.TodosOfiCred();
            ListItem newItem;
            foreach (String cod in h.Keys)
            {
                newItem = new ListItem();
                newItem.Text = cod;                
                newItem.Value = h[cod].ToString();
                DropDownList1.Items.Add(newItem);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox10.Text = DropDownList1.SelectedValue;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.ValidarCamposGuardar() == true)
            {
                 if (Convert.ToInt32(TextBox11.Text) >= 200)
                 {
              
                    //TextBox13.Text = "" + this.CalcularCuotas();
                    TextBox14.Text = this.CalcularGastosAdm();
                    this.GenPlanPagos();

                    Button9.Enabled = true;                    
                    Button10.Visible = true;
                    Button11.Visible = true;
                }else
                 {
                     MessageBoxError("El monto ingresado tiene que ser >= 200 Bs.");
                 }
            }

        }

        void GenPlanPagos() {

            DataTable dt = ViewState["miDataTable"] as DataTable;

            dt.Clear();

            int cuotas = this.cuotasplanpagos();
            int numreg = Convert.ToInt32(TextBox13.Text);
            Double interes = (double)(((double)Convert.ToInt32(DropDownList6.SelectedValue) / (double)100)/(double)cuotas);
            int monto = Convert.ToInt32(TextBox11.Text);            
            int montopaso = monto;

            int vnro, vcapital, vinteres, vinteres_paso, vscapital, vtotal, adicional;
            vscapital = monto;
            adicional = 0;

            DateTime vfecha = Convert.ToDateTime(TextBox9.Text);

            vfecha = Convert.ToDateTime(TextBox15.Text);
   
            Boolean sw = false;

            vnro = 1;
            vcapital = Convert.ToInt32(Math.Round( (double) (monto/numreg) ));
            
            

            
                    int c = 1;
                    while (vnro <= numreg)
                    {
                        //vfecha = vfecha.AddDays(Convert.ToInt16(DropDownList2.SelectedValue)); 
                        vtotal = 0;

                        vinteres = Convert.ToInt32(Math.Round(((double)montopaso * interes))) + adicional;

                        if (sw == false)
                        {
                            vinteres_paso = this.calcularInteres(DateTime.Now, vfecha, Convert.ToInt32(DropDownList2.SelectedValue), vinteres);

                            int diferencia = vinteres_paso - vinteres;

                            if (diferencia > 0)
                            {
                                adicional = Convert.ToInt32(Decimal.Round((decimal)((decimal) diferencia / (decimal) numreg)));

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
                            //vinteres = Convert.ToInt32(Math.Round(((double)vcapital * interes)));
                            vscapital = 0;
                        }
                        dt.Rows.Add(vnro, vfecha.ToString("dd-MM-yyyy"), vcapital, vinteres, vscapital, vtotal);

                        if (c == cuotas){
                            montopaso = vscapital;
                            c = 1;
                        }else{
                            c++;
                        }

                        vnro++;
                    }
            


            GridView1.DataSource = dt;
            GridView1.DataBind(); 
        }

        public int cuotasplanpagos() {
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

        public int CalcularCuotas() { 
            int valor = 0;
            if (DropDownList2.SelectedValue == "7")
            {
                valor = int.Parse(DropDownList3.SelectedValue) * 4;
            }
            else {
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

        public String CalcularGastosAdm()
        {
            Double gastosadm = Convert.ToDouble((String)Session["vgastosadm"]);
            Double valor = Convert.ToDouble(TextBox11.Text) * gastosadm;
            return "" + Math.Round(valor,0);
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

        protected void Button9_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];

            DataTable dt = ViewState["miDataTable"] as DataTable;

            if (confirmValue == "Si")
            {
                if (this.ValidarCamposGuardar())
                {
                    String codcli = TextBox3.Text;
                    String codgar = TextBox5.Text;
                    String refper = TextBox8.Text;
                    String reflab = TextBox12.Text;
                    String descgarantia = TextBox2.Text;
                    int oficre = int.Parse(DropDownList1.SelectedItem.Text);
                    String nomoficre = TextBox10.Text;
                    String forpago = DropDownList2.SelectedItem.Text;
                    int monto = int.Parse(TextBox11.Text);
                    int plazo = int.Parse(DropDownList3.SelectedItem.Text);
                    int nrocuota = int.Parse(TextBox13.Text);
                    String garantia = DropDownList4.SelectedItem.Text;
                    int interes = int.Parse(DropDownList6.SelectedItem.Text);
                    int gasadm = int.Parse(TextBox14.Text);
                    String usuario = (String)Session["usuario"];

                    TextBox1.Text = con.InsertCredito(codcli, Convert.ToDateTime(TextBox9.Text), codgar, refper, reflab, oficre, nomoficre, forpago, monto, plazo, nrocuota, garantia, interes, gasadm, usuario, dt, "NORMAL", "", "", descgarantia);

                    Session["param1"] = TextBox1.Text;
                    Session["param2"] = "ABIERTO";

                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>"));


                    this.bloquearguardar();

                    this.Button10.Enabled = true;
                    this.Button11.Enabled = true;
                }
            }
        }
        void bloquearguardar() {
            TextBox1.Enabled = false;
            TextBox3.Enabled = false;
            TextBox5.Enabled = false;
            TextBox8.Enabled = false;
            TextBox12.Enabled = false;
            TextBox2.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList2.Enabled = false;
            TextBox11.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList6.Enabled = false;
            Button4.Enabled = false;
            Button9.Enabled = false;
        }

        Boolean ValidarCamposGuardar() {
            Boolean sw = true;
            String valor = TextBox3.Text;
            int x;
            if (valor.Length == 0)
            {
                sw = false;
                MessageBoxError("Por favor ingrese un CI de CLIENTE Valido.");
            }
            else
            {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    sw = false;
                    MessageBoxError("La Cantidad de caracteres para CI del CLIENTE, no es Correcto.");
                }
            }

            valor = TextBox5.Text;
            if (DropDownList4.SelectedValue == "Personal")
            {
                if (valor.Length == 0)
                {
                    sw = false;
                    MessageBoxError("Por favor ingrese un CI de GARANTE Valido.");
                }
                else
                {
                    if ((valor.Length > 10) || (valor.Length < 7))
                    {
                        sw = false;
                        MessageBoxError("La Cantidad de caracteres para CI del GARANTE, no es Correcto.");
                    }
                }
            }
            if (TextBox8.Text.Length == 0)
            {
                sw = false;
                MessageBoxError("No se permite datos en blanco, para la Ref. personal ");
            }           

            if (TextBox12.Text.Length == 0)
            {
                sw = false;
                MessageBoxError("No se permite datos en blanco, para la Ref. Laboral ");
            }

            if (TextBox2.Text.Length == 0)
            {
                sw = false;
                MessageBoxError("No se permite datos en blanco, para la Descrip. de la Garantia ");
            }

            if (!int.TryParse(TextBox11.Text, out x))
            {
                sw = false;
                MessageBoxError("El monto NO tiene un valor numerico.");
            }

            return sw;

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgCredito.aspx");
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList4.SelectedValue == "Personal")
            {
                TextBox5.Enabled = true;

            }
            else {
                TextBox5.Enabled = false;             

            }
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox1.Text;
            Session["param2"] = "ABIERTO";
            
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>"));
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["param1"] = TextBox1.Text;
            Session["param2"] = "ABIERTO";

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>"));
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            fecha = fecha.AddDays(Convert.ToInt32(DropDownList2.SelectedValue));
            TextBox15.Text = fecha.ToString("yyyy-MM-dd");
               
            TextBox13.Text = "" + this.CalcularCuotas();
        }

        public int calcularInteres(DateTime fechaIni, DateTime FechaFin, int fpago, int interes)
        {
            //int r = 0;
            TimeSpan dias = FechaFin - fechaIni;

            Double InteresDia = ((double)interes / (double)fpago);

            Double r = (InteresDia * ((double)dias.Days + 1));

            return Convert.ToInt32(Math.Round(r, 0));

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox13.Text = "" + this.CalcularCuotas();
        }


    }
}

/*
namespace SGCC.Pages
{
    public partial class pgCredito : System.Web.UI.Page
    {
        private ConexBD con;
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
                con = new ConexBD();
                if (!IsPostBack)
                {
                    this.ListTodosOfiCred();

                    this.CargarFormaPago();
                    TextBox11.Text = "200";

                    TextBox9.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    DropDownList1.SelectedIndex = 0;
                    TextBox10.Text = DropDownList1.SelectedValue;
                    TextBox13.Text = "" + this.CalcularCuotas();

                    DateTime fecha = DateTime.Now;
                    fecha = fecha.AddDays(7);
                    TextBox15.Text = fecha.ToString("yyyy-MM-dd");

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
            var dcliente = new List<string>();
            String valor = TextBox3.Text;

            if (valor.Length > 0)
            {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    this.MessageBoxError("La cantidad de caractes, no es correcta");
                }
                else {
                    dcliente = con.ConsultarCliente(valor);
                    if (dcliente.Count > 0)
                    {
                        bool sw = con.ConsultarEsClienteCastigado(valor);
                        if (sw == false){
                            TextBox4.Text = dcliente.ElementAt(2);
                        }else{
                            this.MessageBoxError("El cliente esta CASTIGADO por incumplimiento de PAGO.");
                        }
                    }
                    else
                    {
                        this.MessageBoxError("El cliente no Existe.");
                    }
                    
                }
            }
            else
            {
                this.MessageBoxError("Ingrese un Codigo de Cliente.");
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

        private void CargarFormaPago() {

            DropDownList4.Items.Clear();
            var dgarantias = new List<string>();
            dgarantias = con.ConsultaValor_EntidadTipo("GARANTIA", "GENERAL");
            foreach (String garantia in dgarantias)
            {

                DropDownList4.Items.Add(garantia);

            }
            DropDownList4.SelectedValue = "Personal";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var dgarante = new List<string>();
            String valor = TextBox5.Text;


            if (valor.Length > 0)
            {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    this.MessageBoxError("La cantidad de caractes, no es correcta");
                }
                else {                    
                    dgarante = con.ConsultarGarante(valor);
                    if (dgarante.Count > 0)
                    {
                        TextBox6.Text = dgarante.ElementAt(2);
                    }
                    else
                    {
                        this.MessageBoxError("El Garante no Existe.");
                    }
                }
            }
            else
            {
                this.MessageBoxError("Ingrese un Codigo de Garante.");
            }
            
        }

        private void ListTodosOfiCred() {
            Hashtable h = con.TodosOfiCred();
            ListItem newItem;
            foreach (String cod in h.Keys)
            {
                newItem = new ListItem();
                newItem.Text = cod;                
                newItem.Value = h[cod].ToString();
                DropDownList1.Items.Add(newItem);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox10.Text = DropDownList1.SelectedValue;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.ValidarCamposGuardar() == true)
            {
                 if (Convert.ToInt32(TextBox11.Text) >= 200)
                 {
              
                    TextBox14.Text = this.CalcularGastosAdm();
                    this.GenPlanPagos();

                    Button9.Enabled = true;                    
                    Button10.Visible = true;
                    Button11.Visible = true;
                }else
                 {
                     MessageBoxError("El monto ingresado tiene que ser >= 200 Bs.");
                 }
            }

        }

        void GenPlanPagos() {

            dt.Clear();

            int cuotas = this.cuotasplanpagos();
            int numreg = Convert.ToInt32(TextBox13.Text);
            Double interes = (double)(((double)Convert.ToInt32(DropDownList6.SelectedValue) / (double)100)/(double)cuotas);
            int monto = Convert.ToInt32(TextBox11.Text);            
            int montopaso = monto;

            int vnro, vcapital, vinteres, vinteres_paso, vscapital, vtotal, adicional;
            vscapital = monto;
            adicional = 0;

            DateTime vfecha = Convert.ToDateTime(TextBox9.Text);

            vfecha = Convert.ToDateTime(TextBox15.Text);
   
            Boolean sw = false;

            vnro = 1;
            vcapital = Convert.ToInt32(Math.Round( (double) (monto/numreg) ));
            
            

            
                    int c = 1;
                    while (vnro <= numreg)
                    {
                        vtotal = 0;

                        vinteres = Convert.ToInt32(Math.Round(((double)montopaso * interes))) + adicional;

                        if (sw == false)
                        {
                            vinteres_paso = this.calcularInteres(DateTime.Now, vfecha, Convert.ToInt32(DropDownList2.SelectedValue), vinteres);

                            int diferencia = vinteres_paso - vinteres;

                            if (diferencia > 0)
                            {
                                adicional = Convert.ToInt32(Decimal.Round((decimal)((decimal) diferencia / (decimal) numreg)));

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

                        if (c == cuotas){
                            montopaso = vscapital;
                            c = 1;
                        }else{
                            c++;
                        }

                        vnro++;
                    }
            


            GridView1.DataSource = dt;
            GridView1.DataBind(); 
        }

        public int cuotasplanpagos() {
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

        public int CalcularCuotas() { 
            int valor = 0;
            if (DropDownList2.SelectedValue == "7")
            {
                valor = int.Parse(DropDownList3.SelectedValue) * 4;
            }
            else {
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

        public String CalcularGastosAdm()
        {
            Double gastosadm = Convert.ToDouble((String)Session["vgastosadm"]);
            Double valor = Convert.ToDouble(TextBox11.Text) * gastosadm;
            return "" + Math.Round(valor,0);
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

        protected void Button9_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Si")
            {
                if (this.ValidarCamposGuardar())
                {
                    String codcli = TextBox3.Text;
                    String codgar = TextBox5.Text;
                    String refper = TextBox8.Text;
                    String reflab = TextBox12.Text;
                    String descgarantia = TextBox2.Text;
                    int oficre = int.Parse(DropDownList1.SelectedItem.Text);
                    String nomoficre = TextBox10.Text;
                    String forpago = DropDownList2.SelectedItem.Text;
                    int monto = int.Parse(TextBox11.Text);
                    int plazo = int.Parse(DropDownList3.SelectedItem.Text);
                    int nrocuota = int.Parse(TextBox13.Text);
                    String garantia = DropDownList4.SelectedItem.Text;
                    int interes = int.Parse(DropDownList6.SelectedItem.Text);
                    int gasadm = int.Parse(TextBox14.Text);
                    String usuario = (String)Session["usuario"];

                    TextBox1.Text = con.InsertCredito(codcli, Convert.ToDateTime(TextBox9.Text), codgar, refper, reflab, oficre, nomoficre, forpago, monto, plazo, nrocuota, garantia, interes, gasadm, usuario, dt, "NORMAL", "", "", descgarantia);

                    Session["param1"] = TextBox1.Text;
                    Session["param2"] = "ABIERTO";

                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>"));


                    this.bloquearguardar();

                    this.Button10.Enabled = true;
                    this.Button11.Enabled = true;
                }
            }
        }
        void bloquearguardar() {
            TextBox1.Enabled = false;
            TextBox3.Enabled = false;
            TextBox5.Enabled = false;
            TextBox8.Enabled = false;
            TextBox12.Enabled = false;
            TextBox2.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList2.Enabled = false;
            TextBox11.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList6.Enabled = false;
            Button4.Enabled = false;
            Button9.Enabled = false;
        }

        Boolean ValidarCamposGuardar() {
            Boolean sw = true;
            String valor = TextBox3.Text;
            int x;
            if (valor.Length == 0)
            {
                sw = false;
                MessageBoxError("Por favor ingrese un CI de CLIENTE Valido.");
            }
            else
            {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    sw = false;
                    MessageBoxError("La Cantidad de caracteres para CI del CLIENTE, no es Correcto.");
                }
            }

            valor = TextBox5.Text;
            if (DropDownList4.SelectedValue == "Personal")
            {
                if (valor.Length == 0)
                {
                    sw = false;
                    MessageBoxError("Por favor ingrese un CI de GARANTE Valido.");
                }
                else
                {
                    if ((valor.Length > 10) || (valor.Length < 7))
                    {
                        sw = false;
                        MessageBoxError("La Cantidad de caracteres para CI del GARANTE, no es Correcto.");
                    }
                }
            }
            if (TextBox8.Text.Length == 0)
            {
                sw = false;
                MessageBoxError("No se permite datos en blanco, para la Ref. personal ");
            }           

            if (TextBox12.Text.Length == 0)
            {
                sw = false;
                MessageBoxError("No se permite datos en blanco, para la Ref. Laboral ");
            }

            if (TextBox2.Text.Length == 0)
            {
                sw = false;
                MessageBoxError("No se permite datos en blanco, para la Descrip. de la Garantia ");
            }

            if (!int.TryParse(TextBox11.Text, out x))
            {
                sw = false;
                MessageBoxError("El monto NO tiene un valor numerico.");
            }

            return sw;

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgCredito.aspx");
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList4.SelectedValue == "Personal")
            {
                TextBox5.Enabled = true;

            }
            else {
                TextBox5.Enabled = false;             

            }
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox1.Text;
            Session["param2"] = "ABIERTO";
            
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>"));
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["param1"] = TextBox1.Text;
            Session["param2"] = "ABIERTO";

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrPlanPagoCredito.aspx" + "','_blank'); </script>"));
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            fecha = fecha.AddDays(Convert.ToInt32(DropDownList2.SelectedValue));
            TextBox15.Text = fecha.ToString("yyyy-MM-dd");
               
            TextBox13.Text = "" + this.CalcularCuotas();
        }

        public int calcularInteres(DateTime fechaIni, DateTime FechaFin, int fpago, int interes)
        {
            TimeSpan dias = FechaFin - fechaIni;

            Double InteresDia = ((double)interes / (double)fpago);

            Double r = (InteresDia * ((double)dias.Days + 1));

            return Convert.ToInt32(Math.Round(r, 0));

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox13.Text = "" + this.CalcularCuotas();
        }


    }
}
 
  
*/