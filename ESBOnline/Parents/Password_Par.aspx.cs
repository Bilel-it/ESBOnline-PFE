using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Configuration;
using System.ComponentModel;
using System.Data;


using ABSEsprit;
namespace ESPOnline.Parents
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        byte up;
        string str = null;
        OracleCommand cmd;
        public string returnedvalue;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["NUM_CIN_PASSEPORT"] == null)
            //{
            //    Response.Redirect("~/Online/default.aspx");
            //}
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        protected void Button1_Click(object sender, EventArgs e)
        {


            if (ESP_PARENTS.Instance.CIN_EXISTE(TextBox1.Text.Trim()) != null)
            {

                using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                {
                    string t = TextBox1.Text.Trim();

                    con.Open();
                    cmd = new OracleCommand("update esp_etudiant set pwd_parent= '" + txt_ccpassword.Text + "' where NUM_CIN_PASSEPORT='" + t + "' ");
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                                     "alert",
                                     "alert('Mot de passe modifié avec succès,Reconnectez-vous à l aide de votre nouveau mot de passe');window.location ='https://esprit-tn.com/ESBOnline/Online/default.aspx#tabs-3';",
                                     true);
                   // Response.Write("<script LANGUAGE='JavaScript'> alert('Mot de passe modifié avec succès,Reconnectez-vous à l aide de votre nouveau mot de passe')</script>");

                }

            }
            else 
            
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Votre cin est incorrecte ,Essayé de nouveau ')</script>");

            }
                 

        }
    
    }
}