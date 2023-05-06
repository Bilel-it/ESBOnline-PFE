using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;
using System.Text;
using System.Drawing;

namespace ESPOnline.Direction
{
    public partial class Stat_langues_2017 : System.Web.UI.Page
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
                binlisparnivETUD();
                binlisparnivETUDNIV();
                lbl2.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }

        }
        protected void gridViewtoiec_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridtoiec.PageIndex = e.NewPageIndex;
            Gridtoiec.DataBind();
            Gridtoiec.DataSource = service.Affich_list_etud_niveau_ang();
            Gridtoiec.DataBind();
        }

        public void binlisparnivETUD()
        {
            Gridtoiec.DataSource = service.Affich_list_etud_niveau_ang();
            Gridtoiec.DataBind();
        }

        //total par niveau
        public void binlisparnivETUDNIV()
        {
            //GridView1.DataSource = service.Afficher_total_par_niv();
            //GridView1.DataBind();
        }

        protected void Btnprint_Click(object sender, EventArgs e)
        {
            Gridtoiec.AllowPaging = false;
            Gridtoiec.DataSource = service.Affich_list_etud_niveau_ang();
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
            Gridtoiec.DataSource = service.Affich_list_etud_niveau_ang();
            Gridtoiec.DataBind();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }


        protected void BuTT2_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Repartition_par_niveau.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Gridtoiec.AllowPaging = false;
                binlisparnivETUD();

                Gridtoiec.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in Gridtoiec.HeaderRow.Cells)
                {
                    cell.BackColor = Gridtoiec.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Gridtoiec.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Gridtoiec.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Gridtoiec.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                Gridtoiec.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }


        decimal totalPrice = 0M;
        decimal totalStock = 0M;
        decimal totalgc = 0M;
        decimal totaltt = 0M;
        decimal redOUB = 0M;
        decimal PINS = 0M;
        decimal NBS = 0M;
        int totalItems = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                Label lblUnitsInStock = (Label)e.Row.FindControl("lblUnitsInStock");
                Label lblUnitsInStockGC = (Label)e.Row.FindControl("lblUnitsInStockGC");
                Label lblUnitsInStockGCTotal = (Label)e.Row.FindControl("lblUnitsInStockGCTotal");

                Label lblUnitsInStockGCTredoub = (Label)e.Row.FindControl("lblUnitsInStockGCTredoub");
               

                decimal price = Decimal.Parse(lblPrice.Text);
                decimal stock = Decimal.Parse(lblUnitsInStock.Text);
                decimal sgc = Decimal.Parse(lblUnitsInStockGC.Text);
                decimal tt = Decimal.Parse(lblUnitsInStockGCTotal.Text);

                decimal tt1 = Decimal.Parse(lblUnitsInStockGCTredoub.Text);
               


                totalPrice += price;
                totalStock += stock;
                totalgc += sgc;
                totaltt += tt;
                redOUB += tt1;
              
                totalItems += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPrice");
                Label lblTotalUnitsInStock = (Label)e.Row.FindControl("lblTotalUnitsInStock");
                Label lblTotalUnitsInStockGC = (Label)e.Row.FindControl("lblTotalUnitsInStockGC");
                Label lblTotalUnitsInStockGCTotal = (Label)e.Row.FindControl("lblTotalUnitsInStockGCTotal");

                Label lblTotalUnitsInStockredoub = (Label)e.Row.FindControl("lblTotalUnitsInStockredoub");
              


                lblTotalPrice.Text = totalPrice.ToString();
                lblTotalUnitsInStock.Text = totalStock.ToString();
                lblTotalUnitsInStockGC.Text = totalgc.ToString();
                lblTotalUnitsInStockGCTotal.Text = totaltt.ToString();

                lblTotalUnitsInStockredoub.Text = redOUB.ToString();
               

                // lblAveragePrice.Text = (totalPrice / totalItems).ToString("F");
            }
        }

    }

}