using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Drawing;
using System.Data;

namespace ESPOnline.EmploiEsp
{
    public partial class Plan_Etude : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        ServiceEDT salle = new ServiceEDT();
        List<DateTime> dtholidays = null;

        string x;
        string y;
        string z;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null || Session["PWD_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
          
           


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
               
        }
        }
       
        public void BindEnseignants()
        {
            ddlnomenseig.DataTextField = "NOM_ENS";
            ddlnomenseig.DataValueField = "ID_ENS";
            ddlnomenseig.DataSource = salle.getEns();
            ddlnomenseig.DataBind();
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

            ddlmodule.DataTextField = "DESIGNATION";
            ddlmodule.DataValueField = "CODE_MODULE";
            ddlmodule.DataSource = salle.getAllModule();
            ddlmodule.DataBind();

        }
        public void BindClas()
        {
            Dropcodecl.DataTextField = "CODE_CL";
            Dropcodecl.DataValueField = "CODE_CL";
            Dropcodecl.DataSource = salle.BindClasspe();
            Dropcodecl.DataBind();
        }
        public void BindClasse()
        {
            ddlcodclasse.DataTextField = "CODE_CL";
            ddlcodclasse.DataValueField = "CODE_CL";
            ddlcodclasse.DataSource = salle.BindClasspe();
            ddlcodclasse.DataBind();
         }
        //event where i selectes a row
        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = Gridemp.SelectedRow;
            Label labelidens = row.FindControl("lblIDabonne") as Label;

            if (labelidens != null)
            {
                //ddlnomenseig.DataBind();
                // lblens.Text = labelidens.Text;
               
                DayPilotCalendar1.Visible = false;
                lblaffect.Text = "AFFECTATION EMPLOI DU TYEMPS";
                Panel2.Visible = true;
               
                ddlnomenseig.DataSource = salle.Getnomens(labelidens.Text);
                ddlnomenseig.DataBind();
                ddlnomenseig.Items.Insert(0, new ListItem("--choisir Enseignant--", "0"));
                DayPilotCalendar2.Visible = false;
                //ici je vais declencher les events 
            }
           
        }
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
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
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='aquamarine';";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
            e.Row.ToolTip = "Click last column for selecting this row.";
        }
    }
        //generation d'un emploi de temps et tester
        protected void btnaddEMP_Click(object sender, EventArgs e)
        {
            dt.TableName = "ESP_AFFECTATION_EMPLOI";
            dt = salle.getEnsIndisponible(ddlcodclasse.SelectedValue, ddlnomenseig.SelectedValue, ddlmodule.SelectedValue, Convert.ToDateTime(txtdebutDate.Text), Convert.ToInt32(DdlNumSeance1.SelectedValue), Convert.ToInt32(DdlNumSeance2.SelectedValue), ddlSalle.SelectedValue);

            //dt2.TableName = "ESP_AFFECTATION_EMPLOI";
            //dt2 = salle.getdispojours(ddljours.SelectedValue, DdlNumSeance1.SelectedValue, DdlNumSeance2.SelectedValue,ddlnomenseig.SelectedValue);
            try
            {
               
                if (dt.Rows.Count == 0)
                {

                    salle.Enre_Affect_emploi(lblanneedeb.Text, Dropcodecl.SelectedValue, ddlmodule.SelectedValue, ddlnomenseig.SelectedValue, ddlSalle.SelectedValue, Convert.ToDateTime(txtdebutDate.Text), int.Parse(DdlNumSeance1.SelectedValue), int.Parse(DdlNumSeance2.SelectedValue));
                    Response.Write(@"<script language='javascript'>alert(' Enseignant Enregistré avec succès');</script>");
                    //DayPilotCalendar1.DataBind();
                   // DayPilotCalendar2.DataBind();
                    refresh();
                    refreshgrid();
                    
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Place indisponible!!!');</script>");

                }
            }
            catch (Exception ex)
            {
                //Response.Write(@"<script language='javascript'>alert('Erreur de serveur');</script>");

                Page.Response.Write("ERROR ERROR ERROR");
            }
        }

        //get seance 1
        protected void DdlNumSeance1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s;
            Label1.Text = DdlNumSeance1.SelectedValue;
            // s=DdlNumSeance1.Text;
        }
        //get seance 2
        protected void DdlNumSeance2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label2.Text = DdlNumSeance2.SelectedValue;
        }
        // bind le plan etude
        //public void bindgrid()
        //{

        //    Gridbord.DataSource = salle.getEnsIndispo(ddlnomenseig.SelectedValue);
        //    Gridbord.DataBind();
        //}

        protected void ddlmodule_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbnheures.Text = salle.GetnbHr(Dropcodecl.SelectedValue, ddlmodule.SelectedValue);
        }

        protected void ddlnomenseig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlnomenseig.SelectedValue != null && ddlcodclasse.SelectedValue != null)
            {

                //bind classes of enseignants
                Dropcodecl.DataSource = salle.getlisteCLbYeNS(ddlnomenseig.SelectedValue);
                Dropcodecl.DataBind();
                Dropcodecl.Items.Insert(0, new ListItem("--Choisir la classe--", "0"));

                //bindgrid();
                lblenseign.Text = "AFFECTATION ACTUELLE DE L'EMPLOI DU TEMPS (CHARGE ENSEIGNANT) : ";
                lblNomEEnsss.Text = salle.getNameteacher(ddlnomenseig.SelectedValue);
                lblNomEEnsss.ForeColor = System.Drawing.Color.OrangeRed;
                DayPilotCalendar2.DataSource = getDataCalendarbyidens(ddlnomenseig.SelectedValue);
                 DayPilotCalendar2.DataBind();
                DayPilotCalendar2.Visible = true;
            }
        }


        public void refreshgrid()
        {
            Gridemp.DataSource = salle.PlanEtuDE(ddlcodclasse.SelectedValue);
            Gridemp.DataBind();
        }

        public void refresh()
        {
            DayPilotCalendar1.DataSource = getDataCalendarbycodecl(Dropcodecl.SelectedValue);
            DayPilotCalendar1.DataBind();

            DayPilotCalendar2.DataSource = getDataCalendarbyidens(ddlnomenseig.SelectedValue);
            DayPilotCalendar2.DataBind();
        }



        protected void ddlcodclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
            if (Dropcodecl.SelectedValue != null)
            {
                ddlSalle.SelectedValue = salle.getsalleBycode(Dropcodecl.SelectedValue);
                lblempcl.Text="EMPLOI DU TEMPS PAR CLASSE";
                lblcodeclasss.Text= Dropcodecl.Text;
                lblcodeclasss.ForeColor= System.Drawing.Color.GreenYellow;
                Gridemp.DataSource = salle.PlanEtuDE(Dropcodecl.SelectedValue);
                Gridemp.DataBind();
                lblcodecl.Text = ddlcodclasse.SelectedValue;
                Label5.Text = "Plan d'Etude pour la classe :";


                ddlmodule.DataSource = salle.BindMODULEByEns(ddlnomenseig.SelectedValue, Dropcodecl.SelectedValue);
                ddlmodule.DataBind();
                ddlmodule.Items.Insert(0, new ListItem("--Choisir Module--", "0"));

                DayPilotCalendar1.DataSource = getDataCalendarbycodecl(Dropcodecl.SelectedValue);
                DayPilotCalendar1.DataBind();
               // lblcodecl.Text = ddlcodclasse.SelectedValue;
                DayPilotCalendar1.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            txtdebutDate_PopupControlExtender1.Commit(Calendar1.SelectedDate.ToShortDateString());
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
                int year = (Convert.ToDateTime(DRow["JOURS"])).Year;
                int month = (Convert.ToDateTime(DRow["JOURS"])).Month;
                int day = (Convert.ToDateTime(DRow["JOURS"])).Day;

                DateTime dte = new DateTime(year, month, day, int.Parse(DRow["CREN_1"].ToString()), 0, 0);
                DateTime dts = new DateTime(year, month, day, int.Parse(DRow["CREN_2"].ToString()), 0, 0);

                DRow["start"] = dte;
                DRow["end"] = dts;
                DRow["DESIGNATION"] = "<CENTER>" + DRow["DESIGNATION"] + "<BR />" + DRow["NOM_ENS"] + "<BR />" + DRow["CODE_CL"] + "<BR />" + DRow["SALLE_PRINCIPALE"] + "<CENTER>";

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
                int year = (Convert.ToDateTime(DRow["JOURS"])).Year;
                int month = (Convert.ToDateTime(DRow["JOURS"])).Month;
                int day = (Convert.ToDateTime(DRow["JOURS"])).Day;

                DateTime dte = new DateTime(year, month, day, int.Parse(DRow["CREN_1"].ToString()), 0, 0);
                DateTime dts = new DateTime(year, month, day, int.Parse(DRow["CREN_2"].ToString()), 0, 0);

                DRow["start"] = dte;
                DRow["end"] = dts;
                DRow["DESIGNATION"] = "<CENTER>" + DRow["DESIGNATION"] + "<BR />" + DRow["NOM_ENS"] + "<BR />" + DRow["CODE_CL"] + "<BR />" + DRow["SALLE_PRINCIPALE"] + "<CENTER>";
            }
            return dt;
        }

        private static DateTime firstDayOfWeek(DateTime day, DayOfWeek weekStarts)
        {
            DateTime d = day;
            while (d.DayOfWeek != weekStarts)
            {
                d = d.AddDays(-1);
            }

            return d;
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
            return list;
        }
    }
}
