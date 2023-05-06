using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Maha
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["__EVENTTARGET"] != null)
            {
                Response.Write(Request.Form["__EVENTARGUMENT"]);
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Cell.Text = "";
            CheckBox cb = new CheckBox();
            cb.ID = "cb_" + e.Day.Date.ToString();
            cb.Text = e.Day.DayNumberText;
            cb.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(cb, "CheckChanged");  //add postback event(javascript)


            e.Cell.Controls.Add(cb);
        }
    }
}