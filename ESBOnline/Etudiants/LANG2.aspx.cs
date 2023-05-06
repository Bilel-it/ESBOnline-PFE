using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Etudiants
{
    public partial class LANG2 : System.Web.UI.Page
    {
        public string ID_ET;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string NOM_ET;
            string PRENOM_ET;
            string NUM_CIN_PASSEPORT;
            ID_ET = Session["ID_ET"].ToString();
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            List<string> etdp = new List<string>  {"aa"};
//            { "123JFT0830","11-3MT-610","123JFT1280","123JMT0829","11-3MT-406","123JMT0254",
//"123JMT0641","10-1MT-172","123JMT2460","1231MT-009","1231MT-045","123JMT1180","11-3FT-824","123JFT1559","10-1FT-858","123JMT1018","123JMT1079","123JFT0398","10-1MT-853","123JMT1413","123JMT0847","123JMT0269","123JFT2279","123JMT0808","123JMT1118","123JMT0564","123JMT2478","123JMT2128","1231FT-043","1231MT-048","123JFT0917","123JFT1795","123JMT0453","1231FT-005","123JMT0874","123JMT2196","123JMT0908","11-2MT-843","123JMT0877","11-2FT-742","123JMT2033","123JMT0659","11-3MT-406","10-1FT-214","11-2MT-390","1231MT-045",
//"123JMT1079","123JMT2716","123JMT0371",
//"11-2MT-788","123JMT2478","123JMT1248","123JMT0453","11-2MT-249","11-3MT-610",
//"123JFT1280","123JMT0829","123JFT1000","123JMT1519","11-3MT-406","10-1FT-214","123JMT0641",
//"123JMT0317","1231MT-078","123JFT2634","123JMT0972","123JMT2460","123JMT0510",
//"10-1FT-177","1231MT-045","123JMT1180","11-2MT1088","11-3FT-824",
//"123JMT0774","10-1FT-858","123JMT0152","123JMT1018","123JMT0759","123JMT1079",
//"123JFT0398","123JMT1774","123JMT2716","123JMT0847","10-1MT-222","123JMT0371",
//"123JMT0779","11-2MT-788","123JFT2279","123JMT2478","1231FT-043","1231MT-048",
//"123JMT2316","123JMT0453","123JMT2599","11-2FT-742" };
            if (etdp.Contains(Session["ID_ET"].ToString()))
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Vous devez payer les frais dinscription aux tests')</script>");
                GridView2.Visible = false;
            }
            if (GridView2.Rows.Count == 0)
            {
                GridView2.Visible = false;
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétent')</script>");

            }
           
            if (!IsPostBack)
            {

            }
          
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
            if (Class1.Instance.verify(NUM_CIN_PASSEPORT) == false)
                Response.Redirect("Resultas.aspx");

        }
        protected void GridView1_test(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell cell in e.Row.Cells)
            {

                cell.Attributes.CssStyle["text-align"] = "center";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statuscell = e.Row.Cells[0];
                TableCell statuscell1 = e.Row.Cells[1];
                    if(statuscell.Text=="NN")
                    {
                        statuscell.Text = "Absent";
                    }
                    if (statuscell1.Text == "NN")
                    {
                        statuscell1.Text = "Absent";
                    }

            }
        }
    }
}