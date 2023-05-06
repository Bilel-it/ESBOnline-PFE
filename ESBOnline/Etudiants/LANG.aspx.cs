using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Etudiants
{
    public partial class LANG : System.Web.UI.Page
    {
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            if (GridView1.Rows.Count == 0)
            {

                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétent')</script>");
                GridView2.Visible = false;
            }
            else { GridView2.Visible = true; }
            if (!IsPostBack)
            {

            }
            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
            if (Class1.Instance.verify(NUM_CIN_PASSEPORT) == false)
                Response.Redirect("Resultas.aspx");
        }
        protected void GridView1_test(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell cell in e.Row.Cells)
            {

                cell.Attributes.CssStyle["text-align"] = "center";
            }
        }
    }
}