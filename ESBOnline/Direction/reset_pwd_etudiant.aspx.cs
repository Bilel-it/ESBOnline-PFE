using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

using System.Data.OracleClient;

using System.Configuration;
using System.ComponentModel;
using System.Data;
using ABSEsprit;
using System.IO;
using System.Net.Mail;
namespace ESPOnline.Direction
{
    public partial class reset_pwd_etudiant : System.Web.UI.Page
    {
        byte up;
        string str = null;
        OracleCommand cmd;
        public string returnedvalue;

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RadioButtonList3.SelectedIndex == 0) { Panel2.Visible = true; Panel3.Visible = false; }
            else if (RadioButtonList3.SelectedIndex == 1) { Panel2.Visible = false; Panel3.Visible = true; }
            else { Panel3.Visible = false; Panel2.Visible = false; }

            if (DropDownList1.SelectedItem != null)
            {

                GridView3.DataSource = SqlDataSource3;
                GridView3.DataBind();
            }
            if (RadComboBox1.SelectedItem != null)
            {

                GridView1.DataSource = SqlDataSource4;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = DropDownList1.SelectedValue;
            string pw = GridView4.Rows[0].Cells[0].Text.ToString();

            using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
            {
                con.Open();

                cmd = new OracleCommand("update esp_etudiant set pwd_et= FS_CRYPT_DECRYPT('" + pw + "') where id_et='" + id + "' ");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                string userName = GridView4.Rows[0].Cells[0].Text.ToString();
                string idi = GridView3.Rows[0].Cells[1].Text.ToString();

                string body = this.PopulateBody(userName, idi);
                this.SendHtmlFormattedEmail((GridView3.Rows[0].Cells[2].Text.ToString()).Trim(), "", body);
                Response.Write("<script LANGUAGE='JavaScript' >alert('le mot de passe a réinitialisé avec succes')</script>");
                
            }
        }


        private string PopulateBody(string userName, string idi)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/resetmail.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{userName}", userName);
            body = body.Replace("{idi}", idi);



            return body;
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("si_noreply@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();

                NetworkCred.UserName = "si_noreply@esprit.tn";
                NetworkCred.Password = "si_noreply2014";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Online/default.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string id = RadComboBox1.SelectedValue;
            string pw = GridView2.Rows[0].Cells[0].Text.ToString();

            using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
            {
                con.Open();

                cmd = new OracleCommand("update esp_enseignant set pwd_ens= '" + pw + "' where id_ens='" + id + "' ");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                // string userName = GridView2.Rows[0].Cells[0].Text.ToString();
               
                
                
                string idi = GridView1.Rows[0].Cells[1].Text.ToString();

                string body = this.PopulateBody("", idi);
                this.SendHtmlFormattedEmail((GridView1.Rows[0].Cells[2].Text.ToString()).Trim(), "", body);
                Response.Write("<script LANGUAGE='JavaScript' >alert('le mot de passe a réinitialisé avec succes')</script>");
                
            }
        }




    }
    }
