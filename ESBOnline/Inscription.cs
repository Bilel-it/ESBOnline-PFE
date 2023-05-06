using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;
using ABSEsprit;

namespace ESPOnline
{
    public class Inscription
    {
        #region sing

        static Inscription instance;
        static Object locker = new Object();

        public static Inscription Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Inscription();
                    }

                    return Inscription.instance;
                }
            }

        }
        private Inscription() { }

        #endregion
        #region getset
        private string _LIB_DECISION_SESSION_P;

        public string LIB_DECISION_SESSION_P
        {
            get { return _LIB_DECISION_SESSION_P; }
            set { _LIB_DECISION_SESSION_P = value; }
        }


        private string _RESERVE;

        public string RESERVE
        {
            get { return _RESERVE; }
            set { _RESERVE = value; }
        }


        private string _CODE_CL;

        public string CODE_CL
        {
            get { return _CODE_CL; }
            set { _CODE_CL = value; }
        }

        private string _NOM_ET;

        public string NOM_ET
        {
            get { return _NOM_ET; }
            set { _NOM_ET = value; }
        }

        private string _PNOM_ET;

        public string PNOM_ET
        {
            get { return _PNOM_ET; }
            set { _PNOM_ET = value; }
        }

        private decimal _MOY_GENERAL;

        public decimal MOY_GENERAL
        {
            get { return _MOY_GENERAL; }
            set { _MOY_GENERAL = value; }
        }


        private string _LIB_DECISION_SESSION_Rat;

        public string LIB_DECISION_SESSION_Rat
        {
            get { return _LIB_DECISION_SESSION_Rat; }
            set { _LIB_DECISION_SESSION_Rat = value; }
        }
        private decimal _MOY_RATT;

        public decimal MOY_RATT
        {
            get { return _MOY_RATT; }
            set { _MOY_RATT = value; }
        }

        private string _CODE_DECISION_SESSION_RAT;
        public string CODE_DECISION_SESSION_RAT
        {
            get { return _CODE_DECISION_SESSION_RAT; }
            set { _CODE_DECISION_SESSION_RAT = value; }
        }
        #endregion
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Inscription> GetListInscription(string _Id_et)
        {
            List<Inscription> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT RESERVE , NOM_ET , PNOM_ET ,CODE_CL, LIB_DECISION_SESSION_P, MOY_GENERAL , LIB_DECISION_SESSION_Rat , MOY_RATT , CODE_DECISION_SESSION_RAT FROM ESP_INSCRIPTION , ESP_ETUDIANT where ESP_INSCRIPTION.id_et='" + _Id_et + "' and ESP_INSCRIPTION.annee_deb=2016  and ESP_INSCRIPTION.id_Et = ESP_ETUDIANT.id_Et";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<Inscription>();
                        while (myReader.Read())
                        {
                            myList.Add(new Inscription(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
        public Inscription(OracleDataReader myReader)
        {



            if (!myReader.IsDBNull(myReader.GetOrdinal("LIB_DECISION_SESSION_P")))
            {
                _LIB_DECISION_SESSION_P = myReader.GetString(myReader.GetOrdinal("LIB_DECISION_SESSION_P"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_GENERAL")))
            {
                _MOY_GENERAL = myReader.GetDecimal(myReader.GetOrdinal("MOY_GENERAL"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("LIB_DECISION_SESSION_Rat")))
            {
                _LIB_DECISION_SESSION_Rat = myReader.GetString(myReader.GetOrdinal("LIB_DECISION_SESSION_Rat"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_RATT")))
            {
                _MOY_RATT = myReader.GetDecimal(myReader.GetOrdinal("MOY_RATT"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ET")))
            {
                _NOM_ET = myReader.GetString(myReader.GetOrdinal("NOM_ET"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("PNOM_ET")))
            {
                _PNOM_ET = myReader.GetString(myReader.GetOrdinal("PNOM_ET"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
            {
                _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));


            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_DECISION_SESSION_RAT")))
            {
                _CODE_DECISION_SESSION_RAT = myReader.GetString(myReader.GetOrdinal("CODE_DECISION_SESSION_RAT"));


            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("RESERVE")))
            {
                _RESERVE = myReader.GetString(myReader.GetOrdinal("RESERVE"));


            }


        }
    }
}