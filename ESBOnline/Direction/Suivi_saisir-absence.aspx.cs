using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace ESPOnline.Direction
{
    public partial class Suivi_saisir_absence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
              
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = DateTime.Parse(TextBox2.Text.Trim()).ToString("dd/MM/yy", CultureInfo.InvariantCulture).ToUpper() ;

            GridView1.DataSourceID = "SqlDataSource1";
           
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0) { Label2.Visible = true; } else { Label2.Visible = false; }
            GridView2.DataSourceID = "SqlDataSource2";

            GridView2.DataBind();
            if (GridView2.Rows.Count == 0) { Label3.Visible = true; } else { Label3.Visible = false; }
        }

       
        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            GridViewRow row = GridView1.SelectedRow;
            Session["ID"] = row.Cells[1].Text.Trim();
            Session["NOM"] = row.Cells[2].Text.Trim();
            Session["DATE_SAISIE"] = row.Cells[3].Text.Trim();
            Session["DATE_SEANCE"] = row.Cells[4].Text.Trim();
            Session["CLASSE"] = row.Cells[5].Text.Trim();
            Session["NUM_SEANCE"] = row.Cells[6].Text.Trim();
           
           
            Response.Write("<script>window.open('Suivi_Abs.aspx','_blank');</script>");
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
           
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            Session["ID"] = row.Cells[1].Text.Trim();
            Session["NOM"] = row.Cells[2].Text.Trim();
            Session["DATE_SAISIE"] = row.Cells[3].Text.Trim();
            Session["DATE_SEANCE"] = row.Cells[4].Text.Trim();
            Session["CLASSE"] = row.Cells[5].Text.Trim();
            Session["NUM_SEANCE"] = row.Cells[6].Text.Trim();
            
          
           
            Response.Write("<script>window.open('Suivi_Abs.aspx','_blank');</script>");
        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView2.Rows[e.NewSelectedIndex];

        } 
       

     
    }
}