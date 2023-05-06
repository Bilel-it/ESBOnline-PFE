using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace ESPOnline.Enseignants
{
    public partial class Inscrit_TOEIC_PREPens : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();
        string id_ens;
        string typechoix;
        string nbenregtoiec;
        string nbenregtpreptoiec;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblanneedeb.Text = service.getANNEEDEBs();

            lblanneefin.Text = service.getAnneeFiN();

            nbenregtoiec = service.countNB_TOIEC();
            nbenregtpreptoiec = service.countNBPrep_TOIEC();
            if (!IsPostBack)
            {
                plrst.Visible = false;

                lblcounttoiec.Text = nbenregtoiec;
                lblcountpreptoiec.Text = nbenregtpreptoiec;
                // Label1.Text = "";
                Response.Write(@"<script language='javascript'>alert('Le nombre des inscrits est atteint 300 candidats au certif Toeic,preparez la certification TOEIC si vous voulez:');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            id_ens = Session["ID_ENS"].ToString();
            service.Enreg_ens_toeic(id_ens, ddlchoix.SelectedValue);

            Response.Write(@"<script language='javascript'>alert('Vous êtes enregistré avec succée');</script>");

            typechoix = service.selectEtatTTOIECENS(id_ens);

            if (typechoix == "1")
            {
                lbltpd.Text = "Vous êtes inscrit au certification toeic,Bonne chance";
                plrst.Visible = true;
                Button1.Visible = false;
                ddlchoix.Visible = false;
                paneltoiec.Visible = false;
                panelprep.Visible = false;
                lblprep.Visible = false;
                //lbltoiec.Visible = false;
                lblchoix.Visible = false;
                //Panel1.Visible = false;
            }
            else
                if (typechoix == "2")
                {
                    lbltpd.Text = "Vous êtes inscrit au prep toeic,Bonne chance";
                    plrst.Visible = true;
                    Button1.Visible = false;
                    ddlchoix.Visible = false;
                    paneltoiec.Visible = false;
                    panelprep.Visible = false;
                    lblprep.Visible = false;
                    //lbltoiec.Visible = false;
                    lblchoix.Visible = false;
                    //Panel1.Visible = false;
                }
                else
                    if (typechoix == "3")
                    {
                        lbltpd.Text = "Vous êtes inscrit dans les deux certifications,Bonne chance";
                        plrst.Visible = true;
                        Button1.Visible = false;
                        ddlchoix.Visible = false;
                        paneltoiec.Visible = false;
                        panelprep.Visible = false;
                        lblprep.Visible = false;
                        //lbltoiec.Visible = false;
                        lblchoix.Visible = false;
                        //Panel1.Visible = false;
                    }


        }
    }
}