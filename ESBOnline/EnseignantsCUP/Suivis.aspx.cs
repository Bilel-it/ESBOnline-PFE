using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Suivis : System.Web.UI.Page
    {
        string codecl;
        string id;
        string nomet;
        string idet;
        string idproj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/Signin.aspx");
            }
            codecl = Session["CODE_CL"].ToString();
            nomet = Session["NOM_ET"].ToString();
            idet = Session["ID_ET"].ToString();
            id = Session["ID_ENS"].ToString();
            idproj = Session["ID_PROJ"].ToString();
            Label2.Text = idproj;
            Label4.Text = nomet;
            Label6.Text = idet;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["SUIVI"] = "true";
            codecl = Session["CODE_CL"].ToString();
            nomet = Session["NOM_ET"].ToString();
            idet = Session["ID_ET"].ToString();
            id = Session["ID_ENS"].ToString();
            idproj = Session["ID_PROJ"].ToString();
            Response.Redirect("Encadrements.aspx");
        }
    }
}