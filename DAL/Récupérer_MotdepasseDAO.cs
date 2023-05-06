using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using admiss;
using System.Data;

namespace DAL
{
  public  class Récupérer_MotdepasseDAO
    {
        #region sing

        static Récupérer_MotdepasseDAO instance;
        static Object locker = new Object();
        
        public static Récupérer_MotdepasseDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Récupérer_MotdepasseDAO();
                    }

                    return Récupérer_MotdepasseDAO.instance;
                }
            }

        }
        private Récupérer_MotdepasseDAO() { }

        #endregion
          OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString);
        OracleTransaction myTrans;

        public void openconntrans()
        {
            mySqlConnection.Open();
            myTrans = mySqlConnection.BeginTransaction();

        }

        public void commicttrans()
        {
            myTrans.Commit();
        }

        public void rollbucktrans()
        {
            myTrans.Rollback();
        }
        public void closeConnection()
        {

            mySqlConnection.Close();
     


        }

     
        public string GET_PASSWORD(string _id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "select FS_CRYPT_DECRYPT(pwd_et) from esp_etudiant where id_et='" + _id_et + "' and ETAT='A'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }
        public string GET_ADRESSE_MAIL(string _id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "select trim(lower(ADRESSE_MAIL_ESP)) from esp_etudiant where id_et='" + _id_et + "' and ETAT='A'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string GET_ADRESSE_MAIL_parent(string _id_et)
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "select E_MAIL_PARENT from esp_etudiant where id_et='" + _id_et + "' and ETAT='A'";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

    }
}
