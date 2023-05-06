using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using Oracle.ManagedDataAccess.Types;

using Oracle.ManagedDataAccess.Client;
using System.IO;


using System.Net.Mail;
using System.Configuration;

using System.Diagnostics;

namespace Image_blob
{
    public partial class PHOTO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            if (!IsPostBack)
            {
                DropDownList1.DataSource = SqlDataSource1;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("Select", "")); //updated code
                //using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                //{
                //    con.Open();

                //    OracleCommand cmd = new OracleCommand("SELECT distinct ID FROM APHOTOS ");

                //    cmd.Connection = con;
                //    OracleDataReader _dr = cmd.ExecuteReader();
                //    while (_dr.Read())
                //    {
                //        DropDownList1.Items.Add(_dr.GetString(0));
                //    }
                    
                //    _dr.Close();
                //    con.Close();
                //}
            }
        }
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.tt);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
        protected void tt(object sender, EventArgs e)
        {
           
            Page.DataBind();




        }
        public string PopulateBody(string datedoss)
        {

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/basic.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{datedoss}", datedoss);
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
         
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/basic.html")))
            {
                body = reader.ReadToEnd();
            }
            string mail = pho.Instance.Getemail(DropDownList1.SelectedValue);
            string datedoss = pho.Instance.Getdossier(DropDownList1.SelectedValue);
           body = this.PopulateBody(datedoss);
           Label1.Text = "l'email de confirmation à bien été envoyé à" + DropDownList1.SelectedValue;
           Label1.ForeColor = System.Drawing.Color.Red;
            this.SendHtmlFormattedEmail(mail, "ESP INSCRIPTION", body);
            pho.Instance.update_etat(DropDownList1.SelectedValue);
            DropDownList1.Items.Clear();
            DropDownList1.DataTextField = "ID_ET";
            DropDownList1.DataValueField = "ID_ET";
            DropDownList1.DataSource = SqlDataSource1;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("SELECT", ""));
        }
        //void creatimage(string it_p)
        //{ 
        //    using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
        //    {
        //        con.Open();

        //        OracleCommand cmd = new OracleCommand("SELECT PHO FROM APHOTOS where id='" + it_p + "'");

        //        cmd.Connection = con;
        //        byte[] _buf = (byte[])cmd.ExecuteScalar();

        //        // This is optional
        //        Response.ContentType = "image/gif";

        //        //stream it back in the HTTP response
        //        Response.BinaryWrite(_buf);

        //        con.Close();
        //    }
        //}
    }
}
