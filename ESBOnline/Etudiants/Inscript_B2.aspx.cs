using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.Etudiants
{
    public partial class Inscript_B2 : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();
        string ID_ET;
        string nivetudiantang;
        string nivetudiantfr;
        string veriflabeltoeic;
        string veriflabelprepTOEIC;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID_ET = Session["ID_ET"].ToString();
            lblanneedeb.Text = service.getANNEEDEBs();

            lblanneefin.Text = service.getAnneeFiN();
            
           // lblcodecl.Text = service.returnCL(ID_ET);
            //lblcodecl.Visible = false;
            veriflabeltoeic = service.selectEtatTTOIEC(ID_ET);
            //veriflabelprepTOEIC = service.selectEtatTPREPTOIEC(ID_ET, lblanneedeb.Text);
             nivetudiantang = service.selectniVeauEDTANG(ID_ET);
             nivetudiantfr = service.selectniVeauEDTFR(ID_ET); 
           if(!IsPostBack)
            {
                BindDateExam();
                BindDateang();


                if (nivetudiantfr == "B2")
                {
                    panelfr.Visible = false;
                    Response.Write(@"<script language='javascript'>alert('Votre niveau en français est B2,vous n\'avez le droit  de passer que l\'anglais, TOIEC OU PREP TOEIC');</script>");
                }

                else
                {
                    if (nivetudiantang == "B2")
                    {
                        Response.Write(@"<script language='javascript'>alert(' Votre niveau en anglais est B2,vous n\'avez le droit  de passer que le Français, TOIEC OU PREP TOEIC');</script>");

                        panelang.Visible = false;

                    }
                }
              
           }
            }

        
        //protected void chkTOIEC_CheckedChanged(object sender, EventArgs e)
        //{
        //    ID_ET = Session["ID_ET"].ToString();
        //    if (chkTOIEC.Checked)
        //    {
        //        service.UpdatETOIC(ID_ET);
        //        lblchek.Text = "VOUS êtes inscrit au test toic";
              
        //    }
        //    else
        //    {
        //        service.UpdatETOICToNo(ID_ET);
        //        lblchek.Text = "VOUS avez annuler votre choix";
               
        //    }
        //}

        //protected void chkprepTOIEC_CheckedChanged(object sender, EventArgs e)
        //{
        //    ID_ET = Session["ID_ET"].ToString();
        //    if (chkprepTOIEC.Checked)
        //    {
        //        service.UpdatEPREPTOIC(ID_ET);
        //    }
        //    else
        //    {
        //        service.UpdatEPREPTOICTONo(ID_ET);
        //    }

        //}

        protected void ddltestfr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltestfr.SelectedValue != null)
            {
                LabCount.Text = service.nbCondidatsInscrit(Convert.ToDateTime(ddltestfr.SelectedValue));
            }
        }

        protected void ddltestang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltestang.SelectedValue != null)
            {
                LabCountang.Text = service.nbCondidatsInscritang(Convert.ToDateTime(ddltestang.SelectedValue));
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            ID_ET = Session["ID_ET"].ToString();
            //try
            //{
                string etatEtudiant = service.selectEtatTest(ID_ET);
                if (etatEtudiant == "Y")
                {
                    Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit');</script>");
                    panelfr.Visible = false;
                    paneltoiec.Visible = false;
                    Afficher_Liste_fr();

                    if(veriflabeltoeic=="O")
                    {
                        lblTOIEC.Text = "Vous êtes inscrit au test TOEIC";
                       
                    }
                    else
                    {
                        lblTOIEC.Text = "Vous n'êtes pas inscrit au test TOEIC";
                    }
                    if(veriflabelprepTOEIC=="O")
                    {
                        LblprepTOIEC.Text = "Vous êtes inscrit au test PREP TOEIC";
                    }
                    else
                    {
                        LblprepTOIEC.Text = "Vous n'êtes  pas inscrit au test PREP TOEIC";
                    }
                }
                else
                {
                    if (service.verif(ddltestfr.SelectedValue) == true)
                    {


                        service.Enreg_inscriTest_fr(Convert.ToDateTime(ddltestfr.SelectedValue), ID_ET, lblanneedeb.Text);
                    
                        service.Addnbcondidatfr(Convert.ToDateTime(ddltestfr.SelectedValue));
                        service.UpdateEtatInsctestniv(ID_ET);

                        Response.Write(@"<script language='javascript'>alert('Ajout avec succès');</script>");
                       
                        Gridfr.Visible = true;
                        Gridang.Visible = false;
                        
                        //panelfr.Visible = false;
                        //panelang.Visible = false;

                        Afficher_Liste_fr();


                    }
                    //else
                    //{
                        
                    //    Response.Write(@"<script language='javascript'>alert('Session fermée, car le nombre max des inscriptions atteint 150 élèves');</script>");
                    //}

                }
            //}

            //catch (Exception)
            //{
            //    Response.Write(@"<script language='javascript'>alert('Session fermée, car le nombre max des inscriptions atteint 150 élèves');</script>");
            //}
        }
        void Afficher_Liste_fr()
        {
            ID_ET = Session["ID_ET"].ToString();
            Gridfr.DataSource = service.Afficher_date_exam_etudfrfr(ID_ET);
            Gridfr.DataBind();
        }
        public void Afficher_Liste_ang()
        {
            ID_ET = Session["ID_ET"].ToString();
            Gridang.DataSource = service.Afficher_date_exam_etudangang(ID_ET);
            Gridang.DataBind();
        }
        public void BindDateExam()
        {
            ddltestfr.DataTextField = "DATETEST";
            ddltestfr.DataValueField = "DATETEST";
            ddltestfr.DataSource = service.bindDATEexaM();
            ddltestfr.DataBind();
        }


        public void BindDateang()
        {
            ddltestang.DataTextField = "DATETEST";
            ddltestang.DataValueField = "DATETEST";
            ddltestang.DataSource = service.bindDATEexaMANG();
            ddltestang.DataBind();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
         ID_ET = Session["ID_ET"].ToString();
            //try
            //{
                string etatEtudiant = service.selectEtatTest(ID_ET);
                if (etatEtudiant == "Y")
                {
                    Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit');</script>");

                    panelang.Visible = false;
                    paneltoiec.Visible = false;
                    Afficher_Liste_ang();

                    if (veriflabeltoeic == "O")
                    {
                        lblTOIEC.Text = "Vous êtes inscrit au test TOEIC";

                    }
                    else
                    {
                        lblTOIEC.Text = "Vous n'êtes pas inscrit au test TOEIC";
                    }
                    if (veriflabelprepTOEIC == "O")
                    {
                        LblprepTOIEC.Text = "Vous êtes inscrit au test PREP TOEIC";
                    }
                    else
                    {
                        LblprepTOIEC.Text = "Vous n'êtes  pas inscrit au test PREP TOEIC";
                    }
                }
                else
                {

             if (service.verifang(ddltestang.SelectedValue) == true)
                                    {
                                        service.Enreg_inscriTest_ANG(Convert.ToDateTime(ddltestang.SelectedValue),ID_ET, lblanneedeb.Text);
                                     
                                        service.AddnbcondidatANG(Convert.ToDateTime(ddltestang.SelectedValue));
                 
                                         service.UpdateEtatInsctestniv(ID_ET);
                                   

                                    Response.Write(@"<script language='javascript'>alert('Ajout avec succès');</script>");
                                   
                                    Gridfr.Visible = false;
                                    Gridang.Visible = true;
                                    Afficher_Liste_ang();

                                }
             //else
             //{

             //    Response.Write(@"<script language='javascript'>alert('Session fermée, car le nombre max des inscriptions atteint 150 élèves');</script>");
             //}
                           
                        //}
            }

            //catch (Exception)
            //{
                //Response.Write(@"<script language='javascript'>alert('Session fermée, car le nombre max des inscriptions atteint 150 élèves');</script>");
            //}
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            ID_ET = Session["ID_ET"].ToString();
            //if (chkprepTOIEC.Checked)
            //{
            //    service.UpdatEPREPTOIC(ID_ET, lblanneedeb.Text);
            //    lblchekPREP.Text = "VOUS êtes inscrit au test PREP toic";
            //}
            //else
            //{
            //    service.UpdatEPREPTOICTONo(ID_ET, lblanneedeb.Text);
            //    lblchekPREP.Text = "VOUS n'êtes pas inscrit AU TEST PREP TOIC";
            //}


            if (chkTOIEC.Checked)
            {
                service.UpdatETOIC(ID_ET);
                lblchek.Text = "Vous êtes inscrit au test TOIEC";

            }
            else
            {
                service.UpdatETOICToNo(ID_ET);
                lblchek.Text = "VOUS n'êtes pas inscrit  AU TEST TOIEC";

            }




        }


        }
    }
