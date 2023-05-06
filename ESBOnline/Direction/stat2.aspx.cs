using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace ESPOnline.Direction.Stat
{
    public partial class stat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DownloadFile(object sender, EventArgs e)
        {
             
                
                Response.ContentType = "Application/x-msexcel";
               string   fileName = Server.MapPath("~/Direction/stat/Admission.xlsx");  //Give path name\file name.

                             

              Response.AppendHeader("Content-Disposition", "attachment; filename=Admission.xlsx"); 

             //Specify the file name which needs to be displayed while prompting

              Response.TransmitFile(fileName);

             Response.End();
            }
        protected void DownloadFile2(object sender, EventArgs e)
        {


            Response.ContentType = "Application/x-msexcel";
            string fileName = Server.MapPath("~/Direction/stat/Effectif Classe.xlsx");  //Give path name\file name.



            Response.AppendHeader("Content-Disposition", "attachment; filename=Effectif.xlsx");

            //Specify the file name which needs to be displayed while prompting

            Response.TransmitFile(fileName);

            Response.End();
        }
        }
    }
