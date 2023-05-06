using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.Etudiants
{
    public partial class Toiec_preptoiec : System.Web.UI.Page
    {
        string id_et;
        ToiecService service = new ToiecService();
        string ID_ET;

        string veriflabeltoeic;
        string veriflabelprepTOEIC;
        string nbenregtoiec;
        string nbenregtpreptoiec;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            lblanneedeb.Text = service.getANNEEDEBs();

            lblanneefin.Text = service.getAnneeFiN();
            id_et = Session["ID_ET"].ToString();
            //nbenregtoiec = service.countNBTOIEC();
            //nbenregtpreptoiec = service.countNBPREPTOIEC();
             nbenregtoiec = service.countNB_TOIEC();
             nbenregtpreptoiec = service.countNBPrep_TOIEC();
            panelmsg.Visible = false;
            if (!IsPostBack)
            {
                lblcountpreptoiec.Text = nbenregtpreptoiec;

                lblcounttoiec.Text = nbenregtoiec;

                int nbtoiec = Convert.ToInt32(nbenregtoiec);

                int nbprep = Convert.ToInt32(nbenregtpreptoiec);

                if (nbtoiec < 5 && nbprep < 5)
                {
                    Panelfrang.Visible = true;
                }

                if (nbtoiec < 5 || nbprep < 5)
                {
                    if (nbtoiec < 5)
                    {
                        paneltoiec.Visible = true;
                        Panelfrang.Visible = true;
                    }
                    else
                    {
                        paneltoiec.Visible = false;
                        chkTOIEC.Enabled = false;
                        //Panelfrang.Visible = true;
                        panelmsg.Visible = true;
                        lblchoix.Visible = false;
                        // Label2.Text = "le nombre est atteint 300 candidats au test toiec";
                        Response.Write(@"<script language='javascript'>alert('le nombre est atteint 300 candidats au certification toiec,passer preparation');</script>");

                    }

                    if (nbprep < 5)
                    {
                        panelprep.Visible = true;
                        Panelfrang.Visible = true;

                    }
                    else
                    {
                        //Panelfrang.Visible = true;
                        panelprep.Visible = false;
                        panelmsg.Visible = true;
                        lblprep.Visible = false;
                        //Label2.Text = "le nombre est atteint 300 candidats au test PREPARATION toiec";
                        Response.Write(@"<script language='javascript'>alert('le nombre est atteint 300 candidats au  prep certification toiec,passer certification toiec');</script>");

                    }

                }






                else
                {
                    panelmsg.Visible = false;
                    Panelfrang.Visible = false;
                    Response.Write(@"<script language='javascript'>alert('Session fermée,le nombre est atteint 300 candidats dans les deux certification toiec et preparation toiec');</script>");


                }
                

              
                //panelmsg.Visible = false;
                //Response.Write(@"<script language='javascript'>alert('Session fermée,le nombre est atteint 300 candidats dans les deux test toiec et preparation toiec');</script>");
                
            }



             }

            
               
       

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (chkTOIEC.Checked)
            {
                service.UpdatETOIC(id_et);
                lbltoiec.Text = "Vous êtes inscrit au certification toeic";
                paneltoiec.Visible = false;
                Panelfrang.Visible = false;
                panelmsg.Visible = true;
                
            }
            else
            {
                service.UpdatETOICToNo(id_et);
                lbltoiec.Text = "Vous n'êtes pas inscrit au certification toeic";
                
                paneltoiec.Visible = false;
                Panelfrang.Visible = false;
                panelmsg.Visible = true;
            }

            
            if (chkprepTOIEC.Checked)
            {
                //service.UpdatEPREPTOIC(id_et, lblanneedeb.Text);
                lblpreptoiec.Text = "Vous êtes inscrit au prep certification toeic";
                //plrep.Visible = true;
               // paneltest.Visible = false;
                panelprep.Visible = false;
                Panelfrang.Visible = false;
                panelmsg.Visible = true;
              
            }
            else
            {
                //service.UpdatEPREPTOICTONo(id_et, lblanneedeb.Text);
                lblpreptoiec.Text = "Vous n'êtes pas inscrit au prep certification toeic";
                //plrep.Visible = true;
                //paneltest.Visible = false;
                panelprep.Visible = false;
              
                panelmsg.Visible = true;
                Panelfrang.Visible = false;
             
            }

        }

    }
    }
