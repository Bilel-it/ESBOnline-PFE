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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Telerik.Web.UI;
using static ESPOnline.Vacataire.AValid_Cahier_classe;
using ProudMonkey.Common.Controls;

namespace ESPOnline.Vacataire
{
    public partial class Entretiensession2022 : System.Web.UI.Page
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
            //if (DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")

            //{
            //    Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir une valeur')</script>");
            //}
            //else
            //{




            //    //   TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

            //    TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();


            //}
        }
        //Ali function
//        protected void butsubmit_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (chkcompetences.SelectedValue == "")
//                {
//                    Response.Write("<script LANGUAGE='JavaScript' >alert('Veuillez choisir une compétence/enseignant')</script>");

//                }
//                else
//                {

//                    string id = DropDownList1.SelectedValue;
//    Convert.ToDecimal(TextBox1.Text);
//                    string idens = Label3.Text;
//    TextBox2.Text.Trim();
//                    DAL.Admission.Instance.update_scoreentretien(Convert.ToDecimal(TextBox1.Text), idens, TextBox2.Text.Trim(), id);
//                    DAL.Admission.Instance.Insert_inti_comp(id, chkcompetences.SelectedValue);
//                    Response.Write("<script LANGUAGE='JavaScript' >alert('Enregistrement avec Succès ')</script>");
//                    GridView3.DataSource = null;
//                    GridView3.DataBind();
//                    DropDownList1.ClearSelection(); Ddlchoix3.Visible = false;
//                    DropDownList2.ClearSelection(); DropDownList5.ClearSelection(); DropDownList2.ClearSelection(); DropDownList6.ClearSelection();
//                    DropDownList7.ClearSelection(); TextBox1.Text = "";
//                    DropDownList1.DataBind(); TextBox2.Text = "";
//                    Ddlchoix3.Visible = false;

//                }
//            }
//            catch
//            {
//                Response.Write("<script LANGUAGE='JavaScript' >alert('Il faut choisir un candidat et lui donner une note ')</script>");
//                GridView3.DataSource = null;
//                GridView3.DataBind();
//                DropDownList1.ClearSelection(); Ddlchoix3.Visible = false;
//                DropDownList2.ClearSelection(); DropDownList5.ClearSelection(); DropDownList2.ClearSelection(); DropDownList6.ClearSelection();
//                DropDownList7.ClearSelection(); TextBox1.Text = ""; TextBox2.Text = "";
//            }
//}
        protected void butsubmit_Click(object sender, EventArgs e)
        {
            //if (DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")

            //{
            //    Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir une valeur')</script>");
            //}
            //try
            //{
                if (chkcompetences.SelectedValue == "" || DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")
                {
                    // Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir une valeur ou bien une compétence')</script>");

                    ShowPopupMessage("Choisir une valeur ou bien une compétence",
                 PopupMessageType.Message);

                }
                else
                {

                    string id = DropDownList1.SelectedValue;
                    using (Entities1 ec = new Entities1())
                    {
                        ESP_ETUDIANT re = ec.ESP_ETUDIANT.First(p => p.ID_ET == id);
                        re.SCORE_ENTRETIEN = Convert.ToDecimal(TextBox1.Text);
                        re.ID_ENS_ENTRETIEN = Label3.Text;
                        re.DATE_SAISIE_SCORE_ENT = DateTime.Now;
                        re.OBSERVATION_ENTRETIEN = TextBox2.Text;                      
                          //  re.CHOIX3 = Ddlchoix3.SelectedItem.Value;
                        ec.SaveChanges();
                    }
                    DAL.Admission.Instance.Insert_inti_comp(id, chkcompetences.SelectedValue);
                    // Response.Write("<script LANGUAGE='JavaScript' >alert('Enregistrement avec Succès ')</script>");

                    ShowPopupMessage("Enregistrement avec Succès",
                PopupMessageType.Success);

                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    DropDownList1.ClearSelection(); Ddlchoix3.Visible = false; DropDownList3.ClearSelection();
                    DropDownList2.ClearSelection(); DropDownList5.ClearSelection(); DropDownList2.ClearSelection(); DropDownList6.ClearSelection();
                    DropDownList7.ClearSelection(); TextBox1.Text = "";
                    DropDownList1.DataBind(); TextBox2.Text = "";
                    Ddlchoix3.Visible = false;

                }
            //}
            //catch
            //{
                //Response.Write("<script LANGUAGE='JavaScript' >alert('Erreur de serveur')</script>");

              //  ShowPopupMessage("Erreur de serveur",
              //PopupMessageType.Warning);
              //  GridView3.DataSource = null;
              //  GridView3.DataBind();
              //  DropDownList1.ClearSelection(); Ddlchoix3.Visible = false; DropDownList3.ClearSelection();
              //  DropDownList2.ClearSelection(); DropDownList5.ClearSelection(); DropDownList2.ClearSelection(); DropDownList6.ClearSelection();
              //  DropDownList7.ClearSelection(); TextBox1.Text = ""; TextBox2.Text = "";
           // }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GridView5.Visible = true;
            GridView5.DataSource = DAL.Admission.Instance.getPJS(DropDownList1.SelectedValue);
            GridView5.DataBind();
            //gridimg.DataSource = DAL.Admission.Instance.getPJS(DropDownList1.SelectedValue);
            //gridimg.DataBind();
            //gridimg.Visible = true;
            //Label22.Text = DropDownList1.SelectedValue;
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")

            {
               // Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir une valeur')</script>");
            }
            else
            {

                //   TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

                TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();


            }

        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")

            {
                // Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir les valeur')</script>");
            }
            else
            {

                //   TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

                TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();


            }

        }

        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(DropDownList3.Text) && !string.IsNullOrEmpty(DropDownList5.Text) && !string.IsNullOrEmpty(DropDownList5.Text) && !string.IsNullOrEmpty(DropDownList5.Text))
            //{ 
            //if (DropDownList3.SelectedValue != "C" || DropDownList5.SelectedValue != "C" || DropDownList6.SelectedValue != "C" || DropDownList7.SelectedValue != "C" || DropDownList2.SelectedValue != "C")

            //{


               
            //    TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();



            //}
            //else
            //{
            //    DropDownList5.ClearSelection();
            //    DropDownList6.ClearSelection();
            //    DropDownList3.ClearSelection();
            //    DropDownList7.ClearSelection();
            //    //DropDownList3.Items.Add(new ListItem("--Veuillez choisir--", "--Veuillez choisir--"));
            //    //DropDownList5.Items.Add(new ListItem("--Veuillez choisir--", "--Veuillez choisir--"));
            //    //DropDownList6.Items.Add(new ListItem("--Veuillez choisir--", "--Veuillez choisir--"));
            //    //DropDownList7.Items.Add(new ListItem("--Veuillez choisir--", "--Veuillez choisir--"));

            //}
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")

            {
               // Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir les valeur')</script>");
            }
            else
            {

                //   TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

                TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();


            }
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")

            {
               // Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir les valeur')</script>");
            }
            else
            {

                //   TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

                TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();


            }
        }

        protected void DropDownList7_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")

            {
               // Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir les valeur')</script>");
            }
            else
            {

                //   TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

                TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();


            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "C" || DropDownList3.SelectedValue == "C" || DropDownList5.SelectedValue == "C" || DropDownList6.SelectedValue == "C" || DropDownList7.SelectedValue == "C")

            {
               // Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir les valeur')</script>");
            }
            else
            {

                //   TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();

                TextBox1.Text = (Convert.ToDecimal(DropDownList2.SelectedValue) * 5 + Convert.ToDecimal(DropDownList3.SelectedValue) * 5 + Convert.ToDecimal(DropDownList5.SelectedValue) * 5 + Convert.ToDecimal(DropDownList6.SelectedValue) * 5 + Convert.ToDecimal(DropDownList7.SelectedValue) * 5).ToString();


            }
        }

        protected void DropDownList5_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void DropDownList6_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void DropDownList7_SelectedIndexChanged2(object sender, EventArgs e)
        {

        }





        private void ShowPopupMessage(string message, AValid_Cahier_classe.PopupMessageType messageType)
        {
            switch (messageType)
            {
                case PopupMessageType.Error:
                    lblMessagePopupHeading.Text = "Error";
                    //Render image in literal control
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/images/error.png") + "' alt='' />";
                    break;
                case PopupMessageType.Message:
                    lblMessagePopupHeading.Text = "Information";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/Images/info.png") + "' alt='' />";
                    break;
                case PopupMessageType.Warning:
                    lblMessagePopupHeading.Text = "Warning";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/Images/Warning.png") + "' alt='' />";
                    break;
                case PopupMessageType.Success:
                    lblMessagePopupHeading.Text = "Success";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/Images/success.png") + "' alt='' />";
                    break;
                default:
                    lblMessagePopupHeading.Text = "Information";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/Images/info.png") + "' alt='' />";
                    break;
            }

            lblMessagePopupText.Text = message;
            mpeMessagePopup.Show();
        }

    }
}