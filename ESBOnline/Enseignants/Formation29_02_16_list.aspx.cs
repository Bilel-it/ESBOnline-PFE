using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.IO;
using System.Data;
using BLL;

namespace ESPOnline.Enseignants
{
    public partial class Formation29_02_16_list : System.Web.UI.Page
    {

        ToiecService langue = new ToiecService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            if (!IsPostBack)
            {
                bindLists();
            }

        }


        public void bindLists()
        {
            Gridtoiec.DataSource = langue.Consult_list_formationggg();
            Gridtoiec.DataBind();
        }


        protected void gridViewtoiec_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridtoiec.PageIndex = e.NewPageIndex;
            Gridtoiec.DataBind();
            Gridtoiec.DataSource = langue.Consult_list_formationggg();
            Gridtoiec.DataBind();
        }

        protected void Btntoiec_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("GridView_Data");


            foreach (TableCell cell in Gridtoiec.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in Gridtoiec.Rows)
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
                Response.AddHeader("content-disposition", "attachment;filename=liste_formation et test.xlsx");
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