using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Enseignants
{
    public partial class SuivieEval : System.Web.UI.Page
    {
        string NOM_ENS;
        string ID_ENS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            ID_ENS = Session["ID_ENS"].ToString();
            NOM_ENS = Session["NOM_ENS"].ToString();  
        }
    }
}