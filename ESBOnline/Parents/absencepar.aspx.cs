using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Parents
{
    public partial class absencepar : System.Web.UI.Page
    {
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
            HiddenField1.Value = ID_ET;
            if (GridView2.Rows.Count == 0)
            {
                Label6.Text = "Aucune absence n'a été saisie";
            }
            foreach (GridViewRow gvr in GridView2.Rows)
            {

                switch (gvr.Cells[1].Text)
                {
                    case "1":
                        gvr.Cells[1].Text = "9:00 à 10:30";
                        break;
                    case "2":
                        gvr.Cells[1].Text = "10:45 à 12:15";
                        break;
                    case "3":
                        gvr.Cells[1].Text = "14:00 à 15:30";
                        break;
                    case "4":
                        gvr.Cells[1].Text = "15:45 à 17:15";
                        break;
                }
            }
        }
    }
}