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
    public partial class ResultatRattrapage : System.Web.UI.Page
    {
        public string ID_ET;
        public string TYPE_PV;
        public string CODE_CL;
        public decimal ec;
        decimal total = 0;
        decimal tot = 0;
        string t = "E";
        public string LIB_DECISION_SESSION_RAT;
        public string Moy_R;
      
        public decimal nb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            ID_ET = DropDownList1.SelectedValue.ToString();

            Label18.Visible = true;
            
           
           

        }
        protected void GrouperAffichage(object sender, EventArgs e)
        {


            for (int rowIndex = GridView3.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {

                GridViewRow row = GridView3.Rows[rowIndex];
                GridViewRow previousRow = GridView3.Rows[rowIndex + 1];

                if (row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;

                }

            }
        }
        protected void test(object sender, EventArgs e)
        {

            ID_ET = DropDownList1.SelectedValue.ToString();
                CODE_CL = DAL.OrientationDAO.getlcodecl(ID_ET, "2013");
                TYPE_PV = DAL.OrientationDAO.getTypepv("2013", CODE_CL);

                LIB_DECISION_SESSION_RAT = DAL.OrientationDAO.getDecisionRat(ID_ET, "2013");
                Label19.Text = Moy_R;
                Moy_R = DAL.OrientationDAO.getMoyRat(ID_ET, "2013");
               // nb = DAL.OrientationDAO.getsumnbects(ID_ET, "2013");
            
            Label18.Visible = false;

            GridView2.DataBind();
            
             if (LIB_DECISION_SESSION_RAT == null)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('ADMIS   SESSION PRINCIPALE')</script>");
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                DetailsView3.Visible = false;
                GridView1.Visible = false;

            }
             //else if (GridView2.Rows.Count == 0)
             //{
             //    Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétant')</script>");
             //    GridView2.Visible = false;
             //    Label18.Visible = false;
             //    GridView3.Visible = false;
             //    GridView4.Visible = false;
             //    DetailsView3.Visible = false;
             //    GridView1.Visible = false;
             //}
             else if (TYPE_PV.ToString() == "E" && LIB_DECISION_SESSION_RAT != null )
             {
               

                //nb = DAL.OrientationDAO.getsumnbects(ID_ET, "2013");
                    Label18.Visible = true;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView1.Visible = false;
                    DetailsView3.Visible = false;
                    GridView2.Visible = true;
                
                

            }
            else if (TYPE_PV.ToString() == "O" && LIB_DECISION_SESSION_RAT != null)
             {
                 ID_ET = DropDownList1.SelectedValue.ToString();
                //Response.Redirect("~/Direction/CharguiaRattrapage.aspx");
                //  GridView1.Visible = true;
                DetailsView3.Visible = true;
                GridView3.Visible = true;
                GridView4.Visible = true;
                GridView1.Visible = true;
                GridView2.Visible = false;
                Label18.Visible = false;
            }
            
            
        }

        protected void grdView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }
        protected void GridView1_test(object sender, GridViewRowEventArgs e)
        {
            nb = DAL.OrientationDAO.getsumnbects(ID_ET, "2013");
            ec = DAL.OrientationDAO.getsumnbects2(ID_ET, "2013");
          //  if (e.Row.RowType == DataControlRowType.Header)
          //  {
          //      GridView grid = sender as GridView;
          //      GridViewRow row = new GridViewRow(0, -1,
          //  DataControlRowType.Header, DataControlRowState.Normal);
          //      GridViewRow row2 = new GridViewRow(5, -1,
          //DataControlRowType.Header, DataControlRowState.Normal);
          //      TableCell left = new TableHeaderCell();
          //      left.ColumnSpan = 2;
          //      row.Cells.Add(left);
          //      left.BackColor = System.Drawing.Color.Gray;
          //      TableCell totals = new TableHeaderCell();
          //      totals.ColumnSpan = grid.Columns.Count - 8;
          //      totals.Text = "Session Principale";
          //      row.Cells.Add(totals);
          //      TableCell lef = new TableHeaderCell();
          //      lef.ColumnSpan = grid.Columns.Count - 8;
          //      lef.Text = "Rattrapage";
          //      row.Cells.Add(lef);
          //      lef.ForeColor = System.Drawing.Color.Black;
          //      lef.BackColor = System.Drawing.Color.BlueViolet;
          //      TableCell ratue = new TableHeaderCell();
          //      ratue.ColumnSpan = grid.Columns.Count - 8;

          //      row.Cells.Add(ratue);
          //      ratue.BackColor = System.Drawing.Color.Gray;
          //      TableCell modp = new TableHeaderCell();
          //      modp.ColumnSpan = grid.Columns.Count - 9;
          //      modp.Text = "Principale";

          //      row.Cells.Add(modp);
          //      TableCell modr = new TableHeaderCell();
          //      modr.ColumnSpan = grid.Columns.Count - 9;
          //      modr.Text = "Rattrapage";

          //      row.Cells.Add(modr);
          //      Table t = grid.Controls[0] as Table;



          //      if (t != null)
          //      {
          //          t.Rows.AddAt(0, row);
          //      }

            //}

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label Label7 = (Label)e.Row.FindControl("Label7");

                Label7.ForeColor = System.Drawing.Color.Purple;
                Label Label10 = (Label)e.Row.FindControl("Label10");

                Label10.ForeColor = System.Drawing.Color.Purple;
                Label DECISIONR = (Label)e.Row.FindControl("DECISIONR");

                DECISIONR.ForeColor = System.Drawing.Color.Purple;
                if (Convert.ToDecimal(Moy_R) >= 10)
                {
                    Label Label12 = (Label)e.Row.FindControl("Label12");
                    Label12.Text = nb.ToString();
                    Label12.ForeColor = System.Drawing.Color.Purple;
                }
                else if (Convert.ToDecimal(Moy_R) < 10)
                {
                    Label Label12 = (Label)e.Row.FindControl("Label12");
                    Label12.Text = ec.ToString();
                    Label12.ForeColor = System.Drawing.Color.Purple;
                }
                Label Label13 = (Label)e.Row.FindControl("Label13");
                Label13.Text = Moy_R;
                Label13.ForeColor = System.Drawing.Color.Purple;
                Label Label17 = (Label)e.Row.FindControl("Label17");
                Label17.ForeColor = System.Drawing.Color.Purple;
                Label17.Text = LIB_DECISION_SESSION_RAT;
                TableCell tableCell = new TableCell();
                tableCell.HorizontalAlign = HorizontalAlign.Center;
                e.Row.Font.Bold = true;
                //Label Label2 = (Label)e.Row.FindControl("Label2");
                //Label2.Text = Label9.Text;
                //using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                //{
                //    con.Open();
                //    string t = DropDownList1.SelectedValue.ToString();
                   
                //    OracleCommand cmd = new OracleCommand("SELECT sum(nb_ects) FROM ESP_V_MOY_UE_ETUDIANT where type_moy='P' and moyenne>=10 and id_et='" + t + "'  ");

                //    cmd.Connection = con;
                //    Label Label2 = (Label)e.Row.FindControl("Label2");
                //    Label2.Text = cmd.ExecuteScalar().ToString();
                //    con.Close();
                //}
                //using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                //{
                //    con.Open();
                //    string t = DropDownList1.SelectedValue.ToString();
                    
                //    OracleCommand cmd = new OracleCommand("SELECT MOY_GENERAL FROM ESP_INSCRIPTION where ANNEE_DEB=2013 and id_et='" + t + "'  ");

                //    cmd.Connection = con;
                //    Label Label3 = (Label)e.Row.FindControl("Label3");
                //    Label3.Text = cmd.ExecuteScalar().ToString();
                //    con.Close();
                //}
                //using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                //{
                //    con.Open();
                //    string t = DropDownList1.SelectedValue.ToString();
                  
                //    OracleCommand cmd = new OracleCommand("SELECT LIB_DECISION_SESSION_P FROM ESP_INSCRIPTION where ANNEE_DEB=2013 and id_et='" + t + "'  ");

                //    cmd.Connection = con;
                //    Label Label4 = (Label)e.Row.FindControl("Label4");
                //    Label4.Text = cmd.ExecuteScalar().ToString();
                //    con.Close();
                //}
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToDecimal(Moy_R) >= 10)
                {
                    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE_RATT")) < 8)
                    {
                        for (int i = 1; i < GridView2.Rows.Count + 2; i++)
                        {

                            e.Row.Cells[5].Text = "0";
                            e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;

                        }
                    }
                    else if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE_RATT")) >= 8)
                    {
                        for (int i = 1; i < GridView2.Rows.Count + 2; i++)
                        {


                            e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;

                        }
                    }
                }
                else if (Convert.ToDecimal(Moy_R) < 10)
                {
                    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE_RATT")) < 10)
                    {
                        for (int i = 1; i < GridView2.Rows.Count + 2; i++)
                        {

                            e.Row.Cells[5].Text = "0";
                            e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;

                        }
                    }
                    else if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE_RATT")) >= 10)
                    {
                        for (int i = 1; i < GridView2.Rows.Count + 2; i++)
                        {


                            e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;

                        }
                    }
                }


                if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) >= 10)
                {

                    decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NB_ECTS"));

                    total = total + rowTotal;


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

                }
            }
            foreach (TableCell cell in e.Row.Cells)
            {

                cell.Attributes.CssStyle["text-align"] = "center";

                if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOY_UE")) >= 10)
                {

                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Green;
                    e.Row.BorderWidth = 5;


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
                if (row.Cells[5].Text == previousRow.Cells[5].Text && row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    if (previousRow.Cells[5].RowSpan == 0)
                    {
                        if (row.Cells[5].RowSpan == 0)
                        {
                            previousRow.Cells[5].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[5].RowSpan = row.Cells[5].RowSpan + 1;
                        }
                        row.Cells[5].Visible = false;
                    }
                }

                if (row.Cells[6].Text == previousRow.Cells[6].Text && row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    if (previousRow.Cells[6].RowSpan == 0)
                    {
                        if (row.Cells[6].RowSpan == 0)
                        {
                            previousRow.Cells[6].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[6].RowSpan = row.Cells[6].RowSpan + 1;
                        }
                        row.Cells[6].Visible = false;
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
    }
}