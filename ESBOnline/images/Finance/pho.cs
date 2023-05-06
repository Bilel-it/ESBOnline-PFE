using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Image_blob
{
    public class pho
    {
          #region sing
        OracleConnection mySqlConnection = new OracleConnection("DATA SOURCE= ;PERSIST SECURITY INFO=True;USER ID=sco_admis1415;PASSWORD=sco_admis1415");
        OracleTransaction myTrans;

        public void openconntrans()
        {
            mySqlConnection.Open();
            myTrans = mySqlConnection.BeginTransaction();

        }
        public string cmdQuery;
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
        static pho instance;
        static Object locker = new Object();

        public static pho Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new pho();
                    }

                    return pho.instance;
                }
            }

        }
        private pho() { }

     

        #endregion

        public string Getemail(string _Id_et)
        {
            string mail = "";

            openconntrans();

            string cmdQuery = " SELECT E_MAIL_ET from esp_etudiant where id_et='" + _Id_et + "'  ";

            OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            mail = myCommand.ExecuteScalar().ToString();
            mySqlConnection.Close();

            return mail;

        }
        public string Getdossier(string _Id_et)
        {
            string mail = "";

            openconntrans();

            string cmdQuery = " SELECT date_dossir from esp_recu where id_et='" + _Id_et + "'  ";

            OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            mail = myCommand.ExecuteScalar().ToString();
            mySqlConnection.Close();

            return mail;

        }
        public bool update_etat(string idet)
        {
            bool result = false;
            openconntrans();
            string cmdQuery = " UPDATE esp_recu set etat='V' where id_et='" + idet + "'  ";
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;
            try
            {
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }
            mySqlConnection.Close();
            return result;
        }
    }
}