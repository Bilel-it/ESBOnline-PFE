using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ESPSuiviEncadrement
{
    public class AppConfiguration
    {
        public static String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            }
        }

    }
}