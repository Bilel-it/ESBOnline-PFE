using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

using System.Data;

namespace ESPSuiviEncadrement
{
    public class Entreprise
    {
        #region sing

        static Entreprise instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Entreprise Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Entreprise();
                    }

                    return Entreprise.instance;
                }
            }

        }
        private Entreprise() { }

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
        private decimal _NUM_SEMESTRE_ACTUEL;
        private string _ANNEE_FIN;
        private string _ANNEE_DEB;
        //private  _DATE_DEBUT_SAISON;

        public decimal NUM_SEMESTRE_ACTUEL
        {
            get { return _NUM_SEMESTRE_ACTUEL; }
            set { _NUM_SEMESTRE_ACTUEL = value; }
        }
        public string ANNEE_FIN
        {
            get { return _ANNEE_FIN; }
            set { _ANNEE_FIN = value; }
        }

        public string ANNEE_DEB
        {
            get { return _ANNEE_DEB; }
            set { _ANNEE_DEB = value; }
        }

        public decimal getNumSemestre()
        {
            decimal x;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT  NUM_SEMESTRE_ACTUEL FROM SOCIETE";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        x = 1;
                    }
                    else
                    {
                        x = 0;
                    }

                }
                mySqlConnection.Close();
            }
            return x;
        }

        public string getAnneeDeb()
        {
            string x;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT ANNEE_DEB FROM SOCIETE";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        x = myReader["ANNEE_DEB"].ToString();
                       
                    }
                    else
                    {
                        x = "0";
                    }

                }
                mySqlConnection.Close();
            }
            return x;
        }


    }
}
