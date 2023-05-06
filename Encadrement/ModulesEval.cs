using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.ComponentModel;
using System.Data;
using ESPSuiviEncadrement;
using DAL;


namespace Evaluation
{
    [DataObject()]

    public class ModulesEval
    {

        public string anneedeb;
        #region sing

        static ModulesEval instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static ModulesEval Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ModulesEval();
                    }

                    return ModulesEval.instance;
                }
            }

        }
        private ModulesEval() { }

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

        private decimal _NUM_SEMESTRE;

        public decimal NUM_SEMESTRE
        {
            get { return _NUM_SEMESTRE; }
            set { _NUM_SEMESTRE = value; }
        }

        #endregion



        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ModulesEval> GetList(string id)
        {
            
            List<ModulesEval> myList = null;
          
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                string anneedeb = DAL.AffectationDAO.Instance.getanneedeb();
                mySqlConnection.Open();

                string cmdQuery = "SELECT ESP_INSCRIPTION.ID_ET, ESP_INSCRIPTION.code_cl1,ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE, ESP_MODULE.DESIGNATION FROM ESP_INSCRIPTION INNER JOIN ESP_MODULE_PANIER_CLASSE_SAISO ON ESP_INSCRIPTION.CODE_CL1 = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL INNER JOIN ESP_MODULE ON ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE = ESP_MODULE.CODE_MODULE WHERE     (ESP_INSCRIPTION.ID_ET = '" + id + "') and (ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE=2) AND (ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '2017') AND (ESP_INSCRIPTION.ANNEE_DEB = '2017') AND (ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 1 or ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 2   ) minus select esp_evaluation.id_et,code_cl,esp_evaluation.code_module,ESP_MODULE.designation from esp_evaluation,ESP_MODULE where (esp_evaluation.CODE_MODULE = ESP_MODULE.CODE_MODULE and annee_deb='2017' )";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ModulesEval>();
                        while (myReader.Read())
                        {
                            myList.Add(new ModulesEval(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        public ModulesEval(OracleDataReader myReader)
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

        public ModulesEval(string CODE_MODULE, string DESIGNATION)
        {

            this._CODE_MODULE = CODE_MODULE;
            this._DESIGNATION = DESIGNATION;

        }



    }
}