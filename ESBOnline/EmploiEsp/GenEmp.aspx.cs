using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Drawing.Imaging;

namespace ESPOnline.EmploiEsp
{
    public partial class GenEmp : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        ServiceEDT salle = new ServiceEDT();
        protected void Page_Load(object sender, EventArgs e)
        {
            DayPilotCalendar1.Visible = false;
            BindClas();
        }
      
        

        private DataTable GetEventsbycode_cl(string code_cl)
        {
            DataTable dt = new DataTable();

            dt.TableName = "ESP_AFFECTATION_EMPLOI";
          //  dt = salle.GroupByCode_cl(code_cl);
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

        protected void ddlcodclasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            DayPilotCalendar1.Visible = true;
            DayPilotCalendar1.DataSource = getDataCalendarbycodecl(ddlcodclasse.SelectedValue);
            DayPilotCalendar1.DataBind();

        }
        public void BindClas()
        {
            ddlcodclasse.DataTextField = "CODE_CL";
            ddlcodclasse.DataValueField = "CODE_CL";
            ddlcodclasse.DataSource = salle.BindClasspe();
            ddlcodclasse.DataBind();
        }
    }
}