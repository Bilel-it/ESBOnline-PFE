using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.Etudiants
{
    public partial class Inscrip_Test_Langue : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        string code_cl;
        string veriflabeltoeic;
        string veriflabelprepTOEIC;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            lblanneedeb.Text = service.getANNEEDEBs();

            lblanneefin.Text = service.getAnneeFiN();

            ID_ET = Session["ID_ET"].ToString();
            lblcodecl.Text = service.returnCL(ID_ET);
            veriflabeltoeic = service.selectEtatTTOIEC(ID_ET);
            //veriflabelprepTOEIC = service.selectEtatTPREPTOIEC(ID_ET, lblanneedeb.Text);

            if (!Page.IsPostBack)
            {

                HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
                if (Session["ID_ET"] == null)
                {
                    Response.Redirect("~/Online/default.aspx");
                }
                else
                {
                    //Gridbord.Visible = false;

                }

                string nivetudiantang = service.selectniVeauEDTANG(ID_ET);
                string nivetudiantfr = service.selectniVeauEDTFR(ID_ET);

                if (nivetudiantang == "B2" && nivetudiantfr == "B2")
                {
                    Response.Write(@"<script language='javascript'>alert('Votre niveau en français est B2 ,qu\'en anglais ,passer un test TOIEC OU PREP TOEIC');</script>");

                    foreach (ListItem item in ddltestfr.Items)
                    {

                        item.Attributes.Add("disabled", "disabled");
                    }

                    foreach (ListItem itemang in ddltestang.Items)
                    {
                        itemang.Attributes.Add("disabled", "disabled");

                    }
                    panel.Visible = false;
                }


                else
                {
                    if (nivetudiantfr == "B2" || nivetudiantang == "B2")
                    {
                        Response.Redirect("~/Etudiants/Inscript_B2.aspx");
                    }
                    else
                    {

                        Response.Redirect("~/Etudiants/Inscrit_moin_B2.aspx");

                    }
                }

            }

        }


        protected void chkTOIEC_CheckedChanged(object sender, EventArgs e)
        {
            //ID_ET = Session["ID_ET"].ToString();
            //if (chkTOIEC.Checked)
            //{
            //    Response.Write(@"<script language='DDDDDD');</script>");
            //    service.UpdatETOIC(ID_ET);


            //    //lblchek.Text = "Vous êtes inscrit au test TOIEC";
            //    //LBLUNCHEK.Visible = false;

            //}
            //else
            //{
            //    service.UpdatETOICToNo(ID_ET);
            //    //LBLUNCHEK.Text = "Vous avez annuler votre inscription au test TOIC";
            //    //lblchek.Visible = false;
            //    Response.Write(@"<script language='Vous avez annulé votre enregistrement');</script>"); 

            //}
        }

        protected void chkprepTOIEC_CheckedChanged(object sender, EventArgs e)
        {
            //    ID_ET = Session["ID_ET"].ToString();
            //    if (chkprepTOIEC.Checked)
            //    {
            //        service.UpdatEPREPTOIC(ID_ET);
            //        //lblcheckprep.Text = "Vous êtes inscrit au test PREP TOIEC";


            //}
            //else 
            //{
            //    service.UpdatEPREPTOICTONo(ID_ET);
            //    //lbluncheckpreptoic.Text = "Vous avez annuler votre inscription au test prep TOIC";

            //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ID_ET = Session["ID_ET"].ToString();

            string etatEtudiant = service.selectEtatTest(ID_ET);
            if (etatEtudiant == "Y")
            {
                Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit');</script>");
                panelddr.Visible = false;
                panel.Visible = false;

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
                    lblTOIEC.Text = "Vous n'êtes  pas inscrit au test PREP TOEIC";
                }

            }
            else
            {
                lblTOIEC.Visible = false;
                LblprepTOIEC.Visible = false;
                service.UpdateEtatInsctestniv(ID_ET);
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
                    lblTOIEC.Text = "Vous n'êtes  pas inscrit au test PREP TOEIC";
                }

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
                    lblchek.Text = "VOUS n'êtes pas inscrit AU TEST TOIEC";

                }


            }

        }




    }
}