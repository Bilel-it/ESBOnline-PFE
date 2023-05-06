using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Direction
{
    public partial class Suivi_Abs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            GridView3.DataSourceID = "SqlDataSource3";
           
            GridView3.DataBind();
            Label3.Text = Session["DATE_SEANCE"].ToString(); Label4.Text = Session["NUM_SEANCE"].ToString(); Label5.Text = Session["CLASSE"].ToString();
            if (GridView3.Rows.Count == 0) { Label2.Visible = true; } else { Label2.Visible = false; }
        }
    }
}