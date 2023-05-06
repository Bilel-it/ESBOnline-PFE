using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.Etudiants
{
    public partial class Inscrit_moin_B2 : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();
        string ID_ET;
        string veriflabeltoeic;
        string veriflabelprepTOEIC;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblanneedeb.Text = service.getANNEEDEBs();

            lblanneefin.Text = service.getAnneeFiN();

           // lblcodecl.Text = service.returnCL(ID_ET);
           
            if (!IsPostBack)
            {
                BindDateExam();

                BindDateExamANG();
               
            }
            panel.Visible = true;
           
           // string nivetudiantang = service.selectniVeauEDTANG(ID_ET);
            //string nivetudiantfr = service.selectniVeauEDTFR(ID_ET); 
        }



        public void BindDateExam()
        {
            ddltestfr.DataTextField = "DATETEST";
            ddltestfr.DataValueField = "DATETEST";
            ddltestfr.DataSource = service.bindDATEexaM();
            ddltestfr.DataBind();
        }
        public void BindDateExamANG()
        {
            ddltestang.DataTextField = "DATETEST";
            ddltestang.DataValueField = "DATETEST";
            ddltestang.DataSource = service.bindDATEexaMANG();
            ddltestang.DataBind();
        }


        public void Afficher_Liste_BS()
        {
            ID_ET = Session["ID_ET"].ToString();
            Gridbord.DataSource = service.Afficher_date_exam_etud(ID_ET);
            Gridbord.DataBind();
        }
       

        protected void chkTOIEC_CheckedChanged(object sender, EventArgs e)
        {
            ID_ET = Session["ID_ET"].ToString();
            if (chkTOIEC.Checked)
            {
                service.UpdatETOIC(ID_ET);
            }
            else
            {
                service.UpdatETOICToNo(ID_ET);
            }
        }

        protected void chkprepTOIEC_CheckedChanged(object sender, EventArgs e)
        {
            ID_ET = Session["ID_ET"].ToString();
            //if (chkprepTOIEC.Checked)
            //{
            //    service.UpdatEPREPTOIC(ID_ET, lblanneedeb.Text);
            //    lblchek.Text = "Vous êtes inscrit au test TOIEC";
            //    //LBLUNCHEK.Visible = false;
            //}
            //     else 
            //{
            //    service.UpdatEPREPTOICTONo(ID_ET, lblanneedeb.Text);
            //   // LBLUNCHEK.Text = "Vous avez annuler votre inscription";
            //    lblchek.Visible = false;
            //}
           

        }


        
        protected void btnOk_Click(object sender, EventArgs e)
        {
            ID_ET = Session["ID_ET"].ToString();
            veriflabeltoeic = service.selectEtatTTOIEC(ID_ET);
            //veriflabelprepTOEIC = service.selectEtatTPREPTOIEC(ID_ET, lblanneedeb.Text);
          
            //ID_ET = Session["11-3MT-380"].ToString();
            //try
            //{
                string etatEtudiant = service.selectEtatTest(ID_ET);
                if (etatEtudiant == "Y")
                {
                    Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit!');</script>");
                    panel1.Visible = false;
                    Gridbord.Visible = true;
                    paneltoiec.Visible = false;
                    Afficher_Liste_BS();
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
                        LblprepTOIEC.Text = "Vous n'êtes pas  inscrit au test PREP TOEIC";
                    }
                }
                else
                {
                    if (service.verif(ddltestfr.SelectedValue) == true && service.verifang(ddltestang.SelectedValue) == true)
                    // if (service.verif(ddltestfr.SelectedValue) == true)
                    {
                        service.Enreg_inscriTest_Lng(Convert.ToDateTime(ddltestfr.SelectedValue), Convert.ToDateTime(ddltestang.SelectedValue), ID_ET, lblanneedeb.Text);
                        service.UpdateEtatInsctestniv(ID_ET);

                        service.Addnbcondidatfr(Convert.ToDateTime(ddltestfr.SelectedValue));
                        service.AddnbcondidatANG(Convert.ToDateTime(ddltestang.SelectedValue));

                        Response.Write(@"<script language='javascript'>alert('Ajout avec succès');</script>");
                        Afficher_Liste_BS();
                        Gridbord.Visible = true;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ID_ET = Session["ID_ET"].ToString();
            //if (chkprepTOIEC.Checked)
            //{
            //    service.UpdatEPREPTOIC(ID_ET, lblanneedeb.Text);
            //    lblchekPREP.Text = "VOUS êtes inscrit au test PREP toic";
                
            //}
            //else
            //{
            //    service.UpdatEPREPTOICTONo(ID_ET, lblanneedeb.Text);
            //    lblchekPREP.Text = "VOUS n'êtes pas inscrit  AU TEST PREP TOIC";
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