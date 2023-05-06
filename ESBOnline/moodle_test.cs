using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ESPOnline
{
     static class moodle_test
    {
        private static MySqlConnection cnx;

        public static MySqlConnection getconnection()
        {
            if (cnx == null)
            {
                cnx = new MySqlConnection("Server=172.16.20.15;UserID=esprit;Password=Esprit2022+;Database=moodle");
                cnx.Open();
            }
            return cnx;
        }
    }
}