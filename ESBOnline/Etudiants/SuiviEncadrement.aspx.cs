using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;

namespace ESPOnline.Etudiants
{
    public partial class SuiviEncadrement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
       
 
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
           
            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("fr-fr");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture("fr-fr");

            RadGrid1.MasterTableView.NoDetailRecordsText = "No records to display in the Master table";
             
        }
         
 
        bool isGrouping = false;
        protected void RadGrid1_GroupsChanging(object source, GridGroupsChangingEventArgs e)
        {
            isGrouping = true;
            if (e.Action == GridGroupsChangingAction.Ungroup && RadGrid1.CurrentPageIndex > 0)
            {
                isGrouping = false;
            }
        }
 
        public bool ShouldApplySortFilterOrGroup()
        {
            return RadGrid1.MasterTableView.FilterExpression != "" ||
                (RadGrid1.MasterTableView.GroupByExpressions.Count > 0 || isGrouping) ||
                RadGrid1.MasterTableView.SortExpressions.Count > 0;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedIndexes.Count == 0)
                RadGrid1.SelectedIndexes.Add(0);
            //if (RadGrid2.SelectedIndexes.Count == 0)
            //{
            //    RadGrid2.Rebind();
            //    RadGrid2.SelectedIndexes.Add(0);
            //}
        }
         
        protected void RadGrid_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            if (e.Column is GridBoundColumn)
            {
                (e.Column as GridBoundColumn).FilterControlWidth = Unit.Pixel(140);
            }
        }

         
    }
    }
