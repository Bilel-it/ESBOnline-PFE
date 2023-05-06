using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI.GridExcelBuilder;
using Telerik.Web.UI;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace ESPOnline.Direction.admission
{
    public partial class CJ_liste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ID_DECID"] == null)
            //{
            //    Response.Redirect("~/Online/default.aspx");
            //}
            //Response.Redirect("~/Online/default.aspx");
            //DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            //decimal nb = (decimal)dv.Table.Rows[0][0];
            //Label1.Text = nb.ToString();
        }


        protected void grid1(object sender, GridItemEventArgs e)
        {
            foreach (TableCell cell in e.Item.Cells)
            {

                cell.Attributes.CssStyle["text-align"] = "center";

            }
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;
                TableCell myCell = dataItem["NATURE_BAC"];
                TableCell myCell2 = dataItem["SPECIALITE_ESP_ET"];
                if (myCell2.Text == "INFO")
                {
                    // myCell2.Text = "INFO";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Red;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "06")
                {
                    myCell2.Text = "Licence en Sciences de Gestion";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.IndianRed;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "07")
                {
                    myCell2.Text = "Licence en Informatique de Gestion";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Chocolate;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "08")
                {
                    myCell2.Text = "Master en Management	Digital	et Systèmes d’Information";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Pink;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "09")
                {
                    myCell2.Text = "Master en Marketing Digital";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.BlueViolet;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "10")
                {
                    myCell2.Text = "Master en Innovation	& Entrepreneuriat";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Brown;
                    dataItem.Font.Bold = true;
                }

                if (myCell2.Text == "03")
                {
                    myCell2.Text = "GC";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Green;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "04")
                {
                    myCell2.Text = "EM";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Black;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "02")
                {
                    myCell2.Text = "TELECOM";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Black;
                    dataItem.Font.Bold = true;
                }
                if ((myCell.Text == "INFO"))
                {
                    //  myCell.Text = "INFO";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.HotPink;
                    dataItem.Font.Bold = true;
                }
                if ((myCell.Text == "MATH"))
                {
                    //  myCell.Text = "Math";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.Red;
                    dataItem.Font.Bold = true;
                } if ((myCell.Text == "SC EXP"))
                {
                    //  myCell.Text = "Sc Exp";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.Green;
                    dataItem.Font.Bold = true;
                }
                if ((myCell.Text == "ECONOMIE"))
                {
                    // myCell.Text = "Economie";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.Black;
                    dataItem.Font.Bold = true;


                }
                if ((myCell.Text == "TECHNIQUE"))
                {
                    //  myCell.Text = "Tech";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.Blue;
                    dataItem.Font.Bold = true;


                }
            }

        }


        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            GridHeaderItem hitem = (GridHeaderItem)RadGrid1.MasterTableView.GetItems(GridItemType.Header)[0];
            //foreach (TableCell cell in lastItem.Cells)
            //{
            //    cell.Style["border-bottom"] = "1px solid red";
            //} 
            //hitem["ID_ET"].BackColor = System.Drawing.Color.Red;
            RadGrid1.Columns[3].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ae002e");
            RadGrid1.Columns[4].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ae002e");
            RadGrid1.Columns[5].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ae002e");
            RadGrid1.Columns[6].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
            RadGrid1.Columns[7].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
            RadGrid1.Columns[8].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
            RadGrid1.Columns[9].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
            RadGrid1.Columns[10].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
            RadGrid1.Columns[11].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
            RadGrid1.Columns[12].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
            RadGrid1.Columns[13].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
            RadGrid1.Columns[14].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");

            foreach (GridColumn col in RadGrid1.MasterTableView.RenderColumns)
            {

                //col.ItemStyle.Width = Unit.Pixel(100);
                //col.HeaderStyle.Width = Unit.Pixel(100);
                if (col.UniqueName == "E_MAIL_ET")
                {
                    col.ItemStyle.Width = Unit.Pixel(150);
                    col.HeaderStyle.Width = Unit.Pixel(150);
                }
                if (col.UniqueName == "ANNEE_BAC")
                {
                    col.ItemStyle.Width = Unit.Pixel(40);
                    col.HeaderStyle.Width = Unit.Pixel(50);
                }
                if (col.UniqueName == "NIVEAU_ACCES")
                {
                    col.ItemStyle.Width = Unit.Pixel(20);
                    col.HeaderStyle.Width = Unit.Pixel(40);
                }
                if (col.UniqueName == "SPECIALITE_ESP_ET")
                {
                    col.ItemStyle.Width = Unit.Pixel(40);
                    col.HeaderStyle.Width = Unit.Pixel(80);
                }
                
                //if (col.UniqueName == "PNOM_ET" || col.UniqueName == "NOM_ET")
                //{
                //    col.ItemStyle.Width = Unit.Pixel(70);
                //    col.HeaderStyle.Width = Unit.Pixel(70);
                //}

            }


        }
        protected void grvMergeHeader_RowCreated(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.Header)
            {


                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();

                //HeaderCell.Text = " ";
                //HeaderCell.ColumnSpan = 3;

                //HeaderCell.BackColor = System.Drawing.Color.White;
                //HeaderGridRow.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Soutien Scolaire";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 3;
                //HeaderCell.BackColor = System.Drawing.Color.FromName("#d3003f");

                //HeaderGridRow.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Clubs";
                //HeaderCell.BackColor = System.Drawing.Color.FromName("#A8A8A8");
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 14;
                //HeaderGridRow.Cells.Add(HeaderCell);
                //RadGrid1.Controls[0].Controls.AddAt(0, HeaderGridRow);
                RadGrid1.Columns[3].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ae002e");
                RadGrid1.Columns[4].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ae002e");
                RadGrid1.Columns[5].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ae002e");
                RadGrid1.Columns[6].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[7].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[8].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[9].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[10].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[11].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[12].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[13].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[14].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[15].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[16].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ffcc99");
                RadGrid1.Columns[17].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ffcc99");
                RadGrid1.Columns[18].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ffcc99");
                RadGrid1.Columns[19].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ffcc99");
            }
        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            //string alternateText = (sender as ImageButton).AlternateText; ;
            //RadGrid2.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
            //RadGrid2.ExportSettings.IgnorePaging = true;
            //RadGrid2.ExportSettings.ExportOnlyData = true;
            //RadGrid2.ExportSettings.OpenInNewWindow = true;
            //RadGrid2.MasterTableView.ExportToExcel();

            DataTable dt = new DataTable("ETAT_Data");


            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                Response.Clear();

                Response.Buffer = true;
                Response.Charset = "";

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.ContentType = "text/csv";
                Response.AddHeader("content-disposition", "attachment;filename=Liste_candidats" + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }


        }

        protected void RadGrid1_ExcelMLWorkBookCreated(object sender, GridExcelMLWorkBookCreatedEventArgs e)
        {

            foreach (RowElement row in e.WorkBook.Worksheets[0].Table.Rows)
            {
                row.Cells[0].StyleValue = "Style1";
            }

            StyleElement style = new StyleElement("Style1");
            style.InteriorStyle.Pattern = InteriorPatternType.Solid;
            style.InteriorStyle.Color = System.Drawing.Color.LightGray;
            e.WorkBook.Styles.Add(style);

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}