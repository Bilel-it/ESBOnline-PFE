using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.ComponentModel;

namespace ESPSuiviEncadrement
{
    public class recherchePROF
    {
        #region sing
        static recherchePROF instance;
        static Object locker = new Object();
        public static recherchePROF Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new recherchePROF();
                    }

                    return recherchePROF.instance;
                }
            }

        }
        private recherchePROF() { }
        #endregion sing
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

        #region public private methodes

        

        private string _ID_ENS;
        private string _NOM_ENS;

        

        public string ID_ENS
        {
            get { return _ID_ENS; }
            set { _ID_ENS = value; }

        }
        public string NOM_ENS
        {
            get { return _NOM_ENS; }
            set { _NOM_ENS = value; }

        }
        
        #endregion

        public recherchePROF(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ENS")))
            {
                _NOM_ENS = myReader.GetString(myReader.GetOrdinal("NOM_ENS"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ENS")))
            {
                _ID_ENS = myReader.GetString(myReader.GetOrdinal("ID_ENS"));

            }

        }






        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<recherchePROF> GETAllEnseignant()
        {
            List<recherchePROF> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT * FROM ESP_ENSEIGNANT";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<recherchePROF>();
                        while (myReader.Read())
                        {
                            myList.Add(new recherchePROF(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }

    }
}
