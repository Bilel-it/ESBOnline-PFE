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
namespace ESPOnline.Direction
{
    public partial class Statistique_2017 : System.Web.UI.Page
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
                   lblch.Text = service.totalch();
                    Lblgh.Text = service.totalgh();
                    bindcharguia();
                    bindghazela();
                    //lbl2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lbl2.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); 
                   // lbl1.Text = DateTime.Now.ToString("h:mm:ss");
                }
            
        }
        protected void gridViewtoiec_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridtoiec.PageIndex = e.NewPageIndex;
            Gridtoiec.DataBind();
            Gridtoiec.DataSource = service.Afficher_list_ghazela();
            Gridtoiec.DataBind();
        }

        protected void gridViewtoiec62_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            GridView1.DataSource = service.Afficher_list_charguia();
            GridView1.DataBind();
        }

        public void bindcharguia()
        {
            GridView1.DataSource = service.Afficher_list_charguia();
            GridView1.DataBind();
        }

        public void bindghazela()
        {
            Gridtoiec.DataSource = service.Afficher_list_ghazela();
            Gridtoiec.DataBind();
        }

        protected void Gridtoiec_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BUTT1_Click(object sender, EventArgs e)
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
                Response.AddHeader("content-disposition", "attachment;filename=liste_Ens_toeic_prep.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
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

        protected void Btntoiec_Click(object sender, EventArgs e)
        {

        }
        decimal totalPrice = 0M;

        int totalItems = 0;
      
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrice = (Label)e.Row.FindControl("lblPricezer");
               

                decimal price = Decimal.Parse(lblPrice.Text);
              

                totalPrice += price;
              
                totalItems += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPriceeze");
               

                lblTotalPrice.Text = totalPrice.ToString();
               
                // lblAveragePrice.Text = (totalPrice / totalItems).ToString("F");
            }
        }







        decimal totalPrice2 = 0M;

        int totalItems2 = 0;
       
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrice = (Label)e.Row.FindControl("lblPrice");


                decimal price3 = Decimal.Parse(lblPrice.Text);


                totalPrice2 += price3;

                totalItems2 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPrice");


                lblTotalPrice.Text = totalPrice2.ToString();

                // lblAveragePrice.Text = (totalPrice / totalItems).ToString("F");
            }
        }


    }
}