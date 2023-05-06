using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BLL;

namespace ESPOnline.EmploiEsp
{
    public partial class bind_DATA_IN8ATABLE : System.Web.UI.Page
    {
        ServiceEDT service = new ServiceEDT();
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeaterData();
            }
        }
        // This button click event is used to insert comment details and bind data to repeater control
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            service.posteddate(txtName.Text, txtSubject.Text, txtComment.Text);
            txtName.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtComment.Text = string.Empty;
            BindRepeaterData();
        }
        //Bind Data to Repeater Control
        protected void BindRepeaterData()
        {
            service.Bindrep();
        }
    }
}