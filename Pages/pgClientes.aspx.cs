using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;
using System.Collections;

namespace SGCC.Pages
{
    public partial class pgClientes : System.Web.UI.Page
    {

        private ConexBD con;
        //private Boolean nuevocli;
        //private static Boolean nuevocli;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["usuario"] == null)
            {
                Response.Redirect("pgError.aspx");
            }
            else
            {
                con = new ConexBD();            
                if (!IsPostBack) {
                    this.cargarTipoCliente();
                    this.cargarRubros();
                }
            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.validarci())
            {
                
                this.Siguiente();
                this.MostrarClieSiExiste(TextBox1.Text);
            }

        }

        public void MostrarClieSiExiste(String ci)
        {
            var dcliente = new List<string>();

            dcliente = con.ConsultarCliente(ci);
            if (dcliente.Count > 0){
                ViewState["nuevocli"] = false;
                DropDownList1.SelectedValue = dcliente.ElementAt(1); ;
                TextBox2.Text = dcliente.ElementAt(2);
                TextBox3.Text = dcliente.ElementAt(3);
                TextBox4.Text = dcliente.ElementAt(4);
                TextBox5.Text = dcliente.ElementAt(5);
                DropDownList2.SelectedValue = dcliente.ElementAt(6);
                this.cargarRubros();
                DropDownList3.SelectedValue = dcliente.ElementAt(7);
                this.Button7.Visible = true;
            }
            
        }
        public Boolean validarci()
        {
            Boolean sw = true;
            String valor = TextBox1.Text;
            if (valor.Length == 0)
            {
                sw = false;
                this.Message("ERROR: Por favor ingrese un Valor.");
            }
            else
            {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    sw = false;
                    this.Message("ERROR: La cantidad de caractes, NO es correcta.");
                }
            }
            return sw;
        }

        public Boolean datosvalidos() {

            if ((TextBox2.Text.Length == 0) || (TextBox3.Text.Length == 0) || (TextBox4.Text.Length == 0) || (TextBox5.Text.Length == 0))
            {
                return false;
            }else{
                return true;
            }
            
        }

        void Siguiente()
        {
            this.Label2.Text = "";
            Button5.Visible = true;
            Button6.Visible = true;
            Button4.Visible = false;

            TextBox1.Enabled = false;

            DropDownList1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
            TextBox5.Enabled = true;
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            ViewState["nuevocli"] = true;
        }
        void Volver()
        {
            this.Label2.Text = "";
            Button5.Visible = false;
            Button6.Enabled = true;
            Button6.Visible = false;
            Button7.Visible = false;
            Button4.Visible = true;

            TextBox1.Enabled = true;
            TextBox1.Text = "";

            DropDownList1.Enabled = false; DropDownList1.SelectedIndex = 6;
            TextBox2.Enabled = false; TextBox2.Text = "";
            TextBox3.Enabled = false; TextBox3.Text = "";
            TextBox4.Enabled = false; TextBox4.Text = "";
            TextBox5.Enabled = false; TextBox5.Text = "";

            ViewState["nuevocli"] = true;

            this.cargarTipoCliente();
            this.cargarRubros();
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
        }

        void bloquear()
        {
            TextBox1.Enabled = false;

            DropDownList1.Enabled = false;
            TextBox2.Enabled = false; 
            TextBox3.Enabled = false; 
            TextBox4.Enabled = false; 
            TextBox5.Enabled = false;
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;

            Button6.Enabled = false;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            this.Volver();
        }

        private void Message(string msg)
        {
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string msj = "";
            if (this.datosvalidos() == true){
                if ((bool)ViewState["nuevocli"])
                {
                    msj = con.InsertarCliente(TextBox1.Text, DropDownList1.SelectedValue, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, DropDownList2.SelectedValue, DropDownList3.SelectedValue, "HABILITADO");
                    Label2.Text = msj;
                    if (msj.Length == 0)
                        this.Message("El Cliente se guardo con Exito");
                    else
                        Label2.Text = msj;

                    Button7.Visible = true;
                    
                }else{
                    msj = con.ActualizarCliente(TextBox1.Text, DropDownList1.SelectedValue, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, DropDownList2.SelectedValue, DropDownList3.SelectedValue);
                    Label2.Text = msj;
                    if (msj.Length == 0)     
                        this.Message("El Cliente se actualizo con Exito");
                    else
                        Label2.Text = msj;
                }
                this.bloquear();
            }else{
                this.Message("ERROR: Existen datos incorrectos.");
            }

        }

        public void cargarTipoCliente() {
            DropDownList2.Items.Clear();
            Hashtable h = con.ConsultaDatosMasterEntidad("RUBROS");
            String aux = "";
            ListItem newItem;
            foreach (String cod in h.Keys)
            {
                    newItem = new ListItem();
                    newItem.Text = cod;
                    newItem.Value = cod;
                    DropDownList2.Items.Add(newItem);
                    aux = cod;         
            }
    
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarRubros();
        }

        public void cargarRubros() {
            DropDownList3.Items.Clear();
            var drubros = new List<string>();
            drubros = con.ConsultaValor_EntidadTipo("RUBROS", DropDownList2.SelectedValue);
            foreach (String rubro in drubros)
            {

                DropDownList3.Items.Add(rubro);

            }
            DropDownList3.Items.Add("OTROS");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox1.Text;

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrConsultaDatosClientes.aspx" + "','_blank'); </script>"));
        }
    }
}
/*
namespace SGCC.Pages
{
    public partial class pgClientes : System.Web.UI.Page
    {

        private ConexBD con;
        private Boolean nuevocli;
        //private static Boolean nuevocli;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["usuario"] == null)
            {
                Response.Redirect("pgError.aspx");

            }
            else
            {
                con = new ConexBD();            
                if (!IsPostBack) {
                    this.cargarTipoCliente();
                    this.cargarRubros();
                
                }
            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.validarci())
            {
                
                this.Siguiente();
                this.MostrarClieSiExiste(TextBox1.Text);
            }

        }

        public void MostrarClieSiExiste(String ci)
        {
            var dcliente = new List<string>();

            dcliente = con.ConsultarCliente(ci);
            if (dcliente.Count > 0){
                this.nuevocli = false;
                DropDownList1.SelectedValue = dcliente.ElementAt(1); ;
                TextBox2.Text = dcliente.ElementAt(2);
                TextBox3.Text = dcliente.ElementAt(3);
                TextBox4.Text = dcliente.ElementAt(4);
                TextBox5.Text = dcliente.ElementAt(5);
                DropDownList2.SelectedValue = dcliente.ElementAt(6);
                this.cargarRubros();
                DropDownList3.SelectedValue = dcliente.ElementAt(7);
                this.Button7.Visible = true;
            }
            
        }
        public Boolean validarci()
        {
            Boolean sw = true;
            String valor = TextBox1.Text;
            if (valor.Length == 0)
            {
                sw = false;
                this.Message("ERROR: Por favor ingrese un Valor.");
            }
            else
            {
                if ((valor.Length > 10) || (valor.Length < 7))
                {
                    sw = false;
                    this.Message("ERROR: La cantidad de caractes, NO es correcta.");
                }
            }
            return sw;
        }

        public Boolean datosvalidos() {

            if ((TextBox2.Text.Length == 0) || (TextBox3.Text.Length == 0) || (TextBox4.Text.Length == 0) || (TextBox5.Text.Length == 0))
            {
                return false;
            }else{
                return true;
            }
            
        }

        void Siguiente()
        {
            this.Label2.Text = "";
            Button5.Visible = true;
            Button6.Visible = true;
            Button4.Visible = false;

            TextBox1.Enabled = false;

            DropDownList1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;
            TextBox5.Enabled = true;
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            this.nuevocli = true;
        }
        void Volver()
        {
            this.Label2.Text = "";
            Button5.Visible = false;
            Button6.Enabled = true;
            Button6.Visible = false;
            Button7.Visible = false;
            Button4.Visible = true;

            TextBox1.Enabled = true;
            TextBox1.Text = "";

            DropDownList1.Enabled = false; DropDownList1.SelectedIndex = 6;
            TextBox2.Enabled = false; TextBox2.Text = "";
            TextBox3.Enabled = false; TextBox3.Text = "";
            TextBox4.Enabled = false; TextBox4.Text = "";
            TextBox5.Enabled = false; TextBox5.Text = "";

            this.nuevocli = true;

            this.cargarTipoCliente();
            this.cargarRubros();
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
        }

        void bloquear()
        {
            TextBox1.Enabled = false;

            DropDownList1.Enabled = false;
            TextBox2.Enabled = false; 
            TextBox3.Enabled = false; 
            TextBox4.Enabled = false; 
            TextBox5.Enabled = false;
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;

            Button6.Enabled = false;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            this.Volver();
        }

        private void Message(string msg)
        {
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string msj = "";
            if (this.datosvalidos() == true){
                if (this.nuevocli)
                {
                    msj = con.InsertarCliente(TextBox1.Text, DropDownList1.SelectedValue, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, DropDownList2.SelectedValue, DropDownList3.SelectedValue, "HABILITADO");
                    Label2.Text = msj;
                    if (msj.Length == 0)
                        this.Message("El Cliente se guardo con Exito");
                    else
                        Label2.Text = msj;

                    Button7.Visible = true;
                    
                }else{
                    msj = con.ActualizarCliente(TextBox1.Text, DropDownList1.SelectedValue, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, DropDownList2.SelectedValue, DropDownList3.SelectedValue);
                    Label2.Text = msj;
                    if (msj.Length == 0)     
                        this.Message("El Cliente se actualizo con Exito");
                    else
                        Label2.Text = msj;
                }
                this.bloquear();
            }else{
                this.Message("ERROR: Existen datos incorrectos.");
            }

        }

        public void cargarTipoCliente() {
            DropDownList2.Items.Clear();
            Hashtable h = con.ConsultaDatosMasterEntidad("RUBROS");
            String aux = "";
            ListItem newItem;
            foreach (String cod in h.Keys)
            {
                    newItem = new ListItem();
                    newItem.Text = cod;
                    newItem.Value = cod;
                    DropDownList2.Items.Add(newItem);
                    aux = cod;         
            }
    
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarRubros();
        }

        public void cargarRubros() {
            DropDownList3.Items.Clear();
            var drubros = new List<string>();
            drubros = con.ConsultaValor_EntidadTipo("RUBROS", DropDownList2.SelectedValue);
            foreach (String rubro in drubros)
            {

                DropDownList3.Items.Add(rubro);

            }
            DropDownList3.Items.Add("OTROS");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox1.Text;

            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrConsultaDatosClientes.aspx" + "','_blank'); </script>"));
        }
    }
}
*/