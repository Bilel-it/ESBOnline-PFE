using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ClosedXML.Excel;
using System.Data;
using BLL;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Liste_Formation_langue_Commun : System.Web.UI.Page
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
                bindcommun();
            }

        }
        protected void gridViewcommun_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridcommun.PageIndex = e.NewPageIndex;
            Gridcommun.DataBind();
            Gridcommun.DataSource = service.Afficher_list_commune_formation();
            Gridcommun.DataBind();
        }

        public void bindcommun()
        {
            Gridcommun.DataSource = service.Afficher_list_commune_formation();
            Gridcommun.DataBind();

        }

        protected void Btntoiec_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("GridView_Data");


            foreach (TableCell cell in Gridcommun.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in Gridcommun.Rows)
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
                Response.AddHeader("content-disposition", "attachment;filename=liste_Commun.xlsx");
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

            //lblcountfr.Visible = true;

            lblnbtoiec.Text = service.countNB_fr_ang();
        }
    }
}