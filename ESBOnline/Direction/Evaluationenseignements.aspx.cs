using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.UI.DataVisualization.Charting;

namespace ESPOnline.Direction
{
    public partial class Evaluationenseignements : System.Web.UI.Page
    {
        
      
        public string id_ens;
        public string dept;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void test(object sender, EventArgs e)
        {
            DDLAnnee.ClearSelection();


           

        }




        protected void DDLAnnee_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            StatService etudiatlocator = new StatService();
            DropDownList1.DataSource = etudiatlocator.GetserviceListNotes55( DDLAnnee.SelectedValue);
            DropDownList1.DataValueField = "CODE_CL";
            DropDownList1.DataTextField = "CODE_CL";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));


        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            StatService etudiatlocator = new StatService();
            DropDownList2.DataSource = etudiatlocator.GetserviceListNotes66( DropDownList1.SelectedValue.Trim(), DDLAnnee.SelectedValue);
            DropDownList2.DataValueField = "CODE_MODULE";
            DropDownList2.DataTextField = "DESIGNATION";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("", "0"));
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code_cl = DropDownList1.SelectedValue;
            string code_module = DropDownList2.SelectedValue;
            StatService etudiatlocator = new StatService();
            GridView5.DataSource = etudiatlocator.GetserviceListNotes(code_cl, code_module, DDLAnnee.SelectedValue);

            GridView5.DataBind();

            Chart1.DataSource = etudiatlocator.GetserviceListNotes33(code_cl, code_module, DDLAnnee.SelectedValue);


            Chart1.DataBind();




            Chart2.DataSource = etudiatlocator.GetserviceListNotes22(code_cl, code_module, DDLAnnee.SelectedValue);

            Chart2.DataBind();

            Chart3.DataSource = etudiatlocator.GetserviceListNotes44(code_cl, code_module, DDLAnnee.SelectedValue);

            Chart3.DataBind();

            GridView2.DataSource = etudiatlocator.GetserviceListNotes77(code_cl, code_module, DDLAnnee.SelectedValue);
            GridView2.DataBind();

            GridView3.DataSource = etudiatlocator.GetserviceListNotes88(code_cl, code_module, DDLAnnee.SelectedValue);
            GridView3.DataBind();
            GridView4.DataSource = etudiatlocator.GetserviceTauxRep1(code_cl, code_module, DDLAnnee.SelectedValue);
            GridView4.DataBind();
        }

        protected void SummaryChart_Customize(object sender, EventArgs e)
        {
            //hide label value if zero
            foreach (System.Web.UI.DataVisualization.Charting.Series series in Chart1.Series)
            {
                foreach (DataPoint point in series.Points)
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

           
            //string rep;
            string code_cl = DropDownList1.SelectedValue;
            string code_module = DropDownList2.SelectedValue;
            StatService etudiatlocator = new StatService();
            GridView5.DataSource = etudiatlocator.GetserviceListNotes(code_cl, code_module, DDLAnnee.SelectedValue);

            GridView5.DataBind();

            Chart1.DataSource = etudiatlocator.GetserviceListNotes33(code_cl, code_module,  DDLAnnee.SelectedValue);


            Chart1.DataBind();




            Chart2.DataSource = etudiatlocator.GetserviceListNotes22(code_cl, code_module,  DDLAnnee.SelectedValue);

            Chart2.DataBind();

            Chart3.DataSource = etudiatlocator.GetserviceListNotes44(code_cl, code_module,  DDLAnnee.SelectedValue);

            Chart3.DataBind();

            GridView2.DataSource = etudiatlocator.GetserviceListNotes77(code_cl, code_module, DDLAnnee.SelectedValue);
            GridView2.DataBind();

            GridView3.DataSource = etudiatlocator.GetserviceListNotes88(code_cl, code_module,  DDLAnnee.SelectedValue);
            GridView3.DataBind();
            GridView4.DataSource = etudiatlocator.GetserviceTauxRep1(code_cl, code_module,  DDLAnnee.SelectedValue);
            GridView4.DataBind();
            //rep = etudiatlocator.GetserviceListNotes8(code_cl, code_module, id_ens, DDLAnnee.SelectedValue).ToString();
            //TextBox2.Text = rep;


        }

    }
    }
