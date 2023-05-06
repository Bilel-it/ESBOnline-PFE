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

namespace ESPOnline.Etudiants
{
    public partial class reset_pwd : System.Web.UI.Page
    {
        byte up;
        string str = null;
        OracleCommand cmd;
        public string returnedvalue;

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        protected void btn_update_Click(object sender, EventArgs e)
        {
           using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
            {
                
                string t = Session["ID_ET"].ToString().Trim();
                string numc = Session["CIN_PASS"].ToString().Trim();
               






                    con.Open();

                    cmd = new OracleCommand("update esp_etudiant set pwd_et= FS_CRYPT_DECRYPT('" + txt_npassword.Text + "') where id_et='" + t + "' ");





                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Mot de passe modifié avec succès,Reconnectez-vous à l aide de votre nouveau mot de passe')</script>");
                    
               
               
            }
        }
    }
}