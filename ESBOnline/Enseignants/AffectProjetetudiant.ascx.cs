using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESPOnline.Enseignants
{
    public partial class AffectProjetetudiant : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        protected void Page_Load(object sender, EventArgs e)
        {

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