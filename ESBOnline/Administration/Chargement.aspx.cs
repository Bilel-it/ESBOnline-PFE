using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data.OracleClient;
using Oracle.ManagedDataAccess;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace ESPOnline.Administration
{
    public partial class Chargement : System.Web.UI.Page
    {
        string mannee;
        List<string> number = new List<string>();

        List<string> listh = new List<string>();
        COMPT_CERT certcomp = new COMPT_CERT();
        List<COMPT_CERT> ListCERT = new List<COMPT_CERT>();

        COMPT_CERTSERVICES cmpservice = new COMPT_CERTSERVICES();

        protected void Page_Load(object sender, EventArgs e)
        {
             

            if (Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            mannee = "/" + DropDownList2.SelectedValue.ToString() + "/" + DropDownList3.SelectedValue.ToString();
          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Label2.Text = "/" + DropDownList2.SelectedValue.ToString() + "/" + DropDownList3.SelectedValue.ToString();
        }

        protected void Calendar1_PreRender(object sender, EventArgs e)
        {

            Calendar1.SelectedDates.Clear();

            foreach (DateTime dt in MultipleSelectedDates)
            {
                Calendar1.SelectedDates.Add(dt);
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            if (MultipleSelectedDates.Contains(Calendar1.SelectedDate))
            {
                MultipleSelectedDates.Remove(Calendar1.SelectedDate);
            }
            else
            {
                MultipleSelectedDates.Add(Calendar1.SelectedDate);
            }

            ViewState["MultipleSelectedDates"] = MultipleSelectedDates;
        }


        public List<DateTime> MultipleSelectedDates
        {
            get
            {
                if (ViewState["MultipleSelectedDates"] == null)

                    ViewState["MultipleSelectedDates"] = new List<DateTime>();
                return (List<DateTime>)ViewState["MultipleSelectedDates"];
            }
            set
            {
                ViewState["MultipleSelectedDates"] = value;
            }
        }


        protected void btnGetSelectedDate_Click(object sender, EventArgs e)
        {

            foreach (DateTime dt in MultipleSelectedDates)
            {

                lblDate.Text = lblDate.Text + " <br/> " + dt.ToString("dd/MM/yyyy").Substring(0, 2);

                // Label1.Text = DateTime.Today.Day.ToString();




                number.Add(dt.ToString("dd/MM/yyyy").Substring(0, 2));


            }
            DropDownList1.DataSource = number;
            DropDownList1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<string> test1 = new List<string>();
            listh.Add("09:00");
            listh.Add("11:00");
            listh.Add("13:30");
            listh.Add("15:30");
            //certcomp.HEURE = "11";
            //certcomp.DATE_CERT =DateTime.Today;
            //cmpservice.ajouterESP_COMPT_CERT(certcomp);

            foreach (DateTime dt in MultipleSelectedDates)
            {

                //lblDate.Text = lblDate.Text + " <br/> " + dt.ToString("dd/MM/yyyy").Substring(0, 2);

                // Label1.Text = DateTime.Today.Day.ToString();




                number.Add(dt.ToString("dd/MM/yyyy").Substring(0, 2));


            }


            foreach (string va in number)
            {
                //foreach (string hr  in listh)
                for (int hr = 1; hr <= listh.Count; hr++)
                {
                    COMPT_CERT certcomp1 = new COMPT_CERT();
                    certcomp1.HEURE = hr.ToString();


                    certcomp1.DATE_CERT = DateTime.Parse(va + mannee);


                    ListCERT.Add(certcomp1);



                }
            }

            foreach (COMPT_CERT b in ListCERT)
            {
                cmpservice.ajouterESP_COMPT_CERT(b);
                lblDate.Text = lblDate.Text + " <br/> " + b.DATE_CERT.ToString() + " *Heure* " + b.HEURE + "*Compteur*";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

      
        protected void Button3_Click1(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

 

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click2(object sender, EventArgs e)
        {
     
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalModifier();", true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
       

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalModifier();", true);
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            int columnsCount = GridView3.HeaderRow.Cells.Count;
            // Create the PDF Table specifying the number of columns
            PdfPTable pdfTable = new PdfPTable(columnsCount);

            // Loop thru each cell in GrdiView header row
            foreach (TableCell gridViewHeaderCell in GridView3.HeaderRow.Cells)
            {
                // Create the Font Object for PDF document
                Font font = new Font();
                // Set the font color to GridView header row font color
                font.Color = new BaseColor(GridView3.HeaderStyle.ForeColor);

                // Create the PDF cell, specifying the text and font
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                pdfCell.BackgroundColor = new BaseColor(GridView3.HeaderStyle.BackColor);

                // Add the cell to PDF table
                pdfTable.AddCell(pdfCell);
            }

            // Loop thru each datarow in GrdiView
            foreach (GridViewRow gridViewRow in GridView3.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    // Loop thru each cell in GrdiView data row
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(GridView3.RowStyle.ForeColor);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfCell.BackgroundColor = new BaseColor(GridView3.RowStyle.BackColor);

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }
            // Create the PDF document specifying page size and margins
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
                  Response.ContentType = "application/pdf";
    Response.AppendHeader("content-disposition",
        "attachment;filename=List Etudiant.pdf");
    Response.Write(pdfDocument);
    Response.Flush();
    Response.End();
        }

    
    }
}