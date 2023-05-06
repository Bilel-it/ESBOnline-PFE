using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
namespace ESPOnline.Direction
{
    public partial class STATADD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
        }
        protected void ddltestang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != null)
            {
              //  Label5.Text = DAL.ToiecDAO.Instance.nbCondidatsInscritad(Convert.ToDateTime(DropDownList1.SelectedValue));
            }
        }
    }
}