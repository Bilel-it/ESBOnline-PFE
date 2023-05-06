using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.EmploiEsp
{
    public partial class EnsDispo : System.Web.UI.Page
    {
        ServiceEDT salle = new ServiceEDT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null || Session["PWD_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            lbl.Text = "Bienvenue " + Session["NOM_DECID"] as string;   
            if (!IsPostBack)
            {
                BindEnseignants();
                bindNUMS1();
                bindNUMS2();
                panelgrid.Visible = false;
                 lblanneedeb.Text = salle.getANNEEDEB();
            lblsemestre.Text = salle.getNUMSemestre();
            lblanneefin.Text = salle.getAnneeFiN();
            }

        }

        public void bindNUMS1()
        {
            DdlNumSeance1.DataTextField = "LIB_NOME";
            DdlNumSeance1.DataValueField = "CODE_NOME";
            DdlNumSeance1.DataSource = salle.BindNumSeanceBYNnmclature();
            DdlNumSeance1.DataBind();
        }

        public void bindNUMS2()
        {
            DdlNumSeance2.DataTextField = "LIB_NOME";
            DdlNumSeance2.DataValueField = "CODE_NOME";
            DdlNumSeance2.DataSource = salle.BindNumSeanceBYNnmclature();
            DdlNumSeance2.DataBind();

        }

        protected void add_Click(object sender, EventArgs e)
        {
            try
            {
                string id_ens = Session["ID_ENS"] as string;
                string jours = txtdebutDate.Text;
                int h_debut = int.Parse(DdlNumSeance1.SelectedValue);
                int h_fin = int.Parse(DdlNumSeance2.SelectedValue);


                salle.VerifDispo(lblanneedeb.Text, ddlnomenseig.SelectedValue, jours, h_debut, h_fin);
                Response.Write(@"<script language='javascript'>alert('Verification avec succès');</script>");
            }
            catch (Exception)
            {
                Response.Write(@"<script language='javascript'>alert('Erreur de serveur');</script>");
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdebutDate_PopupControlExtender1.Commit(Calendar1.SelectedDate.ToShortDateString());
            //this.txtdebutDate.Text = Calendar1.SelectedDate.ToString();
        }
        public void BindEnseignants()
        {

            ddlnomenseig.DataTextField = "NOM_ENS";
            ddlnomenseig.DataValueField = "ID_ENS";
            ddlnomenseig.DataSource = salle.getEns();
            ddlnomenseig.DataBind();

        }
        protected void DdlNumSeance1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Label1.Text = DdlNumSeance1.SelectedValue;
        }


        protected void btngrid_Click(object sender, EventArgs e)
        {

            panelgrid.Visible = true;
            GridIndispo.DataSource = salle.GETdispo();
                GridIndispo.DataBind();

            }
        }
    }

