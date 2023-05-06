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
    public partial class Afficher_list_condidatsANG : System.Web.UI.Page
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
                GridANG.DataSource = service.Afficher_list_condParDateANG(dateang);
                GridANG.DataBind();
                //Lblpreptoiec.Text = service.nbPREPtoiec();
                //lblnbtoiec.Text = service.nbtoiec();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           // ExportGridToExcel();
        }
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridANG.PageIndex = e.NewPageIndex;
            GridANG.DataBind();
            GridANG.DataSource = service.Afficher_list_condParDateANG(Convert.ToDateTime(ddltestang.SelectedValue));
            GridANG.DataBind();
        }

        protected void EXPORT_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable("GridView_Data");
            foreach (TableCell cell in GridANG.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in GridANG.Rows)
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
      
       

       




        //private void ExportGridToExcel()
        //{
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
        //    Response.Charset = "";

        //    // If you want the option to open the Excel file without saving then
        //    // comment out the line below
        //    // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = "application/vnd.xls";
        //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //    GridANG.RenderControl(htmlWrite);
        //    Response.Write(stringWrite.ToString());
        //    Response.End();
        //   /* Response.Clear();
        //    Response.Buffer = true;
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    Response.Charset = "";
        //    string FileName = "Vithal" + DateTime.Now + ".xls";
        //    StringWriter strwritter = new StringWriter();
        //    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = "application/vnd.ms-excel";
        //    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //    GridANG.GridLines = GridLines.Both;
        //    GridANG.HeaderStyle.Font.Bold = true;
        //    GridANG.RenderControl(htmltextwrtter);
        //    Response.Write(strwritter.ToString());
        //    Response.End();*/

        //}
    }
}