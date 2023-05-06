using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;
using ESPSuiviEncadrement;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Affect : System.Web.UI.Page
    {
               string x;
        string y;
        string z;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UP"] == null || Session["ID_ENS"]==null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            x = Session["UP"].ToString().Trim();
            y = Session["Nom_ENS"].ToString().Trim();
            z = Session["ID_ENS"].ToString().Trim();

            Labelnomens.Text = Session["NOM_ENS"].ToString();
            Labelup.Text = Session["UP"].ToString();


            Label1.Text = "";
            if (GridView1.Rows.Count == 0)
            {
                Label1.Text = "grid view have no data";

            }

            if (!IsPostBack)
            {
                if (Session["UP"] == null)
                {
                    Response.Redirect("Default.aspx");
                }

                Label1.Text = "";
                this.BindGrid();

                if (GridView1.Rows.Count == 0)
                {
                    Label1.Text = "grid view have no data";

                }
            }
        }
        private void BindGrid()
        {
            decimal num_sem = Entreprise.Instance.getNumSemestre();
            string annee_deb = Entreprise.Instance.getAnneeDeb();
            if (CBmodules.Checked == true)
            {
                OracleCommand cmd = new OracleCommand("SELECT ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE,(select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as designation,  ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS)as dd,CHARGE_ENS1_P1,CHARGE_ENS1_P2  ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2=ESP_ENSEIGNANT.ID_ENS)as dd2,CHARGE_ENS2_P1,CHARGE_ENS2_P2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3=ESP_ENSEIGNANT.ID_ENS)as dd3,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4=ESP_ENSEIGNANT.ID_ENS)as dd4,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5=ESP_ENSEIGNANT.ID_ENS)as dd5 FROM   ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '" + annee_deb + "' and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE in (select CODE_MODULE from esp_module where esp_module.up = '" + Session["UP"].ToString() + "') and NUM_SEMESTRE='" + num_sem + "' and code_cl like '" + RadioButtonList2.SelectedValue + "%' and code_module ='" + RadComboBox2.SelectedValue.ToString().Trim() + "' order by code_cl");
                GridView1.DataSource = this.ExecuteQuery(cmd, "SELECT");
                GridView1.DataBind();

            }
            else
            {
                OracleCommand cmd = new OracleCommand("SELECT ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE,(select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as designation,  ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS=ESP_ENSEIGNANT.ID_ENS)as dd ,CHARGE_ENS1_P1,CHARGE_ENS1_P2  ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2=ESP_ENSEIGNANT.ID_ENS)as dd2,CHARGE_ENS2_P1,CHARGE_ENS2_P2 ,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3=ESP_ENSEIGNANT.ID_ENS)as dd3,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4=ESP_ENSEIGNANT.ID_ENS)as dd4,(select ESP_ENSEIGNANT.NOM_ENS from ESP_ENSEIGNANT where ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5=ESP_ENSEIGNANT.ID_ENS)as dd5 FROM   ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '" + annee_deb + "' and ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE in (select CODE_MODULE from esp_module where esp_module.up = '" + Session["UP"].ToString() + "') and NUM_SEMESTRE='" + num_sem + "' and code_cl like '" + RadioButtonList2.SelectedValue + "%' order by code_cl");
                GridView1.DataSource = this.ExecuteQuery(cmd, "SELECT");
                GridView1.DataBind();
            }

        }
        private DataTable ExecuteQuery(OracleCommand cmd, string action)
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(conString))
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

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chk = (sender as CheckBox);
            if (chk.ID == "CheckBox2")
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked = chk.Checked;
                    }
                }
            }
            CheckBox CheckBox2 = (GridView1.HeaderRow.FindControl("CheckBox2") as CheckBox);
            CheckBox2.Checked = true;


        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            decimal num_sem = Entreprise.Instance.getNumSemestre();
            string annee_deb = Entreprise.Instance.getAnneeDeb();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox Chekcc = (CheckBox)row.FindControl("CheckBox1");
               // TextBox textp1 = (TextBox)row.FindControl("TBEnsP1");
                //TextBox textp2 = (TextBox)row.FindControl("TBEnsP2");

                if (Chekcc.Checked == true)
                {

                    if (RadioButtonList1.SelectedValue == "1")
                    {//if (isChecked)
                        //{

                        //string chp1 = textp1.Text.Trim();
                        //chp1 = chp1.Replace(".", ",");
                        //decimal chargep1 = decimal.Parse(chp1);

                        //string chp2 = textp2.Text.Trim();
                        //chp2 = chp2.Replace(".", ",");
                        //decimal chargep2 = decimal.Parse(chp2);
                        OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS= :ID_ENS WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='"+num_sem+"' AND NUM_SEMESTRE='"+num_sem+"'");
                       
                       // OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS= :ID_ENS,CHARGE_ENS1_P1=" + chargep1 + ",CHARGE_ENS1_P2=" + chargep2 + " WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='"+num_sem+"' AND NUM_SEMESTRE='"+num_sem+"'");
                        //cmd.Parameters.AddWithValue("@ContactName", row.Cells[1].Controls.OfType<TextBox>().FirstOrDefault().Text);
                        //cmd.Parameters.AddWithValue("@Country", row.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                        //cmd.Parameters.AddWithValue("@CustomerId", gvCustomers.DataKeys[row.RowIndex].Value);


                        OracleParameter prmID_ENS = new OracleParameter("@ID_ENS", OracleDbType.Varchar2);
                        prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS);

                        OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
                        prmCODE_MODULE.Value = row.Cells[1].Text;
                        cmd.Parameters.Add(prmCODE_MODULE);
                        OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
                        prmCODE_CL.Value = row.Cells[3].Text;
                        cmd.Parameters.Add(prmCODE_CL);

                        //OracleParameter prmCHARGE_ENS1_P1 = new OracleParameter("@CHARGE_ENS1_P1", OracleDbType.Decimal);

                        //decimal a = 44;
                        //prmCHARGE_ENS1_P1.Value = a;
                        //cmd.Parameters.Add(prmCHARGE_ENS1_P1);


                        ////  string chp1 = textp1.Text.Trim();
                        //  //chp1 = chp1.Replace(".", ",");
                        //  //decimal chargep1 = decimal.Parse(chp1);
                        //  prmCHARGE_ENS1_P1.Value = 4;
                        //  cmd.Parameters.Add(prmCHARGE_ENS1_P1);

                        //  OracleParameter prmCHARGE_ENS1_P2 = new OracleParameter("@CHARGE_ENS1_P2", OracleDbType.Int32);

                        //  //string chp2 = string.Format("{0:0.00}", textp2.Text);
                        //  //chp2 = chp2.Replace(".", ",");
                        //  //decimal chargep2 = decimal.Parse(chp2);
                        //  prmCHARGE_ENS1_P2.Value = 4;
                        //  cmd.Parameters.Add(prmCHARGE_ENS1_P2);


                        this.ExecuteQuery(cmd, "SELECT");
                    }
                    if (RadioButtonList1.SelectedValue == "2")
                    {//if (isChecked)
                        //{

                        OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS2= :ID_ENS2 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='"+num_sem+"' AND NUM_SEMESTRE='"+num_sem+"'");
                        //cmd.Parameters.AddWithValue("@ContactName", row.Cells[1].Controls.OfType<TextBox>().FirstOrDefault().Text);
                        //cmd.Parameters.AddWithValue("@Country", row.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                        //cmd.Parameters.AddWithValue("@CustomerId", gvCustomers.DataKeys[row.RowIndex].Value);


                        OracleParameter prmID_ENS = new OracleParameter("@ID_ENS2", OracleDbType.Varchar2);
                        prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS);

                        OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
                        prmCODE_MODULE.Value = row.Cells[1].Text;
                        cmd.Parameters.Add(prmCODE_MODULE);
                        OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
                        prmCODE_CL.Value = row.Cells[3].Text;
                        cmd.Parameters.Add(prmCODE_CL);

                        this.ExecuteQuery(cmd, "SELECT");
                    }
                    if (RadioButtonList1.SelectedValue == "3")
                    {//if (isChecked)
                        //{

                        OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS3= :ID_ENS3 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='"+num_sem+"' AND NUM_SEMESTRE='"+num_sem+"'");
                        //cmd.Parameters.AddWithValue("@ContactName", row.Cells[1].Controls.OfType<TextBox>().FirstOrDefault().Text);
                        //cmd.Parameters.AddWithValue("@Country", row.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                        //cmd.Parameters.AddWithValue("@CustomerId", gvCustomers.DataKeys[row.RowIndex].Value);


                        OracleParameter prmID_ENS = new OracleParameter("@ID_ENS3", OracleDbType.Varchar2);
                        prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS);

                        OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
                        prmCODE_MODULE.Value = row.Cells[1].Text;
                        cmd.Parameters.Add(prmCODE_MODULE);
                        OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
                        prmCODE_CL.Value = row.Cells[3].Text;
                        cmd.Parameters.Add(prmCODE_CL);

                        this.ExecuteQuery(cmd, "SELECT");
                    }

                    if (RadioButtonList1.SelectedValue == "4")
                    {//if (isChecked)
                        //{

                        OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS4= :ID_ENS4 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='"+num_sem+"' AND NUM_SEMESTRE='"+num_sem+"'");
                        //cmd.Parameters.AddWithValue("@ContactName", row.Cells[1].Controls.OfType<TextBox>().FirstOrDefault().Text);
                        //cmd.Parameters.AddWithValue("@Country", row.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                        //cmd.Parameters.AddWithValue("@CustomerId", gvCustomers.DataKeys[row.RowIndex].Value);


                        OracleParameter prmID_ENS = new OracleParameter("@ID_ENS4", OracleDbType.Varchar2);
                        prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS);

                        OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
                        prmCODE_MODULE.Value = row.Cells[1].Text;
                        cmd.Parameters.Add(prmCODE_MODULE);
                        OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
                        prmCODE_CL.Value = row.Cells[3].Text;
                        cmd.Parameters.Add(prmCODE_CL);

                        this.ExecuteQuery(cmd, "SELECT");
                    }
                    if (RadioButtonList1.SelectedValue == "5")
                    {//if (isChecked)
                        //{

                        OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS5= :ID_ENS5 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='"+num_sem+"' AND NUM_SEMESTRE='"+num_sem+"'");
                        //cmd.Parameters.AddWithValue("@ContactName", row.Cells[1].Controls.OfType<TextBox>().FirstOrDefault().Text);
                        //cmd.Parameters.AddWithValue("@Country", row.Cells[2].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value);
                        //cmd.Parameters.AddWithValue("@CustomerId", gvCustomers.DataKeys[row.RowIndex].Value);


                        OracleParameter prmID_ENS = new OracleParameter("@ID_ENS5", OracleDbType.Varchar2);
                        prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS);

                        OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
                        prmCODE_MODULE.Value = row.Cells[1].Text;
                        cmd.Parameters.Add(prmCODE_MODULE);
                        OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
                        prmCODE_CL.Value = row.Cells[3].Text;
                        cmd.Parameters.Add(prmCODE_CL);

                        this.ExecuteQuery(cmd, "SELECT");
                    }

                }

            }

            BindGrid();
        }

        protected void CBmodules_CheckedChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["UP"] = x;
            Session["NOM_ENS"] = y;
            Session["ID_ENS"] = z;
            Response.Redirect("ChargeEns.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        OracleCommand cmd = new OracleCommand("SELECT DISTINCT id_ens,nom_ens FROM esp_enseignant");
        //        RadComboBox ddlCountries2 = (e.Row.FindControl("ddlCountries") as RadComboBox);
        //        DropDownList ddlCountries = (e.Row.FindControl("ddlCountries2") as DropDownList);
        //        //DropDownList ddlCountries2 = (e.Row.FindControl("ddlCountries2") as DropDownList);

        //          ddlCountries.DataSource = this.ExecuteQuery(cmd, "SELECT");

        //        ddlCountries.DataTextField = "nom_ens";
        //        ddlCountries.DataValueField = "id_ens";
        //        ddlCountries.DataBind();
        //        //ddlCountries.Items.Insert(0, "");
        //        ddlCountries2.DataSource = this.ExecuteQuery(cmd, "SELECT");
        //        ddlCountries2.DataTextField = "nom_ens";
        //        ddlCountries2.DataValueField = "id_ens";
        //        ddlCountries2.DataBind();
        //        //ddlCountries2.Items.Insert(0, "");
        //        //string country = (e.Row.FindControl("lblCountry") as Label).Text;
        //        //  ddlCountries.Items.FindByValue(country).Selected = true;
        //    }
        //}

    }
}