using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESBOnline.Finance
{
    public partial class RECU : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("https://esprit-tn.com/ESPONLINE/Online/default.aspx#tabs-6");
        }
    }
}