using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Online
{
    public partial class Signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
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
                    //Label1.Text = "vérifier vos paramètres";

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
            catch {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
                //Label1.Text = "Problème de connexion."; 
            }
        }
    }
}