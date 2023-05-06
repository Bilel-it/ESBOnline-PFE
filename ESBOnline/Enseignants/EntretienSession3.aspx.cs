using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace ESPOnline.Enseignants
{
    public partial class EntretienSession3 : System.Web.UI.Page
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

            //   TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

            TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

        }

        protected void butsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkcompetences.SelectedValue == "")
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Veuillez choisir une compétence')</script>");

                }
                else
                {

                    string id = DropDownList1.SelectedValue;
                    using (Entities1 ec = new Entities1())
                    {
                        ClassLibrary1.ESP_ETUDIANT re = ec.ESP_ETUDIANT.First(p => p.ID_ET == id);




                        re.SCORE_ENTRETIEN = Convert.ToDecimal(TextBox1.Text);
                        re.ID_ENS_ENTRETIEN = Label3.Text;
                        re.DATE_SAISIE_SCORE_ENT = DateTime.Now;

                        re.OBSERVATION_ENTRETIEN = TextBox2.Text;
                        if (DAL.Admission.Instance.get_niveauadmission(DropDownList1.SelectedItem.Value) == "3")
                        {
                            re.CHOIX3 = Ddlchoix3.SelectedItem.Value;
                        }
                        ec.SaveChanges();
                    }
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
    }
}