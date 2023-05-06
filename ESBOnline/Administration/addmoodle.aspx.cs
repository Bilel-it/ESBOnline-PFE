using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;


namespace ESPOnline.Direction.admission
{
    public partial class addmoodle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void addmood( object snder,EventArgs arg)
        {
             DataTable dt = DAL.Admission.Instance.getmoodle();

            string m1= dt.Rows[0][0].ToString();
            try
            {
                if (DropDownList1.SelectedItem != null)
                {
                    DAL.Admission.Instance.updatemoodle(DropDownList1.SelectedItem.Value.ToString(), dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
                }
                else
                {
                    Label1.Text = "Veuillez choisir un candidat";
                }

                Label1.Text = "Modification avec succée";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            catch
            {



                Label1.Text = "ERREUR";

            }
        }
}
}