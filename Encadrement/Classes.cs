using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ESPSuiviEncadrement
{
    
    public class Classes
    {

        #region sing

        static Classes instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Classes Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Classes();
                    }

                    return Classes.instance;
                }
            }

        }
        private Classes() { }

        #endregion


        #region public private methodes

        private string _NOM_ENS;
        private string _CODE_CL;

        public string NOM_ENS
        {
            get { return _NOM_ENS; }
            set { _NOM_ENS = value; }
        }

        public string CODE_CL
        {
            get { return _CODE_CL; }
            set { _CODE_CL = value; }
        }

        #endregion


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Classes> GetList(string id)
        {
            List<Classes> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT distinct ESP_ENSEIGNANT.NOM_ENS,   ESP_MODULE_PANIER_CLASSE_SAISO.CODE_CL,    ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS   FROM ESP_ENSEIGNANT,     ESP_MODULE_PANIER_CLASSE_SAISO,    ESP_MODULE   WHERE ( ESP_ENSEIGNANT.ID_ENS = ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS ) and   ( ESP_MODULE.CODE_MODULE = ESP_MODULE_PANIER_CLASSE_SAISO.CODE_MODULE ) and   ( ( ESP_MODULE_PANIER_CLASSE_SAISO.ID_ENS = '" + id + "' ) AND   ( ESP_MODULE_PANIER_CLASSE_SAISO.NUM_SEMESTRE = 1 ) AND   ( ESP_MODULE_PANIER_CLASSE_SAISO.ANNEE_DEB = '2013' ) )   ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<Classes>();
                        while (myReader.Read())
                        {
                            myList.Add(new Classes(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Classes> GetList()
        {
            List<Classes> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT distinct  CODE_CL from  ESP_MODULE_PANIER_CLASSE_SAISO  where annee_deb='2013' order by code_cl";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<Classes>();
                        while (myReader.Read())
                        {
                            myList.Add(new Classes(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }


        public Classes(OracleDataReader myReader)
        {
          

            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
            {

                _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));
            }

        }

        public Classes(string NOM_ENS, string CODE_CL)
        {

          
            this._CODE_CL = CODE_CL;

        }


    }
}