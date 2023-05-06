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
    public class ESP_ENCADREMENT_GP
    {
        #region sing
        static ESP_ENCADREMENT_GP instance;
        static Object locker = new Object();
        public static ESP_ENCADREMENT_GP Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_ENCADREMENT_GP();
                    }

                    return ESP_ENCADREMENT_GP.instance;
                }
            }

        }
        private ESP_ENCADREMENT_GP() { }
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

        private string _ID_PROJET;
        private string _ANNEE_DEB;
        private string _TYPE_PROJET;
       
        private string _ID_ENS;
        private string _CODE_CL;


        public string ID_PROJET
        {
            get { return _ID_PROJET; }
            set { _ID_PROJET = value; }

        }

        public string ANNEE_DEB
        {
            get { return _ANNEE_DEB; }
            set { _ANNEE_DEB = value; }
        }

        public string TYPE_PROJET
        {
            get { return _TYPE_PROJET; }
            set { _TYPE_PROJET = value; }
        }

      



        public string ID_ENS
        {
            get { return _ID_ENS; }
            set { _ID_ENS = value; }
        }

        public string CODE_CL
        {
            get { return _CODE_CL; }
            set { _CODE_CL = value; }
        }
        private DateTime _DATE_ENC;
        private OracleTimeStamp _HEURE_DEB;
        private OracleTimeStamp _HEURE_FIN;
        private OracleTimeStamp _DUREE;


        public DateTime DATE_ENC
        {
            get { return _DATE_ENC; }
            set { _DATE_ENC = value; }
        }



        public OracleTimeStamp HEURE_DEB
        {
            get { return _HEURE_DEB; }
            set { _HEURE_DEB = value; }
        }

        public OracleTimeStamp HEURE_FIN
        {
            get { return _HEURE_FIN; }
            set { _HEURE_FIN = value; }
        }

        public OracleTimeStamp DUREE
        {
            get { return _DUREE; }
            set { _DUREE = value; }
        }

        private decimal _AV_TECH;
        private decimal _AV_ANG;
        private decimal _AV_FR;
        private decimal _AV_RAPPORT;
        private decimal _AV_CC;


        public decimal AV_TECH
        {
            get { return _AV_TECH; }
            set { _AV_TECH = value; }
        }

        public decimal AV_ANG
        {
            get { return _AV_ANG; }
            set { _AV_ANG = value; }
        }



        public decimal AV_FR
        {
            get { return _AV_FR; }
            set { _AV_FR = value; }
        }

        public decimal AV_RAPPORT
        {
            get { return _AV_RAPPORT; }
            set { _AV_RAPPORT = value; }
        }

        public decimal AV_CC
        {
            get { return _AV_CC; }
            set { _AV_CC = value; }
        }

        private string _COMPORTEMENT;
        private string _REMARQUE_OBS;
        private string _TRAVAUX_DEMANDE;

        public string COMPORTEMENT
        {
            get { return _COMPORTEMENT; }
            set { _COMPORTEMENT = value; }
        }

        public string REMARQUE_OBS
        {
            get { return _REMARQUE_OBS; }
            set { _REMARQUE_OBS = value; }
        }

        public string TRAVAUX_DEMANDE
        {
            get { return _TRAVAUX_DEMANDE; }
            set { _TRAVAUX_DEMANDE = value; }
        }


        private decimal _NOTE_GROUPE;


        public decimal NOTE_GROUPE
        {
            get { return _NOTE_GROUPE; }
            set { _NOTE_GROUPE = value; }
        }


        private string _ID_GROUPE_PROJET;

        public string ID_GROUPE_PROJET
        {
            get { return _ID_GROUPE_PROJET; }
            set { _ID_GROUPE_PROJET = value; }
        }


        private string _NOM_GROUPE;
        public string NOM_GROUPE
        {
            get { return _NOM_GROUPE; }
            set { _NOM_GROUPE = value;} 
        }

        #endregion



        //NOTE_GROUPE,ID_GROUPE_PROJET
        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //creation d'un encadrement du projet
        public bool create_Encadrement_ESP(string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ENS, string _CODE_CL, OracleDate _DATE_ENC, OracleTimeStamp _HEURE_DEB, OracleTimeStamp _HEURE_FIN, OracleTimeStamp _DUREE, decimal _AV_TECH, decimal _AV_ANG, decimal _AV_FR, decimal _AV_RAPPORT, decimal _AV_CC, string _COMPORTEMENT, string _REMARQUE_OBS, string _TRAVAUX_DEMANDE,decimal _NOTE_GROUPE,string _ID_GROUPE_PROJET)
        {
            //( string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ET,string _ID_ENS,string _CODE_CL,OracleDate _DATE_ENC,OracleTimeStamp _HEURE_DEB,OracleTimeStamp _HEURE_FIN,OracleTimeStamp _DUREE,decimal _AV_TECH,decimal _AV_ANG,decimal _AV_FR,decimal _AV_RAPPORT,decimal _AV_CC,string _COMPORTEMENT,string _REMARQUE_OBS,string _TRAVAUX_DEMANDE
            bool result = false;

            string cmdQuery = "INSERT INTO  ESP_ENCADREMENT_GP (ANNEE_DEB, TYPE_PROJET, ID_ENS, CODE_CL, DATE_ENC, HEURE_DEB, HEURE_FIN, DUREE, AV_TECH, AV_ANG, AV_FR, AV_RAPPORT, AV_CC, COMPORTEMENT, REMARQUE_OBS, TRAVAUX_DEMANDE , NOTE_GROUPE,ID_GROUPE_PROJET) VALUES (:ANNEE_DEB, :TYPE_PROJET, :ID_ENS, :CODE_CL, :DATE_ENC, :HEURE_DEB, :HEURE_FIN, :DUREE, :AV_TECH, :AV_ANG, :AV_FR, :AV_RAPPORT, :AV_CC, :COMPORTEMENT, :REMARQUE_OBS, :TRAVAUX_DEMANDE, :NOTE_GROUPE,:ID_GROUPE_PROJET)";

            //execution du requette   
            Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // id du projet, _ID_PROJET
            //OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            //prmID_PROJET.Value = _ID_PROJET;
            //myCommand.Parameters.Add(prmID_PROJET);

            //annee de comencement : _ANNEE_DEB
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            // _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            // id etudiant, _ID_ETUD
            //OracleParameter prmID_ETUD = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            //prmID_ETUD.Value = _ID_ET;
            //myCommand.Parameters.Add(prmID_ETUD);

            // id enseignant, _ID_ENS
            OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
            prmID_ENS.Value = _ID_ENS;
            myCommand.Parameters.Add(prmID_ENS);



            // _CODE_CL
            OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
            prmCODE_CL.Value = _CODE_CL;
            myCommand.Parameters.Add(prmCODE_CL);

            // _DATE_ENCADREMENT
            OracleParameter prmDATE_ENCADREMENT = new OracleParameter(":DATE_ENC", OracleDbType.Date);
            prmDATE_ENCADREMENT.Value = _DATE_ENC;
            myCommand.Parameters.Add(prmDATE_ENCADREMENT);

            // _HEURE_DEBUT
            OracleParameter prmHEURE_DEBUT = new OracleParameter(":HEURE_DEB", OracleDbType.TimeStamp);
            prmHEURE_DEBUT.Value = _HEURE_DEB;
            myCommand.Parameters.Add(prmHEURE_DEBUT);

            // _HEURE_FIN
            OracleParameter prmHEURE_FIN = new OracleParameter(":HEURE_FIN", OracleDbType.TimeStamp);
            prmHEURE_FIN.Value = _HEURE_FIN;
            myCommand.Parameters.Add(prmHEURE_FIN);

            // _HEURE_FIN
            OracleParameter prmDUREE = new OracleParameter(":DUREE", OracleDbType.TimeStamp);
            prmDUREE.Value = _DUREE;
            myCommand.Parameters.Add(prmDUREE);



            // Avancement technique
            OracleParameter prmAV_TECH = new OracleParameter(":AV_TECH", OracleDbType.Decimal);
            prmAV_TECH.Value = _AV_TECH;
            myCommand.Parameters.Add(prmAV_TECH);

            // Avancement Francais
            OracleParameter prmAV_FR = new OracleParameter(":AV_FR", OracleDbType.Decimal);
            prmAV_FR.Value = _AV_FR;
            myCommand.Parameters.Add(prmAV_FR);

            // Avancement Anglais
            OracleParameter prmAV_ANG = new OracleParameter(":AV_ANG", OracleDbType.Decimal);
            prmAV_ANG.Value = _AV_ANG;
            myCommand.Parameters.Add(prmAV_ANG);

            // Avancement Rapport : _AV_RAPPORT
            OracleParameter prmAV_RAPPORT = new OracleParameter(":AV_RAPPORT", OracleDbType.Decimal);
            prmAV_RAPPORT.Value = _AV_RAPPORT;
            myCommand.Parameters.Add(prmAV_RAPPORT);

            //avancement cahier de charge _AV_CC
            OracleParameter prmAV_CC = new OracleParameter(":AV_CC", OracleDbType.Decimal);
            prmAV_CC.Value = _AV_CC;
            myCommand.Parameters.Add(prmAV_CC);

            //comportement _COMORTEMENT
            OracleParameter prmCOMPORTEMENT = new OracleParameter(":COMPORTEMENT", OracleDbType.Varchar2);
            prmCOMPORTEMENT.Value = _COMPORTEMENT;
            myCommand.Parameters.Add(prmCOMPORTEMENT);

            //remarque : _REMARQUE
            OracleParameter prmREMARQUE = new OracleParameter(":REMARQUE_OBS", OracleDbType.Varchar2);
            prmREMARQUE.Value = _REMARQUE_OBS;
            myCommand.Parameters.Add(prmREMARQUE);

            //_TRAVAUX_DEMANDER
            OracleParameter prmTRAVAUX_DEMANDER = new OracleParameter(":TRAVAUX_DEMANDE", OracleDbType.Varchar2);
            prmTRAVAUX_DEMANDER.Value = _TRAVAUX_DEMANDE;
            myCommand.Parameters.Add(prmTRAVAUX_DEMANDER);

            //NOTE_GROUPE,ID_GROUPE_PROJET

            //NOTE_GROUPE : _NOTE_GROUPE
            OracleParameter prmNOTE_GROUPE = new OracleParameter(":NOTE_GROUPE", OracleDbType.Decimal);
            prmNOTE_GROUPE.Value = _NOTE_GROUPE;
            myCommand.Parameters.Add(prmNOTE_GROUPE);

            //ID_GROUPE_PROJET:_ID_GROUPE_PROJET
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);

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

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //verification l'existance d'un encadrement du projet ajouter id groupe projet dans la requette sql
        public bool verif_encadrement_ESP(string _ID_PROJET, string _ID_ET, string _ID_ENS)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                string cmdQuery = "SELECT * FROM ESP_ENCADREMENT_GP WHERE" +
                    "(ID_PROJET =:ID_PROJET)  AND (ID_ENS=:ID_ENS)";
                OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                //id projet
                OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
                prmID_PROJET.Value = _ID_PROJET;
                myCommandAbsence.Parameters.Add(prmID_PROJET);

                //id etudiant
                OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
                prmID_ET.Value = _ID_ET;
                myCommandAbsence.Parameters.Add(prmID_ET);

                //id Enseignant
                OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                prmID_ENS.Value = _ID_ENS;
                myCommandAbsence.Parameters.Add(prmID_ENS);

                mySqlConnection.Open();
                OracleDataReader MyReader = myCommandAbsence.ExecuteReader();
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

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //NOTE_GROUPE,ID_GROUPE_PROJET
        //update un encadrement du projet
        public bool update_encadrement_ESP(string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ENS, string _CODE_CL, OracleDate _DATE_ENC, OracleTimeStamp _HEURE_DEB, OracleTimeStamp _HEURE_FIN, OracleTimeStamp _DUREE, decimal _AV_TECH, decimal _AV_ANG, decimal _AV_FR, decimal _AV_RAPPORT, decimal _AV_CC, string _COMPORTEMENT, string _REMARQUE_OBS, string _TRAVAUX_DEMANDE,decimal _NOTE_GROUPE,string _ID_GROUPE_PROJET)
        {
            bool result = false;

            string cmdQuery = "UPDATE ESP_ENCADREMENT_GP SET ID_PROJET=:ID_PROJET,ANNEE_DEB=:ANNEE_DEB, TYPE_PROJET=:TYPE_PROJET,  ID_ENS=:ID_ENS, CODE_CL=:CODE_CL, DATE_ENC=:DATE_ENC, HEURE_DEB=:HEURE_DEB, HEURE_FIN=:HEURE_FIN, DUREE=:DUREE, AV_TECH=:AV_TECH, AV_ANG=:AV_ANG, AV_FR=:AV_FR, AV_RAPPORT=:AV_RAPPORT, AV_CC=:AV_CC, COMPORTEMENT=:COMPORTEMENT, REMARQUE_OBS=:REMARQUE_OBS, TRAVAUX_DEMANDE=:TRAVAUX_DEMANDE ,NOTE_GROUPE=:NOTE_GROUPE , ID_GROUPE_PROJET=:ID_GROUPE_PROJET";
            /*"UPDATE ESP_ENCADREMENTT SET ID_PROJET=:ID_PROJET , ID_ETUD=:ID_ETUD , ID_ENS=:ID_ENS , TYPE_PROJET=:TYPE_PROJET"
            + "CODE_CL=:CODE_CL , DATE_ENCADREMENT=:DATE_ENCADREMENT , HEURE_DEBUT=:HEURE_DEBUT , HEURE_FIN=:HEURE_FIN"
            + "DUREE=:DUREE , ANNEE_DEB=:ANNEE_DEB , AV_TECH=:AV_TECH , AV_FR=:AV_FR ,AV_ANG=:AV_ANG , AV_RAPPORT=:AV_RAPPORT , AV_CC=:AV_CC"
            + "COMPORTEMENT=:COMPORTEMENT , REMARQUE=:REMARQUE , TRAVAUX_DEMANDER=:TRAVAUX_DEMANDER";*/

            //execution du requette   
            Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // id du projet, _ID_PROJET
            OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            prmID_PROJET.Value = _ID_PROJET;
            myCommand.Parameters.Add(prmID_PROJET);

            //annee de comencement : _ANNEE_DEB
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            // _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            //// id etudiant, _ID_ETUD
            //OracleParameter prmID_ETUD = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            //prmID_ETUD.Value = _ID_ET;
            //myCommand.Parameters.Add(prmID_ETUD);

            // id enseignant, _ID_ENS
            OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
            prmID_ENS.Value = _ID_ENS;
            myCommand.Parameters.Add(prmID_ENS);



            // _CODE_CL
            OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
            prmCODE_CL.Value = _CODE_CL;
            myCommand.Parameters.Add(prmCODE_CL);

            // _DATE_ENCADREMENT
            OracleParameter prmDATE_ENCADREMENT = new OracleParameter(":DATE_ENC", OracleDbType.Date);
            prmDATE_ENCADREMENT.Value = _DATE_ENC;
            myCommand.Parameters.Add(prmDATE_ENCADREMENT);

            // _HEURE_DEBUT
            OracleParameter prmHEURE_DEBUT = new OracleParameter(":HEURE_DEB", OracleDbType.TimeStamp);
            prmHEURE_DEBUT.Value = _HEURE_DEB;
            myCommand.Parameters.Add(prmHEURE_DEBUT);

            // _HEURE_FIN
            OracleParameter prmHEURE_FIN = new OracleParameter(":HEURE_FIN", OracleDbType.TimeStamp);
            prmHEURE_FIN.Value = _HEURE_FIN;
            myCommand.Parameters.Add(prmHEURE_FIN);

            // _HEURE_FIN
            OracleParameter prmDUREE = new OracleParameter(":DUREE", OracleDbType.TimeStamp);
            prmDUREE.Value = _DUREE;
            myCommand.Parameters.Add(prmDUREE);



            // Avancement technique
            OracleParameter prmAV_TECH = new OracleParameter(":AV_TECH", OracleDbType.Decimal);
            prmAV_TECH.Value = _AV_TECH;
            myCommand.Parameters.Add(prmAV_TECH);

            // Avancement Francais
            OracleParameter prmAV_FR = new OracleParameter(":AV_FR", OracleDbType.Decimal);
            prmAV_FR.Value = _AV_FR;
            myCommand.Parameters.Add(prmAV_FR);

            // Avancement Anglais
            OracleParameter prmAV_ANG = new OracleParameter(":AV_ANG", OracleDbType.Decimal);
            prmAV_ANG.Value = _AV_ANG;
            myCommand.Parameters.Add(prmAV_ANG);

            // Avancement Rapport : _AV_RAPPORT
            OracleParameter prmAV_RAPPORT = new OracleParameter(":AV_RAPPORT", OracleDbType.Decimal);
            prmAV_RAPPORT.Value = _AV_RAPPORT;
            myCommand.Parameters.Add(prmAV_RAPPORT);

            //avancement cahier de charge _AV_CC
            OracleParameter prmAV_CC = new OracleParameter(":AV_CC", OracleDbType.Decimal);
            prmAV_CC.Value = _AV_CC;
            myCommand.Parameters.Add(prmAV_CC);

            //comportement _COMORTEMENT
            OracleParameter prmCOMPORTEMENT = new OracleParameter(":COMPORTEMENT", OracleDbType.Varchar2);
            prmCOMPORTEMENT.Value = _COMPORTEMENT;
            myCommand.Parameters.Add(prmCOMPORTEMENT);

            //remarque : _REMARQUE
            OracleParameter prmREMARQUE = new OracleParameter(":REMARQUE_OBS", OracleDbType.Varchar2);
            prmREMARQUE.Value = _REMARQUE_OBS;
            myCommand.Parameters.Add(prmREMARQUE);

            //_TRAVAUX_DEMANDER
            OracleParameter prmTRAVAUX_DEMANDER = new OracleParameter(":TRAVAUX_DEMANDE", OracleDbType.Varchar2);
            prmTRAVAUX_DEMANDER.Value = _TRAVAUX_DEMANDE;
            myCommand.Parameters.Add(prmTRAVAUX_DEMANDER);

            

            //_NOTE_GROUPE
            OracleParameter prmNOTE_GROUPE = new OracleParameter(":NOTE_GROUPE", OracleDbType.Decimal);
            prmNOTE_GROUPE.Value = _NOTE_GROUPE;
            myCommand.Parameters.Add(prmNOTE_GROUPE);

            //ID_GROUPE_PROJET
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);

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


        /*****************************************************************************************************************************************************/
        public ESP_ENCADREMENT_GP(OracleDataReader myReader)
        {
            //if (!myReader.IsDBNull(myReader.GetOrdinal("ID_PROJET")))
            //{
            //    _ID_PROJET = myReader.GetString(myReader.GetOrdinal("ID_PROJET"));

            //}

            if (!myReader.IsDBNull(myReader.GetOrdinal("ANNEE_DEB")))
            {

                _ANNEE_DEB = myReader.GetString(myReader.GetOrdinal("ANNEE_DEB"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("TYPE_PROJET")))
            {
                _TYPE_PROJET = myReader.GetString(myReader.GetOrdinal("TYPE_PROJET"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ENS")))
            {
                _ID_ENS = myReader.GetString(myReader.GetOrdinal("ID_ENS"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
            {

                _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("DATE_ENC")))
            {
                _DATE_ENC = myReader.GetDateTime(myReader.GetOrdinal("DATE_ENC"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("HEURE_DEB")))
            {

                _HEURE_DEB = myReader.GetDateTime(myReader.GetOrdinal("HEURE_DEB"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("HEURE_FIN")))
            {
                _HEURE_FIN = myReader.GetDateTime(myReader.GetOrdinal("HEURE_FIN"));

            }

            //if (!myreader.isdbnull(myreader.getordinal("duree")))
            //{

            //   _duree = myreader.getdatetime(myreader.getordinal("duree"));
            //}

            if (!myReader.IsDBNull(myReader.GetOrdinal("AV_TECH")))
            {
                _AV_TECH = myReader.GetDecimal(myReader.GetOrdinal("AV_TECH"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("AV_ANG")))
            {

                _AV_ANG = myReader.GetDecimal(myReader.GetOrdinal("AV_ANG"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("AV_FR")))
            {
                _AV_FR = myReader.GetDecimal(myReader.GetOrdinal("AV_FR"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("AV_RAPPORT")))
            {

                _AV_RAPPORT = myReader.GetDecimal(myReader.GetOrdinal("AV_RAPPORT"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("AV_CC")))
            {

                _AV_CC = myReader.GetDecimal(myReader.GetOrdinal("AV_CC"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("COMPORTEMENT")))
            {
                _COMPORTEMENT = myReader.GetString(myReader.GetOrdinal("COMPORTEMENT"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("REMARQUE_OBS")))
            {

                _REMARQUE_OBS = myReader.GetString(myReader.GetOrdinal("REMARQUE_OBS"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("TRAVAUX_DEMANDE")))
            {

                _TRAVAUX_DEMANDE = myReader.GetString(myReader.GetOrdinal("TRAVAUX_DEMANDE"));
            }

            
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOTE_GROUPE")))
            {

                _NOTE_GROUPE = myReader.GetDecimal(myReader.GetOrdinal("NOTE_GROUPE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_GROUPE_PROJET")))
            {

                _ID_GROUPE_PROJET = myReader.GetString(myReader.GetOrdinal("ID_GROUPE_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_GROUPE")))
            {

                _NOM_GROUPE = myReader.GetString(myReader.GetOrdinal("NOM_GROUPE"));
            }
            
        }


        /*****************************************************************************************************************************************************/


        //recuperer liste des encadrement par groupe par id_groupe_projet
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADREMENT_GP> GetListByGROUPE(string ID_GROUPE_PROJET)
        {
            List<ESP_ENCADREMENT_GP> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT DISTINCT ESP_ENCADREMENT_GP.*,ESP_GP_PROJET.NOM_GROUPE FROM ESP_ENCADREMENT_GP INNER JOIN ESP_GP_PROJET ON ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = ESP_GP_PROJET.ID_GROUPE_PROJET WHERE ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = '" + ID_GROUPE_PROJET + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ENCADREMENT_GP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADREMENT_GP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        //recuperer liste des encadrement par groupe par id_groupe_projet et id projet
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADREMENT_GP> GetProjByGROUPEProjet(string id_proj, string ID_GROUPE_PROJET)
        {
            List<ESP_ENCADREMENT_GP> myList = null;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_ENCADREMENT_GP.*, ESP_GP_PROJET.NOM_GROUPE FROM ESP_ENCADREMENT_GP INNER JOIN ESP_GP_PROJET ON ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = ESP_GP_PROJET.ID_GROUPE_PROJET WHERE ESP_ENCADREMENT_GP.ID_PROJET = '" + id_proj + "' AND ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = '" + ID_GROUPE_PROJET + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {

                        myList = new List<ESP_ENCADREMENT_GP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADREMENT_GP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        //recuperer liste des encadrement par groupe par classe et id projet
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADREMENT_GP> GetGROUPProjByClass(string codecl, string ID_GROUPE_PROJET)
        {
            List<ESP_ENCADREMENT_GP> myList = null;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_ENCADREMENT_GP.*, ESP_GP_PROJET.NOM_GROUPE FROM ESP_ENCADREMENT_GP INNER JOIN ESP_GP_PROJET ON ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = ESP_GP_PROJET.ID_GROUPE_PROJET WHERE ESP_ENCADREMENT_GP.CODE_CL = '" + codecl + "' AND ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = '" + ID_GROUPE_PROJET + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {

                        myList = new List<ESP_ENCADREMENT_GP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADREMENT_GP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        
        //recuperer liste des encadrement par groupe par type et id groupe projet
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADREMENT_GP> GetListByEtudiantType(string ID_GROUPE_PROJET, string type)
        {
            List<ESP_ENCADREMENT_GP> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT ESP_ENCADREMENT_GP.*, ESP_GP_PROJET.NOM_GROUPE FROM ESP_ENCADREMENT_GP INNER JOIN ESP_GP_PROJET ON ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = ESP_GP_PROJET.ID_GROUPE_PROJET WHERE ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = '" + ID_GROUPE_PROJET + "' AND ESP_ENCADREMENT_GP.TYPE_PROJET ='" + type + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ENCADREMENT_GP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADREMENT_GP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

       



        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADREMENT_GP> GetProjetEtudiantSuiviparGroupe(string id_et)
        {
            List<ESP_ENCADREMENT_GP> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT DISTINCT ESP_PROJET_NEW.*,ESP_ETUDIANT_NOTE_GROUPE.*,ESP_ENCADREMENT_GP.*,ESP_GP_PROJET.* FROM ESP_PROJET_NEW, ESP_ETUDIANT_NOTE_GROUPE,ESP_ENCADREMENT_GP,ESP_GP_PROJET WHERE     (ESP_ETUDIANT_NOTE_GROUPE.ID_ET = '" + id_et + "') AND (ESP_PROJET_NEW.NIVEAU_ETUDIANT IS NULL)";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ENCADREMENT_GP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADREMENT_GP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }
        //SELECT ESP_PROJET_NEW.NOM_PROJET, ESP_ENCADREMENT.ID_PROJET FROM ESP_ENCADREMENT INNER JOIN ESP_PROJET_NEW ON ESP_ENCADREMENT.ID_PROJET = ESP_PROJET_NEW.ID_PROJET Where  ESP_ENCADREMENT.id_et='11-3MT-581' AND ESP_ENCADREMENT.AV_FR!='0';



        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADREMENT_GP> GetProjetSuiviparGroupe(string id_proj)
        {
            List<ESP_ENCADREMENT_GP> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT    ESP_ENCADREMENT_GP.*,ESP_GP_PROJET.* FROM        ESP_ENCADREMENT_GP INNER JOIN                     ESP_GP_PROJET ON ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = ESP_GP_PROJET.ID_GROUPE_PROJET WHERE ESP_ENCADREMENT_GP.ID_GROUPE_PROJET='"+id_proj+"'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ENCADREMENT_GP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADREMENT_GP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADREMENT_GP> profProjetEval(string id_ens)
        {
            List<ESP_ENCADREMENT_GP> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT    ESP_ENCADREMENT_GP.*,ESP_GP_PROJET.* FROM        ESP_ENCADREMENT_GP INNER JOIN                     ESP_GP_PROJET ON ESP_ENCADREMENT_GP.ID_GROUPE_PROJET = ESP_GP_PROJET.ID_GROUPE_PROJET WHERE ESP_ENCADREMENT_GP.ID_ENS='" + id_ens + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ENCADREMENT_GP>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADREMENT_GP(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }










        
        



        //incrimentation id enncadrement groupe projet
        public decimal inc_id_encadrement_groupe()
        {
            decimal x = 0;
            string cmdQuery = "SELECT COUNT(*) AS NB FROM ESP_ENCADREMENT_GP";
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
    }
}
