using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace ESPOnline.Etudiants
{
    public partial class Emplois : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                BindGrid();
            }
            ID_ET = Session["ID_ET"].ToString();
            NOM_ET = Session["NOM_ET"].ToString();
            PRENOM_ET = Session["PNOM_ET"].ToString();
            NUM_CIN_PASSEPORT = Session["CIN_PASS"].ToString();
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
        protected void BrowseFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;


            WebClient user = new WebClient();
            Byte[] FileBuffer = user.DownloadData(filePath);
            if (FileBuffer != null)
            {
                // Response.ContentType = ContentType;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }


        }
        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            BindGrid();
        }
        protected void BindGrid()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/DOC/"));
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }
            GridView1.DataSource = files;
            GridView1.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}