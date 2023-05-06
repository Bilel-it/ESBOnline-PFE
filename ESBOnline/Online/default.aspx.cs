using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using AffichageClasse;
using Evaluation;

using System.Data;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using DAL;
using System.Threading.Tasks;
using System.Threading;

namespace ESPOnline.Online
{
    public partial class _default : System.Web.UI.Page
    {
        string vn_numsem;
        string vs_ctrl_fin_stat;
        string annee_deb;
        string max_val_credit_accepte;
        string source_num;
        string solde;
        bool res = true;
        DateTime date_rgt;
        string mode_rgt;
        string mode_rglt;
        decimal solde_new; decimal max_val;
        bool a = true;
        string numcompte;
        decimal somme_solde;

        string code_cl;

        string lockd;
        string lockdB;

        string c_locked_esp;
        string c_locked_esb;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Etudiants/Recupérer_mot_de_passe.aspx");
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            EncadrementDAO dt = EncadrementDAO.Instance;
            try
            {
                //if (TextBox1.Text == "administration" && TextBox2.Text == "esprit2014")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();
                  
                //    Response.Redirect("~/Administration/Absence.aspx");
                
                //}
                 
                //if (TextBox1.Text == "administration" && TextBox2.Text == "esprit@@2015")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/WebForm1.aspx");

                //}
                string log = Log.Instance.login(injectionSQL.Sanitize(TextBox1.Text.Trim()), injectionSQL.Sanitize(TextBox2.Text.Trim()));
                if (log == "N")
                {
                    //Label1.Text = "Vous n'êtes pas un CUP";
                    Session["UP"] = Log.Instance.logiCUP(TextBox1.Text.Trim());
                    Session["ID_ENS"] = TextBox1.Text.Trim();
                    Session["NOM_ENS"] = Log.Instance.loginomCUP(TextBox1.Text.Trim());
                    Session["CUP"] = "N";

                    if (dt.TYPEENS(Session["ID_ENS"].ToString()) == "P")
                    {
                        Response.Redirect("~/Enseignants/Accueil.aspx");
                    }

                    else
                    {
                        if (dt.TYPEENS(Session["ID_ENS"].ToString()) == "V")
                        {
                            Response.Redirect("~/Vacataire/AccueilVaca.aspx");
                        }

                    }

                  //  Response.Redirect("~/Enseignants/Accueil.aspx");

                }

                if (log == "x")
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('vérifier vos paramètres')</script>");
                    Response.Redirect("https://esprit-tn.com/ESBONLINE/Online/default.aspx#tabs-1");

                }
                if (log == "O")
                {
                    Session["ID_ENS"] = TextBox1.Text.Trim();
                    Session["UP"] = Log.Instance.logiCUP(TextBox1.Text.Trim());
                    Session["NOM_ENS"] = Log.Instance.loginomCUP(TextBox1.Text.Trim());
                    Session["CODE_DEPT"] = Log.Instance.logindeptCUP(TextBox1.Text.Trim());
                    Session["CUP"] = "UP";
                   
                    if (dt.TYPEENS(Session["ID_ENS"].ToString()) == "P")
                    {
                        Response.Redirect("~/Enseignants/Accueil.aspx");
                    }

                    else
                    {
                        if (dt.TYPEENS(Session["ID_ENS"].ToString()) == "V")
                        {
                            Response.Redirect("~/Vacataire/AccueilVaca.aspx");
                        }

                    }


                    // Response.Redirect("~/EnseignantsCUP/Accueil.aspx");


                }

            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
               // TextBox1.Text = "";
                //Label1.Text = "Problème de connexion."; 
                Panel1.DefaultButton = "Button2";
            }
        }


        protected void ButtonEtudiant_Click(object sender, EventArgs e)
        {
            try
            {
                if (ESP_ETUDIANT.Instance.loginET(TextBox3.Text.Trim(), TextBox3.Text.Trim(), TextBox7.Text.Trim()) != null)
                {
                    ESP_ETUDIANT et = ESP_ETUDIANT.Instance.loginET(injectionSQL.Sanitize(TextBox3.Text.Trim()), injectionSQL.Sanitize(TextBox3.Text.Trim()), injectionSQL.Sanitize(TextBox7.Text.Trim()));
                    Session["ID_ET"] = et.ID_ET;
                    Session["NOM_ET"] = et.NOM_ET;
                    Session["PNOM_ET"] = et.PRENOM_ET;
                    Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
                    Session["PWD_ET"] = et.PWD_ET;
                    Session["motdepasse"] = et.motdepasse;
                    Session["CODE_CL"] = et.CODE_CL;

                    if (et.motdepasse == null || et.motdepasse == "esb2022" || et.motdepasse == "esß2022")
                    {
                        Response.Redirect("~/Etudiants/reset_pwd.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Etudiants/Accueil.aspx");
                    }
                  //  Response.Redirect("~/Etudiants/Accueil.aspx");
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier vos paramètres')</script>");
                    Panel2.DefaultButton = "ButtonEtudiant";
                }
            }
            catch(Exception ex)
            {
                string bug = ex.ToString();
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
            }
        }
        protected void ButtonParent_Click4(object sender, EventArgs e)
        {

            //ici espace parent

            string cin = TextBox4.Text.Trim();


            string numc = ESP_ETUDIANT.Instance.GetnumcompteByid(TextBox4.Text.Trim());
            string annee = ESP_ETUDIANT.Instance.andb();
            //"4110001102";
            string aav = "('ESB')/Navision_To_Sco('" + numc + "')";
            var urlhistorique = "http://192.168.0.147:7028/Esprit_NAV_PROD/ODatav4/Company" + aav;

            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(urlhistorique);
            webrequest.Method = "GET";
            webrequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes("USER4:Esp@123**2021"));
            webrequest.Credentials = new NetworkCredential("USER4", "Esp@123**2021");
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                var cc = Convert.ToString(result);
                Getsoldeet list_hist1 = JsonConvert.DeserializeObject<Getsoldeet>(cc);

                list_hist1.id_et = list_hist1.id_et;
                list_hist1.no = list_hist1.no;
                list_hist1.locked = Convert.ToBoolean(list_hist1.locked);

                //string ss = Session["list_hist1.locked"].ToString();

                res = Convert.ToBoolean(list_hist1.locked);

                if (res == false)

                {
                    try
                    {

                        ESP_PARENTS et = ESP_PARENTS.Instance.loginETP(injectionSQL.Sanitize(TextBox4.Text.Trim()), injectionSQL.Sanitize(pass_parent.Text.Trim()));
                        Session["ID_ET"] = et.ID_ET;
                        Session["NOM_ET"] = et.NOM_ET;
                        Session["PNOM_ET"] = et.PRENOM_ET;
                        Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
                        Session["PWD_ET_INIT"] = et.PWD_ET_INIT;
                        //Session["CODE_CL"] = et.CODE_CL;
                        //Session["NUMCOMPTE"] = et.NUMCOMPTE;
                        Session["nbredeconsultationparsession"] = 0;
                        Response.Redirect("~/Parents/accueilp.aspx");

                    }
                    catch
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier vos paramètres.')</script>");
                    }
                }

                else
                {
                    if (res == true)

                    {


                        Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");

                        DataTable dTable2 = DAL.EncadDAO.Instance.Get_data_Etudiantbycin(cin, annee_deb);

                        foreach (DataRow row2 in dTable2.Rows)
                        {
                            if (row2["mode_rglt"] == DBNull.Value)
                            {
                                mode_rgt = "";

                            }

                            else
                            {
                                mode_rgt = row2["mode_rglt"].ToString();
                                //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                            }

                            if (row2["DATE_LIM_PROLONG_RGLT"] == DBNull.Value)
                            {
                                // date_rgt = null;

                            }

                            else
                            {
                                date_rgt = Convert.ToDateTime(row2["DATE_LIM_PROLONG_RGLT"].ToString());

                            }


                            if (row2["numcompte"] == DBNull.Value)
                            {
                                numcompte = "";

                            }

                            else
                            {
                                numcompte = row2["numcompte"].ToString();
                                //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                            }
                            //



                        }

                        if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                        {
                            try
                            {

                                ESP_PARENTS et = ESP_PARENTS.Instance.loginETP(injectionSQL.Sanitize(TextBox4.Text.Trim()), injectionSQL.Sanitize(pass_parent.Text.Trim()));
                                Session["ID_ET"] = et.ID_ET;
                                Session["NOM_ET"] = et.NOM_ET;
                                Session["PNOM_ET"] = et.PRENOM_ET;
                                Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
                                Session["PWD_ET_INIT"] = et.PWD_ET_INIT;
                                //Session["CODE_CL"] = et.CODE_CL;
                                //Session["NUMCOMPTE"] = et.NUMCOMPTE;
                                Session["nbredeconsultationparsession"] = 0;
                                Response.Redirect("~/Parents/accueilp.aspx");

                            }
                            catch
                            {
                                Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier vos paramètres.')</script>");
                            }
                        }

                        else
                        {

                            if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                            {

                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");

                            }

                            else
                            {


                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");
                            }
                        }


                    }

                }


            }








        }



        protected void ButtonParent_Click(object sender, EventArgs e)
        {

            //ici espace parent

            string cin = TextBox4.Text.Trim();

            string id_et= ESP_ETUDIANT.Instance.GetnumcompteByidet(TextBox4.Text.Trim());

            string numc = ESP_ETUDIANT.Instance.GetnumcompteByid(TextBox4.Text.Trim());
            string annee = ESP_ETUDIANT.Instance.andb();

            DataTable dTable2 = DAL.EncadDAO.Instance.Get_data_Etudiant(cin, annee);

            foreach (DataRow row2 in dTable2.Rows)
            {
                if (row2["mode_rglt"] == DBNull.Value)
                {
                    mode_rgt = "";

                }

                else
                {
                    mode_rgt = row2["mode_rglt"].ToString();
                    //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                }

                if (row2["DATE_LIM_PROLONG_RGLT"] == DBNull.Value)
                {
                    // date_rgt = null;

                }

                else
                {
                    date_rgt = Convert.ToDateTime(row2["DATE_LIM_PROLONG_RGLT"].ToString());

                }


                if (row2["numcompte"] == DBNull.Value)
                {
                    numcompte = "";

                }

                else
                {
                    numcompte = row2["numcompte"].ToString();
                    //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                }


                if (row2["code_cl"] == DBNull.Value)
                {
                    code_cl = "";

                }

                else
                {
                    code_cl = row2["code_cl"].ToString();
                    //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                }

            }

            //"4110001102";

            DataTable dTable3 = DAL.EncadDAO.Instance.Get_Value_lockedfromESPRITESBynumcompte(id_et);
            foreach (DataRow dt3 in dTable3.Rows)
            {

                if (dt3["c_locked_esp"] == DBNull.Value)
                {
                    c_locked_esp = "";

                }

                else
                {
                    c_locked_esp = dt3["c_locked_esp"].ToString();
                    //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                }

                if (dt3["c_locked_esb"] == DBNull.Value)
                {
                    c_locked_esb = "";

                }

                else
                {
                    c_locked_esb = dt3["c_locked_esb"].ToString();
                    //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                }

            }






            if (c_locked_esp == null && c_locked_esb == null)
            {
                lockdB = DAL.EncadDAO.Instance.Get_Value_lockedfROMESB(id_et);


                if (lockdB == "1")

                {
                    if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                    {

                        //oui 
                        a = true;

                    }

                    else
                    {
                        if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                        {

                            //non
                            a = false;
                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");

                            TextBox3.Text = "";

                        }


                        else
                        {
                            a = false;
                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");

                            TextBox3.Text = "";
                        }
                    }

                }


                else

                {
                    if (lockdB == "0")

                    {
                        a = true;

                    }

                }

            }

            else
            {
                if (c_locked_esp == "1" && c_locked_esb == "1")
                {

                    if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                    {

                        //oui 
                        a = true;

                    }

                    else
                    {

                        if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                        {

                            //oui 
                            a = false;
                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");
                            TextBox3.Text = "";

                        }


                        else
                        {
                            a = false;
                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");
                            TextBox3.Text = "";
                        }

                    }
                }


                else

                {
                    if (c_locked_esp == "1" && c_locked_esb == "0")
                    {

                        if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                        {

                            //oui 
                            a = true;

                        }

                        else
                        {

                            if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                            {

                                //oui 
                                a = false;
                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais de restauration et/ou foyer')</script>");
                                TextBox3.Text = "";

                            }


                            else
                            {
                                a = false;
                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais de restauration et/ou foyer')</script>");
                                TextBox3.Text = "";
                            }

                        }
                    }




                    else
                    {


                        if (c_locked_esp == "0" && c_locked_esb == "1")
                        {

                            if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                            {

                                //oui 
                                a = true;

                            }

                            else
                            {

                                if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                                {

                                    //oui 
                                    a = false;
                                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");
                                    TextBox3.Text = "";

                                }


                                else
                                {
                                    a = false;
                                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");
                                    TextBox3.Text = "";
                                }

                            }
                        }


                        else
                        {

                            if (c_locked_esp == "0" && c_locked_esb == "0")
                            {

                                a = true;
                            }

                        }
                    }

                }

            }

            if (a == true)

            {
                // commenter le 16-02-2022
                //   Response.Write("<script LANGUAGE='JavaScript'> alert('l intranet est actuallement inaccessible')</script>");


                try
                {

                    ESP_PARENTS et = ESP_PARENTS.Instance.loginETP(injectionSQL.Sanitize(TextBox4.Text.Trim()), injectionSQL.Sanitize(pass_parent.Text.Trim()));
                    Session["ID_ET"] = et.ID_ET;
                    Session["NOM_ET"] = et.NOM_ET;
                    Session["PNOM_ET"] = et.PRENOM_ET;
                    Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
                    Session["PWD_ET_INIT"] = et.PWD_ET_INIT;
                    Session["CODE_CL"] = et.CODE_CL;
                    Session["NUMCOMPTE"] = et.NUMCOMPTE;
                    Session["nbredeconsultationparsession"] = 0;
                    Response.Redirect("~/Parents/accueilp.aspx");

                }
                catch
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier vos paramètres.')</script>");
                }
            }

            else
            {
                if (a == false)

                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");

                    // commenter le 16-02-2022
                   // Response.Write("<script LANGUAGE='JavaScript'> alert('l intranet est actuallement inaccessible')</script>");

                }

            }






            //if (res == false)

            //    {
            //        try
            //        {

            //            ESP_PARENTS et = ESP_PARENTS.Instance.loginETP(injectionSQL.Sanitize(TextBox4.Text.Trim()), injectionSQL.Sanitize(pass_parent.Text.Trim()));
            //            Session["ID_ET"] = et.ID_ET;
            //            Session["NOM_ET"] = et.NOM_ET;
            //            Session["PNOM_ET"] = et.PRENOM_ET;
            //            Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
            //            Session["PWD_ET_INIT"] = et.PWD_ET_INIT;
            //            //Session["CODE_CL"] = et.CODE_CL;
            //            //Session["NUMCOMPTE"] = et.NUMCOMPTE;
            //            Session["nbredeconsultationparsession"] = 0;
            //            Response.Redirect("~/Parents/accueilp.aspx");

            //        }
            //        catch
            //        {
            //            Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier vos paramètres.')</script>");
            //        }
            //    }

            //    else
            //    {
            //        if (res == true)

            //        {






            //}

            //if (mode_rgt == "99" && date_rgt >= DateTime.Now)

            //{
            //    try
            //    {

            //        ESP_PARENTS et = ESP_PARENTS.Instance.loginETP(injectionSQL.Sanitize(TextBox4.Text.Trim()), injectionSQL.Sanitize(pass_parent.Text.Trim()));
            //        Session["ID_ET"] = et.ID_ET;
            //        Session["NOM_ET"] = et.NOM_ET;
            //        Session["PNOM_ET"] = et.PRENOM_ET;
            //        Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
            //        Session["PWD_ET_INIT"] = et.PWD_ET_INIT;
            //        //Session["CODE_CL"] = et.CODE_CL;
            //        //Session["NUMCOMPTE"] = et.NUMCOMPTE;
            //        Session["nbredeconsultationparsession"] = 0;
            //        Response.Redirect("~/Parents/accueilp.aspx");

            //    }
            //    catch
            //    {
            //        Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier vos paramètres.')</script>");
            //    }
            //}

            //else
            //{

            //    if (mode_rgt == "99" && date_rgt <= DateTime.Now)

            //    {

            //     //   Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");

            //    }

            //    else
            //    {


            //       // Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");
            //    }
            //}


            //    }

            //}










        }

        //protected void ButtonParent_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ESP_PARENTS.Instance.loginETP(TextBox4.Text.Trim(), pass_parent.Text.Trim()) != null)
        //        {
        //            ESP_PARENTS et = ESP_PARENTS.Instance.loginETP(injectionSQL.Sanitize(TextBox4.Text.Trim()), injectionSQL.Sanitize(pass_parent.Text.Trim()));
        //            Session["ID_ET"] = et.ID_ET;
        //           // Session["NOM_ET"] = et.NOM_ET;
        //           // Session["PNOM_ET"] = et.PRENOM_ET;
        //           // Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;
        //            //Session["PWD_ET_INIT"] = et.PWD_ET_INIT;
        //           // Session["CODE_CL"] = et.CODE_CL;
        //            Response.Redirect("~/Parents/accueilp.aspx");
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(),
        //                               "alert",
        //                               "alert('Verifier votre identifiant');window.location ='https://esprit-tn.com/ESBOnline/Online/default.aspx#tabs-3';",
        //                               true);


        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        string bug = ex.ToString();
        //        Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
        //    }
        //}
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Etudiants/Recupérer_mot_de_passe.aspx");

        }
        protected void ButtonAdmin_Click(object sender, EventArgs e)
        {
            try
            {

                if (Log.Instance.loginEntretien(injectionSQL.Sanitize(TextBox5.Text.Trim()), injectionSQL.Sanitize(TextBox6.Text.Trim())) != null)
               
                {
                    Log decid = Log.Instance.loginEntretien(TextBox5.Text.Trim(), TextBox6.Text.Trim());
                    Session["ID_DECID"] = decid.ID_DECID;
                    Session["NOM_DECID"] = decid.NOM_DECID;
                    Session["PWD_DECID"] = decid.PWD_DECID;
                    Response.Redirect("~/Direction/Entretiensession22.aspx");
                  

                }

                //if (TextBox5.Text == "esb" && TextBox6.Text == "esprit2017")
                //{
                //    Session["ID_DECID"] = TextBox5.Text.Trim();
                //    //Session["id"] = "dominique";
                //    Session["motdepasse"] = TextBox6.Text.Trim();


                //    Response.Redirect("~/Finance/PHOTOESB.aspx");
                //}
                if (TextBox5.Text == "Arbi" && TextBox6.Text == "admin22")
                {
                    Session["ID_ENS"] = TextBox1.Text.Trim();
                    Session["NOM_ENS"] = TextBox1.Text.Trim();
                    Session["NOM_DECID"] = "admin";
                    Session["ID_DECID"] = "admin";
                    Response.Redirect("~/Administration/suiviabsence.aspx");

                }
                if (TextBox5.Text == "Ibtissem" && TextBox6.Text == "admin_esb_22")
                {
                    Session["ID_ENS"] = TextBox1.Text.Trim();
                    Session["NOM_ENS"] = TextBox1.Text.Trim();
                    Session["NOM_DECID"] = "admin";
                    Session["ID_DECID"] = "admin";
                    Response.Redirect("~/Administration/suiviabsence.aspx");

                }

                if (Log.Instance.loginRole3(injectionSQL.Sanitize(TextBox5.Text.Trim()), injectionSQL.Sanitize(TextBox6.Text.Trim())) != null)
                //  if (TextBox5.Text == "admission" && TextBox6.Text == "esb@@2022*")
                {
                    Log decid = Log.Instance.loginRole3(TextBox5.Text.Trim(), TextBox6.Text.Trim());
                    Session["ID_DECID"] = decid.ID_DECID;
                    Session["NOM_DECID"] = decid.NOM_DECID;
                    Session["PWD_DECID"] = decid.PWD_DECID;
                    Response.Redirect("~/Administration/suiviabsence.aspx");
                    //Response.Redirect("~/Administration/Accueil.aspx");

                }
                else
                if (Log.Instance.loginD(injectionSQL.Sanitize(TextBox5.Text.Trim()), injectionSQL.Sanitize(TextBox6.Text.Trim())) != null)
              //  if (TextBox5.Text == "admission" && TextBox6.Text == "esb@@2022*")
                {
                    Log decid = Log.Instance.loginD(TextBox5.Text.Trim(), TextBox6.Text.Trim());
                    Session["ID_DECID"] = decid.ID_DECID;
                    Session["NOM_DECID"] = decid.NOM_DECID;
                    Session["PWD_DECID"] = decid.PWD_DECID;
                    Response.Redirect("~/Administration/admission/CJ_liste.aspx");
                    //Response.Redirect("~/Administration/Accueil.aspx");

                }
                else
                if (Log.Instance.loginD(injectionSQL.Sanitize(TextBox5.Text.Trim()), injectionSQL.Sanitize(TextBox6.Text.Trim())) != null)
                {
                    Log decid = Log.Instance.loginD(TextBox5.Text.Trim(), TextBox6.Text.Trim());
                    Session["ID_DECID"] = decid.ID_DECID;
                    Session["NOM_DECID"] = decid.NOM_DECID;
                    Session["PWD_DECID"] = decid.PWD_DECID;

                   Response.Redirect("~/Direction/admission/CJ_liste.aspx");
                   // Response.Redirect("~/Administration/Accueil.aspx");

                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier votre identifiant')</script>");
                    //Response.Redirect("https://esprit-tn.com/ESBOnline/Online/default.aspx#tabs-6");
                }

                //if (TextBox5.Text == "admin" && TextBox6.Text == "esb19*")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/Absence.aspx");

                //}



                // if (TextBox5.Text == "houria" && TextBox6.Text == "esb@2018")
                //{
                //     Session["ID_ENS"] = TextBox1.Text.Trim();
                //     Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/Absence.aspx");

                // }

                //if (TextBox5.Text == "mohamed" && TextBox6.Text == "esb*2019")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/Absence.aspx");

                //}

                //if (TextBox5.Text == "ibtissem" && TextBox6.Text == "esb@@18")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/Absence.aspx");

                //}

                //if (TextBox5.Text == "dominiquep" && TextBox6.Text == "esb$2020*")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/Absence.aspx");

                //}

                //if (TextBox5.Text == "esb" && TextBox6.Text == "esb20$19")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/Absence.aspx");

                //}


                //if (TextBox5.Text == "dominique" && TextBox6.Text == "esb@2018")
                //{
                //    Session["ID_DECID"] = TextBox5.Text.Trim();
                //    //Session["id"] = "dominique";
                //    Session["motdepasse"] = TextBox6.Text.Trim();


                //    Response.Redirect("~/Direction/Evaluationenseignements.aspx");
                //}
                //if (TextBox5.Text == "inesm" && TextBox6.Text == "esb2018")
                //{
                //    Session["ID_DECID"] = TextBox5.Text.Trim();
                //    //Session["id"] = "dominique";
                //    Session["motdepasse"] = TextBox6.Text.Trim();


                //    Response.Redirect("~/Direction/Evaluationenseignements.aspx");
                //}
                //if (TextBox5.Text == "wela" && TextBox6.Text == "esb@1718")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/Absence.aspx");

                //}
                //if (TextBox5.Text == "administration" && TextBox6.Text == "espritesb@17")
                //  {
                //      Session["ID_ENS"] = TextBox1.Text.Trim();
                //      Session["NOM_ENS"] = TextBox1.Text.Trim();

                //      Response.Redirect("~/Administration/Absence.aspx");

                //  }
                //if (TextBox5.Text == "administration" && TextBox6.Text == "espritesb@1718")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/Absence.aspx");

                //}
                //if (TextBox5.Text == "arbi" && TextBox6.Text == "//wp5xc0%6")
                //{
                //    Session["ID_ENS"] = TextBox1.Text.Trim();
                //        //"Arbi";
                //    Session["NOM_ENS"] = TextBox1.Text.Trim();

                //    Response.Redirect("~/Administration/Absence.aspx");

                //}

            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session["PWD_ENS"] = Log.Instance.loginPWDCUP(TextBox1.Text.Trim());

            Panel1.DefaultButton = "Button2";

            if (Session["PWD_ENS"].ToString() == Log.Instance.loginPWDnomenclature())
            {

                Session["ID_ENS"] = TextBox1.Text.Trim();
                Session["NOM_ENS"] = Log.Instance.loginomCUP(TextBox1.Text.Trim());

                Response.Redirect("~/Enseignants/Accueil.aspx");
            }
            else
            {
                Label5.Visible = false;
                Button2.Visible = true; RequiredFieldValidator2.Enabled = true; Button1.Visible = false; TextBox1.Visible = false; TextBox2.Visible = true; Label6.Visible = true;
                Panel4.Visible = false; Panel2.Visible = false; Panel3.Visible = false; a3.Visible = false; a1.Visible = false; a2.Visible = false; a4.Visible = false; Panel1.DefaultButton = "Button2";

            } Panel1.DefaultButton = "Button2";
        }
        public class Getsoldeet
        {

            public string no { get; set; }
            public bool locked { get; set; }
            public string id_et { get; set; }




        }
        protected void Button3_Clickanc(object sender, EventArgs e)
        {









            if (ESP_ETUDIANT.Instance.loginet_id(TextBox3.Text.Trim(), TextBox3.Text.Trim()) != null)
            {
                string et = ESP_ETUDIANT.Instance.loginet_id(TextBox3.Text.Trim(), TextBox3.Text.Trim());

                //Session["ID_ET"] = et.ID_ET;
                //Session["NOM_ET"] = et.NOM_ET;
                //Session["PNOM_ET"] = et.PRENOM_ET;
                //Session["CIN_PASS"] = et.NUM_CIN_PASSEPORT;

                //Session["PWD_ET"] = et.motdepasse;
                if (Session["PWD_ET"].ToString() == Log.Instance.loginPWDnomenclature())
                {




                    Response.Redirect("~/Etudiants/reset_pwd.aspx");
                }
                else
                {
                    LinkButton2.Visible = true; TextBox3.Visible = false; TextBox7.Visible = true; ButtonEtudiant.Visible = true; Button3.Visible = false; RequiredFieldValidator7.Enabled = true;
                    Label7.Visible = false; Label8.Visible = true; Panel2.DefaultButton = "ButtonEtudiant";
                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème de connexion.')</script>");
            }
        }


        //ici 15012022
        protected   void Button3_Click(object sender, EventArgs e)
        {
            //if(!TextBox3.Text.StartsWith("22"))
            //{
            //    if (DAL.EncadDAO.Instance.get_type_insc(TextBox3.Text) == "P")
            //    {
            //       // Response.Write("<script LANGUAGE='JavaScript'> alert('test')</script>");
            //        Response.Write("<script>alert('Veuillez régler votre situation financière ! ');window.location = 'accueil.aspx';</script>"); //works great

            //       // Thread.Sleep(6000);

            //      //  Response.Redirect("~/Online/accueil.aspx");

            //    };
            //}
            //ici le test de NAVISION

            //string liaison_fin = DAL.EncadDAO.Instance.get_liaison_fin();

            //if (liaison_fin == "N")
            //{
            //    //ici ij new student


            //    string et = ESP_ETUDIANT.Instance.loginet_id(TextBox3.Text.Trim(), TextBox3.Text.Trim());
            //    if (et != null)
            //    {


            //        Session["ID_ET"] = TextBox3.Text.Trim();
            //        //Session["NOM_ET"] = et.NOM_ET;
            //        //Session["PNOM_ET"] = et.PRENOM_ET;
            //        Session["CIN_PASS"] = TextBox3.Text.Trim(); ;

            //        if (et.ToUpper().Contains("esprit2019".ToUpper()))
            //        {




            //            Response.Redirect("~/Etudiants/reset_pwd.aspx");
            //        }
            //        else
            //        {



            //            Session["PWD_ET"] = et; Session["motdepasse"] = et;
            //            LinkButton2.Visible = true; TextBox3.Visible = false; TextBox7.Visible = true; ButtonEtudiant.Visible = true;
            //            Button3.Visible = false; RequiredFieldValidator7.Enabled = true;
            //            Label7.Visible = false; Label8.Visible = true; Panel2.DefaultButton = "ButtonEtudiant";
            //        }
            //    }
            //    else
            //    {


            //        //string id_et = Session["ID_ET"].ToString();

            //        //if (id_et.StartsWith("21"))
            //        //{
            //        //    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez déposer votre dosier numérique')</script>");
            //        //}

            //        //else
            //        //{
            //            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");

            //        //}



            //        // Response.Write("<script LANGUAGE='JavaScript'> alert('Vérifier vos paramétres')</script>");
            //    }
            //}
            //else
            //{
            //    if (liaison_fin == "O")

            //    {
                //    DataTable dTablesoc = DAL.EncadDAO.Instance.Get_data_societe();

                //    foreach (DataRow row2 in dTablesoc.Rows)
                //    {
                //        if (row2["NUM_SEMESTRE_ACTUEL"] == DBNull.Value)
                //        {
                //            vn_numsem = "";

                //        }

                //        else
                //        {
                //            vn_numsem = row2["NUM_SEMESTRE_ACTUEL"].ToString();
                //            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                //        }

                //        if (row2["max_val_credit_accepte"] == DBNull.Value)
                //        {
                //            max_val_credit_accepte = "";

                //        }

                //        else
                //        {
                //            max_val_credit_accepte = row2["max_val_credit_accepte"].ToString();
                //            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                //        }

                //        if (row2["ANNEE_DEB"] == DBNull.Value)
                //        {
                //            annee_deb = "";

                //        }

                //        else
                //        {
                //     annee_deb = row2["ANNEE_DEB"].ToString();
                //   // annee_deb = "2021";
                //            //ddlcat.SelectedItem.Text = row2["cat"].ToString();

                //            Session["annee_deb"] = annee_deb;

                //        }

                //        if (row2["CTRL_FIN_STAT"] == DBNull.Value)
                //        {
                //            vs_ctrl_fin_stat = "";

                //        }

                //        else
                //        {
                //            vs_ctrl_fin_stat = row2["CTRL_FIN_STAT"].ToString();

                //        }

                //    }


                //    DataTable dTable2 = DAL.EncadDAO.Instance.Get_data_Etudiant(TextBox3.Text.Trim(), annee_deb);

                //    foreach (DataRow row2 in dTable2.Rows)
                //    {
                //        if (row2["mode_rglt"] == DBNull.Value)
                //        {
                //            mode_rgt = "";

                //        }


                

                //        else
                //        {
                //            mode_rgt = row2["mode_rglt"].ToString();
                //            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                //        }
                //if (row2["RESERVE"] == DBNull.Value)
                //{
                //  string  RESERVE = "";

                //}
                //else
                //{
                //string    RESERVE = row2["RESERVE"].ToString();
                //    if (RESERVE.Equals("O")) Response.Redirect("~/Online/default.aspx");
                //}

               
                //if (row2["DATE_LIM_PROLONG_RGLT"] == DBNull.Value)
                //        {
                //            // date_rgt = null;

                //        }

                //        else
                //        {
                //            date_rgt = Convert.ToDateTime(row2["DATE_LIM_PROLONG_RGLT"].ToString());

                //        }


                //        if (row2["numcompte"] == DBNull.Value)
                //        {
                //            numcompte = "";

                //        }

                //        else
                //        {
                //            numcompte = row2["numcompte"].ToString();
                //            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                //        }


                //        if (row2["code_cl"] == DBNull.Value)
                //        {
                //            code_cl = "";

                //        }

                //        else
                //        {
                //            code_cl = row2["code_cl"].ToString();
                //            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                //        }

                //    }

                //    //solde_sem2
                //    //Get_Value_lockedfromESPRITESB
                //    DataTable dTable3 =  DAL.EncadDAO.Instance.Get_Value_lockedfromESPRITESB(TextBox3.Text.Trim());
                //    foreach(DataRow dt3 in dTable3.Rows)
                //    {

                //        if (dt3["c_locked_esp"] == DBNull.Value)
                //        {
                //            c_locked_esp = "";

                //        }

                //        else
                //        {
                //            c_locked_esp = dt3["c_locked_esp"].ToString();
                //            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                //        }

                //        if (dt3["c_locked_esb"] == DBNull.Value)
                //        {
                //            c_locked_esb = "";

                //        }

                //        else
                //        {
                //            c_locked_esb = dt3["c_locked_esb"].ToString();
                //            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                //        }

                //    }

                //    if (c_locked_esp == null && c_locked_esb==null)
                //    {
                //        lockdB = DAL.EncadDAO.Instance.Get_Value_lockedfROMESB(TextBox3.Text.Trim());


                //        if (lockdB == "1")

                //        {
                //            if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                //            {

                //                //oui 
                //                a = true;

                //            }

                //            else
                //            {
                //                if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                //                {

                //                    //non
                //                    a = false;
                //                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");

                //                    TextBox3.Text = "";

                //                }


                //                else
                //                {
                //                    a = false;
                //                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");

                //                    TextBox3.Text = "";
                //                }
                //            }

                //        }


                //        else

                //        {
                //            if (lockdB == "0")

                //            {
                //                a = true;

                //            }

                //        }

                //    }

                //    else
                //    {
                //        if (c_locked_esp == "1" && c_locked_esb == "1")
                //        {

                //            if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                //            {

                //                //oui 
                //                a = true;

                //            }

                //            else
                //            {

                //                if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                //                {

                //                    //oui 
                //                    a = false;
                //                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");
                //                    TextBox3.Text = "";

                //                }


                //                else
                //                {
                //                    a = false;
                //                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");
                //                    TextBox3.Text = "";
                //                }

                //            }
                //        }


                //        else

                //        {
                //            if (c_locked_esp == "1" && c_locked_esb == "0")
                //            {

                //                if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                //                {

                //                    //oui 
                //                    a = true;

                //                }

                //                else
                //                {

                //                    if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                //                    {

                //                        //oui 
                //                        a = false;
                //                        Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais de restauration et/ou foyer')</script>");
                //                        TextBox3.Text = "";

                //                    }


                //                    else
                //                    {
                //                        a = false;
                //                        Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais de restauration et/ou foyer')</script>");
                //                        TextBox3.Text = "";
                //                    }

                //                }
                //            }




                //            else
                //            {


                //                if (c_locked_esp == "0" && c_locked_esb == "1")
                //                {

                //                    if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                //                    {

                //                        //oui 
                //                        a = true;

                //                    }

                //                    else
                //                    {

                //                        if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                //                        {

                //                            //oui 
                //                            a = false;
                //                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");
                //                            TextBox3.Text = "";

                //                        }


                //                        else
                //                        {
                //                            a = false;
                //                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");


                //                    TextBox3.Text = "";
                //                        }

                //                    }
                //                }


                //                else
                //                {

                //                    if (c_locked_esp == "0" && c_locked_esb == "0")
                //                    {

                //                        a = true;
                //                    }

                //                }
                //            }

                //        }

                //        }



                    
                      
                    

                           
                        



                //    //if (a == true || code_cl.StartsWith("5")) || code_cl.StartsWith("3")
                //    if (a == true)

                //    {

               // commenter le 16-02-2022
              //  Response.Write("<script LANGUAGE='JavaScript'> alert('l intranet est actuallement inaccessible')</script>");
                // decommnetr le 16-02-2022
                //ici decommenter
                string et = ESP_ETUDIANT.Instance.loginet_id(TextBox3.Text.Trim(), TextBox3.Text.Trim());
                if (et != null)
                {


                    Session["ID_ET"] = TextBox3.Text.Trim();
                    //Session["NOM_ET"] = et.NOM_ET;
                    //Session["PNOM_ET"] = et.PRENOM_ET;
                    Session["CIN_PASS"] = TextBox3.Text.Trim(); ;

                    if (et.ToUpper().Contains("esb2022".ToUpper())|| et.ToUpper().Contains("esß2022".ToUpper()) )
                      
                        {

                        Response.Redirect("~/Etudiants/reset_pwd.aspx");
                    }
                    else
                    {
                        Session["PWD_ET"] = et; Session["motdepasse"] = et;
                        LinkButton2.Visible = true; TextBox3.Visible = false; TextBox7.Visible = true; ButtonEtudiant.Visible = true; Button3.Visible = false; RequiredFieldValidator7.Enabled = true;
                        Label7.Visible = false; Label8.Visible = true; Panel2.DefaultButton = "ButtonEtudiant";
                    }
                }
                else
                {
                    //Session["ID_ET"] = TextBox3.Text.Trim();

                    //string id_et = Session["ID_ET"].ToString();

                    //if (id_et.StartsWith("21"))
                    //{
                    //   Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez déposer votre dossier numérique')</script>");
                    //}

                    //else
                    //{
                    // Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");

                    //}
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Vérifier vos paramétres')</script>");
                    TextBox3.Text = "";
                }
            }

                //    else
                //    {
                //        if (a == false)

                //        {
                //     Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais de restauration et/ou foyer')</script>");

                //    //commenter le 16-02-2022
                //    //Response.Write("<script LANGUAGE='JavaScript'> alert('l intranet est actuallement inaccessible')</script>");

                //}

            



                

        //    }






        //}


        protected void Button3_Clickws(object sender, EventArgs e)
        {

            //ici le test de NAVISION


            //string login = "USER4";
            //string pwd = "Esp@123**2021";

            string idetud = TextBox1.Text.Trim();

            try
            {
                string numc = ESP_ETUDIANT.Instance.GetnumcompteByid(TextBox3.Text.Trim());


                string annee = ESP_ETUDIANT.Instance.andb();
                //"4110001102";
                string aav = "('ESB')/Navision_To_Sco('" + numc + "')";
                var urlhistorique = "http://192.168.0.212:7028/Esprit_NAV_PROD/ODatav4/Company" + aav;

                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(urlhistorique);
                webrequest.Method = "GET";
                webrequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes("USER4:Esp@123**2021"));
                webrequest.Credentials = new NetworkCredential("USER4", "Esp@123**2021");
                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    var cc = Convert.ToString(result);
                    Getsoldeet list_hist1 = JsonConvert.DeserializeObject<Getsoldeet>(cc);

                    list_hist1.id_et = list_hist1.id_et;
                    list_hist1.no = list_hist1.no;
                    list_hist1.locked = Convert.ToBoolean(list_hist1.locked);

                    //string ss = Session["list_hist1.locked"].ToString();

                    res = Convert.ToBoolean(list_hist1.locked);
                    //lblid_et.Text = list_hist1.id_et;
                    //lblno.Text = list_hist1.no;
                    //lbllocked.Text = list_hist1.locked.ToString();




                    string liaison_fin = DAL.EncadDAO.Instance.get_liaison_fin();

                    if (liaison_fin == "N")
                    {
                        //ici ij new student


                        string et = ESP_ETUDIANT.Instance.loginet_id(TextBox3.Text.Trim(), TextBox3.Text.Trim());
                        if (et != null)
                        {


                            Session["ID_ET"] = TextBox3.Text.Trim();
                            //Session["NOM_ET"] = et.NOM_ET;
                            //Session["PNOM_ET"] = et.PRENOM_ET;
                            Session["CIN_PASS"] = TextBox3.Text.Trim(); ;

                            if (et.ToUpper().Contains("esb2022".ToUpper())|| et.ToUpper().Contains("esß2022".ToUpper()))
                            {




                                Response.Redirect("~/Etudiants/reset_pwd.aspx");
                            }
                            else
                            {



                                Session["PWD_ET"] = et; Session["motdepasse"] = et;
                                LinkButton2.Visible = true; TextBox3.Visible = false; TextBox7.Visible = true; ButtonEtudiant.Visible = true;
                                Button3.Visible = false; RequiredFieldValidator7.Enabled = true;
                                Label7.Visible = false; Label8.Visible = true; Panel2.DefaultButton = "ButtonEtudiant";
                            }
                        }
                        else
                        {


                            string id_et = Session["ID_ET"].ToString();

                            if (id_et.StartsWith("21"))
                            {
                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez déposer votre dosier numérique')</script>");
                            }

                            else
                            {
                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription ')</script>");

                            }



                            // Response.Write("<script LANGUAGE='JavaScript'> alert('Vérifier vos paramétres')</script>");
                        }
                    }
                    else
                    {
                        if (liaison_fin == "O")

                        {





                            //if (a == true || code_cl.StartsWith("5")) || code_cl.StartsWith("3")
                            if (res == false)

                            {

                                string et = ESP_ETUDIANT.Instance.loginet_id(TextBox3.Text.Trim(), TextBox3.Text.Trim());
                                if (et != null)
                                {


                                    Session["ID_ET"] = TextBox3.Text.Trim();
                                    //Session["NOM_ET"] = et.NOM_ET;
                                    //Session["PNOM_ET"] = et.PRENOM_ET;
                                    Session["CIN_PASS"] = TextBox3.Text.Trim(); ;

                                    if (et.ToUpper().Contains("esb2022".ToUpper())||et.ToUpper().Contains("esß2022".ToUpper()))
                                    {




                                        Response.Redirect("~/Etudiants/reset_pwd.aspx");
                                    }
                                    else
                                    {
                                        Session["PWD_ET"] = et; Session["motdepasse"] = et;
                                        LinkButton2.Visible = true; TextBox3.Visible = false; TextBox7.Visible = true; ButtonEtudiant.Visible = true; Button3.Visible = false; RequiredFieldValidator7.Enabled = true;
                                        Label7.Visible = false; Label8.Visible = true; Panel2.DefaultButton = "ButtonEtudiant";
                                    }
                                }
                                else
                                {
                                    Session["ID_ET"] = TextBox3.Text.Trim();

                                    string id_et = Session["ID_ET"].ToString();

                                    if (id_et.StartsWith("21"))
                                    {
                                        Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez déposer votre dossier numérique')</script>");
                                    }

                                    else
                                    {
                                        Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");

                                    }
                                    // Response.Write("<script LANGUAGE='JavaScript'> alert('Vérifier vos paramétres')</script>");
                                }
                            }

                            else
                            {
                                if (res == true)

                                {
                                    DataTable dTable2 = DAL.EncadDAO.Instance.Get_data_Etudiant(TextBox3.Text.Trim(), annee);

                                    foreach (DataRow row2 in dTable2.Rows)
                                    {
                                        if (row2["mode_rglt"] == DBNull.Value)
                                        {
                                            mode_rgt = "";

                                        }

                                        else
                                        {
                                            mode_rgt = row2["mode_rglt"].ToString();
                                            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                                        }

                                        if (row2["DATE_LIM_PROLONG_RGLT"] == DBNull.Value)
                                        {
                                            // date_rgt = null;

                                        }

                                        else
                                        {
                                            date_rgt = Convert.ToDateTime(row2["DATE_LIM_PROLONG_RGLT"].ToString());

                                        }


                                        if (row2["numcompte"] == DBNull.Value)
                                        {
                                            numcompte = "";

                                        }

                                        else
                                        {
                                            numcompte = row2["numcompte"].ToString();
                                            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                                        }


                                        if (row2["code_cl"] == DBNull.Value)
                                        {
                                            code_cl = "";

                                        }

                                        else
                                        {
                                            code_cl = row2["code_cl"].ToString();
                                            //ddlcat.SelectedItem.Text = row2["cat"].ToString();
                                        }

                                    }

                                    if (mode_rgt == "99" && date_rgt >= DateTime.Now)

                                    {

                                        string et = ESP_ETUDIANT.Instance.loginet_id(TextBox3.Text.Trim(), TextBox3.Text.Trim());
                                        if (et != null)
                                        {


                                            Session["ID_ET"] = TextBox3.Text.Trim();
                                            //Session["NOM_ET"] = et.NOM_ET;
                                            //Session["PNOM_ET"] = et.PRENOM_ET;
                                            Session["CIN_PASS"] = TextBox3.Text.Trim(); ;

                                            if (et.ToUpper().Contains("esb2022".ToUpper())||et.ToUpper().Contains("esß2022".ToUpper()))
                                            {




                                                Response.Redirect("~/Etudiants/reset_pwd.aspx");
                                            }
                                            else
                                            {
                                                Session["PWD_ET"] = et; Session["motdepasse"] = et;
                                                LinkButton2.Visible = true; TextBox3.Visible = false; TextBox7.Visible = true; ButtonEtudiant.Visible = true; Button3.Visible = false; RequiredFieldValidator7.Enabled = true;
                                                Label7.Visible = false; Label8.Visible = true; Panel2.DefaultButton = "ButtonEtudiant";
                                            }
                                        }
                                        else
                                        {
                                            Session["ID_ET"] = TextBox3.Text.Trim();

                                            string id_et = Session["ID_ET"].ToString();

                                            if (id_et.StartsWith("21"))
                                            {
                                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez déposer votre dossier numérique')</script>");
                                            }

                                            else
                                            {
                                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");

                                            }
                                            // Response.Write("<script LANGUAGE='JavaScript'> alert('Vérifier vos paramétres')</script>");
                                        }


                                    }

                                    else
                                    {
                                        if (mode_rgt == "99" && date_rgt <= DateTime.Now)

                                        {

                                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");

                                        }

                                        else
                                        {

                                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez procéder au paiement de vos frais d  inscription')</script>");

                                        }

                                    }

                                }



                            }



                        }

                    }


                }
            }
            catch
            {

                Response.Write("<script LANGUAGE='JavaScript'> alert('Vérifier votre identifiant')</script>");
                TextBox3.Text = "";

            }

        }


    }
}