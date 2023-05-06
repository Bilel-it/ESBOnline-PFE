using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AffichageClasse;


namespace ESPOnline.EmploiEsp
{
    public partial class LoginPage : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click1(object sender, ImageClickEventArgs e)
        {
            SiteEDT masterPage = (SiteEDT)Page.Master;
         
           
              try
            {

                // auth des enseignants
            //    if (TextBox1.Text == "administration" && TextBox2.Text == "esprit2014")
            //    {
            //        Session["ID_ENS"] = TextBox1.Text.Trim();
            //        Session["NOM_ENS"] = TextBox1.Text.Trim();

            //        Response.Redirect("~/EmploiEsp/Test.aspx");

            //    }



                string log = Log.Instance.login(TextBox1.Text.Trim(), TextBox2.Text.Trim());
                if (log == "N")
                {
                    //Label1.Text = "Vous n'êtes pas un CUP";
                    Session["UP"] = Log.Instance.logiCUP(TextBox1.Text.Trim());
                    Session["ID_ENS"] = TextBox1.Text.Trim();
                    Session["NOM_ENS"] = Log.Instance.loginomCUP(TextBox1.Text.Trim());
                    Session["CUP"] = "N";
                    Response.Redirect("~/EmploiEsp/EnsDispo.aspx");

                }

                if (log == "x")
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('vérifier vos paramètres')</script>");
                    // Response.Redirect("http://esprit-tn.com/ESPONLINE/Online/default.aspx#tabs-1");

                }
                if (log == "O")
                {
                    Session["ID_ENS"] = TextBox1.Text.Trim();
                    Session["UP"] = Log.Instance.logiCUP(TextBox1.Text.Trim());
                    Session["NOM_ENS"] = Log.Instance.loginomCUP(TextBox1.Text.Trim());
                    Session["CUP"] = "UP";
                    Response.Redirect("~/EmploiEsp/EnsDispo.aspx");


                }

                  //Authentification admin

                if (Log.Instance.loginD(TextBox1.Text.Trim(), TextBox2.Text.Trim()) != null)
                {
                    Log decid = Log.Instance.loginD(TextBox1.Text, TextBox2.Text);
                    Session["ID_DECID"] = decid.ID_DECID;
                    Session["NOM_DECID"] = decid.NOM_DECID;
                    Session["PWD_DECID"] = decid.PWD_DECID;

                    Response.Redirect("~/EmploiEsp/accueil.aspx");
 
                }
                //if (ESP_ETUDIANT.Instance.loginET(TextBox1.Text.Trim(), TextBox1.Text.Trim(), TextBox2.Text.Trim()) != null)
                //{
                //    ESP_ETUDIANT et = ESP_ETUDIANT.Instance.loginET(TextBox1.Text, TextBox1.Text, TextBox2.Text);
                //    Session["ID_ET"] = et.ID_ET;
                //    Session["NOM_ET"] = et.NOM_ET;
                //    Session["PNOM_ET"] = et.PRENOM_ET;
                //    Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
                //    Session["PWD_ET"] = et.PWD_ET;
                //    if (et.ADRESSE_MAIL_ESP == null || et.ADRESSE_MAIL_ESP == "")
                //    { Session["ADRESSE_MAIL_ESP"] = "vide"; }
                //    else
                //    {
                //        Session["ADRESSE_MAIL_ESP"] = et.ADRESSE_MAIL_ESP;
                //    }
                //    Response.Redirect("~/EmploiEsp/GestionCours.aspx");
                //}

                
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier votre identifiant')</script>");
                    
                    Response.Redirect("~/EmploiEsp/LoginPage.aspx");
                   
                }
            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
            }
        }
        }
    }
