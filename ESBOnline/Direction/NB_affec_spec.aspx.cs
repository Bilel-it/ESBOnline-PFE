using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ClosedXML.Excel;
using System.IO;
using System.Data;
using System.Text;

namespace ESPOnline.Direction
{
    public partial class NB_affec_spec : System.Web.UI.Page
    {
        StatService service = new StatService();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }


            if (!IsPostBack)
            {
                get_nb_affecparspecialite();
              
                lbl2.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }

        }
        protected void gridViewtoiec_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridtoiec.PageIndex = e.NewPageIndex;
            Gridtoiec.DataBind();
            Gridtoiec.DataSource = service.Afficher_list_ens_affecter();
            Gridtoiec.DataBind();
        }

        public void get_nb_affecparspecialite()
        {
            Gridtoiec.DataSource = service.Afficher_list_ens_affecter();
            Gridtoiec.DataBind();
        }

        protected void BuTT2_Click(object sender, EventArgs e)
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
                Response.AddHeader("content-disposition", "attachment;filename=Effectif_Ghazela.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

        }

        protected void Btnprint_Click(object sender, EventArgs e)
        {
            Gridtoiec.AllowPaging = false;
            Gridtoiec.DataSource = service.Afficher_list_ens_affecter();
            Gridtoiec.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Gridtoiec.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'")
                .Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            sb.Append(gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            Gridtoiec.AllowPaging = true;
            Gridtoiec.DataSource = service.Afficher_list_ens_affecter();
            Gridtoiec.DataBind();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

   
 
          decimal totalPrice = 0M;
                decimal totalStock = 0M;
                decimal totalgc = 0M;
              
                int totalItems = 0;
                protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                        Label lblUnitsInStock = (Label)e.Row.FindControl("lblUnitsInStock");
                        Label lblUnitsInStockGC = (Label)e.Row.FindControl("lblUnitsInStockGC");
                        

                        decimal price = Decimal.Parse(lblPrice.Text);
                        decimal stock = Decimal.Parse(lblUnitsInStock.Text);
                        decimal sgc = Decimal.Parse(lblUnitsInStockGC.Text);
                     


                        totalPrice += price;
                        totalStock += stock;
                        totalgc += sgc;
                       
                        totalItems += 1;
                    }

                    if (e.Row.RowType == DataControlRowType.Footer)
                    {
                        Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPrice");
                        Label lblTotalUnitsInStock = (Label)e.Row.FindControl("lblTotalUnitsInStock");
                        Label lblTotalUnitsInStockGC = (Label)e.Row.FindControl("lblTotalUnitsInStockGC");
                       


                        lblTotalPrice.Text = totalPrice.ToString();
                        lblTotalUnitsInStock.Text = totalStock.ToString();
                        lblTotalUnitsInStockGC.Text = totalgc.ToString();
                       

                        // lblAveragePrice.Text = (totalPrice / totalItems).ToString("F");
                    }
                }

 


    }
}
