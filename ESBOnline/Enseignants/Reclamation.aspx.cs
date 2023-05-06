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

namespace ESPOnline.Enseignants
{
    public partial class Reclamation : System.Web.UI.Page
    {
        string NOM_ENS;
        string ID_ENS;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            ID_ENS = Session["ID_ENS"].ToString();
            NOM_ENS = Session["NOM_ENS"].ToString();             
            TextBox123.Text = Session["NOM_ENS"].ToString();
            TextBox123.Enabled = false;
            if (!Page.IsPostBack)
            {
                TextBox4.DataBind();
                DropDownList1.DataBind();
                Label5.Text = DropDownList1.SelectedValue;
              
                if (Label5.Text != "0")
                {
                    DropDownList1.Visible = false;
                    Panel3.Visible = true;
                }
                else
                {
                    Panel3.Visible = false;
                }


            }
        
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(TextBox1.Text, "Esprit Reclamation");
            msg.To.Add(new MailAddress(TextBox4.Text));
            msg.Subject = DropDownList3.Text;
            msg.Body = TextBox5.Text;
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
            if ((TextBox123.Text == ""))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Identifier Votre Nom SVP ')</script>");
            }
            else if ((DropDownList3.SelectedValue == "Choisir"))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('vous devez donner le module du Réclamation ')</script>");
            }
            else if (DropDownList3.SelectedValue == "Autres")
            {
            
                ENTETE_RECLAMATION re = new ENTETE_RECLAMATION();
                //re.ID_ENTETE_RECLAMATION = int.Parse(TextBox124.Text);
                re.NOM_ENS = TextBox123.Text;
                re.TYPE_RECLAMATION = DropDownList3.Text;
                re.DATE_RECLAMATION = OracleDate.GetSysDate().Value;
                re.DESIGNATION = TextBox5.Text;
                re.ID_ENS = ID_ENS;
              
                EnteteService rs = new EnteteService();
                rs.ajouterEntete_Reclamation(re);
                Response.Write("<script LANGUAGE='JavaScript'> alert('Reclamation Envoyer Avec Succés')</script>");
              
            }
            else
            {
                ENTETE_RECLAMATION re = new ENTETE_RECLAMATION();
                //re.ID_ENTETE_RECLAMATION = int.Parse(TextBox124.Text);
                re.NOM_ENS = TextBox123.Text;
                re.TYPE_RECLAMATION = DropDownList3.Text;
                re.DATE_RECLAMATION = OracleDate.GetSysDate().Value;
                re.DESIGNATION = TextBox5.Text;
                re.ID_ENS = ID_ENS;
                EnteteService rs = new EnteteService();
                rs.ajouterEntete_Reclamation(re);
                Response.Write("<script LANGUAGE='JavaScript'> alert('Reclamation Envoyer Avec Succés')</script>");
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue != "Choisir")
            {
                if (DropDownList3.SelectedValue == "Autres")
                {
                    Panel1.Visible = true;
                    Label1.Visible = true;
                    TextBox2.Visible = true;
                    Button1.Visible = true;
                }
                else
                {
                    Panel1.Visible = true;
                    Label1.Visible = false;
                    TextBox2.Visible = false;
                    Button1.Visible = true;
                }
            }
            if (DropDownList3.SelectedIndex == 1)
            {
                TextBox4.Text = "naours.bennagra@esprit.tn";
            }
            else if (DropDownList3.SelectedIndex == 2)
            {
                TextBox4.DataBind();
                TextBox4.Text = "naours.bennagra@esprit.tn";
            }
            else if (DropDownList3.SelectedIndex == 3)
            {
                TextBox4.DataBind();
                TextBox4.Text = "naours.bennagra@esprit.tn";
            }
            else if (DropDownList3.SelectedIndex == 4)
            {
                TextBox4.DataBind();
                TextBox4.Text = "mohamed.saidi@esprit.tn";
            }
            else if (DropDownList3.SelectedIndex == 5)
            {
                TextBox4.DataBind();
                TextBox4.Text = "naours.bennagra@esprit.tn";
            }
            else if (DropDownList3.SelectedIndex == 6)
            {
                TextBox4.DataBind();
                TextBox4.Text = "mohamed.saidi@esprit.tn";
            }
            else if (DropDownList3.SelectedIndex == 7)
            {
                TextBox4.DataBind();
                TextBox4.Text = "nawel.rais@esprit.tn";
            }
            else if (DropDownList3.SelectedIndex == 8)
            {
                TextBox4.DataBind();
                TextBox4.Text = "naours.bennagra@esprit.tn";
            }
            else if (DropDownList3.SelectedIndex == 9)
            {
                TextBox4.DataBind();
                TextBox4.Text = "naours.bennagra@esprit.tn";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalModifier();", true);
            Panel20.Visible = true;
        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource6_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged2(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged3(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}