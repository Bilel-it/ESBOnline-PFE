using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Oracle.ManagedDataAccess.Types;
using DAL;
using BLL;
namespace ESPOnline.Direction
{
    public partial class Consultaion_Admission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            Label4.Text = DAL.ToiecDAO.Instance.nbCondidasteste();
            Label5.Text = DAL.ToiecDAO.Instance.nbCondidasteste2();
            if (!Page.IsPostBack)
            {
               
            }
            GridView1.DataBind();
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        Label lblNom = (row.FindControl("lblNom") as Label);
                        if (lblNom.Text == "01") { lblNom.Text = "Math"; }
                        else if (lblNom.Text == "03") { lblNom.Text = "Sc Exp"; }
                        else if (lblNom.Text == "04") { lblNom.Text = "Tech"; }
                        else if (lblNom.Text == "35") { lblNom.Text = "Info"; }
                        else if (lblNom.Text == "02") { lblNom.Text = "Economie"; }
                        else if (lblNom.Text == "48") { lblNom.Text = "Autre Bac"; }
                        Label lbl = (row.FindControl("lblNom1") as Label);
                        if (lbl.Text == "05") { lbl.Text = "INFO"; }
                        else if (lbl.Text == "03") { lbl.Text = "GC"; }
                        else if (lbl.Text == "04") { lbl.Text = "Electro"; }
                        else if (lbl.Text == "02") { lbl.Text = "Télécom"; }
                        else if (lbl.Text == "01") { lbl.Text = "INFO"; }
                    }
                }

            } Label1.Text = GridView1.Rows.Count.ToString();  
        }
        protected void GridView1_test(object sender, GridViewRowEventArgs e)
        {
            if (RadioButtonList3.SelectedValue == "T")
            { e.Row.Cells[2].Visible = false; }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                       
                        Label lblNom = (row.FindControl("lblNom") as Label);
                        if (lblNom.Text == "01") { lblNom.Text = "Math"; }
                        else if (lblNom.Text == "03") { lblNom.Text = "Sc Exp"; }
                        else if (lblNom.Text == "04") { lblNom.Text = "Tech"; }
                        else if (lblNom.Text == "35") { lblNom.Text = "Info"; }
                        else if (lblNom.Text == "02") { lblNom.Text = "Economie"; }
                        else if (lblNom.Text == "48") { lblNom.Text = "Autre Bac"; }
                        Label lbl = (row.FindControl("lblNom1") as Label);
                        if (lbl.Text == "05") { lbl.Text = "INFO"; }
                        else if (lbl.Text == "03") { lbl.Text = "GC"; }
                        else if (lbl.Text == "04") { lbl.Text = "Electro"; }
                        else if (lbl.Text == "02") { lbl.Text = "Télécom"; }
                        else if (lbl.Text == "01") { lbl.Text = "INFO"; }
                    }
                }
            } Label1.Text = GridView1.Rows.Count.ToString();
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}