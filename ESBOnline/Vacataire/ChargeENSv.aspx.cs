using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using ESPSuiviEncadrement;
using ABSEsprit;

namespace ESPOnline.Enseignants
{
    public partial class ChargeENSv : System.Web.UI.Page
    {

        string up;
        string id;
        string nom;
        string cup;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null ||Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            string annee_deb = ServicesABS.Instance.getANNEEDEBs();
            up = Session["UP"].ToString();
            id = Session["ID_ENS"].ToString();
            nom = Session["NOM_ENS"].ToString();
            cup = Session["CUP"].ToString();

            OracleCommand cmd = new OracleCommand("SELECT (select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as CODE_MODULE, Code_cl,NB_HEURES,NUM_SEMESTRE,CHARGE_ENS1_P1,CHARGE_ENS1_P2 FROM ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '"+annee_deb+"' and ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = :PARAM1");
            cmd.Parameters.Add(":PARAM1", OracleDbType.Varchar2).Value = id;
            Repeater1.DataSource = this.ExecuteQuery(cmd, "SELECT");
            Repeater1.DataBind();

            OracleCommand cmd2 = new OracleCommand("SELECT (select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as CODE_MODULE, Code_cl,NB_HEURES,NUM_SEMESTRE,CHARGE_ENS2_P1,CHARGE_ENS2_P2 FROM ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '"+annee_deb+"' and ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2 = :PARAM1");
            cmd2.Parameters.Add(":PARAM1", OracleDbType.Varchar2).Value = id;
            Repeater2.DataSource = this.ExecuteQuery(cmd2, "SELECT");
            Repeater2.DataBind();

            OracleCommand cmd3 = new OracleCommand("SELECT (select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as CODE_MODULE, Code_cl,NB_HEURES,NUM_SEMESTRE,CHARGE_ENS3_P1,CHARGE_ENS3_P2 FROM ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '"+annee_deb+"' and ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3 = :PARAM1");
            cmd3.Parameters.Add(":PARAM1", OracleDbType.Varchar2).Value = id;
            Repeater3.DataSource = this.ExecuteQuery(cmd3, "SELECT");
            Repeater3.DataBind();

            OracleCommand cmd4 = new OracleCommand("SELECT (select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as CODE_MODULE, Code_cl,NB_HEURES,NUM_SEMESTRE,CHARGE_ENS4_P1,CHARGE_ENS4_P2 FROM ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '"+annee_deb+"' and ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4 = :PARAM1");
            cmd4.Parameters.Add(":PARAM1", OracleDbType.Varchar2).Value = id;
            Repeater4.DataSource = this.ExecuteQuery(cmd4, "SELECT");
            Repeater4.DataBind();

            OracleCommand cmd5 = new OracleCommand("SELECT (select Designation from ESP_MODULE where ESP_MODULE.CODE_MODULE=ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE)as CODE_MODULE, Code_cl,NB_HEURES,NUM_SEMESTRE,CHARGE_ENS5_P1,CHARGE_ENS5_P2 FROM ESP_MODULE_PANIER_CLASSE_SAISO WHERE ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '"+annee_deb+"' and ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5 = :PARAM1");
            cmd5.Parameters.Add(":PARAM1", OracleDbType.Varchar2).Value = id;
            Repeater5.DataSource = this.ExecuteQuery(cmd5, "SELECT");
            Repeater5.DataBind();
            Labelnomens.Text = "Enseignant : " + nom;
            Labelup.Text = up;

            Label31.Text = "Total Charge P1 : " + Convert.ToString(getTotalENS(5));
            Label32.Text = "Total Charge P2 : " + Convert.ToString(getTotalENS(6));
            Label33.Text = "Total Charge P1 : " + Convert.ToString(getTotalENS2(11));
            Label34.Text = "Total Charge P2 : " + Convert.ToString(getTotalENS2(12));
            Label35.Text = "Total Charge P1 : " + Convert.ToString(getTotalENS3(17));
            Label36.Text = "Total Charge P2 : " + Convert.ToString(getTotalENS3(18));
            Label37.Text = "Total Charge P1 : " + Convert.ToString(getTotalENS4(23));
            Label38.Text = "Total Charge P2 : " + Convert.ToString(getTotalENS4(24));
            Label39.Text = "Total Charge P1 : " + Convert.ToString(getTotalENS5(29));
            Label40.Text = "Total Charge P2 : " + Convert.ToString(getTotalENS5(30));


            if (Repeater1.Items.Count == 0)
            {
                Panel2.Visible = false;
            }
            if (Repeater2.Items.Count == 0)
            {
                Panel3.Visible = false;
            }
            if (Repeater3.Items.Count == 0)
            {
                Panel4.Visible = false;
            }
            if (Repeater4.Items.Count == 0)
            {
                Panel5.Visible = false;
            }
            if (Repeater5.Items.Count == 0)
            {
                Panel6.Visible = false;
            }
            double totcharg1 = 0;
            double totcharg2 = 0;

            totcharg1 = getTotalENS(5) + getTotalENS2(11) + getTotalENS3(17) + getTotalENS4(23) + getTotalENS5(29);
            totcharg2 = getTotalENS(6) + getTotalENS2(12) + getTotalENS3(18) + getTotalENS4(24) + getTotalENS5(30);
            Label44.Text = Convert.ToString(totcharg1);
            Label45.Text = Convert.ToString(totcharg2);
            double total = 0;
            total = Convert.ToDouble(Label44.Text.ToString().Trim()) + Convert.ToDouble(Label45.Text.ToString().Trim());
            Label46.Text = Convert.ToString(total);
        }

        private DataTable ExecuteQuery(OracleCommand cmd, string action)
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(conString))
            {
                cmd.Connection = con;
                switch (action)
                {
                    case "SELECT":
                        using (OracleDataAdapter sda = new OracleDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                return dt;
                            }
                        }
                }
                return null;
            }
        }

        private double getTotalENS(int i)
        {
            double tot = 0;
            double x = 0;
            foreach (RepeaterItem item in Repeater1.Items)
            {

                Label lbl = (Label)item.FindControl("Label" + i);
                if (lbl.Text != "")
                {
                    x = Convert.ToDouble(lbl.Text.ToString());
                    tot = tot + x;
                }



            }
            return tot;
        }

        private double getTotalENS2(int i)
        {
            double tot = 0;
            double x = 0;
            foreach (RepeaterItem item in Repeater2.Items)
            {

                Label lbl = (Label)item.FindControl("Label" + i);

                if (lbl.Text != "")
                {
                    x = Convert.ToDouble(lbl.Text.ToString());
                    tot = tot + x;
                }
            }
            return tot;
        }

        private double getTotalENS3(int i)
        {
            double tot = 0;
            double x = 0;
            foreach (RepeaterItem item in Repeater3.Items)
            {

                Label lbl = (Label)item.FindControl("Label" + i);
                if (lbl.Text != "")
                {
                    x = Convert.ToDouble(lbl.Text.ToString());
                    tot = tot + x;
                }
            }
            return tot;
        }

        private double getTotalENS4(int i)
        {
            double tot = 0;
            double x = 0;
            foreach (RepeaterItem item in Repeater4.Items)
            {

                Label lbl = (Label)item.FindControl("Label" + i);
                if (lbl.Text != "")
                {
                    x = Convert.ToDouble(lbl.Text.ToString());
                    tot = tot + x;
                }
            }
            return tot;
        }

        private double getTotalENS5(int i)
        {
            double tot = 0;
            double x = 0;
            foreach (RepeaterItem item in Repeater5.Items)
            {

                Label lbl = (Label)item.FindControl("Label" + i);
                if (lbl.Text != "")
                {
                    x = Convert.ToDouble(lbl.Text.ToString());
                    tot = tot + x;
                }


            }
            return tot;
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            Panel7.RenderControl(hw);
            Panel2.RenderControl(hw);
            Panel3.RenderControl(hw);
            Panel4.RenderControl(hw);
            Panel5.RenderControl(hw);
            Panel6.RenderControl(hw);
            Panel8.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["ID_ENS"] = id;
            Session["UP"] = up;
            Session["NOM_ENS"] = nom;
            Session["CUP"] = cup;
            Response.Redirect("Affectation.aspx");
        }
    }
}