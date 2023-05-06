using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Parents
{
    public partial class noterat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            string ID_ET = Session["ID_ET"].ToString().ToString();

            //lbletat.Text = DAL.Admission.Instance.getetatue(ID_ET);

            //Label1.Text = DAL.Admission.Instance.getetat(ID_ET);


            //if (lbletat.Text == ("-1") || Label1.Text == ("-1"))
            //{

            //    Response.Write("<script LANGUAGE='JavaScript'> alert('Problème pédagogique,veuillez contacter votre chef de département')</script>");
            //    GridView1.Visible = false;
            //    // GridView2.Visible = false;
            //    // DetailsView2.Visible = false;
            //}
            //else
            //{
            //    
            if (GridView1.Rows.Count == 0)
            {
                //Problème Administratif, Veuillez contacter le service compétent
                // Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétent')</script>");
                Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");

                GridView1.Visible = false;
            }

            else
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Aucune saisie n a été effectuée')</script>");
                GridView1.Visible = false;

            }


            //    }

        }
    }
}