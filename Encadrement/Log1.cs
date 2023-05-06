using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using ESPSuiviEncadrement;

namespace Evaluation
{
    public class Log1
    {
        #region sing

        static Log1 instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Log1 Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Log1();
                    }

                    return Log1.instance;
                }
            }

        }
        private Log1() { }

        #endregion

        public bool login(string _ID_ET,string _NUM_CIN_PASSEPORT)
        {
            bool exist = false;


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_ETUDIANT WHERE  ID_ET ='" + _ID_ET + "'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();

                    if (MyReader["NUM_CIN_PASSEPORT"].ToString() == _NUM_CIN_PASSEPORT)/*Name.Equals(username)*/
                    {
                        exist = true;


                        break;
                    }
                }
                MyReader.Close();
                mySqlConnection.Close();
                return exist;
            }


        }

        public bool login(string _ID_ET)
        {
            bool exist = false;


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_ETUDIANT WHERE  ID_ET ='" + _ID_ET + "'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    exist = true;


                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return exist;
            }
        }
    }
}