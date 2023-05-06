using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace ESPOnline.Direction
{
    public partial class Niveau_R : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            if (!IsPostBack)
            {
                reportview();
            }
        }
        public void reportview()
        {
            try
            {

                ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://41.226.11.244/ReportServer1");
                ReportViewer1.ServerReport.ReportPath = "/Report_Project1/Niveau_F";
                ReportViewer1.ServerReport.Refresh();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}