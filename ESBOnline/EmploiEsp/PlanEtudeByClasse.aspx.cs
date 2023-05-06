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
    public partial class PlanEtudeByClasse : System.Web.UI.Page
    {
    ServiceEDT calendrier = new ServiceEDT();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //fillcodeClasse();
                
                //DayCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek();

                //// select full week in the Calendar control
                //for (int i = 0; i < 8; i++)
                //{
                //    DateTime selected = DayCalendar1.StartDate.AddDays(i);
                //    Calendar1.SelectedDates.Add(selected);
                //}
                ////DateTime dm = new DateTime(2008,04,14);
                //DayCalendar1.StartDate = firstDayOfWeek(dm, DayOfWeek.Sunday);

                //get events in a calendar
                //DayCalendar1.DataSource = getDataCalendar();
                //DataBind();
            }

        }
        private DataTable GetEvents()
        {
            DataTable dt = new DataTable();

            dt.TableName = "ESP_SEANCE_ENS";
            dt = calendrier.GetDataEvents();
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

        protected DataTable getDataCalendar()
        {
            DataTable dt = new DataTable();



            dt = GetEvents();
            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));

            foreach (DataRow DRow in dt.Rows)
            {
                int year = (Convert.ToDateTime(DRow["DATE_SEANCE"])).Year;
                int month = (Convert.ToDateTime(DRow["DATE_SEANCE"])).Month;
                int day = (Convert.ToDateTime(DRow["DATE_SEANCE"])).Day;

                DateTime dte = new DateTime(year, month, day, int.Parse(DRow["HEURE_ENTREE"].ToString()), int.Parse(DRow["MINUTE_ENTREE"].ToString()), 0);
                DateTime dts = new DateTime(year, month, day, int.Parse(DRow["HEURE_SORTIE"].ToString()), int.Parse(DRow["MINUTE_SORTIE"].ToString()), 0);

                DRow["start"] = dte;
                DRow["end"] = dts;
                DRow["DESIGNATION"] = DRow["DESIGNATION"] + "\r\n" + DRow["NOM_ENS"] + "\r\n" + DRow["CODE_CL"] + "\r\n" + DRow["SALLE"];

            }
            //dt.Columns.Add("start", typeof(DateTime));
            //dt.Columns.Add("end", typeof(DateTime));
            //dt.Columns.Add("DESIGNATION", typeof(string));
            //dt.Columns.Add("CODE_MODULE", typeof(string));

            //DataRow dr;

            //dr = dt.NewRow();
            //dr["CODE_MODULE"] = 0;
            //dr["start"] = Convert.ToDateTime("13:00");
            //dr["end"] = Convert.ToDateTime("14:00");
            //dr["DESIGNATION"] = "events";
            //dt.Rows.Add(dr);

            /*
            dr = dt.NewRow();
            dr["CODE_MODULE"] = 1;
            dr["start"] = Convert.ToDateTime("19:00");
            dr["end"] = Convert.ToDateTime("20:30");
            dr["DESIGNATION"] = "PAUSE";
            dr["color"] = "red";
            dt.Rows.Add(dr);*/

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
            DateTime firstDay = firstDayOfWeek(Calendar1.SelectedDate, DayOfWeek.Sunday);
            Calendar1.VisibleDate = firstDay;
            for (int i = 0; i < 7; i++)
                Calendar1.SelectedDates.Add(firstDay.AddDays(i));

            DayCalendar1.StartDate = firstDay;


        }


        private void fillcodeClasse()
        {
            ddclasse.DataTextField = "CODE_CL";
            ddclasse.DataValueField = "CODE_CL";

            ddclasse.DataSource = calendrier.getAllClasses();
            ddclasse.DataBind();

            ddclasse.Items.Insert(0, new ListItem("--Select One--", "--Select One--"));
            ddclasse.SelectedItem.Selected = false;
            ddclasse.Items.FindByText("--Select One--").Selected = true;

        }

        protected void ddclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddclasse.SelectedValue != null)
            {
                getDataCalendar();
                this.DayCalendar1.DataValueField.ToString();
            }
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int days = Convert.ToInt32(DropDownList1.SelectedValue);
            DayCalendar1.Days = days;
    
        }
    }
}
