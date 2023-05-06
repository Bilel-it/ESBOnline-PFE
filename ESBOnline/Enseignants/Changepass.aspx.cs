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
    public partial class Changepass : System.Web.UI.Page
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
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        protected void btn_update_Click(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
            {
                con.Open();
                string t = Session["ID_ENS"].ToString().Trim();
                // string numc = Session["CIN_PASS"].ToString().Trim();
                cmd = new OracleCommand("SELECT PWD_ENS as pw FROM ESP_ENSEIGNANT where id_ens='" + t + "'  ");

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                using (OracleDataReader myReader = cmd.ExecuteReader())
                {


                    cmd.Connection = con;
                    while (myReader.Read())
                    {
                        if (txt_cpassword.Text == myReader["pw"].ToString())
                        {
                            up = 1;

                        }


                    }
                }

                con.Close();


                //if (txt_cpassword.Text == Session["PWD_ET"].ToString())
                //{
                if (up == 1)
                {


                    //        con.Open();
                    //        cmd = new OracleCommand("select FS_CRYPT_DECRYPT('" + txt_cpassword.Text + "') as ts from esp_etudiant where id_et like '"+t+"'");

                    //cmd.Connection = con;
                    //cmd.CommandType = CommandType.Text;
                    //using (OracleDataReader myReader = cmd.ExecuteReader())
                    //{


                    //    cmd.Connection = con;
                    //    while (myReader.Read())
                    //    {
                    //       Label4.Text= myReader["ts"].ToString();

                    //       returnedvalue = myReader["ts"].ToString();

                    //    }


                    //}




                    //OracleParameter ret = new OracleParameter("vl_result", OracleType.VarChar, 20);
                    //ret.Direction = ParameterDirection.ReturnValue;
                    //cmd3.Parameters.Add(ret);
                    //OracleParameter PWD = new OracleParameter("PWD_ET", OracleType.VarChar, 20);
                    // returnedvalue = (string)cmd3.Parameters["vl_result"].Value;


                    // string rt = (string)ret.Value.ToString();
                    // PWD.Value = txt_npassword.Text.Trim();

                    // cmd3.Parameters.Add("PWD_ET", OracleType.VarChar, 20).Value = txt_npassword.Text.Trim();
                    //OracleParameter prmPWD_T = new OracleParameter();
                    //prmPWD_T.ParameterName = "@PWD_ET";
                    //cmd3.Parameters.Add("PWD_ET", OracleType.VarChar,20).Value = txt_npassword.Text.Trim().ToString();
                    //prmPWD_T.OracleType = OracleType.VarChar;
                    //prmPWD_T.Direction = ParameterDirection.Input;
                    //prmPWD_T.Value ="eee";
                    //cmd3.Parameters.Add(prmPWD_T);
                    // prmPWD_T.Value = txt_npassword.Text.Trim();
                    //cmd3.Parameters.Add(prmPWD_T);
                    //cmd3.Parameters.Add("PWD_ET", OracleType.VarChar,20).Value = txt_npassword.Text.Trim();
                    // ParameterDirection.ReturnValue.ToString();
                    //cmd3.Parameters["PWD_ET"].Direction = ParameterDirection.Input;
                    //cmd3.Parameters["PWD_ET"].Value = "fff";

                    //prmPWD_T.Direction = ParameterDirection.InputOutput;

                    //prmPWD_T.Value = "Hello";

                    //cmd3.Parameters.Add(prmPWD_T);	



                    con.Open();

                    cmd = new OracleCommand("update esp_enseignant set pwd_ens= '" + txt_npassword.Text + "' where id_ens='" + t + "' ");

                    //OracleParameter prmPWD_ET = new OracleParameter("@PWD_ET", OracleType.VarChar, 20);
                    //prmPWD_ET.Value = txt_npassword.Text.Trim();




                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script LANGUAGE='JavaScript'> alert('Mot de passe modifié avec succès')</script>");
                    // lbl_msg.Text = "Mot de passe modifié avec succès";
                }
                else
                {
                    lbl_msg.Text = "S'il vous plaît entrez le mot de passe correct actuel";
                }
            }
        }
    }
}