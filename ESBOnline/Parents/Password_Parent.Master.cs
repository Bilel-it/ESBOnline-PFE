﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Parents
{
    public partial class Password_Parent : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Online/default.aspx");
        }
    }
}