using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DayPilot.Utils;
using DayPilot.Web.Ui;
using DayPilot.Web.Ui.Data;
using DayPilot.Web.Ui.Enums;
using DayPilot.Web.Ui.Events.Scheduler;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using BeforeEventRenderEventArgs = DayPilot.Web.Ui.Events.Calendar.BeforeEventRenderEventArgs;
using CommandEventArgs = DayPilot.Web.Ui.Events.CommandEventArgs;
using System.Collections;
using DocumentFormat.OpenXml.Drawing;

namespace ESPOnline.EmploiEsp
{
    public partial class EmploiparEnsClasse : System.Web.UI.Page
    {
        ServiceEDT calendrier = new ServiceEDT();

        private DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Today;
            int JourDsSemaine = (int)d.DayOfWeek;
            d = d.AddDays((-1) * JourDsSemaine + 1);
            lbldatedebut.Text = d.ToString("dd/MM/yyyy");


            lbldatefin.Text = d.AddDays(5).ToString("dd/MM/yyyy");
            fillcodeClasse();
            //BindEnseignants();
            DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(DateTime.Today);
            if (!IsPostBack)
            {
                //fillcodeClasse();
                DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek();

                // select full week in the Calendar control
                for (int i = 0; i < 8; i++)
                {
                    DateTime selected = DayPilotCalendar1.StartDate.AddDays(i);
                    //Calendar1.SelectedDates.Add(selected);
                }
                //DateTime dm = new DateTime(2008,04,14);
                //DayCalendar1.StartDate = firstDayOfWeek(dm, DayOfWeek.Sunday);

                //get events in a calendar
            }

            lblannee.Text = calendrier.getanneedeb().ToString();
        }

        private DataTable GetEventsbyidENS(string id_ens)
        {
            DataTable dt = new DataTable();

            dt.TableName = "ESP_AFFECTATION_EMPLOI";
            dt = calendrier.BindDataEventsByID_ENS(id_ens);
            return dt;
        }

        private DataTable GetEventsbycode_cl(string code_cl)
        {
            DataTable dt = new DataTable();

            dt.TableName = "ESP_AFFECTATION_EMPLOI";
            dt = calendrier.GetDataEventsByCode_cl(code_cl);
            return dt;
        }

        protected void DayPilotCalendar1_BeforeEventRender(object sender, DayPilot.Web.Ui.Events.Calendar.BeforeEventRenderEventArgs e)
        {
            string color = e.DataItem["color"] as string;
            if (!String.IsNullOrEmpty(color))
            {
                e.DurationBarColor = color;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            setWeek();
        }

        //****************************** les methodes appelées****************************************//

        protected DataTable getDataCalendarbycodecl(string code_cl)
        {
            DataTable dt = new DataTable();
            dt = GetEventsbycode_cl(code_cl);
            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));

            foreach (DataRow DRow in dt.Rows)
            {
                //int year = (Convert.ToDateTime(DRow["JOURS"])).Year;
                //int month = (Convert.ToDateTime(DRow["JOURS"])).Month;
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;

                Dictionary<string, string> dictionary =
                    new Dictionary<string, string>();
                dictionary.Add("1", "9,00");
                dictionary.Add("2", "12,30");
                dictionary.Add("3", "14,00");
                dictionary.Add("4", "17,30");

                //int day = int.Parse(DRow["JOURS"].ToString());
                int day = (Convert.ToDateTime(DRow["JOURS"])).Day;
                string seance = dictionary[DRow["CREN_1"].ToString()];
                string seance2 = dictionary[DRow["CREN_2"].ToString()];
                string[] heures = seance.Split(',');

                string[] heures2 = seance2.Split(',');
                //string[] heuretotal =  string.Concat(heures,heures2);
                List<string> list = new List<string>();
                list.AddRange(heures);
                list.AddRange(heures2);
                string[] z = list.ToArray();
                int heure_deb = int.Parse(z[0]);
                int min_deb = int.Parse(z[1]);
                int heure_fin = int.Parse(z[2]);
                int min_fin = int.Parse(z[3]);


                DateTime dte = new DateTime(year, month, day, heure_deb, min_deb, 0);
                DateTime dts = new DateTime(year, month, day, heure_fin, min_fin, 0);

                DRow["start"] = dte;
                DRow["end"] = dts;
               //
               //DRow["DESIGNATION"] = "<CENTER>" + DRow["DESIGNATION"] + "<BR />" + DRow["NOM_ENS"] + "<BR />" + DRow["CODE_CL"] + "<BR />" + DRow["SALLE_PRINCIPALE"] + "<CENTER>";
              DRow["DESIGNATION"] = DRow["DESIGNATION"] + "                                                                                                                                                                                                      " + DRow["NOM_ENS"] + "                                                                                                                                                                  " + DRow["CODE_CL"] + "                                                                                                                                                                                                         " + DRow["SALLE_PRINCIPALE"]+"                                                                                                              ";
               
            }
            return dt;
        }

        protected DataTable getDataCalendarbyidens(string id_ens)
        {
            DataTable dt = new DataTable();
            dt = GetEventsbyidENS(id_ens);

            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));

            foreach (DataRow DRow in dt.Rows)
            {
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;

                Dictionary<string, string> dictionary =
                    new Dictionary<string, string>();
                dictionary.Add("1", "9,00");
                dictionary.Add("2", "12,30");
                dictionary.Add("3", "14,00");
                dictionary.Add("4", "17,30");

                // int day = int.Parse(DRow["JOURS"].ToString());
                int day = (Convert.ToDateTime(DRow["JOURS"])).Day;
                string seance = dictionary[DRow["CREN_1"].ToString()];
                string seance2 = dictionary[DRow["CREN_2"].ToString()];
                string[] heures = seance.Split(',');
                string[] heures2 = seance2.Split(',');
                //string[] heuretotal =  string.Concat(heures,heures2);
                List<string> list = new List<string>();
                list.AddRange(heures);
                list.AddRange(heures2);
                string[] z = list.ToArray();
                int heure_deb = int.Parse(z[0]);
                int min_deb = int.Parse(z[1]);
                int heure_fin = int.Parse(z[2]);
                int min_fin = int.Parse(z[3]);

                DateTime dte = new DateTime(year, month, day, heure_deb, min_deb, 0);
                DateTime dts = new DateTime(year, month, day, heure_fin, min_fin, 0);

                DRow["start"] = dte;
                DRow["end"] = dts;
                DRow["DESIGNATION"] = "<CENTER>" + DRow["DESIGNATION"] + "<BR />" + DRow["NOM_ENS"] + "<BR />" + DRow["CODE_CL"] + "<BR />" + DRow["SALLE_PRINCIPALE"] + "<CENTER>";
               // DRow["DESIGNATION"] = DRow["DESIGNATION"] + "                                                                 " + DRow["NOM_ENS"] + "                                                  " + DRow["SALLE_PRINCIPALE"] + "                                          " + DRow["CODE_CL"];
            
            }
            return dt;
        }
     

        private static DateTime firstDayOfWeek(DateTime day, DayOfWeek weekStarts)
        {
            DateTime d = day;
            while (d.DayOfWeek != weekStarts)
            {
                d = d.AddDays(-1);
            }

            return d;
        }

        private void setWeek()
        {

        }

        private void deleteAndBind(string id)
        {

            #region Simulation of database update

            DataRow dr = table.Rows.Find(id);
            if (dr != null)
            {
                table.Rows.Remove(dr);
                table.AcceptChanges();
            }

            #endregion

            DayPilotCalendar1.DataBind();
            // DayPilotCalendar1.Update();

        }

        //public void BindEnseignants()
        //{

        //    ddlnomenseig.DataTextField = "NOM_ENS";
        //    ddlnomenseig.DataValueField = "ID_ENS";
        //    ddlnomenseig.DataSource = calendrier.getEns();
        //    ddlnomenseig.DataBind();
           
        //}

        private void fillcodeClasse()
        {
            DdlPromotion.DataTextField = "CODE_CL";
            DdlPromotion.DataValueField = "CODE_CL";
            DdlPromotion.DataSource = calendrier.BindClasspe();
            DdlPromotion.DataBind();
        }

        //protected void ddlnomenseig_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
        //    if (ddlnomenseig.SelectedValue != null)
        //    {
        //        DayPilotCalendar1.DataSource = getDataCalendarbyidens(ddlnomenseig.SelectedValue);
        //        DataBind();
        //    }
        //}

        protected void btnOK_Click1(object sender, ImageClickEventArgs e)
        {
            DayPilotCalendar1.DataSource = getDataCalendarbyidens(null);
            DataBind();
        }

        protected void DdlPromotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
            if (DdlPromotion.SelectedValue != null)
            {
                lblcodeclasss.Visible = true;
                lblempcl.Text = "EMPLOI DU TEMPS POUR LA CLASSE DE";
                lblcodeclasss.Text = DdlPromotion.SelectedValue;
                lblcodeclasss.ForeColor = System.Drawing.Color.MediumBlue;
                DayPilotCalendar1.DataSource = getDataCalendarbycodecl(DdlPromotion.SelectedValue);
                DataBind();
            }
        }

        protected void btnExPoRtToPDF_Click(object sender, EventArgs e)
        {
           ExportToPdf();
           // ExportToPng();
        }


        private void ExportToPdf()
        {
            // create a new PDF document
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "DayPilot Calendar PDF Export";
            doc.Info.Author = "DayPilot";

            // add a page
            PdfPage page = doc.AddPage();

            // set PDF page properties (size and orientation)
            //*****page.Size = (PageSize)Enum.Parse(typeof(PageSize), ListPageSize.SelectedValue);
            //*****page.Orientation = (PageOrientation)Enum.Parse(typeof(PageOrientation), ListPageOrientation.SelectedValue);

            // create graphics object for PDF page modification
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // write title
            XRect titleRect = new XRect(new XPoint(), gfx.PageSize);
            titleRect.Inflate(-10, -15);
            XFont font = new XFont("Tahoma", 14, XFontStyle.Bold);
            gfx.DrawString("Emploi du temp de la semaine de:" + lbldatedebut.Text +" "+ "à"+" " + lbldatefin.Text + "  " + "--" + lblcodeclasss.Text + "--", font, XBrushes.DarkGray, titleRect, XStringFormats.TopCenter);

            // create Scheduler image
            SetDataSourceAndBind();
            SetExportProperties();
            Bitmap bitmap = DayPilotCalendar1.ExportBitmap();

            // add the image to the PDF page
            XImage image = XImage.FromGdiPlusImage(bitmap);
            XRect imageRect = GetPaddedRectForImage(gfx, image, 10);
            double y = 40;
            imageRect.Y = y;
            gfx.DrawImage(image, imageRect);

            // save the PDF file to MemoryStream
            MemoryStream mem = new MemoryStream();
            doc.Save(mem, false);

            // send the output stream to the browser
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Emploi_du_temps_2017.pdf");
            mem.WriteTo(Response.OutputStream);
            Response.End();
        }

        private void SetDataSourceAndBind()
        {
            DayPilotCalendar1.DataSource = getDataCalendarbycodecl(DdlPromotion.Text);
            DataBind();
            DayPilotCalendar1.DataStartField = "start";
            DayPilotCalendar1.DataEndField = "end";
            DayPilotCalendar1.DataIdField = "DESIGNATION";
            DayPilotCalendar1.DataTextField = "DESIGNATION";
            //DayPilotCalendar1.DataBind();

        }

        private void SetExportProperties()
        {
            //DayPilotCalendar1.Width = Unit.Percentage(100);
            //DayPilotCalendar1.HeightSpec = HeightSpecEnum.Full;

            // match the theme

            DayPilotCalendar1.HourNameBackColor = ColorTranslator.FromHtml("#eee");
            DayPilotCalendar1.BackColor = Color.White;
            DayPilotCalendar1.NonBusinessBackColor = Color.White;
            DayPilotCalendar1.BorderColor = ColorTranslator.FromHtml("#999");
            DayPilotCalendar1.HeaderFontColor = ColorTranslator.FromHtml("#ea2712");
            DayPilotCalendar1.CellBorderColor = ColorTranslator.FromHtml("#eee");
            DayPilotCalendar1.EventFontColor = ColorTranslator.FromHtml("#030303");
            DayPilotCalendar1.EventCorners = CornerShape.Rounded;
            DayPilotCalendar1.EventFontSize = "10pt";
            DayPilotCalendar1.EventBorderColor = ColorTranslator.FromHtml("#999");
            DayPilotCalendar1.EventBackColor = ColorTranslator.FromHtml("#e01919");
            DayPilotCalendar1.HourBorderColor = ColorTranslator.FromHtml("#eee");
            DayPilotCalendar1.HourHalfBorderColor = ColorTranslator.FromHtml("#eee");
            DayPilotCalendar1.DurationBarVisible = true;

        }
        private XRect GetPaddedRectForImage(XGraphics gfx, XImage image, int paddingWidthPct)
        {
            double ratio = image.PixelWidth / (double)image.PixelHeight;
            double width = gfx.PageSize.Width;
            double height = width / ratio;

            XRect imageRect = new XRect(0, 0, width, height);
            imageRect.Scale((100 - paddingWidthPct) / 100.0, (100 - paddingWidthPct) / 100.0);

            double x = (gfx.PageSize.Width - imageRect.Width) / 2;
            imageRect.X = x;

            return imageRect;
        }

        private Hashtable Getholiday() 
 {
     Hashtable holiday = new Hashtable();
     holiday["9/5/2013"] = "Mudirin Ad gunu";
     holiday["9/7/2013"] = "Dostumun Ad gunu";
     holiday["10/28/2013"] = "Tetil";
    return holiday;
 }


        protected void DayPilotCalendar1_OnBeforeEventRender(object sender, BeforeEventRenderEventArgs e)
        {
            //string color = e.DataItem["color"] as string;
            //if (!String.IsNullOrEmpty(color))
            //{
            //    e.DurationBarColor = "Red";
            //}
        }
        private void ExportToPng()
        {

            SetDataSourceAndBind();
            SetExportProperties();

            Response.Clear();
            Response.ContentType = "image/png";
            Response.AddHeader("content-disposition", "attachment;filename=print.png");
            MemoryStream img = DayPilotCalendar1.Export(ImageFormat.Png);
            img.WriteTo(Response.OutputStream);
            Response.End();
        }

       

 }
}


