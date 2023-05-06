using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI.GridExcelBuilder;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI;

namespace ESPOnline.EnseignantsCUP
{
    public partial class ExportTOExcel : System.Web.UI.Page
    {
        string x;
        string y;
        string z;
     
        public string anneedeb;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            x = Session["UP"].ToString().Trim();
            y = Session["Nom_ENS"].ToString().Trim();
            z = Session["ID_ENS"].ToString().Trim();
            anneedeb = DAL.AffectationDAO.Instance.getanneedeb();

             GridFilterMenu menu = RadGrid1.FilterMenu;
            int i = 0; 
                    while (i < menu.Items.Count) 
                    { 
                        if (menu.Items[i].Text == "NoFilter" ||  
                            menu.Items[i].Text == "Contains" || 
                            menu.Items[i].Text == "EqualTo" || 
                            menu.Items[i].Text == "GreatherThan"  
                           ) 
                        { 
                            i++; 
                        } 
                        else 
                        { 
                            menu.Items.RemoveAt(i);
                        }
                    } 
    foreach (RadMenuItem item in menu.Items)
    {   if (item.Text == "Contains")
        {
            item.Text = "Contient";
        }
    if (item.Text == "DoesNotContain")
    {
        item.Text = "NeContientpPas";
    } 
        if (item.Text == "EndsWith")
        {
            item.Text = "SETerminePar";
        } if (item.Text == "EqualTo")
        {
            item.Text = "EgalA";
        }
        if (item.Text == "NotEqualTo")
        {
            item.Text = "NonEgalA";
        }
    }

        }
        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridFilteringItem)
            {
                GridFilteringItem filteringItem = e.Item as GridFilteringItem;
                //set dimensions for the filter textbox  
                TextBox box = filteringItem["CODE_CL"].Controls[0] as TextBox;
                box.Height                    = Unit.Pixel(30);
                TextBox box2 = filteringItem["CODE_MODULE"].Controls[0] as TextBox;
                box2.Height                    = Unit.Pixel(30);
                
                TextBox box3 = filteringItem["ENS1"].Controls[0] as TextBox;
                box3.Height            = Unit.Pixel(30);
                
                    TextBox box4 = filteringItem["DESIGNATION"].Controls[0] as TextBox;
                box4.Height                  = Unit.Pixel(30);
                    
                        TextBox box5 = filteringItem["NB_HEURES"].Controls[0] as TextBox;
                box5.Height                    = Unit.Pixel(30);
                    
                        TextBox box6 = filteringItem["CHARGE_P1"].Controls[0] as TextBox;
                box6.Height                   = Unit.Pixel(30);
                        
                            TextBox box7 = filteringItem["CHARGE_P2"].Controls[0] as TextBox;
                box7.Height                   = Unit.Pixel(30);
                        
                            TextBox box8 = filteringItem["CHARGE_ENS1_P1"].Controls[0] as TextBox;
                box8.Height                    = Unit.Pixel(30);

                TextBox box9 = filteringItem["CHARGE_ENS1_P2"].Controls[0] as TextBox;
                box9.Height                   = Unit.Pixel(30);
            }
        }
        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            string alternateText = (sender as ImageButton).AlternateText;
            RadGrid1.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;
            RadGrid1.MasterTableView.ExportToExcel();
        }
        protected void RadGrid1_ExcelMLWorkBookCreated(object sender, GridExcelMLWorkBookCreatedEventArgs e)
        {
            
                foreach (RowElement row in e.WorkBook.Worksheets[0].Table.Rows)
                {
                    row.Cells[0].StyleValue = "Style1";
                }
               
                StyleElement style = new StyleElement("Style1");
                style.InteriorStyle.Pattern = InteriorPatternType.Solid;
                style.InteriorStyle.Color = System.Drawing.Color.LightGray;
                e.WorkBook.Styles.Add(style);
            }
        
    }
}