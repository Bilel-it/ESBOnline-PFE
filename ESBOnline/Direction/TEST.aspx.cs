using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
namespace ESPOnline.Direction
{
    public partial class TEST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            Label4.Text = DAL.ToiecDAO.Instance.nbCondidasteste();
            Label5.Text = DAL.ToiecDAO.Instance.nbCondidasteste2();
        }
    }
}