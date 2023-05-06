using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.ComponentModel;

namespace ESPSuiviEncadrement
{
    public class ESP_GROUPE_ETUDIANT
    {
        #region sing
        static ESP_GROUPE_ETUDIANT instance;
        static Object locker = new Object();
        public static ESP_GROUPE_ETUDIANT Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_GROUPE_ETUDIANT();
                    }

                    return ESP_GROUPE_ETUDIANT.instance;
                }
            }

        }
        private ESP_GROUPE_ETUDIANT() { }
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

        private string _ID_ET;
        private string _ID_GROUPE_PROJET;
        private string _NOM_GROUPE;
        private string _DESCRIPTIO_GROUPE;
        private decimal _NOTE_ETUDIANT;
        private decimal _NUMERO_GROUPE;

        public string ID_ET
        {
            get { return _ID_ET; }
            set { _ID_ET = value; }

        }
        public string ID_GROUPE_PROJET
        {
            get { return _ID_GROUPE_PROJET; }
            set { _ID_GROUPE_PROJET = value; }

        }
        public string NOM_GROUPE
        {
            get { return _NOM_GROUPE; }
            set { _NOM_GROUPE = value; }

        }
        public string DESCRIPTIO_GROUPE
        {
            get { return _DESCRIPTIO_GROUPE; }
            set { _DESCRIPTIO_GROUPE = value; }

        }
        public decimal NOTE_ETUDIANT
        {
            get { return _NOTE_ETUDIANT; }
            set { _NOTE_ETUDIANT = value; }

        }
        public decimal NUMERO_GROUPE
        {
            get { return _NUMERO_GROUPE; }
            set { _NUMERO_GROUPE = value; }

        }

        #endregion public private methodes


        public bool create_Groupe_ETUDIANT(string _ID_ET, string _ID_GROUPE_PROJET, string _NOM_GROUPE, string _DESCRIPTIO_GROUPE, decimal _NOTE_ETUDIANT, decimal _NUMERO_GROUPE, string _ANNEE_DEB)
        {

            bool result = false;

            string cmdQuery = "INSERT INTO  ESP_GROUPE_ETUDIANT (ID_ET,ID_GROUPE_PROJET,NOM_GROUPE,DESCRIPTIO_GROUPE,NOTE_ETUDIANT,NUMERO_GROUPE,ANNEE_DEB) VALUES (:ID_ET,:ID_GROUPE_PROJET,:NOM_GROUPE,:DESCRIPTIO_GROUPE,:NOTE_ETUDIANT,:NUMERO_GROUPE,:ANNEE_DEB)";
            //execution du requette   
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // ID_ET
            OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            prmID_ET.Value = _ID_ET;
            myCommand.Parameters.Add(prmID_ET);

            // ID_GROUPE_PROJET
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);

            // NOM_GROUPE
            OracleParameter prmNOM_GROUPE = new OracleParameter(":NOM_GROUPE", OracleDbType.Varchar2);
            prmNOM_GROUPE.Value = _NOM_GROUPE;
            myCommand.Parameters.Add(prmNOM_GROUPE);

            // NOM_GROUPE
            OracleParameter prmDESCRIPTIO_GROUPE = new OracleParameter(":DESCRIPTIO_GROUPE", OracleDbType.Varchar2);
            prmDESCRIPTIO_GROUPE.Value = _DESCRIPTIO_GROUPE;
            myCommand.Parameters.Add(prmDESCRIPTIO_GROUPE);

            //NOTE_ETUDIANT
            OracleParameter prmNOTE_ETUDIANT = new OracleParameter(":NOTE_ETUDIANT", OracleDbType.Decimal);
            prmNOTE_ETUDIANT.Value = _NOTE_ETUDIANT;
            myCommand.Parameters.Add(prmNOTE_ETUDIANT);

            //NOTE_ETUDIANT
            OracleParameter prmNUMERO_GROUPE = new OracleParameter(":NUMERO_GROUPE", OracleDbType.Decimal);
            prmNUMERO_GROUPE.Value = _NUMERO_GROUPE;
            myCommand.Parameters.Add(prmNUMERO_GROUPE);

            //ANNEE_DEB
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            try
            {

                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }
            return result;
        }


        public bool verif_Groupe_ETUDIANT(string _NOM_GROUPE, decimal _NUMERO_GROUPE)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                string cmdQuery = "SELECT * FROM ESP_GROUPE_ETUDIANT WHERE" +
                    "(NOM_GROUPE=:NOM_GROUPE)AND (NUMERO_GROUPE=:NUMERO_GROUPE)";
                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                //NOM_GROUPE
                OracleParameter prmNOM_GROUPE = new OracleParameter(":NOM_GROUPE", OracleDbType.Varchar2);
                prmNOM_GROUPE.Value = _NOM_GROUPE;
                myCommand.Parameters.Add(prmNOM_GROUPE);

                //NUMERO_GROUPE
                OracleParameter prmNUMERO_GROUPE = new OracleParameter(":NUMERO_GROUPE", OracleDbType.Decimal);
                prmNUMERO_GROUPE.Value = _NUMERO_GROUPE;
                myCommand.Parameters.Add(prmNUMERO_GROUPE);

                ////ANNEE_DEB
                //OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
                //prmANNEE_DEB.Value = _ANNEE_DEB;
                //myCommand.Parameters.Add(prmANNEE_DEB);


                mySqlConnection.Open();
                OracleDataReader MyReader = myCommand.ExecuteReader();
                while (MyReader.Read() && !exist)
                {
                    exist = true;

                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();

            }
            return exist;
        }

        public bool update_Groupe_ETUDIANT(string _ID_ET, string _ID_GROUPE_PROJET, string _NOM_GROUPE, string _DESCRIPTIO_GROUPE, decimal _NUMERO_GROUPE, string _ANNEE_DEB)
        {

            bool result = false;

            string cmdQuery = "UPDATE ESP_GROUPE_ETUDIANT SET " +
                "ID_ET=:ID_ET,ID_GROUPE_PROJET=:ID_GROUPE_PROJET,NOM_GROUPE=:NOM_GROUPE,DESCRIPTIO_GROUPE=:DESCRIPTIO_GROUPE,NOTE_ETUDIANT=:NOTE_ETUDIANT,NUMERO_GROUPE=:NUMERO_GROUP,ANNEE_DEB=:ANNEE_DEB";
            //execution du requette   
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // ID_ET
            OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            prmID_ET.Value = _ID_ET;
            myCommand.Parameters.Add(prmID_ET);

            // ID_GROUPE_PROJET
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);

            // NOM_GROUPE
            OracleParameter prmNOM_GROUPE = new OracleParameter(":NOM_GROUPE", OracleDbType.Varchar2);
            prmNOM_GROUPE.Value = _NOM_GROUPE;
            myCommand.Parameters.Add(prmNOM_GROUPE);

            // NOM_GROUPE
            OracleParameter prmDESCRIPTIO_GROUPE = new OracleParameter(":DESCRIPTIO_GROUPE", OracleDbType.Varchar2);
            prmDESCRIPTIO_GROUPE.Value = _DESCRIPTIO_GROUPE;
            myCommand.Parameters.Add(prmDESCRIPTIO_GROUPE);

            //NOTE_ETUDIANT
            OracleParameter prmNOTE_ETUDIANT = new OracleParameter(":NOTE_ETUDIANT", OracleDbType.Decimal);
            prmNOTE_ETUDIANT.Value = _NOTE_ETUDIANT;
            myCommand.Parameters.Add(prmNOTE_ETUDIANT);

            //NUMERO_GROUPE
            OracleParameter prmNUMERO_GROUPE = new OracleParameter(":NUMERO_GROUPE", OracleDbType.Decimal);
            prmNUMERO_GROUPE.Value = _NUMERO_GROUPE;
            myCommand.Parameters.Add(prmNUMERO_GROUPE);

            //ANNEE_DEB
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            try
            {
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }
            return result;
        }

        public List<ESP_GROUPE_ETUDIANT> getIdproj(string _ANNEE_DEB, string _NOM_GROUPE)
        {
            List<ESP_GROUPE_ETUDIANT> myList = new List<ESP_GROUPE_ETUDIANT>();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                /* ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, NIVEAU_ETUDIANT, DUREE, SEMESTRE, PERIODE */
                string cmdQuery = "SELECT ID_GROUPE_PROJET, NOM_GROUPE FROM ESP_GROUPE_ETUDIANT WHERE (ANNEE_DEB =:ANNEE_DEB) AND (NOM_GROUPE = :NOM_GROUPE)";

                OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                //DATE_SEANCE
                OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
                prmANNEE_DEB.Value = _ANNEE_DEB;
                myCommandAbsence.Parameters.Add(prmANNEE_DEB);

                //_NOM_GROUPE
                OracleParameter prmNOM_GROUPE = new OracleParameter(":NOM_GROUPE", OracleDbType.Varchar2);
                prmNOM_GROUPE.Value = _NOM_GROUPE;
                myCommandAbsence.Parameters.Add(prmNOM_GROUPE);

                mySqlConnection.Close();
                mySqlConnection.Open();
                using (OracleDataReader myReader = myCommandAbsence.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_GROUPE_ETUDIANT>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_GROUPE_ETUDIANT(myReader));
                        }
                    }
                }
                mySqlConnection.Close();

            }
            return myList;


        }


        public ESP_GROUPE_ETUDIANT(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_GROUPE_PROJET")))
            {

                _ID_GROUPE_PROJET = myReader.GetString(myReader.GetOrdinal("ID_GROUPE_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_GROUPE")))
            {

                _NOM_GROUPE = myReader.GetString(myReader.GetOrdinal("NOM_GROUPE"));
            }
        }

        public decimal inc_id_groupe_etudiant()
        {
            decimal x = 0;
            string cmdQuery = "SELECT COUNT(*) AS NB FROM ESP_GROUPE_ETUDIANT";
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;
            mySqlConnection.Open();
            using (OracleDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.HasRows)
                {
                    x = myReader.GetDecimal(myReader.GetOrdinal("NB"));
                    mySqlConnection.Close();
                }
                return x;
            }
        }

        

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static bool verifier_etudiant_dans_groupe(string _ID_ET)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                //ID_GROUPE_PROJET,NUM_PROJET_GROUPE,ETAT,REMARQUE,ID_PROJET
                string cmdQuery = "SELECT * FROM ESP_GROUPE_ETUDIANT WHERE" +
                    "(ID_ET =:ID_ET)";
                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                //ID_GROUPE_PROJET
                OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
                prmID_ET.Value = _ID_ET;
                myCommand.Parameters.Add(prmID_ET);

                mySqlConnection.Open();
                OracleDataReader MyReader = myCommand.ExecuteReader();

                while (MyReader.Read() && !exist)
                {
                    exist = true;

                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();

            }
            return exist;
        }



        public string[] REchercheGroupeParNomGROUPE(string nom)
        {
            string[] ls;
            string NOM_GROUPE;
            string DESCRIPTIO_GROUPE;
            decimal NOTE_ETUDIANT;
            decimal NUMERO_GROUPE;
            string ID_GROUPE_PROJET;
           
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT NOM_GROUPE,DESCRIPTIO_GROUPE,NOTE_ETUDIANT,NUMERO_GROUPE,ID_GROUPE_PROJET FROM ESP_GROUPE_ETUDIANT WHERE  (ESP_GROUPE_ETUDIANT.NOM_GROUPE = '" + nom + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        NOM_GROUPE = myReader.GetString(myReader.GetOrdinal("NOM_GROUPE"));
                        DESCRIPTIO_GROUPE = myReader.GetString(myReader.GetOrdinal("DESCRIPTIO_GROUPE"));
                        NOTE_ETUDIANT = myReader.GetDecimal(myReader.GetOrdinal("NOTE_ETUDIANT"));
                        NUMERO_GROUPE = myReader.GetDecimal(myReader.GetOrdinal("NUMERO_GROUPE"));
                        ID_GROUPE_PROJET = myReader.GetString(myReader.GetOrdinal("ID_GROUPE_PROJET"));
                        
                    }
                    else
                    {
                        NOM_GROUPE="";
                        DESCRIPTIO_GROUPE = "";
                        NOTE_ETUDIANT=0;
                        ID_GROUPE_PROJET = "";
                        NUMERO_GROUPE=0;
                    }

                }
                mySqlConnection.Close();
                ls = new string[] { NOM_GROUPE, DESCRIPTIO_GROUPE, NOTE_ETUDIANT.ToString(), NUMERO_GROUPE.ToString(), ID_GROUPE_PROJET };
                return ls;
            }
            
        }

    }
}
