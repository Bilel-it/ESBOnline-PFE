using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Toeic_ens_cup : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();
        string id_ens;
        string ID_ET;

        string veriflabeltoeic;
        string veriflabelprepTOEIC;
        string nbenregtoiec;
        string nbenregtpreptoiec;
        string typechoix;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            id_ens = Session["ID_ENS"].ToString();
            lblanneedeb.Text = service.getANNEEDEBs();

            lblanneefin.Text = service.getAnneeFiN();
            plrst.Visible = false;


            nbenregtoiec = service.countNB_TOIEC();
            nbenregtpreptoiec = service.countNBPrep_TOIEC();

            //ddlTOEIC.Visible = false;
            // ddlprepToeic.Visible = false;
            if (!IsPostBack)
            {


                lblcounttoiec.Text = nbenregtoiec;
                lblcountpreptoiec.Text = nbenregtpreptoiec;

                int nbtoiec = Convert.ToInt32(nbenregtoiec);

                int nbprep = Convert.ToInt32(nbenregtpreptoiec);


                if (nbtoiec < 299 && nbprep < 299)
                {
                    ddlchoix.Visible = true;
                }
                else
                {
                    if (nbtoiec < 299 || nbprep < 299)
                    {
                        if (nbtoiec < 299)
                        {
                            Response.Redirect("~/Enseignants/Inscrit_TOEICenscup.aspx");

                        }
                        else
                        {

                            Response.Write(@"<script language='javascript'>alert('le nombre est atteint 300 candidats au certification toiec,passer preparation');</script>");

                        }
                        if (nbprep < 299)
                        {
                            Response.Redirect("~/Enseignants/Inscrit_TOEIC_PREPenscup.aspx");

                        }
                        else
                        {
                            //Panelfrang.Visible = true;
                            panelprep.Visible = false;
                            //panelmsg.Visible = true;
                            lblprep.Visible = false;
                            //Label2.Text = "le nombre est atteint 300 candidats au test PREPARATION toiec";
                            Response.Write(@"<script language='javascript'>alert('le nombre est atteint 300 candidats au  prep certification toiec,passer certification toiec');</script>");

                        }
                    }

                    else
                    {

                        Panelfrang.Visible = false;
                        Response.Write(@"<script language='javascript'>alert('Session fermée,le nombre est atteint 300 candidats dans les deux certification toiec et preparation toiec');</script>");


                    }
                }


            }
        }











        /*
         * 
         * //if (nbtoiec < 10 && nbprep < 10)
         //{
         //    ddlchoix.Visible = true;
         //    //ddlTOEIC.Visible = false;
         //    //ddlprepToeic.Visible = true;
         //}
         * else
         {
             if (nbtoiec > 10 && nbprep > 10)
             {
                 Response.Write(@"<script language='javascript'>alert('Session fermée,le nombre est atteint 300 candidats dans les deux certification toiec et preparation toiec');</script>");



             }

         }


         if (nbtoiec < 10 && nbprep > 10)
         {
                   
             Response.Write(@"<script language='javascript'>alert('le nombre est atteint 300 candidats au  prep certification toiec,passer certification toiec');</script>");

                   
             Response.Redirect("~/Etudiants/Inscrit_TOEIC.aspx");

            

       
         }
         else
         {
             if (nbtoiec > 10 && nbprep < 10)
             {
                 Response.Write(@"<script language='javascript'>alert('le nombre est atteint 300 candidats au certification toiec,preparer certification toiec');</script>");

                       
                 Response.Redirect("~/Etudiants/Inscrit_TOEIC_PREP.aspx");

             }
                   
         }

               
               

     }




            


 }*/


        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
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
                }
                else
                    if (typechoix == "2")
                    {
                        lbltpd.Text = "Vous êtes inscrit au prep toeic,Bonne chance";
                        plrst.Visible = true;
                        Button1.Visible = false;
                        ddlchoix.Visible = false; paneltoiec.Visible = false;
                        panelprep.Visible = false;
                        lblprep.Visible = false;
                        //lbltoiec.Visible = false;
                        lblchoix.Visible = false;
                    }
                    else
                        if (typechoix == "3")
                        {
                            lbltpd.Text = "Vous êtes inscritdans les deux certifications,Bonne chance";
                            plrst.Visible = true;
                            Button1.Visible = false;
                            ddlchoix.Visible = false;
                            paneltoiec.Visible = false;
                            panelprep.Visible = false;
                            lblprep.Visible = false;

                            lblchoix.Visible = false;
                        }



            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('Vous n\'avez pas le droit de modifier');</script>");
                Panelfrang.Visible = false;

            }
        }



    }


}
