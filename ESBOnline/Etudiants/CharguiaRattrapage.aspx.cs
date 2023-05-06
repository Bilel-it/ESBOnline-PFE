using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSEsprit;
using DAL;

namespace ESPOnline.Etudiants
{
    public partial class CharguiaRattrapage : System.Web.UI.Page
    {
        public string ID_ET;
        public string LIB_DECISION_SESSION_RAT;
        public string CODE_DECISION_SESSION_RAT;
        OrientationDAO orientdao = new OrientationDAO();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            ID_ET = Session["ID_ET"].ToString();
            LIB_DECISION_SESSION_RAT = DAL.OrientationDAO.getDecisionRat(ID_ET, "2015");
            CODE_DECISION_SESSION_RAT = DAL.OrientationDAO.getCodeDecisionRat(ID_ET, "2015");
            if(GridView1.Rows.Count==0)
            {               
                Response.Write("<script LANGUAGE='JavaScript'> alert('Problème Administratif, Veuillez contacter le service compétant')</script>");
                   GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    DetailsView3.Visible = false;
                    Label1.Visible = false;
            }
            else    if (LIB_DECISION_SESSION_RAT == null)
            {
                
                GridView2.Visible = false;
                GridView1.Visible = false;
                GridView3.Visible = false;
                DetailsView3.Visible = false;
                Label1.Visible = false;
            }
            else if (CODE_DECISION_SESSION_RAT == "03")
            {

                Response.Write("<script LANGUAGE='JavaScript'> alert('Veuillez contacter la direction des etudes')</script>");
                GridView2.Visible = false;
                GridView1.Visible = false;
                GridView3.Visible = false;
                DetailsView3.Visible = false;
                Label1.Visible = false;
            }
            else  
            
            {
                //GridView2.Visible = false;
                //GridView1.Visible = false;
                //GridView3.Visible = false;
                //DetailsView3.Visible = false;
                //Label1.Visible = false;

                GridView2.Visible = true;
                GridView1.Visible = true;
                GridView3.Visible = true;
                DetailsView3.Visible = true;
                Label1.Visible = true;
            }
        }
        protected void GrouperAffichage(object sender, EventArgs e)
        {


            for (int rowIndex = GridView3.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {

                GridViewRow row = GridView3.Rows[rowIndex];
                GridViewRow previousRow = GridView3.Rows[rowIndex + 1];

                if (row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;
                 
                }

            }
        }
    }
}