using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.EmploiEsp
{
    public partial class GestionSalleClasse : System.Web.UI.Page
    {
        ServiceEDT salle = new ServiceEDT();
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)

                FillSalle();
        }

        public void FillSalle()
        {

            //Gridsalle.DataSource = salle.getSalleClasse();
            //Gridsalle.DataBind();

        }
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridsalle.PageIndex = e.NewPageIndex;
            Gridsalle.DataBind();
            FillSalle();
        }

        protected void GrdSalle_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {

        }

        public void Delete_esp_salle(decimal _ID)
        {
            salle.Delete_esp_salle(_ID);
        }


        protected void GrdEmpData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Gridsalle.EditIndex = e.NewEditIndex;
            ////bind grid
            //FillSalle();

            //DropDownList ddlsalleCours = Gridsalle.Rows[e.NewEditIndex].FindControl("ddlsalle") as DropDownList;
            //ddlsalleCours.DataTextField = "SALLE";
            //ddlsalleCours.DataValueField = "SALLE";
            //ddlsalleCours.DataSource = salle.getSalleClasse();
            //ddlsalleCours.DataBind();
            //ddlsalleCours.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
            //ddlsalleCours.SelectedItem.Selected = false;
            //ddlsalleCours.Items.FindByText("--Select One--").Selected = true;

            //DropDownList ddlcodeclasse = Gridsalle.Rows[e.NewEditIndex].FindControl("ddlcodecl") as DropDownList;
            //ddlcodeclasse.DataTextField = "CODE_CL";
            //ddlcodeclasse.DataValueField = "CODE_CL";
            //ddlcodeclasse.DataSource = salle.getSalleClasse();
            //ddlcodeclasse.DataBind();
            //ddlcodeclasse.Items.Insert(0, new ListItem("--Select One--","--Select One--"));
            //ddlcodeclasse.SelectedItem.Selected = false;
            //ddlcodeclasse.Items.FindByText("--Select One--").Selected = true;

        }

        protected void GrdEmpData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting Grid to non editable mode
            Gridsalle.EditIndex = -1;
            //Rebind Grid
            FillSalle();
        } 

        protected void GrdEmpData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblIDsalles = (Label)Gridsalle.Rows[e.RowIndex].FindControl("lblIDsalle");
             DropDownList ddlcodecls = (DropDownList)Gridsalle.Rows[e.RowIndex].FindControl("ddlcodecl"); 
            DropDownList ddlsalles = (DropDownList)Gridsalle.Rows[e.RowIndex].FindControl("ddlsalle");
            float id = float.Parse(lblIDsalles.Text);
            if (ddlcodecls != null && ddlsalles != null)

            salle.UpdateSalle(ddlcodecls.SelectedValue, ddlsalles.Text,id);
            Gridsalle.EditIndex = -1;
            //Rebind Grid
            FillSalle();
        }
    }
}