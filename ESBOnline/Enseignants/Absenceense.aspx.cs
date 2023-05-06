using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Types;
using ABSEsprit;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using System.IO;
using System.Data;

namespace ESPOnline.Enseignants
{
    public partial class Absenceens : System.Web.UI.Page
    {

        string id;

        string annee_deb;

        string dateseance1;
        DateTime dateseance2; string ts1; DateTime ts;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            if (!IsPostBack)
            {
                DDClasse.DataSource = ObjectDataSource1;
                DDClasse.DataBind();
                //DDClasse.Items.Insert(0, new ListItem("Choisir", "Choisir"));
                DDClasse.Items.Insert(0, new ListItem("Veuillez choisir", "Veuillez choisir"));
                DDClasse.SelectedItem.Selected = false;
                DDClasse.Items.FindByText("Veuillez choisir").Selected = true;
            }
            Label1.Visible = false;
            decimal numseance = decimal.Parse(DdlNumSeance.SelectedValue.ToString());

            id = Session["ID_ENS"].ToString().Trim();

           
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
            // TBdateseance.Text = OracleDate.GetSysDate().ToString();
            //BtnModifier.Visible = false;
 

            if (ServicesABS.Instance.verifAbsence(DdlModule.SelectedValue.ToString().Trim(), id, DDClasse.SelectedValue.ToString().Trim(), Convert.ToDecimal(DdlNumSeance.SelectedValue), ts1) == true)
            {

                // Response.Write("<script>confirm('voulez vous modifier');</script>");
                //GridView2.DataSource = DAL.AbscenceDAO.Instance.ModifAbscence(Convert.ToDecimal(DdlNumSeance.SelectedValue), DDClasse.SelectedValue.ToString().Trim(), ts1, DdlModule.SelectedValue);
                //GridView2.DataBind();
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
                //GridView2.DataSource = DAL.AbscenceDAO.Instance.ModifAbscence(Convert.ToDecimal(DdlNumSeance.SelectedValue), DDClasse.SelectedValue.ToString().Trim(), ts1, DdlModule.SelectedValue);
                //GridView2.DataBind();
               
                BtnCreer.Visible = true;
                BtnModifier.Visible = false;
                GridView2.Enabled = false;
                GridView2.Visible = false;
                GridView1.Enabled = true;
                //GridView1.Visible = true;
                CheckBoxAccess.Enabled = true;
                CheckBoxAccess0.Enabled = true;
                Label3.Text = ""; 
               
              
            }
       
        }


        protected void DdlModule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        protected void DdlNumSeance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = DdlNumSeance.SelectedValue;
        }
    

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            if (DateTime.Parse(ts1).Date <= DateTime.Today.Date)
            {
                string annee_deb = ServicesABS.Instance.getANNEEDEBs();
                decimal numSeance = Convert.ToDecimal(DdlNumSeance.SelectedValue);
                ServicesABS.Instance.closeConnection();
                ServicesABS.Instance.openconntrans();

                ServicesABS.Instance.Delete_esp_ABS(DdlModule.SelectedValue.ToString(), DDClasse.SelectedValue.ToString(),annee_deb, numSeance, ts1, id, Convert.ToDecimal(RadioButtonList3.SelectedValue));
                foreach (GridViewRow gvr in GridView2.Rows)
                {
                    CheckBox Chekabs1 = (CheckBox)gvr.FindControl("ui_absent1");
                    TextBox txtobs1 = (TextBox)gvr.FindControl("txtobservation2");
                    if (Chekabs1.Checked == true)
                    {
                         annee_deb = ServicesABS.Instance.getANNEEDEBs();
                        //Label2.Text = gvr.Cells[1].Text + ts1 + "" + DdlModule.SelectedValue + "   " + numSeance + " " + id + "" + Convert.ToDecimal(RadioButtonList3.SelectedValue);
                        ServicesABS.Instance.Save_esp_ABS(gvr.Cells[1].Text, DdlModule.SelectedValue, DDClasse.SelectedValue,annee_deb, numSeance, ts1, id, id, Convert.ToDecimal(RadioButtonList3.SelectedValue), null, null, null, null, txtobs1.Text);


                    }


                }
                ServicesABS.Instance.commicttrans();

                ServicesABS.Instance.closeConnection();
                Response.Write("<script LANGUAGE='JavaScript' >alert('Modification  avec Succées')</script>");
                // Response.Redirect(Request.Url.AbsoluteUri);
                //modif15_12_14

            }
            else { Response.Write("<script LANGUAGE='JavaScript' >alert('Date seance erroné')</script>"); }      
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }





        

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(ts1).Date <= DateTime.Today.Date)
            {
            decimal numSeance = Convert.ToDecimal(DdlNumSeance.SelectedValue);

            if (!CheckBoxAccess0.Checked && !CheckBoxAccess.Checked)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Vous devez etablir type par défaut Présence/Absence ')</script>");

            }

            else if (DdlNumSeance.SelectedIndex == 0)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('vous devez choisir une séance ')</script>");

            }
            else if (TBdateseance.SelectedDate.ToString() == "")
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


                if (ServicesABS.Instance.verifAbsence(DdlModule.SelectedValue.ToString().Trim(), id, DDClasse.SelectedValue.ToString().Trim(), numSeance, ts1) == true)
                {
                    //Response.Write("<script LANGUAGE='JavaScript' >alert('Ajout est déja effectué voulez vous modifier ?')</script>");
                    BtnCreer.Visible = false;
                    BtnModifier.Visible = true;
                }

                else
                {
                         annee_deb = ServicesABS.Instance.getANNEEDEBs();
                        ServicesABS.Instance.Save_esp_entete_ABS(DdlModule.SelectedValue,annee_deb, Convert.ToDecimal(RadioButtonList3.SelectedValue), DDClasse.SelectedValue, numSeance, ts1, id, id);



                    foreach (GridViewRow gvr in GridView1.Rows)
                    {

                        CheckBox Chekabs1 = (CheckBox)gvr.FindControl("ui_absent");
                        CheckBox Chekabs2 = (CheckBox)gvr.FindControl("ui_present");

                        TextBox txtobs = (TextBox)gvr.FindControl("txtobservation");
                        string str = Regex.Replace(txtobs.Text, @"\s", "");
                        if (Chekabs1.Checked == true)
                        {
                                 annee_deb = ServicesABS.Instance.getANNEEDEBs();
                                ServicesABS.Instance.Save_esp_ABS(gvr.Cells[1].Text, DdlModule.SelectedValue, DDClasse.SelectedValue,annee_deb, numSeance, ts1, id, id, Convert.ToDecimal(RadioButtonList3.SelectedValue), null, null, null, null, txtobs.Text);


                        }


                    }
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Ajout avec Succées')</script>");
                    ServicesABS.Instance.commicttrans();

                    ServicesABS.Instance.closeConnection();
                   //modif15_12_14
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    CheckBoxAccess.Checked = false;
                    CheckBoxAccess0.Checked = false;

                    DdlNumSeance.SelectedIndex = 0;

                }

            }
            }
             else { Response.Write("<script LANGUAGE='JavaScript' >alert('Date seance erroné')</script>"); }
            

        }




        protected void Button4_Click(object sender, EventArgs e)
        {


        }




        protected void Export_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("GridView_Data");


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
                Response.AddHeader("content-disposition", "attachment;filename=liste_etudiants.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
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

        

        protected void Button6_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr1 in GridView1.Rows)
            {
                RadioButtonList Chekabs1 = (RadioButtonList)gvr1.FindControl("RadioButtonList1");
                Chekabs1.SelectedIndex = 1;

            }
        }

        protected void DDClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.Visible = true;
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.Visible = false;
        }

       
        

    }
}