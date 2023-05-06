using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.images.Finance
{
    public partial class Reçu_valide : System.Web.UI.Page
       
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            DropDownList1.Items.Clear(); 
            DropDownList1.Items.Insert(0, new ListItem(drop1.SelectedValue.ToString(), drop1.SelectedValue.ToString()));

            if (Session["ID_DECID"] == null)
            {
                Response.Redirect("~/Online/default.aspx");
            }
            if (!IsPostBack)
            {
                

             //  DropDownList2.Items.Insert(0, new ListItem("Select année", ""));
                //updated code
                //using (OracleConnection con = new OracleConnection(AppConfiguration.ConnectionString))
                //{
                //    con.Open();

                //    OracleCommand cmd = new OracleCommand("SELECT distinct ID FROM APHOTOS ");

                //    cmd.Connection = con;
                //    OracleDataReader _dr = cmd.ExecuteReader();
                //    while (_dr.Read())
                //    {
                //        DropDownList1.Items.Add(_dr.GetString(0));
                //    }
                    
                //    _dr.Close();
                //    con.Close();
                //}
            }
        }
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.tt);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
        protected void tt(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            DropDownList1.DataTextField = "tt"; DropDownList1.DataValueField = "ID_ET"; 

                  Page.DataBind();




        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            if (DropDownList2.SelectedValue == "16")
            {
                drop1.DataSource = SqlDataSource1;
                drop1.DataBind();
                DropDownList1.Items.Clear();
                DropDownList1.Items.Insert(0, new ListItem(drop1.SelectedValue.ToString(), drop1.SelectedValue.ToString()));
                // DropDownList1.SelectedValue = DropDownList1.Items.FindByText(drop1.SelectedValue.ToString()).Value;
               
                Page.DataBind();
              
            }
            else {
                drop1.DataSource = SqlDataSource2;
                drop1.DataBind();
                DropDownList1.Items.Clear();
                DropDownList1.Items.Insert(0, new ListItem(drop1.SelectedValue.ToString(), drop1.SelectedValue.ToString()));
                // DropDownList1.SelectedValue = DropDownList1.Items.FindByText(drop1.SelectedValue.ToString()).Value;
               
                Page.DataBind();
              
               
            
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            Page.DataBind();
            Panel1.Visible = true;

        }
    }
}