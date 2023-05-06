using soc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Administration
{
    public partial class Administration : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Bienvenue " + Session["NOM_decid"].ToString().Trim();
            ANNEEUN.Text = Societe.Instance.ANNEE().ANNEE_DEB + "/" + Societe.Instance.ANNEE().ANNEE_FIN;

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Online/Accueil.aspx");
        }
    }
}