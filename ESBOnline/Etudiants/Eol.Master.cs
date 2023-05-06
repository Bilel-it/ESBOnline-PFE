using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace ESPOnline
{
    public partial class Eol : System.Web.UI.MasterPage
    {
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        string ADRESSE_MAIL_ESP;
        string CODE_CL;
        ToiecService service = new ToiecService();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Session["motdepasse"].ToString() == Log.Instance.loginPWDnomenclature())
                { ; Response.Redirect("~/Etudiants/reset_pwd.aspx"); }


                if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
                {
                    Response.Redirect("~/Online/default.aspx");
                }
            EncadrementDAO dt = EncadrementDAO.Instance;
            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
          CODE_CL = Session["CODE_CL"].ToString();
           
            
           
            Label2.Text = PRENOM_ET + " " + NOM_ET;
          Label3.Text = DAL.ResctsDAO.Instance.returnCL(ID_ET); 
           // string nivetudiantang = service.selectniVeauEDTANG(ID_ET);
            
        }
         
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Online/Accueil.aspx");
        }

        protected void clickbtn_Click(object sender, EventArgs e)
        {

            string id_etud = Session["ID_ET"].ToString();
            string codecl = service.returnCLSUPP(id_etud);

            //bool exist=service.verifexistet();
            DataTable dt;
            dt = service.Aff_list_inscrit(id_etud);
            //string veriflabelprepTOEIC = service.selectEtatTPREPTOIEC(id_etud);
            string nivetudiantang = service.selectniVeauEDTANG(id_etud);
            string nivetudiantfr = service.selectniVeauEDTFR(id_etud);
            if (dt.Rows.Count != 0)
            {
                Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit,mais tu peux modifier votre choix');</script>");
                Response.Redirect("~/Etudiants/Toeic_modif.aspx");
            }
            else
            {
                if (codecl.StartsWith("5") || codecl.StartsWith("4"))
                {
                    if (nivetudiantang == "A1")
                    {

                        Response.Write(@"<script language='javascript'>alert('Votre niveau d\'anglais est A1');</script>");
                    }



                    else
                    { 
                        Response.Redirect("~/Etudiants/Toeic_etudiant.aspx");
                    }



                }

                else
                {
                    Response.Write(@"<script language='javascript'>alert('Sauf les classes de 5 ème et de 4 ème année ont le droit de passer le test');</script>");

                }

            }


        }
     

    }
}