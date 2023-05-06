 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.Enseignants
{
    public partial class Fiche_niv_moins_b2_2015 : System.Web.UI.Page
    {
        LangueService service = new LangueService();
        string id_ens;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (ddlannee_debM.SelectedValue != null)
            {
                id_ens = Session["ID_ENS"].ToString();
                ddclasse2.DataTextField = "code_cl";
                ddclasse2.DataValueField = "code_cl";
                ddclasse2.DataSource = service.bind_classes_1516(id_ens, ddlannee_debM.SelectedValue);
                ddclasse2.DataBind();

                ddclasse2.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
                ddclasse2.SelectedItem.Selected = false;
                ddclasse2.Items.FindByText("Veuillez choisir").Selected = true;
            }
        }

        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridView1.DataSource = service.fiche_niveau_langue_moins_B2(ddclasse2.SelectedValue, ddlannee_debM.SelectedValue);
            GridView1.DataBind();
            GridView1.Visible = true;
        }

       
    }
}