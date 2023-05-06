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
    public partial class EncadrementG : System.Web.UI.Page
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
                DropDownList10.Items.Clear();
                DropDownList5.Items.Clear();
                DropDownList12.Items.Clear();
                DropDownList13.Items.Clear();
                DropDownList2.Items.Insert(0, new ListItem("Choisir", "0"));
                DropDownList2.Items.Insert(1, new ListItem("All", "All"));
                DropDownList3.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList10.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList5.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList4.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList12.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList13.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList8.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList16.Items.Insert(0, new ListItem("N/A", "0"));
                DropDownList13.Items.Insert(0, new ListItem("N/A", "0"));
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
                LinkButton1.Visible = false;
                
                LinkButton9.Visible = false;
                LinkButton6.Visible = false;
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
            initTout();

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
                initCLasse();

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
                    EtudiantClassBind(DropDownList2.SelectedValue);

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
            initTout();

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
                initCLasse();
            }
            else
            {
                if (DropDownList2.SelectedValue != "0" && DropDownList5.SelectedValue != "0")
                {
                    EtudiantClassBind(DropDownList2.SelectedValue);
                    DropDownList7.Items.Clear();
                    DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
                    Label21.Text = Convert.ToString(EtudiantClasses.Instance.getNiveauEtudiant(DropDownList3.SelectedValue.ToString()));
                    DropDownList4.Items.Clear();
                    TypeProjetBind();
                }
                if (DropDownList2.SelectedValue == "All" && DropDownList5.SelectedValue != "0")
                {
                    EtudiantBind();
                    DropDownList7.Items.Clear();
                    DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
                    Label21.Text = Convert.ToString(EtudiantClasses.Instance.getNiveauEtudiant(DropDownList3.SelectedValue.ToString().Trim()));
                    DropDownList4.Items.Clear();
                    TypeProjetBind();
                }
            }
            
        }
        //Etudiant
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkButton2.Visible = true;
            //LinkButton2.Visible = false;
            //LinkButton3.Visible = false;
            //LinkButton1.Visible = false;
            Panel3.Visible = false;
            IntiPanel3();
           
           

            if (DropDownList4.SelectedValue != "0")
            {
                
                DropDownList7.Items.Clear();
                BindAllProjects(DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                if (DropDownList3.SelectedValue != "0" && DropDownList2.SelectedValue == "All")
                {
                    DropDownList7.Items.Clear();
                    //PanelTypeENcad.Visible = true;
                    BindAllProjects(DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                    LinkButton2.Visible = true;
                }
                else
                {

                    if (DropDownList3.SelectedValue != "0" && DropDownList2.SelectedValue != "All")
                    {
                        //PanelTypeENcad.Visible = true;
                        DropDownList7.Items.Clear();
                        BindProjectsByClass(DropDownList3.SelectedValue.ToString(), DropDownList2.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                        LinkButton2.Visible = true;
                    }
                }
            }
            else
            {
                //PanelTypeENcad.Visible = false;
                Panel3.Visible = false;
                DropDownList7.Items.Clear();
                DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
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
            DropDownList10.DataSource = ls;

            DropDownList3.DataTextField = "NOM_ET";
            DropDownList10.DataTextField = "NOM_ET";

            DropDownList3.DataValueField = "ID_ET";
            DropDownList10.DataValueField = "ID_ET";
            DropDownList3.DataBind();
            DropDownList10.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Choisir", "0"));
            DropDownList10.Items.Insert(0, new ListItem("Choisir", "0"));
        }

        protected void EtudiantClassBind(string codecl)
        {
            List<EtudiantClasses> ls = new List<EtudiantClasses>();
            ls = EtudiantClasses.GetListEtudiantClasse(codecl);
            //DropDownList3.DataSource = ls;
            //DropDownList3.DataTextField = "NOM_ET";
            //DropDownList3.DataValueField = "ID_ET";
            //DropDownList3.DataBind();
            //DropDownList3.Items.Insert(0, new ListItem("Choisir", "0"));
            DropDownList3.DataSource = ls;
            DropDownList10.DataSource = ls;

            DropDownList3.DataTextField = "NOM_ET";
            DropDownList10.DataTextField = "NOM_ET";

            DropDownList3.DataValueField = "ID_ET";
            DropDownList10.DataValueField = "ID_ET";
            DropDownList3.DataBind();
            DropDownList10.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Choisir", "0"));
            DropDownList10.Items.Insert(0, new ListItem("Choisir", "0"));
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
        /*panel Evaluation recherche*/
        protected void afichierPanel(object sender, object e)
        {
            
        }

        //Type de projet
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList4.SelectedItem.ToString().Equals("Choisir"))
            {
                initTout();
                DropDownList12.Items.Clear();
                DropDownList12.Items.Insert(0, new ListItem("N/A", "0"));
                IntiPanel3();
                Panel3.Visible = false;
                initTypeEncadrement();
            }
            else
            {
                initTout();
                DropDownList12.Items.Clear();
                DropDownList12.Items.Insert(0, new ListItem("Choisir", "0"));
                DropDownList12.Items.Insert(1, new ListItem("Individuel", "1"));
                DropDownList12.Items.Insert(2, new ListItem("Groupe", "2"));
            }
        }

        //Titre Des Projets
        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList7.SelectedItem.ToString() == "Choisir" || DropDownList7.SelectedItem.ToString() == "Aucun"
                || DropDownList7.SelectedItem.ToString() == "N/A"
                && DropDownList12.SelectedValue.ToString() == "1")
            {
                Panel3.Visible = false;
                PanelNoteDeGroupe.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                Button13.Visible = false;
                Button14.Visible = false;
                LinkButton1.Visible = false;
                LinkButton3.Visible = false;
                LinkButton2.Visible = true;  
            }

            else if (DropDownList7.SelectedItem.ToString() != "Choisir" || DropDownList7.SelectedItem.ToString() != "Aucun"
                || DropDownList7.SelectedItem.ToString() != "N/A" && DropDownList12.SelectedValue.ToString() == "1")
            {
                Panel3.Visible = true;
                PanelNoteDeGroupe.Visible = false;
                Button1.Visible = true;
                Button2.Visible = true;
                Button13.Visible = false;
                Button14.Visible = false;
                LinkButton1.Visible = true;
                LinkButton3.Visible = true;
                LinkButton2.Visible = true;    
            }
            else if (DropDownList7.SelectedItem.ToString() != "Choisir" || DropDownList7.SelectedItem.ToString() != "Aucun"
                || DropDownList7.SelectedItem.ToString() != "N/A" && DropDownList12.SelectedValue.ToString() == "2")
            {
                Panel3.Visible = true;
                PanelNoteDeGroupe.Visible = true;
                Button1.Visible = false;
                Button2.Visible = false;
                Button13.Visible = true;
                Button14.Visible = true;
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
               
            }
            else
            {
                Panel3.Visible = false;
                PanelNoteDeGroupe.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                Button13.Visible = false;
                Button14.Visible = false;
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
               
            }

        }
        //Valider Creation Projet

        protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
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

                    }
                    
            }
            else
            
                
                if (DropDownList4.SelectedValue == "0")
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner le type de projet !')</script>");
                }
                else
                
                    if (DropDownList5.SelectedValue == "0")
                    {
                        Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner le module !')</script>");
                    }
                    else
                    
                        if (DropDownList2.SelectedValue == "0")
                        {
                            Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner la classe !')</script>");
                        }
                        else
                        
                            if (DropDownList3.SelectedValue == "0")
                            {
                                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez selectionner l'etudiant !')</script>");
                            }
                        
                    
                
            

            
            else
            {
                DropDownList7.Items.Clear();
                DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
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

        //button affectation au groupe
        protected void Button7_Click(object sender, EventArgs e)
        {
            if (DropDownList10.SelectedItem.ToString() == "Choisir" || DropDownList16.SelectedItem.ToString() == "Choisir")
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Vérifier les champs!')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAffecterGroupe();", true);   

            }
            else
            {
                string id_groupe_projet = DropDownList16.SelectedValue.ToString();
                string id_etudiant = DropDownList10.SelectedValue.ToString();
                string id_enseignant = Session["NOM_ENS"].ToString();

           
            

                ESP_ETUDIANT_NOTE_GROUPE.Instance.openconntrans();
                if (ESP_ETUDIANT_NOTE_GROUPE.Instance.verif_Groupe_projet_ESP(id_groupe_projet, id_etudiant) == true)
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Etudiant " + DropDownList10.SelectedItem.ToString() + " est dèjà affecter dans le groupe " + DropDownList17.SelectedItem.ToString() + " !')</script>");
                
                    //LabelGroupeEtudiant.Text = DropDownList8.SelectedItem.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAffecterGroupe();", true);
                }
                else
                {
                    ESP_ETUDIANT_NOTE_GROUPE.Instance.affect_etudiant_groupe_projet_ESP(id_groupe_projet, id_etudiant, 0, id_enseignant, "","");
                    GetListeEtudiantDansunGroupe(DropDownList8.SelectedValue.ToString());
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Affectation réussite.')</script>");
                }
                ESP_ETUDIANT_NOTE_GROUPE.Instance.closeConnection();
                }
        }

        //Button Ajouter
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Label21.Text = Convert.ToString(EtudiantClasses.Instance.getNiveauEtudiant(DropDownList3.SelectedValue.ToString()));
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

        private void BindProjectsByClass_Groupe(string p, string p_1, string p_2)
        {
            List<ESP_PROJET_DETAIL_GROUPE> ls = new List<ESP_PROJET_DETAIL_GROUPE>();
            ls = ESP_PROJET_DETAIL_GROUPE.GetProjEtudiantClass_Groupe(p, p_1, p_2);
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

        private void BindAllProjects_Groupe(string p, string p_1)
        {
            List<ESP_PROJET_DETAIL_GROUPE> ls = new List<ESP_PROJET_DETAIL_GROUPE>();
            ls = ESP_PROJET_DETAIL_GROUPE.GetProjEtudiant_Groupe(p, p_1);
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

            Response.Write("<script>");
            Response.Write("window.open('Suivi.aspx','_blanck')");
            Response.Write("</script>"); 
            //Response.Redirect("Suivi.aspx");
        }


        protected void suivi_groupe(object sender, EventArgs e)
        {
            Session["CODE_CL"] = DropDownList2.SelectedValue.ToString();
            Session["NOM_ET"] = DropDownList13.SelectedItem.ToString();
            Session["ID_ET"] = DropDownList13.SelectedValue.ToString();
            Session["ID_ENS"] = DropDownList3.SelectedValue.ToString();
            Session["ID_GROUPE_PROJET"] = DropDownList8.SelectedValue.ToString();
            Session["NOM_GROUPE"] = DropDownList8.SelectedItem.ToString();
            Session["ID_PROJET"] = DropDownList7.SelectedValue.ToString().Trim();
            Session["NOM_CLASSE"] = DropDownList2.SelectedItem.ToString();

            Response.Write("<script>");
            Response.Write("window.open('SuiviGroupe.aspx','_blanck')");
            Response.Write("</script>");
            //ESPSuiviEncadrement.ESP_ENCADREMENT_GP.GetProjByGROUPEProjet(
            
        }


        // <summary>
        /// ////////////////////////////////////////////////
        // </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
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
                string TYPE_PROJET = DropDownList4.SelectedValue.ToString().Trim();
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




        protected void cancel_create_groupe(object sender, EventArgs e)
        {
           

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////// type d'encadrement

        protected void select_type_encadrement(object sender, EventArgs e)
        {
            DropDownList7.Items.Clear();
            //encadrementGroupe individuel
            if (DropDownList12.SelectedValue.ToString() == "1")
            {
                PanelHeadEncadrement.Visible = true;
                PanelHeadEncadrementParGroupe.Visible = false;
                PanelNoteDeGroupe.Visible = false;
                PanelEtudiant.Visible = true;
                LinkButton2.Visible = true;
                Panel3.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                Button13.Visible = false;
                Button14.Visible = false;
                if (DropDownList2.SelectedItem.ToString() != "All")
                {
                    BindAllProjects(DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                }
                else
                {
                   
                    if (DropDownList3.SelectedValue != "0" && DropDownList2.SelectedValue == "All")
                    {
                        DropDownList7.Items.Clear();
                        //PanelTypeENcad.Visible = true;
                        BindAllProjects(DropDownList3.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                    }
                    else
                    {

                        if (DropDownList3.SelectedValue != "0" && DropDownList2.SelectedValue != "All")
                        {
                            //PanelTypeENcad.Visible = true;
                            DropDownList7.Items.Clear();
                            BindProjectsByClass(DropDownList3.SelectedValue.ToString(), DropDownList2.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                        }
                    }
                }
               
            }
                //encadrementGroupe par groupe
            else if (DropDownList12.SelectedValue.ToString() == "2")
            {
                PanelHeadEncadrement.Visible = false;
                PanelEtudiant.Visible = false;
                PanelHeadEncadrementParGroupe.Visible = true;
                Panel3.Visible = false;
                PanelNoteDeGroupe.Visible = false;
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
                Panel3.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                Button13.Visible = false;
                Button14.Visible = false;
                if (DropDownList2.SelectedItem.ToString() != "All")
                {
                    bindGroupeProjetParClasseModuleType(DropDownList2.SelectedValue.ToString(), DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                }
                else
                {
                    bindGroupeProjetParModuleType(DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                }

            }
            else if (DropDownList12.SelectedItem.ToString() == "Choisir" || DropDownList12.SelectedItem.ToString() == "Aucun")
            {
                initTout();
                
            }
         }

        private void bindGroupeProjetParClasseModuleType(string classe, string module, string typepg)
        {
            List<ESP_GP_PROJET> ls = new List<ESP_GP_PROJET>();
            ls = ESP_GP_PROJET.GetGrouepByClasseModuleType(module, classe, typepg);
            
            DropDownList8.Items.Clear();
            DropDownList16.Items.Clear();
            DropDownList8.DataSource = ls;
            DropDownList16.DataSource = ls;
            DropDownList8.DataTextField = "NOM_GROUPE";
            DropDownList16.DataTextField = "NOM_PROJET";
            DropDownList8.DataValueField = "ID_GROUPE_PROJET";
            DropDownList16.DataValueField = "ID_GROUPE_PROJET";
            DropDownList8.DataBind();
            DropDownList16.DataBind();
            if (DropDownList8.Items.Count != 0)
            {
                DropDownList8.Items.Insert(0, new ListItem("Choisir", "0"));
                DropDownList16.Items.Insert(0, new ListItem("Choisir", "0"));
                LinkButton8.Visible = true;
                
            }
            else
            {
                DropDownList8.Items.Insert(0, new ListItem("Aucun", "0"));
                DropDownList16.Items.Insert(0, new ListItem("Aucun", "0"));

                LinkButton8.Visible = true;
            }
        }

        private void bindGroupeProjetParModuleType(string module, string typepg)
        {
            List<ESP_GP_PROJET> ls = new List<ESP_GP_PROJET>();
            ls = ESP_GP_PROJET.GetGrouepByModuleType(module, typepg);
            DropDownList8.Items.Clear();
            DropDownList16.Items.Clear();
            DropDownList8.DataSource = ls;
            DropDownList16.DataSource = ls;
            DropDownList8.DataTextField = "NOM_GROUPE";
            DropDownList16.DataTextField = "NOM_PROJET";
            DropDownList8.DataValueField = "ID_GROUPE_PROJET";
            DropDownList16.DataValueField = "ID_GROUPE_PROJET";
            DropDownList8.DataBind();
            DropDownList16.DataBind();
            if (DropDownList8.Items.Count != 0)
            {
                DropDownList8.Items.Insert(0, new ListItem("Choisir", "0"));
                DropDownList16.Items.Insert(0, new ListItem("Choisir", "0"));
                LinkButton6.Visible = true;
                LinkButton8.Visible = true;
            }
            else
            {
                DropDownList8.Items.Insert(0, new ListItem("Aucun", "0"));
                DropDownList16.Items.Insert(0, new ListItem("Aucun", "0"));
                LinkButton6.Visible = false;
                LinkButton8.Visible = true;
            }
        }


        protected void NomGroupProjet(string module, string classe, string type)
        {
            List<ESP_PROJET> ls = new List<ESP_PROJET>();
            ls = ESP_PROJET.GetNNNN(module, classe, type);

            DropDownList17.Items.Clear();

            DropDownList17.DataSource = ls;

            DropDownList17.DataTextField = "NOM_PROJET";

            DropDownList17.DataValueField = "ID_GROUPE_PROJET";

            DropDownList17.DataBind();

            if (DropDownList17.Items.Count != 0)
            {
                DropDownList17.Items.Insert(0, new ListItem("Choisir", "0"));


            }
            else
            {
                DropDownList17.Items.Insert(0, new ListItem("Aucun", "0"));

            }
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

        public void initTout()
        {
            PanelHeadEncadrement.Visible = false;
            PanelEtudiant.Visible = false;
            PanelHeadEncadrementParGroupe.Visible = false;
            DropDownList8.Items.Clear();
            DropDownList8.Items.Insert(0, new ListItem("N/A", "0"));
            DropDownList13.Items.Clear();
            DropDownList13.Items.Insert(0, new ListItem("N/A", "0"));
            //DropDownList3.Items.Clear();
            //DropDownList3.Items.Insert(0, new ListItem("N/A", "0"));
            DropDownList7.Items.Clear();
            DropDownList7.Items.Insert(0, new ListItem("N/A", "0"));
            LinkButton6.Visible = false;
            LinkButton9.Visible = false;
            Panel3.Visible = false;
            PanelNoteDeGroupe.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Button13.Visible = false;
            Button14.Visible = false;
            LinkButton1.Visible = false;
            LinkButton3.Visible = false;
            LinkButton2.Visible = false;
            LinkButton6.Visible = false;
            PanelLinkEvalEtudiant.Visible = false;
            LinkButton6.Visible = false;
            PanelEtudiant.Visible = false;
            initTypeEncadrement();
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

       


        //ajouter un projet par groupe
        protected void Button11_Click(object sender, EventArgs e)
        {
            if (DropDownList17.SelectedItem.ToString() == "Choisir" || DropDownList17.SelectedValue.ToString()=="0")
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Vérifier les champs !')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalcreate_Groupe();", true);
                
            }
            else
            {
                string nom_groupe = textboxNomGroupe.Text;
                string sujet = textboxSujetPI.Text;
                decimal numero_projet = decimal.Parse(DropDownList1.SelectedItem.ToString());
                string Code_CL = DropDownList2.SelectedValue.ToString().Trim();
                string ID_Groupe_pg = DropDownList17.SelectedValue.ToString();
                ESP_GP_PROJET.Instance.openconntrans();
                if (ESP_GP_PROJET.Instance.verif_Groupe_projet_ESP(nom_groupe, numero_projet, Code_CL) == true)
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Groupe existe dèjà !')</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalcreate_Groupe();", true);
                }
                else
                {
                    ESP_GP_PROJET.Instance.create_groupe_projet_ESP(ID_Groupe_pg, nom_groupe, sujet, numero_projet, Code_CL);
                    Response.Write("<div class='alert-success'><script LANGUAGE='JavaScript'> alert('Groupe crée avec success !')</script></div>");
                    GetListeEtudiantDansunGroupe(DropDownList8.SelectedValue.ToString());
               
                
                }
                ESP_GP_PROJET.Instance.closeConnection();
                PanelHeadEncadrement.Visible = false;
                PanelEtudiant.Visible = false;
                PanelHeadEncadrementParGroupe.Visible = true;
                
                if (DropDownList2.SelectedItem.ToString() != "All")
                {
                    bindGroupeProjetParClasseModuleType(DropDownList2.SelectedValue.ToString(), DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                }
                else
                {
                    bindGroupeProjetParModuleType(DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                }

                initCreeProjetParGroupe();

            }


        }

        protected void Afficher_suivi_Groupe(object sender, EventArgs e)
        {
            

        }

        protected void Button13_Click(object sender, EventArgs e)
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



                string ID_PROJET = DropDownList7.SelectedValue.ToString();
                string ANNEE_DEB = "2013";
                string TYPE_PROJET = DropDownList4.SelectedValue.ToString().Trim();
                string ID_ET = DropDownList3.SelectedValue.ToString().Trim();
                string ID_ENS = nom.ToString().Trim();
                string CODE_CL = DropDownList2.SelectedValue.ToString().Trim();
                string ID_GROUPE_PROJET = DropDownList8.SelectedValue.ToString();
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



                

                decimal AV_TECH = Convert.ToDecimal(TextBox3.Text.Trim());
                decimal AV_GLOBAL = Convert.ToDecimal(TextBox9.Text.Trim());
                decimal AV_ANG = Convert.ToDecimal(TextBox4.Text.Trim());
                decimal AV_FR = Convert.ToDecimal(TextBox6.Text.Trim());
                decimal AV_RAPPORT = Convert.ToDecimal(TextBox8.Text.Trim());
                decimal AV_CC = Convert.ToDecimal(TextBox7.Text.Trim());
                string AV_COMPORTEMENT = RadioButtonList1.SelectedValue.ToString();
                string REMARQUE = TextBox10.Text;
                string TRAVAIL = TextBox11.Text;
                decimal Note_GROUPE = decimal.Parse(TextBoxNoteGROUPE.Text.ToString());




                ESP_ENCADREMENT_GP.Instance.openconntrans();
                ESP_ENCADREMENT_GP.Instance.create_Encadrement_ESP( ANNEE_DEB, TYPE_PROJET, ID_ENS, CODE_CL, DATE_ENC, HEURE_DEB, HEURE_FIN, dureee, AV_TECH, AV_ANG, AV_FR, AV_RAPPORT, AV_CC, AV_COMPORTEMENT, REMARQUE, TRAVAIL, Note_GROUPE, ID_GROUPE_PROJET);
                ESP_ENCADREMENT_GP.Instance.closeConnection();
                Response.Write("<script LANGUAGE='JavaScript'> alert('La suivi du projet a été effectué avec succes !!')</script>");
            }



        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedItem.ToString() != "All")
            {
                bindGroupeProjetParClasseModuleType(DropDownList2.SelectedValue.ToString(), DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                //Response.Write("<script LANGUAGE='JavaScript'> alert('merci')</script>");
            }
            else
            {
                bindGroupeProjetParModuleType(DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                //Response.Write("<script LANGUAGE='JavaScript'> alert('merci')</script>");
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAjouterGP();", true);

        }

        //ajouter un projet par groupe
        protected void Button9_Click(object sender, EventArgs e)
        {
            if (DropDownList11.SelectedValue.ToString() == "Mois") 
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('choisir une durée')</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAjouterGP();", true);
                
                
               
            }
            else
            {
                string CODE_MODULE = DropDownList5.SelectedValue.ToString().Trim();
            //string ID_ET = DropDownList3.SelectedValue.ToString().Trim();
            string ID_ENS = nom.ToString().Trim();
            string CODE_CL = DropDownList2.SelectedValue.ToString().Trim();
            //Creation projet

            string TYPE_PROJET = DropDownList4.SelectedValue.ToString().Trim();
            string NOM_PROJET = TextBox12.Text.ToString().Trim();

            string TECHNOLOGIES = DropDownList14.SelectedValue.ToString();
            string METHODOLOGIE = DropDownList15.SelectedValue.ToString();
            string DESCRIPTION_PROJET = TextBox13.Text.ToString().Trim();
            decimal PERIODE = Convert.ToDecimal(RadioButtonList5.SelectedValue.ToString().Trim());
            decimal SEMESTRE = Convert.ToDecimal(RadioButtonList5.SelectedValue.ToString().Trim());

            //ajouter la verification
            decimal DUREE = Convert.ToDecimal(DropDownList11.SelectedValue.ToString().Trim());
            
            OracleDate date = OracleDate.GetSysDate();
            OracleTimeStamp he = OracleTimeStamp.GetSysDate();
           
            
                if(ESP_PROJET.Instance.verif_projet_par_groupe("2013",NOM_PROJET,CODE_MODULE)==false)
                {
                    ESP_PROJET.Instance.openconntrans();
                    ESP_PROJET.Instance.create_esp_projet_par_groupe("2013", NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, DUREE, SEMESTRE, PERIODE,CODE_CL);
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Projet Groupe crée avec success')</script>");
                    if (DropDownList2.SelectedItem.ToString() != "All")
                    {
                        bindGroupeProjetParClasseModuleType(DropDownList2.SelectedValue.ToString(), DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                        //Response.Write("<script LANGUAGE='JavaScript'> alert('merci')</script>");
                    }
                    else
                    {
                        bindGroupeProjetParModuleType(DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
                        //Response.Write("<script LANGUAGE='JavaScript'> alert('merci')</script>");
                    }
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Projet Groupe Existe dèjà')</script>");
                }
            ESP_PROJET.Instance.closeConnection();
            }


            IniTgroupeprojet();
            
            
            
        }



        protected void DropDownList8_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (DropDownList8.SelectedValue.ToString() != "0" || DropDownList8.SelectedItem.ToString() != "Choisir")
            {
                GetListeEtudiantDansunGroupe(DropDownList8.SelectedValue.ToString());
                LinkButton6.Visible = true;
                LinkButton9.Visible = true;
                Panel3.Visible = true;
                PanelNoteDeGroupe.Visible = true;
                Button1.Visible = false;
                Button2.Visible = false;
                Button13.Visible = true;
                Button14.Visible = true;
                LinkButton6.Visible = true;


            }
            else
            {
                DropDownList13.Items.Clear();
                DropDownList13.Items.Insert(0, new ListItem("N/A", "0"));
                LinkButton6.Visible = false;
                LinkButton9.Visible = false;
                Panel3.Visible = false;
                PanelNoteDeGroupe.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                Button13.Visible = false;
                Button14.Visible = false;
                LinkButton6.Visible = false;
                LinkButton10.Visible = false;
                LinkButton11.Visible = false;
            }
        }

        protected void GetListeEtudiantDansunGroupe(string idprojetParGroupe)
        {
            List<ESP_ETUDIANT_NOTE_GROUPE> ls = new List<ESP_ETUDIANT_NOTE_GROUPE>();
            ls = ESP_ETUDIANT_NOTE_GROUPE.GetListeEtudiantDansunGroupe(idprojetParGroupe);
            
            DropDownList13.Items.Clear();

            DropDownList13.DataSource = ls;

            DropDownList13.DataTextField = "NOM_ET";
            
            DropDownList13.DataValueField = "ID_ET";

            DropDownList13.DataBind();

            if (DropDownList13.Items.Count != 0)
            {
                DropDownList13.Items.Insert(0, new ListItem("Liste Etudiants", "0"));
                
                
            }
            else
            {
                DropDownList13.Items.Insert(0, new ListItem("Aucun", "0"));
                
                
            }
        }


        //affectation etudiant dans un groupe
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            LabelGroupeClasse.Text = DropDownList2.SelectedItem.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAffecterGroupe();", true);            
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            NomGroupProjet(DropDownList5.SelectedValue.ToString(), DropDownList2.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalcreate_Groupe();", true);
        }


        protected void LinkButton10_Click(object sender, EventArgs e)
        {

            labelevalEtu.Text = DropDownList13.SelectedItem.ToString();
            labelevalGroupe.Text = DropDownList8.SelectedItem.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalEvaluationEtudiantGroup();", true);
        }

        protected void DropDownList13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList13.SelectedItem.ToString().Equals("Liste Etudiants"))
            {
                PanelLinkEvalEtudiant.Visible = false;
            }
            else if (DropDownList13.SelectedItem.ToString().Equals("N/A"))
            {
                PanelLinkEvalEtudiant.Visible = false;
            }
            else
            {
                PanelLinkEvalEtudiant.Visible = true;
                LinkButton10.Visible = true;
                LinkButton11.Visible = true;
            }
            
        }


        //Evaluation etudiant
        protected void Button15_Click(object sender, EventArgs e)
        {
            string id_groupe_projet = DropDownList8.SelectedValue.ToString();
            string id_etudiant = DropDownList13.SelectedValue.ToString();
            string id_enseignant = Session["NOM_ENS"].ToString();

            ESP_ETUDIANT_NOTE_GROUPE.Instance.openconntrans();
            ESP_ETUDIANT_NOTE_GROUPE.Instance.create_etudiant_groupe_projet_ESP(id_groupe_projet, id_etudiant, decimal.Parse(textboxNoteEval.Text),
                id_enseignant, TextBoxRemarque.Text, RadioButtonList6.SelectedValue.ToString());
            ESP_ETUDIANT_NOTE_GROUPE.Instance.closeConnection();
            Response.Write("<div class='alert-success'><script LANGUAGE='JavaScript'> alert('Evaluation crée avec success !')</script></div>");
            initEvalEtudiant();

        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Session["CODE_CL"] = DropDownList2.SelectedValue.ToString();
            Session["NOM_ET"] = DropDownList13.SelectedItem.ToString();
            Session["ID_ET"] = DropDownList13.SelectedValue.ToString();
            Session["ID_ENS"] = DropDownList3.SelectedValue.ToString();
            Session["ID_GROUPE_PROJET"] = DropDownList8.SelectedValue.ToString();
            Session["NOM_PROJET"] = DropDownList8.SelectedItem.ToString();

            Response.Write("<script>");
            Response.Write("window.open('SuiviETG.aspx','_blanck')");
            Response.Write("</script>");
        }


        /*
        * Panel 2
        * 
        */


        protected void initCLasse()
        {
            DropDownList12.Items.Clear();
            DropDownList12.Items.Insert(0, new ListItem("N/A", "0"));
            PanelHeadEncadrement.Visible = false;
            PanelHeadEncadrementParGroupe.Visible = false;
            Panel3.Visible = false;
            PanelNoteDeGroupe.Visible = false;
            DropDownList8.Items.Clear();
            DropDownList8.Items.Insert(0, new ListItem("N/A", "0"));
            DropDownList13.Items.Clear();
            DropDownList13.Items.Insert(0, new ListItem("N/A", "0"));
            PanelLinkEvalEtudiant.Visible = false;
            //LinkButton2.Visible = false;
        }
        protected void initTypeEncadrement()
        {
            PanelHeadEncadrement.Visible = false;
            PanelHeadEncadrementParGroupe.Visible = false;
            Panel3.Visible = false;
            PanelNoteDeGroupe.Visible = false;
            DropDownList8.Items.Clear();
            DropDownList8.Items.Insert(0, new ListItem("N/A", "0"));
            DropDownList13.Items.Clear();
            DropDownList13.Items.Insert(0, new ListItem("N/A", "0"));
            PanelLinkEvalEtudiant.Visible = false;
            
            if (DropDownList2.SelectedItem.ToString() != "All" && DropDownList12.SelectedValue.ToString() == "2")
            {
                bindGroupeProjetParClasseModuleType(DropDownList2.SelectedValue.ToString(), DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
            }
            else if(DropDownList2.SelectedValue.ToString() != "Choisir" || DropDownList2.SelectedValue.ToString() != "All" && DropDownList12.SelectedValue.ToString() == "2")
            {
                bindGroupeProjetParModuleType(DropDownList5.SelectedValue.ToString(), DropDownList4.SelectedValue.ToString());
            }
            //else if (DropDownList2.SelectedItem.ToString() != "All" && DropDownList12.SelectedValue.ToString() == "1")
            //{
            //    BindAllProjects
            //}
            
        }


        public void IniTgroupeprojet()
        {
            TextBox12.Text = "";
            DropDownList11.SelectedValue = "Mois";
            TextBox13.Text = "";


        }


        public void initEvalEtudiant()
        {
            RadioButtonList6.SelectedValue = "non";
            textboxNoteEval.Text = "0";
            TextBoxRemarque.Text = "";
        }

        public void initCreeProjetParGroupe()
        {
            textboxNomGroupe.Text = "";
            textboxSujetPI.Text = "";
            DropDownList1.SelectedValue = "choi";
        }
    }
}
