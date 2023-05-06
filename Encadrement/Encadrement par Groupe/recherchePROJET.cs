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
    public class recherchePROJET
    {
        #region sing
        static recherchePROJET instance;
        static Object locker = new Object();
        public static recherchePROJET Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new recherchePROJET();
                    }

                    return recherchePROJET.instance;
                }
            }

        }
        private recherchePROJET() { }
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


        private string _ID_PROJET;
        private string _ID_GROUPE_PROJET;

        public string ID_PROJET
        {
            get { return _ID_PROJET; }
            set { _ID_PROJET = value; }

        }
        public string ID_GROUPE_PROJET
        {
            get { return _ID_GROUPE_PROJET; }
            set { _ID_GROUPE_PROJET = value; }

        }

        private string _NOM_PROJET;

        public string NOM_PROJET
        {
            get { return _NOM_PROJET; }
            set { _NOM_PROJET = value; }
        }
        private string _CODE_CL;

        public string CODE_CL
        {
            get { return _CODE_CL; }
            set { _CODE_CL = value; }
        }

        #endregion







        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<recherchePROJET> GetProjetEtudiantSuiviparGroupe(string id_et)
        {
            List<recherchePROJET> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT DISTINCT ESP_PROJET_NEW.* FROM ESP_PROJET_NEW, ESP_ETUDIANT_NOTE_GROUPE,ESP_GP_PROJET WHERE     (ESP_ETUDIANT_NOTE_GROUPE.ID_ET = '" + id_et + "') AND (ESP_PROJET_NEW.NIVEAU_ETUDIANT IS NULL) AND (ESP_PROJET_NEW.ID_GROUPE_PROJET = ESP_ETUDIANT_NOTE_GROUPE.ID_GROUPE_PROJET )";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<recherchePROJET>();
                        while (myReader.Read())
                        {
                            myList.Add(new recherchePROJET(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }



        public recherchePROJET(OracleDataReader myReader)
        {

            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_PROJET")))
            {

                _ID_PROJET = myReader.GetString(myReader.GetOrdinal("ID_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_PROJET")))
            {

                _NOM_PROJET = myReader.GetString(myReader.GetOrdinal("NOM_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_GROUPE_PROJET")))
            {

                _ID_GROUPE_PROJET = myReader.GetString(myReader.GetOrdinal("ID_GROUPE_PROJET"));
            }
        }

































        
    }
}
