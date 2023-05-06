using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;

namespace ESPSuiviEncadrement
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

        #endregion

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Modules> GetList(string codcl)
        {
            List<Modules> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT ESP_MODULE.CODE_MODULE, ESP_MODULE.DESIGNATION, ESP_ENSEIGNANT.ID_ENS, ESP_ENSEIGNANT.NOM_ENS,  ESP_MODULE_PANIER_CLASSE_SAISO.NB_HEURES, ESP_MODULE_PANIER_CLASSE_SAISO.COEF, ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE FROM   ESP_MODULE_PANIER_CLASSE_SAISO INNER JOIN  ESP_ENSEIGNANT ON ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = ESP_ENSEIGNANT.ID_ENS INNER JOIN  ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE WHERE (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '2013') AND (ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL = '"+codcl+"')";
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
        public static List<Modules> GetListAllModules()
        {
            List<Modules> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT DISTINCT ESP_MODULE.CODE_MODULE, ESP_MODULE.DESIGNATION FROM ESP_MODULE ORDER BY ESP_MODULE.DESIGNATION";
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
        public static List<Modules> GetListEval(string id)
        {
            List<Modules> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT ESP_INSCRIPTION.ID_ET, ESP_INSCRIPTION.code_cl,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE, ESP_MODULE.DESIGNATION FROM ESP_INSCRIPTION INNER JOIN ESP_MODULE_PANIER_CLASSE_SAISO ON ESP_INSCRIPTION.CODE_CL = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL INNER JOIN ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE WHERE (ESP_MODULE.A_EVALUER='O' ) and    (ESP_INSCRIPTION.ID_ET = '" + id + "') AND (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '2013') AND (ESP_INSCRIPTION.ANNEE_DEB = '2013') AND (ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 1 or ( (ESP_MODULE.A_EVALUER='O' )and(ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '2013') AND (ESP_INSCRIPTION.ANNEE_DEB = '2013')and(ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 2 and ESP_MODULE_PANIER_CLASSE_SAISO.PERIODE=1 ))) minus select esp_evaluation.id_et,code_cl,esp_evaluation.code_module,ESP_MODULE.designation from esp_evaluation,ESP_MODULE where (esp_evaluation.CODE_MODULE = ESP_MODULE.CODE_MODULE and annee_deb=2013 )";
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

        public Modules(string CODE_MODULE, string DESIGNATION)
        {

            this._CODE_MODULE = CODE_MODULE;
            this._DESIGNATION = DESIGNATION;

        }


    }
}