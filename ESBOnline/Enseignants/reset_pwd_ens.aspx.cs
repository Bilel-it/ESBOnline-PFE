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

namespace ESPOnline.Enseignants
{
    public partial class reset_pwd_ens : System.Web.UI.Page
    {
        byte up;
        string str = null;
        OracleCommand cmd;
        public string returnedvalue;

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }


        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
            {

                string t = Session["ID_ENS"].ToString().Trim();
              
                con.Open();

                cmd = new OracleCommand("update esp_enseignant set pwd_ens=trim('" + txt_npassword.Text + "') where id_ens='" + t + "' ");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script LANGUAGE='JavaScript'> alert('Mot de passe modifié avec succès,Reconnectez-vous à l aide de votre nouveau mot de passe')</script>");

            }          
        }
    }
}