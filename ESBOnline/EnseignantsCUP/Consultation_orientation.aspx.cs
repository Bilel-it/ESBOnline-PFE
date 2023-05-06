using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Consultation_orientation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
           
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        if (row.RowType == DataControlRowType.DataRow)
            //        {
            //            Label lblNom = (row.FindControl("lblNom") as Label);
            //            if (lblNom.Text == "4I") { lblNom.Text = "4B"; }
                       
            //        }
            //    }
            //}
            GridView1.DataBind(); GridView2.DataBind();
            Label3.Text = deleteorient(Label48.Text,"2014").ToString();
            Label4.Text = deleteorient(Label49.Text, "2014").ToString();
            Label5.Text = deleteorient(Label50.Text, "2014").ToString();
            Label6.Text = deleteorient(Label51.Text, "2014").ToString();
            Label7.Text = deleteorient(Label52.Text, "2014").ToString();
            Label8.Text = deleteorient(Label53.Text, "2014").ToString();
            Label9.Text = deleteorient(Label54.Text, "2014").ToString();
            Label10.Text = deleteorient(Label55.Text, "2014").ToString();
            Label11.Text = deleteorient(Label56.Text, "2014").ToString();
            Label12.Text = deleteorient(Label57.Text, "2014").ToString();
            Label13.Text = deleteorient(Label58.Text, "2014").ToString();
            Label14.Text = deleteorient(Label59.Text, "2014").ToString();
            Label15.Text = deleteorient(Label60.Text, "2014").ToString();
            Label16.Text = deleteorient(Label61.Text, "2014").ToString();
            Label17.Text = deleteorient(Label62.Text, "2014").ToString();
            Label18.Text = deleteorientch2(Label48.Text, "2014").ToString();
            Label19.Text = deleteorientch2(Label49.Text, "2014").ToString();
            Label20.Text = deleteorientch2(Label50.Text, "2014").ToString();
            Label21.Text = deleteorientch2(Label51.Text, "2014").ToString();
            Label22.Text = deleteorientch2(Label52.Text, "2014").ToString();
            Label23.Text = deleteorientch2(Label53.Text, "2014").ToString();
            Label24.Text = deleteorientch2(Label54.Text, "2014").ToString();
            Label25.Text = deleteorientch2(Label55.Text, "2014").ToString();
            Label26.Text = deleteorientch2(Label56.Text, "2014").ToString();
            Label27.Text = deleteorientch2(Label57.Text, "2014").ToString();
            Label28.Text = deleteorientch2(Label58.Text, "2014").ToString();
            Label29.Text = deleteorientch2(Label59.Text, "2014").ToString();
            Label30.Text = deleteorientch2(Label60.Text, "2014").ToString();
            Label31.Text = deleteorientch2(Label61.Text, "2014").ToString();
            Label32.Text = deleteorientch2(Label62.Text, "2014").ToString();
            Label33.Text = deleteorientch3(Label48.Text, "2014").ToString();
            Label34.Text = deleteorientch3(Label49.Text, "2014").ToString();
            Label35.Text = deleteorientch3(Label50.Text, "2014").ToString();
            Label36.Text = deleteorientch3(Label51.Text, "2014").ToString();
            Label37.Text = deleteorientch3(Label52.Text, "2014").ToString();
            Label38.Text = deleteorientch3(Label53.Text, "2014").ToString();
            Label39.Text = deleteorientch3(Label54.Text, "2014").ToString();
            Label40.Text = deleteorientch3(Label55.Text, "2014").ToString();
            Label41.Text = deleteorientch3(Label56.Text, "2014").ToString();
            Label42.Text = deleteorientch3(Label57.Text, "2014").ToString();
            Label43.Text = deleteorientch3(Label58.Text, "2014").ToString();
            Label44.Text = deleteorientch3(Label59.Text, "2014").ToString();
            Label45.Text = deleteorientch3(Label60.Text, "2014").ToString();
            Label46.Text = deleteorientch3(Label61.Text, "2014").ToString();
            Label47.Text = deleteorientch3(Label62.Text, "2014").ToString();
           






        }
         
         public   int  deleteorient(string ch, string anneedeb)
       {
           using (Entities ctx = new Entities())
           {
               var req = from p in ctx.ESP_ORIENTATION
                         where p.CH1 == ch && p.ANNEE_DEB == anneedeb && p.CODE_CL.Substring(0,1)=="3"

                          select p;


               return req.Count();
           }


        

           }
         public int deleteorientch2(string ch, string anneedeb)
         {
             using (Entities ctx = new Entities())
             {
                 var req = from p in ctx.ESP_ORIENTATION
                           where p.CH2 == ch && p.ANNEE_DEB == anneedeb && p.CODE_CL.Substring(0,1)=="3"

                           select p;


                 return req.Count();
             }
         }
         public int deleteorientch3(string ch, string anneedeb)
         {
             using (Entities ctx = new Entities())
             {
                 var req = from p in ctx.ESP_ORIENTATION
                           where p.CH3 == ch && p.ANNEE_DEB == anneedeb && p.CODE_CL.Substring(0, 1) == "3"

                           select p;


                 return req.Count();
             }
         }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataBind(); GridView2.DataBind();
            Label3.Text = deleteorient(Label48.Text, "2014").ToString();
            Label4.Text = deleteorient(Label49.Text, "2014").ToString();
            Label5.Text = deleteorient(Label50.Text, "2014").ToString();
            Label6.Text = deleteorient(Label51.Text, "2014").ToString();
            Label7.Text = deleteorient(Label52.Text, "2014").ToString();
            Label8.Text = deleteorient(Label53.Text, "2014").ToString();
            Label9.Text = deleteorient(Label54.Text, "2014").ToString();
            Label10.Text = deleteorient(Label55.Text, "2014").ToString();
            Label11.Text = deleteorient(Label56.Text, "2014").ToString();
            Label12.Text = deleteorient(Label57.Text, "2014").ToString();
            Label13.Text = deleteorient(Label58.Text, "2014").ToString();
            Label14.Text = deleteorient(Label59.Text, "2014").ToString();
            Label15.Text = deleteorient(Label60.Text, "2014").ToString();
            Label16.Text = deleteorient(Label61.Text, "2014").ToString();
            Label17.Text = deleteorient(Label62.Text, "2014").ToString();
            Label18.Text = deleteorientch2(Label48.Text, "2014").ToString();
            Label19.Text = deleteorientch2(Label49.Text, "2014").ToString();
            Label20.Text = deleteorientch2(Label50.Text, "2014").ToString();
            Label21.Text = deleteorientch2(Label51.Text, "2014").ToString();
            Label22.Text = deleteorientch2(Label52.Text, "2014").ToString();
            Label23.Text = deleteorientch2(Label53.Text, "2014").ToString();
            Label24.Text = deleteorientch2(Label54.Text, "2014").ToString();
            Label25.Text = deleteorientch2(Label55.Text, "2014").ToString();
            Label26.Text = deleteorientch2(Label56.Text, "2014").ToString();
            Label27.Text = deleteorientch2(Label57.Text, "2014").ToString();
            Label28.Text = deleteorientch2(Label58.Text, "2014").ToString();
            Label29.Text = deleteorientch2(Label59.Text, "2014").ToString();
            Label30.Text = deleteorientch2(Label60.Text, "2014").ToString();
            Label31.Text = deleteorientch2(Label61.Text, "2014").ToString();
            Label32.Text = deleteorientch2(Label62.Text, "2014").ToString();
            Label33.Text = deleteorientch3(Label48.Text, "2014").ToString();
            Label34.Text = deleteorientch3(Label49.Text, "2014").ToString();
            Label35.Text = deleteorientch3(Label50.Text, "2014").ToString();
            Label36.Text = deleteorientch3(Label51.Text, "2014").ToString();
            Label37.Text = deleteorientch3(Label52.Text, "2014").ToString();
            Label38.Text = deleteorientch3(Label53.Text, "2014").ToString();
            Label39.Text = deleteorientch3(Label54.Text, "2014").ToString();
            Label40.Text = deleteorientch3(Label55.Text, "2014").ToString();
            Label41.Text = deleteorientch3(Label56.Text, "2014").ToString();
            Label42.Text = deleteorientch3(Label57.Text, "2014").ToString();
            Label43.Text = deleteorientch3(Label58.Text, "2014").ToString();
            Label44.Text = deleteorientch3(Label59.Text, "2014").ToString();
            Label45.Text = deleteorientch3(Label60.Text, "2014").ToString();
            Label46.Text = deleteorientch3(Label61.Text, "2014").ToString();
            Label47.Text = deleteorientch3(Label62.Text, "2014").ToString();
            
            
        }
     
    }
}
          
            
            
 