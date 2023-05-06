 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using DayPilot.Utils;
using System.Security;
using System.Text;
using System.Threading;
using DayPilot.Web.Ui.Events;
using DayPilot.Web.Ui.Events.Calendar;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Resources;
using DayPilot.Web.Ui.Data;

namespace ESPOnline.EmploiEsp
{
    public partial class Plan_Etude_2015 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dtdispoEns = new DataTable();
        ServiceEDT salle = new ServiceEDT();
        List<DateTime> dtholidays = null;
        DateTime dtNow;
        public DataTable table;
        private DateTime stweek;
        private DateTime endweek;

        DateTime date;

        string x;
        string y;
        string z;

        string id_ens;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null || Session["PWD_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            DateTime d;
            d = DateTime.Today;
            int JourDsSemaine = (int)d.DayOfWeek;
            d = d.AddDays((-1) * JourDsSemaine + 1);
            lbldatedebut.Text = d.ToString("dd/MM/yyyy");


            lbldatefin.Text = d.AddDays(5).ToString("dd/MM/yyyy");
            Calendar1.Visible = false;
            lblchoixsemaine.Visible = false;   

            lblanneedeb.Text = salle.getANNEEDEB();
            lblsemestre.Text = salle.getNUMSemestre();
            lblanneefin.Text = salle.getAnneeFiN();
            dtholidays = GetPublicHolidays();
            DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(DateTime.Today);
            if (!IsPostBack)
            {
                DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek();
                DayPilotCalendar2.StartDate = DayPilot.Utils.Week.FirstDayOfWeek();

                // select full week in the Calendar control
                for (int i = 0; i < 8; i++)
                {
                    DateTime selected = DayPilotCalendar1.StartDate.AddDays(i);
                    DateTime selectedS = DayPilotCalendar2.StartDate.AddDays(i);
                    //Calendar1.SelectedDates.Add(selected);
                }

                BindClasse();
                DayPilotCalendar1.Visible = false;
                DayPilotCalendar2.Visible = false;
                Panel2.Visible = false;
                BindClas();

                BindModule();
                BindSalle();
                BindEnseignants();
                BindClasse();
                bindNUMS1();
                bindNUMS2();

            }
        }

        private DateTime GetFirstDayOfWeekNb(int weekNb)
        {
            DateTime date = new DateTime(DateTime.Now.Year, 1, 1);
            date = date.AddDays(7 * weekNb);
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    date = date.AddDays(1);
                    break;
                //Fait la même chose avec les autres jours de la semaine                 
                default:
                    break;
            }
            return date;

        }

        public void bindNUMS1()
        {
            DdlNumSeance1.DataTextField = "LIB_NOME";
            DdlNumSeance1.DataValueField = "CODE_NOME";
            DdlNumSeance1.DataSource = salle.BindNumSeanceBYNnmclature();
            DdlNumSeance1.DataBind();
        }

        public void bindNUMS2()
        {
            DdlNumSeance2.DataTextField = "LIB_NOME";
            DdlNumSeance2.DataValueField = "CODE_NOME";
            DdlNumSeance2.DataSource = salle.BindNumSeanceBYNnmclature();
            DdlNumSeance2.DataBind();

        }


        public void BindEnseignants()
        {
            //ddlnomenseig.DataTextField = "NOM_ENS";
            //ddlnomenseig.DataValueField = "ID_ENS";
            //ddlnomenseig.DataSource = salle.getEns();
            //ddlnomenseig.DataBind();
        }
        public void BindSalle()
        {
            ddlSalle.DataTextField = "SALLE_PRINCIPALE";
            ddlSalle.DataValueField = "SALLE_PRINCIPALE";
            ddlSalle.DataSource = salle.getAllClass();
            ddlSalle.DataBind();

        }

        public void BindModule()
        {

            //ddlmodule.DataTextField = "DESIGNATION";
            //ddlmodule.DataValueField = "CODE_MODULE";
            //ddlmodule.DataSource = salle.getAllModule();
            //ddlmodule.DataBind();

        }
        public void BindClas()
        {
            //Dropcodecl.DataTextField = "CODE_CL";
            //Dropcodecl.DataValueField = "CODE_CL";
            //Dropcodecl.DataSource = salle.BindClasspe();
            //Dropcodecl.DataBind();
        }
        public void BindClasse()
        {
            ddlcodclasse.DataTextField = "CODE_CL";
            ddlcodclasse.DataValueField = "CODE_CL";
            ddlcodclasse.DataSource = salle.BindClasspe();
            ddlcodclasse.DataBind();
        }
       
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //string s = System.Drawing.Color.Salmon.ToString();
        }

        //****************************************Event where i selected the code cl********************************************//
        protected void DdlPromotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
            if (ddlcodclasse.SelectedValue != null)
            {
                lblcodecl.Text = ddlcodclasse.SelectedValue;
                Label5.Text = "Plan d'Etude pour la classe :";
                Gridemp.DataSource = salle.PlanEtuDE(ddlcodclasse.SelectedValue);
                Gridemp.DataBind();

            }
        }
        //get color in a row selected
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //System.System.Drawing.Color.Aquamarine
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='Aquamarine';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Cliquer sur le mot select";
            }
        }

        //generation d'un emploi de temps et tester
        protected void btnaddEMP_Click(object sender, EventArgs e)
        {
            dt.TableName = "ESP_AFFECTATION_EMPLOI";
            dt = salle.getEnsIndisponible(Dropcodecl.Text, TextBox1.Text, TextBox2.Text, Convert.ToDateTime(txtdebutDates.Text), Convert.ToInt32(DdlNumSeance1.SelectedValue), Convert.ToInt32(DdlNumSeance2.SelectedValue), ddlSalle.SelectedValue);
            
            //verifier disponibilite des enseignnat d'apres si lamjed bettaieb
            //dtdispoEns = salle.getEnsinDispoparlmjed(TextBox1.Text, Convert.ToDateTime(txtdebutDates.Text), Convert.ToInt32(DdlNumSeance1.SelectedValue), Convert.ToInt32(DdlNumSeance2.SelectedValue));

            try
            {
                if (dt.Rows.Count == 0)
                   
                {


                    salle.Enre_Affect_emploi(lblanneedeb.Text, Dropcodecl.Text, TextBox2.Text, TextBox1.Text, ddlSalle.SelectedValue, Convert.ToDateTime(txtdebutDates.Text), int.Parse(DdlNumSeance1.SelectedValue), int.Parse(DdlNumSeance2.SelectedValue));
                    //  Response.Write(@"<script language='javascript'>alert(' Enseignant Enregistré avec succès');</script>");
                    // MessageBox1.ShowSuccess("Success, page processed.", 5000);
                    MessageBox1.ShowSuccess("Ajout avec succèes.", 8000);


                    refresh();
                    refreshgrid();
                    ddlnomenseig.Text = "";
                    Dropcodecl.Text = "";
                    ddlmodule.Text = "";
                    txtbnheures.Text = "";
                    txtdebutDate.Text = "";

                    ddlSalle.Items.Clear();
                    ddlSalle.DataTextField = "SALLE_PRINCIPALE";
                    ddlSalle.DataValueField = "SALLE_PRINCIPALE";
                    ddlSalle.DataSource = salle.getAllClass();
                    ddlSalle.DataBind();
                    //ddlSalle.Items.Insert(0, new ListItem("Veuillez choisir la salle", "0")); 

                }
                else
                {
                    // Response.Write(@"<script language='javascript'>alert('Conflit de planification!!!');</script>");
                    MessageBox2.ShowError("Conflit de planification!!!.", 10000);

                    refresh();
                    refreshgrid();

                }
            }
            catch (Exception)
            {
                Response.Write(@"<script language='javascript'>alert('Erreur de serveur');</script>");
            }
        }

        //get seance 1
        protected void DdlNumSeance1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Label1.Text = DdlNumSeance1.SelectedValue;
        }
        //get seance 2
        protected void DdlNumSeance2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numseance1 = Convert.ToInt32(DdlNumSeance1.SelectedValue);
            int numseance2 = Convert.ToInt32(DdlNumSeance2.SelectedValue);
            if (numseance1 < numseance2 && (numseance1 != null || numseance2 != null))
            {
               // Label2.Text = DdlNumSeance2.SelectedValue;
            }
            else
            {
                MessageBox1.ShowWarning("VERIFIER La SEANCE ENTREE!!!", 10000);
            }
            refresh();
            refreshgrid();


        }
        protected void ddlmodule_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtbnheures.Text = salle.GetnbHr(Dropcodecl.SelectedValue, ddlmodule.SelectedValue);

        }

        protected void ddlnomenseig_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        public void refreshgrid()
        {
            Gridemp.DataSource = salle.PlanEtuDE(ddlcodclasse.SelectedValue);
            Gridemp.DataBind();

        }


        public void refresh()
        {
            DayPilotCalendar1.DataSource = getDataCalendarbycodecl(Dropcodecl.Text);
            DataBind();

            DayPilotCalendar2.DataSource = getDataCalendarbyidens(TextBox1.Text);
            DayPilotCalendar2.DataBind();
        }



        protected void ddlcodclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
            if (Dropcodecl.Text != null)
            {
                //  ddlSalle.SelectedValue = salle.getsalleBycode(Dropcodecl.SelectedValue);
                lblempcl.Text = "EMPLOI DU TEMPS PAR CLASSE";
                lblcodeclasss.Text = Dropcodecl.Text;
                lblcodeclasss.ForeColor = System.Drawing.Color.GreenYellow;
                // Gridemp.DataSource = salle.PlanEtuDE(Dropcodecl.SelectedValue);
                Gridemp.DataBind();
                lblcodecl.Text = ddlcodclasse.SelectedValue;
                Label5.Text = "Plan d'Etude pour la classe :";


                //  ddlmodule.DataSource = salle.BindMODULEByEns(ddlnomenseig.SelectedValue, Dropcodecl.SelectedValue);
                ddlmodule.DataBind();
                // ddlmodule.Items.Insert(0, new ListItem("--Choisir Module--", "0"));

                // DayPilotCalendar1.DataSource = getDataCalendarbycodecl(Dropcodecl.SelectedValue);
                DayPilotCalendar1.DataBind();
                // lblcodecl.Text = ddlcodclasse.SelectedValue;
                DayPilotCalendar1.Visible = true;
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        
        {    
            txtdebutDate_PopupControlExtender1.Commit(Calendar2.SelectedDate.ToShortDateString());

        }

        protected void GrdEmpData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


        }

        private DataTable GetEventsbyidENS(string id_ens)
        {
            DataTable dt = new DataTable();

            dt.TableName = "ESP_AFFECTATION_EMPLOI";
            dt = salle.BindDataEventsByID_ENS(id_ens);
            return dt;
        }

        private DataTable GetEventsbycode_cl(string code_cl)
        {
            DataTable dt = new DataTable();

            dt.TableName = "ESP_AFFECTATION_EMPLOI";
            dt = salle.GetDataEventsByCode_cl(code_cl);
            return dt;
        }

        protected DataTable getDataCalendarbycodecl(string code_cl)
        {
            DataTable dt = new DataTable();
            dt = GetEventsbycode_cl(code_cl);
            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));

            foreach (DataRow DRow in dt.Rows)
            {
                //int year = (Convert.ToDateTime(DRow["JOURS"])).Year;
                //int month = (Convert.ToDateTime(DRow["JOURS"])).Month;
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;

                Dictionary<string, string> dictionary =
                    new Dictionary<string, string>();
                dictionary.Add("1", "9,00");
                dictionary.Add("2", "10,45");
                dictionary.Add("3", "14,00");
                dictionary.Add("4", "15,45");

                Dictionary<string, string> dictionary2 =
                  new Dictionary<string, string>();
                dictionary2.Add("1", "10,30");
                dictionary2.Add("2", "12,15");
                dictionary2.Add("3", "15,30");
                dictionary2.Add("4", "17,15");

                //int day = int.Parse(DRow["JOURS"].ToString());
                int day = (Convert.ToDateTime(DRow["JOURS"])).Day;
                string seance = dictionary[DRow["CREN_1"].ToString()];
                string seance2 = dictionary2[DRow["CREN_2"].ToString()];
                string[] heures = seance.Split(',');

                string[] heures2 = seance2.Split(',');
                //string[] heuretotal =  string.Concat(heures,heures2);
                List<string> list = new List<string>();
                list.AddRange(heures);
                list.AddRange(heures2);
                string[] z = list.ToArray();
                int heure_deb = int.Parse(z[0]);
                int min_deb = int.Parse(z[1]);
                int heure_fin = int.Parse(z[2]);
                int min_fin = int.Parse(z[3]);


                DateTime dte = new DateTime(year, month, day, heure_deb, min_deb, 0);
                DateTime dts = new DateTime(year, month, day, heure_fin, min_fin, 0);

                DRow["start"] = dte;
                DRow["end"] = dts;
                DRow["DESIGNATION"] = "<CENTER>" + DRow["DESIGNATION"] + "<BR />" + DRow["NOM_ENS"] + "<BR />" + DRow["CODE_CL"] + "<BR />" + DRow["SALLE_PRINCIPALE"] + "<CENTER>";
                //DRow["DESIGNATION"] = DRow["DESIGNATION"] + "                                                      " + DRow["NOM_ENS"] + "                                                          " + DRow["CODE_CL"] + "                                                                  " + DRow["SALLE_PRINCIPALE"]  ;

            }
            return dt;
        }

        protected DataTable getDataCalendarbyidens(string id_ens)
        {
            DataTable dt = new DataTable();
            dt = GetEventsbyidENS(id_ens);

            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));
            foreach (DataRow DRow in dt.Rows)
            {
                //int year = (Convert.ToDateTime(DRow["JOURS"])).Year;
                //int month = (Convert.ToDateTime(DRow["JOURS"])).Month;
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;

                Dictionary<string, string> dictionary =
                    new Dictionary<string, string>();
                dictionary.Add("1", "9,00");
                dictionary.Add("2", "10,45");
                dictionary.Add("3", "14,00");
                dictionary.Add("4", "15,45");

                Dictionary<string, string> dictionary2 =
                  new Dictionary<string, string>();
                dictionary2.Add("1", "10,30");
                dictionary2.Add("2", "12,15");
                dictionary2.Add("3", "15,30");
                dictionary2.Add("4", "17,15");

                //int day = int.Parse(DRow["JOURS"].ToString());
                int day = (Convert.ToDateTime(DRow["JOURS"])).Day;
                string seance = dictionary[DRow["CREN_1"].ToString()];
                string seance2 = dictionary2[DRow["CREN_2"].ToString()];
                string[] heures = seance.Split(',');

                string[] heures2 = seance2.Split(',');
                //string[] heuretotal =  string.Concat(heures,heures2);
                List<string> list = new List<string>();
                list.AddRange(heures);
                list.AddRange(heures2);
                string[] z = list.ToArray();
                int heure_deb = int.Parse(z[0]);
                int min_deb = int.Parse(z[1]);
                int heure_fin = int.Parse(z[2]);
                int min_fin = int.Parse(z[3]);


                DateTime dte = new DateTime(year, month, day, heure_deb, min_deb, 0);
                DateTime dts = new DateTime(year, month, day, heure_fin, min_fin, 0);

                DRow["start"] = dte;
                DRow["end"] = dts;
                DRow["DESIGNATION"] = "<CENTER>" + DRow["DESIGNATION"] + "<BR />" + DRow["NOM_ENS"] + "<BR />" + DRow["CODE_CL"] + "<BR />" + DRow["SALLE_PRINCIPALE"] + "<CENTER>";
                //DRow["DESIGNATION"] = DRow["DESIGNATION"] + "                                                      " + DRow["NOM_ENS"] + "                                                          " + DRow["CODE_CL"] + "                                                                  " + DRow["SALLE_PRINCIPALE"]  ;

            }
            return dt;
        }
/*
            foreach (DataRow DRow in dt.Rows)
            {
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;

                Dictionary<string, string> dictionary =
                    new Dictionary<string, string>();
                dictionary.Add("1", "9,00");
                dictionary.Add("2", "12,30");
                dictionary.Add("3", "14,00");
                dictionary.Add("4", "17,30");

                // int day = int.Parse(DRow["JOURS"].ToString());
                int day = (Convert.ToDateTime(DRow["JOURS"])).Day;
                string seance = dictionary[DRow["CREN_1"].ToString()];
                string seance2 = dictionary[DRow["CREN_2"].ToString()];
                string[] heures = seance.Split(',');
                string[] heures2 = seance2.Split(',');
                //string[] heuretotal =  string.Concat(heures,heures2);
                List<string> list = new List<string>();
                list.AddRange(heures);
                list.AddRange(heures2);
                string[] z = list.ToArray();
                int heure_deb = int.Parse(z[0]);
                int min_deb = int.Parse(z[1]);
                int heure_fin = int.Parse(z[2]);
                int min_fin = int.Parse(z[3]);

                DateTime dte = new DateTime(year, month, day, heure_deb, min_deb, 0);
                DateTime dts = new DateTime(year, month, day, heure_fin, min_fin, 0);

                DRow["start"] = dte;
                DRow["end"] = dts;
                DRow["DESIGNATION"] = "<CENTER>" + DRow["DESIGNATION"] + "<BR />" + DRow["NOM_ENS"] + "<BR />" + DRow["CODE_CL"] + "<BR />" + DRow["SALLE_PRINCIPALE"] + "<CENTER>";
            }
            return dt;
        }
        */

        private static DateTime firstDayOfWeek(DateTime day, DayOfWeek weekStarts)
        {
            DateTime d = day;
            while (d.DayOfWeek != weekStarts)
            {
                d = d.AddDays(-1);
            }

            return d;
        }

        private void calculateDays()
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;
            int days = day - DayOfWeek.Sunday;
            this.stweek = DateTime.Now.AddDays(-days);
            this.endweek = this.stweek.AddDays(6);

        }
        protected void calDT_DayRender(object sender, DayRenderEventArgs e)
        {

            if (dtholidays.Contains(e.Day.Date))
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ForeColor = System.Drawing.Color.White;

            }
        }


        private List<DateTime> GetPublicHolidays()
        {
            List<DateTime> list = new List<DateTime>();
            //populate from database or other sources
            list.Add(new DateTime(2015, 01, 01));
            list.Add(new DateTime(2015, 04, 09));
            list.Add(new DateTime(2015, 01, 14));
            list.Add(new DateTime(2015, 05, 01));
            list.Add(new DateTime(2015, 06, 25));
            list.Add(new DateTime(2015, 08, 13));
            return list;
        }

        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
            lblchoixsemaine.Visible = true;
            //    DateTime dt;
            //  dt=  DateTime.Now.AddDays(1);
            GridViewRow row = Gridemp.SelectedRow;
            //ddlnomenseig.Text = row.Cells[3].Text;
            //ddlcodclasse.Text = row.Cells[5].Text;
            TextBox1.Text = (row.FindControl("lblIDabonne") as Label).Text;
            TextBox2.Text = (row.FindControl("lbcodemodule") as Label).Text;
            ddlnomenseig.Text = (row.FindControl("lblnomEns") as Label).Text;
            Dropcodecl.Text = (row.FindControl("lblclasse") as Label).Text;
            ddlmodule.Text = (row.FindControl("lbldesign") as Label).Text;
            txtbnheures.Text = (row.FindControl("lblnumheures") as Label).Text;
            ddlSalle.SelectedValue = salle.getsalleBycode(Dropcodecl.Text);

            lblaffect.Text = "AFFECTATION EMPLOI DU TEMPS";
            Panel2.Visible = true;


            //Label labelidens = row.FindControl("lblIDabonne") as Label;

            lblenseign.Text = "AFFECTATION ACTUELLE DE L'EMPLOI DU TEMPS (CHARGE ENSEIGNANT) : ";
            lblNomEEnsss.Text = salle.getNameteacher(TextBox1.Text);
            lblNomEEnsss.ForeColor = System.Drawing.Color.OrangeRed;

            DayPilotCalendar2.DataSource = getDataCalendarbyidens(TextBox1.Text);
            DayPilotCalendar2.DataBind();
            DayPilotCalendar2.Visible = true;

            lblempcl.Text = "EMPLOI DU TEMPS PAR CLASSE";
            lblcodeclasss.Text = Dropcodecl.Text;
            lblcodeclasss.ForeColor = System.Drawing.Color.GreenYellow;
            DayPilotCalendar1.DataSource = getDataCalendarbycodecl(Dropcodecl.Text);
            DayPilotCalendar1.DataBind();
            DayPilotCalendar1.Visible = true;
        }

        protected void ddljours_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
            refreshgrid();
        }


        #region DeleteEvents
        //protected void DayPilotCalendar1_EventDelete(object sender, EventDeleteEventArgs e)
        //{
        //    //id_ens = salle.getIDenseignant(ddlnomenseig.Text);
        //    ////deleteAndBind(e.Value);

        //    //salle.Deleteenseign(id_ens);

        //    //DayPilotCalendar1.UpdateWithMessage("Enseignant a été supprimé");
        //    //DayPilotCalendar2.UpdateWithMessage("Enseignant a été supprimé");

        //    //refresh();
        //    //refreshgrid();

        //}

        protected void DayPilotCalendar2_EventDelete(object sender, EventDeleteEventArgs e)
        {
            // id_ens = salle.getIDenseignant(ddlnomenseig.Text);
            // //deleteAndBind(e.Value);

            //// salle.Deleteenseign(id_ens,lblcodeclasss.Text);

            // DayPilotCalendar1.UpdateWithMessage("Enseignant a été supprimé");
            // DayPilotCalendar1.DataSource = getDataCalendarbycodecl(Dropcodecl.Text);
            // DataBind();
            // DayPilotCalendar2.DataSource = getDataCalendarbyidens(TextBox1.Text);
            // DayPilotCalendar2.DataBind();

            // DayPilotCalendar2.UpdateWithMessage("Enseignant a été supprimé");

            // DayPilotCalendar2.DataSource = getDataCalendarbyidens(TextBox1.Text);
            // DayPilotCalendar2.DataBind();
            // DayPilotCalendar1.DataSource = getDataCalendarbycodecl(Dropcodecl.Text);
            // DataBind();

            //refreshgrid();

        }

        #endregion

        protected void DayPilotMonth1_EventMove(object sender, EventMoveEventArgs e)
        {
            #region Simulation of database update
            DataTable table = new DataTable();
            table = GetEventsbyidENS(id_ens);

            DataRow dr = table.Rows.Find(e.Value);
            if (dr != null)
            {
                dr["start"] = e.NewStart;
                dr["end"] = e.NewEnd;
                //dr["column"] = e.NewResource;
                table.AcceptChanges();
            }
            else // moved from outside
            {
                dr = table.NewRow();
                dr["start"] = e.NewStart;
                dr["end"] = e.NewEnd;
                dr["id"] = e.Value;
                dr["name"] = e.Text;
                //dr["column"] = e.NewResource;

                table.Rows.Add(dr);
                table.AcceptChanges();
            }

            #endregion

            DayPilotCalendar2.DataSource = getDataCalendarbyidens(TextBox1.Text);
            DayPilotCalendar2.DataBind();
            DayPilotCalendar2.UpdateWithMessage("la séance a été déplacé avec succées: " + e.Position);
        }

        #region EventMenuClick
        //protected void DayPilotCalendar1_EventMenuClick(object sender, DayPilot.Web.Ui.Events.EventMenuClickEventArgs e)
        //{
        //    if (e.Command == "Delete")
        //    {

        //    //    DayPilotCalendar1.DataStartField = "start";
        //    //DayPilotCalendar1.DataEndField = "end";
        //    //DayPilotCalendar1.DataIdField = "DESIGNATION";
        //    //DayPilotCalendar1.DataTextField = "DESIGNATION";
        //    //id_ens = e.Value;

        //    //salle.Deleteenseign(id_ens);

        //    //    //DayPilotCalendar1.DataBind();
        //    //    //DayPilotCalendar1.Update();
        //    //    //DayPilotCalendar2.DataBind();
        //    //    //DayPilotCalendar2.Update();
        //    //    refresh();

        //    //    refreshgrid();
        //    }
        //    else
        //    {

        //        if (e.Command == "edit")
        //        {
        //            ///
        //        }
        //    }
        //} 
        #endregion

        protected void DayPilotCalendar1_EventMove(object sender, EventMoveEventArgs e)

        {

           //#region Simulation of database update
             DataTable dt = new DataTable();
            dt = GetEventsbyidENS(id_ens);

            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));

            DataRow dr = dt.Rows.Find(e.Value) ;
            if (dr != null)
            {
                dr["start"] = e.NewStart;
                dr["end"] = e.NewEnd;
                table.AcceptChanges();
            }
            //#endregion

            DayPilotCalendar1.DataBind();
            DayPilotCalendar1.UpdateWithMessage("Event moved.");
            DayPilotCalendar1.Update();

        }

        protected void DayPilotCalendar1_BeforeCellRender(object sender, BeforeCellRenderEventArgs e)
        {
            
            //if (e.Start.Hour >= 14 && e.Start.Hour < 20 )
               
            //    e.BackgroundColor = "#fdbdbd"; // shift #2
        }

        protected void DayPilotCalendar1_EventDelete(object sender, EventDeleteEventArgs e)
        {
            DataRow dr = table.Rows.Find(e.Value);
            if (dr != null)
            {
                table.Rows.Remove(dr);
                table.AcceptChanges();
            }

            DayPilotCalendar1.DataBind();
            DayPilotCalendar1.UpdateWithMessage("Event deleted.");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            setWeek();
        }

        private void setWeek()
        {
            DateTime firstDay = firstDayOfWeek(Calendar1.SelectedDate, DayOfWeek.Monday);
            Calendar1.VisibleDate = firstDay;
            for (int i = 0; i < 7; i++)
                Calendar1.SelectedDates.Add(firstDay.AddDays(i));
            


            DayPilotCalendar1.StartDate = firstDay;
            DayPilotCalendar2.StartDate = firstDay;


        }
        
    }
}
