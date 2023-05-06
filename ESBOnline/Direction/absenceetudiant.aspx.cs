using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace ESPOnline.Direction
{
    public partial class absenceetudiant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RadComboBox1_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            DataView dv2 = (DataView)SqlDataSource5.Select(DataSourceSelectArguments.Empty);
            decimal nb2 = (decimal)dv2.Table.Rows[0][0];
            Label22.Text = nb2.ToString();
            Label22.Visible = true;
            if (gvue.Rows.Count == 0)
            {
              
                Label19.Visible = true;
                Label19.Text = "Pas de saisie d'absence";
            }
            Label19.Text = "";
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
                Response.AddHeader("content-disposition", "attachment;filename=Suividesabsences.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

        }

        protected void BuTT_Click(object sender, EventArgs e)
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
                Response.AddHeader("content-disposition", "attachment;filename=Suividesabsencescumules.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

        }
        protected void test(object o, EventArgs e)
        {
            Button2.Visible = false;
            gvue.Visible = false;
            Label18.Visible = false;
            DropDownList1.Visible = false;
            Label2.Text = RadNumericTextBox1.Text;
             DataView dv = (DataView)SqlDataSource4.Select(DataSourceSelectArguments.Empty);
            decimal nb = (decimal)dv.Table.Rows[0][0];
            Label20.Text = nb.ToString();
            Label23.Text = TBdateseance.SelectedDate.ToString();
        }

       
    }
}