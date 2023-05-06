using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.EmploiEsp
{
    public partial class DefaultMBOX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

        }
        protected void Success_Click(object sender, EventArgs e)
        {
            MessageBox1.ShowSuccess("Ajout avec succèes.", 5000);
        }

        protected void Error_Click(object sender, EventArgs e)
        {
            MessageBox2.ShowError("Erreur,Vérifier la séance entrée .", 5000);
        }

        protected void Warning_Click(object sender, EventArgs e)
        {
            MessageBox1.ShowWarning("WARNING.", 5000);
        }

        protected void Information_Click(object sender, EventArgs e)
        {
            MessageBox2.ShowInfo("INFORMATION", 5000);
        }
    }
}