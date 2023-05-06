using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace ESPOnline.EmploiEsp
{
    public partial class GestionCours : System.Web.UI.Page
    {
        ServiceEDT salle = new ServiceEDT();
        public string sallecours;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillEnseignant();
        }
        public void FillEnseignant()
        {
            Gridens.DataSource = salle.getListeEnseigant();
            Gridens.DataBind();
        }
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridens.PageIndex = e.NewPageIndex;
            Gridens.DataBind();
            FillEnseignant();
        }
        protected void btnOK_Click1(object sender, ImageClickEventArgs e)
        {
            FillEnseignant();
        }



        protected void GrdEmpData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridens.EditIndex = e.NewEditIndex;
            //bind grid
            FillEnseignant();

            DropDownList ddlsalleCours = Gridens.Rows[e.NewEditIndex].FindControl("ddlsalle") as DropDownList;
            ddlsalleCours.DataTextField = "SALLE";
            ddlsalleCours.DataValueField = "SALLE";
            ddlsalleCours.DataSource = salle.getSalleClasse();
            ddlsalleCours.DataBind();
            ddlsalleCours.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
            ddlsalleCours.SelectedItem.Selected = false;
            ddlsalleCours.Items.FindByText("--Select One--").Selected = true;

            DropDownList ddlcodemodules = Gridens.Rows[e.NewEditIndex].FindControl("ddlcodemodule") as DropDownList;
            ddlcodemodules.DataTextField = "DESIGNATION";
            ddlcodemodules.DataValueField = "DESIGNATION";
            ddlcodemodules.DataSource = salle.getAllModule();
            ddlcodemodules.DataBind();
            ddlcodemodules.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
            ddlcodemodules.SelectedItem.Selected = false;
            ddlcodemodules.Items.FindByText("--Select One--").Selected = true;

            DropDownList ddlcodeclasse = Gridens.Rows[e.NewEditIndex].FindControl("ddlcodclasse") as DropDownList;
            ddlcodeclasse.DataTextField = "CODE_CL";
            ddlcodeclasse.DataValueField = "CODE_CL";
            ddlcodeclasse.DataSource = salle.getSalleClasse();
            ddlcodeclasse.DataBind();
            ddlcodeclasse.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
            ddlcodeclasse.SelectedItem.Selected = false;
            ddlcodeclasse.Items.FindByText("--Select One--").Selected = true;

        }

        protected void GrdEmpData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting Grid to non editable mode
            Gridens.EditIndex = -1;
            //Rebind Grid
            FillEnseignant();
        }

        protected void GrdEmpData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


        }

        protected void Grdenseig_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            //    DropDownList ddlnom = (DropDownList)Gridens.Rows[e.RowIndex].FindControl("ddlnomenseig");
            //    string idens = Gridens.DataKeys[e.RowIndex].Value.ToString();
            //    //DeleteAbonneService.ServiceGestionDesAbonnés delete = new DeleteAbonneService.ServiceGestionDesAbonnés();

            //    if (idens != null)
            //    {
            //        idens = ddlnom.SelectedValue;
            //        salle.DeleteEnseig(ddlnom.SelectedValue);
            //        FillEnseignant();

        }


    }
}
