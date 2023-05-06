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


namespace ESPOnline.Enseignants
{
    public partial class Suivi : System.Web.UI.Page
    {
        string nomet;
        string idet;
        string idproj;

        string up;
        string id;
        string nom;
        string cup;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            nomet = Session["NOM_ET"].ToString();
            idet = Session["ID_ET"].ToString();
            idproj = Session["ID_PROJ"].ToString();

            up = Session["UP"].ToString();
            id = Session["ID_ENS"].ToString();
            nom = Session["NOM_ENS"].ToString();
            cup = Session["CUP"].ToString();

            Label2.Text = idproj;
            Label4.Text = nomet;
            Label6.Text = idet;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UP"] = up;
            Session["ID_ENS"] = id;
            Session["NOM_ENS"] = nom;
            Session["CUP"] = cup;
            Response.Redirect("Encadrement.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=" + nomet + ".pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);

            //Panel1.RenderControl(hw);



            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 100f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();
            Response.Write("<script LANGUAGE='JavaScript'> alert('changer l'orientation de Portrait vers Paysage pour avoir les informations COMPLET .')</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "imprimer();", true);
        }
    }
}