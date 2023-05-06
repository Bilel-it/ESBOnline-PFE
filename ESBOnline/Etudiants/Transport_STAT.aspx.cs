using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Etudiants
{
    public partial class Transport_STAT : System.Web.UI.Page
    {
        LangueService service = new LangueService();
        string ID_ET;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");

            }
            ID_ET = Session["ID_ET"].ToString();
        }

        protected void RadioBtncjBUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioBtncjBUS.SelectedValue=="O")
            {

               // service.enreg8transportoui(ID_ET, RadioBtncjBUS.SelectedValue,ddlannee_debM.SelectedValue);
                ddlannee_debM.Visible = true;
                Btnscore_finale.Visible = true;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Enregistrement avec succès');", true);

            }

            else
            {
                if (RadioBtncjBUS.SelectedValue == "N")
                {
                  //service.enreg8transportnon(ID_ET, RadioBtncjBUS.SelectedValue);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Merci pour votre collaboration');", true);
                    ddlannee_debM.Visible = false;
                    Btnscore_finale.Visible = true;

                }

            }
        }

        protected void Btnscore_finale_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = service.Find_TARANSPORT(ID_ET);

            if(dt.Rows.Count==0)
            {
                // ddlannee_debM.Visible = true;
                if (RadioBtncjBUS.SelectedValue == "O")
                {

                    service.enreg8transportoui(ID_ET, RadioBtncjBUS.SelectedValue, ddlannee_debM.SelectedValue);
                    // ddlannee_debM.Visible = true;
                  //  ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "');", true);

                    Response.Write("<script LANGUAGE='JavaScript'> alert('Enregistrement effectué avec succès')</script>");
                }

                else
                {
                    if (RadioBtncjBUS.SelectedValue == "N")
                    {
                        service.enreg8transportnon(ID_ET, RadioBtncjBUS.SelectedValue);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "');", true);

                        Response.Write("<script LANGUAGE='JavaScript'> alert('Merci pour votre collaboration')</script>");
                        // ddlannee_debM.Visible = false;

                    }

                }
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Vous êtes inscrit')</script>");


            }

        }
    }
}