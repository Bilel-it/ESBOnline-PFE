using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ESPOnline.Direction.admission
{
    public partial class transfert_envoiemail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
                GridView1.DataBind();

                lbladmis.Text = "Le nombre total des admis en :" + DateTime.Now.ToShortDateString() + " " + " " + "est:" + " " + " " + DAL.Admission.Instance.nbadmisreussis() + " " + "candidats";

            }
        }

        protected void OnCheckedChangedDDD(object sender, EventArgs e)
        {

        }

        protected void OnCheckedChanged(object sender, EventArgs e)
        {
            bool checkSelected = false;
            //foreach (GridView row in GridView1.Rows)
            //{
            //    checkSelected = Convert.ToBoolean(row.Rows["select_check"].Value);
            //    if (checkSelected == true)
            //    {
            //        row.RowStyle.BackColor = System.Drawing.Color.CadetBlue;
            //    }
            //    else
            //    {
            //        row.RowStyle.BackColor = System.Drawing.Color.White;
            //    }

            //}
            //  bool isUpdateVisible = false;
            // //// Label1.Text = string.Empty;

            // // //Loop through all rows in GridView
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //if (row.RowType == DataControlRowType.DataRow)
            //{
            //     bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
            //     if (isChecked)
            //         row.ForeColor = Color.Yellow;
            //          { }
            // row.RowState = DataControlRowState.Edit;


            //for (int i = 11; i < row.Cells.Count; i++)
            // {
            //         //    //row.Cells[i].Controls.OfType<Label>().FirstOrDefault().Visible = !isChecked;
            //         //    //if (row.Cells[i].Controls.OfType<TextBox>().ToList().Count > 0)
            //         //    //{
            //         //    //    row.Cells[i].Controls.OfType<TextBox>().FirstOrDefault().Visible = isChecked;
            //         //    //}
            //         //    //if (row.Cells[i].Controls.OfType<DropDownList>().ToList().Count > 0)
            //         //    //{
            //         //    //    row.Cells[i].Controls.OfType<DropDownList>().FirstOrDefault().Visible = isChecked;
            //         //    //}

            //         //    //if (isChecked && !isUpdateVisible)
            //         //    //{
            //         //    //    isUpdateVisible = true;
            //         //    //}
            ////         //}
            //    }
            //}
            //// UpdatePanel1.Update();
            // //btnUpdate.Visible = isUpdateVisible;
        }
        private Color GetColor(string color)
        {
            return Color.FromName(color);
        }
        protected void OnRowDataBoundS(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow) return;

            var c = e.Row.FindControl("lblbacnat") as Label;
            if (c != null)
            {
                if (c.Text == "INFO")
                    e.Row.Cells[4].ForeColor = GetColor("Red");

                if (c.Text == "TECHNIQUE")
                    e.Row.Cells[4].ForeColor = GetColor("Green");
                if (c.Text == "MATH")
                    e.Row.Cells[4].ForeColor = GetColor("Blue");


                if (c.Text == "SC EXP")
                    e.Row.Cells[4].ForeColor = GetColor("Peru");
            }

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.RowIndex == 0)     // This is row no.1
            //        if (e.Row.Cells[0].Text == "INFO")
            //            e.Row.Cells[0].BackColor = Color.Red;

            //    if (e.Row.RowIndex == 1)     // This is row no.2
            //        if (e.Row.Cells[0].Text == "TECHNIQUE")
            //            e.Row.Cells[0].BackColor = Color.Green;

            //    if (e.Row.RowIndex == 2)     // This is row no.2
            //        if (e.Row.Cells[0].Text == "MATH")
            //            e.Row.Cells[0].BackColor = Color.Blue;

            //    if (e.Row.RowIndex == 3)     // This is row no.2
            //        if (e.Row.Cells[0].Text == "SC EXP")
            //            e.Row.Cells[0].BackColor = Color.Peru;
            //}
        }

        protected void OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].CssClass = "viscol";
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].CssClass = "viscol";
            }
        }
        protected void OnDataBound(object sender, EventArgs e)

        {
            //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            //for (int i = 0; i < GridView1.Columns.Count; i++)
            //{
            //    TableHeaderCell cell = new TableHeaderCell();
            //    TextBox txtSearch = new TextBox();
            //    txtSearch.Attributes["placeholder"] = GridView1.Columns[i].HeaderText;
            //    txtSearch.CssClass = "search_textbox";
            //    cell.Controls.Add(txtSearch);
            //    row.Controls.Add(cell);

            //}
            //GridView1.HeaderRow.Parent.Controls.AddAt(1, row);


        }



        protected void Update(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
            GridView1.DataBind();
        }

        protected void btnUpdate_Click45(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    if (isChecked)
                    {

                        CheckBoxList duty = (CheckBoxList)row.FindControl("RadioButtonds");
                        for (int i = 0; i < duty.Items.Count; i++)
                        {

                            //check if particular items is selected or not
                            if (duty.Items[i].Selected)
                            {
                                //row.ForeColor = Color.Yellow;
                                Int32 totalvalues = 0;
                                //If selected then add the values to textbox
                                totalvalues += Convert.ToInt32(duty.Items[i].Value);
                                string id_et = GridView1.DataKeys[row.RowIndex].Value.ToString();

                                Session["totalvalues"] = totalvalues;
                                string hh = Session["totalvalues"].ToString();


                                string Getscorefinal = DAL.Admission.Instance.Getscorefinal(id_et);


                                decimal aa = Convert.ToDecimal(Getscorefinal);
                                decimal bb = Convert.ToDecimal(hh);
                                decimal nousf = aa + bb;
                                decimal nousf2 = Math.Round(nousf);

                                DAL.Admission.Instance.Modif_score(nousf2.ToString(), id_et);

                            }
                        }

                        //DataTable dtt = new DataTable();
                        //CheckBox duty = (CheckBox)row.FindControl("cf");
                        //CheckBox duty1 = (CheckBox)row.FindControl("CheckBox2");
                        //CheckBox duty2 = (CheckBox)row.FindControl("CheckBox3");
                        //string id_et = GridView1.DataKeys[row.RowIndex].Value.ToString();
                        //string Getscorefinal = DAL.Admission.Instance.Getscorefinal(id_et);
                        //decimal aa = Convert.ToDecimal(Getscorefinal);
                        //if (duty.Checked && duty1.Checked && duty2.Checked)
                        //{
                        //    decimal bb = Convert.ToDecimal(duty.Text.Substring(7, 2));
                        //    decimal bb1 = Convert.ToDecimal(duty1.Text.Substring(7, 2));
                        //    decimal bb2 = Convert.ToDecimal(duty2.Text.Substring(7, 2));

                        //    decimal nousf = aa + bb + bb1 + bb2;
                        //    DAL.Admission.Instance.Modif_score(nousf.ToString(), id_et);

                        //    GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
                        //    GridView1.DataBind();
                        //}

                        //if (duty1.Checked && duty.Checked)
                        //{
                        //    decimal bb = Convert.ToDecimal(duty.Text.Substring(7, 2));
                        //    decimal bb1 = Convert.ToDecimal(duty1.Text.Substring(7, 2));
                        //    decimal nousf = aa + bb1 + bb;
                        //    DAL.Admission.Instance.Modif_score(nousf.ToString(), id_et);


                        //    GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
                        //    GridView1.DataBind();
                        //}


                        //if (duty2.Checked && duty.Checked)
                        //{
                        //    decimal bb = Convert.ToDecimal(duty.Text.Substring(7, 2));

                        //    decimal bb2 = Convert.ToDecimal(duty2.Text.Substring(7, 2));
                        //    decimal nousf = aa + bb2 + bb;
                        //    DAL.Admission.Instance.Modif_score(nousf.ToString(), id_et);

                        //    GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
                        //    GridView1.DataBind();
                        //}

                        //if (duty2.Checked && duty1.Checked)
                        //{
                        //    decimal bb1 = Convert.ToDecimal(duty1.Text.Substring(7, 2));

                        //    decimal bb2 = Convert.ToDecimal(duty2.Text.Substring(7, 2));
                        //    decimal nousf = aa + bb2 + bb1;
                        //    DAL.Admission.Instance.Modif_score(nousf.ToString(), id_et);

                        //    GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
                        //    GridView1.DataBind();
                        //}
                        //else
                        //{
                        //    if (duty.Checked)
                        //    {
                        //        decimal bb = Convert.ToDecimal(duty.Text.Substring(7, 2));
                        //        decimal nousf = aa + bb;
                        //        DAL.Admission.Instance.Modif_score(nousf.ToString(), id_et);

                        //        GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
                        //        GridView1.DataBind();
                        //    }
                        //    if (duty1.Checked)
                        //    {
                        //        decimal bb1 = Convert.ToDecimal(duty1.Text.Substring(7, 2));
                        //        decimal nousf = aa + bb1;
                        //        DAL.Admission.Instance.Modif_score(nousf.ToString(), id_et);

                        //        GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
                        //        GridView1.DataBind();
                        //    }

                        //    if (duty2.Checked)
                        //    {
                        //        decimal bb2 = Convert.ToDecimal(duty2.Text.Substring(7, 2));
                        //        decimal nousf = aa + bb2;
                        //        DAL.Admission.Instance.Modif_score(nousf.ToString(), id_et);

                        //        GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
                        //        GridView1.DataBind();
                        //    }
                        //}


                    }











                }
                else
                {

                }

            }
        }

        protected void chckchanged(object sender, EventArgs e)

        {

            CheckBox chckheader = (CheckBox)GridView1.HeaderRow.FindControl("CheckBox1");

            foreach (GridViewRow row in GridView1.Rows)

            {

                CheckBox CheckBoxchckrw = (CheckBox)row.FindControl("CheckBox2");

                if (chckheader.Checked == true)

                {
                    CheckBoxchckrw.Checked = true;
                }
                else

                {
                    CheckBoxchckrw.Checked = false;
                }

            }

        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    if (isChecked)
                    {

                        TextBox duty = (TextBox)row.FindControl("txtmotiv");

                        string id_et = GridView1.DataKeys[row.RowIndex].Value.ToString();

                        string Getscorefinal = DAL.Admission.Instance.Getscorefinal(id_et);

                        decimal aa = Convert.ToDecimal(Getscorefinal);
                        decimal bb = Convert.ToDecimal(duty.Text);
                        decimal nousf = aa + bb;
                        decimal nousf2 = Math.Round(nousf);

                        DAL.Admission.Instance.Modif_score(nousf2.ToString(), id_et);


                    }



                }










                else
                {

                }

            }

            Response.Write("<script LANGUAGE='JavaScript'> alert('Score modifié avec succès ') </script>");
            GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
            GridView1.DataBind();

        }

        protected void chkbli_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridView1.DataSource = DAL.Admission.Instance.getinfscoresup(rdbli.SelectedValue);
            //GridView1.DataBind();
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            var userHost = System.Net.Dns.GetHostName();

            var userIp = Dns.GetHostEntry(userHost).AddressList[0].ToString();
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    if (isChecked)
                    {

                        string dd = TextBox1.Text;
                        string id_et = GridView1.DataKeys[row.RowIndex].Value.ToString();

                        Label lblniv = row.Cells[9].Controls.OfType<Label>().FirstOrDefault();
                        string niveau_acces = lblniv.Text;
                        Label1.Text = niveau_acces;

                        if (id_et.Contains("S"))
                        {

                            if (niveau_acces.StartsWith("4"))
                            {

                                

                                DataTable tabcup = DAL.Admission.Instance.GetInfoByIDtotransfert(id_et);

                                
                                foreach (DataRow rowcup in tabcup.Rows)
                                {
                                    string lblnom;
                                    string lblmail;
                                    string lblnumcin;
                                    //string sentre;
                                    lblnom = rowcup["nom"].ToString();
                                    lblmail = rowcup["e_mail_et"].ToString();
                                    lblnumcin = rowcup["num_cin_passeport"].ToString();

                                    string PNOM = "";
                                    string body = this.PopulateBody4emme(id_et, lblnumcin, lblnom, PNOM, dd);
                                    this.SendHtmlFormattedEmail_4emme(lblmail, "ESPRIT  Concours d'admission", body);
                                    DAL.Admission.Instance.transfer_to_enreg(id_et);
                                    DAL.Admission.Instance.ESP_JOURNAL_4ADMISSIBLE(id_et, userIp);
                                    DAL.Admission.Instance.updatedecisionBONUS(id_et);
                                    DAL.Admission.Instance.mail_envoyer4emme(id_et);
                                    

                                    DAL.Admission.Instance.update_envoiMail(id_et);
                                }

                            }
                            else
                            {
                               
                                DataTable tabcup = DAL.Admission.Instance.GetInfoByIDtotransfert(id_et);

                               
                                foreach (DataRow rowcup in tabcup.Rows)
                                {
                                    string lblnom;
                                    string lblmail;
                                    string lblnumcin;
                                    
                                    //string sentre;
                                    lblnom = rowcup["nom"].ToString();
                                    lblmail = rowcup["e_mail_et"].ToString();
                                    lblnumcin = rowcup["num_cin_passeport"].ToString();
                                    
                                    string PNOM = "";
                                    string body = this.PopulateBodycs(id_et, lblnumcin, lblnom, PNOM, dd);
                                    this.SendHtmlFormattedEmail(lblmail, "ESPRIT Resultat concours d'admission", body);
                                    DAL.Admission.Instance.transfer_to_enreg(id_et);
                                    DAL.Admission.Instance.add_journal_RACHAT(id_et, userIp);
                                    DAL.Admission.Instance.updatedecisionBONUS(id_et);
                                   

                                    DAL.Admission.Instance.update_envoiMail(id_et);
                                }


                            }

                        }

                        else
                        {
                            niveau_acces = lblniv.Text;
                            Label1.Text = niveau_acces;


                            if (niveau_acces.StartsWith("4"))
                            {

                               
                                DataTable tabcup = DAL.Admission.Instance.GetInfoByIDtotransfert(id_et);
                               
                                foreach (DataRow rowcup in tabcup.Rows)
                                {
                                    string lblnom;
                                    string lblmail;
                                    string lblnumcin;
                                    //string sentre;
                                    lblnom = rowcup["nom"].ToString();
                                    lblmail = rowcup["e_mail_et"].ToString();
                                    lblnumcin = rowcup["num_cin_passeport"].ToString();

                                    string PNOM = "";
                                    string body = this.PopulateBody4emme(id_et, lblnumcin, lblnom, PNOM, dd);
                                    this.SendHtmlFormattedEmail_4emme(lblmail, "ESPRIT  Concours d'admission", body);

                                    DAL.Admission.Instance.transfer_to_enreg(id_et);
                                    DAL.Admission.Instance.ESP_JOURNAL_4ADMISSIBLE(id_et, userIp);
                                    DAL.Admission.Instance.mail_envoyer4emme(id_et);

                                 
                                    DAL.Admission.Instance.updatedecisionBONUS(id_et);
                                    DAL.Admission.Instance.update_envoiMail(id_et);
                                }

                            }


                            if (niveau_acces.StartsWith("3"))
                            {


                                DataTable tabcup = DAL.Admission.Instance.GetInfoByIDtotransfert(id_et);

                                foreach (DataRow rowcup in tabcup.Rows)
                                {
                                    string lblnom;
                                    string lblmail;
                                    string lblnumcin;
                                    //string sentre;
                                    lblnom = rowcup["nom"].ToString();
                                    lblmail = rowcup["e_mail_et"].ToString();
                                    lblnumcin = rowcup["num_cin_passeport"].ToString();

                                    string PNOM = "";
                                    string body = this.PopulateBodycs3emeLicen(id_et, lblnumcin, lblnom, PNOM, dd);
                                    this.SendHtmlFormattedEmail(lblmail, "ESPRIT  Concours d'admission", body);




                                    //DAL.Admission.Instance.transfer_to_enreg(id_et);
                                    //DAL.Admission.Instance.ESP_JOURNAL_4ADMISSIBLE(id_et, userIp);
                                    //DAL.Admission.Instance.mail_envoyer4emme(id_et);
                                    //DAL.Admission.Instance.updatedecisionBONUS(id_et);
                                    DAL.Admission.Instance.updatedecision23licence(id_et);
                                    DAL.Admission.Instance.update_envoiMail(id_et);
                                }

                            }

                            if (niveau_acces.StartsWith("2"))
                            {


                                DataTable tabcup = DAL.Admission.Instance.GetInfoByIDtotransfert(id_et);

                                foreach (DataRow rowcup in tabcup.Rows)
                                {
                                    string lblnom;
                                    string lblmail;
                                    string lblnumcin;
                                    //string sentre;
                                    lblnom = rowcup["nom"].ToString();
                                    lblmail = rowcup["e_mail_et"].ToString();
                                    lblnumcin = rowcup["num_cin_passeport"].ToString();

                                    string PNOM = "";
                                    string body = this.PopulateBodycs2emeLicen(id_et, lblnumcin, lblnom, PNOM, dd);
                                    this.SendHtmlFormattedEmail(lblmail, "ESPRIT  Concours d'admission", body);

                                    //DAL.Admission.Instance.transfer_to_enreg(id_et);
                                    //DAL.Admission.Instance.ESP_JOURNAL_4ADMISSIBLE(id_et, userIp);
                                    //DAL.Admission.Instance.mail_envoyer4emme(id_et);
                                    //DAL.Admission.Instance.updatedecisionBONUS(id_et);
                                    DAL.Admission.Instance.updatedecision23licence(id_et);
                                    DAL.Admission.Instance.update_envoiMail(id_et);
                                }

                            }


                            else

                            {
                                if (niveau_acces.StartsWith("1"))
                                {
                                    DataTable tabcup = DAL.Admission.Instance.GetInfoByIDtotransfert(id_et);

                                    //DAL.Admission.Instance.update_envoiMail(id_et);
                                    foreach (DataRow rowcup in tabcup.Rows)
                                    {
                                        string lblnom;
                                        string lblmail;
                                        string lblnumcin;
                                        //string sentre;
                                        lblnom = rowcup["nom"].ToString();
                                        lblmail = rowcup["e_mail_et"].ToString();
                                        lblnumcin = rowcup["num_cin_passeport"].ToString();
                                        //DAL.Admission.Instance.transfer_to_etudiant(ID);

                                        //string pwd = row["NUM_CIN_PASSEPORT"].Text;
                                        //string NOM = row["NOM"].Text;
                                        string PNOM = "";
                                        string body = this.PopulateBody(id_et, lblnumcin, lblnom, PNOM, dd);
                                        // this.SendHtmlFormattedEmail(lblmail, "ESPRIT Resultat concours d'admission", body);
                                        this.SendHtmlFormattedEmail(lblmail, "ESPRIT Resultat concours d'admission", body);

                                        DAL.Admission.Instance.updatedecisionBONUS(id_et);

                                        DAL.Admission.Instance.transfer_to_enreg(id_et);
                                        DAL.Admission.Instance.add_journal_RACHAT(id_et, userIp);


                                        DAL.Admission.Instance.update_envoiMail(id_et);
                                    }

                                }
                            }




                        }

                    }
                }
            }

            string message;
            message = "alert('Transfert effectué')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            //txtdatefin.Text = "";

            GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
            GridView1.DataBind();

            lbladmis.Text = "Le nombre total des admis en :" + DateTime.Now.ToShortDateString() + " " + " " + "est:" + " " + " " + DAL.Admission.Instance.nbadmisreussis() + " " + "candidats";

        }



        private string PopulateBody(string idi, string pwd, string NOM, string PNOM, string datel)
        {


            string body = string.Empty;
            DateTime dd = Convert.ToDateTime(TextBox1.Text);
            datel = TextBox1.Text;

            //  DateTime d = DateTime.ParseExact(TextBox1.Text, "yyyyddMM", CultureInfo.InvariantCulture);
            // Console.WriteLine(d.ToString("MM/dd/yyyy"));
            string dateld = dd.ToString("dd/MM/yyyy");

            using (StreamReader reader = new StreamReader(Server.MapPath("~/Mail1erLicence.htm")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{pwd}", pwd);
            body = body.Replace("{NOM}", NOM);
            body = body.Replace("{PNOM}", PNOM);

            body = body.Replace("{dd}", dateld);

            return body;
        }


        private string PopulateBodycs2emeLicen(string idi, string pwd, string NOM, string PNOM, string datel)
        {
            string body = string.Empty;
            //admcs



            using (StreamReader reader = new StreamReader(Server.MapPath("~/2emeLicence.htm")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{pwd}", pwd);
            body = body.Replace("{NOM}", NOM);
            body = body.Replace("{PNOM}", PNOM);

            body = body.Replace("{dd}", datel);

            return body;
        }

        private string PopulateBodycs3emeLicen(string idi, string pwd, string NOM, string PNOM, string datel)
        {
            string body = string.Empty;
            //admcs



            using (StreamReader reader = new StreamReader(Server.MapPath("~/3emeLicence.htm")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{pwd}", pwd);
            body = body.Replace("{NOM}", NOM);
            body = body.Replace("{PNOM}", PNOM);

            body = body.Replace("{dd}", datel);

            return body;
        }


        private string PopulateBodycs(string idi, string pwd, string NOM, string PNOM, string datel)
        {
            string body = string.Empty;
            //admcs

            

            using (StreamReader reader = new StreamReader(Server.MapPath("~/Mail1erLicence.htm")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{pwd}", pwd);
            body = body.Replace("{NOM}", NOM);
            body = body.Replace("{PNOM}", PNOM);

            body = body.Replace("{dd}", datel);

            return body;
        }

        private string PopulateBody4emme(string idi, string pwd, string NOM, string PNOM, string datel)
        {
            string body = string.Empty;
            DateTime dd = Convert.ToDateTime(TextBox1.Text);
            datel = TextBox1.Text;


            using (StreamReader reader = new StreamReader(Server.MapPath("~/masterl.htm")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{idi}", idi);
            body = body.Replace("{pwd}", pwd);
            body = body.Replace("{NOM}", NOM);
            body = body.Replace("{PNOM}", PNOM);

            body = body.Replace("{dd}", datel);

            return body;
        }



        private void SendHtmlFormattedEmail_4emme(string recepientEmail, string subject, string body)
        {



            using (MailMessage mailMessage = new MailMessage())
            {
                // mailMessage.From = new MailAddress("inscription-esprit1718@esprit.tn");
                // mailMessage.From = new MailAddress("resultats1819@esprit.tn");
                // mailMessage.From = new MailAddress("resultat-sp1@esprit.tn");
                //mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.From = new MailAddress("admission.esb@esprit.tn");
                mailMessage.Subject = subject;
                // mailMessage.Bcc.Add = "dd";
                //mailMessage.Bcc.Add("maha.hammami@esprit.tn");



                //subject;
                //"Rectification montant payable";
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                //NetworkCred.UserName = "inscription-esprit1718@esprit.tn";
                //NetworkCred.Password = "Esprit2017";

                //NetworkCred.UserName = "inscription@esprit.tn";

                //NetworkCred.Password = "esprit2012";

                NetworkCred.UserName = "admission.esb@esprit.tn";

                NetworkCred.Password = "12345678";

                //NetworkCred.UserName = "resultats1819@esprit.tn";
                //NetworkCred.Password = "20esprit20";
                //NetworkCred.Password = "20esprit19**";

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }

        }

        //resultat 2018
        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {



            using (MailMessage mailMessage = new MailMessage())
            {
                // mailMessage.From = new MailAddress("inscription-esprit1718@esprit.tn");
                // mailMessage.From = new MailAddress("resultats1819@esprit.tn");
                // mailMessage.From = new MailAddress("resultat-sp1@esprit.tn");
                //mailMessage.From = new MailAddress("inscription@esprit.tn");
                mailMessage.From = new MailAddress("admission.esb@esprit.tn");
                mailMessage.Subject = subject;

                //subject;
                //"Rectification montant payable";
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                //NetworkCred.UserName = "inscription-esprit1718@esprit.tn";
                //NetworkCred.Password = "Esprit2017";

                //NetworkCred.UserName = "inscription@esprit.tn";
                //NetworkCred.Password = "esprit2012";


                NetworkCred.UserName = "admission.esb@esprit.tn";
                NetworkCred.Password = "12345678";
                //NetworkCred.UserName = "resultats1819@esprit.tn";
                //NetworkCred.Password = "20esprit20";
                //NetworkCred.Password = "20esprit19**";

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }

        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            foreach (GridViewRow row in GridView1.Rows)
            {
                (row.FindControl("CheckBox1") as CheckBox).Checked = false;
            }

        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //cours du soir
            //if (RadioButtonList1.SelectedValue == "S")
            //{
            //    GridView1.DataSource = DAL.Admission.Instance.getinfscoresupsoir();
            //    GridView1.DataBind();
            //    lbladmis.Visible = false;
            //}

            //else
            //{



            //    if (RadioButtonList1.SelectedValue == "4")
            //    {
            //        GridView1.DataSource = DAL.Admission.Instance.getinf4code03();
            //        GridView1.DataBind();
            //        lbladmis.Visible = false;
            //    }

            //    else
            //    {


            //        GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
            //        GridView1.DataBind();

            //        lbladmis.Text = "Le nombre total des admis en :" + DateTime.Now.ToShortDateString() + " " + " " + "est:" + " " + " " + DAL.Admission.Instance.nbadmisreussis() + " " + "candidats";

            //        lbladmis.Visible = true;
            //    }


            //}


        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void RadioButtonList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //cours du soir
            //if (RadioButtonList2.SelectedValue == "P")
            //{
            //    GridView1.DataSource = DAL.Admission.Instance.getprepa();
            //    GridView1.DataBind();
            //    lbladmis.Visible = false;
            //}

            //else
            //{
            //    GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussi();
            //    GridView1.DataBind();

            //    lbladmis.Text = "Le nombre total des admis en :" + DateTime.Now.ToShortDateString() + " " + " " + "est:" + " " + " " + DAL.Admission.Instance.nbadmisreussis() + " " + "candidats";

            //    lbladmis.Visible = true;
            //}
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime dd = Convert.ToDateTime(TextBox1.Text);
            Label1.Text = dd.ToShortDateString();
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = true;
            Button1.Visible = true;
            Cancel1.Visible = true;

            GridView1.DataSource = DAL.Admission.Instance.getinfodossierreussipreadmis(TextBox14.Text ,RadioButtonListspe.SelectedValue, TextBox2.Text, TextBox3.Text);
            GridView1.DataBind();

        }
    }
}

