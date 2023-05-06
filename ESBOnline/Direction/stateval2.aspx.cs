using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.IO;
using System.Data;

namespace ESPOnline.Direction
{
    public partial class stateval2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataView dv3 = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            decimal nb3 = (decimal)dv3.Table.Rows[0][0];
            Label1.Text = nb3.ToString();
        }

        protected void GridView1_test(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell cell in e.Row.Cells)
            {

                cell.Attributes.CssStyle["text-align"] = "center";
            }
        }
        protected void BuTT2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("GridView_Data");


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
                Response.AddHeader("content-disposition", "attachment;filename=satisfaction_60.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

        }
    }
}