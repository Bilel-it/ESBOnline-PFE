using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.EmploiEsp
{
    public partial class SiteEDT : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkBtnConsulteredt.Enabled = false;
            Linkbtncalender.Enabled = false;
            LinkBtnverifIndispo.Enabled = false;
            LinkBtContact.Enabled = false;
            LinkBtnaffecter.Enabled = false;
        }




    }
}