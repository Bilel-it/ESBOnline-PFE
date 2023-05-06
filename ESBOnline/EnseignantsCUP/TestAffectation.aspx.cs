using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using ESPSuiviEncadrement;
using System.Data;
using System.Configuration;
using PlanEtude;
//using ClosedXML.Excel;
using System.IO;


namespace ESPOnline.EnseignantsCUP
{
    public partial class TestAffectation : System.Web.UI.Page
    {
        string x;
        string y;
        string z;

        string c1p1;
        string c1p2;
        string c2p1;
        string c2p2;
        string c3p1;
        string c3p2;
        string c4p1;
        string c4p2;
        string c5p1;
        string c5p2;
        string ens1;
        string ens2;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            x = Session["UP"].ToString().Trim();
            y = Session["Nom_ENS"].ToString().Trim();
            z = Session["ID_ENS"].ToString().Trim();

            Labelnomens.Text = Session["NOM_ENS"].ToString();
            Labelup.Text = Session["UP"].ToString();


            Label1.Text = "";
            //if (GridView1.Rows.Count == 0)
            //{
            //    Label1.Text = "grid view have no data";

            //}

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
                Button1.Visible = false;
            }
        }
        private void BindGrid()
        {
            decimal num_sem = Entreprise.Instance.getNumSemestre();
            string annee_deb = Entreprise.Instance.getAnneeDeb();

            if (CBmodules.Checked == true)
            {
                if (RadioButtonList3.SelectedValue != "3")
                {
                    GridView1.DataSource = Affectation.Instance.BindAffectation(RadioButtonList3.SelectedValue, true, RadComboBox2.SelectedValue, RadioButtonList2.SelectedValue, Session["UP"].ToString());
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = Affectation.Instance.BindAffectation(RadioButtonList3.SelectedValue, true, RadComboBox2.SelectedValue, RadioButtonList2.SelectedValue, Session["UP"].ToString());
                    GridView1.DataBind();
                }

            }
            else
            {
                if (RadioButtonList3.SelectedValue != "3")
                {
                    GridView1.DataSource = Affectation.Instance.BindAffectation(RadioButtonList3.SelectedValue, false, RadComboBox2.SelectedValue, RadioButtonList2.SelectedValue, Session["UP"].ToString());
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = Affectation.Instance.BindAffectation(RadioButtonList3.SelectedValue, false, RadComboBox2.SelectedValue, RadioButtonList2.SelectedValue, Session["UP"].ToString());
                    GridView1.DataBind();
                }
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
                        row.Cells[1].Controls.OfType<CheckBox>().FirstOrDefault().Checked = chk.Checked;
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
            Label2.Text = "";
            string lstr;
            Button1.Visible = false;
            Button2.Text = "Affecter";
            // Entreprise.Instance.getNumSemestre();
            string annee_deb = Entreprise.Instance.getAnneeDeb();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox Chekcc = (CheckBox)row.FindControl("CheckBox1");
                TextBox textp1 = (TextBox)row.FindControl("TBEnsP1");
                TextBox textp2 = (TextBox)row.FindControl("TBEnsP2");
                TextBox text2p1 = (TextBox)row.FindControl("TBEns2P1");
                TextBox text2p2 = (TextBox)row.FindControl("TBEns2P2");
                TextBox text3p1 = (TextBox)row.FindControl("TBEns3P1");
                TextBox text3p2 = (TextBox)row.FindControl("TBEns3P2");
                TextBox text4p1 = (TextBox)row.FindControl("TBEns4P1");
                TextBox text4p2 = (TextBox)row.FindControl("TBEns4P2");
                TextBox text5p1 = (TextBox)row.FindControl("TBEns5P1");
                TextBox text5p2 = (TextBox)row.FindControl("TBEns5P2");

                var dd1 = row.Cells[8].FindControl("RadComboBox1") as DropDownList;
                var dd2 = row.Cells[9].FindControl("RadComboBox2") as DropDownList;
                var dd3 = row.Cells[10].FindControl("RadComboBox3") as DropDownList;
                var dd4 = row.Cells[11].FindControl("RadComboBox4") as DropDownList;
                var dd5 = row.Cells[12].FindControl("RadComboBox5") as DropDownList;
                var tpep = row.Cells[13].FindControl("type_ep") as DropDownList;
                decimal num_sem = decimal.Parse(row.Cells[0].Text);
                var lblp1 = row.Cells[6].FindControl("Label4") as Label;
                var lblp2 = row.Cells[7].FindControl("Label5") as Label;

                if (Chekcc.Checked == true)
                {

                    string ensp1 = lblp1.Text.Trim();
                    string ensp2 = lblp2.Text.Trim();
                    ens1 = ensp1.Replace(".", ",");
                    ens2 = ensp2.Replace(".", ",");
                    decimal p1 = decimal.Parse(ensp1.Trim());
                    decimal p2 = decimal.Parse(ensp2.Trim());
                    string ch1p1 = textp1.Text.Trim();
                    c1p1 = ch1p1;
                    ch1p1 = ch1p1.Replace(".", ",");
                    decimal charge1p1 = decimal.Parse(ch1p1);
                    string ch1p2 = textp2.Text.Trim();
                    c1p2 = ch1p2;
                    ch1p2 = ch1p2.Replace(".", ",");
                    decimal charge1p2 = decimal.Parse(ch1p2);
                    string ch2p1 = text2p1.Text.Trim();
                    c2p1 = ch2p1;
                    ch2p1 = ch2p1.Replace(".", ",");
                    decimal charge2p1 = decimal.Parse(ch2p1);
                    string ch2p2 = text2p2.Text.Trim();
                    c2p2 = ch2p2;
                    ch2p2 = ch2p2.Replace(".", ",");
                    decimal charge2p2 = decimal.Parse(ch2p2);
                    string ch3p1 = text3p1.Text.Trim();
                    c3p1 = ch3p1;
                    ch3p1 = ch3p1.Replace(".", ",");
                    decimal charge3p1 = decimal.Parse(ch3p1);
                    string ch3p2 = text3p2.Text.Trim();
                    c3p2 = ch3p2;
                    ch3p2 = ch3p2.Replace(".", ",");
                    decimal charge3p2 = decimal.Parse(ch3p2);
                    string ch4p1 = text4p1.Text.Trim();
                    c4p1 = ch4p1;
                    ch4p1 = ch4p1.Replace(".", ",");
                    decimal charge4p1 = decimal.Parse(ch4p1);
                    string ch4p2 = text4p2.Text.Trim();
                    c4p2 = ch4p2;
                    ch4p2 = ch4p2.Replace(".", ",");
                    decimal charge4p2 = decimal.Parse(ch4p2);
                    string ch5p1 = text5p1.Text.Trim();
                    c5p1 = ch5p1;
                    ch5p1 = ch5p1.Replace(".", ",");
                    decimal charge5p1 = decimal.Parse(ch5p1);
                    string ch5p2 = text5p2.Text.Trim();
                    c5p2 = ch5p2;
                    ch5p2 = ch5p2.Replace(".", ",");
                    decimal charge5p2 = decimal.Parse(ch5p2);

                    if ((charge1p1 <= p1 && charge1p2 <= p2) || (charge2p1 <= p1 && charge2p2 <= p2) || (charge3p1 <= p1 && charge3p2 <= p2) || (charge4p1 <= p1 && charge4p2 <= p2) || (charge5p1 <= p1 && charge5p2 <= p2))
                    {
                        OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET TYPE_EPREUVE=:TYPE_EPREUVE,ID_ENS= :ID_ENS,ID_ENS2= :ID_ENS2,CHARGE_ENS1_P1=:CHARGE_ENS1_P1,CHARGE_ENS1_P2=:CHARGE_ENS1_P2,CHARGE_ENS2_P1=:CHARGE_ENS2_P1,CHARGE_ENS2_P2=:CHARGE_ENS2_P2,ID_ENS3= :ID_ENS3,ID_ENS4= :ID_ENS4,ID_ENS5= :ID_ENS5,CHARGE_ENS3_P1=:CHARGE_ENS3_P1,CHARGE_ENS3_P2=:CHARGE_ENS3_P2,CHARGE_ENS4_P1=:CHARGE_ENS4_P1,CHARGE_ENS4_P2=:CHARGE_ENS4_P2,CHARGE_ENS5_P1=:CHARGE_ENS5_P1,CHARGE_ENS5_P2=:CHARGE_ENS5_P2 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND ANNEE_DEB='2014'");
                        OracleParameter prmtpep = new OracleParameter("@TYPE_EPREUVE", OracleDbType.Varchar2);
                        prmtpep.Value = tpep.SelectedValue.ToString();
                        cmd.Parameters.Add(prmtpep);
                        OracleParameter prmID_ENS = new OracleParameter("@ID_ENS", OracleDbType.Varchar2);
                        prmID_ENS.Value = dd1.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS);
                        OracleParameter prmID_ENS2 = new OracleParameter("@ID_ENS2", OracleDbType.Varchar2);
                        prmID_ENS2.Value = dd2.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS2);

                        OracleParameter prmCHARGE_ENS1_P1 = new OracleParameter("@CHARGE_ENS1_P1", OracleDbType.Decimal);
                        prmCHARGE_ENS1_P1.Value = charge1p1;
                        cmd.Parameters.Add(prmCHARGE_ENS1_P1);

                        OracleParameter prmCHARGE_ENS1_P2 = new OracleParameter("@CHARGE_ENS1_P2", OracleDbType.Decimal);
                        prmCHARGE_ENS1_P2.Value = charge1p2;
                        cmd.Parameters.Add(prmCHARGE_ENS1_P2);

                        OracleParameter prmCHARGE_ENS2_P1 = new OracleParameter("@CHARGE_ENS2_P1", OracleDbType.Decimal);
                        prmCHARGE_ENS2_P1.Value = charge2p1;
                        cmd.Parameters.Add(prmCHARGE_ENS2_P1);

                        OracleParameter prmCHARGE_ENS2_P2 = new OracleParameter("@CHARGE_ENS2_P2", OracleDbType.Decimal);
                        prmCHARGE_ENS2_P2.Value = charge2p2;
                        cmd.Parameters.Add(prmCHARGE_ENS2_P2);


                        OracleParameter prmID_ENS3 = new OracleParameter("@ID_ENS3", OracleDbType.Varchar2);
                        prmID_ENS3.Value = dd3.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS3);
                        OracleParameter prmID_ENS4 = new OracleParameter("@ID_ENS4", OracleDbType.Varchar2);
                        prmID_ENS4.Value = dd4.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS4);
                        OracleParameter prmID_ENS5 = new OracleParameter("@ID_ENS5", OracleDbType.Varchar2);
                        prmID_ENS5.Value = dd5.SelectedValue.ToString();
                        cmd.Parameters.Add(prmID_ENS5);

                        OracleParameter prmCHARGE_ENS3_P1 = new OracleParameter("@CHARGE_ENS3_P1", OracleDbType.Decimal);
                        prmCHARGE_ENS3_P1.Value = charge3p1;
                        cmd.Parameters.Add(prmCHARGE_ENS3_P1);

                        OracleParameter prmCHARGE_ENS3_P2 = new OracleParameter("@CHARGE_ENS3_P2", OracleDbType.Decimal);
                        prmCHARGE_ENS3_P2.Value = charge3p2;
                        cmd.Parameters.Add(prmCHARGE_ENS3_P2);

                        OracleParameter prmCHARGE_ENS4_P1 = new OracleParameter("@CHARGE_ENS4_P1", OracleDbType.Decimal);
                        prmCHARGE_ENS4_P1.Value = charge4p1;
                        cmd.Parameters.Add(prmCHARGE_ENS4_P1);

                        OracleParameter prmCHARGE_ENS4_P2 = new OracleParameter("@CHARGE_ENS4_P2", OracleDbType.Decimal);
                        prmCHARGE_ENS4_P2.Value = charge4p2;
                        cmd.Parameters.Add(prmCHARGE_ENS4_P2);

                        OracleParameter prmCHARGE_ENS5_P1 = new OracleParameter("@CHARGE_ENS5_P1", OracleDbType.Decimal);
                        prmCHARGE_ENS5_P1.Value = charge5p1;
                        cmd.Parameters.Add(prmCHARGE_ENS5_P1);

                        OracleParameter prmCHARGE_ENS5_P2 = new OracleParameter("@CHARGE_ENS5_P2", OracleDbType.Decimal);
                        prmCHARGE_ENS5_P2.Value = charge5p2;
                        cmd.Parameters.Add(prmCHARGE_ENS5_P2);


                        OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
                        prmCODE_MODULE.Value = row.Cells[2].Text;
                        cmd.Parameters.Add(prmCODE_MODULE);
                        OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
                        prmCODE_CL.Value = row.Cells[4].Text;
                        cmd.Parameters.Add(prmCODE_CL);
                        ClientScript.RegisterStartupScript(Page.GetType(), "key", "showNotification('Enregistrement effectué avec succès ' )", true);
                        Affectation.Instance.ExecuteQuery(cmd, "SELECT");
                    }

                    else
                    {
                        string cr = "Ligne : (" + row.RowIndex + ") P1 = " + p1 + " P2 = " + p2;
                        string err1 = "[ ENS1:(P1" + c1p1 + " | P2" + c1p2 + ")";
                        string err2 = "ENS2:(P1" + c2p1 + " | P2" + c2p2 + ")";
                        string err3 = "ENS2:(P1" + c3p1 + " | P2" + c3p2 + ")";
                        string err4 = "ENS4:(P1" + c4p1 + " | P2" + c4p2 + ")";
                        string err5 = "ENS2:(P1" + c5p1 + " | P2" + c5p2 + ") ]";
                        Label2.Text = string.Join(", ", cr, err1, err2, err3, err4, err5);
                    }


                }


            }
            if (Label2.Text == "")
            {
                BindGrid();
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Label2.Text = "";

        //    // Entreprise.Instance.getNumSemestre();
        //    string annee_deb = Entreprise.Instance.getAnneeDeb();
        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //        CheckBox Chekcc = (CheckBox)row.FindControl("CheckBox1");
        //        TextBox textp1 = (TextBox)row.FindControl("TBEnsP1");
        //        TextBox textp2 = (TextBox)row.FindControl("TBEnsP2");
        //        TextBox text2p1 = (TextBox)row.FindControl("TBEns2P1");
        //        TextBox text2p2 = (TextBox)row.FindControl("TBEns2P2");
        //        TextBox text3p1 = (TextBox)row.FindControl("TBEns3P1");
        //        TextBox text3p2 = (TextBox)row.FindControl("TBEns3P2");
        //        TextBox text4p1 = (TextBox)row.FindControl("TBEns4P1");
        //        TextBox text4p2 = (TextBox)row.FindControl("TBEns4P2");
        //        TextBox text5p1 = (TextBox)row.FindControl("TBEns5P1");
        //        TextBox text5p2 = (TextBox)row.FindControl("TBEns5P2");

        //        decimal num_sem = decimal.Parse(row.Cells[0].Text);
        //        if (Chekcc.Checked == true)
        //        {

        //            if (RadioButtonList1.SelectedValue == "1")
        //            {//if (isChecked)
        //                //{

        //                //OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS= :ID_ENS WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");
        //                OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS= :ID_ENS,CHARGE_ENS1_P1=:CHARGE_ENS1_P1,CHARGE_ENS1_P2=:CHARGE_ENS1_P2 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");

        //                OracleParameter prmID_ENS = new OracleParameter("@ID_ENS", OracleDbType.Varchar2);
        //                prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
        //                cmd.Parameters.Add(prmID_ENS);
        //                try
        //                {
        //                    string chp1 = textp1.Text.Trim();
        //                    cp1 = chp1;
        //                    chp1 = chp1.Replace(".", ",");
        //                    decimal chargep1 = decimal.Parse(chp1);
        //                    if (chargep1 <= decimal.Parse(row.Cells[6].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS1_P1 = new OracleParameter("@CHARGE_ENS1_P1", OracleDbType.Decimal);
        //                        prmCHARGE_ENS1_P1.Value = chargep1;
        //                        cmd.Parameters.Add(prmCHARGE_ENS1_P1);
        //                    }
        //                }
        //                catch
        //                {
        //                }
        //                try
        //                {
        //                    string chp2 = textp2.Text.Trim();
        //                    cp2 = chp2;
        //                    chp2 = chp2.Replace(".", ",");
        //                    decimal chargep2 = decimal.Parse(chp2);
        //                    if (chargep2 <= decimal.Parse(row.Cells[7].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS1_P2 = new OracleParameter("@CHARGE_ENS1_P2", OracleDbType.Decimal);
        //                        prmCHARGE_ENS1_P2.Value = chargep2;
        //                        cmd.Parameters.Add(prmCHARGE_ENS1_P2);
        //                    }
        //                }
        //                catch
        //                {
        //                }
        //                OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
        //                prmCODE_MODULE.Value = row.Cells[2].Text;
        //                cmd.Parameters.Add(prmCODE_MODULE);
        //                OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
        //                prmCODE_CL.Value = row.Cells[4].Text;
        //                cmd.Parameters.Add(prmCODE_CL);



        //                try
        //                {
        //                    Affectation.Instance.ExecuteQuery(cmd, "SELECT");
        //                }
        //                catch
        //                {
        //                    Label2.Text = "Veuillez vérifier les valeurs (P1:" + cp1 + "-P2 :" + cp2 + ") Ligne :" + (row.RowIndex + 1).ToString();
        //                }
        //            }
        //            if (RadioButtonList1.SelectedValue == "2")
        //            {//if (isChecked)
        //                //{




        //                //OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS2= :ID_ENS2 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");
        //                OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS2= :ID_ENS2,CHARGE_ENS2_P1=:CHARGE_ENS2_P1,CHARGE_ENS2_P2=:CHARGE_ENS2_P2 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");

        //                OracleParameter prmID_ENS = new OracleParameter("@ID_ENS2", OracleDbType.Varchar2);
        //                prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
        //                cmd.Parameters.Add(prmID_ENS);
        //                try
        //                {
        //                    string chp1 = text2p1.Text.Trim();
        //                    cp1 = chp1;
        //                    chp1 = chp1.Replace(".", ",");
        //                    decimal charge2p1 = decimal.Parse(chp1);
        //                    if (charge2p1 <= decimal.Parse(row.Cells[6].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS2_P1 = new OracleParameter("@CHARGE_ENS2_P1", OracleDbType.Decimal);
        //                        prmCHARGE_ENS2_P1.Value = charge2p1;
        //                        cmd.Parameters.Add(prmCHARGE_ENS2_P1);
        //                    }
        //                }
        //                catch
        //                {

        //                }
        //                try
        //                {
        //                    string chp2 = text2p2.Text.Trim();
        //                    cp2 = chp2;
        //                    chp2 = chp2.Replace(".", ",");
        //                    decimal charge2p2 = decimal.Parse(chp2);
        //                    if (charge2p2 <= decimal.Parse(row.Cells[7].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS2_P2 = new OracleParameter("@CHARGE_ENS2_P2", OracleDbType.Decimal);
        //                        prmCHARGE_ENS2_P2.Value = charge2p2;
        //                        cmd.Parameters.Add(prmCHARGE_ENS2_P2);
        //                    }
        //                }
        //                catch
        //                {
        //                }

        //                OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
        //                prmCODE_MODULE.Value = row.Cells[2].Text;
        //                cmd.Parameters.Add(prmCODE_MODULE);
        //                OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
        //                prmCODE_CL.Value = row.Cells[4].Text;
        //                cmd.Parameters.Add(prmCODE_CL);

        //                try
        //                {
        //                    Affectation.Instance.ExecuteQuery(cmd, "SELECT");
        //                }
        //                catch
        //                {
        //                    Label2.Text = "Veuillez vérifier les valeurs (P1:" + cp1 + "-P2 :" + cp2 + ") Ligne :" + row.RowIndex.ToString();
        //                }
        //            }
        //            if (RadioButtonList1.SelectedValue == "3")
        //            {//if (isChecked)
        //                //{

        //                //OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS3= :ID_ENS3 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");
        //                OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS3= :ID_ENS3,CHARGE_ENS3_P1=:CHARGE_ENS3_P1,CHARGE_ENS3_P2=:CHARGE_ENS3_P2 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");

        //                OracleParameter prmID_ENS = new OracleParameter("@ID_ENS3", OracleDbType.Varchar2);
        //                prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
        //                cmd.Parameters.Add(prmID_ENS);
        //                try
        //                {
        //                    string chp1 = text3p1.Text.Trim();
        //                    cp1 = chp1;
        //                    chp1 = chp1.Replace(".", ",");
        //                    decimal charge3p1 = decimal.Parse(chp1);

        //                    if (charge3p1 <= decimal.Parse(row.Cells[6].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS3_P1 = new OracleParameter("@CHARGE_ENS3_P1", OracleDbType.Decimal);
        //                        prmCHARGE_ENS3_P1.Value = charge3p1;
        //                        cmd.Parameters.Add(prmCHARGE_ENS3_P1);
        //                    }
        //                }
        //                catch
        //                {
        //                }
        //                try
        //                {
        //                    string chp2 = text3p2.Text.Trim();
        //                    cp2 = chp2;
        //                    chp2 = chp2.Replace(".", ",");
        //                    decimal charge3p2 = decimal.Parse(chp2);
        //                    if (charge3p2 <= decimal.Parse(row.Cells[7].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS3_P2 = new OracleParameter("@CHARGE_ENS3_P2", OracleDbType.Decimal);
        //                        prmCHARGE_ENS3_P2.Value = charge3p2;
        //                        cmd.Parameters.Add(prmCHARGE_ENS3_P2);
        //                    }
        //                }
        //                catch
        //                {
        //                }

        //                OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
        //                prmCODE_MODULE.Value = row.Cells[2].Text;
        //                cmd.Parameters.Add(prmCODE_MODULE);
        //                OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
        //                prmCODE_CL.Value = row.Cells[4].Text;
        //                cmd.Parameters.Add(prmCODE_CL);

        //                try
        //                {
        //                    Affectation.Instance.ExecuteQuery(cmd, "SELECT");
        //                }
        //                catch
        //                {
        //                    Label2.Text = "Veuillez vérifier les valeurs (P1:" + cp1 + "-P2 :" + cp2 + ") Ligne :" + row.RowIndex.ToString();
        //                }
        //            }

        //            if (RadioButtonList1.SelectedValue == "4")
        //            {//if (isChecked)
        //                //{

        //                //OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS4= :ID_ENS4 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");

        //                OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS4= :ID_ENS4,CHARGE_ENS4_P1=:CHARGE_ENS4_P1,CHARGE_ENS4_P2=:CHARGE_ENS4_P2 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");

        //                OracleParameter prmID_ENS = new OracleParameter("@ID_ENS4", OracleDbType.Varchar2);
        //                prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
        //                cmd.Parameters.Add(prmID_ENS);
        //                try
        //                {
        //                    string chp1 = text4p1.Text.Trim();
        //                    cp1 = chp1;
        //                    chp1 = chp1.Replace(".", ",");
        //                    decimal charge4p1 = decimal.Parse(chp1);
        //                    if (charge4p1 <= decimal.Parse(row.Cells[6].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS4_P1 = new OracleParameter("@CHARGE_ENS4_P1", OracleDbType.Decimal);
        //                        prmCHARGE_ENS4_P1.Value = charge4p1;
        //                        cmd.Parameters.Add(prmCHARGE_ENS4_P1);
        //                    }
        //                }
        //                catch
        //                {

        //                }
        //                try
        //                {
        //                    string chp2 = text4p2.Text.Trim();
        //                    cp2 = chp2;
        //                    chp2 = chp2.Replace(".", ",");
        //                    decimal charge4p2 = decimal.Parse(chp2);
        //                    if (charge4p2 <= decimal.Parse(row.Cells[7].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS4_P2 = new OracleParameter("@CHARGE_ENS4_P2", OracleDbType.Decimal);
        //                        prmCHARGE_ENS4_P2.Value = charge4p2;
        //                        cmd.Parameters.Add(prmCHARGE_ENS4_P2);
        //                    }
        //                }
        //                catch
        //                {
        //                }

        //                OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
        //                prmCODE_MODULE.Value = row.Cells[2].Text;
        //                cmd.Parameters.Add(prmCODE_MODULE);
        //                OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
        //                prmCODE_CL.Value = row.Cells[4].Text;
        //                cmd.Parameters.Add(prmCODE_CL);

        //                try
        //                {
        //                    Affectation.Instance.ExecuteQuery(cmd, "SELECT");
        //                }
        //                catch
        //                {
        //                    Label2.Text = "Veuillez vérifier les valeurs (P1:" + cp1 + "-P2 :" + cp2 + ") Ligne :" + row.RowIndex.ToString();
        //                }

        //            }
        //            if (RadioButtonList1.SelectedValue == "5")
        //            {//if (isChecked)
        //                //{

        //                //OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS5= :ID_ENS5 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");

        //                OracleCommand cmd = new OracleCommand("UPDATE ESP_MODULE_PANIER_CLASSE_SAISO SET ID_ENS5= :ID_ENS5,CHARGE_ENS5_P1=:CHARGE_ENS5_P1,CHARGE_ENS5_P2=:CHARGE_ENS5_P2 WHERE CODE_MODULE= :CODE_MODULE AND CODE_CL= :CODE_CL AND NUM_SEMESTRE='" + num_sem + "' AND NUM_SEMESTRE='" + num_sem + "'");

        //                OracleParameter prmID_ENS = new OracleParameter("@ID_ENS5", OracleDbType.Varchar2);
        //                prmID_ENS.Value = RadComboBox1.SelectedValue.ToString();
        //                cmd.Parameters.Add(prmID_ENS);
        //                try
        //                {
        //                    string chp1 = text5p1.Text.Trim();
        //                    cp1 = chp1;
        //                    chp1 = chp1.Replace(".", ",");
        //                    decimal charge5p1 = decimal.Parse(chp1);
        //                    if (charge5p1 <= decimal.Parse(row.Cells[6].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS5_P1 = new OracleParameter("@CHARGE_ENS5_P1", OracleDbType.Decimal);
        //                        prmCHARGE_ENS5_P1.Value = charge5p1;
        //                        cmd.Parameters.Add(prmCHARGE_ENS5_P1);
        //                    }
        //                }
        //                catch
        //                {

        //                }
        //                try
        //                {
        //                    string chp2 = text5p2.Text.Trim();
        //                    cp2 = chp2;
        //                    chp2 = chp2.Replace(".", ",");
        //                    decimal charge5p2 = decimal.Parse(chp2);
        //                    if (charge5p2 <= decimal.Parse(row.Cells[7].Text))
        //                    {
        //                        OracleParameter prmCHARGE_ENS5_P2 = new OracleParameter("@CHARGE_ENS5_P2", OracleDbType.Decimal);
        //                        prmCHARGE_ENS5_P2.Value = charge5p2;
        //                        cmd.Parameters.Add(prmCHARGE_ENS5_P2);
        //                    }
        //                }
        //                catch
        //                {
        //                }

        //                OracleParameter prmCODE_MODULE = new OracleParameter("@CODE_MODULE", OracleDbType.Varchar2);
        //                prmCODE_MODULE.Value = row.Cells[2].Text;
        //                cmd.Parameters.Add(prmCODE_MODULE);
        //                OracleParameter prmCODE_CL = new OracleParameter("@CODE_CL", OracleDbType.Varchar2);
        //                prmCODE_CL.Value = row.Cells[4].Text;
        //                cmd.Parameters.Add(prmCODE_CL);

        //                try
        //                {

        //                    Affectation.Instance.ExecuteQuery(cmd, "SELECT");
        //                }
        //                catch
        //                {
        //                    Label2.Text = "Veuillez vérifier les valeurs (P1:" + cp1 + "-P2 :" + cp2 + ") Ligne :" + row.RowIndex.ToString();
        //                }
        //            }

        //        }

        //    }

        //    BindGrid();
        //}

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
            if (Button2.Text == "Affecter")
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    var chk = row.Cells[1].FindControl("CheckBox1") as CheckBox;
                    var dd1 = row.Cells[8].FindControl("RadComboBox1") as DropDownList;
                    var dd2 = row.Cells[9].FindControl("RadComboBox2") as DropDownList;
                    var dd3 = row.Cells[10].FindControl("RadComboBox3") as DropDownList;
                    var dd4 = row.Cells[11].FindControl("RadComboBox4") as DropDownList;
                    var dd5 = row.Cells[12].FindControl("RadComboBox5") as DropDownList;
                    var tpep = row.Cells[13].FindControl("type_ep") as DropDownList;

                    var lblCountry1 = row.FindControl("lblCountry1") as Label;
                    var lblCountry2 = row.FindControl("lblCountry2") as Label;
                    var lblCountry3 = row.FindControl("lblCountry3") as Label;
                    var lblCountry4 = row.FindControl("lblCountry4") as Label;
                    var lblCountry5 = row.FindControl("lblCountry5") as Label;
                    var lblCountry6 = row.FindControl("lblCountry6") as Label;
                    if (chk.Checked)
                    {

                        //row.BackColor = System.Drawing.Color.LightGray; //"#c0c0c0";
                        if (dd1 != null)
                        {

                            lblCountry1.Visible = false;
                            dd1.Visible = true;
                            dd1.DataSource = Enseignant.Instance.BindEnseignant();

                            dd1.DataBind();
                            dd1.Items.Insert(0, "");

                            string country1 = lblCountry1.Text;
                            dd1.Items.FindByText(country1).Selected = true;
                        }

                        if (dd2 != null)
                        {

                            lblCountry2.Visible = false;
                            dd2.Visible = true;
                            dd2.DataSource = Enseignant.Instance.BindEnseignant();

                            dd2.DataBind();
                            dd2.Items.Insert(0, "");
                            string country2 = lblCountry2.Text;
                            dd2.Items.FindByText(country2).Selected = true;
                        }
                        if (tpep != null)
                        {
                            lblCountry6.Visible = false;
                            tpep.Visible = true;
                            tpep.DataSource = TypEpreuve.Instance.BindEnseignant();

                            tpep.DataBind();
                            tpep.Items.Insert(0, "");
                            string country6 = lblCountry6.Text;
                            tpep.Items.FindByText(country6).Selected = true;
                        }
                        if (dd3 != null)
                        {

                            lblCountry3.Visible = false;
                            dd3.Visible = true;
                            dd3.DataSource = Enseignant.Instance.BindEnseignant();

                            dd3.DataBind();
                            dd3.Items.Insert(0, "");
                            string country3 = lblCountry3.Text;
                            dd3.Items.FindByText(country3).Selected = true;
                        }
                        if (dd4 != null)
                        {

                            lblCountry4.Visible = false;
                            dd4.Visible = true;
                            dd4.DataSource = Enseignant.Instance.BindEnseignant();

                            dd4.DataBind();
                            dd4.Items.Insert(0, "");
                            string country4 = lblCountry4.Text;
                            dd4.Items.FindByText(country4).Selected = true;
                        }
                        if (dd5 != null)
                        {

                            lblCountry5.Visible = false;
                            dd5.Visible = true;
                            dd5.DataSource = Enseignant.Instance.BindEnseignant();

                            dd5.DataBind();
                            dd5.Items.Insert(0, "");
                            string country5 = lblCountry5.Text;
                            dd5.Items.FindByText(country5).Selected = true;
                        }
                        Button2.Text = "Annuler";
                        Button1.Visible = true;
                        //GridView1.SelectedIndex = row.RowIndex;
                        //ScriptManager.RegisterStartupScript(GridView1, this.GetType(), "highlight",
                        //            string.Format("window.onload = function() {2} focusRow('{0}', {1}); {3};", GridView1.ClientID, row.RowIndex + 1, "{", "}"), true);
                    }
                    else
                    {

                        

                    }
                }
            }
            else
            {
                Button2.Text = "Affecter";
                Button1.Visible = false;
                BindGrid();
            }

        }
        protected void ExportExcel(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable("GridView_Data");
            //foreach (TableCell cell in GridView1.HeaderRow.Cells)
            //{
            //    dt.Columns.Add(cell.Text);
            //}
            //foreach (GridViewRow row in GridView2.Rows)
            //{
            //    dt.Rows.Add();
            //    for (int i = 0; i < row.Cells.Count; i++)
            //    {
            //        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
            //    }
            //}
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(dt);

            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.Charset = "";
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.AddHeader("content-disposition", "attachment;filename=Affectation.xlsx");
            //    using (MemoryStream MyMemoryStream = new MemoryStream())
            //    {
            //        wb.SaveAs(MyMemoryStream);
            //        MyMemoryStream.WriteTo(Response.OutputStream);
            //        Response.Flush();
            //        Response.End();
            //    }
            //}
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.SelectedRow.Focus();
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string FormatNullValue(object objPrice)
        {

            if (objPrice.Equals(DBNull.Value))
            {
                return "0";
            }
            else
            {
                decimal price = Convert.ToDecimal(objPrice);
                if (price <= 0)
                {
                    return "0";
                }
                else
                {
                    return price.ToString();
                }
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

        protected void CheckBox1_Checked_Changed(object sender, EventArgs e)
        {
            //CheckBox chk = (sender as CheckBox);
            //GridViewRow row = chk.NamingContainer as GridViewRow;
            //var dd1 = row.Cells[8].FindControl("RadComboBox1") as DropDownList;
            //var dd2 = row.Cells[9].FindControl("RadComboBox2") as DropDownList;
            //var dd3 = row.Cells[10].FindControl("RadComboBox3") as DropDownList;
            //var dd4 = row.Cells[11].FindControl("RadComboBox4") as DropDownList;
            //var dd5 = row.Cells[12].FindControl("RadComboBox5") as DropDownList;
            //var lblCountry1 = row.FindControl("lblCountry1") as Label;
            //var lblCountry2 = row.FindControl("lblCountry2") as Label;
            //var lblCountry3 = row.FindControl("lblCountry3") as Label;
            //var lblCountry4 = row.FindControl("lblCountry4") as Label;
            //var lblCountry5 = row.FindControl("lblCountry5") as Label;

            //if (chk.Checked == false)
            //{
            //    row.BackColor = System.Drawing.Color.White; //"#c0c0c0";

            //    if (dd1 != null)
            //    {

            //        lblCountry1.Visible = false;
            //        dd1.Visible = true;
            //        dd1.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd1.DataBind();
            //        dd1.Items.Insert(0, "");

            //        string country1 = lblCountry1.Text;
            //        dd1.Items.FindByText(country1).Selected = true;
            //    }
            //    if (dd2 != null)
            //    {

            //        lblCountry2.Visible = false;
            //        dd2.Visible = true;
            //        dd2.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd2.DataBind();
            //        dd2.Items.Insert(0, "");
            //        string country2 = lblCountry2.Text;
            //        dd2.Items.FindByText(country2).Selected = true;
            //    }
            //    if (dd3 != null)
            //    {

            //        lblCountry3.Visible = false;
            //        dd3.Visible = true;
            //        dd3.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd3.DataBind();
            //        dd3.Items.Insert(0, "");
            //        string country3 = lblCountry3.Text;
            //        dd3.Items.FindByText(country3).Selected = true;
            //    }
            //    if (dd4 != null)
            //    {

            //        lblCountry4.Visible = false;
            //        dd4.Visible = true;
            //        dd4.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd4.DataBind();
            //        dd4.Items.Insert(0, "");
            //        string country4 = lblCountry4.Text;
            //        dd4.Items.FindByText(country4).Selected = true;
            //    }
            //    if (dd5 != null)
            //    {

            //        lblCountry5.Visible = false;
            //        dd5.Visible = true;
            //        dd5.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd5.DataBind();
            //        dd5.Items.Insert(0, "");
            //        string country5 = lblCountry5.Text;
            //        dd5.Items.FindByText(country5).Selected = true;
            //    }
            //    GridView1.SelectedIndex = row.RowIndex;
            //    ScriptManager.RegisterStartupScript(GridView1, this.GetType(), "highlight",
            //                string.Format("window.onload = function() {2} focusRow('{0}', {1}); {3};", GridView1.ClientID, row.RowIndex + 1, "{", "}"), true);
            //}
            //else
            //{
            //    row.BackColor = System.Drawing.Color.White;
            //    lblCountry1.Visible = true;
            //    dd1.Items.Clear();
            //    dd1.Visible = false;
            //    lblCountry2.Visible = true;
            //    dd2.Items.Clear();
            //    dd2.Visible = false;
            //    lblCountry3.Visible = true;
            //    dd3.Items.Clear();
            //    dd3.Visible = false;
            //    lblCountry4.Visible = true;
            //    dd4.Items.Clear();
            //    dd4.Visible = false;
            //    lblCountry5.Visible = true;
            //    dd5.Items.Clear();
            //    dd5.Visible = false;

            //}

        }

        protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
        {


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (((CheckBox)e.Row.FindControl("CheckBox1")).Checked == true)
            //    {
            //        // Find the drop-down (say in 3rd column)
            //        var dd1 = e.Row.Cells[8].FindControl("RadComboBox1") as DropDownList;
            //        var dd2 = e.Row.Cells[9].FindControl("RadComboBox2") as DropDownList;
            //        var dd3 = e.Row.Cells[10].FindControl("RadComboBox3") as DropDownList;
            //        var dd4 = e.Row.Cells[11].FindControl("RadComboBox4") as DropDownList;
            //        var dd5 = e.Row.Cells[12].FindControl("RadComboBox5") as DropDownList;
            //        if (dd1 != null)
            //        {
            //            var lblCountry1 = e.Row.FindControl("lblCountry1") as Label;
            //            lblCountry1.Visible = false;
            //            dd1.Visible = true;
            //            dd1.DataSource = Enseignant.Instance.BindEnseignant();

            //            dd1.DataBind();
            //            dd1.Items.Insert(0, "");

            //            string country1 = lblCountry1.Text;
            //            dd1.Items.FindByText(country1).Selected = true;
            //        }
            //        if (dd2 != null)
            //        {
            //            dd2.Visible = true;
            //            dd2.DataSource = Enseignant.Instance.BindEnseignant();

            //            dd2.DataBind();
            //            dd2.Items.Insert(0, "");
            //            string country2 = (e.Row.FindControl("lblCountry2") as Label).Text;
            //            dd2.Items.FindByText(country2).Selected = true;
            //        }
            //        if (dd3 != null)
            //        {
            //            dd3.Visible = true;
            //            dd3.DataSource = Enseignant.Instance.BindEnseignant();

            //            dd3.DataBind();
            //            dd3.Items.Insert(0, "");
            //            string country3 = (e.Row.FindControl("lblCountry3") as Label).Text;
            //            dd3.Items.FindByText(country3).Selected = true;
            //        }
            //        if (dd4 != null)
            //        {
            //            dd4.Visible = true;
            //            dd4.DataSource = Enseignant.Instance.BindEnseignant();

            //            dd4.DataBind();
            //            dd4.Items.Insert(0, "");
            //            string country4 = (e.Row.FindControl("lblCountry4") as Label).Text;
            //            dd4.Items.FindByText(country4).Selected = true;
            //        }
            //        if (dd5 != null)
            //        {
            //            dd5.Visible = true;
            //            dd5.DataSource = Enseignant.Instance.BindEnseignant();

            //            dd5.DataBind();
            //            dd5.Items.Insert(0, "");
            //            string country5 = (e.Row.FindControl("lblCountry5") as Label).Text;
            //            dd5.Items.FindByText(country5).Selected = true;
            //        }
            //        /*
            //        // In case of template fields, use FindControl
            //        dd = e.Row.Cells[2].FindControl("MyDD") as DropDownList;
            //        */
            //    }
            //}


        }

        //protected void UpdateAffectation(object sender, GridViewUpdateEventArgs e)
        //{

        //}

        //protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    BindGrid();
        //}

        //protected void EditAffectation(object sender, GridViewEditEventArgs e)
        //{

        //    //GridView1.EditIndex = e.NewEditIndex;
        //    //BindGrid();
        //}

        protected void GridView1_Row_Command(object sender, GridViewCommandEventArgs e)
        {

            //int index = Convert.ToInt32(e.CommandArgument);
            //string kk = GridView1.Rows[index].Cells[1].Text.ToString();
            //GridView1.Rows[index].ForeColor = System.Drawing.Color.Red;
            //if (e.CommandName == "SelectAffectation")
            //{

            //    // Find the drop-down (say in 3rd column)
            //    var dd1 = GridView1.Rows[index].Cells[8].FindControl("RadComboBox1") as DropDownList;
            //    var dd2 = GridView1.Rows[index].Cells[9].FindControl("RadComboBox2") as DropDownList;
            //    var dd3 = GridView1.Rows[index].Cells[10].FindControl("RadComboBox3") as DropDownList;
            //    var dd4 = GridView1.Rows[index].Cells[11].FindControl("RadComboBox4") as DropDownList;
            //    var dd5 = GridView1.Rows[index].Cells[12].FindControl("RadComboBox5") as DropDownList;
            //    if (dd1 != null)
            //    {
            //        var lblCountry1 = GridView1.Rows[index].FindControl("lblCountry1") as Label;
            //        lblCountry1.Visible = false;
            //        dd1.Visible = true;
            //        dd1.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd1.DataBind();
            //        dd1.Items.Insert(0, "");

            //        string country1 = lblCountry1.Text;
            //        dd1.Items.FindByText(country1).Selected = true;
            //    }
            //    if (dd2 != null)
            //    {
            //        dd2.Visible = true;
            //        dd2.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd2.DataBind();
            //        dd2.Items.Insert(0, "");
            //        string country2 = (GridView1.Rows[index].FindControl("lblCountry2") as Label).Text;
            //        dd2.Items.FindByText(country2).Selected = true;
            //    }
            //    if (dd3 != null)
            //    {
            //        dd3.Visible = true;
            //        dd3.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd3.DataBind();
            //        dd3.Items.Insert(0, "");
            //        string country3 = (GridView1.Rows[index].FindControl("lblCountry3") as Label).Text;
            //        dd3.Items.FindByText(country3).Selected = true;
            //    }
            //    if (dd4 != null)
            //    {
            //        dd4.Visible = true;
            //        dd4.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd4.DataBind();
            //        dd4.Items.Insert(0, "");
            //        string country4 = (GridView1.Rows[index].FindControl("lblCountry4") as Label).Text;
            //        dd4.Items.FindByText(country4).Selected = true;
            //    }
            //    if (dd5 != null)
            //    {
            //        dd5.Visible = true;
            //        dd5.DataSource = Enseignant.Instance.BindEnseignant();

            //        dd5.DataBind();
            //        dd5.Items.Insert(0, "");
            //        string country5 = (GridView1.Rows[index].FindControl("lblCountry5") as Label).Text;
            //        dd5.Items.FindByText(country5).Selected = true;
            //    }

            //}
        }
    }
}