using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Configuration;
using Oracle.ManagedDataAccess.Types;
using BLL;
using Oracle.ManagedDataAccess.Client;

using ABSEsprit;

namespace ESPOnline.Direction
{
    public partial class Resultat : System.Web.UI.Page
    {
        public string ID_ET;
        public string TYPE_PV;
        public string CODE_CL;
        //string ff;
        decimal total = 0;
        decimal tot = 0;
        string t = "E";
        OrientationDAO orientdao = new OrientationDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            DropDownList1.Font.Bold = true;
            GridView2.Visible = false;
            if (IsPostBack)
            {
                GridView2.Visible = true;
            }
        }
        protected void GridView1_test(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                //int RowIndex = e.Row.RowIndex;
                //int DataItemIndex = e.Row.DataItemIndex;
                //int Columnscount = GridView2.Columns.Count;
                //GridViewRow row = new GridViewRow(RowIndex, DataItemIndex, DataControlRowType.Footer, DataControlRowState.Normal);
                //GridViewRow row2= new GridViewRow(RowIndex+1, DataItemIndex+1, DataControlRowType.Footer, DataControlRowState.Normal);

                //for (int i = 0; i < Columnscount; i++)
                //{
                //    TableCell tablecell = new TableCell();
                //    tablecell.Text = "ee";
                //    row.Cells.Add(tablecell);
                //}
                //this.GridView2.Controls[0].Controls.Add(row);

                TableCell tableCell = new TableCell();
                tableCell.HorizontalAlign = HorizontalAlign.Center;
                e.Row.Font.Bold = true;
                //Label Label2 = (Label)e.Row.FindControl("Label2");
                //Label2.Text = Label9.Text;
                using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                {
                    con.Open();
                    string t = Session["ID_ET"].ToString().Trim();
                    string numc = Session["CIN_PASS"].ToString().Trim();
                    OracleCommand cmd = new OracleCommand("SELECT sum(nb_ects) FROM ESP_V_MOY_UE_ETUDIANT where type_moy='P' and moyenne>=10 and id_et='" + t + "'  ");

                    cmd.Connection = con;
                    Label Label2 = (Label)e.Row.FindControl("Label2");
                    Label2.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                {
                    con.Open();
                    string t = Session["ID_ET"].ToString().Trim();
                    string numc = Session["CIN_PASS"].ToString().Trim();
                    OracleCommand cmd = new OracleCommand("SELECT MOY_GENERAL FROM ESP_INSCRIPTION where ANNEE_DEB=2013 and id_et='" + t + "'  ");

                    cmd.Connection = con;
                    Label Label3 = (Label)e.Row.FindControl("Label3");
                    Label3.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                {
                    con.Open();
                    string t = Session["ID_ET"].ToString().Trim();
                    string numc = Session["CIN_PASS"].ToString().Trim();
                    OracleCommand cmd = new OracleCommand("SELECT LIB_DECISION_SESSION_P FROM ESP_INSCRIPTION where ANNEE_DEB=2013 and id_et='" + t + "'  ");

                    cmd.Connection = con;
                    Label Label4 = (Label)e.Row.FindControl("Label4");
                    Label4.Text = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) >= 10)
                {

                    decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NB_ECTS"));

                    total = total + rowTotal;

                    // Label9.Text = "Total Crédits acquis  :" + " " + total.ToString();
                }
                else if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) < 10)
                {
                    for (int i = 1; i < GridView2.Rows.Count + 2; i++)
                    {

                        e.Row.Cells[3].Text = "0";
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;

                    }

                    decimal rowTo = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NB_ECTS"));
                    tot = tot + rowTo;
                    // Label2.Text = "Total Crédits a rattrapés  :" + " " + tot.ToString();
                }
            }
            foreach (TableCell cell in e.Row.Cells)
            {
                //for (int i = 0; i < GridView1.Rows.Count; i++)
                //{ 
                cell.Attributes.CssStyle["text-align"] = "center";

                if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) >= 10)
                {
                    // headerRow.ForeColor = System.Drawing.Color.White;  
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Green;
                    e.Row.BorderWidth = 5;
                    //cell.ForeColor = System.Drawing.Color.Green;

                }
                else if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) < 10)
                {
                    e.Row.BorderWidth = 5;
                    //e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
                    // cell.ForeColor = System.Drawing.Color.Red;

                    e.Row.BorderColor = System.Drawing.Color.FromName("#A8A8A8");



                }




            }

        }
        protected void OnDataBound(object sender, EventArgs e)
        {

            for (int i = GridView2.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GridView2.Rows[i];
                GridViewRow previousRow = GridView2.Rows[i - 1];
                for (int j = 0; j < 3; j++)
                {
                    if (row.Cells[j].Text == previousRow.Cells[j].Text && row.Cells[0].Text == previousRow.Cells[0].Text)
                    {
                        if (previousRow.Cells[j].RowSpan == 0)
                        {
                            if (row.Cells[j].RowSpan == 0)
                            {
                                previousRow.Cells[j].RowSpan += 2;

                            }
                            else
                            {
                                previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                            }
                            row.Cells[j].Visible = false;
                        }
                    }
                }
                int k = 6;
                if (row.Cells[4].Text == previousRow.Cells[4].Text && row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    if (previousRow.Cells[4].RowSpan == 0)
                    {
                        if (row.Cells[4].RowSpan == 0)
                        {
                            previousRow.Cells[4].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[4].RowSpan = row.Cells[4].RowSpan + 1;
                        }
                        row.Cells[4].Visible = false;
                    }
                }
                if (row.Cells[3].Text == previousRow.Cells[3].Text && row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    if (previousRow.Cells[3].RowSpan == 0)
                    {
                        if (row.Cells[3].RowSpan == 0)
                        {
                            previousRow.Cells[3].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[3].RowSpan = row.Cells[3].RowSpan + 1;
                        }
                        row.Cells[3].Visible = false;
                    }
                }
            }
        }
        protected void GridView2_test(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell cell in e.Row.Cells)
            {

                cell.Attributes.CssStyle["text-align"] = "center";
            }
            // Label Label3 = (Label)e.Row.FindControl("Label3");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) >= 10)
                {
                    decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NB_ECTS"));
                    total = total + rowTotal;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                    //Label3.Text = total.ToString();
                }

                else if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) < 10)
                {
                    for (int i = 1; i < GridView2.Rows.Count + 2; i++)
                    {

                        e.Row.Cells[4].Text = "0";
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;

                    }

                }
            }
        }
    }
}