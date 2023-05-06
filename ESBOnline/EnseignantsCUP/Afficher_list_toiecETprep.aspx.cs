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
    public partial class Afficher_list_toiecETprep : System.Web.UI.Page
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
                lblanneedeb.Text = service.getANNEEDEBs();

                lblanneefin.Text = service.getAnneeFiN();


                bindnbTOIEC();
                bindnbPrepTOIEC();
            }

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
            Gridtoiec.DataSource = service.Afficher_list_toiec() ;
            Gridtoiec.DataBind();
        }

        public void bindnbTOIEC()
        {
            Gridtoiec.DataSource = service.Afficher_list_toiec();
            Gridtoiec.DataBind();
        
        }

        public void bindnbPrepTOIEC()
        {
            Gridprep.DataSource = service.Afficher_list_PREP_toiec();
            Gridprep.DataBind();
        }


        public void listCommune()
        { 
        
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
                Response.AddHeader("content-disposition", "attachment;filename=listeCandidatPreparationToiec.xlsx");
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
                Response.AddHeader("content-disposition", "attachment;filename=listeCandidtsToiec.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        
      
        }

        protected void btnres_Click(object sender, EventArgs e)
        {
            lblcountang.Visible = true;
            lblcountfr.Visible = true;
            Lblpreptoiec.Text = service.countNBPrep_TOIEC();
            lblnbtoiec.Text = service.countNB_TOIEC();
        }
    }
}