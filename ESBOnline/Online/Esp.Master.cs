using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using soc;

namespace ESPOnline
{
    public partial class Esp : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ANNEEUN.Text = Societe.Instance.ANNEE().ANNEE_DEB + "/" + Societe.Instance.ANNEE().ANNEE_FIN;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}