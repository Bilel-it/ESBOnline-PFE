using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Parents
{
    public partial class Resetpwd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          string  NOM_ET = Session["NOM_ET"].ToString();
          string PRENOM_ET = Session["PNOM_ET"].ToString();

          Label2.Text = PRENOM_ET + " " + NOM_ET;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Online/default.aspx");


        }
    }
}