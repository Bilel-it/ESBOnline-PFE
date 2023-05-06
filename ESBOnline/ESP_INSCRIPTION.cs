using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using ABSEsprit;

namespace ESPOnline
{
    public class ESP_INSCRIPTION
    {
        #region sing

        static ESP_INSCRIPTION instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static ESP_INSCRIPTION Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_INSCRIPTION();
                    }

                    return ESP_INSCRIPTION.instance;
                }
            }

        }
        private ESP_INSCRIPTION() { }

        #endregion
        #region public private methodes

        private string _CODE_CL;

        public string CODE_CL
        {
            get { return _CODE_CL; }
            set { _CODE_CL = value; }
        }
        #endregion

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ESP_INSCRIPTION getClassEtudiant(string _ID_ET, string _NUM_CIN_PASSEPORT)
        {
            bool exist = false;
            string Name = "x";
            ESP_INSCRIPTION ins = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "select * from ESP_INSCRIPTION WHERE  ID_ET ='" + _ID_ET + "' and ANNEE_DEB='2013'";


                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    // String Name = MyReader["Username"].ToString();


                    ins = new ESP_INSCRIPTION(MyReader);
                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();
                return ins;
            }



        }

        public ESP_INSCRIPTION(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
            {
                _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));

            }
        }

        public ESP_INSCRIPTION(string ID_ET, string NUM_CIN_PASSEPORT, string NOM_ET, string PRENOM_ET)
        {
            this._CODE_CL = CODE_CL;
        }
    }
}