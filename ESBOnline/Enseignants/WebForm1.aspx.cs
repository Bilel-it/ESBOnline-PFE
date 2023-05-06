using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESPSuiviEncadrement;
using Oracle.ManagedDataAccess.Types;

namespace ESPOnline.Enseignants
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string up;
        string id;
        string nom;
        string cup;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            up = Session["UP"].ToString();
            id = Session["ID_ENS"].ToString();
            nom = Session["NOM_ENS"].ToString();
            cup = Session["CUP"].ToString();
            //Panel3.Visible = false;
            if (!Page.IsPostBack)
            {
                List<Classes> cl = new List<Classes>();
                cl = Classes.GetList();
                DropDownList2.DataSource = cl;
                DropDownList2.DataTextField = "CODE_CL";
                DropDownList2.DataValueField = "CODE_CL";
                DropDownList2.DataBind();
                DropDownList3.Items.Clear();
                DropDownList5.Items.Clear();
                DropDownList2.Items.Insert(0, new ListItem("Choisir", "0"));
                DropDownList2.Items.Insert(1, new ListItem("All", "All"));
                DropDownList3.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList5.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList4.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
                LinkButton1.Visible = false;
                Panel3.Visible = false;
            }
            if (Session["SUIVI"] == "true")
            {
                Session["SUIVI"] = "false";
                PostSuivi();
            }
        }
        /*
         * Panel 1
         * 
         */
        //Classe
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            LinkButton3.Visible = false;
            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
            Panel3.Visible = false;
            IntiPanel3();

            if (DropDownList2.SelectedValue == "0")
            {
                DropDownList3.Items.Clear();
                DropDownList4.Items.Clear();
                DropDownList5.Items.Clear();
                DropDownList7.Items.Clear();
                DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList5.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList4.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList3.Items.Insert(0, new ListItem("N/A", "0"));

            }
            else
            {
                if (DropDownList2.SelectedValue == "All")
                {
                    //EtudiantBind();
                    ModuleAllBind();
                    DropDownList3.Items.Clear();
                    DropDownList3.Items.Insert(0, new ListItem("N/A", "0"));

                    DropDownList4.Items.Clear();
                    DropDownList4.Items.Insert(0, new ListItem("N/A", "0"));
                }
                else
                {
                    DropDownList3.Items.Clear();
                    DropDownList3.Items.Insert(0, new ListItem("N/A", "0"));
                    DropDownList4.Items.Clear();
                    DropDownList4.Items.Insert(0, new ListItem("N/A", "0"));
                    DropDownList7.Items.Clear();
                    DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
                    ModuleClassBind(DropDownList2.SelectedValue);
                    //EtudiantClassBind(DropDownList2.SelectedValue);

                }
            }
        }
        //Module
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkButton3.Visible = false;
            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
            Panel3.Visible = false;
            IntiPanel3();

            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("N/A", "0"));
            DropDownList4.Items.Clear();
            DropDownList4.Items.Insert(0, new ListItem("N/A", "0"));
            DropDownList7.Items.Clear();
            DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
            if (DropDownList5.SelectedValue == "0")
            {
                DropDownList3.Items.Clear();
                DropDownList3.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList4.Items.Clear();
                DropDownList4.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList7.Items.Clear();
                DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
            }
            else
            {
                if (DropDownList2.SelectedValue != "0" && DropDownList5.SelectedValue != "0")
                {
                    EtudiantClassBind(DropDownList2.SelectedValue);
                }
                if (DropDownList2.SelectedValue == "All" && DropDownList5.SelectedValue != "0")
                {
                    EtudiantBind();
                }
            }
        }
        //Etudiant
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkButton3.Visible = false;
            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
            Panel3.Visible = false;
            IntiPanel3();

            if (DropDownList3.SelectedValue == "0")
            {
                DropDownList4.Items.Clear();
                DropDownList7.Items.Clear();
                DropDownList4.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
            }
            else
            {
                DropDownList7.Items.Clear();
                DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
                Label21.Text = Convert.ToString(EtudiantClasses.Instance.getNiveauEtudiant(DropDownList3.SelectedValue.ToString()));
                DropDownList4.Items.Clear();
                TypeProjetBind();
            }
        }

        private void ModuleAllBind()
        {
            List<Modules> mod = new List<Modules>();
            mod = Modules.GetListAllModules();
            DropDownList5.DataSource = mod;
            DropDownList5.DataTextField = "DESIGNATION";
            DropDownList5.DataValueField = "CODE_MODULE";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem("Choisir", "0"));
        }

        protected void EtudiantBind()
        {
            List<EtudiantClasses> ls = new List<EtudiantClasses>();
            ls = EtudiantClasses.GetList();
            DropDownList3.DataSource = ls;
            DropDownList3.DataTextField = "NOM_ET";
            DropDownList3.DataValueField = "ID_ET";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Choisir", "0"));
        }

        protected void EtudiantClassBind(string codecl)
        {
            List<EtudiantClasses> ls = new List<EtudiantClasses>();
            ls = EtudiantClasses.GetListEtudiantClasse(codecl);
            DropDownList3.DataSource = ls;
            DropDownList3.DataTextField = "NOM_ET";
            DropDownList3.DataValueField = "ID_ET";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Choisir", "0"));
        }

        protected void ModuleClassBind(string codecl)
        {
            List<Modules> ls = new List<Modules>();
            ls = Modules.GetList(codecl);
            DropDownList5.DataSource = ls;
            DropDownList5.DataTextField = "DESIGNATION";
            DropDownList5.DataValueField = "CODE_MODULE";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem("Choisir", "0"));
        }

        protected void TypeProjetBind()
        {
            DropDownList4.Items.Insert(0, new ListItem("Choisir", "0"));
            DropDownList4.Items.Insert(1, new ListItem("Mini Projet", "01"));
            DropDownList4.Items.Insert(2, new ListItem("Projet d'intégration", "12"));
            DropDownList4.Items.Insert(3, new ListItem("P.F.E", "23"));
        }

        /*
        * Fin Panel 1
        * 
        */
        /*
        * Panel 2
        * 
        */

        //Type
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkButton2.Visible = false;
            LinkButton3.Visible = false;
            LinkButton1.Visible = false;
            Panel3.Visible = false;
            IntiPanel3();

            if (DropDownList4.SelectedValue != "0")
            {
                LinkButton2.Visible = true;
                DropDownList7.Items.Clear();
                BindAllProjects(DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                //if (DropDownList3.SelectedValue != "0" && DropDownList2.SelectedValue == "All")
                //{
                //    DropDownList7.Items.Clear();
                //    BindAllProjects(DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                //}
                //else
                //{

                //    if (DropDownList3.SelectedValue != "0" && DropDownList2.SelectedValue != "All")
                //    {
                //        DropDownList7.Items.Clear();
                //        BindProjectsByClass(DropDownList3.SelectedValue.ToString(), DropDownList2.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                //    }
                //}
            }
            else
            {

                Panel3.Visible = false;
                DropDownList7.Items.Clear();
                DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
            }
        }

        //Titre Des Projets
        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (DropDownList7.SelectedValue != "0")
            {
                
                //forcé l'initialisation du label38 de la base

                if (Label38.Text == "non affecter")
                {
                    Panel6.Visible = true;
                }
                else
                {
                    IntiPanel3();
                    LinkButton3.Visible = true;
                    LinkButton1.Visible = true;
                    //List<ESP_PROJET_DETAILS> proj = ESP_PROJET_DETAILS.GetProj(DropDownList7.SelectedValue.ToString());
                    HiddenField1.Value = DropDownList4.SelectedValue;
                    Panel7.Visible = true;
                    Panel3.Visible = true;
                    Panel6.Visible = false;
                }
            }
            else
            {
                LinkButton3.Visible = false;
                LinkButton1.Visible = false;
                Panel3.Visible = false;
            }

        }
        //Valider Creation Projet
        protected void Button3_Click(object sender, EventArgs e)
        {
            string CODE_MODULE = DropDownList5.SelectedValue.ToString().Trim();
            string ID_ET = DropDownList3.SelectedValue.ToString().Trim();
            string ID_ENS = nom.ToString().Trim();
            string CODE_CL = DropDownList2.SelectedValue.ToString().Trim();
            //Creation projet

            string TYPE_PROJET = DropDownList4.SelectedValue.ToString().Trim();
            string NOM_PROJET = TextBox5.Text.ToString().Trim();

            string TECHNOLOGIES = DDlistTech.SelectedValue.ToString();
            string METHODOLOGIE = DDlistMethod.SelectedValue.ToString();
            string DESCRIPTION_PROJET = TextBox15.Text.ToString().Trim();
            decimal PERIODE = Convert.ToDecimal(RadioButtonList3.SelectedValue.ToString().Trim());
            decimal SEMESTRE = Convert.ToDecimal(RadioButtonList2.SelectedValue.ToString().Trim());
            decimal NIVEAU_ETUDIANT = Convert.ToDecimal(Label21.Text.ToString());
            OracleDate date = OracleDate.GetSysDate();
            OracleTimeStamp he = OracleTimeStamp.GetSysDate();
            int v = 0;

            if (DropDownList4.SelectedValue != "0" && DropDownList5.SelectedValue != "0" && DropDownList2.SelectedValue != "0" && DropDownList3.SelectedValue != "0")
            {
                if (ESP_PROJET.Instance.verif_projet("2013", NOM_PROJET, CODE_MODULE))
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Le projet est deja existant !')</script>");
                }
                else
                    if (DropDownList6.SelectedValue.ToString() == "Mois" || TextBox5.Text == "")
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert('verifier le titre du projet ou la durée du projet !')</script>");
                    }
                    else
                    {
                        decimal DUREE = Convert.ToDecimal(DropDownList6.SelectedValue.ToString().Trim());
                        ESP_PROJET.Instance.openconntrans();
                        ESP_PROJET.Instance.create_esp_projet("2013", NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, NIVEAU_ETUDIANT, DUREE, SEMESTRE, PERIODE);
                        ESP_PROJET.Instance.closeConnection();
                        List<ESP_PROJET> id = ESP_PROJET.Instance.getIdproj("2013", NOM_PROJET, CODE_MODULE);
                        string proj = id.FirstOrDefault<ESP_PROJET>().ID_PROJET;
                        if (proj != "")
                        {
                            ESP_ENCADDREMENT.Instance.openconntrans();
                            ESP_ENCADDREMENT.Instance.create_Encadrement_ESP(proj, "2013", TYPE_PROJET, ID_ET, ID_ENS, CODE_CL, date, he, he, he, 0, 0, 0, 0, 0, "", "", "");
                            ESP_ENCADDREMENT.Instance.closeConnection();
                        }

                        TextBox5.Text = "";
                        TextBox15.Text = "";
                        Label21.Text = "";
                        Response.Write("<script LANGUAGE='JavaScript'> alert('Projet crée avec succes !')</script>");
                        DropDownList4.SelectedIndex = 0;
                        DropDownList6.SelectedIndex = 0;
                        DDlistTech.SelectedIndex = 0;
                        DDlistMethod.SelectedIndex = 0;
                        if (DropDownList4.SelectedValue != "0")
                        {

                            if (DropDownList3.SelectedValue != "0" && DropDownList2.SelectedValue == "All")
                            {
                                DropDownList7.Items.Clear();
                                BindAllProjects(DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                            }
                            else
                            {
                                if (DropDownList3.SelectedValue != "0" && DropDownList2.SelectedValue != "All")
                                {
                                    DropDownList7.Items.Clear();
                                    BindProjectsByClass(DropDownList3.SelectedValue.ToString(), DropDownList2.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                                }
                            }
                        }
                        else
                        {
                            DropDownList7.Items.Clear();
                            DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
                        }

                    }
            }
            else
            {
                TextBox5.Text = "";
                TextBox15.Text = "";
                Label21.Text = "";
                DropDownList4.SelectedIndex = 0;
                DropDownList6.SelectedIndex = 0;
                DDlistTech.SelectedIndex = 0;
                DDlistMethod.SelectedIndex = 0;
                if (DropDownList4.SelectedValue == "0")
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner le type de projet !')</script>");
                }
                else
                {
                    if (DropDownList5.SelectedValue == "0")
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner le module !')</script>");
                    }
                    else
                    {
                        if (DropDownList2.SelectedValue == "0")
                        {
                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner la classe !')</script>");
                        }
                        else
                        {
                            if (DropDownList3.SelectedValue == "0")
                            {
                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner l'etudiant !')</script>");
                            }
                        }
                    }
                }
            }
        }
        //Valider Modification Projet
        protected void Button5_Click(object sender, EventArgs e)
        {
            string CODE_MODULE = DropDownList5.SelectedValue.ToString().Trim();

            //Modification projet
            string ID_PROJET;
            string TYPE_PROJET;
            string NOM_PROJET;
            decimal DUREE;
            string TECHNOLOGIES;
            string METHODOLOGIE;
            string DESCRIPTION_PROJET;
            decimal PERIODE;
            decimal SEMESTRE;
            decimal NIVEAU_ETUDIANT;


            TYPE_PROJET = DropDownList4.SelectedValue.ToString().Trim();

            foreach (RepeaterItem i in Repeater1.Items)
            {
                TextBox txt = (TextBox)i.FindControl("TextBox18");
                ID_PROJET = txt.Text;
                TextBox txt1 = (TextBox)i.FindControl("TextBox25");
                NOM_PROJET = txt1.Text;

                TextBox txt4 = (TextBox)i.FindControl("TextBox15");
                DESCRIPTION_PROJET = txt4.Text;

                DropDownList ddl4 = (DropDownList)i.FindControl("DDlistTech2");
                TECHNOLOGIES = ddl4.SelectedValue.ToString().Trim();
                DropDownList ddl5 = (DropDownList)i.FindControl("DDlistMethod2");
                METHODOLOGIE = ddl5.SelectedValue.ToString().Trim();

                //DropDownList ddl = (DropDownList)i.FindControl("DropDownList4");
                //TYPE_PROJET = ddl.SelectedValue.ToString().Trim();
                DropDownList ddl1 = (DropDownList)i.FindControl("DropDownList8");
                Label txtN = (Label)i.FindControl("TextBoxNiveau");

                NIVEAU_ETUDIANT = Convert.ToDecimal(txtN.Text);
                DropDownList ddl2 = (DropDownList)i.FindControl("DropDownList9");
                DUREE = Convert.ToDecimal(ddl2.SelectedValue.ToString().Trim());
                RadioButtonList rbl2 = (RadioButtonList)i.FindControl("RadioButtonList2");
                SEMESTRE = Convert.ToDecimal(rbl2.SelectedValue.ToString().Trim());
                RadioButtonList rbl3 = (RadioButtonList)i.FindControl("RadioButtonList3");
                PERIODE = Convert.ToDecimal(rbl3.SelectedValue.ToString().Trim());
                ESP_PROJET.Instance.openconntrans();
                ESP_PROJET.Instance.update_esp_suivi_projet("2013", ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, NIVEAU_ETUDIANT, DUREE, SEMESTRE, PERIODE);
                ESP_PROJET.Instance.closeConnection();
                Response.Write("<script LANGUAGE='JavaScript'> alert('La mise à jour du projet a été effectué avec succes !!')</script>");
                BindAllProjects(DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());

            }


        }
        //Button Modifier
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //Response.Write("<script LANGUAGE='JavaScript'> alert('Le projet est deja existant !')</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalModifier();", true);
            //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "LoginFail", "$('#modifier_projet').modal('show');", true);
            //ClientScript.RegisterStartupScript(Page.GetType(), "key", "alert('Button Clicked')", true);
        }
        //Button Ajouter
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "0")
            {

                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner la classe !')</script>");
            }
            else
            {

                if (DropDownList3.SelectedValue == "0")
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner l'etudiant !')</script>");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAjouter();", true);

                }

            }

        }

        private void BindProjectsByClass(string p, string p_1, string p_2)
        {
            List<ESP_PROJET_DETAILS> ls = new List<ESP_PROJET_DETAILS>();
            ls = ESP_PROJET_DETAILS.GetProjEtudiantClass(p, p_1, p_2);
            DropDownList7.DataSource = ls;
            DropDownList7.DataTextField = "NOM_PROJET";
            DropDownList7.DataValueField = "ID_PROJET";
            DropDownList7.DataBind();
            if (DropDownList7.Items.Count != 0)
            {
                DropDownList7.Items.Insert(0, new ListItem("Choisir", "0"));
            }
            else
            {
                DropDownList7.Items.Insert(0, new ListItem("Aucun", "0"));
            }

        }

        private void BindAllProjects(string p, string p_1)
        {
            List<ESP_PROJET_DETAILS> ls = new List<ESP_PROJET_DETAILS>();
            ls = ESP_PROJET_DETAILS.GetProjEtudiant(p, p_1);
            DropDownList7.DataSource = ls;
            DropDownList7.DataTextField = "NOM_PROJET";
            DropDownList7.DataValueField = "ID_PROJET";
            DropDownList7.DataBind();
            if (DropDownList7.Items.Count != 0)
            {
                DropDownList7.Items.Insert(0, new ListItem("Choisir", "0"));
            }
            else
            {
                DropDownList7.Items.Insert(0, new ListItem("Aucun", "0"));
            }
        }
        //Suivi
        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Session["CODE_CL"] = DropDownList2.SelectedValue.ToString();
            Session["NOM_ET"] = DropDownList3.SelectedItem.ToString();
            Session["ID_ET"] = DropDownList3.SelectedValue.ToString();
            Session["ID_ENS"] = DropDownList3.SelectedValue.ToString();
            Session["ID_PROJ"] = DropDownList7.SelectedValue.ToString();
            Response.Redirect("Suivis.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string h_entre = dtp_input2.Value.ToString();
            h_entre = dtp_input2.Value.ToString().Substring(0, 2);
            string h_sortie = dtp_input3.Value.ToString().Substring(0, 2);
            string m_entre = dtp_input2.Value.ToString().Substring(3, 2);
            string m_sortie = dtp_input3.Value.ToString().Substring(3, 2);

            int duree_entre = int.Parse(h_entre) * 60 + int.Parse(m_entre);
            int duree_sortir = int.Parse(h_sortie) * 60 + int.Parse(m_sortie);
            int dure = duree_sortir - duree_entre;

            if (dure < 60)
            {
                Response.Write(@"<script language='javascript'>alert('verifier les heures !!')</script>");
            }
            else
            {

                string dure_heure_string = (dure / 60).ToString();
                string dure_minute_string = (dure % 60).ToString();
                Convert.ToInt32(dure_heure_string);
                OracleTimeStamp date;
                date = Oracle.DataAccess.Types.OracleTimeStamp.GetSysDate();
                OracleTimeStamp dureee = new OracleTimeStamp(date.Year, date.Month, date.Day, Convert.ToInt32(dure_heure_string), Convert.ToInt32(dure_minute_string), 0);
                string ID_PROJET = DropDownList7.SelectedValue.ToString().Trim();
                string ANNEE_DEB = "2013";
                string TYPE_PROJET = HiddenField1.Value.ToString().Trim();
                string ID_ET = DropDownList3.SelectedValue.ToString().Trim();
                string ID_ENS = nom.ToString().Trim();
                string CODE_CL = DropDownList2.SelectedValue.ToString().Trim();
                /* ************************************************************** */

                string date_from_input = dtp_input1.Value.ToString();
                Oracle.DataAccess.Types.OracleDate.GetSysDate();
                OracleDate dateoracle;
                OracleDate time = Oracle.DataAccess.Types.OracleDate.GetSysDate();

                dateoracle = new OracleDate(int.Parse(date_from_input.Substring(6, 4)), int.Parse(date_from_input.Substring(3, 2)), int.Parse(date_from_input.Substring(0, 2)), Oracle.DataAccess.Types.OracleDate.GetSysDate().Hour, Oracle.DataAccess.Types.OracleDate.GetSysDate().Minute, Oracle.DataAccess.Types.OracleDate.GetSysDate().Second);
                //dateoracle = new OracleDate(int.Parse(date_from_input.Substring(0, 4)), int.Parse(date_from_input.Substring(5, 2)), int.Parse(date_from_input.Substring(8, 2)), Oracle.DataAccess.Types.OracleDate.GetSysDate().Hour, Oracle.DataAccess.Types.OracleDate.GetSysDate().Minute, Oracle.DataAccess.Types.OracleDate.GetSysDate().Second);

                OracleDate DATE_ENC = dateoracle;

                //Label1.Text = dateoracle.ToString();
                /********************************************************************/
                //OracleTimeStamp HEURE_DEB = OracleTimeStamp.Parse(dtp_input2.Value.ToString());
                string datetime2 = dtp_input2.Value.ToString();
                OracleTimeStamp time1;
                time1 = Oracle.DataAccess.Types.OracleTimeStamp.GetSysDate();

                double milii = 0;
                OracleTimeStamp HEURE_DEB = new OracleTimeStamp(time1.Year, time1.Month, time1.Day, int.Parse(datetime2.Substring(0, 2)), int.Parse(datetime2.Substring(3, 2)), 1
                    , milii);

                //OracleTimeStamp HEURE_FIN = OracleTimeStamp.Parse(dtp_input3.Value.ToString());
                string datetime = dtp_input3.Value.ToString();
                OracleTimeStamp time11;
                time11 = Oracle.DataAccess.Types.OracleTimeStamp.GetSysDate();

                double mili = 0;
                OracleTimeStamp HEURE_FIN = new OracleTimeStamp(time11.Year, time11.Month, time11.Day, int.Parse(datetime.Substring(0, 2)), int.Parse(datetime.Substring(3, 2)), 1
                    , mili);



                /**************************************************/



                //int h = int.Parse(dure_en_string.Substring(0,2)); //int min = int.Parse(dure_en_string.Substring(2)); //int m = min*60; Label1.Text = dure_heure_string +"h"+dure_minute_string+"m";
                /******************840 780********************************/


                //OracleTimeStamp DUREE_SEANCE = OracleTimeStamp.GetSysDate();
                //string h_entre = dtp_input2.Value.ToString().Substring(0, 2);
                //string h_sortie = dtp_input3.Value.ToString().Substring(0, 2);
                //string m_entre = dtp_input2.Value.ToString().Substring(3, 2);
                //string m_sortie = dtp_input3.Value.ToString().Substring(3, 2);
                //int duree_entre = int.Parse(h_entre) * 60 + int.Parse(m_entre);
                //int duree_sortir = int.Parse(h_sortie) * 60 + int.Parse(m_sortie);
                //int dure = duree_sortir - duree_entre;
                //int heure = 0;
                //int minute = 0;
                //do
                //{
                //    heure = dure / 60;
                //    minute = dure % 60;


                //} while (dure >= 60);

                ////string d = Convert.ToString(heure) + ":" + Convert.ToString(minute);



                //Label1.Text = dureee.ToString();

                decimal AV_TECH = Convert.ToDecimal(TextBox3.Text.Trim());
                decimal AV_GLOBAL = Convert.ToDecimal(TextBox9.Text.Trim());
                decimal AV_ANG = Convert.ToDecimal(TextBox4.Text.Trim());
                decimal AV_FR = Convert.ToDecimal(TextBox6.Text.Trim());
                decimal AV_RAPPORT = Convert.ToDecimal(TextBox8.Text.Trim());
                decimal AV_CC = Convert.ToDecimal(TextBox7.Text.Trim());
                string AV_COMPORTEMENT = RadioButtonList1.SelectedValue.ToString();
                string REMARQUE = TextBox10.Text;
                string TRAVAIL = TextBox11.Text;




                ESP_ENCADDREMENT.Instance.openconntrans();
                ESP_ENCADDREMENT.Instance.create_Encadrement_ESP(ID_PROJET, ANNEE_DEB, TYPE_PROJET, ID_ET, ID_ENS, CODE_CL, DATE_ENC, HEURE_DEB, HEURE_FIN, dureee, AV_TECH, AV_ANG, AV_FR, AV_RAPPORT, AV_CC, AV_COMPORTEMENT, REMARQUE, TRAVAIL);
                ESP_ENCADDREMENT.Instance.closeConnection();
                Response.Write("<script LANGUAGE='JavaScript'> alert('La suivi du projet a été effectué avec succes !!')</script>");
            }




        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        public void IntiPanel3()
        {
            //AV_TECH 
            TextBox3.Text = "";
            //AV_GLOBAL 
            TextBox9.Text = "";
            //AV_ANG 
            TextBox4.Text = "";
            //AV_FR 
            TextBox6.Text = "";
            //AV_RAPPORT 
            TextBox8.Text = "";
            //AV_CC
            TextBox7.Text = "";
            //AV_COMPORTEMENT
            RadioButtonList1.SelectedValue = "B";
            //REMARQUE
            TextBox10.Text = "";
            //TRAVAIL
            TextBox11.Text = "";
        }

        public void PostSuivi()
        {
            //string codecl;
            //string id;
            //string nomet;
            //string idet;
            //string idproj;

            ////Session["SUIVI"] = "true";
            //codecl = Session["CODE_CL"].ToString();
            //nomet = Session["NOM_ET"].ToString();
            //idet = Session["ID_ET"].ToString();
            //id = Session["ID_ENS"].ToString();
            //idproj = Session["ID_PROJ"].ToString();

            //DropDownList2.SelectedValue = codecl;
            //DropDownList2.AutoPostBack = true;

            //DropDownList2.SelectedIndexChanged += new EventHandler(DropDownList2_SelectedIndexChanged);
        }
        /*
        * Panel 2
        * 
        */
        protected void affecter_etudiant_projet(object sender, EventArgs e)
        {
            if (RadioButtonList4.SelectedValue == "oui")
            {
                Panel5.Visible = true;
                Label36.Text = DropDownList3.SelectedItem.Text.ToString();
                Label42.Text = DropDownList4.SelectedItem.Text.ToString();
                Label44.Text = DropDownList7.SelectedItem.Text.ToString();
                

            }
            else
            {
                Panel5.Visible = false;
            }
        }

    }
}