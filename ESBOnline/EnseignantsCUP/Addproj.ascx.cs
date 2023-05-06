using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.EnseignantsCUP
{
    public partial class Addproj : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }
        private void InitializeComponent()
        {
            // this.DataBinding += new System.EventHandler(this.EmployeeDetails_DataBinding);


        }

        public object DataItem
        {
            get
            {
                return this._dataItem;
            }
            set
            {
                this._dataItem = value;
            }
        }

    }
}