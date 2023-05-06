using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace ESPOnline.EmploiEsp
{
    public partial class PopUpAjoutEmploi : System.Web.UI.Page
    {
        ServiceEDT salle = new ServiceEDT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindModule();
                BindSalle();
                BindEnseignants();
                BindClasse();
            }
        }
        public void BindEnseignants()
        {
            ddlnomenseig.DataTextField = "NOM_ENS";
            ddlnomenseig.DataValueField = "ID_ENS";
            ddlnomenseig.DataSource = salle.getEns();
            ddlnomenseig.DataBind();
        }
        public void BindSalle()
        {
            ddlSalle.DataTextField = "SALLE";
            ddlSalle.DataValueField = "SALLE";
            ddlSalle.DataSource = salle.getSalleClasse();
            ddlSalle.DataBind();
           
        }

        public void BindModule()
        {

            ddlmodule.DataTextField = "DESIGNATION";
            ddlmodule.DataValueField = "CODE_MODULE";
            ddlmodule.DataSource = salle.getAllModule();
            ddlmodule.DataBind();

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdebutDate_PopupControlExtender1.Commit(Calendar1.SelectedDate.ToShortDateString());
            //this.txtdebutDate.Text = Calendar1.SelectedDate.ToString();
        }


        public void BindClasse()
        {
            ddlcodclasse.DataTextField = "CODE_CL";
            ddlcodclasse.DataValueField = "CODE_CL";
            ddlcodclasse.DataSource = salle.getSalleClasse();
            ddlcodclasse.DataBind();
            
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateD = Convert.ToDateTime(txtdebutDate.Text);
                DataTable dt = salle.GETiNDSPObYid(ddlnomenseig.SelectedValue);
                bool testAdd = true;
                foreach (DataRow DRow in dt.Rows)
                {
                    DateTime jour = Convert.ToDateTime(DRow["JOURS_SEANCE"].ToString());
                    int heuredebp = int.Parse(DRow["HEURE_DEBUT"].ToString());
                    int heurefinp = int.Parse(DRow["HEURE_FIN"].ToString());
                    int heuredeb = int.Parse(txthd.Text);
                    int heuredef = int.Parse(txthf.Text);
                    if (jour == dateD)
                    {
                        if ((heuredeb >= heuredebp && heuredef <= heurefinp) || (heuredeb <= heurefinp && heuredef >= heurefinp) || (heuredeb <= heuredebp && heuredef >= heuredebp))
                        {
                            testAdd = false;
                            break;
                        }
                    }
                }
                if (testAdd)
                {
                    salle.AjouterEmploi(txtcode.Text, ddlType.SelectedValue, ddlnomenseig.SelectedValue, int.Parse(txthd.Text), int.Parse(txthf.Text), dateD, ddlSalle.SelectedValue, ddlmodule.SelectedValue, ddlcodclasse.SelectedValue, int.Parse(TextminE.Text), int.Parse(TextminS.Text));
                    Response.Write(@"<script language='javascript'>alert('Ajout avec succès');</script>");
                }
                else 
                {
                    Response.Write(@"<script language='javascript'>alert('Le professeur est indisponible dans cette période');</script>");
                }

            }
            catch (Exception)
            {

                Response.Write(@"<script language='javascript'>alert('erreur du server ');</script>");
            }
        }


        protected void btnRemove_Click(object sender, EventArgs e)
        {
            txtcode.Text = "";
            ddlType.Text = "";
            ddlmodule.Text = "";
            ddlcodclasse.Text = "";
            ddlnomenseig.Text = "";
            txthd.Text = "";
            txthf.Text = "";
            TextminE.Text = "";
            TextminS.Text = "";

        }

        protected void ddlcodclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
            if (ddlcodclasse.SelectedValue != null)
            {
                //salle.getsalleBycode(ddlcodclasse.SelectedValue);
                //this.ddlSalle.Text.ToString();
                 ddlSalle.SelectedValue = salle.getsalleBycode(ddlcodclasse.SelectedValue).ToString();
                //ddlSalle.DataSource = salle.getsalleBycode(ddlcodclasse.SelectedValue);
                //ddlSalle.DataBind();
            }
        }

        protected void ddlmodule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlmodule.SelectedValue!=null)
            {
                ddlnomenseig.DataSource = salle.getENsBymoD(ddlmodule.SelectedValue);
                ddlnomenseig.DataBind();
            }
        }

       
    }
}