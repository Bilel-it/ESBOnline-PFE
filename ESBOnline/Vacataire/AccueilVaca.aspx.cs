using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Enseignants
{
    public partial class AccueilVaca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
        }
    }
}