using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Enseignants
{
    public partial class reset_pwd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Bienvenue " + Session["NOM_ENS"].ToString().Trim();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("https://esprit-tn.com/ESPONLINE/Online/default.aspx#tabs-1");
        }
    }
}