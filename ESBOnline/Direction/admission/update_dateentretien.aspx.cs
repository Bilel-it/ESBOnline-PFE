using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Direction.admission
{
    public partial class update_dateentretien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["ID_DECID"] == null)
                {
                    Response.Redirect("~/Online/default.aspx");
                }

                DropDownList2.DataSource = SqlDataSource1;
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("Select", ""));

            }

        }

        protected void btnmod_Click(object sender, EventArgs e)
        {
            DAL.Admission.Instance.update_dateENTR(DropDownList1.SelectedValue, DropDownList2.SelectedValue);
            DAL.Admission.Instance.update_datelimite( DropDownList2.SelectedValue);
            string message;
            message = "alert('Modification effectué')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
    }
}