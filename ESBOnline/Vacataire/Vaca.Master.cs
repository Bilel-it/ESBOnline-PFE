using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;
namespace ESPOnline.Enseignants
{
    public partial class Vaca : System.Web.UI.MasterPage
    {
        ToiecService service = new ToiecService();
        string id_ens;
        DataTable dt;
        StatService upLANG = new StatService();

        string up;
  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PWD_ENS"].ToString() == Log.Instance.loginPWDnomenclature())
            { Response.Redirect("~/Enseignants/reset_pwd_ens.aspx"); }
           
            EncadrementDAO dt = EncadrementDAO.Instance;
            Label2.Text = "Bienvenue ";
            Label1.Text = Session["NOM_ENS"].ToString().Trim();
            //if (dt.ens_lang(Session["ID_ENS"].ToString()))
            //    //if ((Session["ID_ENS"].ToString()) == "P-450-11")
            //{
            //    test.Visible = true;
            //}
            //else test.Visible = false;
            id_ens = Session["ID_ENS"].ToString();
            up = upLANG.GetUP(id_ens);

            //if (up == "UP_LANGUE" || Session["ID_ENS"].ToString().Equals("V-88-07"))
            //{

            //    if (id_ens == "V-96-07")
            //    {
            //        idup.Visible = true;
            //        idup2.Visible = true;
            //        A3.Visible = true;
            //        A4.Visible = true;
            //        A1.Visible = true;
            //        L1.Visible = true;
            //        POP2.Visible = true;
            //        POP3.Visible = true;

            //    }
            //}
             
            //else
            //{
            //    idup.Visible = false;
            //    idup2.Visible = false;
            //    A3.Visible = false;
            //    A4.Visible = false;
            //    A1.Visible = false;
            //    POP2.Visible = false;
            //    POP3.Visible = false;
             
            //}
        }
        protected void clickbtn_Click(object sender, EventArgs e)
        {
            id_ens = Session["ID_ENS"].ToString();
            dt = service.Aff_list_inscrit_ens(id_ens);
            if (dt.Rows.Count != 0)
            {
                Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit');</script>");
            }
            else
            {
                Response.Redirect("~/Enseignants/Toeic_enseig.aspx");
            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Online/Accueil.aspx");
        }
    }
}