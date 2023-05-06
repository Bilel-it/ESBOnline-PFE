using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ESPOnline.Direction
{
    public partial class répartitiondescandidatsparscore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DAL.Admission.Instance.getnbparspe2("05", DropDownList1.SelectedItem.Value);



            string[] x = new string[dt.Rows.Count];
            decimal[] y = new decimal[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                x[i] = dt.Rows[i][1].ToString();

                y[i] = Convert.ToInt32(dt.Rows[i][0]);

            }
            LineChart1.Series.Add(new AjaxControlToolkit.LineChartSeries { Name = "TIC", Data = y });
            DataTable dt1 = DAL.Admission.Instance.getnbparspe2("04", DropDownList1.SelectedItem.Value);
            x = new string[dt1.Rows.Count];
            y = new decimal[dt1.Rows.Count];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                x[i] = dt1.Rows[i][1].ToString();

                y[i] = Convert.ToInt32(dt1.Rows[i][0]);
            }
            LineChart1.Series.Add(new AjaxControlToolkit.LineChartSeries { Name = "EM", Data = y });
            DataTable dt2 = DAL.Admission.Instance.getnbparspe2("03", DropDownList1.SelectedItem.Value);
            x = new string[dt2.Rows.Count];

            y = new decimal[dt2.Rows.Count];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {

                x[i] = dt2.Rows[i][1].ToString();

                y[i] = Convert.ToInt32(dt2.Rows[i][0]);
            }
            LineChart1.Series.Add(new AjaxControlToolkit.LineChartSeries { Name = "GC", Data = y });
            LineChart1.CategoriesAxis = string.Join(",", x);

           // LineChart1.ChartTitle = string.Format("{0} , {1} et {2} : NIVEAU 1", "TIC", "EM", "GC");
            LineChart1.Visible = true;

        }

    }
}