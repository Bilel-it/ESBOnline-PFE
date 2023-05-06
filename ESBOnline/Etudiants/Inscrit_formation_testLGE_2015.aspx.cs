using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace ESPOnline.Etudiants
{
    public partial class Inscrit_formation_testLGE_2015 : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();
        string id_et;
       DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            if (!IsPostBack)
            {
                id_et = Session["ID_ET"].ToString();
              DataTable  dt2=service.verif5eme();
                dt = service.get_id_etud_formation(id_et);
                pl1.Visible = false;
                panel1.Visible = false;

                if (dt.Rows.Count != 0)
                {

                    //Response.Redirect("~/Etudiants/Accueil.aspx");
                    Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit');</script>");
                    pl1.Visible = false;
                    panel1.Visible = true;
                }
                else
                {
                 string codecl = service.verif5eme2014(id_et);
                        string codecl2 = service.verif5eme2015(id_et);
                          if (codecl.StartsWith("5") || codecl2.StartsWith("5"))
                          {
                            Response.Write(@"<script language='javascript'>alert('Veuillez choisir la formation que vous voulez passer');</script>");
                            pl1.Visible = true;
                            panel1.Visible = false;
                        }
                        else
                        {
                            Response.Write(@"<script language='javascript'>alert('Vous n\'avez pas le droit de passer la formation');</script>");
                            pl1.Visible = false;
                            panel1.Visible = true;

                        }
                    }
                
            }
        }
        protected void Imgvalid_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ddlchoix.SelectedValue != null)
                {
                    if (ddlchoix.SelectedValue == "1" || ddlchoix.SelectedValue == "2")
                    {
                        id_et = Session["ID_ET"].ToString();
                        service.Enreg_etud_FORMAt_test(id_et, ddlchoix.SelectedValue);
                        Response.Write(@"<script language='javascript'>alert('Vous êtes enregistré avec succès');</script>");

                        pl1.Visible = false;
                        panel1.Visible = true;
                    }
                    else
                    {
                        if (ddlchoix.SelectedValue == "3" || ddlchoix.SelectedValue == "4" || ddlchoix.SelectedValue == "5" || ddlchoix.SelectedValue == "6")
                        {
                            id_et = Session["ID_ET"].ToString();
                            service.Enreg_etud_test(id_et, ddlchoix.SelectedValue);
                            Response.Write(@"<script language='javascript'>alert('Vous êtes enregistré avec succès');</script>");

                            pl1.Visible = false;
                            panel1.Visible = true;
                        }
                    }
                }

            }

            catch
            {
                Response.Write(@"<script language='javascript'>alert('Erreur de serveur');</script>");

            }
            
        }
    }
}