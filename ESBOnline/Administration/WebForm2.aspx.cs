using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication9
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource2.DataBind();
            GridView1.DataSource = SqlDataSource2;
            GridView1.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "imprimer();", true);
          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "imprimer();", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
          
        }
    }
}