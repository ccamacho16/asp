using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGCC.Pages
{
    public partial class pgConfiguracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void MessageBoxError(string msg)
        {
            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "', 3)</script>"));
        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            foreach (System.Collections.DictionaryEntry entry in e.Values)
            {
                if (entry.Value.Equals(""))
                {
                    // Use the Cancel property to cancel the 
                    // insert operation.
                    String item = entry.Key.ToString();
                    if (!item.Equals("Valor2")) 
                        e.Cancel = true;

                }
            }
            if (e.Cancel)
                this.MessageBoxError("Error: Existen datos vacios.");
        }
    }
}