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
   
    public partial class GenerationEDT : System.Web.UI.Page
    {
        ServiceEDT service = new ServiceEDT();
       
        DataTable dt = new DataTable();
        public void getAllenseign()
        {
            ddlEns.DataTextField = "NOM_ENS";
            ddlEns.DataValueField = "NOM_ENS";
            ddlEns.DataSource = service.getAllenseign();
            ddlEns.DataBind();
            ddlEns.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
            ddlEns.SelectedItem.Selected = false;
            ddlEns.Items.FindByText("--Select One--").Selected = true;
        }
        private void getnumSemestre()
        {
            ddlSemestre.DataTextField = "NUM_SEMESTRE";
            ddlSemestre.DataValueField = "NUM_SEMESTRE";

            ddlSemestre.DataSource = service.getnumSemestre();
            ddlSemestre.DataBind();
            ddlSemestre.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
            ddlSemestre.SelectedItem.Selected = false;
            ddlSemestre.Items.FindByText("--Select One--").Selected = true;
        }
        public DataTable getAllClasses()
        {
            ddlclasse.DataTextField = "CODE_CL";
            ddlclasse.DataValueField = "CODE_CL";
            dt = service.getAllClasses();
            ddlclasse.DataSource = dt;
            ddlclasse.DataBind();
            ddlclasse.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
            ddlclasse.SelectedItem.Selected = false;
            ddlclasse.Items.FindByText("--Select One--").Selected = true;
            return dt;
        }
        //public void getSalle()
        //{
        //    ddlsalleP.DataTextField = "SALLE";
        //    ddlsalleP.DataValueField = "SALLE";
        //    ddlsalleP.DataSource = service.getSalle();
        //    ddlsalleP.DataBind();
        //    ddlsalleP.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
        //    ddlsalleP.SelectedItem.Selected = false;
        //    ddlsalleP.Items.FindByText("--Select One--").Selected = true;

            
        //}

        public DataTable getModule()
        {
           
            ddlmodule.DataTextField = "DESIGNATION";
            ddlmodule.DataValueField = "DESIGNATION"; 
            dt= service.getAllModule();
            ddlmodule.DataSource = dt;
            ddlmodule.DataBind();
            ddlmodule.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
            ddlmodule.SelectedItem.Selected = false;
            ddlmodule.Items.FindByText("--Select One--").Selected = true;

            return dt;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAllenseign();
                getAllClasses();
                getModule();
                //getSalle();
                getnumSemestre();
            }
        }

        protected void btnValider_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlclasse.SelectedValue != null)
            {
                this.ddlsalleP.SelectedValue.ToString();
            }
        }

        protected void ddlsalleP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

}
}