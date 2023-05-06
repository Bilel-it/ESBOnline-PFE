using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BLL;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using System.Data;


namespace ESPOnline.EnseignantsCUP
{
    public partial class Memedates : System.Web.UI.Page
    {

        ToiecService service = new ToiecService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            if (!IsPostBack)
            {

                BindDateExamANG();
                Label1.Text = service.getANNEEDEBs();

                Label2.Text = service.getAnneeFiN();

                Label1.Text = service.getANNEEDEBs();

                Label2.Text = service.getAnneeFiN();

                lblcountang.Visible = true;
                lblcountfr.Visible = true;


            }
        }
        protected void btnres_Click(object sender, EventArgs e)
        {
            lblcountang.Visible = true;
            lblcountfr.Visible = true;
            Lblpreptoiec.Text = service.nbPREPtoiec();
            lblnbtoiec.Text = service.nbtoiec();
        }
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridALL.PageIndex = e.NewPageIndex;
            GridALL.DataBind();
            GridALL.DataSource = service.Afficher_date_exam_etud_mamadate(Convert.ToDateTime(ddltestang.SelectedValue));
            GridALL.DataBind();
        }

        public void BindDateExamANG()
        {
            ddltestang.DataTextField = "DATETEST";
            ddltestang.DataValueField = "DATETEST";
            ddltestang.DataSource = service.bindDATEx();
            ddltestang.DataBind();
        }




        protected void ddltestang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltestang.SelectedValue != null)
            {
                DateTime dateang = Convert.ToDateTime(ddltestang.SelectedValue);
                GridALL.DataSource = service.Afficher_date_exam_etud_mamadate(dateang);
                GridALL.DataBind();
                //Lblpreptoiec.Text = service.nbPREPtoiec();
                //lblnbtoiec.Text = service.nbtoiec();
            }
        }
        

       

        protected void Button1_Click1(object sender, EventArgs e)
        {

            DataTable dt = new DataTable("GridView_Data");
            foreach (TableCell cell in GridALL.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in GridALL.Rows)
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
                GridALL.AllowPaging = true;
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=listetudinscANG.xlsx");
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