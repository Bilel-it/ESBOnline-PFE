using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI.GridExcelBuilder;
using Telerik.Web.UI;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using System.Net.Mail;
using System.Diagnostics;
using ClassLibrary1;

namespace ESPOnline.Direction.admission
{
    public partial class Envoi_mail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ID_DECID"] == null)
            //{
            //    Response.Redirect("~/Online/default.aspx");
            //}

        }


        ///licence niv1

        private string PopulateBody(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_licenceniv1.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);
           
          
           
            return body;
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
              
                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i =0 ; i < GridView1.Rows.Count; i++)
            {
                    string idi = GridView1.Rows[i].Cells[0].Text;
                    string nom = GridView1.Rows[i].Cells[1].Text;
                    string prenom = GridView1.Rows[i].Cells[2].Text;
                    string body = this.PopulateBody(idi,nom,prenom);
                    this.SendHtmlFormattedEmail((GridView1.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);
                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();


            }
            Response.Redirect("Envoi_mail.aspx");


        }

        ///licence niv2
        private string PopulateBody2(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_licenceniv2.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail2(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView2.Rows.Count ; i++)
            {
                string idi = GridView2.Rows[i].Cells[0].Text;
                string nom = GridView2.Rows[i].Cells[1].Text;
                string prenom = GridView2.Rows[i].Cells[2].Text;
                string body = this.PopulateBody2(idi, nom, prenom);
                this.SendHtmlFormattedEmail2((GridView2.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);
                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();


            }
            Response.Redirect("Envoi_mail.aspx");

        }

        ///master niv 4
        private string PopulateBody3(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_master_niv4.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail3(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                string idi = GridView3.Rows[i].Cells[0].Text;
                string nom = GridView3.Rows[i].Cells[1].Text;
                string prenom = GridView3.Rows[i].Cells[2].Text;
                string body = this.PopulateBody3(idi, nom, prenom);
                this.SendHtmlFormattedEmail3((GridView3.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);
                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();


            }
            Response.Redirect("Envoi_mail.aspx");

        }


        //vermeg
        private string PopulateBody4(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_vermeg.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail4(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView4.Rows.Count; i++)
            {
                string idi = GridView4.Rows[i].Cells[0].Text;
                string nom = GridView4.Rows[i].Cells[1].Text;
                string prenom = GridView4.Rows[i].Cells[2].Text;
                string body = this.PopulateBody4(idi, nom, prenom);
                this.SendHtmlFormattedEmail4((GridView4.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);
                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();


            }
            Response.Redirect("Envoi_mail.aspx");
        }

        //internatio

        private string PopulateBody5(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/resultat_internationaux.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail5(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView5.Rows.Count; i++)
            {
                string idi = GridView5.Rows[i].Cells[0].Text;
                string nom = GridView5.Rows[i].Cells[1].Text;
                string prenom = GridView5.Rows[i].Cells[2].Text;
                string body = this.PopulateBody5(idi, nom, prenom);
                this.SendHtmlFormattedEmail5((GridView5.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);

                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();

            }
            Response.Redirect("Envoi_mail.aspx");
        }
        private string PopulateBody6(string idi, string nom, string prenom)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/admission/refus.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{nom}", nom);
            body = body.Replace("{prenom}", prenom);



            return body;
        }

        private void SendHtmlFormattedEmail6(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription@esprit.tn";
                NetworkCred.Password = "esprit2012";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Entities1 ctx = new Entities1();
            for (int i = 0; i < GridView6.Rows.Count; i++)
            {
                string idi = GridView6.Rows[i].Cells[0].Text;
                string nom = GridView6.Rows[i].Cells[1].Text;
                string prenom = GridView6.Rows[i].Cells[2].Text;
                string body = this.PopulateBody6(idi, nom, prenom);
                this.SendHtmlFormattedEmail6((GridView6.Rows[i].Cells[3].Text.ToString()).Trim(), "RESULTAT CONCOURS D'ADMISSION ", body);

                var et = ctx.ESP_ETUDIANT.Where(etu => etu.ID_ET.Equals(idi)).FirstOrDefault();
                et.ENVOI_MAIL = "O";
                et.DATE_ADDMISSION = DateTime.Now;
                ctx.SaveChanges();

            }
            Response.Redirect("Envoi_mail.aspx");
        }



        //refus

    }
}