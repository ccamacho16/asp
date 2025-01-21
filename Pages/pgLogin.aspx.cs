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
    public partial class pgLogin : System.Web.UI.Page
    {
        private ConexBD con;        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            con = new ConexBD();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String user = this.TextBox1.Text;
            String pass = this.TextBox2.Text;
            String tipo = con.ConsultarUsuario(user, pass);
            if (tipo.Equals(""))
            {
                this.Label1.Text = "Usuario Incorrecto .!!";
            }
            else
            {
                this.cargarDatosSession(user, tipo);
                Response.Redirect("pgPrincipal.aspx");
            }
            
            
            /*this.cargarDatosSession("ccamacho","1");
         
            Response.Redirect("pgPrincipal.aspx");*/
            

        }

        public void cargarDatosSession(String user, String tipo) {

            Session["usuario"] = user;
            Session["TipoUsuario"] = tipo;

            Hashtable h = con.ConsultaDatosMasterEntidad("EMPRESA");

            foreach (String cod in h.Keys)
            {
                if (cod == "DIRECCION")
                {
                    Session["edireccion"] = h[cod].ToString();
                }
                if (cod == "NOMBRE")
                {
                    Session["enombre"] = h[cod].ToString();
                }
                if (cod == "TELEFONO")
                {
                    Session["etelefono"] = h[cod].ToString();
                }
                if (cod == "CIUDAD")
                {
                    Session["eciudad"] = h[cod].ToString();
                }

            }

            h = con.ConsultaDatosMasterEntidad("VALORES");
            foreach (String cod in h.Keys)
            {
                // 25,5  25.5
                // 25.5  25.5
                if (cod == "GASTOS_ADM")
                {
                    Session["vgastosadm"] = h[cod].ToString().Replace('.',',');
                }
                if (cod == "MULTA_MORA")
                {
                    Session["vmultamora"] = h[cod].ToString();
                }
            }
        }
    }
}