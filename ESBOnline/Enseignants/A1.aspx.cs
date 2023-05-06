using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESPSuiviEncadrement;
using Oracle.DataAccess.Types;
using Telerik.Web.UI;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ESPOnline.Enseignants
{
    public partial class A1 : System.Web.UI.Page
    {

        //  public OracleConnection con;
        OracleTransaction myTrans;
        // public   DateTime date_encp;
        public string date_encp;
        public DateTime time_end;
        public DateTime time_start;
        public string ang;
        public string fran;
        public string cc;
        public string AV_TECH;
        public string AV_COMPORTEMENT;
        public string ID_ET;
        public string idproj;
        public string idet;
        public string TravD;
        public string Obs;
        public string ID_ENS;
        public string OBS_TECH;
        public string OBS_ANG;
        public string AV_RAP;
        public string OBS_FR;
        public string OBS_CC;
        public string OBS_RAP;
        public string rapp;
        //public OracleDate date;
        public OracleTimeStamp HEURE_DEB;
        public OracleTimeStamp time1;
        public double milii = 0;
        public string dateencp;

        public void commicttrans()
        {
            myTrans.Commit();
        }
        public void rollbucktrans()
        {
            myTrans.Rollback();
        }
        public OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            ID_ENS = Session["ID_ENS"].ToString();

            //RadGrid1.MasterTableView.EditMode = (GridEditMode)Enum.Parse(typeof(GridEditMode), "PopUp");
            //RadGrid1.Rebind();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedIndexes.Count == 0)
                RadGrid1.SelectedIndexes.Add(0);
            if (RadGrid2.SelectedIndexes.Count == 0)
                RadGrid2.SelectedIndexes.Add(0);


        }

        protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            //RadGrid1.Select("EmployeeID = " + editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["EmployeeID"]);

            //foreach (GridDataItem item in RadGrid1.SelectedItems)
            //{
            //    idproj = item["ID_PROJET"].Text;


            //}

            idproj = ((userControl.FindControl("Label1") as Label).Text);

            //idproj = editedItem.GetDataKeyValue("ID_PROJET").ToString(); 
            string meth = ((userControl.FindControl("DDlistMethod") as DropDownList).SelectedItem.Value);
            string desc = ((userControl.FindControl("TextBox1") as TextBox).Text);
            string modul = ((userControl.FindControl("DropDownList5") as DropDownList).SelectedItem.Value);
            string tech = ((userControl.FindControl("DDlistTech") as DropDownList).SelectedItem.Value);
            string type = ((userControl.FindControl("Droptypeproj") as DropDownList).SelectedItem.Value);
            string title = ((userControl.FindControl("TextBox2") as TextBox).Text);
            OracleDate date = OracleDate.GetSysDate();
            decimal mois = Convert.ToDecimal((userControl.FindControl("Dropmois") as DropDownList).SelectedItem.Value);

            ESP_PROJET.Instance.openconntrans();
            Label lblError1 = new Label();

            lblError1.Text = "Modification avec succée";
            lblError1.ForeColor = System.Drawing.Color.Green;
            RadGrid1.Controls.Add(lblError1);
            ESP_PROJET.Instance.update_esp_suivi_projet1("2015", idproj, title, modul, type, desc, tech, meth, mois, 4, 5, ID_ENS);


            ESP_PROJET.Instance.closeConnection();



        }
        protected void RadGrid2_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            foreach (GridDataItem item in RadGrid3.SelectedItems)
            {
                idproj = item["ID_PROJET"].Text;
                idet = item["ID_ET"].Text;

            }



            //idproj = editedItem.GetDataKeyValue("ID_PROJET").ToString(); 
            date_encp = ((userControl.FindControl("BirthDatePicker") as RadDatePicker).SelectedDate.ToString());
            TravD = ((userControl.FindControl("TextBox2") as TextBox).Text);
            Obs = ((userControl.FindControl("TextBox1") as TextBox).Text);
            OBS_TECH = ((userControl.FindControl("RadTextBox4") as RadTextBox).Text);
            OBS_ANG = ((userControl.FindControl("RadTextBox2") as RadTextBox).Text);
            AV_TECH = ((userControl.FindControl("RadNumericTextBox1") as RadNumericTextBox).Text);
            rapp = ((userControl.FindControl("txtrapp") as RadNumericTextBox).Text);
            time_end = ((userControl.FindControl("RadTimePicker1") as RadTimePicker).SelectedDate.Value);
            time_start = ((userControl.FindControl("RadDateTimePicker1") as RadDateTimePicker).SelectedDate.Value);
            time1 = OracleTimeStamp.GetSysDate();
            OracleDate date = OracleDate.GetSysDate();
            ang = ((userControl.FindControl("RadioButtonList1") as RadioButtonList).SelectedItem.Value);
            // HEURE_DEB = new OracleTimeStamp(time1.Year, time1.Month, time1.Day, int.Parse(time_end.Substring(0, 2)), int.Parse(time_end.Substring(3, 2)), 1, milii);
            time_end = ((userControl.FindControl("RadTimePicker1") as RadTimePicker).SelectedDate.Value);
            time_start = ((userControl.FindControl("RadDateTimePicker1") as RadDateTimePicker).SelectedDate.Value);
            fran = ((userControl.FindControl("RadioButtonList2") as RadioButtonList).SelectedItem.Value);
            cc = ((userControl.FindControl("RadioButtonList3") as RadioButtonList).SelectedItem.Value);
            dateencp = ((userControl.FindControl("Label3") as Label).Text);

            OBS_RAP = ((userControl.FindControl("RadTextBox5") as RadTextBox).Text);
            OBS_CC = ((userControl.FindControl("RadTextBox3") as RadTextBox).Text);
            OBS_FR = ((userControl.FindControl("RadTextBox1") as RadTextBox).Text);

            con.Open();
            //string idens = Session["ID_ENS"].ToString().Trim();
            //to_date((SUBSTR('" + HEURE_DEB + "',1,6)||''||SUBSTR('" + HEURE_DEB + "',9,2)),'dd/MM/yy hh24:mi:ss')
            OracleCommand cmd = new OracleCommand(" UPDATE ESP_ENCADREMENT SET AV_ANG='" + ang + "',HEURE_DEB=to_date((SUBSTR('" + time_start + "',1,6)||''||SUBSTR('" + time_start + "',9,2)||' '||Substr('" + time_start + "' ,12,2)||':'||Substr('" + time_start + "' ,15,2)||':'||Substr('" + time_start + "' ,18,2)),'dd/MM/yy hh:mi:ss'),HEURE_FIN=to_date((SUBSTR('" + time_start + "',1,6)||''||SUBSTR('" + time_start + "',9,2)||' '||Substr('" + time_end + "' ,12,2)||':'||Substr('" + time_end + "' ,15,2)||':'||Substr('" + time_end + "' ,18,2)),'dd/MM/yy hh:mi:ss') ,REMARQUE_OBS='" + Obs + "',TRAVAUX_DEMANDE='" + TravD + "',AV_FR='" + fran + "',   AV_CC='" + cc + "',AV_RAPPORT='" + rapp + "',AV_TECH='" + AV_TECH + "',OBS_RAPPORT='" + OBS_RAP + "',OBS_TECH='" + OBS_TECH + "',OBS_ANGLAIS='" + OBS_ANG + "',OBS_CC='" + OBS_CC + "',OBS_FRANCAIS='" + OBS_FR + "', DATE_ENC =to_date((SUBSTR('" + date_encp + "',1,6)||''||SUBSTR('" + date_encp + "',9,2)),'dd/MM/yy') where id_projet='" + idproj + "' and id_et= '" + idet + "' and date_enc=to_date((SUBSTR('" + dateencp + "',1,6)||''||SUBSTR('" + dateencp + "',9,2)),'dd/MM/yy')   ");


            cmd.Connection = con;

            cmd.Transaction = myTrans;
            try
            {
                cmd.ExecuteNonQuery();
                //myTrans.Commit();
                Label lblError2 = new Label();
                lblError2.Text = "Modification avec succée";
                lblError2.ForeColor = System.Drawing.Color.Green;
                RadGrid2.Controls.Add(lblError2);
            }
            catch (Exception ex)
            {
                Label lblError1 = new Label();

                lblError1.Text = "ERROR";
                RadGrid2.Controls.Add(lblError1);
            }






        }
        protected void RadGrid1_PreRender(object sender, System.EventArgs e)
        {
        }


        public DataTable GetDataTable(string t, string p)
        {






            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("  select t2.*,  (SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80') and  code_nome=AV_FR)as AV_FR,(SELECT CODE_NOME FROM CODE_NOMENCLATURE  WHERE ( CODE_STR  = '80') and  code_nome=AV_ANG)as AV_ANG from esp_encadrement t2 where id_et='" + t + "'and id_projet ='" + p + "'", con);
            DataTable myDataTable = new DataTable();

            //con.Open();
            try
            {
                adapter.Fill(myDataTable);
            }
            finally
            {
                con.Close();
            }

            return myDataTable;
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            foreach (GridDataItem item in RadGrid3.SelectedItems)
            {
                idproj = item["ID_PROJET"].Text;
                idet = item["ID_ET"].Text;

            }
            (sender as RadGrid).DataSource = GetDataTable(idet, idproj);

        }
        


        public decimal inc_id_projet()
        {
            decimal NB = 0;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

              



                string cmdQuery = "SELECT COUNT(*) AS NB FROM ESP_PROJET_N";

                Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = con;
                myCommand.CommandType = CommandType.Text;
                myCommand.Transaction = myTrans;
                NB = (decimal)myCommand.ExecuteScalar();
                mySqlConnection.Close();
            }
            return NB;
        } 
        protected void test(object sender, EventArgs e)
        {
            foreach (GridDataItem item in RadGrid3.SelectedItems)
            {
                idproj = item["ID_PROJET"].Text;
                idet = item["ID_ET"].Text;

            }
            Label4.Visible = true;
            RadGrid2.Visible = true;
            RadGrid2.DataSource = GetDataTable(idet, idproj);
            RadGrid2.DataBind();

        }
       

       
        protected void RadGrid2_InsertCommand(object source, GridCommandEventArgs e)
        {
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            //ID_ET = ((userControl.FindControl("DropDownList1") as RadComboBox).SelectedItem.Value);
            string meth = ((userControl.FindControl("DDlistMethod") as DropDownList).SelectedItem.Value);
            string desc = ((userControl.FindControl("TextBox1") as TextBox).Text);
            string modul = ((userControl.FindControl("DropDownList5") as DropDownList).SelectedItem.Value);
            string tech = ((userControl.FindControl("DDlistTech") as DropDownList).SelectedItem.Value);
            string type = ((userControl.FindControl("Droptypeproj") as DropDownList).SelectedItem.Value);
            string title = ((userControl.FindControl("TextBox2") as TextBox).Text);
            OracleDate date = OracleDate.GetSysDate();
            decimal mois = Convert.ToDecimal((userControl.FindControl("Dropmois") as DropDownList).SelectedItem.Value);

          
          
            con.Open();
            decimal x = inc_id_projet() + 1;
            String _ID_PROJET = "PROJ" + x;
            OracleCommand cmd = new OracleCommand(" Insert into ESP_PROJET_N( ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, DUREE, SEMESTRE, PERIODE,ID_ENS) VALUES ('2015', '" + _ID_PROJET + "','" + title + "', '" + modul + "','" + type + "', '" + desc + "', '" + tech + "', '" + meth + "',  '" + mois + "', 4, 5, '" + ID_ENS + "')");


            cmd.Connection = con;

            cmd.Transaction = myTrans;
            try
            {
                cmd.ExecuteNonQuery();
                Label lblError1 = new Label();

                lblError1.Text = "Ajout avec succée";
                lblError1.ForeColor = System.Drawing.Color.Green;
                RadGrid1.Controls.Add(lblError1);
                //myTrans.Commit();
            }
            catch (Exception ex)
            {
                Label lblError1 = new Label();


                lblError1.Text = "ERREUR";
                RadGrid1.Controls.Add(lblError1);
            }


        }
        protected void RadGrid3_InsertCommand(object source, GridCommandEventArgs e)
        {
            foreach (GridDataItem item in RadGrid1.SelectedItems)
            {
                idproj = item["ID_PROJET"].Text;


            }

            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            ID_ET = ((userControl.FindControl("DropDownList1") as RadComboBox).SelectedItem.Value);
            OracleDate date = OracleDate.GetSysDate();

            // HEURE_DEB = new OracleTimeStamp(time1.Year, time1.Month, time1.Day, int.Parse(time_end.Substring(0, 2)), int.Parse(time_end.Substring(3, 2)), 1, milii);





            con.Open();
            //string idens = Session["ID_ENS"].ToString().Trim();
            //to_date((SUBSTR('" + HEURE_DEB + "',1,6)||''||SUBSTR('" + HEURE_DEB + "',9,2)),'dd/MM/yy hh24:mi:ss')
            OracleCommand cmd = new OracleCommand(" Insert into ESP_PROJET_ETUDIANT (ID_PROJET,ID_ET) values  ('" + idproj + "','" + ID_ET + "')");


            cmd.Connection = con;

            cmd.Transaction = myTrans;
            try
            {
                cmd.ExecuteNonQuery();
                //myTrans.Commit();
                Label lblError2 = new Label();
                lblError2.Text = "Ajout avec succée";
                lblError2.ForeColor = System.Drawing.Color.Green;
                RadGrid3.Controls.Add(lblError2);
            }
            catch (Exception ex)
            {
                Label lblError1 = new Label();
                if (ex.Message == "ORA-00001: violation de contrainte unique (scoesb02.KEY_PROJ_ET)")
                {
                    lblError1.Text = "Etudiant existe dejà!!";
                }
                else { lblError1.Text = ex.Message; }
                RadGrid3.Controls.Add(lblError1);
            }




        }
        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {
            foreach (GridDataItem item in RadGrid3.SelectedItems)
            {
                idproj = item["ID_PROJET"].Text;
                idet = item["ID_ET"].Text;

            }

            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            // DateTime date = Convert.ToDateTime(RadDatePicker1.SelectedDate);
            //   DateTime date_encp =Convert.ToDateTime((userControl.FindControl("BirthDatePicker") as RadDatePicker).SelectedDate);
            date_encp = ((userControl.FindControl("BirthDatePicker") as RadDatePicker).SelectedDate.ToString());
            DateTime gg = ((userControl.FindControl("BirthDatePicker") as RadDatePicker).SelectedDate.Value);
            TravD = ((userControl.FindControl("TextBox2") as TextBox).Text);
            Obs = ((userControl.FindControl("TextBox1") as TextBox).Text);
            OBS_TECH = ((userControl.FindControl("RadTextBox4") as RadTextBox).Text);
            OBS_ANG = ((userControl.FindControl("RadTextBox2") as RadTextBox).Text);
            AV_TECH = ((userControl.FindControl("RadNumericTextBox1") as RadNumericTextBox).Text);
            time_end = ((userControl.FindControl("RadTimePicker1") as RadTimePicker).SelectedDate.Value);
            time_start = ((userControl.FindControl("RadDateTimePicker1") as RadDateTimePicker).SelectedDate.Value);

            AV_RAP = ((userControl.FindControl("txtrapp") as RadNumericTextBox).Text);
            time1 = OracleTimeStamp.GetSysDate();
            OracleDate date = OracleDate.GetSysDate();
            DateTime ts = new DateTime(gg.Year, gg.Month, gg.Day);
            string ts1 = String.Format("{0:dd/MM/yy}", ts);
            DateTime tf = new DateTime(time_start.Year, time_start.Month, time_start.Day, time_start.Hour, time_start.Minute, time_start.Second);
            string tf1 = String.Format("{0:dd/MM/yy hh:mm:ss}", tf);
            DateTime tend = new DateTime(time_start.Year, time_start.Month, time_start.Day, time_end.Hour, time_end.Minute, time_end.Second);
            string tend1 = String.Format("{0:dd/MM/yy hh:mm:ss}", tf);

            ang = ((userControl.FindControl("RadioButtonList1") as RadioButtonList).SelectedItem.Value);
            // HEURE_DEB = new OracleTimeStamp(time1.Year, time1.Month, time1.Day, int.Parse(time_end.Substring(0, 2)), int.Parse(time_end.Substring(3, 2)), 1, milii);

            fran = ((userControl.FindControl("RadioButtonList2") as RadioButtonList).SelectedItem.Value);
            cc = ((userControl.FindControl("RadioButtonList3") as RadioButtonList).SelectedItem.Value);
            OBS_RAP = ((userControl.FindControl("RadTextBox5") as RadTextBox).Text);
            OBS_CC = ((userControl.FindControl("RadTextBox3") as RadTextBox).Text);
            OBS_FR = ((userControl.FindControl("RadTextBox1") as RadTextBox).Text);
            con.Open();
           
            OracleCommand cmd = new OracleCommand(" Insert into ESP_ENCADREMENT (ID_PROJET,ANNEE_DEB,ID_ET,ID_ENS,DATE_ENC,HEURE_DEB,HEURE_FIN,AV_TECH,AV_ANG,AV_FR,AV_RAPPORT,AV_CC,REMARQUE_OBS,TRAVAUX_DEMANDE,OBS_TECH,OBS_ANGLAIS,OBS_RAPPORT,OBS_FRANCAIS,OBS_CC) values  ('" + idproj + "','2014','" + idet + "','" + ID_ENS + "',to_date('" + ts1 + "','dd/MM/yy'),to_date('" + tf1 + "','dd/MM/yy hh24:mi:ss') ,to_date('" + tend1 + "','dd/MM/yy hh24:mi:ss'),'" + AV_TECH + "','" + ang + "','" + fran + "','" + AV_RAP + "','" + cc + "','" + Obs + "','" + TravD + "','" + OBS_TECH + "','" + OBS_ANG + "','" + OBS_RAP + "','" + OBS_FR + "','" + OBS_CC + "')");

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = myTrans;
            try
            {
                cmd.ExecuteNonQuery();


                //  myTrans.Commit();
                Label lblError2 = new Label();
                lblError2.Text = "Ajout avec succée";
                lblError2.ForeColor = System.Drawing.Color.Green;
                RadGrid2.Controls.Add(lblError2);
            }


            catch (Exception ex)
            {
                Label lblError2 = new Label();
                lblError2.Text = "ERREUR";

                lblError2.ForeColor = System.Drawing.Color.Red;
                RadGrid2.Controls.Add(lblError2);
                con.Close();

            }





        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  RadGrid1.MasterTableView.EditMode = (GridEditMode)Enum.Parse(typeof(GridEditMode), RadioButtonList1.SelectedValue);
            RadGrid1.Rebind();
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAjouter();", true);
        }
        protected string RadGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            return (RadGrid1.SelectedItems[0] as GridDataItem).GetDataKeyValue("ID_PROJET").ToString();

        }
    }
}