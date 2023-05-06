using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace ESPOnline.EmploiEsp
{
    public partial class EmpClasse : System.Web.UI.Page
    {
        ServiceEDT calendrier = new ServiceEDT();

        private DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            fillcodeClasse();
            //BindEnseignants();
            DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(DateTime.Today);
            if (!IsPostBack)
            {
                //fillcodeClasse();
                DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek();

                // select full week in the Calendar control
                for (int i = 0; i < 8; i++)
                {
                    DateTime selected = DayPilotCalendar1.StartDate.AddDays(i);
                    //Calendar1.SelectedDates.Add(selected);
                }
                //DateTime dm = new DateTime(2008,04,14);
                //DayCalendar1.StartDate = firstDayOfWeek(dm, DayOfWeek.Sunday);

                //get events in a calendar
            }

            lblannee.Text = calendrier.getanneedeb().ToString();
        }

        private DataTable GetEventsbyidENS(string id_ens)
        {
            DataTable dt = new DataTable();

            dt.TableName = "ESP_AFFECTATION_EMPLOI";
            dt = calendrier.BindDataEventsByID_ENS(id_ens);
            return dt;
        }

        private DataTable GetEventsbycode_cl(string code_cl)
        {
            DataTable dt = new DataTable();

            dt.TableName = "ESP_AFFECTATION_EMPLOI";
            dt = calendrier.GetDataEventsByCode_cl(code_cl);
            return dt;
        }

        protected void DayPilotCalendar1_BeforeEventRender(object sender, DayPilot.Web.Ui.Events.Calendar.BeforeEventRenderEventArgs e)
        {
            string color = e.DataItem["color"] as string;
            if (!String.IsNullOrEmpty(color))
            {
                e.DurationBarColor = color;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            setWeek();
        }

        //****************************** les methodes appelées****************************************//

        //afficher emploi du temps pae enseignant
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


        //Affichage emploi du temps par classe
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

        private static DateTime firstDayOfWeek(DateTime day, DayOfWeek weekStarts)
        {
            DateTime d = day;
            while (d.DayOfWeek != weekStarts)
            {
                d = d.AddDays(-1);
            }

            return d;
        }

        private void setWeek()
        {

        }

        private void deleteAndBind(string id)
        {

            #region Simulation of database update

            DataRow dr = table.Rows.Find(id);
            if (dr != null)
            {
                table.Rows.Remove(dr);
                table.AcceptChanges();
            }

            #endregion

            DayPilotCalendar1.DataBind();
            // DayPilotCalendar1.Update();

        }

        //public void BindEnseignants()
        //{

        //    ddlnomenseig.DataTextField = "NOM_ENS";
        //    ddlnomenseig.DataValueField = "ID_ENS";
        //    ddlnomenseig.DataSource = calendrier.getEns();
        //    ddlnomenseig.DataBind();

        //}

        private void fillcodeClasse()
        {
            DdlPromotion.DataTextField = "CODE_CL";
            DdlPromotion.DataValueField = "CODE_CL";
            DdlPromotion.DataSource = calendrier.BindClasspe();
            DdlPromotion.DataBind();
        }

        //protected void ddlnomenseig_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
        //    if (ddlnomenseig.SelectedValue != null)
        //    {
        //        DayPilotCalendar1.DataSource = getDataCalendarbyidens(ddlnomenseig.SelectedValue);
        //        DataBind();
        //    }
        //}

        protected void btnOK_Click1(object sender, ImageClickEventArgs e)
        {
            DayPilotCalendar1.DataSource = getDataCalendarbyidens(null);
            DataBind();
        }

        protected void DdlPromotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
            if (DdlPromotion.SelectedValue != null)
            {
                DayPilotCalendar1.DataSource = getDataCalendarbycodecl(DdlPromotion.SelectedValue);
                DataBind();
            }
        }
    }
}


