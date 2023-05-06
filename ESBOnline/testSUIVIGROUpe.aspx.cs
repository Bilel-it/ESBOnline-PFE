using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESPSuiviEncadrement;
using Oracle.ManagedDataAccess.Types;


namespace ESPOnline
{
    public partial class testSUIVIGROUpe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            //ESPSuiviEncadrement.EtudiantClasses.Instance.openconntrans();
            //if (ESPSuiviEncadrement.EtudiantClasses.Instance.statusEtudiantaffecter("05-1MT-036") == true)
            //    Label2.Text = "true";
            //else
            //    Label2.Text = "false";
            //ESPSuiviEncadrement.EtudiantClasses.Instance.closeConnection();
            string me ;
            ESP_PROJET_DETAIL_GROUPE.Instance.openconntrans();
            me = ESP_PROJET_DETAIL_GROUPE.Instance.GetIDProjGroupe("DSI");
            ESP_PROJET_DETAIL_GROUPE.Instance.closeConnection();
            Label2.Text = me;

            

        }
    }
}