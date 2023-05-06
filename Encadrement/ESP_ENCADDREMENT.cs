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
    public class ESP_ENCADDREMENT
    {
        #region sing
        static ESP_ENCADDREMENT instance;
        static Object locker = new Object();
        public static ESP_ENCADDREMENT Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_ENCADDREMENT();
                    }

                    return ESP_ENCADDREMENT.instance;
                }
            }

        }
        private ESP_ENCADDREMENT() { }
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
        private string _ID_ET;
        private string _ID_ENS;
        private string _CODE_CL;
        private string _NOM_PROJET;
       

        public string ID_PROJET
        {
            get { return _ID_PROJET; }
            set { _ID_PROJET = value; }

        }

        public string NOM_PROJET
        {
            get { return _NOM_PROJET; }
            set { _NOM_PROJET = value; }

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

        public string ID_ET
        {
            get { return _ID_ET; }
            set { _ID_ET = value; }
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
        #endregion

/*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //creation d'un encadrement du projet
        public bool create_Encadrement_ESP(string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ET, string _ID_ENS, string _CODE_CL, OracleDate _DATE_ENC, OracleTimeStamp _HEURE_DEB, OracleTimeStamp _HEURE_FIN, OracleTimeStamp _DUREE, decimal _AV_TECH, decimal _AV_ANG, decimal _AV_FR, decimal _AV_RAPPORT, decimal _AV_CC, string _COMPORTEMENT, string _REMARQUE_OBS, string _TRAVAUX_DEMANDE)
        {
            //( string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ET,string _ID_ENS,string _CODE_CL,OracleDate _DATE_ENC,OracleTimeStamp _HEURE_DEB,OracleTimeStamp _HEURE_FIN,OracleTimeStamp _DUREE,decimal _AV_TECH,decimal _AV_ANG,decimal _AV_FR,decimal _AV_RAPPORT,decimal _AV_CC,string _COMPORTEMENT,string _REMARQUE_OBS,string _TRAVAUX_DEMANDE
             bool result = false;
            
             string cmdQuery = "INSERT INTO  ESP_ENCADREMENT (ID_PROJET, ANNEE_DEB, TYPE_PROJET, ID_ET, ID_ENS, CODE_CL, DATE_ENC, HEURE_DEB, HEURE_FIN, DUREE, AV_TECH, AV_ANG, AV_FR, AV_RAPPORT, AV_CC, COMPORTEMENT, REMARQUE_OBS, TRAVAUX_DEMANDE) VALUES (:ID_PROJET,:ANNEE_DEB, :TYPE_PROJET, :ID_ET, :ID_ENS, :CODE_CL, :DATE_ENC, :HEURE_DEB, :HEURE_FIN, :DUREE, :AV_TECH, :AV_ANG, :AV_FR, :AV_RAPPORT, :AV_CC, :COMPORTEMENT, :REMARQUE_OBS, :TRAVAUX_DEMANDE)";



            //execution du requette   
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
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

            // id etudiant, _ID_ETUD
            OracleParameter prmID_ETUD = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            prmID_ETUD.Value = _ID_ET;
            myCommand.Parameters.Add(prmID_ETUD);

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
        //verification l'existance d'un encadrement du projet
        public bool verif_encadrement_ESP(string _ID_PROJET, string _ID_ET, string _ID_ENS)
        {
             bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                string cmdQuery = "SELECT * FROM ESP_ENCADREMENT WHERE" +
                    "(ID_PROJET =:ID_PROJET) AND (ID_ET =:ID_ET) AND (ID_ENS=:ID_ENS)";
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
        //update un encadrement du projet
        public bool update_encadrement_ESP(string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ET, string _ID_ENS, string _CODE_CL, OracleDate _DATE_ENC, OracleTimeStamp _HEURE_DEB, OracleTimeStamp _HEURE_FIN, OracleTimeStamp _DUREE, decimal _AV_TECH, decimal _AV_ANG, decimal _AV_FR, decimal _AV_RAPPORT, decimal _AV_CC, string _COMPORTEMENT, string _REMARQUE_OBS, string _TRAVAUX_DEMANDE)
        {
            bool result = false;

            string cmdQuery = "UPDATE ESP_ENCADREMENT SET ID_PROJET=:ID_PROJET,ANNEE_DEB=:ANNEE_DEB, TYPE_PROJET=:TYPE_PROJET, ID_ET=:ID_ET, ID_ENS=:ID_ENS, CODE_CL=:CODE_CL, DATE_ENC=:DATE_ENC, HEURE_DEB=:HEURE_DEB, HEURE_FIN=:HEURE_FIN, DUREE=:DUREE, AV_TECH=:AV_TECH, AV_ANG=:AV_ANG, AV_FR=:AV_FR, AV_RAPPORT=:AV_RAPPORT, AV_CC=:AV_CC, COMPORTEMENT=:COMPORTEMENT, REMARQUE_OBS=:REMARQUE_OBS, TRAVAUX_DEMANDE=:TRAVAUX_DEMANDE";
                /*"UPDATE ESP_ENCADREMENTT SET ID_PROJET=:ID_PROJET , ID_ETUD=:ID_ETUD , ID_ENS=:ID_ENS , TYPE_PROJET=:TYPE_PROJET"
                + "CODE_CL=:CODE_CL , DATE_ENCADREMENT=:DATE_ENCADREMENT , HEURE_DEBUT=:HEURE_DEBUT , HEURE_FIN=:HEURE_FIN"
                + "DUREE=:DUREE , ANNEE_DEB=:ANNEE_DEB , AV_TECH=:AV_TECH , AV_FR=:AV_FR ,AV_ANG=:AV_ANG , AV_RAPPORT=:AV_RAPPORT , AV_CC=:AV_CC"
                + "COMPORTEMENT=:COMPORTEMENT , REMARQUE=:REMARQUE , TRAVAUX_DEMANDER=:TRAVAUX_DEMANDER";*/

            //execution du requette   
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
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

            // id etudiant, _ID_ETUD
            OracleParameter prmID_ETUD = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            prmID_ETUD.Value = _ID_ET;
            myCommand.Parameters.Add(prmID_ETUD);

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
        //delete un encadrement du projet
        public bool delete_encadrement_ESP(string _ID_PROJET)
        {
             bool delete = false;
             using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
             {
                 string cmdQuery = "DELETE * FROM ESP_ENCADREMENT WHERE" +
                    "(ID_PROJET =:ID_PROJET) ";
                 OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                 //id projet
                 OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
                 prmID_PROJET.Value = _ID_PROJET;
                 myCommandAbsence.Parameters.Add(prmID_PROJET);

                 OracleDataReader MyReader = myCommandAbsence.ExecuteReader();
                while (MyReader.Read() && !delete)
                {
                    delete = true;

                    break;

                }
                MyReader.Close();
                mySqlConnection.Close();

            }
            return delete;

             }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADDREMENT> GetListByEtudiant(string id_et)
        {
            List<ESP_ENCADDREMENT> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT * FROM   ESP_ENCADREMENT WHERE ID_ET = '" + id_et + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ENCADDREMENT>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADDREMENT(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADDREMENT> GetProjByEtudiantProjet(string id_proj, string id_et)
        {
            List<ESP_ENCADDREMENT> myList = null;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT * FROM   ESP_ENCADREMENT WHERE ID_PROJET = '" + id_proj + "' AND ID_ET = '" + id_et + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {

                        myList = new List<ESP_ENCADDREMENT>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADDREMENT(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADDREMENT> GetProjByEtudiantClass(string codecl, string id_et)
        {
            List<ESP_ENCADDREMENT> myList = null;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT * FROM   ESP_ENCADREMENT WHERE CODE_CL = '" + codecl + "' AND ID_ET = '" + id_et + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {

                        myList = new List<ESP_ENCADDREMENT>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADDREMENT(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_PROJET_DETAILS> GetListByEtudiantType(string id_et, string type)
        {
            List<ESP_PROJET_DETAILS> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT * FROM   ESP_ENCADREMENT WHERE ID_ET = '" + id_et + "' AND TYPE_PROJET ='" + type + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_PROJET_DETAILS>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_PROJET_DETAILS(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }








        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADDREMENT> GetProjetEtudiantSuivi(string id_et)
        {
            List<ESP_ENCADDREMENT> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_ENCADREMENT.*, ESP_PROJET_NEW.* FROM ESP_ENCADREMENT INNER JOIN ESP_PROJET_NEW ON ESP_ENCADREMENT.ID_PROJET = ESP_PROJET_NEW.ID_PROJET Where ESP_ENCADREMENT.COMPORTEMENT IS NULL   AND ESP_ENCADREMENT.ID_ET = '" + id_et + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ENCADDREMENT>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADDREMENT(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }
        //SELECT ESP_PROJET_NEW.NOM_PROJET, ESP_ENCADREMENT.ID_PROJET FROM ESP_ENCADREMENT INNER JOIN ESP_PROJET_NEW ON ESP_ENCADREMENT.ID_PROJET = ESP_PROJET_NEW.ID_PROJET Where  ESP_ENCADREMENT.id_et='11-3MT-581' AND ESP_ENCADREMENT.AV_FR!='0';







        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADDREMENT> GetProjetSuivi(string ID_PROJET)
        {
            List<ESP_ENCADDREMENT> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_ENCADREMENT.*, ESP_PROJET_NEW.* FROM ESP_ENCADREMENT INNER JOIN ESP_PROJET_NEW ON ESP_ENCADREMENT.ID_PROJET = ESP_PROJET_NEW.ID_PROJET Where ESP_ENCADREMENT.AV_FR!='0' AND  ESP_ENCADREMENT.ID_PROJET = '" + ID_PROJET + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ENCADDREMENT>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADDREMENT(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }

        public ESP_ENCADDREMENT(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_PROJET")))
            {
                _ID_PROJET = myReader.GetString(myReader.GetOrdinal("ID_PROJET"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("ANNEE_DEB")))
            {

                _ANNEE_DEB = myReader.GetString(myReader.GetOrdinal("ANNEE_DEB"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("TYPE_PROJET")))
            {
                _TYPE_PROJET = myReader.GetString(myReader.GetOrdinal("TYPE_PROJET"));

            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ET")))
            {

                _ID_ET = myReader.GetString(myReader.GetOrdinal("ID_ET"));
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

            if (!myReader.IsDBNull(myReader.GetOrdinal("DUREE")))
            {

                _DUREE = myReader.GetDateTime(myReader.GetOrdinal("DUREE"));
            }

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
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_PROJET")))
            {

                _NOM_PROJET = myReader.GetString(myReader.GetOrdinal("NOM_PROJET"));
            }
            
        }



        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_ENCADDREMENT> GetProjetPROF(string ID_ENS)
        {
            List<ESP_ENCADDREMENT> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_ENCADREMENT.*, ESP_PROJET_NEW.* FROM ESP_ENCADREMENT INNER JOIN ESP_PROJET_NEW ON ESP_ENCADREMENT.ID_PROJET = ESP_PROJET_NEW.ID_PROJET Where ESP_ENCADREMENT.AV_FR!='0' AND  ESP_ENCADREMENT.ID_ENS = '" + ID_ENS + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_ENCADDREMENT>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_ENCADDREMENT(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;
        }
        }
    }
