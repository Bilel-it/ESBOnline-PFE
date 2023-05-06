using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace ESPOnline.EnseignantsCUP
{
    public partial class Encadrementdet : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            RadioButtonList2.Items[0].Attributes.CssStyle.Add("visibility", "hidden");
            RadioButtonList1.Items[0].Attributes.CssStyle.Add("visibility", "hidden");
            RadioButtonList3.Items[0].Attributes.CssStyle.Add("visibility", "hidden");


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