using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ESPSuiviEncadrement
{
    public class EtudiantClasses
    {
         #region sing

        static EtudiantClasses instance;
        static Object locker = new Object();
        public static EtudiantClasses Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new EtudiantClasses();
                    }

                    return EtudiantClasses.instance;
                }
            }

        }
        private EtudiantClasses() { }

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

        #region public private methodes

        private string _NOM_ET;
        private string _PNOM_ET;
        private string _ID_ET;
        private decimal _NIVEAU_COURANT_ET;
        private decimal _NOTE_ETUDIANT;

        public string NOM_ET
        {
            get { return _NOM_ET; }
            set { _NOM_ET = value; }
        }
        public string PNOM_ET
        {
            get { return _PNOM_ET; }
            set { _PNOM_ET = value; }
        }

        public string ID_ET
        {
            get { return _ID_ET; }
            set { _ID_ET = value; }
        }
        public decimal NIVEAU_COURANT_ET
        {
            get { return _NIVEAU_COURANT_ET; }
            set { _NIVEAU_COURANT_ET = value; }
        }
        public decimal NOTE_ETUDIANT
        {
            get { return _NOTE_ETUDIANT; }
            set { _NOTE_ETUDIANT = value; }
        }

        #endregion


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<EtudiantClasses> GetList()
        {
            List<EtudiantClasses> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS NOM_ET, NIVEAU_COURANT_ET FROM ESP_ETUDIANT WHERE  (ESP_ETUDIANT.ETAT = 'A') ORDER BY ESP_ETUDIANT.NOM_ET";
                //"SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS &quot;NOM_ET&quot; FROM ESP_ETUDIANT, ESP_INSCRIPTION WHERE ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL = :argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = '2013') AND (ESP_ETUDIANT.ETAT = 'A') ORDER BY ESP_ETUDIANT.NOM_ET"
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;


                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<EtudiantClasses>();
                        while (myReader.Read())
                        {
                            myList.Add(new EtudiantClasses(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<EtudiantClasses> GetListEtudiantClasse(string codecl)
        {
            List<EtudiantClasses> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery ="SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS NOM_ET FROM ESP_ETUDIANT, ESP_INSCRIPTION WHERE ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL = :argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = '2013') AND (ESP_ETUDIANT.ETAT = 'A') ORDER BY ESP_ETUDIANT.NOM_ET";
                //"SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS &quot;NOM_ET&quot; FROM ESP_ETUDIANT, ESP_INSCRIPTION WHERE ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL = :argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = '2013') AND (ESP_ETUDIANT.ETAT = 'A') ORDER BY ESP_ETUDIANT.NOM_ET"
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                OracleParameter prmID_PROJET = new OracleParameter(":argcl", OracleDbType.Varchar2);
                prmID_PROJET.Value = codecl;
                myCommand.Parameters.Add(prmID_PROJET);

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<EtudiantClasses>();
                        while (myReader.Read())
                        {
                            myList.Add(new EtudiantClasses(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<EtudiantClasses> GetListEtudiantParGroupe(string nom_group)
        {
            List<EtudiantClasses> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();


                string cmdQuery = "SELECT ESP_ETUDIANT.ID_ET,ESP_ETUDIANT.NOM_ET,ESP_ETUDIANT.PNOM_ET , ESP_GROUPE_ETUDIANT.NOTE_ETUDIANT FROM ESP_ETUDIANT INNER JOIN ESP_GROUPE_ETUDIANT ON ESP_ETUDIANT.ID_ET = ESP_GROUPE_ETUDIANT.ID_ET WHERE (ESP_GROUPE_ETUDIANT.NOM_GROUPE= '" + nom_group + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<EtudiantClasses>();
                        while (myReader.Read())
                        {
                            myList.Add(new EtudiantClasses(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        public decimal getNiveauEtudiant(string code)
        {
            decimal x;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                
                mySqlConnection.Open();
                string cmdQuery = "SELECT  NIVEAU_COURANT_ET FROM ESP_ETUDIANT WHERE  (ID_ET = '" + code + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        x = myReader.GetDecimal(myReader.GetOrdinal("NIVEAU_COURANT_ET"));
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

        
        public bool statusEtudiantaffecter(string id_et , string type_projet)
        {
            bool status = false;
            string etu = "";
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT     scoesb02.ESP_GROUPE_ETUDIANT.ID_ET FROM scoesb02.ESP_PROJET_NEW INNER JOIN scoesb02.ESP_GROUPE_ETUDIANT ON scoesb02.ESP_PROJET_NEW.ID_GROUPE_PROJET = scoesb02.ESP_GROUPE_ETUDIANT.ID_GROUPE_PROJET "+
                    " WHERE  ESP_GROUPE_ETUDIANT.ID_ET = '" + id_et + "' AND ESP_PROJET_NEW.TYPE_PROJET='"+type_projet+"'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        etu = myReader.GetString(myReader.GetOrdinal("ID_ET"));
                        
                    }
                    else
                    {
                        etu = "";
                    }
                    if(etu!="")
                        status = true;
                    else
                        status = false;

                }
                mySqlConnection.Close();
            }
            return status;
        }



        




        public EtudiantClasses(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ET")))
            {
                _NOM_ET = myReader.GetString(myReader.GetOrdinal("NOM_ET"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("PNOM_ET")))
            {
                _NOM_ET = myReader.GetString(myReader.GetOrdinal("PNOM_ET"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ET")))
            {

                _ID_ET = myReader.GetString(myReader.GetOrdinal("ID_ET"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_ETUDIANT")))
            {

                _NOTE_ETUDIANT = myReader.GetDecimal(myReader.GetOrdinal("NOTE_ETUDIANT"));
            }



        }

        public EtudiantClasses(string NOM_ET, string ID_ET)
        {

            this._NOM_ET = NOM_ET;
            this._PNOM_ET = PNOM_ET;
            this._ID_ET = ID_ET;
            this._NIVEAU_COURANT_ET = NIVEAU_COURANT_ET;
            this._NOTE_ETUDIANT = NOTE_ETUDIANT;

        }
    }
}