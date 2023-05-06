using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.EnseignantsCUP
{
    public partial class SuiviEvaluation : System.Web.UI.Page
    {

        string NOM_ENS;
        string ID_ENS;
        decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView2.DataBind();
            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            ID_ENS = Session["ID_ENS"].ToString();
            NOM_ENS = Session["NOM_ENS"].ToString();

            Chart1.ChartAreas[0].AxisX.Interval = 1;
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs t)
        {

            if (t.Row.RowType == DataControlRowType.DataRow)
            {
                Label6.Text = ((Label)formview1.FindControl("label5")).Text;
                decimal nbeval = Convert.ToDecimal(t.Row.Cells[2].Text);
                decimal nbet = Convert.ToDecimal(t.Row.Cells[3].Text);
                decimal nbmod = Convert.ToDecimal(t.Row.Cells[4].Text);
                decimal test = nbmod * nbet;
                //for (int i = 1; i <= t.Row.Cells.Count - 1; i++)
                //{
                //    t.Row.Cells[0].Text = nbet.ToString();
                //}

                decimal nbmodule = Convert.ToDecimal(t.Row.Cells[4].Text);
                t.Row.Cells[0].Text = ((nbeval / test) * 100).ToString("0.##") + "  " + " % "; ;
                //  t.Row.Cells[0].Text =test.ToString() ;
            }
        }
        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {


            SortDirection sortDirection = SortDirection.Ascending;
            string sortField = string.Empty;

            SortGridview((GridView)sender, e, out sortDirection, out sortField);
            string strSortDirection = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";
            // GridView2.DataSource = SqlDataSource6;
            GridView2.DataBind();
        }
        private void SortGridview(GridView gridView, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
        {
            sortField = e.SortExpression;
            sortDirection = e.SortDirection;


            if (gridView.Attributes["CurrentSortField"] != null && gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (sortField == gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"] == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }

                gridView.Attributes["CurrentSortField"] = sortField;
                gridView.Attributes["CurrentSortDirection"] = (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");

            }
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            decimal final;
            int totalRowsCount = GridView1.Rows.Count + 1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label6.Text = ((Label)formview1.FindControl("label5")).Text;
                Label2.Text = ((Label)formview2.FindControl("nbmod")).Text;
                //System.Web.UI.WebControls.Label lb = (Label)e.Row.Cells[0].FindControl("formview1");
                //string bitBlack = e.Row.Cells[2].Text.ToString();
                //string tex = lb.Text;
                decimal tt = Convert.ToDecimal(e.Row.Cells[2].Text);
                decimal hh = Convert.ToDecimal(Label6.Text);
                int nbmodule = Convert.ToInt32(Label2.Text);
                int nbretudiant = Convert.ToInt32(Label6.Text);
                int rowTo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "C_NB_EVAL"));
                total = total + rowTo;

                decimal test = (nbretudiant * nbmodule);

                //if (totalRowsCount == 0)
                //    throw new System.DivideByZeroException();


                //else { final = (total / test); }
                //((total / (nbretudiant * totalRowsCount)) * 100).ToString(); 
                int v = Convert.ToInt32(total.ToString());
                final = (total / test) * 100;
                Label7.Text = final.ToString("0.##") + "  " + " % ";

                //if (totalRowsCount == 0)
                //    throw new System.DivideByZeroException();


                //else { final = (total / test); }
                e.Row.Cells[0].Text = ((tt / hh) * 100).ToString("0.##") + "  " + " % ";


            }

        }
    }
}