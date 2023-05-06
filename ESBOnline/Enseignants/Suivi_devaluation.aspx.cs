using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Types;
using ABSEsprit;

namespace ESPOnline.Enseignants
{
    public partial class Sivi_devaluation : System.Web.UI.Page

    {

        string id;


        OracleDate dateseance;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }


            Label1.Visible = false;

            //BtnCreer.Visible = true; Button5.Visible = false;
            id = Session["ID_ENS"].ToString().Trim();
            if (!Page.IsPostBack)
            {
                  ObjectDataSource1.DataBind(); DDClasse.DataBind(); ObjectDataSource2.DataBind(); DdlModule.DataBind();
                SqlDataSource1.DataBind(); SqlDataSource2.DataBind();
                GridView1.DataBind();
                GridView2.DataBind();

                foreach (GridViewRow gvr2 in GridView2.Rows)
                {
                    foreach (GridViewRow gvr1 in GridView1.Rows)
                    {
                        Label txtds1 = (Label)gvr1.FindControl("txtobservation");

                        if (gvr1.Cells[1].Text.Trim() == gvr2.Cells[0].Text.Trim())
                        { txtds1.Text = "oui"; txtds1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#009900"); }

                    }

                }
            }

            SqlDataSource1.DataBind(); SqlDataSource2.DataBind();
            GridView1.DataBind();
            GridView2.DataBind();

            foreach (GridViewRow gvr2 in GridView2.Rows)
            {
                foreach (GridViewRow gvr1 in GridView1.Rows)
                {
                    Label txtds1 = (Label)gvr1.FindControl("txtobservation");

                    if (gvr1.Cells[1].Text.Trim() == gvr2.Cells[0].Text.Trim())
                    { txtds1.Text = "oui"; txtds1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#009900"); }

                }

            }
            
          
            

        }








        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            ServicesABS.Instance.closeConnection();
            ServicesABS.Instance.openconntrans();
     //foreach (GridViewRow gvr in GridView2.Rows)
            //{
            //    CheckBox Chekabs1 = (CheckBox)gvr.FindControl("ui_absent1");
            //    TextBox txtobs1 = (TextBox)gvr.FindControl("txtobservation2");
            //    if (Chekabs1.Checked == true)
            //    {
            //        ServicesABS.Instance.Save_esp_ABS(gvr.Cells[1].Text, DdlModule.SelectedValue, DDClasse.SelectedValue, "2014", numSeance, dateseance, id, id, Convert.ToDecimal(RadioButtonList3.SelectedValue), null, null, null, null, txtobs1.Text);


            //    }


            //}
            ServicesABS.Instance.commicttrans();

            ServicesABS.Instance.closeConnection();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Modification  avec Succées')</script>");
            // Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            SqlDataSource1.DataBind(); SqlDataSource2.DataBind();
            GridView1.DataBind();
            GridView2.DataBind();

            foreach (GridViewRow gvr2 in GridView2.Rows)
            {
                foreach (GridViewRow gvr1 in GridView1.Rows)
                {
                    Label txtds1 = (Label)gvr1.FindControl("txtobservation");

                    if (gvr1.Cells[1].Text.Trim() == gvr2.Cells[0].Text.Trim())
                    { txtds1.Text = "oui"; txtds1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#009900"); }

                }

            }
        }





        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {



        }


       



        

        protected void Button4_Click(object sender, EventArgs e)
        {


        }

        protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlModule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

      

      

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            //int n = 0;
            //while (n < GridView1.Rows.Count - 1)
            //{

                foreach (GridViewRow gvr2 in GridView2.Rows)
                {
                    foreach (GridViewRow gvr1 in GridView1.Rows)
                    {
                        Label txtds1 = (Label)gvr1.FindControl("txtobservation");
                        if (gvr1.Cells[1].Text.Trim() == gvr2.Cells[0].Text.Trim())
                        { txtds1.Text = "Oui"; txtds1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#009900"); }
                        
                    }

                }
            //    n++;
            //} 
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectDataSource1.DataBind(); DDClasse.DataBind(); ObjectDataSource2.DataBind(); DdlModule.DataBind();
            SqlDataSource1.DataBind(); SqlDataSource2.DataBind();
            GridView1.DataBind();
            GridView2.DataBind();

            foreach (GridViewRow gvr2 in GridView2.Rows)
            {
                foreach (GridViewRow gvr1 in GridView1.Rows)
                {
                    Label txtds1 = (Label)gvr1.FindControl("txtobservation");

                    if (gvr1.Cells[1].Text.Trim() == gvr2.Cells[0].Text.Trim())
                    { txtds1.Text = "oui"; txtds1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#009900"); }

                }

            }
        }

    }
}