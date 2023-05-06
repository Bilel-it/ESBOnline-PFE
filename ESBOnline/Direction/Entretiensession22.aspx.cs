using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using ClassLibrary1;
using DAL;
using BLL;

namespace ESPOnline.Direction
{
    public partial class Entretiensession22 : System.Web.UI.Page
    {
        string idt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ID_ENS"] == null)
            //{
            //    Response.Redirect("~/Online/default.aspx");
            //}



            idt = "ZiedS";
            //Session["ID_ENS"].ToString().Trim();
            Label3.Text = idt;

            Label3.Visible = false;

            if (DropDownList1.SelectedItem != null)
            {
                if (DAL.Admission.Instance.get_niveauadmission(DropDownList1.SelectedItem.Value) == "3" && DAL.Admission.Instance.get_speadmission(DropDownList1.SelectedItem.Value) == "05")
                {
                    Ddlchoix3.Visible = true;
                    Label4.Visible = true;
                }
                else
                {
                    Ddlchoix3.Visible = false;
                    Label4.Visible = false;
                }
                GridView3.DataSource = SqlDataSource3;
                GridView3.DataBind();
            }


        }
        protected void test(object sender, EventArgs e)
        {
            if (DAL.Admission.Instance.get_niveauadmission(DropDownList1.SelectedItem.Value) == "3" && DAL.Admission.Instance.get_speadmission(DropDownList1.SelectedItem.Value) == "05")
            {
                Ddlchoix3.Visible = true;
                Label4.Visible = true;
                Ddlchoix3.Items.Clear();

                Ddlchoix3.Items.Add(new ListItem("Choisir", ""));
                Ddlchoix3.Items.Add(new ListItem("3A", "3A"));
                Ddlchoix3.Items.Add(new ListItem("3B", "3B"));
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
            if (DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")

            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir une valeur')</script>");
            }
            else
            {




                //   TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

                TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();


            }
        }

        protected void butsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkcompetences.SelectedValue == "" || Radens.SelectedValue == "")
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Veuillez choisir une compétence/enseignant')</script>");

                }
                else
                {

                    string id = DropDownList1.SelectedValue;
                    Convert.ToDecimal(TextBox1.Text);
                    string idens = Radens.SelectedValue;
                    TextBox2.Text.Trim();
                    DAL.Admission.Instance.update_scoreentretien(Convert.ToDecimal(TextBox1.Text), idens, TextBox2.Text.Trim(), id);
                    DAL.Admission.Instance.Insert_inti_comp(id, chkcompetences.SelectedValue);
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Enregistrement avec Succès ')</script>");
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    DropDownList1.ClearSelection(); Ddlchoix3.Visible = false;
                    DropDownList2.ClearSelection(); DropDownList5.ClearSelection(); DropDownList2.ClearSelection(); DropDownList6.ClearSelection();
                    DropDownList7.ClearSelection(); TextBox1.Text = "";
                    DropDownList1.DataBind(); TextBox2.Text = "";
                    Ddlchoix3.Visible = false;

                }
            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Il faut choisir un candidat et lui donner une note ')</script>");
                GridView3.DataSource = null;
                GridView3.DataBind();
                DropDownList1.ClearSelection(); Ddlchoix3.Visible = false;
                DropDownList2.ClearSelection(); DropDownList5.ClearSelection(); DropDownList2.ClearSelection(); DropDownList6.ClearSelection();
                DropDownList7.ClearSelection(); TextBox1.Text = ""; TextBox2.Text = "";
            }
}
        protected void gridimgrowdatabound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        { }

        protected void gridimg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (GridViewRow row in gridimg.Rows)
            //{
            //    if (row.RowIndex == gridimg.SelectedIndex + 1)
            //    {
            //        //ici update image
            //        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);


            //    }
            //}
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GridView5.Visible = true;
            GridView5.DataSource = DAL.Admission.Instance.getPJS(DropDownList1.SelectedValue);
            GridView5.DataBind();
           
            Label22.Text = DropDownList1.SelectedValue;
        }
    }
}