using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI.GridExcelBuilder;
using Telerik.Web.UI;
using System.Net;

namespace ESPOnline.Direction
{
    public partial class Transfert_etud2019 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }





        protected void RadButton1_Click(object sender, EventArgs e)
        {
            var userHost = System.Net.Dns.GetHostName();

            var userIp = Dns.GetHostEntry(userHost).AddressList[0].ToString();

            foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("CheckBox1");
                if (chk.Checked == true)
                {

                    string ID = item.GetDataKeyValue("ID_ET").ToString();
                    DAL.Admission.Instance.transfer_to_etudiant_ENREG(ID);
                    DAL.Admission.Instance.transfer_to_etudiant(ID);
                    DAL.Admission.Instance.add_journal_RACHAT(ID, userIp);
                    string pwd = item["NUM_CIN_PASSEPORT"].Text;
                    string NOM = item["NOM"].Text;
                    string PNOM = "";




                }

            }

            //try
            //{
            //foreach(GridDataItem dataitem in RadGrid1.Items)
            //{
            //    string idi =dataitem["ID_ET"].Text;
            //    string pwd = "";
            //    string NOM="";
            //    string PNOM = "";
            //    string body = this.PopulateBody(idi, pwd, NOM, PNOM);
            //    this.SendHtmlFormattedEmail(dataitem["E_MAIL_ET"].Text, "ESPRIT", body);

            //}






            // }
            //catch (Exception ex)
            //{


            //}
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            RadGrid1.DataSource = DAL.Admission.Instance.getinfoetranger();


        }
        protected void grid1(object sender, GridItemEventArgs e)
        {
            foreach (TableCell cell in e.Item.Cells)
            {

                cell.Attributes.CssStyle["text-align"] = "center";

            }
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = (GridDataItem)e.Item;
                TableCell myCell = dataItem["NATURE_BAC"];
                TableCell myCell2 = dataItem["SPECIALITE_ESP_ET"];
                if (myCell2.Text == "INFO")
                {
                    // myCell2.Text = "INFO";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Red;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "06")
                {
                    myCell2.Text = "Licence en Sciences de Gestion";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.IndianRed;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "07")
                {
                    myCell2.Text = "Licence en Informatique de Gestion";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Chocolate;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "08")
                {
                    myCell2.Text = "Master en Management	Digital	et Systèmes d’Information";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Pink;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "09")
                {
                    myCell2.Text = "Master en Marketing Digital";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.BlueViolet;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "10")
                {
                    myCell2.Text = "Master en Innovation	& Entrepreneuriat";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Brown;
                    dataItem.Font.Bold = true;
                }

                if (myCell2.Text == "03")
                {
                    myCell2.Text = "GC";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Green;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "04")
                {
                    myCell2.Text = "EM";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Black;
                    dataItem.Font.Bold = true;
                }
                if (myCell2.Text == "02")
                {
                    myCell2.Text = "TELECOM";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell2.ForeColor = System.Drawing.Color.Black;
                    dataItem.Font.Bold = true;
                }
                if ((myCell.Text == "INFO"))
                {
                    //  myCell.Text = "INFO";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.HotPink;
                    dataItem.Font.Bold = true;
                }
                if ((myCell.Text == "MATH"))
                {
                    //  myCell.Text = "Math";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.Red;
                    dataItem.Font.Bold = true;
                } if ((myCell.Text == "SC EXP"))
                {
                    //  myCell.Text = "Sc Exp";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.Green;
                    dataItem.Font.Bold = true;
                }
                if ((myCell.Text == "ECONOMIE"))
                {
                    // myCell.Text = "Economie";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.Black;
                    dataItem.Font.Bold = true;


                }
                if ((myCell.Text == "TECHNIQUE"))
                {
                    //  myCell.Text = "Tech";
                    //dataItem.BackColor = System.Drawing.Color.Red;  
                    myCell.ForeColor = System.Drawing.Color.Blue;
                    dataItem.Font.Bold = true;


                }
            }

        }

        protected void grvMergeHeader_RowCreated(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.Header)
            {


                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();

                //HeaderCell.Text = " ";
                //HeaderCell.ColumnSpan = 3;

                //HeaderCell.BackColor = System.Drawing.Color.White;
                //HeaderGridRow.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Soutien Scolaire";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 3;
                //HeaderCell.BackColor = System.Drawing.Color.FromName("#d3003f");

                //HeaderGridRow.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Clubs";
                //HeaderCell.BackColor = System.Drawing.Color.FromName("#A8A8A8");
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.ColumnSpan = 14;
                //HeaderGridRow.Cells.Add(HeaderCell);
                //RadGrid1.Controls[0].Controls.AddAt(0, HeaderGridRow);
                RadGrid1.Columns[3].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ae002e");
                RadGrid1.Columns[4].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ae002e");
                RadGrid1.Columns[5].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ae002e");
                RadGrid1.Columns[6].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[7].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[8].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[9].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[10].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ff00");
                RadGrid1.Columns[11].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[12].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[13].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[14].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[15].HeaderStyle.BackColor = System.Drawing.Color.FromName("#00ffff");
                RadGrid1.Columns[16].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ffcc99");
                RadGrid1.Columns[17].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ffcc99");
                RadGrid1.Columns[18].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ffcc99");
                RadGrid1.Columns[19].HeaderStyle.BackColor = System.Drawing.Color.FromName("#ffcc99");
            }
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

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((sender as CheckBox).NamingContainer as GridItem).Selected = (sender as CheckBox).Checked;
            bool checkHeader = true;
            foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
            {
                if (!(dataItem.FindControl("CheckBox1") as CheckBox).Checked)
                {
                    checkHeader = false;
                    break;
                }
            }
            GridHeaderItem headerItem = RadGrid1.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            // (headerItem.FindControl("headerChkbox") as CheckBox).Checked = checkHeader;
        }
        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (sender as CheckBox);
            foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
            {
                (dataItem.FindControl("CheckBox1") as CheckBox).Checked = headerCheckBox.Checked;
                dataItem.Selected = headerCheckBox.Checked;
            }
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
            {
                (dataItem.FindControl("CheckBox1") as CheckBox).Checked = false;
            }
        }
    }
}
