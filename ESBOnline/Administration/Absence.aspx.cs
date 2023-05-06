﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Types;
using ABSEsprit;

namespace ESPOnline.Administration
{
    public partial class Absence : System.Web.UI.Page
    {

        string id_decid;
        string annee_deb;

        string dateseance1;
        DateTime dateseance2; string ts1; DateTime ts;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_decid"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }


            Label1.Visible = false;
            decimal numseance = decimal.Parse(DdlNumSeance.SelectedValue.ToString());

           // id = "administration";


            //Label2.Text = id;

            if (TBdateseance.SelectedDate.HasValue)
            {

                dateseance1 = TBdateseance.SelectedDate.Value.ToString("dd/MM/yy");
                dateseance2 = TBdateseance.SelectedDate.Value;
                ts = new DateTime(dateseance2.Year, dateseance2.Month, dateseance2.Day);
                ts1 = String.Format("{0:dd/MM/yy}", ts);

            }

            else
            {
                dateseance1 = DateTime.Now.ToString("dd/MM/yy");
                ts1 = String.Format("{0:dd/MM/yy}", dateseance1);
            }



            if (ServicesABS.Instance.verifAbsence(DdlModule.SelectedValue.ToString().Trim(), DropDownList1.SelectedValue.ToString (), DDClasse.SelectedValue.ToString().Trim(), Convert.ToDecimal(DdlNumSeance.SelectedValue), ts1) == true)
            {

                // Response.Write("<script>confirm('voulez vous modifier');</script>");


                BtnCreer.Visible = false;
                BtnModifier.Visible = true;
                GridView1.Enabled = false;
                GridView1.Visible = false;
                GridView2.Enabled = true;
                GridView2.Visible = true;
                CheckBoxAccess.Enabled = false;
                CheckBoxAccess0.Enabled = false;
                //CheckBoxAccess.Checked = false;
                //CheckBoxAccess0.Checked = false;

                Label3.Text = "Ajout est déja effectué voulez vous modifier ?";
                //Response.Write("<script LANGUAGE='JavaScript' >alert('Ajout est déja effectué voulez vous modifier ?')</script>");

            }
            else
            {
                BtnCreer.Visible = true;
                BtnModifier.Visible = false;
                GridView2.Enabled = false;
                GridView2.Visible = false;
                GridView1.Enabled = true;
                GridView1.Visible = true;
                CheckBoxAccess.Enabled = true;
                CheckBoxAccess0.Enabled = true;
                Label3.Text = "";
            }

        }








        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            annee_deb = ServicesABS.Instance.getANNEEDEBs();
            decimal numSeance = Convert.ToDecimal(DdlNumSeance.SelectedValue);
            ServicesABS.Instance.closeConnection();
            ServicesABS.Instance.openconntrans();

            ServicesABS.Instance.Delete_esp_ABS(DdlModule.SelectedValue.ToString(), DDClasse.SelectedValue.ToString(), annee_deb, numSeance, ts1, DropDownList1.SelectedValue.ToString(), Convert.ToDecimal(RadioButtonList3.SelectedValue));
            foreach (GridViewRow gvr in GridView2.Rows)
            {
                annee_deb = ServicesABS.Instance.getANNEEDEBs();
                CheckBox Chekabs1 = (CheckBox)gvr.FindControl("ui_absent1");
                TextBox txtobs1 = (TextBox)gvr.FindControl("txtobservation2");
                DropDownList ddljustif = (DropDownList)gvr.FindControl("ddltypeabs2");
                if (Chekabs1.Checked == true)
                {
                    ServicesABS.Instance.Save_esp_ABS(gvr.Cells[1].Text, DdlModule.SelectedValue, DDClasse.SelectedValue, annee_deb, numSeance, ts1, DropDownList1.SelectedValue.ToString(), id_decid, Convert.ToDecimal(RadioButtonList3.SelectedValue),ddljustif.SelectedValue.ToString (), null,txtobs1.Text , null, null);


                }


            }
            ServicesABS.Instance.commicttrans();

            ServicesABS.Instance.closeConnection();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Modification  avec Succées')</script>");
            // Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }





        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {



        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            // decimal absence = 0;
            decimal numSeance = Convert.ToDecimal(DdlNumSeance.SelectedValue);

            if (!CheckBoxAccess0.Checked && !CheckBoxAccess.Checked)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Vous devez etablir type par défaut Présence/Absence ')</script>");

            }

            else if (DdlNumSeance.SelectedIndex == 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('vous devez choisir une séance ')</script>");

            }
            else if (TBdateseance.SelectedDate.HasValue ==false)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('vous devez choisir une date séance ')</script>");

            }

            else
            {

                ServicesABS.Instance.closeConnection();
                ServicesABS.Instance.openconntrans();
                //Test manuelle
                //ServicesABS.Instance.Save_esp_entete_ABS("MT-07", "2013", 1, "4GL1", 1, OracleDate.GetSysDate(), "P-421-11", "P-421-11");
                //  ServicesABS.Instance.Save_esp_ABS("11-3MT-772", "SI-06", "5INFOA3", "2013", 1, OracleDate.GetSysDate(), "P-415-11", "P-415-11", 1, "N", "N", "", "N", "N");


                if (ServicesABS.Instance.verifAbsence(DdlModule.SelectedValue.ToString().Trim(), DropDownList1.SelectedValue.ToString (), DDClasse.SelectedValue.ToString().Trim(), numSeance, ts1) == true)
                {
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Ajout est déja effectué voulez vous modifier ?')</script>");
                    BtnCreer.Visible = false;
                    BtnModifier.Visible = true;
                }

                else
                {
                    annee_deb = ServicesABS.Instance.getANNEEDEBs();
                    ServicesABS.Instance.Save_esp_entete_ABS(DdlModule.SelectedValue, annee_deb, Convert.ToDecimal(RadioButtonList3.SelectedValue), DDClasse.SelectedValue, numSeance, ts1, DropDownList1.SelectedValue.ToString(), id_decid);
                    //if (numSeance == 1)
                    //{
                    //    ServicesABS.Instance.Save_esp_entete_ABS(DdlModule.SelectedValue, "2017", Convert.ToDecimal(RadioButtonList3.SelectedValue), DDClasse.SelectedValue, 2, ts1, id, id);
                    //}
                    //if (numSeance == 3)
                    //{
                    //    ServicesABS.Instance.Save_esp_entete_ABS(DdlModule.SelectedValue, "2017", Convert.ToDecimal(RadioButtonList3.SelectedValue), DDClasse.SelectedValue, 4, ts1, id, id);
                    //}


                    foreach (GridViewRow gvr in GridView1.Rows)
                    {

                        CheckBox Chekabs1 = (CheckBox)gvr.FindControl("ui_absent");


                        TextBox txtobs = (TextBox)gvr.FindControl("txtobservation");

                        DropDownList ddljustif = (DropDownList)gvr.FindControl("ddltypeabs1");


                        if (Chekabs1.Checked == true)
                        {
                            annee_deb = ServicesABS.Instance.getANNEEDEBs();
                            ServicesABS.Instance.Save_esp_ABS(gvr.Cells[1].Text, DdlModule.SelectedValue, DDClasse.SelectedValue, annee_deb, numSeance, ts1, DropDownList1.SelectedValue.ToString(), id_decid, Convert.ToDecimal(RadioButtonList3.SelectedValue),ddljustif.SelectedValue.ToString (), null, txtobs.Text, null,null );

                            //if (numSeance == 1)
                            //{
                            //    ServicesABS.Instance.Save_esp_ABS(gvr.Cells[1].Text, DdlModule.SelectedValue, DDClasse.SelectedValue, "2017", 2, ts1, id, id, Convert.ToDecimal(RadioButtonList3.SelectedValue), null, null, null, null, null);

                            //}
                            //if (numSeance == 3)
                            //{
                            //    ServicesABS.Instance.Save_esp_ABS(gvr.Cells[1].Text, DdlModule.SelectedValue, DDClasse.SelectedValue, "2017", 4, ts1, id, id, Convert.ToDecimal(RadioButtonList3.SelectedValue), null, null, null, null, null);

                            //}
                        }


                    }
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Ajout avec Succées')</script>");
                    ServicesABS.Instance.commicttrans();

                    ServicesABS.Instance.closeConnection();



                }

            }


        }




     

        protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlModule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlNumSeance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = DdlNumSeance.SelectedValue;
        }

        protected void CheckBoxAccess_CheckedChanged(object sender, EventArgs e)
        {


            if (CheckBoxAccess.Checked == true)
            {
                CheckBoxAccess0.Enabled = false;

            }
            else
            {
                CheckBoxAccess.Enabled = true;
            }

        }

        protected void CheckBoxAccess0_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAccess0.Checked == true)
            {
                CheckBoxAccess.Enabled = false;

            }
            else
            {
                CheckBoxAccess.Enabled = true;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr1 in GridView1.Rows)
            {
                RadioButtonList Chekabs1 = (RadioButtonList)gvr1.FindControl("RadioButtonList1");
                Chekabs1.SelectedIndex = 1;

            }
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}