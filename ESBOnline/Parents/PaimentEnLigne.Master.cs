using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Parents
{
    public partial class PaimentEnLigne : System.Web.UI.MasterPage
    {
        string numcompte;
        string ID_ET;
        string NOM_ET;
        string PRENOM_ET;
        string NUM_CIN_PASSEPORT;
        string order;
        //string CODE_CL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CIN_PASS"].ToString() == "13004833")
            {
                Response.Redirect("~/Online/default.aspx");
            }
            
            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
            Label3.Text = Session["CODE_CL"].ToString();
          //  order = Session["ordernumber"].ToString();
            Label2.Text = PRENOM_ET + " " + NOM_ET;
            // Label3.Text = DAL.ResctsDAO.Instance.returnCL(ID_ET); 
        }
      
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Online/Login.aspx");
        }
    }
}