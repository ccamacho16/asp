using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGCC.Clases;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace SGCC.Pages
{
    public partial class pgpConsultaMoraClientes : System.Web.UI.Page
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
                    this.ListTodosOfiCred();
                    TextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");                   
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["param1"] = TextBox1.Text;
            Session["param2"] = DropDownList1.SelectedValue;
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.open('" + "pgrConsultaMoraClientes.aspx" + "','_blank'); </script>"));
        }

        private void ListTodosOfiCred()
        {
            Hashtable h = con.TodosOfiCred();
            ListItem newItem;
            foreach (String cod in h.Keys)
            {
                newItem = new ListItem();
                newItem.Text = cod;
                newItem.Value = cod;
                DropDownList1.Items.Add(newItem);
            }
            newItem = new ListItem();
            newItem.Text = "Todos";
            newItem.Value = "%";
            DropDownList1.Items.Add(newItem);
        }


    }
}