using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Administration
{
    public partial class Historiques_CRM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!Page.IsPostBack)
            {
                foreach (GridViewRow row in GridView2.Rows)
                {

                    if (Convert.ToString(row.Cells[0].Text) == "traiter")
                    {
                        row.BackColor = System.Drawing.Color.Lime;
                    }
                    else if (Convert.ToString(row.Cells[0].Text) == "non traiter")
                    {
                        row.BackColor = System.Drawing.Color.Red;
                    }
                    else if (Convert.ToString(row.Cells[0].Text) == "en cours")
                    {
                        row.BackColor = System.Drawing.Color.Blue;
                    }

                }
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {
                Panel4.Visible = true;

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            foreach (GridViewRow row in GridView2.Rows)
            {
               
                if (Convert.ToString(row.Cells[0].Text) == "traiter")
                {
                    row.BackColor = System.Drawing.Color.Lime;
                }
                else if (Convert.ToString(row.Cells[0].Text) == "non traiter")
                {
                    row.BackColor = System.Drawing.Color.Red;
                }
                else if (Convert.ToString(row.Cells[0].Text) == "en cours")
                {
                    row.BackColor = System.Drawing.Color.Blue;
                }

            }
        }
    }
}