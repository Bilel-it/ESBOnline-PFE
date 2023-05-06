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
    public partial class Inscr_fr_ang_2015 : System.Web.UI.Page
    {
        string id_et;
        string typechoix;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        ToiecService service = new ToiecService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            lblanneedeb.Text = "2014";
            lblanneefin.Text = "2015";
            id_et = Session["ID_ET"].ToString();
            dt2 = service.get_5_classe(id_et);
         
            if(!IsPostBack)
            {

               

                string codecl = service.returnCLSUPP(id_et);
                dt = service.get_id_etud_formation(id_et);
              
                panelddr.Visible = false;
                panel1.Visible = false;
                if (dt2.Rows.Count == 0)
                {

                    Response.Write(@"<script language='javascript'>alert('Formation pour 5 ème année  2014/2015');</script>");
                    panelddr.Visible = false;
                    panel1.Visible = true;
                }
                 
                 
                if (dt.Rows.Count != 0  )
                {

                    //Response.Redirect("~/Etudiants/Accueil.aspx");
                    Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit');</script>");
                    panelddr.Visible = false;
                    panel1.Visible = true;
                }

                else
                {
                    //5ERP-BI%,5ARTIC%,5INFINI,5SLEAM,5SIM%,5GL%,5INFOB%,5IRTB,5IRT
                    if ((codecl.StartsWith("5ERP-BI") || codecl.StartsWith("5INFINI") || codecl.StartsWith("5ARTIC") || codecl.StartsWith("5SIM") || codecl.StartsWith("5GL") || codecl.StartsWith("5INFOB") || codecl.StartsWith("5IRTB") || codecl.StartsWith("5IRT") || codecl.StartsWith("5SLEAM") || codecl.StartsWith("5ISEM") || codecl.StartsWith("5TIC/14-15") || codecl.StartsWith("5")) && (dt2.Rows.Count != 0))
                    {

                        Response.Write(@"<script language='javascript'>alert('Veuillez choisir la formation que vous voulez passer');</script>");
                        panelddr.Visible = true;
                        panel1.Visible = false;

                    }

                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Vous n\'avez pas le droit de passer la formation');</script>");
                        // Response.Write("<meta http-equiv='pas de droit' content='0';URL='~/Etudiants/Accueil.aspx'>");
                        //Response.Redirect("~/Etudiants/Accueil.aspx");
                        panelddr.Visible = false;
                        panel1.Visible = true;
                        //Session.Abandon();
                        //Response.Write("<meta http-equiv='pas de droit' content='0';URL='~/Etudiants/Accueil.aspx'>");
                        //Response.End();

                    }
            }
           
                

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try 
            {

                id_et = Session["ID_ET"].ToString();
                service.Enreg_etud_FORMATION(id_et, ddlchoix.SelectedValue);
                Response.Write(@"<script language='javascript'>alert('Vous êtes enregistré avec succès');</script>");

                 //typechoix = service.selectEtatTTOIEC(id_et);

                 //if (typechoix == "1")
                 //{ }
                panelddr.Visible = false;
                panel1.Visible = true;
            
            }

            catch
            {
                Response.Write(@"<script language='javascript'>alert('Erreur de serveur');</script>");
            
            }
            
            
        }
    }
}