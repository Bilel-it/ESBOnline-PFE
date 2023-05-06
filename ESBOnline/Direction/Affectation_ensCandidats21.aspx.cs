
using admiss;
using ClosedXML.Excel;
using ESPOnline.Enseignants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using static ESPOnline.Enseignants.AValid_Cahier_classe;

namespace ESPOnline.Direction
{
    public partial class Affectation_ensCandidats21 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RadListBox2.DataTextField;

            GridView1.DataSource = DAL.Admission.Instance.list_ens_affectes();

            GridView1.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

      
        protected void btnFinal_Click(object sender, EventArgs e)
        {
            //JavaScriptSerializer jsSer = new JavaScriptSerializer();
            //object obj = jsSer.DeserializeObject(hidJsonHolder.Value);
            //Person[] listPerson = jsSer.ConvertToType<Person[]>(obj);
            ////int count = listPerson.Length;
            //foreach (Person p in listPerson)
            //{ txta.Text += p.ToString(); }
        }

        //class for DTO
        class Person
        {
            public string name { get; set; }
            public int id { get; set; }
            public override string ToString()
            {
                return string.Format("[id={0};name={1}]\n", id, name);
                //return base.ToString();
            }
        }


        protected void RadListBox_Dropped(object sender, RadListBoxDroppedEventArgs e)
        {
            //if (TextBox1.ClientID == e.HtmlElementID)
            //{
            //    TextBox1.Text = String.Empty;

            //    foreach (RadListBoxItem item in e.SourceDragItems)
            //    {
            //        TextBox1.Text += item.Text + ", \n";
            //    }

            //    if (TextBox1.Text.Length > 0)
            //        TextBox1.Text = TextBox1.Text.TrimEnd(new char[] { ',', ' ', '\n' });
            //    }
            }


        private string PopulateBody111(string date)
        {
            string body = string.Empty;
            // using (StreamReader reader = new StreamReader(Server.MapPath("~/nouvinsc.html")))

            using (StreamReader reader = new StreamReader(Server.MapPath("~/ensEnter.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{date}", date);
            //body = body.Replace("{pwdmo}", pwd);

          



            return body;
        }


        //private string PopulateBody()
        //{
        //    string body = string.Empty;
        //    // using (StreamReader reader = new StreamReader(Server.MapPath("~/nouvinsc.html")))

        //    using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/ensEnter.html")))
        //    {
        //        body = reader.ReadToEnd();
        //    }

        //   // body = body.Replace("{date}", date);
        //    //body = body.Replace("{pwdmo}", pwd);





        //    return body;
        //}


        private string PopulateBody(string idi)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Direction/ensEnter.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);

            return body;
        }



        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                //  mailMessage.From = new MailAddress("dsi_noreply@esprit.tn");

                mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                // mailMessage.To.Add(new MailAddress(m2));
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                //NetworkCred.UserName = "inscription-2020@esprit.tn";
                //NetworkCred.Password = "depot2020";

                NetworkCred.UserName = "";
                NetworkCred.Password = "";
                //  NetworkCred.UserName = "dsi_noreply@esprit.tn";
                //NetworkCred.Password = "Esprit2020*";

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            RadListBox2.Items.Clear();
        }



        public DataTable GetListEntretienss(string id_ens)
        {
            DataTable etu = null;

          

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString5))
            {
                try
                {

                                       string cmdQuery = "  select id_et,nom_et,PNOM_ET,e_mail_et from admis_esb.esp_etudiant where ID_ENS_ENTRETIEN='" + RadComboBox1.SelectedValue.ToString()+"' and SCORE_ENTRETIEN is null and id_et like '22%'";
                    OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);
             
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = mySqlConnection.CreateCommand();
                    cmd.CommandText = cmdQuery;
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    mySqlConnection.Open();
                    da.Fill(ds);
                    mySqlConnection.Close();
                    etu = ds.Tables[0];



                    mySqlConnection.Dispose();
                    OracleConnection.ClearPool(mySqlConnection);
                    OracleConnection.ClearAllPools();

                }
                catch
                {

                    mySqlConnection.Close();

                    mySqlConnection.Dispose();
                    OracleConnection.ClearPool(mySqlConnection);
                    OracleConnection.ClearAllPools();
                }
                finally
                {

                    mySqlConnection.Close();

                    mySqlConnection.Dispose();
                    OracleConnection.ClearPool(mySqlConnection);
                    OracleConnection.ClearAllPools();
                }

                return etu;

            }


        }
        private string getHTML(GridView gv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter textwriter = new StringWriter(sb);
            HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
            gv.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CC9966");

            gv.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("Silver");
            gv.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#990000");
            gv.Width = new Unit("100%");
            gv.RenderControl(htmlwriter);
            htmlwriter.Flush();
            textwriter.Flush();
            htmlwriter.Dispose();
            textwriter.Dispose();
            return sb.ToString();
        }


        protected void Btnscore_finale_Click(object sender, EventArgs e)
        {

            if (RadComboBox1.SelectedValue.ToString()=="")
            {
               // Response.Write("<script LANGUAGE='JavaScript' >alert('Choisir un enseignant')</script>");
                ShowPopupMessage("Choisir un enseignant !", PopupMessageType.Warning);
            }

            else
            {
                string ch;
                string userid = Session["ID_DECID"].ToString();
                string id_ens = RadComboBox1.SelectedValue.ToString();

                string mail_ens= DAL.StatMCHOKRIET_MAHA.Instance.mail_ens(id_ens);
                //string slash = "/";
                for (int i = 0; i < RadListBox2.Items.Count; i++)
                {
                    ch = RadListBox2.Items[i].Value;

                    // ch = RadListBox2.DataTextField;

                    //ici update
                    DAL.Admission.Instance.update_ensEntretien(RadComboBox1.SelectedValue, userid, ch, TBdateseance.SelectedDate.Value.ToString("dd/MM/yy"));
                   // Response.Write("<script LANGUAGE='JavaScript' >alert('Affectation réussite')</script>");

                    ShowPopupMessage("Affectation réussite", PopupMessageType.Success);



                    //}



              

                //send mail


                //try
                //{
               


                    //  this.SendHtmlFormattedEmail((GridView1.Rows[i].Cells[1].Text.ToString()).Trim(), "Esprit", body);


                    // Debug.WriteLine(i + " " + GridView1.Rows[i].Cells[1].Text.ToString());


                    //TextBox2.Text = i.ToString();
                    //}
                    //catch (Exception ex)
                    //{

                    //    string bug = ex.ToString();
                    //   // Label1.Text = "erreur en  " + i.ToString() + "  " + GridView1.Rows[i].Cells[1].Text.ToString() + "  " + ex;

                    // string body = this.PopulateBody111();




                    // this.SendHtmlFormattedEmail(mail_ens, "ESPRIT", body);
                    // Debug.WriteLine(i + " " + GridView1.Rows[i].Cells[3].Text.ToString());
                }

                GridView c = new GridView();
                var resultat = DAL.Admission.Instance.listEntretienetud(RadComboBox1.SelectedValue.ToString());

                //c.DataSource = (from myRow in resultat.AsEnumerable()
                //                where myRow.Field<string>("id_et") == GridView1.Rows[i].Cells[0].Text.ToString()
                //                select myRow).CopyToDataTable();
                c.DataSource = (from myRow in resultat.AsEnumerable()

                                select myRow).CopyToDataTable();

                c.DataBind();


                Label Label1 = new Label();
                Label1.Text = getHTML(c);

                string idi = Label1.Text;
                string body = this.PopulateBody(idi);

                this.SendHtmlFormattedEmail(mail_ens, "Esprit ESB", body);

                RadListBox2.Items.Clear();
            }
        }


        private void ShowPopupMessage(string message, AValid_Cahier_classe.PopupMessageType messageType)
        {
            switch (messageType)
            {
                case PopupMessageType.Error:
                    lblMessagePopupHeading.Text = "Error";
                    //Render image in literal control
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/images/error.png") + "' alt='' />";
                    break;
                case PopupMessageType.Message:
                    lblMessagePopupHeading.Text = "Information";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/Images/info.png") + "' alt='' />";
                    break;
                case PopupMessageType.Warning:
                    lblMessagePopupHeading.Text = "Warning";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/Images/Warning.png") + "' alt='' />";
                    break;
                case PopupMessageType.Success:
                    lblMessagePopupHeading.Text = "Success";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/Images/success.png") + "' alt='' />";
                    break;
                default:
                    lblMessagePopupHeading.Text = "Information";
                    ltrMessagePopupImage.Text = "<img src='" +
                      Page.ResolveUrl("../Contentcls/Images/info.png") + "' alt='' />";
                    break;
            }

            lblMessagePopupText.Text = message;
            mpeMessagePopup.Show();
        }

        protected void Buttonexcel_Click(object sender, EventArgs e)
       
        {

            System.Data.DataTable dt = new System.Data.DataTable("ETAT_Data");


            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                Response.Clear();

                Response.Buffer = true;
                Response.Charset = "";

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.ContentType = "text/csv";
                Response.AddHeader("content-disposition", "attachment;filename=Liste_candidats" + DateTime.Now + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }

        }

    }
}

