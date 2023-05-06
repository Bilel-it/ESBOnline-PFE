using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AffichageClasse;

namespace ESPOnline.EmploiEsp
{
    public partial class Login : System.Web.UI.Page
    {
        //ServiceEDT service = new ServiceEDT();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            //LinkBtnAffectation.Enabled = false;
            //LinkBtnDispo.Enabled = false;
            //LinkBtnCalendar.Enabled = false;
            //LinkBtnConsulter.Enabled = false;
            //LinkBtncontact.Enabled = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text == "administration" && TextBox2.Text == "esprit2014")
                {
                    Session["ID_ENS"] = TextBox1.Text.Trim();
                    Session["NOM_ENS"] = TextBox1.Text.Trim();

                    Response.Redirect("~/Administration/Absence.aspx");

                }
                string log = Log.Instance.login(TextBox1.Text.Trim(), TextBox2.Text.Trim());
                if (log == "N")
                {
                    //Label1.Text = "Vous n'êtes pas un CUP";
                    Session["UP"] = Log.Instance.logiCUP(TextBox1.Text.Trim());
                    Session["ID_ENS"] = TextBox1.Text.Trim();
                    Session["NOM_ENS"] = Log.Instance.loginomCUP(TextBox1.Text.Trim());
                    Session["CUP"] = "N";
                    Response.Redirect("~/Enseignants/Accueil.aspx");

                }

                if (log == "x")
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('vérifier vos paramètres')</script>");
                    Response.Redirect("https://esprit-tn.com/ESPONLINE/Online/default.aspx#tabs-1");

                }
                if (log == "O")
                {
                    Session["ID_ENS"] = TextBox1.Text.Trim();
                    Session["UP"] = Log.Instance.logiCUP(TextBox1.Text.Trim());
                    Session["NOM_ENS"] = Log.Instance.loginomCUP(TextBox1.Text.Trim());
                    Session["CUP"] = "UP";
                    Response.Redirect("~/EnseignantsCUP/Accueil.aspx");
                }

            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
                TextBox1.Text = "";
                //Label1.Text = "Problème de connexion."; 
            }
        }

        protected void ButtonEtudiant_Click(object sender, EventArgs e)
        {
            try
            {
                if (ESP_ETUDIANT.Instance.loginET(TextBox3.Text.Trim(), TextBox3.Text.Trim(), TextBox7.Text.Trim()) != null)
                {
                    ESP_ETUDIANT et = ESP_ETUDIANT.Instance.loginET(TextBox3.Text, TextBox3.Text, TextBox7.Text);
                    Session["ID_ET"] = et.ID_ET;
                    Session["NOM_ET"] = et.NOM_ET;
                    Session["PNOM_ET"] = et.PRENOM_ET;
                    Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
                    Session["PWD_ET"] = et.PWD_ET;
                    if (et.ADRESSE_MAIL_ESP == null || et.ADRESSE_MAIL_ESP == "")
                    { Session["ADRESSE_MAIL_ESP"] = "vide"; }
                    else
                    {
                        Session["ADRESSE_MAIL_ESP"] = et.ADRESSE_MAIL_ESP;
                    }
                    Response.Redirect("~/AEmploi/PlanEtudeByClasse.aspx");
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier votre identifiant')</script>");
                    TextBox3.Text = "";


                }
            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
            }
        }

        protected void ButtonParent_Click(object sender, EventArgs e)
        {
            try
            {
                if (ESP_PARENTS.Instance.loginETP(TextBox4.Text, TextBox4.Text) != null)
                {
                    ESP_PARENTS et = ESP_PARENTS.Instance.loginETP(TextBox4.Text, TextBox4.Text);
                    Session["ID_ET"] = et.ID_ET;
                    Session["NOM_ET"] = et.NOM_ET;
                    Session["PNOM_ET"] = et.PRENOM_ET;
                    Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
                    Session["PWD_ET_INIT"] = et.PWD_ET_INIT;
                    Response.Redirect("~/Parents/accueilp.aspx");
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier votre identifiant')</script>");
                }
            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
            }
        }

        protected void ButtonAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Log.Instance.loginD(TextBox5.Text.Trim(), TextBox6.Text.Trim()) != null)
                {
                    Log decid = Log.Instance.loginD(TextBox5.Text, TextBox6.Text);
                    Session["ID_DECID"] = decid.ID_DECID;
                    Session["NOM_DECID"] = decid.NOM_DECID;
                    Session["PWD_DECID"] = decid.PWD_DECID;

                    Response.Redirect("~/Direction/WebForm1.aspx");
                    //Response.Redirect("https://esprit-tn.com/ESPRITSI/WebForm6.aspx");
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier votre identifiant')</script>");
                    Response.Redirect("https://esprit-tn.com/ESPONLINE/Online/default.aspx#tabs-6");
                }
            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
            }
        }
    }
}