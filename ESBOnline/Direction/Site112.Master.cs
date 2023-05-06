using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Direction
{
    public partial class Site112 : System.Web.UI.MasterPage
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
            Response.Redirect("~/Online/Accueil.aspx");
        }
    
    }
}