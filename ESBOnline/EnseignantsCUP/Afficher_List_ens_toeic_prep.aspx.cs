using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;
using ClosedXML.Excel;
using System.Data;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Afficher_List_ens_toeic_prep : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();

        protected void Page_Load(object sender, EventArgs e)
        {
            bindListTOEIC();
            bindlistPrepToeic();
        }

        public void bindListTOEIC()
        {
            Gridtoiec.DataSource = service.Afficher_list_ens_toeic();
            Gridtoiec.DataBind();
        }

        public void bindlistPrepToeic()
        {
            Gridprep.DataSource = service.Afficher_list_ens_prep_toeic();
            Gridprep.DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridprep.PageIndex = e.NewPageIndex;
            Gridprep.DataBind();
            Gridprep.DataSource = service.Afficher_list_PREP_toiec();
            Gridprep.DataBind();
        }
        protected void gridViewtoiec_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridtoiec.PageIndex = e.NewPageIndex;
            Gridtoiec.DataBind();
            Gridtoiec.DataSource = service.Afficher_list_ens_toeic();
            Gridtoiec.DataBind();
        }


        protected void Btnprep_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("GridView_Data");


            foreach (TableCell cell in Gridprep.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in Gridprep.Rows)
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
                Response.AddHeader("content-disposition", "attachment;filename=liste_ens_prep.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
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
                Response.AddHeader("content-disposition", "attachment;filename=liste_ens_toeic.xlsx");
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