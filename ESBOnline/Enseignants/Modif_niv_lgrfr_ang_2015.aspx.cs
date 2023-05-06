using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using ESPSuiviEncadrement;

namespace ESPOnline.Enseignants
{
    public partial class Modif_niv_lgrfr_ang_2015 : System.Web.UI.Page
    {
        LangueService service = new LangueService();
        string id_ens;
        string ancien_niv_fr;
        string ancien_niv_ang;
        DataTable dtab;
        string cod_mod;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }


            if (!IsPostBack)
            {
                

                id_ens = Session["ID_ENS"].ToString();

                cod_mod = service.get_Code_module(id_ens);

                if (cod_mod.StartsWith("FR"))
                {
                    rblangue.Items[1].Enabled = false;

                }
                else
                    if (cod_mod.StartsWith("AN"))
                    {
                        rblangue.Items[0].Enabled = false;
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Vérifier votre module!!!');</script>");
                    }
                plindiv.Visible = false;
                plclasse.Visible = false;
                plchoix.Visible = false;
                lblid.Visible = false;
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbchoix.SelectedValue == "I")
            {

                plindiv.Visible = false;
                plclasse.Visible = true;
                Gridstudent.Visible = false;
                btnUpdate.Visible = false;
                //gvCustomers.Visible = false;

            }
            else
                if (rbchoix.SelectedValue == "C")
                {
                    plindiv.Visible = true;
                    plclasse.Visible = false;
                    Gridstudent.Visible = false;
                    // plgridCL.Visible = false;
                    gvCustomers.Visible = false;
                    btnUpdate.Visible = false;

                }
        }

        protected void rblangue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblangue.SelectedValue != null)
            {
                plchoix.Visible = true;
            }
        }

        public void bind()
        {

            Gridstudent.DataSource = service.bind_niveau_etudiant(lblid.Text);
            Gridstudent.DataBind();
        }

        //editer et modifier le niveau
        protected void GrdEmpData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridstudent.EditIndex = e.NewEditIndex;
            //Rebind Grid
            bind();
            //  lblid.Text = service.Get_ID_ETUD(ddlnomETUD.SelectedValue);
            if (rblangue.SelectedValue == "FR")
            {
                DropDownList ddlnIV_fr = Gridstudent.Rows[e.NewEditIndex].FindControl("ddlniveau_fr") as DropDownList;
                ddlnIV_fr.DataTextField = "niveau_courant_fr";
                ddlnIV_fr.DataValueField = "niveau_courant_fr";
                ddlnIV_fr.Items.Add(new ListItem("NN", "NN"));
                //ddlnIV_fr.Items.Insert(0, new ListItem("NN", ""));
                ddlnIV_fr.DataSource = service.bind_niveau_fr();
                ddlnIV_fr.DataBind();
                ddlnIV_fr.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
                ddlnIV_fr.SelectedItem.Selected = false;
                ddlnIV_fr.Items.FindByText("Veuillez choisir").Selected = true;
                //.niveau_courant_ang,e.niveau_courant_fr
            }
            else
                if (rblangue.SelectedValue == "AN")
                {
                    DropDownList ddlnIV_ang = Gridstudent.Rows[e.NewEditIndex].FindControl("ddlniveau_ang") as DropDownList;
                    ddlnIV_ang.DataTextField = "niveau_courant_ang";
                    ddlnIV_ang.DataValueField = "niveau_courant_ang";

                    ddlnIV_ang.Items.Add(new ListItem("NN", "NN"));
                    ddlnIV_ang.DataSource = service.bind_niveau_ang();
                    ddlnIV_ang.DataBind();
                    ddlnIV_ang.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
                    ddlnIV_ang.SelectedItem.Selected = false;
                    ddlnIV_ang.Items.FindByText("Veuillez choisir").Selected = true;
                }

        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //switch back to default mode
            Gridstudent.EditIndex = -1;
            //Bind the grid
            bind();
        }

        


        protected void GrdEmpData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            id_ens = Session["ID_ENS"].ToString();

            if (rblangue.SelectedValue == "FR")
            {

                ancien_niv_fr = service.getAncien_niveau_fr(lblid.Text);


                DropDownList ddlniv_fr = (DropDownList)Gridstudent.Rows[e.RowIndex].FindControl("ddlniveau_fr");
                try
                {
                    DataTable dtt = new DataTable();

                    //GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
                    //DropDownList duty = (DropDownList)gvr.FindControl("ddlniveau_ang");
                  
                    TextBox1.Text = ddlniv_fr.SelectedItem.Value;
                    string val1 = TextBox1.Text;

                    string val2 = ancien_niv_fr;
                    string message;
                    message = "alert('Le niveau est modifié avec succès')";

                    //if (val1 == "NN")
                    //{
                     
                    //    service.Enreg_niv_langue(lblid.Text, rblangue.SelectedValue, ddlniv_fr.SelectedValue, ancien_niv_fr, id_ens);
                    //    service.Update_niv_etud_fr(lblid.Text, ddlniv_fr.SelectedValue);
                    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    
                    //}
                    //else
                    //    if (val1.CompareTo(val2) < 0)
                    //    {

                    //        if (val2 == "NN")
                    //        {

                    //            service.Enreg_niv_langue(lblid.Text, rblangue.SelectedValue, ddlniv_fr.SelectedValue, ancien_niv_fr, id_ens);
                    //            service.Update_niv_etud_fr(lblid.Text, ddlniv_fr.SelectedValue);

                    //            //Response.Write(@"<script language='javascript'>alert('Le niveau est modifié avec succès');</script>");
                    //            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    
                    //        }
                    //        else
                    //        {

                    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

                    //            ddlniv_fr.BackColor = System.Drawing.Color.Red;

                    //        }

                    //    }

                    //    else
                    //    {
                    //        {

                               service.Enreg_niv_langue(lblid.Text, rblangue.SelectedValue, ddlniv_fr.SelectedValue, ancien_niv_fr, id_ens);
                                service.Update_niv_etud_fr(lblid.Text, ddlniv_fr.SelectedValue);
                                //Response.Write(@"<script language='javascript'>alert('Le niveau est modifié avec succès');</script>");
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    
                            }
                        
                    //}
                    //catch
                    //{
                    //    Response.Write(@"<script language='javascript'>alert('Erreur de serveur!');</script>");
                    //}

                    /*
                     
                     if (val1.CompareTo(val2) < 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

                        // Response.Write(@"<script language='javascript'>alert('Il faut garder le même niveau ou bien un niveau supérieur');</script>");
                    }

                    else
                    {
                        service.Enreg_niv_langue(lblid.Text, rblangue.SelectedValue, ddlniv_fr.SelectedValue, ancien_niv_fr, id_ens);
                        service.Update_niv_etud_fr(lblid.Text, ddlniv_fr.SelectedValue);
                        Response.Write(@"<script language='javascript'>alert('Le niveau est modifié avec succès');</script>");
                    }

                     */

                //}
                catch
                {
                    Response.Write(@"<script language='javascript'>alert('Erreur de serveur');</script>");
                }

            }

            else
                if (rblangue.SelectedValue == "AN")
                {

                    ancien_niv_ang = service.getAncien_niveau_ang(lblid.Text);

                    Label lblId = (Label)Gridstudent.Rows[e.RowIndex].FindControl("lblId");
                    DropDownList ddlniv_ang = (DropDownList)Gridstudent.Rows[e.RowIndex].FindControl("ddlniveau_ang");
                    try
                    {
                        DataTable dtt = new DataTable();
                        TextBox1.Text = ddlniv_ang.SelectedItem.Value;
                        string val1 = TextBox1.Text;
                      string val2 = ancien_niv_ang;
                      string message;
                      message = "alert('Le niveau est modifié avec succès')";

                      //if (val1 == "NN")
                      //{

                      //    service.Enreg_niv_langue(lblid.Text, rblangue.SelectedValue, ddlniv_ang.SelectedValue, ancien_niv_ang, id_ens);
                      //    service.Update_niv_etud_ang(lblid.Text, ddlniv_ang.SelectedValue);
                      //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                      //}
                      //else
                      //    if (val1.CompareTo(val2) < 0)
                      //    {

                      //        if (val2 == "NN")
                      //        {

                      //            service.Enreg_niv_langue(lblid.Text, rblangue.SelectedValue, ddlniv_ang.SelectedValue, ancien_niv_ang, id_ens);
                      //            service.Update_niv_etud_ang(lblid.Text, ddlniv_ang.SelectedValue);

                      //            //Response.Write(@"<script language='javascript'>alert('Le niveau est modifié avec succès');</script>");
                      //            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                      //        }
                      //        else
                      //        {

                      //            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

                      //            ddlniv_ang.BackColor = System.Drawing.Color.Red;

                      //        }

                      //    }

                      //    else
                      //    {
                      //        {

                                  service.Enreg_niv_langue(lblid.Text, rblangue.SelectedValue, ddlniv_ang.SelectedValue, ancien_niv_ang, id_ens);
                                    service.Update_niv_etud_ang(lblid.Text, ddlniv_ang.SelectedValue);
                                  //Response.Write(@"<script language='javascript'>alert('Le niveau est modifié avec succès');</script>");
                                  ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                              }
                          //}
                    
                        //if (val1.CompareTo(val2) < 0)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

                        //    // Response.Write(@"<script language='javascript'>alert('Il faut garder le même niveau ou bien un niveau supérieur');</script>");
                        //}

                        //else
                        //{


                        //    service.Enreg_niv_langue(lblid.Text, rblangue.SelectedValue, ddlniv_ang.SelectedValue, ancien_niv_ang, id_ens);
                        //    service.Update_niv_etud_ang(lblid.Text, ddlniv_ang.SelectedValue);
                        //    Response.Write(@"<script language='javascript'>alert('Le niveau est modifié avec succès');</script>");
                        //}
                        //UpdatePanel1.Update();
                        //
                    //}
                    catch
                    {
                        Response.Write(@"<script language='javascript'>alert('Erreur de serveur!');</script>");
                    }
                    // 
                }

            //

           Gridstudent.EditIndex = -1;

            bind();

        }
        protected void ddlannee_deb_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlannee_deb.SelectedValue != null)
            {

               id_ens = Session["ID_ENS"].ToString();
                ddclasse.DataTextField = "code_cl";
                ddclasse.DataValueField = "code_cl";

                ddclasse.DataSource = service.bind_classes_1516(id_ens,ddlannee_deb.SelectedValue);

                ddclasse.DataBind();

                ddclasse.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
                ddclasse.SelectedItem.Selected = false;
                ddclasse.Items.FindByText("Veuillez choisir").Selected = true;
            }

        }

        protected void ddclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddclasse.SelectedValue != null)
            {
                RadComboBox1.DataTextField = "NOM";
                RadComboBox1.DataValueField = "NOM";
                RadComboBox1.DataSource = service.bind_Nom_Etud(ddclasse.SelectedValue, ddlannee_deb.SelectedValue);

                RadComboBox1.DataBind();
            }
        }

        protected void RadComboBox1_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lblid.Text = service.Get_ID_ETUD(RadComboBox1.SelectedValue);
            Gridstudent.DataSource = service.bind_niveau_etudiant(lblid.Text);
            Gridstudent.DataBind();
            Gridstudent.Visible = true;
        }


        protected void OnCheckedChanged(object sender, EventArgs e)
        {
           
              bool isUpdateVisible = false;
            Label1.Text = string.Empty;

            //Loop through all rows in GridView
            foreach (GridViewRow row in gvCustomers.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    if (isChecked)
                        row.RowState = DataControlRowState.Edit;

                    for (int i = 3; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Controls.OfType<Label>().FirstOrDefault().Visible = !isChecked;
                        if (row.Cells[i].Controls.OfType<TextBox>().ToList().Count > 0)
                        {
                            row.Cells[i].Controls.OfType<TextBox>().FirstOrDefault().Visible = isChecked;
                        }
                        if (row.Cells[i].Controls.OfType<DropDownList>().ToList().Count > 0)
                        {
                            row.Cells[i].Controls.OfType<DropDownList>().FirstOrDefault().Visible = isChecked;
                        }

                        if (isChecked && !isUpdateVisible)
                        {
                            isUpdateVisible = true;
                        }
                    }
                }
            }
            UpdatePanel1.Update();
            btnUpdate.Visible = isUpdateVisible;
        }

        protected void OnRowDataBoundS(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (rblangue.SelectedValue == "FR")
                {
                    OracleCommand cmd = new OracleCommand("SELECT  DISTINCT e.niveau_courant_fr FROM ESP_ETUDIANT e where e.niveau_courant_fr !='null' AND e.niveau_courant_fr !='NN' ORDER BY e.niveau_courant_fr");
                    DropDownList ddlCountries = (e.Row.FindControl("ddlCountries") as DropDownList);
                    ddlCountries.DataSource = this.ExecuteQuery(cmd, "SELECT");
                    ddlCountries.DataTextField = "niveau_courant_fr";
                    ddlCountries.DataValueField = "niveau_courant_fr";
                   // ddlCountries.Items.Add("NN");
                    ddlCountries.Items.Add(new ListItem("NN", "NN"));
                    ddlCountries.DataBind();
                    string country = (e.Row.FindControl("lblCountry") as Label).Text;
                    //ddlCountries.Items.FindByValue(country).Selected = true;
                }

                else

                    if (rblangue.SelectedValue == "AN")
                    {
                        OracleCommand cmd = new OracleCommand("SELECT  DISTINCT e.niveau_courant_ang FROM ESP_ETUDIANT e where e.niveau_courant_ang!='null' and e.niveau_courant_ang!='NN' ORDER BY e.niveau_courant_ang");
                        DropDownList ddlCountries = (e.Row.FindControl("ddlCountries2") as DropDownList);
                        ddlCountries.DataSource = this.ExecuteQuery(cmd, "SELECT");
                        ddlCountries.DataTextField = "niveau_courant_ang";
                        ddlCountries.DataValueField = "niveau_courant_ang";
                        ddlCountries.Items.Add(new ListItem("NN", "NN"));
                        ddlCountries.DataBind();
                        string country = (e.Row.FindControl("lblCountry2") as Label).Text;
                        //ddlCountries.Items.FindByValue(country).Selected = true;
                    }


            }
        }


        private DataTable ExecuteQuery(OracleCommand cmd, string action)
        {
            //string conString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
            {
                cmd.Connection = con;
                switch (action)
                {
                    case "SELECT":
                        using (OracleDataAdapter sda = new OracleDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                return dt;
                            }
                        }
                    case "UPDATE":
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        break;
                }
                return null;
            }
        }

        protected void Update(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCustomers.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    if (isChecked)
                    {
                        if (rblangue.SelectedValue == "FR")
                        {
                            //try
                            //{
                            DataTable dtt = new DataTable();
                           DropDownList duty = (DropDownList)row.FindControl("ddlCountries");
                            TextBox1.Text = duty.SelectedItem.Value;

                            string val1 = TextBox1.Text;
                            string id_et = gvCustomers.DataKeys[row.RowIndex].Value.ToString();

                            ancien_niv_fr = service.getAncien_niveau_fr(gvCustomers.DataKeys[row.RowIndex].Value.ToString());
                            string val2 = ancien_niv_fr;

                            //if (val1 == "NN")
                            //{

                            //    ancien_niv_fr = service.getAncien_niveau_fr(gvCustomers.DataKeys[row.RowIndex].Value.ToString());
                            //    id_ens = Session["ID_ENS"].ToString();
                            //    service.Enreg_niv_langue(gvCustomers.DataKeys[row.RowIndex].Value.ToString(), rblangue.SelectedValue, row.Cells[3].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value, ancien_niv_fr, id_ens);
                            //    //modifier niveau_fr
                            //    OracleCommand cmd = new OracleCommand("UPDATE Esp_etudiant SET niveau_courant_fr = :niveau_courant_fr WHERE Id_et = :Id_et");

                            //    cmd.Parameters.Add(":niveau_courant_fr", row.Cells[3].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                            //    cmd.Parameters.Add(":Id_et", gvCustomers.DataKeys[row.RowIndex].Value);
                            //    this.ExecuteQuery(cmd, "SELECT");
                            //}
                            //else
                            //    if (val1.CompareTo(val2) < 0)
                            //    {

                            //        if (val2 == "NN")
                            //        {

                            //            ancien_niv_fr = service.getAncien_niveau_fr(gvCustomers.DataKeys[row.RowIndex].Value.ToString());
                            //            id_ens = Session["ID_ENS"].ToString();
                            //            service.Enreg_niv_langue(gvCustomers.DataKeys[row.RowIndex].Value.ToString(), rblangue.SelectedValue, row.Cells[3].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value, ancien_niv_fr, id_ens);

                            //            //modifier niveau_fr

                            //            OracleCommand cmd = new OracleCommand("UPDATE Esp_etudiant SET niveau_courant_fr = :niveau_courant_fr WHERE Id_et = :Id_et");

                            //            cmd.Parameters.Add(":niveau_courant_fr", row.Cells[3].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                            //            cmd.Parameters.Add(":Id_et", gvCustomers.DataKeys[row.RowIndex].Value);
                            //            this.ExecuteQuery(cmd, "SELECT");
                            //        }
                            //        else
                            //        {

                            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

                            //            duty.BackColor = System.Drawing.Color.Red;

                            //        }

                            //    }

                            //    else
                            //    {
                            //        {

                            //            ancien_niv_fr = service.getAncien_niveau_fr(gvCustomers.DataKeys[row.RowIndex].Value.ToString());
                                        id_ens = Session["ID_ENS"].ToString();
                                        service.Enreg_niv_langue(gvCustomers.DataKeys[row.RowIndex].Value.ToString(), rblangue.SelectedValue, row.Cells[3].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value, ancien_niv_fr, id_ens);

                                        //modifier niveau_fr

                                        OracleCommand cmd = new OracleCommand("UPDATE Esp_etudiant SET niveau_courant_fr = :niveau_courant_fr WHERE Id_et = :Id_et");

                                        cmd.Parameters.Add(":niveau_courant_fr", row.Cells[3].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                                        cmd.Parameters.Add(":Id_et", gvCustomers.DataKeys[row.RowIndex].Value);
                                        this.ExecuteQuery(cmd, "SELECT");

                                    //}
                                //}
                            //}
                            //catch
                            //{
                            //    Response.Write(@"<script language='javascript'>alert('Erreur de serveur!');</script>");
                            //}

                        }
                        else
                        {
                            if (rblangue.SelectedValue == "AN")
                            {

                                //try
                                //{
                                DataTable dtt = new DataTable();


                                DropDownList duty = (DropDownList)row.FindControl("ddlCountries2");
                                TextBox1.Text = duty.SelectedItem.Value;

                                string val1 = TextBox1.Text;
                                ancien_niv_ang = service.getAncien_niveau_ang(gvCustomers.DataKeys[row.RowIndex].Value.ToString());
                                id_ens = Session["ID_ENS"].ToString();

                                string val2 = ancien_niv_ang;

                                //if (val1 == "NN")
                                //{

                                //    service.Enreg_niv_langue(gvCustomers.DataKeys[row.RowIndex].Value.ToString(), rblangue.SelectedValue, row.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value, ancien_niv_ang, id_ens);

                                //    OracleCommand cmd = new OracleCommand("UPDATE Esp_etudiant SET  niveau_courant_ang = :niveau_courant_ang WHERE Id_et = :Id_et");

                                //    cmd.Parameters.Add(":niveau_courant_ang", row.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                                //    cmd.Parameters.Add(":Id_ET", gvCustomers.DataKeys[row.RowIndex].Value);
                                //    this.ExecuteQuery(cmd, "SELECT");

                                //}
                                //else
                                //    if (val1.CompareTo(val2) < 0)
                                //    {

                                //        if (val2 == "NN")
                                //        {
                                //            service.Enreg_niv_langue(gvCustomers.DataKeys[row.RowIndex].Value.ToString(), rblangue.SelectedValue, row.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value, ancien_niv_ang, id_ens);

                                //            OracleCommand cmd = new OracleCommand("UPDATE Esp_etudiant SET  niveau_courant_ang = :niveau_courant_ang WHERE Id_et = :Id_et");

                                //            cmd.Parameters.Add(":niveau_courant_ang", row.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                                //            cmd.Parameters.Add(":Id_ET", gvCustomers.DataKeys[row.RowIndex].Value);
                                //            this.ExecuteQuery(cmd, "SELECT");

                                //        }
                                //        else
                                //        {

                                //            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

                                //            duty.BackColor = System.Drawing.Color.Red;

                                //        }

                                //    }

                                //    else
                                //    {
                                //        {

                                            service.Enreg_niv_langue(gvCustomers.DataKeys[row.RowIndex].Value.ToString(), rblangue.SelectedValue, row.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value, ancien_niv_ang, id_ens);

                                            OracleCommand cmd = new OracleCommand("UPDATE Esp_etudiant SET  niveau_courant_ang = :niveau_courant_ang WHERE Id_et = :Id_et");

                                            cmd.Parameters.Add(":niveau_courant_ang", row.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                                            cmd.Parameters.Add(":Id_ET", gvCustomers.DataKeys[row.RowIndex].Value);
                                            this.ExecuteQuery(cmd, "SELECT");


                                        }
                                    //}
                                //}
                                //catch
                                //{
                                //    Response.Write(@"<script language='javascript'>alert('Erreur de serveur!');</script>");
                                //}

                            }



                            /*
                                DataTable dtt = new DataTable();
                                   

                                    ancien_niv_fr = service.getAncien_niveau_fr(gvCustomers.DataKeys[row.RowIndex].Value.ToString());
                                    id_ens = Session["ID_ENS"].ToString();
                                    service.Enreg_niv_langue(gvCustomers.DataKeys[row.RowIndex].Value.ToString(), rblangue.SelectedValue, row.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value, ancien_niv_fr, id_ens);

                                    OracleCommand cmd = new OracleCommand("UPDATE Esp_etudiant SET  niveau_courant_ang = :niveau_courant_ang WHERE Id_et = :Id_et");

                                    cmd.Parameters.Add(":niveau_courant_ang", row.Cells[4].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                                    cmd.Parameters.Add(":Id_ET", gvCustomers.DataKeys[row.RowIndex].Value);
                                    this.ExecuteQuery(cmd, "SELECT");*/
                            //Response.Write(@"<script language='javascript'>alert('Le niveau est modifié avec succès');</script>");

                            //}
                            //}
                            //catch
                            //{
                            //    Response.Write(@"<script language='javascript'>alert('Erreur de serveur!');</script>");
                            //}

                            
                        }
                    }


                }

            

            Response.Write(@"<script language='javascript'>alert('Le niveau est modifié avec succès');</script>");

            //rebind grid maha
            gvCustomers.DataSource = service.bind_niveau_etudiantbycl(ddclasse2.SelectedValue, ddlannee_debM.SelectedValue);
            gvCustomers.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlannee_debM.SelectedValue != null)
            {
                id_ens = Session["ID_ENS"].ToString();
                ddclasse2.DataTextField = "code_cl";
                ddclasse2.DataValueField = "code_cl";
                //ddclasse2.DataSource = service.bind_classes_1516_cup(ddlannee_debM.SelectedValue);
                ddclasse2.DataSource = service.bind_classes_1516(id_ens, ddlannee_debM.SelectedValue);
                
                ddclasse2.DataBind();

                ddclasse2.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
                ddclasse2.SelectedItem.Selected = false;
                ddclasse2.Items.FindByText("Veuillez choisir").Selected = true;
            }
        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlannee_debM.SelectedValue != null)
        //    {
        //        id_ens = Session["ID_ENS"].ToString();
        //        if (id_ens == "V-1187-15" || id_ens == "V-1139-15" || id_ens == "V-1151-15" || id_ens == "V-1153-15" || id_ens == "V-1161-15" || id_ens == "V-88-07")
        //        {
                   
        //            ddclasse2.DataTextField = "code_cl";
        //            ddclasse2.DataValueField = "code_cl";
        //            ddclasse2.DataSource = service.bind_classes_1516_cup(ddlannee_debM.SelectedValue);
        //            ddclasse2.DataBind();

        //            ddclasse2.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
        //            ddclasse2.SelectedItem.Selected = false;
        //            ddclasse2.Items.FindByText("Veuillez choisir").Selected = true;
                
        //        }

        //        else{
                
        //        ddclasse2.DataTextField = "code_cl";
        //        ddclasse2.DataValueField = "code_cl";
        //        ddclasse2.DataSource = service.bind_classes_1516(id_ens,ddlannee_debM.SelectedValue);
        //        ddclasse2.DataBind();

        //        ddclasse2.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
        //        ddclasse2.SelectedItem.Selected = false;
        //        ddclasse2.Items.FindByText("Veuillez choisir").Selected = true;
        //        }
        //    }
        //}

        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            gvCustomers.Visible = true;
            btnUpdate.Visible = true;
            gvCustomers.DataSource = service.bind_niveau_etudiantbycl(ddclasse2.SelectedValue, ddlannee_debM.SelectedValue);
            gvCustomers.DataBind();
        }

        //protected void ddlDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rblangue.SelectedValue == "FR")
        //    {
        //        //get nivvvv maha selected
        //        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        //        DropDownList duty = (DropDownList)gvr.FindControl("ddlniveau_fr");
        //        TextBox1.Text = duty.SelectedItem.Value;
        //        string val1 = TextBox1.Text;
        //        // get ancien niveau

        //        lblid.Text = service.Get_ID_ETUD(RadComboBox1.SelectedValue);
        //        //get the anc_niv
        //        string anc_niv = service.get_anc_niv_student(lblid.Text);
        //        string val2 = anc_niv;

        //        //if (val1.CompareTo(val2) < 0)
        //        //{
        //        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveaux ou bien un niveau supérieur');", true);

        //        //    duty.BackColor = System.Drawing.Color.Red;
        //        //}
        //        //else
        //        //{
        //        //    duty.BackColor = System.Drawing.Color.White;
        //        //}

        //        if (val1.CompareTo(val2) < 0)
        //        {
        //            if (val2 == "NN")
        //            {
        //                duty.BackColor = System.Drawing.Color.White;
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

        //                duty.BackColor = System.Drawing.Color.Red;
        //            }

        //        }
        //        else
        //        {
        //            duty.BackColor = System.Drawing.Color.White;
        //        }


        //    }

        //    else
        //        if (rblangue.SelectedValue == "AN")
        //        {
        //            //get nivvvv maha selected
        //            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        //            DropDownList duty = (DropDownList)gvr.FindControl("ddlniveau_ang");
        //            TextBox1.Text = duty.SelectedItem.Value;
        //            string val1 = TextBox1.Text;
        //            // get ancien niveau

        //            lblid.Text = service.Get_ID_ETUD(RadComboBox1.SelectedValue);
        //            //get the anc_niv
        //            string anc_niv = service.get_anc_niv_studentANG(lblid.Text);
        //            string val2 = anc_niv;

        //            //if (val1.CompareTo(val2) < 0)
        //            //{
        //            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveaux ou bien un niveau supérieur');", true);

        //            //    duty.BackColor = System.Drawing.Color.Red;
        //            //}
        //            //else
        //            //{
        //            //    duty.BackColor = System.Drawing.Color.White;
        //            //}


        //            if (val1.CompareTo(val2) < 0)
        //            {
        //                if (val2 == "NN")
        //                {
        //                    duty.BackColor = System.Drawing.Color.White;
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

        //                    duty.BackColor = System.Drawing.Color.Red;
        //                }

        //            }

        //        }

        //}

        protected void OnCheckedChangedDDD(object sender, EventArgs e)
        {
            bool isUpdateVisible = false;
            CheckBox chk = (sender as CheckBox);
            if (chk.ID == "chkAll")
            {
                foreach (GridViewRow row in gvCustomers.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked = chk.Checked;
                    }
                }
            }
            CheckBox chkAll = (gvCustomers.HeaderRow.FindControl("chkAll") as CheckBox);
            chkAll.Checked = true;
            foreach (GridViewRow row in gvCustomers.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    for (int i = 4; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Controls.OfType<Label>().FirstOrDefault().Visible = !isChecked;
                        if (row.Cells[i].Controls.OfType<TextBox>().ToList().Count > 0)
                        {
                            row.Cells[i].Controls.OfType<TextBox>().FirstOrDefault().Visible = isChecked;
                        }
                        if (row.Cells[i].Controls.OfType<DropDownList>().ToList().Count > 0)
                        {
                            row.Cells[i].Controls.OfType<DropDownList>().FirstOrDefault().Visible = isChecked;
                        }
                        if (isChecked && !isUpdateVisible)
                        {
                            isUpdateVisible = true;
                        }
                        if (!isChecked)
                        {
                            chkAll.Checked = false;
                        }
                    }
                }
            }
            btnUpdate.Visible = isUpdateVisible;
        }
        //protected void ddlDropDownList122_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (rblangue.SelectedValue == "FR")
        //    {
        //        //get nivvvv maha selected
        //        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);

        //        DropDownList duty = (DropDownList)gvr.FindControl("ddlCountries");
        //        TextBox1.Text = duty.SelectedItem.Value;
        //        string val1 = TextBox1.Text;
        //        // get ancien niveau

        //        //   lblid.Text = service.Get_ID_ETUD(RadComboBox1.SelectedValue);
        //        //get the anc_niv

        //        string id_et = gvCustomers.DataKeys[gvr.RowIndex].Value.ToString();
        //        //gvCustomers.DataKeys[row.RowIndex].Value;

        //        string anc_niv = service.get_anc_niv_student(id_et);
        //        //lbl_enc_niv.Text=anc_niv;
        //        string val2 = anc_niv;

        //        if (val1.CompareTo(val2) < 0)
        //        {
        //            if (val2 == "NN")
        //            {
        //                duty.BackColor = System.Drawing.Color.White;
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

        //                duty.BackColor = System.Drawing.Color.Red;
        //            }

        //        }
        //        else
        //        {
        //            duty.BackColor = System.Drawing.Color.White;
        //        }

        //    }
        //    else
        //        if (rblangue.SelectedValue == "AN")
        //        {
        //            //get nivvvv maha selected
        //            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        //            DropDownList duty = (DropDownList)gvr.FindControl("ddlCountries2");
        //            TextBox1.Text = duty.SelectedItem.Value;
        //            string val1 = TextBox1.Text;
        //            // get ancien niveau

        //            //   lblid.Text = service.Get_ID_ETUD(RadComboBox1.SelectedValue);
        //            //get the anc_niv

        //            string id_et = gvCustomers.DataKeys[gvr.RowIndex].Value.ToString();
        //            //gvCustomers.DataKeys[row.RowIndex].Value;

        //            string anc_niv = service.get_anc_niv_studentANG(id_et);
        //            //lbl_enc_niv.Text=anc_niv;
        //            string val2 = anc_niv;

        //             if (val1.CompareTo(val2) < 0)
        //        {
        //            if (val2 == "NN")
        //            {
        //                duty.BackColor = System.Drawing.Color.White;
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Il faut garder le même niveau ou bien un niveau supérieur');", true);

        //                duty.BackColor = System.Drawing.Color.Red;
        //            }

        //        }
        //        else
        //        {
        //            duty.BackColor = System.Drawing.Color.White;
        //        }
              


        //        }



        //}

        protected void Gridstudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}