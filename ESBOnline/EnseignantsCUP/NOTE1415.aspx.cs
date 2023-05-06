using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Telerik.Web.UI.GridExcelBuilder;
using ABSEsprit;


namespace ESPOnline.EnseignantsCUP
{
    public partial class NOTE1415 : System.Web.UI.Page
    {
        public string ID_ENS;
        public string idcl;
        public string idmodule;

        public OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString);
        OracleTransaction myTrans;

        public void openconntrans()
        {
            mySqlConnection.Open();
            myTrans = mySqlConnection.BeginTransaction();

        }
        public string cmdQuery;
        public void commicttrans()
        {
            myTrans.Commit();
        }

        public void rollbucktrans()
        {
            myTrans.Rollback();
        }
        public void closeConnection()
        {

            mySqlConnection.Close();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UP"] == null || Session["ID_ENS"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }

            ID_ENS = Session["ID_ENS"].ToString();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedIndexes.Count == 0)
                RadGrid1.SelectedIndexes.Add(0);
            //if (RadGrid2.SelectedIndexes.Count == 0)
            //    RadGrid2.SelectedIndexes.Add(0);
            //if (RadGrid3.SelectedIndexes.Count == 0)
            //    RadGrid3.SelectedIndexes.Add(0);

        }
        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            string alternateText = (sender as ImageButton).AlternateText;
            RadGrid3.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), alternateText);
            RadGrid3.ExportSettings.IgnorePaging = true;
            RadGrid3.ExportSettings.ExportOnlyData = true;
            RadGrid3.ExportSettings.OpenInNewWindow = true;
            RadGrid3.MasterTableView.ExportToExcel();
        }
        protected void RadGrid3_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            foreach (GridDataItem item in RadGrid2.SelectedItems)
            {
                idcl = item["CODE_CL"].Text;
                idmodule = item["CODE_MODULE"].Text;

            }


            (sender as RadGrid).DataSource = GetDataTable1(idcl, idmodule);


        }
        protected void test(object sender, EventArgs e)
        {
            foreach (GridDataItem item in RadGrid2.SelectedItems)
            {
                idcl = item["CODE_CL"].Text;
                idmodule = item["CODE_MODULE"].Text;

            }
            ImageButton2.Visible = true;
            RadGrid3.Visible = true;
            RadGrid3.DataSource = GetDataTable1(idcl, idmodule);
            RadGrid3.DataBind();

        }
        protected void test2(object sender, EventArgs e)
        {

            ImageButton2.Visible = false;
            RadGrid3.Visible = false;


        }
        public DataTable GetDataTable1(string t, string p)
        {



            openconntrans();


            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = new OracleCommand("  select nom_et,pnom_et,note_cc,note_tp,note_exam from ESP_V_NOTE_ENS where code_cl='" + t + "' and code_module='" + p + "'", mySqlConnection);
            DataTable myDataTable = new DataTable();


            try
            {
                adapter.Fill(myDataTable);

            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataTable;
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