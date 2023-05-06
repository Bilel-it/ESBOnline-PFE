using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESPSuiviEncadrement;

namespace ESPOnline.Etudiants
{
    public partial class encadrement : System.Web.UI.Page
    {
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            if (!IsPostBack)
            {

            }
            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.ToString() == "1")
            {
                PanelIndiv.Visible = true;
                PanelGroup.Visible = false;
                Panel3.Visible = false;
                BindEncadrementIndiv(Session["ID_ET"].ToString());

            }
            else if (DropDownList1.SelectedValue.ToString() == "2")
            {
                PanelIndiv.Visible = false;
                PanelGroup.Visible = true;
                BindEncadrementGroupe(Session["ID_ET"].ToString());
                Panel2.Visible = false;
            }
            else
            {
                PanelIndiv.Visible = false;
                PanelGroup.Visible = false;
                Panel3.Visible = false;
                Panel2.Visible = false;
            }
        }


        protected void BindEncadrementIndiv(string i)
        {
            DropDownList2.Items.Clear();
            List<ESP_ENCADDREMENT> ls = new List<ESP_ENCADDREMENT>();
            ls = ESP_ENCADDREMENT.GetProjetEtudiantSuivi(i);
            DropDownList2.DataSource = ls;
            DropDownList2.DataTextField = "NOM_PROJET";
            DropDownList2.DataValueField = "ID_PROJET";
            DropDownList2.DataBind();
            if(DropDownList2.Items.Count ==0)
                DropDownList2.Items.Insert(0, new ListItem("N/A", "0"));
            else
                DropDownList2.Items.Insert(0, new ListItem("Choisir", "0"));            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedItem.ToString() != "Choisir")
            {
                Panel2.Visible = true;
                Panel3.Visible = false;
            }
            else
            {
                Panel3.Visible = true;
                Panel2.Visible = false;
            }
        }


        protected void BindEncadrementGroupe(string i)
        {
            DropDownList3.Items.Clear();
            List<recherchePROJET> ls = new List<recherchePROJET>();
            ls = recherchePROJET.GetProjetEtudiantSuiviparGroupe(i);
            DropDownList3.DataSource = ls;
            DropDownList3.DataTextField = "NOM_PROJET";
            DropDownList3.DataValueField = "ID_GROUPE_PROJET";
            DropDownList3.DataBind();
            if (DropDownList3.Items.Count == 0)
                DropDownList3.Items.Insert(0, new ListItem("N/A", "0"));
            else
                DropDownList3.Items.Insert(0, new ListItem("Choisir", "0"));
        }

       

        protected void DropDownList3_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedItem.ToString() == "Choisir")
            {
                Panel3.Visible = false;
                LinkButton1.Visible=false;
            }
            else
            {
                Panel3.Visible = true;
                LinkButton1.Visible=true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
             Label5.Text = DropDownList3.SelectedItem.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalSuiviGroupe();", true);
        }
        
    }
}