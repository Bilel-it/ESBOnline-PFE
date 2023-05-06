using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Evaluationpardept : System.Web.UI.Page
    {
        string up;
        string nom;
        string z;
        string cup;
        public string id_ens;
        public string dept;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            up = Session["UP"].ToString().Trim();
            nom = Session["Nom_ENS"].ToString().Trim();
            z = Session["ID_ENS"].ToString().Trim();
            cup = Session["CUP"].ToString();

            dept = Session["CODE_DEPT"].ToString().Trim();
          //  EncadrementService enc = new EncadrementService();
            Label3.Text = DAL.EncadrementDAO.Instance.getDEPT(dept);


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void test(object sender, EventArgs e)
        {
            DDLAnnee.ClearSelection();


            id_ens = RadComboBox2.SelectedValue.ToString();
            string nom_ens = RadComboBox2.SelectedItem.Text;


        }




        protected void DDLAnnee_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            StatService etudiatlocator = new StatService();
            DropDownList1.DataSource = etudiatlocator.GetserviceListNotes5(RadComboBox2.SelectedValue, DDLAnnee.SelectedValue);
            DropDownList1.DataValueField = "CODE_CL";
            DropDownList1.DataTextField = "CODE_CL";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));


        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            StatService etudiatlocator = new StatService();
            DropDownList2.DataSource = etudiatlocator.GetserviceListNotes6(RadComboBox2.SelectedValue, DropDownList1.SelectedValue, DDLAnnee.SelectedValue);
            DropDownList2.DataValueField = "CODE_MODULE";
            DropDownList2.DataTextField = "DESIGNATION";
            DropDownList2.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SummaryChart_Customize(object sender, EventArgs e)
        {
            //hide label value if zero
            foreach (System.Web.UI.DataVisualization.Charting.Series series in Chart1.Series)
            {
                foreach (System.Web.UI.DataVisualization.Charting.DataPoint point in series.Points)
                {
                    if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                    {
                        point.IsValueShownAsLabel = false;
                    }
                }
            }
        }

        protected void SummaryChart_Customize2(object sender, EventArgs e)
        {
            //hide label value if zero
            foreach (System.Web.UI.DataVisualization.Charting.Series series in Chart2.Series)
            {
                foreach (System.Web.UI.DataVisualization.Charting.DataPoint point in series.Points)
                {
                    if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                    {
                        point.IsValueShownAsLabel = false;
                    }
                }
            }
        }

        protected void SummaryChart_Customize3(object sender, EventArgs e)
        {
            //hide label value if zero
            foreach (System.Web.UI.DataVisualization.Charting.Series series in Chart3.Series)
            {
                foreach (System.Web.UI.DataVisualization.Charting.DataPoint point in series.Points)
                {
                    if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                    {
                        point.IsValueShownAsLabel = false;
                    }
                }
            }
        }

        protected void YourGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    //tablecell.HorizontalAlign = HorizontalAlign.Center;
                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Chart4.ChartAreas[0].AxisX.Interval = 1;

            Label3.Text = DropDownList2.SelectedValue;
            //string rep;
            string code_cl = DropDownList1.SelectedValue;
            string code_module = DropDownList2.SelectedValue;
            StatService etudiatlocator = new StatService();
            GridView5.DataSource = etudiatlocator.GetserviceListNotes(code_cl, code_module, DDLAnnee.SelectedValue);

            GridView5.DataBind();

            Chart1.DataSource = etudiatlocator.GetserviceListNotes3(code_cl, code_module, RadComboBox2.SelectedValue, DDLAnnee.SelectedValue);


            Chart1.DataBind();




            Chart2.DataSource = etudiatlocator.GetserviceListNotes2(code_cl, code_module, RadComboBox2.SelectedValue, DDLAnnee.SelectedValue);

            Chart2.DataBind();

            Chart3.DataSource = etudiatlocator.GetserviceListNotes4(code_cl, code_module, RadComboBox2.SelectedValue, DDLAnnee.SelectedValue);

            Chart3.DataBind();

            GridView2.DataSource = etudiatlocator.GetserviceListNotes7(code_cl, code_module, RadComboBox2.SelectedValue, DDLAnnee.SelectedValue);
            GridView2.DataBind();

            GridView3.DataSource = etudiatlocator.GetserviceListNotes8(code_cl, code_module, RadComboBox2.SelectedValue, DDLAnnee.SelectedValue);
            GridView3.DataBind();
            GridView4.DataSource = etudiatlocator.GetserviceTauxRep(code_cl, code_module, RadComboBox2.SelectedValue, DDLAnnee.SelectedValue);
            GridView4.DataBind();
            //rep = etudiatlocator.GetserviceListNotes8(code_cl, code_module, id_ens, DDLAnnee.SelectedValue).ToString();
            //TextBox2.Text = rep;


        }

    }
}