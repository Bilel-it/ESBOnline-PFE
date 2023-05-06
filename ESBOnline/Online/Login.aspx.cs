using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Evaluation;

namespace ESPOnline.Online
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

  


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

             

                esp_parent2 ett = esp_parent2.Instance.loginETParentPayment(injectionSQL.Sanitize(TextBox1.Text.Trim()));
              
                if (ett != null)

                {
                    Session["ID_ET"] = ett.ID_ET;
                    Session["NOM_ET"] = ett.NOM_ET;
                    Session["PNOM_ET"] = ett.PRENOM_ET;
                    Session["CIN_PASS"] = ett.NUM_CIN_PASSEPORT;
                   
                    Session["CODE_CL"] = ett.CODE_CL;
                    Session["TEL_ET"] = ett.TEL_ET;
                    Session["nbredeconsultationparsession"] = 0;
                    Response.Redirect("~/Parents/PaymentEsprit.aspx");

                }
             



            }
            catch (Exception ex)
            {
                //string bug=ex.ToString();
                Response.Write("<script LANGUAGE='JavaScript'> alert('Verifier vos paramètres.')</script>");
            }

        }
    }
}