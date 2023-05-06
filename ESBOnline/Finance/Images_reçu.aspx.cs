using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using Oracle.ManagedDataAccess.Types;

using Oracle.ManagedDataAccess.Client;

using ESPSuiviEncadrement;

namespace ESPOnline.images.Finance
{
    public partial class Images_reçu : System.Web.UI.Page
    {
           protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    CreateImage(Request["id"]);
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
                this.Load += new System.EventHandler(this.Page_Load);
            }
            #endregion
          

           
                void CreateImage(string id)
            {
                string id_et = Request["id"];
                if (id_et.StartsWith("16"))
                {
                    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
                    {
                        mySqlConnection.Open();

                        OracleCommand cmd = new OracleCommand("SELECT recu FROM esp_recu where id_et='" + Request["id"] + "' ");

                        cmd.Connection = mySqlConnection;
                        byte[] _buf = (byte[])cmd.ExecuteScalar();

                        // This is optional
                        Response.ContentType = "image/gif";

                        //stream it back in the HTTP response
                        Response.BinaryWrite(_buf);

                        mySqlConnection.Close();
                    }
                }
                else {

                    using (OracleConnection mySqlConnection = new OracleConnection("DATA SOURCE=192.168.0.225:1521/bdesp10N  ;PERSIST SECURITY INFO=True;USER ID=admis2;PASSWORD=tbzr10ep"))
                    {
                        mySqlConnection.Open();

                        OracleCommand cmd = new OracleCommand("SELECT recu FROM esp_recu where id_et='" + Request["id"] + "' ");

                        cmd.Connection = mySqlConnection;
                        byte[] _buf = (byte[])cmd.ExecuteScalar();

                        // This is optional
                        Response.ContentType = "image/gif";

                        //stream it back in the HTTP response
                        Response.BinaryWrite(_buf);

                        mySqlConnection.Close();
                    }
                }
            }
            }
        }
    
