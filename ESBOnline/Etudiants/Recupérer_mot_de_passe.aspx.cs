using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Net.Mail;
using System.IO;

namespace ESPOnline.Etudiants
{
    public partial class Recupérer_mot_de_passe : System.Web.UI.Page
    {
        ReclamationService service_motdepasse = new ReclamationService();
       

      
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            //string NOM_ET = Session["NOM_ET"].ToString();
            //string PRENOM_ET = Session["PNOM_ET"].ToString();
            //Label2.Text = PRENOM_ET + "  " + NOM_ET;

        }

        protected void btn_renitialiser_mot_depasse_Click(object sender, EventArgs e)
        {
            try
            {
                string _id_et = Session["ID_ET"].ToString();
               // string _num_cin = Session["CIN_PASS"].ToString();




                if (service_motdepasse.GET_ADRESSE_MAIL(_id_et) == Adresse_mail_esp.Text.Trim().ToLower())
                {

                    string idi = service_motdepasse.GET_ADRESSE_MAIL(_id_et).ToString();
                    string nom_et = Label2.Text.ToString();
                    string pwd_et = service_motdepasse.GET_PASSWORD(_id_et).ToString();
                    string body = this.PopulateBody(idi, nom_et, pwd_et);
                    this.SendHtmlFormattedEmail((service_motdepasse.GET_ADRESSE_MAIL(_id_et).ToString().Trim()), " Récupérer votre  mot de passe d'intranet Esprit  perdu ou oublié", body);
                    string message;
                    message = "alert('Envoi mot de passe  avec succés')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    lblmessage.Text = "   <span style='color:red;'> Remarque : </span> <br> Vous pouvez consulter votre adresse mail esprit pour récupérer votre mot de passe. ";

                }
                else
                {
                    lblmessage.Text = "";
                    string message;
                    message = "alert('Verifié votre adresse mail !!!')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch 
            {
                lblmessage.Text = "";
                string message;
                message = "alert('En cas de probléme ,Envoyer un mail de reclamation vers : reclamation.si.eol@esprit.tn')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            
            }

        }


        private string PopulateBody(string idi, string nom_et, string pwd_et)
        {

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/récupérer_password_et.html")))
            {
                body = reader.ReadToEnd();

            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom_et}", nom_et);
            body = body.Replace("{pwd_et}", pwd_et);



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



    }
}