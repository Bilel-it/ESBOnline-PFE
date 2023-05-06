using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Modif_Niv_Langue_2015 : System.Web.UI.Page
    {
        StatService service = new StatService();
        string id_ens;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            if (!IsPostBack)
            {
                 bind_niv_etud();
                 id_ens = Session["ID_ENS"].ToString()  ;
               //  bind();
                 Gridstudent.Visible = false;
            }
        }


        public void bind_niv_etud()
        { 
                     ddlniv.DataTextField = "niveau";
                    ddlniv.DataValueField = "niveau";
                    ddlniv.DataSource = service.bind_niveau_1516();
                    ddlniv.DataBind();
        }

        protected void ddlniv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlniv.SelectedValue.ToString() != null)
            {
                ddclasse.DataTextField = "code_cl";
                ddclasse.DataValueField = "code_cl";

                ddclasse.DataSource = service.bind_classes_1516(ddlniv.SelectedValue);
               
                ddclasse.DataBind();

                ddclasse.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
                ddclasse.SelectedItem.Selected = false;
                ddclasse.Items.FindByText("Veuillez choisir").Selected = true;
                

            } 
        }

        protected void ddclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddclasse.SelectedValue != null)
            {
                ddlnomENS.DataTextField = "NOM";
                ddlnomENS.DataValueField = "NOM";

                ddlnomENS.DataSource = service.bind_Nom_Ens(ddclasse.SelectedValue);
                // ddlsite.Items.Add(new ListItem("Veuillez choisir un site", "0"));
                ddlnomENS.DataBind();
               
            }
        }

        protected void ddlnomENS_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
           // string sof = lblident.Text;
            //if (ddlnomENS.SelectedValue != null)
            //{
            //    txtidet.Text = service.Return_id_et(ddclasse.SelectedValue, ddlnomENS.SelectedValue);
            //}

            if (ddlnomENS.SelectedValue != null)
            {
                Gridstudent.Visible = true;
                bind();

            }
        }
     //editer et modifier le niveau
        protected void GrdEmpData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridstudent.EditIndex = e.NewEditIndex;
            //Rebind Grid
            bind();
            DropDownList ddlnIV_fr = Gridstudent.Rows[e.NewEditIndex].FindControl("ddlniveau_etud") as DropDownList;
            ddlnIV_fr.DataTextField = "NIV_ACQUIS_FRANCAIS";
            ddlnIV_fr.DataValueField = "NIV_ACQUIS_FRANCAIS";
            ddlnIV_fr.DataSource = service.bind_list_niveau();
            ddlnIV_fr.DataBind();
            ddlnIV_fr.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
            ddlnIV_fr.SelectedItem.Selected = false;
            ddlnIV_fr.Items.FindByText("Veuillez choisir").Selected = true;

        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridstudent.PageIndex = e.NewPageIndex;
           // Gridstudent.DataBind();
            bind();

        }

        //protected void OnRowCancelingEdit(object sender, EventArgs e)
        //{
           
        //    Gridstudent.EditIndex = -1;
        //    this.bind();
        //}
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
           
            //switch back to default mode
           
            Gridstudent.EditIndex = -1;
            //Bind the grid
            bind();
        }

        protected void GrdEmpData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            id_ens = Session["ID_ENS"].ToString();

            Label lblId = (Label)Gridstudent.Rows[e.RowIndex].FindControl("lblId");
          
            DropDownList ddlniv_fr = (DropDownList)Gridstudent.Rows[e.RowIndex].FindControl("ddlniveau_etud");
            service.Update_niv_etud(lblId.Text, ddlniv_fr.SelectedValue,id_ens);
            Gridstudent.EditIndex = -1;
            bind();

        }

        public void bind()
        {
            Gridstudent.DataSource = service.bind_niveau_ang_et(ddlnomENS.SelectedValue, ddclasse.SelectedValue);
            Gridstudent.DataBind();
        }

    }
}