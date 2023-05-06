using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ESPOnline.EmploiEsp
{
    public partial class Grid_emploi : System.Web.UI.Page
    {
        ServiceEDT emploi = new ServiceEDT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            BINDeNSnONdISpo();
            

        }
        public void BINDeNSnONdISpo()
      {

          Gridbord.DataSource = emploi.BindListensIndispo();
            Gridbord.DataBind();

      }
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GrdSalle_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {

        }


        protected void GrdEmpData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridbord.EditIndex = e.NewEditIndex;
            //bind grid
            BINDeNSnONdISpo();

        }

        protected void GrdEmpData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting Grid to non editable mode
            Gridbord.EditIndex = -1;
            //Rebind Grid
            BINDeNSnONdISpo();
        }
        protected void GrdEmpData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }


    }
}