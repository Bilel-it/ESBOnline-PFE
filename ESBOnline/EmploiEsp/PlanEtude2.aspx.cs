using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using ESPSuiviEncadrement;
using Telerik.Web.UI;
using BLL;

namespace ESPOnline.EmploiEsp
{
    public partial class PlanEtude2 : System.Web.UI.Page
    {
        ServiceEDT salle = new ServiceEDT();
        string x;
        string y;
        string z;
        public string idmodule;
        public string anneedeb;
        OracleTransaction myTrans;
        public OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            x = Session["UP"].ToString().Trim();
            y = Session["Nom_ENS"].ToString().Trim();
            z = Session["ID_ENS"].ToString().Trim();
            //  anneedeb = DAL.AffectationDAO.Instance.getanneedeb();

            if (!IsPostBack)
            {
            
            }
        }
        public void bindgrid()
        {

            RadGrid1.DataSource = salle.getEnsIndispo(ddlnomenseig.SelectedValue);
            RadGrid1.DataBind();
        }
        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem filteringItem = e.Item as GridFilteringItem;
                //set dimensions for the filter textbox  
                TextBox box = filteringItem["CODE_MODULE"].Controls[0] as TextBox;
                box.Height = Unit.Pixel(30);
                TextBox box2 = filteringItem["DESIGNATION"].Controls[0] as TextBox;
                box2.Height = Unit.Pixel(30);
                //TextBox box3 = filteringItem["NUM_SEMESTRE"].Controls[0] as TextBox;
                //box3.Height = Unit.Pixel(30);

            }
        }
       
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedIndexes.Count == 0)
                RadGrid1.SelectedIndexes.Add(0);
          
        }
        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {
        }
        

       
    }
}