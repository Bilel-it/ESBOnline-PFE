using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;
using System.Data;
using DocumentFormat.OpenXml;

using ClosedXML.Excel;



namespace ESPOnline.EnseignantsCUP
{
    public partial class Afficher_list_condidats : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();
        string ID_ET;
        string up;
        string id;
        string nom;
        string cup;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            
            if (!IsPostBack)
            {
                BindDateExam();
                  
                lblanneedeb.Text = service.getANNEEDEBs();

                lblanneefin.Text = service.getAnneeFiN();

                lblcountang.Visible = true;
                lblcountfr.Visible = true;
               
               
            }
        }

       

       

        public void BindDateExam()
        {
            ddltestfr.DataTextField = "DATETEST";
            ddltestfr.DataValueField = "DATETEST";
            ddltestfr.DataSource = service.bindDATEx();
            ddltestfr.DataBind();
        }
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFR.PageIndex = e.NewPageIndex;
            GridFR.DataBind();
            GridFR.DataSource = service.Afficher_list_condParDateFR(Convert.ToDateTime(ddltestfr.SelectedValue));
            GridFR.DataBind();
        }

        protected void ddltestfr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltestfr.SelectedValue != null)
            {
                DateTime date = Convert.ToDateTime(ddltestfr.SelectedValue);
                GridFR.DataSource = service.Afficher_list_condParDateFR(date);
                GridFR.DataBind();
               
            }
        }

      

        protected void btnres_Click(object sender, EventArgs e)
        {
            lblcountang.Visible = true;
            lblcountfr.Visible = true;
            Lblpreptoiec.Text = service.nbPREPtoiec();
            lblnbtoiec.Text = service.nbtoiec();
        }
        

       
        protected void gridViewFR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFR.PageIndex = e.NewPageIndex;
            GridFR.DataBind();
            GridFR.DataSource = service.Afficher_list_condParDateFR(Convert.ToDateTime(ddltestfr.SelectedValue));
            GridFR.DataBind();
        }

       

       

    

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("GridView_Data");
            foreach (TableCell cell in GridFR.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in GridFR.Rows)
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

        
    }
}