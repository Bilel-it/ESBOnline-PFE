using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls ;
using BLL;
using System.Data;


namespace ESPOnline.Etudiants
{
    public partial class Inscripi_test_langueFR2016 : System.Web.UI.Page
    {
        ToiecService service = new ToiecService();
        string id_et;
        DataTable dt;

        string count_nbfr;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_ET"] == null || Session["CIN_PASS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            if (!IsPostBack)
            {
                id_et = Session["ID_ET"].ToString();
                dt = service.get_id_etud_formatioParDate(id_et, "13/04/16");
                // pl1.Visible = false;
                // panel1.Visible = false;
                
                if (dt.Rows.Count != 0)
                {
                    Response.Write(@"<script language='javascript'>alert('Vous êtes déjà inscrit');</script>");
                    // pl1.Visible = false;
                    // panel1.Visible = true;
                    pllo.Visible = false;
                    panel1.Visible = true;
                }
                else
                {
                    string codecl = service.returnCLSUPPmax(id_et);
                    //string codecl14 = service.returnCLSUPP14(id_et);
                    if (codecl.StartsWith("5") || codecl.ToUpper().StartsWith("PS"))
                    {

                        count_nbfr = service.countnbinscrfr_date();

                        int nbfr = Convert.ToInt32(count_nbfr);
                        //Response.Write(@"<script language='javascript'>alert('Veuillez choisir la formation que vous voulez passer');</script>");
                        //pl1.Visible = true;
                        //panel1.Visible = false;

                        if (nbfr <=49)
                        {
                            pllo.Visible = true;
                        }

                        else
                        {
                          Response.Write(@"<script language='javascript'>alert('Le nombre est atteint 50 étudiants');</script>");
                          pllo.Visible = false;
                          panel1.Visible = true;
                        }
                        
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Vous n\'avez pas le droit de passer la formation');</script>");
                        //pl1.Visible = false;
                        //panel1.Visible = true;
                        pllo.Visible = false;
                        panel1.Visible = true;

                    }
                }
            }
        }



        protected void ddltestfr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void Imgvalid_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                if (ddlchoix.SelectedValue == "0")

                {
                    Response.Write(@"<script language='javascript'>alert('Veuillez choisir la date');</script>");

                }

                else 
                
                {
                    pllo.Visible = true;
                    id_et = Session["ID_ET"].ToString();
                    service.Enreg_etud_FORMAt_testparDATE(id_et,ddlchoix.SelectedValue);
                    Response.Write(@"<script language='javascript'>alert('Vous êtes enregistré avec succès');</script>");
                    panel1.Visible = true;
                    pllo.Visible = false;


                
                }
            }

            catch
            {
                Response.Write(@"<script language='javascript'>alert('Erreur de serveur');</script>");

            }

        }

    }

}