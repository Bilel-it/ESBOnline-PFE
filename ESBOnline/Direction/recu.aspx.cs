using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ESPOnline.Direction
{
    public partial class recu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            DataView dv = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
           decimal nb = (decimal)dv.Table.Rows[0][0];
            Label3.Text = nb.ToString();
            DataView dv2 = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
            decimal nb2 = (decimal)dv2.Table.Rows[0][0];
            Label5.Text = nb2.ToString();
        }
    }
}