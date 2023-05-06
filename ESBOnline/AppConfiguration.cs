using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ABSEsprit
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
        public static String ConnectionString1
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnectionString1"].ConnectionString;
            }
        }
        public static String ConnectionString2
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnectionString2"].ConnectionString;
            }
        }
    }
}