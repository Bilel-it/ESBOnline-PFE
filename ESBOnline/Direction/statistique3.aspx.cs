using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ESPOnline.Direction
{
    public partial class statistique3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
          decimal  nb = (decimal)dv.Table.Rows[0][0];
            Label1.Text = nb.ToString();

            DataView dv2 = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            decimal nb2 = (decimal)dv2.Table.Rows[0][0];
            Label2.Text = nb2.ToString();

            DataView dv3 = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
            decimal nb3 = (decimal)dv3.Table.Rows[0][0];
            Label3.Text = nb3.ToString();

            DataView dv4 = (DataView)SqlDataSource4.Select(DataSourceSelectArguments.Empty);
            decimal nb4 = (decimal)dv4.Table.Rows[0][0];
            Label4.Text = nb4.ToString();

            DataView dv5 = (DataView)SqlDataSource5.Select(DataSourceSelectArguments.Empty);
            decimal nb5 = (decimal)dv5.Table.Rows[0][0];
            Label5.Text = nb5.ToString();


            DataView dv6 = (DataView)SqlDataSource6.Select(DataSourceSelectArguments.Empty);
            decimal nb6 = (decimal)dv6.Table.Rows[0][0];
            Label6.Text = nb6.ToString();


            DataView dv7 = (DataView)SqlDataSource7.Select(DataSourceSelectArguments.Empty);
            decimal nb7 = (decimal)dv7.Table.Rows[0][0];
            Label7.Text = nb7.ToString();


            DataView dv8 = (DataView)SqlDataSource8.Select(DataSourceSelectArguments.Empty);
            decimal nb8 = (decimal)dv8.Table.Rows[0][0];
            Label8.Text = nb8.ToString();

            DataView dv9 = (DataView)SqlDataSource9.Select(DataSourceSelectArguments.Empty);
            decimal nb9 = (decimal)dv9.Table.Rows[0][0];
            Label9.Text = nb9.ToString();

            DataView dv10 = (DataView)SqlDataSource10.Select(DataSourceSelectArguments.Empty);
            decimal nb10 = (decimal)dv10.Table.Rows[0][0];
            Label10.Text = nb10.ToString();

            DataView dv11 = (DataView)SqlDataSource11.Select(DataSourceSelectArguments.Empty);
            decimal nb11 = (decimal)dv11.Table.Rows[0][0];
            Label11.Text = nb11.ToString();

            DataView dv12 = (DataView)SqlDataSource12.Select(DataSourceSelectArguments.Empty);
            decimal nb12 = (decimal)dv12.Table.Rows[0][0];
            Label12.Text = nb12.ToString();

            DataView dv13 = (DataView)SqlDataSource13.Select(DataSourceSelectArguments.Empty);
            decimal nb13 = (decimal)dv13.Table.Rows[0][0];
            Label13.Text = nb13.ToString();

            DataView dv14 = (DataView)SqlDataSource14.Select(DataSourceSelectArguments.Empty);
            decimal nb14 = (decimal)dv14.Table.Rows[0][0];
            Label14.Text = nb14.ToString();

            DataView dv15 = (DataView)SqlDataSource15.Select(DataSourceSelectArguments.Empty);
            decimal nb15 = (decimal)dv15.Table.Rows[0][0];
            Label15.Text = nb15.ToString();

            DataView dv16 = (DataView)SqlDataSource16.Select(DataSourceSelectArguments.Empty);
            decimal nb16 = (decimal)dv16.Table.Rows[0][0];
            Label16.Text = nb16.ToString();

            DataView dv17 = (DataView)SqlDataSource17.Select(DataSourceSelectArguments.Empty);
            decimal nb17 = (decimal)dv17.Table.Rows[0][0];
            Label17.Text = nb17.ToString();
            DataView dv18 = (DataView)SqlDataSource18.Select(DataSourceSelectArguments.Empty);
            decimal nb18 = (decimal)dv18.Table.Rows[0][0];
            Label18.Text = nb18.ToString();
            DataView dv19 = (DataView)SqlDataSource19.Select(DataSourceSelectArguments.Empty);
            decimal nb19 = (decimal)dv19.Table.Rows[0][0];
            Label19.Text = nb19.ToString();
            DataView dv20 = (DataView)SqlDataSource20.Select(DataSourceSelectArguments.Empty);
            decimal nb20 = (decimal)dv20.Table.Rows[0][0];
            Label20.Text = nb20.ToString();
            /////////////////////////soir///////////
            


             

            

        }
    }
}