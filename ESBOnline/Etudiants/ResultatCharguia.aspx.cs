using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.UI.WebControls;

using System.Web;
using System.Web.UI;
using DAL;
using System.Configuration;
using Oracle.ManagedDataAccess.Types;
using BLL;
using Oracle.ManagedDataAccess.Client;

using ABSEsprit;
namespace ESPOnline.Etudiants
{
    public partial class ResultatCharguia : System.Web.UI.Page
    {
        public string ID_ET;
        string strPreviousRowID = string.Empty;
        int intSubTotalIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            ID_ET = Session["ID_ET"].ToString();
            if (GridView2.Rows.Count == 0)
            {
                DetailsView1.Visible = false;
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétent')</script>");
            }
            else
            {
                GridView2.Visible = true;
                DetailsView1.Visible = true;
            }

        }


        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            bool IsSubTotalRowNeedToAdd = false;
            bool IsGrandTotalRowNeedtoAdd = false;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "NUM_PANIER") != null))
                if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "NUM_PANIER").ToString())
                    IsSubTotalRowNeedToAdd = true;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "NUM_PANIER") == null))
            {
                IsSubTotalRowNeedToAdd = true;
                IsGrandTotalRowNeedtoAdd = true;
                intSubTotalIndex = 0;
            }
            if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "NUM_PANIER") != null))
            {
                GridView GridView2 = (GridView)sender;
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                TableCell cell = new TableCell();
                cell.Text = "Numéro Panier : " + DataBinder.Eval(e.Row.DataItem, "NUM_PANIER").ToString() + "            " + ".    Coeficient Panier : " + DataBinder.Eval(e.Row.DataItem, "COEF_P").ToString();
                cell.ColumnSpan = 6;
                cell.CssClass = "GroupHeaderStyle";
                row.Cells.Add(cell);
                GridView2.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;
            }
            if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "NUM_PANIER") != null))
            {
                GridView GridView2 = (GridView)sender;
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                TableCell cell = new TableCell();
                cell.Text = "Moyenne Panier : " + DataBinder.Eval(e.Row.DataItem, "MOYENNEP").ToString(); //+ "            " + ".    Nombre ECTS : " + DataBinder.Eval(e.Row.DataItem, "NB_ECTS").ToString() + "            " + ".    Moyenne Unité d'enseignement : " + DataBinder.Eval(e.Row.DataItem, "Moy_UE").ToString();
                cell.ColumnSpan = 6;
                cell.CssClass = "GroupHeaderStyle";
                row.Cells.Add(cell);
                GridView2.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;
            }

            if (IsSubTotalRowNeedToAdd)
            {
                #region Adding Sub Total Row
                GridView grdViewOrders = (GridView)sender;
                // Creating a Row          
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                //Adding Total Cell          
                TableCell cell = new TableCell();
                cell.Text = "Sub Total";
                cell.HorizontalAlign = HorizontalAlign.Left;
                cell.ColumnSpan = 2;
                cell.CssClass = "SubTotalRowStyle";
                // row.Cells.Add(cell);
                //Adding Unit Price Column          
                cell = new TableCell();
                cell.Text = "test1";//string.Format("{0:0.00}", dblSubTotalUnitPrice);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                // row.Cells.Add(cell);
                //Adding Quantity Column            
                cell = new TableCell();
                cell.Text = "test2";//string.Format("{0:0.00}", dblSubTotalQuantity);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                // row.Cells.Add(cell);
                //Adding Discount Column         
                cell = new TableCell();
                cell.Text = "test3"; //string.Format("{0:0.00}", dblSubTotalDiscount);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                //row.Cells.Add(cell);
                //Adding Amount Column         
                cell = new TableCell();
                cell.Text = "test4";//string.Format("{0:0.00}", dblSubTotalAmount);
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                //row.Cells.Add(cell);
                //Adding the Row at the RowIndex position in the Grid      
                grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;
                #endregion
                #region Adding Next Group Header Details
                if (DataBinder.Eval(e.Row.DataItem, "NUM_PANIER") != null)
                {
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "Numéro Panier : " + DataBinder.Eval(e.Row.DataItem, "NUM_PANIER").ToString() + "            " + ".    Coeficient Panier : " + DataBinder.Eval(e.Row.DataItem, "COEF_P").ToString();
                    cell.ColumnSpan = 6;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }


                if (DataBinder.Eval(e.Row.DataItem, "NUM_PANIER") != null)
                {
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "Moyenne Panier : " + DataBinder.Eval(e.Row.DataItem, "MOYENNEP").ToString();//+ "            " + ".    Nombre ECTS : " + DataBinder.Eval(e.Row.DataItem, "NB_ECTS").ToString() + "            " + ".    Moyenne Unité d'enseignement : " + DataBinder.Eval(e.Row.DataItem, "Moy_UE").ToString(); ;
                    cell.ColumnSpan = 6;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }




                #endregion



            }

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "NUM_PANIER").ToString();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ddd'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
                    e.Row.Attributes.Add("style", "cursor:pointer;");
                    // e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" + e.Row.RowIndex);
                }
            }
        }
    }
}