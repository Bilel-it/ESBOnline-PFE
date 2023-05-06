using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.Direction
{
    public partial class resultatP : System.Web.UI.Page
    {
        public string ID_ET;
        public string anneedeb;
        protected void Page_Load(object sender, EventArgs e)
        {
            Resultatectservice res = new Resultatectservice();
            anneedeb = DAL.AffectationDAO.Instance.getanneedeb();
            ID_ET = DropDownList1.SelectedValue;
            DropDownList1.Font.Bold = true;
        
            if (IsPostBack)
            {
                gvue.Visible = true;
                gvue.DataSource = res.getUE(ID_ET, anneedeb);

                gvue.DataBind();
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            Resultatectservice res1 = new Resultatectservice();

            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label Label2 = (Label)e.Row.FindControl("Label2");
                Label2.Text = res1.Getnbects(ID_ET);
                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ueId = gvue.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("gvnotes") as GridView;
                gvOrders.DataSource = DAL.ResctsDAO.Instance.GetResFinal2(ID_ET, anneedeb, (string)DataBinder.Eval(e.Row.DataItem, "CODE_UE"));
                gvOrders.DataBind();
                foreach (TableCell cell in e.Row.Cells)
                {

                    cell.Attributes.CssStyle["text-align"] = "center";
                }

                if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) >= 10)
                {

                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;



                }
                else if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) < 10)
                {

                    e.Row.Cells[4].Text = "0";
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;



                }
            }
        }
        protected void OnRowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell cell in e.Row.Cells)
                {

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
    }
}