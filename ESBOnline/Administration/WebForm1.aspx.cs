using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication9
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }


        }

     

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //SqlDataSource2. DataBind();
            //GridView1.DataSource = SqlDataSource2;
            //GridView1.DataBind();
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "imprimer();", true);
            Session["ID_ET"] = DropDownList1.SelectedItem.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'WebForm2.aspx', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            
        
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "imprimer();", true);
          //  ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'WebForm1.aspx', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            
        }
    }
}