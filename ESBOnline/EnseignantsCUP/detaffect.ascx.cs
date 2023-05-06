using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DAL;
using System.Configuration;
using Oracle.ManagedDataAccess.Types;
using BLL;
using Oracle.ManagedDataAccess.Client;
using ABSEsprit;
 
using System.IO;

namespace ESPOnline.EnseignantsCUP
{
    public partial class detaffect : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        protected void Page_Load(object sender, EventArgs e)
        {

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