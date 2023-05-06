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
    public partial class Generation_Emp_temps : System.Web.UI.Page
    {
        ServiceEDT salle = new ServiceEDT();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblanneedeb.Text = salle.getANNEEDEB();
            lblsemestre.Text = salle.getNUMSemestre();
            lblanneefin.Text = salle.getAnneeFiN();
            if (!IsPostBack)
            {

                
                BindModule();
                BindSalle();
                BindEnseignants();
                BindClasse();

            }
        }
        public void BindClasse()
        {
            ddlcodclasse.DataTextField = "CODE_CL";
            ddlcodclasse.DataValueField = "CODE_CL";
            ddlcodclasse.DataSource = salle.BindClasspe();
            ddlcodclasse.DataBind();

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
            ddlSalle.DataTextField = "SALLE_PRINCIPALE";
            ddlSalle.DataValueField = "SALLE_PRINCIPALE";
            ddlSalle.DataSource = salle.getAllClass();
            ddlSalle.DataBind();

        }

        public void BindModule()
        {

            ddlmodule.DataTextField = "DESIGNATION";
            ddlmodule.DataValueField = "CODE_MODULE";
            ddlmodule.DataSource = salle.getAllModule();
            ddlmodule.DataBind();

        }

       

        protected void ddlcodclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
            if (ddlcodclasse.SelectedValue != null)
            {
                
               
                ddlSalle.SelectedValue = salle.getsalleBycode(ddlcodclasse.SelectedValue);

                ddlnomenseig.DataSource = salle.getENsBymoD(ddlcodclasse.SelectedValue);
                ddlnomenseig.DataBind();
                ddlnomenseig.Items.Insert(0, new ListItem("--choisir Enseignant--", "0"));
                ddlmodule.DataSource = salle.getMODULEBY(ddlcodclasse.SelectedValue);
                ddlmodule.DataBind();
            }

        }
        protected void DdlNumSeance1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s;
            Label1.Text = DdlNumSeance1.SelectedValue;
           // s=DdlNumSeance1.Text;
        }

        protected void DdlNumSeance2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label2.Text = DdlNumSeance2.SelectedValue;
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        public void bindgrid()
        {

            Gridbord.DataSource = salle.getEnsIndispo(ddlnomenseig.SelectedValue);
            Gridbord.DataBind();
        }

        protected void ddlnomenseig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlnomenseig.SelectedValue != null && ddlcodclasse.SelectedValue != null)
            {
                ddlmodule.DataSource = salle.BindMODULEByEns(ddlnomenseig.SelectedValue, ddlcodclasse.SelectedValue);
                ddlmodule.DataBind();
                lblnomens.Text = ddlnomenseig.DataTextField;
                ddlmodule.Items.Insert(0, new ListItem("--Choisir Module--", "0"));
                bindgrid();


            }
        }
        protected void btnaddEMP_Click(object sender, EventArgs e)
        {
            dt.TableName = "ESP_AFFECTATION_EMPLOI";
            dt = salle.getEnsIndisponible(ddlcodclasse.SelectedValue, ddlnomenseig.SelectedValue, ddlmodule.SelectedValue, Convert.ToDateTime(txtdebutDate.Text), Convert.ToInt32(DdlNumSeance1.SelectedValue), Convert.ToInt32(DdlNumSeance2.SelectedValue), ddlSalle.SelectedValue);

            //dt2.TableName = "ESP_AFFECTATION_EMPLOI";
            //dt2 = salle.getdispojours(ddljours.SelectedValue, DdlNumSeance1.SelectedValue, DdlNumSeance2.SelectedValue,ddlnomenseig.SelectedValue);
            try
            {
                if (dt.Rows.Count == 0)
                {
                    
                    salle.Enre_Affect_emploi(lblanneedeb.Text, ddlcodclasse.SelectedValue, ddlmodule.SelectedValue, ddlnomenseig.SelectedValue, ddlSalle.SelectedValue, Convert.ToDateTime(txtdebutDate.Text), int.Parse(DdlNumSeance1.SelectedValue), int.Parse(DdlNumSeance2.SelectedValue));
                    Response.Write(@"<script language='javascript'>alert(' Enseignant Enregistré avec succès');</script>");
                }

                else
                {
                    Response.Write(@"<script language='javascript'>alert('Place indisponible!!!');</script>");

                }
            }
            catch(Exception)
            {
             Response.Write(@"<script language='javascript'>alert('Erreur de serveur');</script>");
            }
        }


        protected void ddlmodule_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbnheures.Text = salle.GetnbHr(ddlcodclasse.SelectedValue,ddlmodule.SelectedValue);
        }



        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            txtdebutDate_PopupControlExtender1.Commit(Calendar1.SelectedDate.ToShortDateString());
        }
    }

}
