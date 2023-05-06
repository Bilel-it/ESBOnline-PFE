using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace ESPOnline.EmploiEsp
{
    public partial class TestDeleting : System.Web.UI.Page
    {
        private Dictionary<DateTime, List<Control>> DayControls = new Dictionary<DateTime, List<Control>>();

        protected void Page_Init(object sender, EventArgs e)
        {
            Calendar1.DayRender += new DayRenderEventHandler(Calendar1_DayRender);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Calendar1.VisibleDate == DateTime.MinValue)
                {
                    Calendar1.VisibleDate = DateTime.Today;
                }
            }

            FillDayControls(Calendar1.VisibleDate);
        }

        void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (!DayControls.ContainsKey(e.Day.Date)) return;

            foreach (var control in DayControls[e.Day.Date])
            {
                control.Parent.Controls.Remove(control);

                e.Cell.Controls.Add(control);

                if (control is Button)
                {
                    ClientScript.RegisterForEventValidation(control.UniqueID);
                }
            }
        }

        private void FillDayControls(DateTime dateTime)
        {
            var firstMonthDate = new DateTime(dateTime.Year, dateTime.Month, 1);

            var calendarFirstWeekDay = Calendar1.FirstDayOfWeek == FirstDayOfWeek.Default
                                        ? CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
                                        : (DayOfWeek)(int)Calendar1.FirstDayOfWeek;

            var currentDate = firstMonthDate.DayOfWeek == calendarFirstWeekDay ? firstMonthDate.AddDays(-7) : firstMonthDate.AddDays((int)firstMonthDate.DayOfWeek * -1);
            var lastDate = currentDate.AddDays(41);

            do
            {
                var events = GetCalendarEvents(currentDate);
                if (events.Count > 0)
                {
                    DayControls.Add(currentDate, new List<Control>());
                }

                foreach (var calendarEvent in events)
                {
                    var lbl = new Label
                                    {
                                        BorderColor = System.Drawing.Color.Black,
                                        BorderStyle = BorderStyle.Double,
                                        BackColor = System.Drawing.Color.BlanchedAlmond,
                                        Text = string.Format("{0}<br />{1:hh:mm:ss tt} -- {2:hh:mm:ss tt}", calendarEvent.Title, calendarEvent.Start, calendarEvent.End)
                                    };
                    DayControls[currentDate].Add(lbl);
                    PlaceHolder1.Controls.Add(lbl);

                    var btn = new Button
                                    {
                                        Text = "x",
                                        ID = "DeleteEvent_" + calendarEvent.Id,
                                        CommandName = "DeleteEvent",
                                        CommandArgument = calendarEvent.Id
                                    };

                    DayControls[currentDate].Add(btn);
                    PlaceHolder1.Controls.Add(btn);
                    btn.Click += new EventHandler(btn_Click);

                }

                currentDate = currentDate.AddDays(1);
            } while (currentDate <= lastDate);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var eventId = ((Button)sender).CommandArgument;
        }

        private List<private Dictionary<DateTime, List<Control>> DayControls = new Dictionary<DateTime, List<Control>>();

protected void Page_Init(object sender, EventArgs e)
{
    Calendar1.DayRender += new DayRenderEventHandler(Calendar1_DayRender);
}

protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        if(Calendar1.VisibleDate == DateTime.MinValue)
        {
            Calendar1.VisibleDate = DateTime.Today;
        }
    }
    FillDayControls(Calendar1.VisibleDate);
}

void Calendar1_DayRender(object sender, DayRenderEventArgs e)
{
    if (!DayControls.ContainsKey(e.Day.Date)) return;

    foreach (var control in DayControls[e.Day.Date])
    {
        control.Parent.Controls.Remove(control);

        e.Cell.Controls.Add(control);

        if (control is Button)
        {
            ClientScript.RegisterForEventValidation(control.UniqueID);
        }
    }
}

private void FillDayControls(DateTime dateTime)
{
    var firstMonthDate = new DateTime(dateTime.Year, dateTime.Month, 1);

    var calendarFirstWeekDay = Calendar1.FirstDayOfWeek == FirstDayOfWeek.Default
                                ? CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
                                : (DayOfWeek) (int) Calendar1.FirstDayOfWeek;

    var currentDate = firstMonthDate.DayOfWeek == calendarFirstWeekDay ? firstMonthDate.AddDays(-7) : firstMonthDate.AddDays((int)firstMonthDate.DayOfWeek * -1);
    var lastDate = currentDate.AddDays(41);

    do
    {
        var events = GetCalendarEvents(currentDate);
        if (events.Count > 0)
        {
            DayControls.Add(currentDate, new List<Control>());
        }

        foreach (var calendarEvent in events)
        {
            var lbl = new Label
                            {
                                BorderColor = System.Drawing.Color.Black,
                                BorderStyle = BorderStyle.Double,
                                BackColor = System.Drawing.Color.BlanchedAlmond,
                                Text = string.Format("{0}<br />{1:hh:mm:ss tt} -- {2:hh:mm:ss tt}", calendarEvent.Title, calendarEvent.Start, calendarEvent.End)
                            };
            DayControls[currentDate].Add(lbl);
            PlaceHolder1.Controls.Add(lbl);

            var btn = new Button
                            {
                                Text = "x",
                                ID = "DeleteEvent_" + calendarEvent.Id,
                                CommandName = "DeleteEvent",
                                CommandArgument = calendarEvent.Id
                            };

            DayControls[currentDate].Add(btn);
            PlaceHolder1.Controls.Add(btn);
            btn.Click += new EventHandler(btn_Click);

        }

        currentDate = currentDate.AddDays(1);
    } while (currentDate <= lastDate);
}

private void btn_Click(object sender, EventArgs e)
{
    var eventId = ((Button)sender).CommandArgument;
}

private List<CalendarEvent> GetCalendarEvents(DateTime dateTime)
{
    return new List<CalendarEvent>
    {
                    new CalendarEvent
                    {
                        Id = string.Format("{0:MMMddyyyy}Event" ,dateTime),
                        Start = dateTime.Date.AddHours(10),
                        End = dateTime.Date.AddHours(12),
                        Title = string.Format("{0:dd/MM} meeting", dateTime)
                    } };
}

 GetCalendarEvents(DateTime dateTime)
        {
            return new List<CalendarEvent>{
                    new CalendarEvent
                    {
                        Id = string.Format("{0:MMMddyyyy}Event" ,dateTime),
                        Start = dateTime.Date.AddHours(10),
                        End = dateTime.Date.AddHours(12),
                        Title = string.Format("{0:dd/MM} meeting", dateTime)
                    }};
        }
       
    }
}