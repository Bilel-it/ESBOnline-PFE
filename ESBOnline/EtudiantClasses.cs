using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABSEsprit;
using System.Data;
using System.ComponentModel;
using Oracle.ManagedDataAccess.Client;

namespace ESPOnline
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


        #region public private methodes

        private string _NOM_ET;
        private string _ID_ET;
        private decimal _NIVEAU_COURANT_ET;

        public string NOM_ET
        {
            get { return _NOM_ET; }
            set { _NOM_ET = value; }
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

                string cmdQuery = "SELECT  ESP_ETUDIANT.ID_ET, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS NOM_ET FROM ESP_ETUDIANT, ESP_INSCRIPTION WHERE ESP_ETUDIANT.ID_ET = ESP_INSCRIPTION.ID_ET AND (ESP_INSCRIPTION.CODE_CL = :argcl) AND (ESP_INSCRIPTION.ANNEE_DEB = '2017') AND (ESP_ETUDIANT.ETAT = 'A') ORDER BY ESP_ETUDIANT.NOM_ET";
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


        public EtudiantClasses(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ET")))
            {
                _NOM_ET = myReader.GetString(myReader.GetOrdinal("NOM_ET"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ET")))
            {

                _ID_ET = myReader.GetString(myReader.GetOrdinal("ID_ET"));
            }


        }

        public EtudiantClasses(string NOM_ET, string ID_ET)
        {

            this._NOM_ET = NOM_ET;
            this._ID_ET = ID_ET;
            this._NIVEAU_COURANT_ET = NIVEAU_COURANT_ET;

        }

    }
}