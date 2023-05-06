using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ESPOnline.EmploiEsp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DateTime _dtMonth;
        private DateTime _selectedDate;
        private bool _specialDaySelected = true;
        private int _currentBindingMonth;

        protected void repMonths_OnInit(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(Request.QueryString["CalDate"], out _selectedDate))
            {
                _specialDaySelected = false;
                int selectedMonth, selectedYear;
                int.TryParse(Request.QueryString["CalYear"], out selectedYear);
                int.TryParse(Request.QueryString["CalMonth"], out selectedMonth);

                if (selectedYear <= 0) selectedYear = DateTime.Now.Year;
                if (selectedMonth <= 1) selectedMonth = 1;
                else if (selectedMonth > 12) selectedMonth = 12;

                _selectedDate = new DateTime(selectedYear, selectedMonth, 1);
            }

            litSelectedYear.Text = _selectedDate.Year.ToString();

            repMonths.DataSource = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            repMonths.DataBind();
        }

        protected void repMonths_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repDays = (Repeater)e.Item.FindControl("repDays");
                HyperLink hylMonth = (HyperLink)e.Item.FindControl("hylMonth");
                _currentBindingMonth = (int)e.Item.DataItem;
                _dtMonth = new DateTime(_selectedDate.Year, _currentBindingMonth, 1);

                hylMonth.Text = _dtMonth.ToString("MMM");
                hylMonth.NavigateUrl = string.Format("{0}?CalMonth={1}&CalYear={2}", Request.Path, _currentBindingMonth, _selectedDate.Year);

                if (_currentBindingMonth == _selectedDate.Month) hylMonth.Attributes.Add("class", "selected");

                if (_dtMonth.DayOfWeek != DayOfWeek.Monday)
                {
                    int daysToSubtract = -(int)_dtMonth.DayOfWeek;

                    if (_dtMonth.DayOfWeek == DayOfWeek.Sunday) daysToSubtract = -7; // Special case. US weeks start with sunday, thus the enum DayOfWeek.Sunday = 0.

                    _dtMonth = _dtMonth.AddDays(daysToSubtract + 1);
                }

                DateTime[] dates = new DateTime[37];
                for (int i = 0; i < 37; i++)
                {
                    dates[i] = _dtMonth;
                    _dtMonth = _dtMonth.AddDays(1);
                }

                repDays.DataSource = dates;
                repDays.DataBind();
            }
        }

        protected void repDays_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DateTime date = (DateTime)e.Item.DataItem;
                Literal litDay = (Literal)e.Item.FindControl("litDay");
                HtmlTableCell tdDay = (HtmlTableCell)e.Item.FindControl("tdDay");

                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    tdDay.Attributes.Add("class", "weekend");

                if (_currentBindingMonth == date.Month)
                    litDay.Text = string.Format("<a href=\"{0}?CalDate={3}-{2}-{1}\"{4}>{3}</a>", Request.Path, date.Year, date.Month, date.Day.ToString("D2"), (_specialDaySelected && date.Equals(_selectedDate)) ? " class=\"selected\"" : string.Empty);
                else
                    litDay.Text = string.Format("<span>{0}</span>", date.Day.ToString("D2"));

                // Clear ID's
                tdDay.ID = string.Empty;
            }
        }

        public static string GetDayName(int dayInWeek)
        {
            switch (dayInWeek)
            {
                case 1: return "Lu";
                case 2: return "Mar";
                case 3: return "Mer";
                case 4: return "Je";
                case 5: return "Ve";
                case 6: return "Sa";
                case 7: return "Dim";
            }

            return "God only made seven days in a week.";
        }
    }
}