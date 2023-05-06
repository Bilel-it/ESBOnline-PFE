using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ESPOnline.Direction
{
    public partial class Statistique4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            decimal nb = (decimal)dv.Table.Rows[0][0];
            Label1.Text = nb.ToString();
           ////////
            decimal nb1 = 210 -(decimal)dv.Table.Rows[0][0];
            Label21.Text = nb1.ToString();
            ///////////
            DataView dv2 = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            decimal nb2 = (decimal)dv2.Table.Rows[0][0];
            Label2.Text = nb2.ToString();
           //////
            decimal n5 = 112 - (decimal)dv2.Table.Rows[0][0];
            Label25.Text = n5.ToString();
            ///////////

            DataView dv3 = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
            decimal nb3 = (decimal)dv3.Table.Rows[0][0];
            Label3.Text = nb3.ToString();
            //////////
            decimal n8 = 60 - (decimal)dv3.Table.Rows[0][0];
            Label28.Text = n8.ToString();
            /////

            DataView dv4 = (DataView)SqlDataSource4.Select(DataSourceSelectArguments.Empty);
            decimal nb4 = (decimal)dv4.Table.Rows[0][0];
            Label4.Text = nb4.ToString();
            //////////
            decimal n2 = 58 - (decimal)dv4.Table.Rows[0][0];
            Label22.Text = n2.ToString();
            //////////
            DataView dv5 = (DataView)SqlDataSource5.Select(DataSourceSelectArguments.Empty);
            decimal nb5 = (decimal)dv5.Table.Rows[0][0];
            Label5.Text = nb5.ToString();

            /////////////
            decimal n6 = 30 - (decimal)dv5.Table.Rows[0][0];
            Label26.Text = n6.ToString();
            //////////
            DataView dv6 = (DataView)SqlDataSource6.Select(DataSourceSelectArguments.Empty);
            decimal nb6 = (decimal)dv6.Table.Rows[0][0];
            Label6.Text = nb6.ToString();
            ////////////
            decimal n9 = 30 - (decimal)dv6.Table.Rows[0][0];
            Label29.Text = n9.ToString();
            
            ////////////

            DataView dv7 = (DataView)SqlDataSource7.Select(DataSourceSelectArguments.Empty);
            decimal nb7 = (decimal)dv7.Table.Rows[0][0];
            Label7.Text = nb7.ToString();
            //////////
            decimal n3 = 390 - (decimal)dv.Table.Rows[0][0];
            Label23.Text = n3.ToString();
            ////////

            DataView dv8 = (DataView)SqlDataSource8.Select(DataSourceSelectArguments.Empty);
            decimal nb8 = (decimal)dv8.Table.Rows[0][0];
            Label8.Text = nb8.ToString();
            ///////////
           
            ////////////
            decimal n7 = 150 - (decimal)dv8.Table.Rows[0][0];
            Label27.Text = n7.ToString();
            ///////////
            DataView dv9 = (DataView)SqlDataSource9.Select(DataSourceSelectArguments.Empty);
            decimal nb9 = (decimal)dv9.Table.Rows[0][0];
            Label9.Text = nb9.ToString();
            /////////
            decimal n10 = 60 - (decimal)dv9.Table.Rows[0][0];
            Label30.Text = n10.ToString();
            /////////

            DataView dv10 = (DataView)SqlDataSource10.Select(DataSourceSelectArguments.Empty);
            decimal nb10 = (decimal)dv10.Table.Rows[0][0];
            Label10.Text = nb10.ToString();
            ///////////
            decimal n4 = 90 - (decimal)dv10.Table.Rows[0][0];
            Label24.Text = n4.ToString();
            /////////

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


            DataView dv31 = (DataView)SqlDataSource24.Select(DataSourceSelectArguments.Empty);
            decimal nb31 = (decimal)dv31.Table.Rows[0][0];
            Label31.Text = nb31.ToString();

            DataView dv32 = (DataView)SqlDataSource25.Select(DataSourceSelectArguments.Empty);
            decimal nb32 = (decimal)dv32.Table.Rows[0][0];
            Label32.Text = nb32.ToString();
            DataView dv33 = (DataView)SqlDataSource26.Select(DataSourceSelectArguments.Empty);
            decimal nb33 = (decimal)dv33.Table.Rows[0][0];
            Label33.Text = nb33.ToString();

            DataView dv34 = (DataView)SqlDataSource30.Select(DataSourceSelectArguments.Empty);
            decimal nb34 = (decimal)dv34.Table.Rows[0][0];
            Label34.Text = nb34.ToString();

            DataView dv35 = (DataView)SqlDataSource31.Select(DataSourceSelectArguments.Empty);
            decimal nb35 = (decimal)dv35.Table.Rows[0][0];
            Label35.Text = nb35.ToString();
            DataView dv36 = (DataView)SqlDataSource32.Select(DataSourceSelectArguments.Empty);
            decimal nb36 = (decimal)dv36.Table.Rows[0][0];
            Label36.Text = nb36.ToString();

            DataView dv37 = (DataView)SqlDataSource33.Select(DataSourceSelectArguments.Empty);
            decimal nb37 = (decimal)dv37.Table.Rows[0][0];
            Label37.Text = nb37.ToString();

            DataView dv38 = (DataView)SqlDataSource21.Select(DataSourceSelectArguments.Empty);
            decimal nb38 = (decimal)dv38.Table.Rows[0][0];
            Label38.Text = nb38.ToString();
            DataView dv39 = (DataView)SqlDataSource22.Select(DataSourceSelectArguments.Empty);
            decimal nb39 = (decimal)dv39.Table.Rows[0][0];
            Label39.Text = nb39.ToString();
            DataView dv40 = (DataView)SqlDataSource23.Select(DataSourceSelectArguments.Empty);
            decimal nb40 = (decimal)dv40.Table.Rows[0][0];
            Label40.Text = nb40.ToString();


            DataView dv41 = (DataView)SqlDataSource37.Select(DataSourceSelectArguments.Empty);
            decimal nb41 = (decimal)dv41.Table.Rows[0][0];
            Label41.Text = nb41.ToString();
            DataView dv42 = (DataView)SqlDataSource38.Select(DataSourceSelectArguments.Empty);
            decimal nb42 = (decimal)dv42.Table.Rows[0][0];
            Label42.Text = nb42.ToString();
            DataView dv43 = (DataView)SqlDataSource39.Select(DataSourceSelectArguments.Empty);
            decimal nb43 = (decimal)dv43.Table.Rows[0][0];
            Label43.Text = nb43.ToString();

            DataView dv44 = (DataView)SqlDataSource40.Select(DataSourceSelectArguments.Empty);
            decimal nb44 = (decimal)dv44.Table.Rows[0][0];
            Label44.Text = nb44.ToString();
            DataView dv45 = (DataView)SqlDataSource41.Select(DataSourceSelectArguments.Empty);
            decimal nb45 = (decimal)dv45.Table.Rows[0][0];
            Label45.Text = nb45.ToString();
            DataView dv46 = (DataView)SqlDataSource42.Select(DataSourceSelectArguments.Empty);
            decimal nb46 = (decimal)dv46.Table.Rows[0][0];
            Label46.Text = nb46.ToString();

            DataView dv47 = (DataView)SqlDataSource43.Select(DataSourceSelectArguments.Empty);
            decimal nb47 = (decimal)dv47.Table.Rows[0][0];
            Label47.Text = nb47.ToString();
            DataView dv48 = (DataView)SqlDataSource44.Select(DataSourceSelectArguments.Empty);
            decimal nb48 = (decimal)dv48.Table.Rows[0][0];
            Label48.Text = nb48.ToString();
            DataView dv49 = (DataView)SqlDataSource45.Select(DataSourceSelectArguments.Empty);
            decimal nb49 = (decimal)dv49.Table.Rows[0][0];
            Label49.Text = nb49.ToString();
            DataView dv50 = (DataView)SqlDataSource46.Select(DataSourceSelectArguments.Empty);
            decimal nb50 = (decimal)dv50.Table.Rows[0][0];
            Label50.Text = nb50.ToString();
            
           ///////////////Calcul total///////////////
            decimal nb51 = 210+58+390+90+112+30+150+60+30+60;
            Label51.Text = nb51.ToString();
            Label53.Text = ((n7) + (n10) + (n4) + (n3) + (n9) + (nb1) + (n5) + (n8) + (n2) + (n6)).ToString();
            Label52.Text = ((nb7) + (nb10) + (nb4) + (nb3) + (nb9) + (nb) + (nb5) + (nb8) + (nb2) + (nb6)).ToString();
            Label54.Text = ((nb11) + (nb12) + (nb13) + (nb14) + (nb15) + (nb16) + (nb17) + (nb18) + (nb19) + (nb20)).ToString();
            Label55.Text = ((nb31) + (nb32) + (nb33) + (nb34) + (nb35) + (nb36) + (nb37) + (nb38) + (nb39) + (nb40)).ToString();
            Label56.Text = ((nb41) + (nb42) + (nb43) + (nb44) + (nb45) + (nb46) + (nb47) + (nb48) + (nb49) + (nb50)).ToString(); 
            /////////////////////////////calcul percent/////////////

            Label57.Text=(Math.Round((nb/nb11),2)*100).ToString()+"%" ;
            Label68.Text = (Math.Round((nb11 / nb31), 2) * 100).ToString() + "%";
            Label79.Text = (Math.Round((nb31 / nb41), 2) * 100).ToString() + "%";
            /*************/

       
                //+Decimal.Parse(Label58.Text)+Decimal.Parse(Label59.Text)+Decimal.Parse(Label60.Text)+Decimal.Parse(Label61.Text)+Decimal.Parse(Label62.Text)+Decimal.Parse(Label63.Text)+Decimal.Parse(Label64.Text)+Decimal.Parse(Label65.Text)+Decimal.Parse(Label66.Text))/10;
            Label67.Text = (((Math.Round((nb / nb11), 2) * 100) + (Math.Round((nb4 / nb12), 2) * 100) + (Math.Round((nb7 / nb13), 2) * 100) + (Math.Round((nb10 / nb14), 2) * 100) + (Math.Round((nb2 / nb15), 2) * 100) + (Math.Round((nb5 / nb16), 2) * 100) + (Math.Round((nb8 / nb17), 2) * 100) + (Math.Round((nb8 / nb17), 2) * 100) + (Math.Round((nb3 / nb18), 2) * 100) + (Math.Round((nb6 / nb19), 2) * 100) + (Math.Round((nb9 / nb20), 2) * 100)) / 10).ToString() + "%";
            Label58.Text = (Math.Round((nb4 / nb12), 2) * 100).ToString() + "%";
            Label69.Text = (Math.Round((nb12 / nb32),2) * 100).ToString() + "%";
            Label80.Text = (Math.Round((nb32 / nb42), 2) * 100).ToString() + "%";
            /******/
            Label59.Text = (Math.Round((nb7 / nb13), 2) * 100).ToString() + "%";
            Label70.Text = (Math.Round((nb13 / nb33), 2) * 100).ToString() + "%";
            Label81.Text = (Math.Round((nb33 / nb43), 2) * 100).ToString() + "%";
            /*************/
            Label60.Text = (Math.Round((nb10 / nb14), 2) * 100).ToString() + "%";
            Label71.Text = (Math.Round((nb14 / nb34), 2) * 100).ToString() + "%";
            Label82.Text = (Math.Round((nb34/ nb44), 2) * 100).ToString() + "%";
            /*************/
            Label61.Text = (Math.Round((nb2 / nb15), 2) * 100).ToString() + "%";
            Label72.Text = (Math.Round((nb15 / nb35), 2) * 100).ToString() + "%";
            Label83.Text = (Math.Round((nb35 / nb45), 2) * 100).ToString() + "%";
            /*************/
            Label62.Text = (Math.Round((nb5 / nb16), 2) * 100).ToString() + "%";
            Label73.Text = (Math.Round((nb16 / nb36), 2) * 100).ToString() + "%"; 
            Label84.Text = (Math.Round((nb36 / nb46), 2) * 100).ToString() + "%";
            /*************/
            Label63.Text = (Math.Round((nb8 / nb17), 2) * 100).ToString() + "%";
            Label74.Text = (Math.Round((nb17 / nb37), 2) * 100).ToString() + "%";
            Label85.Text = (Math.Round((nb37 / nb47), 2) * 100).ToString() + "%";
            /*************/
            Label64.Text = (Math.Round((nb3 / nb18), 2) * 100).ToString() + "%";
            Label75.Text = (Math.Round((nb18 / nb38), 2) * 100).ToString() + "%";
            Label86.Text = (Math.Round((nb38 / nb48), 2) * 100).ToString() + "%";
            /*************/
            Label65.Text = (Math.Round((nb6 / nb19), 2) * 100).ToString() + "%";
            Label76.Text = (Math.Round((nb19 / nb39), 2) * 100).ToString() + "%";
            Label87.Text = (Math.Round((nb39 / nb49), 2) * 100).ToString() + "%";
            /*************/
            Label66.Text = (Math.Round((nb9 / nb20), 2) * 100).ToString() + "%";

            Label77.Text = (Math.Round((nb20 / nb40), 2) * 100).ToString() + "%";
            Label88.Text = (Math.Round((nb40 / nb50), 2) * 100).ToString() + "%";
            Label78.Text = (((Math.Round((nb11 / nb31), 2) * 100) + (Math.Round((nb12 / nb32), 2) * 100) + (Math.Round((nb13 / nb33), 2) * 100) + (Math.Round((nb14 / nb34), 2) * 100) + (Math.Round((nb15 / nb35), 2) * 100) + (Math.Round((nb16 / nb36), 2) * 100) + (Math.Round((nb17 / nb37), 2) * 100) + (Math.Round((nb18 / nb38), 2) * 100) + (Math.Round((nb19 / nb39), 2) * 100) + (Math.Round((nb19 / nb39), 2) * 100) + (Math.Round((nb20 / nb40), 2) * 100)) / 10).ToString()+"%";
            //////////////////////////////////////////////////
            Label89.Text = (((Math.Round((nb31 / nb41), 2) * 100) + (Math.Round((nb32 / nb42), 2) * 100) + (Math.Round((nb33 / nb43), 2) * 100) + (Math.Round((nb34 / nb44), 2) * 100) + (Math.Round((nb35 / nb45), 2) * 100) + (Math.Round((nb36 / nb46), 2) * 100) + (Math.Round((nb37 / nb47), 2) * 100) + (Math.Round((nb38 / nb48), 2) * 100) + (Math.Round((nb39 / nb49), 2) * 100) + (Math.Round((nb40 / nb50), 2) * 100))/10).ToString() + "%";
            //////////////////COURS DU SOIR:::::::::::::::::://////////////////////////////
            DataView dv90 = (DataView)SqlDataSource47.Select(DataSourceSelectArguments.Empty);
            decimal nb90 = (decimal)dv90.Table.Rows[0][0];
            Label90.Text = nb90.ToString();
              DataView dv96 = (DataView)SqlDataSource48.Select(DataSourceSelectArguments.Empty);
            decimal nb96 = (decimal)dv96.Table.Rows[0][0];
            Label96.Text = nb96.ToString();
            DataView dv102 = (DataView)SqlDataSource49.Select(DataSourceSelectArguments.Empty);
            decimal nb102 = (decimal)dv102.Table.Rows[0][0];
            Label102.Text = nb102.ToString();
            DataView dv92 = (DataView)SqlDataSource50.Select(DataSourceSelectArguments.Empty);
            decimal nb92 = (decimal)dv92.Table.Rows[0][0];
            Label92.Text = nb92.ToString();
            DataView dv98 = (DataView)SqlDataSource51.Select(DataSourceSelectArguments.Empty);
            decimal nb98 = (decimal)dv98.Table.Rows[0][0];
            Label98.Text = nb98.ToString();
            DataView dv104 = (DataView)SqlDataSource52.Select(DataSourceSelectArguments.Empty);
            decimal nb104 = (decimal)dv104.Table.Rows[0][0];
            Label104.Text = nb104.ToString();

            DataView dv94 = (DataView)SqlDataSource53.Select(DataSourceSelectArguments.Empty);
            decimal nb94 = (decimal)dv94.Table.Rows[0][0];
            Label94.Text = nb94.ToString();

            DataView dv100 = (DataView)SqlDataSource54.Select(DataSourceSelectArguments.Empty);
            decimal nb100 = (decimal)dv100.Table.Rows[0][0];
            Label100.Text = nb100.ToString();

            DataView dv106 = (DataView)SqlDataSource55.Select(DataSourceSelectArguments.Empty);
            decimal nb106 = (decimal)dv106.Table.Rows[0][0];
            Label106.Text = nb106.ToString();
        }

    }
}