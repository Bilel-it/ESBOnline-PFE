using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.EmploiEsp
{
    public partial class Affichedispo : System.Web.UI.Page
    {
        ServiceEDT salle = new ServiceEDT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEnseignants();
            }
        }
        public void BindEnseignants()
        {
            ddlnomenseig.DataTextField = "NOM_ENS";
            ddlnomenseig.DataValueField = "ID_ENS";
            ddlnomenseig.DataSource = salle.getEns();
            ddlnomenseig.DataBind();
           
        }

       

        protected void ddlnomenseig_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
    HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
            if (ddlnomenseig.SelectedValue != null)
            {
                GridIndispo.DataSource = salle.GETiNDSPObYid(ddlnomenseig.SelectedValue);
                GridIndispo.DataBind();
              }
        }
    }
}