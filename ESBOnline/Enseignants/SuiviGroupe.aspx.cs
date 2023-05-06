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
    public partial class SuiviGroupe : System.Web.UI.Page
    {
        string NOM_GROUPE;
        string ID_PROJ_GP;
        string ID_PROJET;
        string ID_GROUPE_PROJET;
        string NOM_CLASSE;

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
            NOM_GROUPE = Session["NOM_GROUPE"].ToString();


            ID_PROJ_GP = Session["ID_GROUPE_PROJET"].ToString();
            ID_PROJET = Session["ID_PROJET"].ToString();
            ID_GROUPE_PROJET = Session["ID_GROUPE_PROJET"].ToString();
            NOM_CLASSE = Session["NOM_CLASSE"].ToString();
            

            up = Session["UP"].ToString();
            id = Session["ID_ENS"].ToString();
            nom = Session["NOM_ENS"].ToString();
            cup = Session["CUP"].ToString();

            //Label2.Text = DESCRIPTIO_GROUPE;
            Label4.Text = NOM_GROUPE;
            Label6.Text = NOM_CLASSE;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UP"] = up;
            Session["ID_ENS"] = id;
            Session["NOM_ENS"] = nom;
            Session["CUP"] = cup;
            Response.Redirect("EncadrementGroupe.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=" + NOM_GROUPE + ".pdf");
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