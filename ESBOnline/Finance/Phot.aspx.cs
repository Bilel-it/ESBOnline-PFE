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

using Image_blob;
using System.Net.Mail;
using System.Configuration;

using System.Diagnostics;

namespace ESPOnline.Finance
{
    public partial class Phot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
          
            if (!IsPostBack)
            {

                //DropDownList2.Items.Clear();
                //DropDownList2.DataBind();
                //DropDownList2.Items.Insert(0, new ListItem("Select", ""));
                //using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                //{
                //    con.Open();

                //    OracleCommand cmd = new OracleCommand("SELECT distinct ID FROM APHOTOS ");

                //    cmd.Connection = con;
                //    OracleDataReader _dr = cmd.ExecuteReader();
                //    while (_dr.Read())
                //    {
                //        drop.Items.Add(_dr.GetString(0));
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
            this.drop.SelectedIndexChanged += new Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventHandler(this.tt);
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
                mailMessage.From = new MailAddress("inscription1617@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "inscription1617@esprit.tn";
                NetworkCred.Password = "esprit2016";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }
        protected void ondropdate(object sender, EventArgs e)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.DataSource = SqlDataSource1;
            drop.DataBind();
            Label1.Text = "";
          

         
           
        }
        protected void drop2(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
           
            DropDownList2.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/basic.html")))
            {
                body = reader.ReadToEnd();
            }
            string mail = pho.Instance.Getemail(drop.SelectedValue);
            string datedoss = pho.Instance.Getdossier(drop.SelectedValue);
            body = this.PopulateBody(datedoss);
          
          //  this.SendHtmlFormattedEmail(mail, "ESP INSCRIPTION", body);
             
                Label1.Text = "l'email de confirmation à bien été envoyé à" + drop.SelectedItem.Text;
            
           
            Label1.ForeColor = System.Drawing.Color.Red;
            pho.Instance.update_etat(drop.SelectedValue);
            //DropDownList2.Items.Clear();
            //DropDownList2.DataBind();
            //drop.Items.Clear();
            //drop.DataTextField = "tt";
            //drop.DataValueField = "ID_ET";
            //drop.DataSource = SqlDataSource1;
            //drop.DataBind();
           
        }
    }
}