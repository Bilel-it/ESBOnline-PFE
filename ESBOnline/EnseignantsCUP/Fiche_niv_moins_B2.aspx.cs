using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Fiche_niv_moins_B2 : System.Web.UI.Page
    {
        LangueService service = new LangueService();
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
        }

        protected void ddlannee_deb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bind le niveau de la classe
            if (ddlannee_deb.SelectedValue != null)
            {
                ddlniv.DataTextField = "niveau";
                ddlniv.DataValueField = "niveau";
                ddlniv.DataSource = service.bind_niveau_1516(ddlannee_deb.SelectedValue);
                ddlniv.DataBind();
            }
        }

        protected void ddlniv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlniv.SelectedValue != null)
            {
                ddclasse.DataTextField = "code_cl";
                ddclasse.DataValueField = "code_cl";

                ddclasse.DataSource = service.bind_classes_parniv(ddlniv.SelectedValue, ddlannee_deb.SelectedValue);
                ddclasse.DataBind();

                ddclasse.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
                ddclasse.SelectedItem.Selected = false;
                ddclasse.Items.FindByText("Veuillez choisir").Selected = true;
            }
        }

        protected void ddclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = service.fiche_niveau_langue_moins_B2(ddclasse.SelectedValue, ddlannee_deb.SelectedValue);
            GridView1.DataBind();
            GridView1.Visible = true;
        }
    }
}