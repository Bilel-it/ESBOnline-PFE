using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace ESPOnline.Etudiants
{
    public partial class Formation_2016_langues : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();
        string id_et;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            if (!IsPostBack)
            {
                id_et = Session["ID_ET"].ToString();
                dt = service.verifieretudiant(id_et);
                pl1.Visible = false;
                panel1.Visible = false;

                if (dt.Rows.Count != 0)
                {
                    Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit');</script>");
                    pl1.Visible = false;
                    panel1.Visible = true;
                }
                else
                {
                    string codecl = service.returnCLSUPPmax(id_et);

                    if (codecl.StartsWith("5") || codecl.ToUpper().StartsWith("PS"))
                    {
                        Response.Write(@"<script language='javascript'>alert('Veuillez choisir la formation que vous voulez passer');</script>");
                        pl1.Visible = true;
                        panel1.Visible = false;
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Vous n\'avez pas le droit de passer la formation');</script>");
                        pl1.Visible = false;
                        panel1.Visible = true;

                    }
                }
            }
        }

       

        protected void Enregistrer(object sender, EventArgs e)
        {
            try
            {
                if (ddlchoix.SelectedValue =="")
                {
                    Response.Write(@"<script language='javascript'>alert('Veuillez choisir');</script>");

                }

                else 
                {
                    id_et = Session["ID_ET"].ToString();
                    service.Enreg_etud_FORMATIONfr(id_et, ddlchoix.SelectedValue);
                    Response.Write(@"<script language='javascript'>alert('Vous êtes enregistré avec succès');</script>");
                    pl1.Visible = false;
                    panel1.Visible = true;

 
                }

            }

            catch
            {
                Response.Write(@"<script language='javascript'>alert('Erreur de serveur');</script>");

            }

        }
    }
}