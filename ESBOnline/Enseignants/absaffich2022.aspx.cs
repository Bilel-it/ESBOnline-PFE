using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Enseignants
{
    public partial class absaffich2022 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["ID_ENS"].ToString();
            Label2.Text = Session["ID_ENS"].ToString();
        }

        protected void rb01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rb01.SelectedValue=="1")
            {
                Label1.Text = Session["ID_ENS"].ToString();
                Label2.Text = Session["ID_ENS"].ToString();
                Div1.Visible = true;
                Div2.Visible = false;
                Div3.Visible = false;
                Div4.Visible = false;
                Div5.Visible = false;

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

                }

                else
                {

                    if (rb01.SelectedValue == "3")
                    {

                        Div1.Visible = false;
                        Div2.Visible = false;
                        Div3.Visible = true;
                        Div4.Visible = false;
                        Div5.Visible = false;

                    }
                    else
                    {

                        if (rb01.SelectedValue == "4")
                        {

                            Div1.Visible = false;
                            Div2.Visible = false;
                            Div3.Visible = false;
                            Div4.Visible = true;
                            Div5.Visible = false;

                        }
                        else
                        {

                            if (rb01.SelectedValue == "5")
                            {
                                Label1.Text = Session["ID_ENS"].ToString();
                                Label2.Text = Session["ID_ENS"].ToString();
                                Div1.Visible = false;
                                Div2.Visible = false;
                                Div3.Visible = false;
                                Div4.Visible = false;
                                Div5.Visible = true;

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
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsebceByFormatioOrStudent("", DropDownList1.SelectedValue,"","","","");
            GridView1.DataBind();
        
    }

        protected void DropDownList11_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lbltitle.Text = "Liste des absence par Formation";
            lbltitle.Visible = true;

            //ici par formation
            GridView1.Visible = true;
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsebceByFormatioOrStudent(DropDownList2.SelectedValue, "","","","","");
            GridView1.DataBind();
        }

        protected void DropDownList1111_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lbltitle.Text = "Liste des absence par Module";
            lbltitle.Visible = true;

            //ici par formation
            GridView1.Visible = true;
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsebceByFormatioOrStudent("", "", "", "", "","");
            GridView1.DataBind();
        }


        protected void RadDatePicker1_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            lbltitle.Text = "Liste des absence par période";
            lbltitle.Visible = true;

            string d1 = TBdateseance.SelectedDate.Value.ToString("dd/MM/yy");
            string d2 = TBdateseance2.SelectedDate.Value.ToString("dd/MM/yy");
            GridView1.Visible = true;
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsebceByFormatioOrStudent("", "", "",d1 , d2,"");
            GridView1.DataBind();
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbltitle.Text = "Liste des absence par Semestre";
            lbltitle.Visible = true;

            GridView1.Visible = true;
            GridView1.DataSource = DAL.EncadDAO.Instance.GetabsebceByFormatioOrStudent("", "", RadioButtonList3.SelectedValue,"","","");
            GridView1.DataBind();
        }
    }
}