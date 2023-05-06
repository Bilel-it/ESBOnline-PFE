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
    public class recherche
    {
        #region sing
        static recherche instance;
        static Object locker = new Object();
        public static recherche Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new recherche();
                    }

                    return recherche.instance;
                }
            }

        }
        private recherche() { }
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

        private string _ID_GROUPE_PROJET;
        private string _ID_ET;
        private decimal _NOTE_ET;

        private string _ID_ENS;
        private string _REMARQUE;

        private string _ABS_ET;
        private DateTime _DATE_EVAL;


      


        public string ID_GROUPE_PROJET
        {
            get { return _ID_GROUPE_PROJET; }
            set { _ID_GROUPE_PROJET = value; }

        }

        public string ID_ET
        {
            get { return _ID_ET; }
            set { _ID_ET = value; }

        }

        public decimal NOTE_ET
        {
            get { return _NOTE_ET; }
            set { _NOTE_ET = value; }

        }

        public string ID_ENS
        {
            get { return _ID_ENS; }
            set { _ID_ENS = value; }

        }
        public string REMARQUE
        {
            get { return _REMARQUE; }
            set { _REMARQUE = value; }

        }
        public string ABS_ET
        {
            get { return _ABS_ET; }
            set { _ABS_ET = value; }

        }

        public DateTime DATE_EVAL
        {
            get { return _DATE_EVAL; }
            set { _DATE_EVAL = value; }

        }
        #endregion

        public recherche(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_GROUPE_PROJET")))
            {
                _ID_GROUPE_PROJET = myReader.GetString(myReader.GetOrdinal("ID_GROUPE_PROJET"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ET")))
            {
                _ID_ET = myReader.GetString(myReader.GetOrdinal("ID_ET"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_ET")))
            {
                _NOTE_ET = myReader.GetDecimal(myReader.GetOrdinal("NOTE_ET"));

            }
      
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ENS")))
            {
                _ID_ENS = myReader.GetString(myReader.GetOrdinal("ID_ENS"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("REMARQUE")))
                    {
                        _REMARQUE = myReader.GetString(myReader.GetOrdinal("REMARQUE"));

                    }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ABS_ET")))
                    {
                        _ABS_ET = myReader.GetString(myReader.GetOrdinal("ABS_ET"));

                    }
            if (!myReader.IsDBNull(myReader.GetOrdinal("DATE_EVAL")))
                    {
                        _DATE_EVAL = myReader.GetDateTime(myReader.GetOrdinal("DATE_EVAL"));

                    }
        

        
        }






        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<recherche> GetResultatSuiviEtudiantParGroupe(string ID_PROJET,string id_et)
        {
            List<recherche> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_ETUDIANT_NOTE_GROUPE.* FROM ESP_ETUDIANT_NOTE_GROUPE WHERE (ID_GROUPE_PROJET='" + ID_PROJET + "') AND (ABS_ET IS NOT NULL) AND (ID_ET='" + id_et + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<recherche>();
                        while (myReader.Read())
                        {
                            myList.Add(new recherche(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }





        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<recherche> GetResultatSuiviEnseignantParGroupe(string id_ens)
        {
            List<recherche> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_ETUDIANT_NOTE_GROUPE.* FROM ESP_ETUDIANT_NOTE_GROUPE WHERE (ABS_ET IS NOT NULL) AND (ID_ENS='" + id_ens + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<recherche>();
                        while (myReader.Read())
                        {
                            myList.Add(new recherche(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }

    }
}
