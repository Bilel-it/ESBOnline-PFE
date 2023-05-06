using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.OracleClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace ESPSuiviEncadrement
{
    public class Log
    {
        #region sing

        static Log instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Log Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Log();
                    }

                    return Log.instance;
                }
            }

        }
        private Log() { }

        #endregion


        public bool loginx(string _ID_ET)
        {
            bool exist = false;


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_SEMINAIRE WHERE  ID_ET ='" + _ID_ET + "'";


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


        public string login(string _ID_ENS, string _PWD_ENS)
        {
            bool exist = false;
            string Name = "x";


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_ENSEIGNANT WHERE  ID_ENS ='" + _ID_ENS + "'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();

                    if (MyReader["PWD_ENS"].ToString() == _PWD_ENS)/*Name.Equals(username)*/
                    {
                         Name = MyReader["TYPE_UP"].ToString();


                        break;
                    }
                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }


        }


        public string logiCUP(string _ID_ENS)
        {
            bool exist = false;
            string Name = "x";


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_ENSEIGNANT WHERE  ID_ENS ='" + _ID_ENS + "'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();

                   
                        Name = MyReader["UP"].ToString();


                        break;
                    
                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }



        }
        public string loginomCUP(string _ID_ENS)
        {
            bool exist = false;
            string Name = "x";


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_ENSEIGNANT WHERE  ID_ENS ='" + _ID_ENS + "'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    Name = MyReader["NOM_ENS"].ToString();


                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return Name;
            }



        }

    }
}