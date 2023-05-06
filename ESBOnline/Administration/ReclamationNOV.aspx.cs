using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Types;
using DAL;
using BLL;
using System.Net;
using System.Net.Mail;


namespace ESPOnline.Administration
{
    public partial class ReclamationNOV : System.Web.UI.Page
    {

        string ID_ENS;
        string NOM_ENS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.DataBind();

                DropDownList1.Items.Insert(0, new ListItem("Choisir"));
            }
            //if (Session["NOM_ENS"] == null)
            //{
            //    Response.Redirect("~/Online/default.aspx");
            //}
            //NOM_ENS = Session["NOM_ENS"].ToString();


            foreach (GridViewRow row in GridView2.Rows)
            {

                if (Convert.ToString(row.Cells[0].Text) == "traiter")
                {
                    row.BackColor = System.Drawing.Color.Lime;
                }
                else if (Convert.ToString(row.Cells[0].Text) == "non traiter")
                {
                    row.BackColor = System.Drawing.Color.Red;
                }
                else if (Convert.ToString(row.Cells[0].Text) == "en cours")
                {
                    row.BackColor = System.Drawing.Color.Blue;
                }

            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        protected void LinkButton155_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(TextBox1.Text, "Sender's Name");
            msg.To.Add(new MailAddress(TextBox4.Text));
           
            msg.Body = TextBox7.Text;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential(TextBox1.Text, TextBox3.Text);
            lblResult.Visible = true;
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);
                lblResult.Text = "Email sent successfully.";
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
            if ((DropDownList3.SelectedIndex == 0))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('vous devez repondre par traiter/non traiter/ en cours ')</script>");
            }
            else if ((TextBox7.Text == ""))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('vous devez donner une description ')</script>");
            }
            else if ((DropDownList4.SelectedIndex == 0))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('vous devez identifier l'utilisateur ')</script>");
            }
            else
            {
                RECLAMATIONN re = new RECLAMATIONN();

 
                re.NOM_ENS = DropDownList1.Text;
                re.TRAITER = DropDownList3.SelectedValue.ToString();
                re.DATE_TRAITEMENT = OracleDate.GetSysDate().Value;
                re.DESCRIPTION = TextBox7.Text;
                re.UTILISATEUR = DropDownList4.Text;
               
               
                ReclamationService rs = new ReclamationService();
                rs.ajouterReclamation(re);
                Response.Write("<script LANGUAGE='JavaScript'> alert('Notification Reclamation Envoyer Avec Succés')</script>");
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in GridView2.Rows)
            {

                if (Convert.ToString(row.Cells[0].Text) == "traiter")
                {
                    row.BackColor = System.Drawing.Color.Lime;
                }
                else if (Convert.ToString(row.Cells[0].Text) == "non traiter")
                {
                    row.BackColor = System.Drawing.Color.Red;
                }
                else if (Convert.ToString(row.Cells[0].Text) == "en cours")
                {
                    row.BackColor = System.Drawing.Color.Blue;
                }

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}