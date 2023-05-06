using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
namespace ESPOnline.Direction
{
    public partial class Listeattente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            GridView1.DataSource = DAL.Admission.Instance.getcandidats();
            GridView1.DataBind();
        }
    }
}