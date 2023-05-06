using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Etudiants
{
    public partial class DetailEncadrement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = RadioButtonList3.Text;          
            //else

            //    Label6.Text = "Ne Confirme pas le cahier des charges";
            //Label6.ForeColor = System.Drawing.Color.Red;
            
 
        }
        protected void RadioButtonList1_DataBound(object sender, EventArgs e)
        {
            Label1.Text = RadioButtonList3.SelectedItem.Text;
        }
       
    }
}