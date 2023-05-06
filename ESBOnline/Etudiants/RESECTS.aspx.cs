using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ESPOnline.Etudiants
{
    public partial class RESECTS : System.Web.UI.Page
    {
         string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        decimal total = 0;
        decimal tot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétant')</script>");
            } 
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            if (!IsPostBack)
            {
                
            }
            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
           

             
        }

        protected void GridView1_test(object sender, GridViewRowEventArgs  e)
        {
            //Label lbl = (Label)e.Row.FindControl("NOMBRE_ECTS");
          // decimal qty = Convert.ToDecimal(lbl.Text);
         //   total = total + qty;
            if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOYENNE")) >= 10)
            {
                decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NB_ECTS"));
                total = total + rowTotal;
                Label1.Text = "Total Crédits acquis  :" +" " +total.ToString();
            }
            else if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MOYENNE")) < 10)
            {
                decimal rowTo = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NB_ECTS"));
                tot = tot + rowTo;
                Label2.Text = "Total Crédits a rattrapés  :" + " " + tot.ToString();
            }
        }
    }
}