using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.Direction
{
    public partial class Stat_par_site : System.Web.UI.Page
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
                affstatsite();
                affstatsitesite();
                lbl2.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); 
            }

        }
        protected void gridViewtoiec_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridtoiec.PageIndex = e.NewPageIndex;
            Gridtoiec.DataBind();
            Gridtoiec.DataSource = service.Afficher_stat_site();
            Gridtoiec.DataBind();
        }

        public void affstatsite()
        {
            Gridtoiec.DataSource = service.Afficher_stat_site();
            Gridtoiec.DataBind();
        }


        public void affstatsitesite()
        {
            GridView1.DataSource = service.Afficher_total_DES_TOTAUX();
            GridView1.DataBind();
        }

        //calculer la somme des totaux:
       
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
                Label lblUnitsInStockGCTprins = (Label)e.Row.FindControl("lblUnitsInStockGCTprins");
                Label lblUnitsInStockNB = (Label)e.Row.FindControl("lblUnitsInStockNB");

                decimal price = Decimal.Parse(lblPrice.Text);
                decimal stock = Decimal.Parse(lblUnitsInStock.Text);
                decimal sgc = Decimal.Parse(lblUnitsInStockGC.Text);
                decimal tt = Decimal.Parse(lblUnitsInStockGCTotal.Text);

                decimal tt1 = Decimal.Parse(lblUnitsInStockGCTredoub.Text);
                decimal tt2 = Decimal.Parse(lblUnitsInStockGCTprins.Text);
                decimal tt3 = Decimal.Parse(lblUnitsInStockNB.Text);


                totalPrice += price;
                totalStock += stock;
                totalgc += sgc;
                totaltt += tt;
                redOUB += tt1;
                PINS += tt2;
                NBS += tt3;
                totalItems += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPrice");
                Label lblTotalUnitsInStock = (Label)e.Row.FindControl("lblTotalUnitsInStock");
                Label lblTotalUnitsInStockGC = (Label)e.Row.FindControl("lblTotalUnitsInStockGC");
                Label lblTotalUnitsInStockGCTotal = (Label)e.Row.FindControl("lblTotalUnitsInStockGCTotal");

                Label lblTotalUnitsInStockredoub = (Label)e.Row.FindControl("lblTotalUnitsInStockredoub");
                Label lblTotalUnitsInStockprins = (Label)e.Row.FindControl("lblTotalUnitsInStockprins");
                Label lblTotalUnitsInStockNB = (Label)e.Row.FindControl("lblTotalUnitsInStockNB");


                lblTotalPrice.Text = totalPrice.ToString();
                lblTotalUnitsInStock.Text = totalStock.ToString();
                lblTotalUnitsInStockGC.Text = totalgc.ToString();
                lblTotalUnitsInStockGCTotal.Text = totaltt.ToString();

                lblTotalUnitsInStockredoub.Text = redOUB.ToString();
                lblTotalUnitsInStockprins.Text = PINS.ToString();
                lblTotalUnitsInStockNB.Text = NBS.ToString();

                // lblAveragePrice.Text = (totalPrice / totalItems).ToString("F");
            }
        }
    }
}