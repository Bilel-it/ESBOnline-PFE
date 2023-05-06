using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.Direction
{
    public partial class Rep_etud_niv_pole : System.Web.UI.Page
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
                // affstatsite();
                affstatsite1();
                    affstatsite2();
                    affstatsite3();
                    affstatsite4();
                    lbl2.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); 

            }

        }
        //1
        protected void gridViewtoiec_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataBind();
            GridView2.DataSource = service.titalReparEtudiantParPole();
            GridView2.DataBind();
           
        }

        //2
        protected void gridViewtoiec_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            Gridtoiec.PageIndex = e.NewPageIndex;
            Gridtoiec.DataBind();
            Gridtoiec.DataSource = service.ReparEtudiantParPole();
            Gridtoiec.DataBind();
           
        }
        //3
        protected void gridViewtoiec_PageIndexChanging3(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataBind();
            GridView3.DataSource = service.totalReparclasseParPole();
            GridView3.DataBind();
           
        }
        //4
        protected void gridViewtoiec_PageIndexChanging4(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            GridView1.DataSource = service.ReparclasseParPole();
            GridView1.DataBind();
           
        }
      
        //1
        public void affstatsite1()
        {
            GridView2.DataSource = service.titalReparEtudiantParPole();
            GridView2.DataBind();
        }
        //2
        public void affstatsite2()
        {
            Gridtoiec.DataSource = service.ReparEtudiantParPole();
            Gridtoiec.DataBind();
        }
        //3
        public void affstatsite3()
        {
            GridView3.DataSource = service.totalReparclasseParPole();
            GridView3.DataBind();
        }
        //4
        public void affstatsite4()
        {
            GridView1.DataSource = service.ReparclasseParPole();
            GridView1.DataBind();
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


        decimal totalPrice1 = 0M;
        decimal totalStock2 = 0M;
        decimal totalgc3 = 0M;

        int totalItems2 = 0;
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                Label lblUnitsInStock = (Label)e.Row.FindControl("lblUnitsInStock");
                Label lblUnitsInStockGC = (Label)e.Row.FindControl("lblUnitsInStockGC");


                decimal price = Decimal.Parse(lblPrice.Text);
                decimal stock = Decimal.Parse(lblUnitsInStock.Text);
                decimal sgc = Decimal.Parse(lblUnitsInStockGC.Text);


                totalPrice1 += price;
                totalStock2 += stock;
                totalgc3 += sgc;

                totalItems2 += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPrice");
                Label lblTotalUnitsInStock = (Label)e.Row.FindControl("lblTotalUnitsInStock");
                Label lblTotalUnitsInStockGC = (Label)e.Row.FindControl("lblTotalUnitsInStockGC");


                lblTotalPrice.Text = totalPrice1.ToString();
                lblTotalUnitsInStock.Text = totalStock2.ToString();
                lblTotalUnitsInStockGC.Text = totalgc3.ToString();


                // lblAveragePrice.Text = (totalPrice / totalItems).ToString("F");
            }
        }



    }
}