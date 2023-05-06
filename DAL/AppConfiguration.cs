using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace admiss
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
        public static String ConnectionString2
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnectionString2"].ConnectionString;
            }
        }

        public static String ConnectionString5
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString5"].ConnectionString;
            }
        }
        //
        public static String myConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            }
        }
        //
        public static String ConnectionStringsolde
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["maha"].ConnectionString;
            }
        }
    }
}