using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Direction
{
    public partial class administration : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
        }
        protected void LinkButton_Click(object sender, EventArgs e)
    {
       string lg = Session["ID_DECID"].ToString();
            string ps=Session["motdepasse"].ToString();
            Response.Redirect("http://si.esprit-tn.com/_forms/default2.aspx?lg=" + lg + "=DashboardsFormsAllItemsDashboardsCharge+EnseignementFolderCTID0x012000C3B620D48FA71D4980895856F90F1ADF&View%7B31F97BC0-A087-472A-905F-274ABA03A7FF%7DDashboardsAdmission&FolderCTID0x012000C3B620D48FA71D4980895856F90F1ADF&View%7B31F97BC0-A" + "=" + ps);
    }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Online/Accueil.aspx");
        }
    }
}