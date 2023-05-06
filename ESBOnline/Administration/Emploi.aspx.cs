using System;
using System.IO;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Collections.Generic;
 


namespace ESPOnline.Administration
{
    public partial class Emploi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["ID_ENS"] == null)
            //{
            //    Response.Redirect("~/Online/default.aspx");
            //}
            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            if (!IsPostBack)
            {
                GridView1.DataBind();
                BindGrid();
                GridView2.DataBind();
                BindGrid2();
            }

        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            {

                if (FileUploadControl.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(FileUploadControl.FileName);
                        string name = filename.ToString();
                        FileUploadControl.SaveAs(Server.MapPath("../DOC/") + filename);
                        StatusLabel.Text = "Fichier chargé!" + filename.ToString();
                        //Response.Write("<script LANGUAGE='JavaScript'> alert(" + name + ") </script>");
                        Response.Write("<script LANGUAGE='JavaScript'> alert('Fichier chargé ') </script>");
                        BindGrid();
                        BindGrid2();
                    }
                    catch (Exception ex)
                    {
                        //StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                        Response.Write("<script LANGUAGE='JavaScript'> alert(' Le fichier n'a pas pu être chargé. L'erreur suivante s'est')</script>");

                    }
                }
            }
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
            BindGrid2();
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
        protected void BindGrid2()
        {
            //  string[] filePaths = Directory.GetFiles(Server.MapPath("~/DOC/"));
            List<FileInfo> fiList = new List<FileInfo>();
            foreach (string fileName in Directory.GetFiles(Server.MapPath("~/DOC/")))
            {
                FileInfo fi = new FileInfo(fileName);
                fiList.Add(fi);
            }
            GridView2.DataSource = fiList;
            GridView2.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
    }
}