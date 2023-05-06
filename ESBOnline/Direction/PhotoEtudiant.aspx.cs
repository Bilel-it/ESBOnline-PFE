using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Direction
{
    public partial class PhotoEtudiant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem(("Choisir Etudiant"), ""));
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataSource1.DataBind();
            // GridView1.DataSource = SqlDataSource1;
            GridView1.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
            
        }
    }
}