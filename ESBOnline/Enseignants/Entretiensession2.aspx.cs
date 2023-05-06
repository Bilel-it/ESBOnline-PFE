using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using ClassLibrary1;

using BLL;

namespace ESPOnline.Enseignants
{
    public partial class Entretiensession2 : System.Web.UI.Page
    {
        string idt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }


         
         idt = Session["ID_ENS"].ToString().Trim();
            Label3.Text = idt;

            Label3.Visible = false;
            if (DropDownList1.SelectedItem != null)
            {

                GridView3.DataSource = SqlDataSource3;
                GridView3.DataBind();
            }
            

        }
     
        protected void GridView3_test(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

        }

        protected void butsubmit_Click(object sender, EventArgs e)
        {
            try
            {


                string id = DropDownList1.SelectedValue;
                using (Entities1 ec = new Entities1())
            {
                     ESP_ETUDIANT re = ec.ESP_ETUDIANT.First(p => p.ID_ET == id);


              
              
               re.SCORE_ENTRETIEN = Convert.ToDecimal(TextBox1.Text);
             re.ID_ENS_ENTRETIEN = Label3.Text;
                re.DATE_SAISIE_SCORE_ENT = DateTime.Now;

                re.OBSERVATION_ENTRETIEN = TextBox2.Text;
                  ec.SaveChanges();
}

                Response.Write("<script LANGUAGE='JavaScript' >alert('Enregistrement avec Succès ')</script>");
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    DropDownList1.ClearSelection();
                    DropDownList2.ClearSelection(); DropDownList5.ClearSelection(); DropDownList2.ClearSelection(); DropDownList6.ClearSelection();
                    DropDownList7.ClearSelection(); TextBox1.Text = "";
                    DropDownList1.DataBind(); TextBox2.Text = "";


            }

            catch
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Il faut choisir un candidat et lui donner une note ')</script>");
                GridView3.DataSource = null;
                GridView3.DataBind();
                DropDownList1.ClearSelection();
                DropDownList2.ClearSelection(); DropDownList5.ClearSelection(); DropDownList2.ClearSelection(); DropDownList6.ClearSelection();
                DropDownList7.ClearSelection(); TextBox1.Text = ""; TextBox2.Text = "";
            }
        }
    }
}