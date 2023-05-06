using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Enseignants
{
    public partial class Admin_absaffich2022 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btntoExcel_Click(object sender, EventArgs e)
        {
            //if (DropDownList1.SelectedValue == "N")
            //{
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=absence_etudiant.xls");
                Response.ContentType = "application/excel";
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                GridView1.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=absence_etudiant2.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw2 = new System.IO.StringWriter();
            HtmlTextWriter htw2 = new HtmlTextWriter(sw2);
            GridView11.RenderControl(htw2);
            Response.Write(sw2.ToString());
            Response.End();

            //}
        }
        protected void rb01_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView11.Visible = false;
            GridView1.Visible = false;
            if (rb01.SelectedValue=="1")
            {

                Div1.Visible = true;
                Div2.Visible = false;
                Div3.Visible = false;
                Div4.Visible = false;
                Div5.Visible = false;
                Div6.Visible = false;

            }

            else
            {


                if (rb01.SelectedValue == "2")
                {

                    Div1.Visible = false;
                    Div2.Visible = true;
                    Div3.Visible = false;
                    Div4.Visible = false;
                    Div5.Visible = false;
                    Div6.Visible = false;

                }

                else
                {

                    if (rb01.SelectedValue == "3")
                    {

                        Div1.Visible = false;
                        Div2.Visible = false;
                        Div3.Visible = true;
                        Div4.Visible = false;
                        Div6.Visible = false;
                        Div5.Visible = false;
                        Div6.Visible = false;

                    }
                    else
                    {

                        if (rb01.SelectedValue == "4")
                        {

                            Div1.Visible = false;
                            Div2.Visible = false;
                            Div3.Visible = false;
                            Div4.Visible = true;
                            Div6.Visible = false;
                            Div5.Visible = false;
                            Div6.Visible = false;

                        }
                        else
                        {

                            if (rb01.SelectedValue == "5")
                            {

                                Div1.Visible = false;
                                Div2.Visible = false;
                                Div3.Visible = false;
                                Div4.Visible = false;
                                Div5.Visible = true;
                                Div6.Visible = false;

                            }
                            else
                            {

                                if (rb01.SelectedValue == "6")
                                {

                                    Div1.Visible = false;
                                    Div2.Visible = false;
                                    Div3.Visible = false;
                                    Div4.Visible = false;
                                    Div5.Visible = false;
                                    Div6.Visible = true;

                                }

                            }

                        }

                       

                    }

                }

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lbltitle.Text = "Liste des absence par Identifiant";
            lbltitle.Visible = true;

            //ici par formation
            GridView1.Visible = true;
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsenceByNb("", DropDownList1.SelectedValue,"","","","");
            GridView1.DataBind();

            GridView11.Visible = true;
            GridView11.DataSource = DAL.EncadDAO.Instance.GetabsenceByNb2(DropDownList1.SelectedValue);
            GridView11.DataBind();

        }

        protected void DropDownList11_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lbltitle.Text = "Liste des absence par Formation";
            lbltitle.Visible = true;

            //ici par formation
            GridView1.Visible = true;
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsenceByNb(DropDownList2.SelectedValue, "","","","","");
            GridView1.DataBind();
        }

        protected void DropDownList1111_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lbltitle.Text = "Liste des absence par Module";
            lbltitle.Visible = true;

            //ici par formation
            GridView1.Visible = true;
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsenceByNb("", "", "", "", "", RadComboBox1.SelectedValue);
            GridView1.DataBind();
        }

        protected void RadDatePicker1_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            lbltitle.Text = "Liste des absence par période";
            lbltitle.Visible = true;

            string d1 = TBdateseance.SelectedDate.Value.ToString("dd/MM/yy");
            string d2 = TBdateseance2.SelectedDate.Value.ToString("dd/MM/yy");
            GridView1.Visible = true;
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsenceByNb("", "", "",d1 , d2,"");
            GridView1.DataBind();
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbltitle.Text = "Liste des absence par Semestre";
            lbltitle.Visible = true;

            GridView1.Visible = true;
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsenceByNb("", "", RadioButtonList3.SelectedValue,"","","");
            GridView1.DataBind();
        }
    }
}