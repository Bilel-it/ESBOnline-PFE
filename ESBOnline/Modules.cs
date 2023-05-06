using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;

namespace ABSEsprit
{
   
         

    public  class Modules
    {


        #region sing

        static Modules instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Modules Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Modules();
                    }

                    return Modules.instance;
                }
            }

        }
        private Modules() { }

        #endregion

        #region public private methodes


        private string _CODE_MODULE;

        public string CODE_MODULE
        {
            get { return _CODE_MODULE; }
            set { _CODE_MODULE = value; }

        }

        private string _DESIGNATION;

        public string DESIGNATION
        {
            get { return _DESIGNATION; }
            set { _DESIGNATION = value; }
        }

        private int _NB_HEURES;

        public int NB_HEURES
        {
            get { return _NB_HEURES; }
            set { _NB_HEURES = value; }
        }
        private int _COEF;

        public int COEF
        {
            get { return _COEF; }
            set { _COEF = value; }
        }

        private int _NUM_SEMESTRE;

        public int NUM_SEMESTRE
        {
            get { return _NUM_SEMESTRE; }
            set { _NUM_SEMESTRE = value; }
        }






        #endregion



        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Modules> GetList(string id,string codcl, int semestre )
        {
            List<Modules> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT trim(ESP_MODULE.CODE_MODULE) as CODE_MODULE, ESP_MODULE.DESIGNATION, ESP_ENSEIGNANT.ID_ENS, ESP_ENSEIGNANT.NOM_ENS,  ESP_MODULE_PANIER_CLASSE_SAISO.NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE FROM   ESP_MODULE_PANIER_CLASSE_SAISO INNER JOIN  ESP_ENSEIGNANT ON ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = ESP_ENSEIGNANT.ID_ENS INNER JOIN  ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE WHERE (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = (select max(annee_deb) from societe)) AND (ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL like '" + codcl + "%') AND   (ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = '" + id + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2 = '" + id + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3 = '" + id + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4 = '" + id + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5 = '" + id + "') AND (ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = '" + semestre + "' )";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<Modules>();
                        while (myReader.Read())
                        {
                            myList.Add(new Modules(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Modules> GetListModuleClasse(string codcl, int semestre)
        {
            List<Modules> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT     ESP_MODULE.CODE_MODULE, ESP_MODULE.DESIGNATION, ESP_ENSEIGNANT.ID_ENS, ESP_ENSEIGNANT.NOM_ENS,  ESP_MODULE_PANIER_CLASSE_SAISO.NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE FROM   ESP_MODULE_PANIER_CLASSE_SAISO INNER JOIN  ESP_ENSEIGNANT ON ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = ESP_ENSEIGNANT.ID_ENS INNER JOIN  ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE WHERE (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = (select max(annee_deb) from societe)) AND (ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL = '" + codcl + "') AND (ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = '" + semestre + "' )";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<Modules>();
                        while (myReader.Read())
                        {
                            myList.Add(new Modules(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Modules> GetListN(string id, string codcl)
        {
            List<Modules> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT     ESP_MODULE.CODE_MODULE, ESP_MODULE.DESIGNATION, ESP_ENSEIGNANT.ID_ENS, ESP_ENSEIGNANT.NOM_ENS,  ESP_MODULE_PANIER_CLASSE_SAISO.NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE FROM   ESP_MODULE_PANIER_CLASSE_SAISO INNER JOIN  ESP_ENSEIGNANT ON ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = ESP_ENSEIGNANT.ID_ENS INNER JOIN  ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE WHERE (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = (select max(annee_deb) from societe)) AND (ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL = '" + codcl + "') AND   (ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = '" + id + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS2 = '" + id + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS3 = '" + id + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS4 = '" + id + "' or ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS5 = '" + id + "') ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<Modules>();
                        while (myReader.Read())
                        {
                            myList.Add(new Modules(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
    

        public Modules(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_MODULE")))
            {
                _CODE_MODULE = myReader.GetString(myReader.GetOrdinal("CODE_MODULE"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("DESIGNATION")))
            {

                _DESIGNATION = myReader.GetString(myReader.GetOrdinal("DESIGNATION"));
            }

            

          

        }

        public Modules(string CODE_MODULE, string DESIGNATION,int NB_HEURES,int COEF,int NUM_SEMESTRE )
        {

            this._CODE_MODULE = CODE_MODULE;
            this._DESIGNATION = DESIGNATION;
            this._NB_HEURES=NB_HEURES;
            this._COEF = COEF;
            this._NUM_SEMESTRE = NUM_SEMESTRE;


        }


    }
}