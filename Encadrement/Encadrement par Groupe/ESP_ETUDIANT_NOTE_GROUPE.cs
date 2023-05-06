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
    public class ESP_ETUDIANT_NOTE_GROUPE
    {
        #region sing
        static ESP_ETUDIANT_NOTE_GROUPE instance;
        static Object locker = new Object();
        public static ESP_ETUDIANT_NOTE_GROUPE Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_ETUDIANT_NOTE_GROUPE();
                    }

                    return ESP_ETUDIANT_NOTE_GROUPE.instance;
                }
            }

        }
        private ESP_ETUDIANT_NOTE_GROUPE() { }
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

        private string _ID_GROUPE_PROJET;
        private string _ID_ET;
        private decimal _NOTE_ET;
        private string _ID_ENS;
        private string _REMARQUE;
        private string _ABS_ET;

        private string _NOM_ET;
        private string _PNOM_ET;
        private DateTime _DATE_EVAL;


        public string ID_GROUPE_PROJET
        {
            get { return _ID_GROUPE_PROJET; }
            set { _ID_GROUPE_PROJET = value; }
        }
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
        public decimal NOTE_ET
        {
            get { return _NOTE_ET; }
            set { _NOTE_ET = value; }
        }

        public string ID_ENS
        {
            get { return _ID_ENS; }
            set { _ID_ENS = value; }
        }
        public string REMARQUE
        {
            get { return _REMARQUE; }
            set { _REMARQUE = value; }
        }
        public string ABS_ET
        {
            get { return _ABS_ET; }
            set { _ABS_ET = value; }
        }
        public DateTime DATE_EVAL
        {
            get { return _DATE_EVAL; }
            set { _DATE_EVAL = value; }
        }
        
        #endregion

        //affectation d'un groupe du projet
        public bool affect_etudiant_groupe_projet_ESP(string _ID_GROUPE_PROJET, string _ID_ET, decimal _NOTE_ET, string _ID_ENS, string _REMARQUE, string _ABS_ET)
        {
            //( string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ET,string _ID_ENS,string _CODE_CL,OracleDate _DATE_ENC,OracleTimeStamp _HEURE_DEB,OracleTimeStamp _HEURE_FIN,OracleTimeStamp _DUREE,decimal _AV_TECH,decimal _AV_ANG,decimal _AV_FR,decimal _AV_RAPPORT,decimal _AV_CC,string _COMPORTEMENT,string _REMARQUE_OBS,string _TRAVAUX_DEMANDE
            bool result = false;

            string cmdQuery = "INSERT INTO  ESP_ETUDIANT_NOTE_GROUPE (ID_GROUPE_PROJET , ID_ET ,NOTE_ET , ID_ENS , REMARQUE , ABS_ET ) VALUES (:ID_GROUPE_PROJET ,:ID_ET ,:NOTE_ET , :ID_ENS , :REMARQUE , :ABS_ET)";

            //execution du requette   
            Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // id du projet, _ID_PROJET
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);

            OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            prmID_ET.Value = _ID_ET;
            myCommand.Parameters.Add(prmID_ET);

            OracleParameter prmNOTE_ET = new OracleParameter(":NOTE_ET", OracleDbType.Decimal);
            prmNOTE_ET.Value = _NOTE_ET;
            myCommand.Parameters.Add(prmNOTE_ET);

            OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
            prmID_ENS.Value = _ID_ENS;
            myCommand.Parameters.Add(prmID_ENS);

            OracleParameter prmREMARQUE = new OracleParameter(":REMARQUE", OracleDbType.Varchar2);
            prmREMARQUE.Value = _REMARQUE;
            myCommand.Parameters.Add(prmREMARQUE);

            OracleParameter prmABS_ET = new OracleParameter(":ABS_ET", OracleDbType.Varchar2);
            prmABS_ET.Value = _ABS_ET;
            myCommand.Parameters.Add(prmABS_ET);

   
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


        //affectation d'un groupe du projet
        public bool create_etudiant_groupe_projet_ESP(string _ID_GROUPE_PROJET, string _ID_ET, decimal _NOTE_ET, string _ID_ENS, string _REMARQUE, string _ABS_ET)
        {
            //( string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ET,string _ID_ENS,string _CODE_CL,OracleDate _DATE_ENC,OracleTimeStamp _HEURE_DEB,OracleTimeStamp _HEURE_FIN,OracleTimeStamp _DUREE,decimal _AV_TECH,decimal _AV_ANG,decimal _AV_FR,decimal _AV_RAPPORT,decimal _AV_CC,string _COMPORTEMENT,string _REMARQUE_OBS,string _TRAVAUX_DEMANDE
            bool result = false;

            string cmdQuery = "INSERT INTO  ESP_ETUDIANT_NOTE_GROUPE (ID_GROUPE_PROJET , ID_ET ,NOTE_ET , ID_ENS , REMARQUE , ABS_ET ,DATE_EVAL) VALUES (:ID_GROUPE_PROJET ,:ID_ET ,:NOTE_ET , :ID_ENS , :REMARQUE , :ABS_ET , :DATE_EVAL)";

            //execution du requette   
            Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // id du projet, _ID_PROJET
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);

            OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            prmID_ET.Value = _ID_ET;
            myCommand.Parameters.Add(prmID_ET);

            OracleParameter prmNOTE_ET = new OracleParameter(":NOTE_ET", OracleDbType.Decimal);
            prmNOTE_ET.Value = _NOTE_ET;
            myCommand.Parameters.Add(prmNOTE_ET);

            OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
            prmID_ENS.Value = _ID_ENS;
            myCommand.Parameters.Add(prmID_ENS);

            OracleParameter prmREMARQUE = new OracleParameter(":REMARQUE", OracleDbType.Varchar2);
            prmREMARQUE.Value = _REMARQUE;
            myCommand.Parameters.Add(prmREMARQUE);

            OracleParameter prmABS_ET = new OracleParameter(":ABS_ET", OracleDbType.Varchar2);
            prmABS_ET.Value = _ABS_ET;
            myCommand.Parameters.Add(prmABS_ET);


            DateTime dd = DateTime.Now;
            DATE_EVAL = dd;
            OracleParameter prmDATE_EVAL = new OracleParameter(":DATE_EVAL", OracleDbType.Date);
            prmDATE_EVAL.Value = _DATE_EVAL;
            myCommand.Parameters.Add(prmDATE_EVAL);





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
        //verif existance d'un etudiant dans un groupe du projet
        public bool verif_Groupe_projet_ESP(string _ID_GROUPE_PROJET, string _ID_ET)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                string cmdQuery = "SELECT * FROM ESP_ETUDIANT_NOTE_GROUPE WHERE" +
                    "(ID_GROUPE_PROJET=:ID_GROUPE_PROJET)AND (ID_ET=:ID_ET)";
                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                //NOM_GROUPE
                OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
                prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
                myCommand.Parameters.Add(prmID_GROUPE_PROJET);

                //NOM_GROUPE
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

        //note etudiant
        public bool update_NOTE_etudiant_projet_ESp(string _ID_GROUPE_PROJET, string _ID_ET, decimal _NOTE_ET, string _ID_ENS)
        {

            bool result = false;

            string cmdQuery = "UPDATE ESP_ETUDIANT_NOTE_GROUPE SET " +
                "NOTE_ET=:NOTE_ET WHERE ID_GROUPE_PROJET='" + _ID_GROUPE_PROJET + "' AND ID_ET='" + _ID_ET + "' AND ID_ENS='"+_ID_ENS+"'";
            //execution du requette   
            Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // id du projet, _ID_PROJET
            OracleParameter prmNOTE_ET = new OracleParameter(":NOTE_ET", OracleDbType.Decimal);
            prmNOTE_ET.Value = _NOTE_ET;
            myCommand.Parameters.Add(prmNOTE_ET);



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

        //reader
        public ESP_ETUDIANT_NOTE_GROUPE(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_GROUPE_PROJET")))
            {

                _ID_GROUPE_PROJET = myReader.GetString(myReader.GetOrdinal("ID_GROUPE_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ET")))
            {

                _ID_ET = myReader.GetString(myReader.GetOrdinal("ID_ET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ENS")))
            {

                _ID_ENS = myReader.GetString(myReader.GetOrdinal("ID_ENS"));
            }

            

            if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_ET")))
            {

                _NOTE_ET = myReader.GetDecimal(myReader.GetOrdinal("NOTE_ET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("REMARQUE")))
            {

                _REMARQUE = myReader.GetString(myReader.GetOrdinal("REMARQUE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ABS_ET")))
            {

                _ABS_ET = myReader.GetString(myReader.GetOrdinal("ABS_ET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ET")))
            {

                _NOM_ET = myReader.GetString(myReader.GetOrdinal("NOM_ET"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("DATE_EVAL")))
            {

                _DATE_EVAL = myReader.GetDateTime(myReader.GetOrdinal("DATE_EVAL"));
            }

            

            
        }

        //incrimentation id groupe projet
        public decimal inc_id_etudiant_groupe_projet()
        {
            decimal x = 0;
            string cmdQuery = "SELECT COUNT(*) AS NB FROM ESP_ETUDIANT_NOTE_GROUPE";
            Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            using (OracleDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.HasRows)
                {
                    x = myReader.GetDecimal(myReader.GetOrdinal("NB"));
                }
                return x;
            }
        }

        //liste des etudiant par id_groupe projet

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ETUDIANT_NOTE_GROUPE> GetListeEtudiantDansunGroupe(string id_gp_pj)
        {
            List<ESP_ETUDIANT_NOTE_GROUPE> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT ESP_ETUDIANT_NOTE_GROUPE.ID_GROUPE_PROJET, ESP_ETUDIANT_NOTE_GROUPE.ID_ET,ESP_ETUDIANT_NOTE_GROUPE.ID_ENS, ESP_ETUDIANT_NOTE_GROUPE.NOTE_ET, ESP_ETUDIANT_NOTE_GROUPE.REMARQUE, ESP_ETUDIANT_NOTE_GROUPE.ABS_ET,ESP_ETUDIANT_NOTE_GROUPE.DATE_EVAL, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS NOM_ET FROM ESP_ETUDIANT_NOTE_GROUPE INNER JOIN ESP_ETUDIANT ON ESP_ETUDIANT_NOTE_GROUPE.ID_ET = ESP_ETUDIANT.ID_ET WHERE (DATE_EVAL IS NULL) AND (ESP_ETUDIANT_NOTE_GROUPE.ID_GROUPE_PROJET = '" + id_gp_pj + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ETUDIANT_NOTE_GROUPE>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ETUDIANT_NOTE_GROUPE(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ETUDIANT_NOTE_GROUPE> EVALGetListeEtudiantDansunGroupe(string id_gp_pj,string id_et)
        {
            List<ESP_ETUDIANT_NOTE_GROUPE> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT ESP_ETUDIANT_NOTE_GROUPE.ID_GROUPE_PROJET, ESP_ETUDIANT_NOTE_GROUPE.ID_ET,ESP_ETUDIANT_NOTE_GROUPE.ID_ENS, ESP_ETUDIANT_NOTE_GROUPE.NOTE_ET, ESP_ETUDIANT_NOTE_GROUPE.REMARQUE, ESP_ETUDIANT_NOTE_GROUPE.ABS_ET,ESP_ETUDIANT_NOTE_GROUPE.DATE_EVAL, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS NOM_ET FROM ESP_ETUDIANT_NOTE_GROUPE INNER JOIN ESP_ETUDIANT ON ESP_ETUDIANT_NOTE_GROUPE.ID_ET = ESP_ETUDIANT.ID_ET WHERE (DATE_EVAL IS NOT NULL) AND (ABS_ET IS NOT NULL) AND (ESP_ETUDIANT_NOTE_GROUPE.ID_GROUPE_PROJET = '" + id_gp_pj + "') AND (ESP_ETUDIANT_NOTE_GROUPE.ID_ET='" + id_et + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ETUDIANT_NOTE_GROUPE>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ETUDIANT_NOTE_GROUPE(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }



        ///////////
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ETUDIANT_NOTE_GROUPE> SuiviEtudiant(string id_et)
        {
            List<ESP_ETUDIANT_NOTE_GROUPE> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT ESP_ETUDIANT_NOTE_GROUPE.ID_GROUPE_PROJET, ESP_ETUDIANT_NOTE_GROUPE.ID_ET,ESP_ETUDIANT_NOTE_GROUPE.ID_ENS, ESP_ETUDIANT_NOTE_GROUPE.NOTE_ET, ESP_ETUDIANT_NOTE_GROUPE.REMARQUE, ESP_ETUDIANT_NOTE_GROUPE.ABS_ET,ESP_ETUDIANT_NOTE_GROUPE.DATE_EVAL, ESP_ETUDIANT.NOM_ET || ' ' || ESP_ETUDIANT.PNOM_ET AS NOM_ET FROM ESP_ETUDIANT_NOTE_GROUPE INNER JOIN ESP_ETUDIANT ON ESP_ETUDIANT_NOTE_GROUPE.ID_ET = ESP_ETUDIANT.ID_ET WHERE (DATE_EVAL IS NOT NULL) AND (ABS_ET IS NOT NULL) AND (ESP_ETUDIANT_NOTE_GROUPE.ID_ET='" + id_et + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ETUDIANT_NOTE_GROUPE>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ETUDIANT_NOTE_GROUPE(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
    }
}
