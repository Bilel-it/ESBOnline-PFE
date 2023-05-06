using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Cup : System.Web.UI.MasterPage
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
            Label2.Text = "Bienvenue "+Session["NOM_ENS"].ToString().Trim();
            if (dt.ens_lang(Session["ID_ENS"].ToString()) || Session["ID_ENS"].ToString().Equals("V-886-13"))
            {
              //  test.Visible = true;
                //suivi2.Visible = true;
                //suivi3.Visible = true;
            }
            else {
                // test.Visible = false; 
                //suivi2.Visible = false; 
                //suivi3.Visible = false; 
            }
            if ((dt.CHEFDEPT(Session["ID_ENS"].ToString())) == "N" )
            {
                test2.Visible = true;
                test3.Visible=false;
                
            }
            else { test2.Visible = false; }
            id_ens = Session["ID_ENS"].ToString();
            up = upLANG.GetUP(id_ens);

            //if (up == "UP_LANGUE" )
            //{
            //    idup.Visible = true;
            //    idup2.Visible = true;
            //    A3.Visible = true;
            //    A4.Visible = true;
            //    A5.Visible = true;
            //    A6.Visible = true;
               
            
            //}
             
            //else
            //{
            //    //idup.Visible = false;
            //    idup2.Visible = false;
            //    A3.Visible = false;
            //    A4.Visible = false;
            //    A5.Visible = false;
            //    A6.Visible = true;
               
                
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
                Response.Redirect("~/EnseignantsCUP/Toeic_ens_cup.aspx");

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