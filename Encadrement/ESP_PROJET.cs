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
    public class ESP_PROJET
    {
        #region sing
        static ESP_PROJET instance;
        static Object locker = new Object();
        public static ESP_PROJET Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_PROJET();
                    }

                    return ESP_PROJET.instance;
                }
            }

        }
        private ESP_PROJET() { }
        #endregion sing
        #region public private methodes


        private string _ID_PROJET;
        private string _ID_GROUPE_PROJET;

        public string ID_PROJET
        {
            get { return _ID_PROJET; }
            set { _ID_PROJET = value; }

        }
        public string ID_GROUPE_PROJET
        {
            get { return _ID_GROUPE_PROJET; }
            set { _ID_GROUPE_PROJET = value; }

        }

        private string _NOM_PROJET;

        public string NOM_PROJET
        {
            get { return _NOM_PROJET; }
            set { _NOM_PROJET = value; }
        }
        private string _CODE_CL;

        public string CODE_CL
        {
            get { return _CODE_CL; }
            set { _CODE_CL = value; }
        }

        #endregion

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
        //ID_GROUPE_PROJET
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

        //enregistrement d'un encadrement
        public bool create_esp_projet(string _ANNEE_DEB, string _NOM_PROJET, string _CODE_MODULE, string _TYPE_PROJET, string _DESCRIPTION_PROJET, string _TECHNOLOGIES, string _METHODOLOGIE, decimal _NIVEAU_ETUDIANT, decimal _DUREE, decimal _SEMESTRE, decimal _PERIODE)
        
        {
            bool result = false;


            string cmdQuery = "INSERT INTO ESP_PROJET_NEW ( ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, NIVEAU_ETUDIANT, DUREE, SEMESTRE, PERIODE) VALUES (:ANNEE_DEB, :ID_PROJET, :NOM_PROJET, :CODE_MODULE, :TYPE_PROJET, :DESCRIPTION_PROJET, :TECHNOLOGIES, :METHODOLOGIE, :NIVEAU_ETUDIANT, :DUREE, :SEMESTRE, :PERIODE)";
            //ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, NIVEAU_ETUDIANT, DUREE, SEMESTRE, PERIODE
            //string _ANNEE_DEB,string _ID_PROJET,string _NOM_PROJET,string _CODE_MODULE,string _TYPE_PROJET,string _DESCRIPTION_PROJET,string _TECHNOLOGIES,string _METHODOLOGIE,decimal _NIVEAU_ETUDIANT,decimal _DUREE,decimal _SEMESTRE,decimal _PERIODE
            //execution du requette   
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // Anne du debut du projet : _ANNEE_DEBUT
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            // id du projet, _ID_PROJET
            decimal x= inc_id_projet() + 1;
            String _ID_PROJET = "PROJ"+x;
            OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            prmID_PROJET.Value = _ID_PROJET;
            myCommand.Parameters.Add(prmID_PROJET);

            

            //le nom du projet _NOM_PROJET
            OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET", OracleDbType.Varchar2);
            prmNOM_PROJET.Value = _NOM_PROJET;
            myCommand.Parameters.Add(prmNOM_PROJET);

            //le code module : _CODE_MODULE
            OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
            prmCODE_MODULE.Value = _CODE_MODULE;
            myCommand.Parameters.Add(prmCODE_MODULE);

            //le type du projet : _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            //la description du projet :_DESCRIPTION_PROJET
            OracleParameter prmDESCRIPTION_PROJET = new OracleParameter(":DESCRIPTION_PROJET", OracleDbType.Varchar2);
            prmDESCRIPTION_PROJET.Value = _DESCRIPTION_PROJET;
            myCommand.Parameters.Add(prmDESCRIPTION_PROJET);

            //technique utilisé dans le projet : _TECHNOLOGIES
            OracleParameter prmTECHNIQUE_UTLISE = new OracleParameter(":TECHNOLOGIES", OracleDbType.Varchar2);
            prmTECHNIQUE_UTLISE.Value = _TECHNOLOGIES;
            myCommand.Parameters.Add(prmTECHNIQUE_UTLISE);

           
            //methodoligie utilisé dans le projet : _METHODOLOGIE
            OracleParameter prmMETHODOLOGIE = new OracleParameter(":METHODOLOGIE", OracleDbType.Varchar2);
            prmMETHODOLOGIE.Value = _METHODOLOGIE;
            myCommand.Parameters.Add(prmMETHODOLOGIE);

            // le  niveau de l'etudiant : _NIVEAU_ETUDIANT
            OracleParameter prmNIVEAU_ETUDIANT = new OracleParameter(":NIVEAU_ETUDIANT", OracleDbType.Int32);
            prmNIVEAU_ETUDIANT.Value = _NIVEAU_ETUDIANT;
            myCommand.Parameters.Add(prmNIVEAU_ETUDIANT);

            OracleParameter prmDUREE = new OracleParameter(":DUREE", OracleDbType.Int32);
            prmDUREE.Value = _DUREE;
            myCommand.Parameters.Add(prmDUREE);

            OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE", OracleDbType.Int32);
            prmSEMESTRE.Value = _SEMESTRE;
            myCommand.Parameters.Add(prmSEMESTRE);

            OracleParameter prmPERIODE = new OracleParameter(":PERIODE", OracleDbType.Int32);
            prmPERIODE.Value = _PERIODE;
            myCommand.Parameters.Add(prmPERIODE);

            //string nu = "";
            //string ID_GROUPE_PROJET = nu;
            //OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            //prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            //myCommand.Parameters.Add(prmID_GROUPE_PROJET);

            

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

        public bool update_esp_suivi_projet1(string _ANNEE_DEB, string _ID_PROJET, string _NOM_PROJET, string _CODE_MODULE, string _TYPE_PROJET, string _DESCRIPTION_PROJET, string _TECHNOLOGIES, string _METHODOLOGIE, decimal _DUREE, decimal _SEMESTRE, decimal _PERIODE, string _ID_ENS)
        {

            bool result = false;

            string cmdQuery = "UPDATE ESP_PROJET_N SET ANNEE_DEB=:ANNEE_DEB, NOM_PROJET=: NOM_PROJET, CODE_MODULE=:CODE_MODULE, TYPE_PROJET=:TYPE_PROJET, DESCRIPTION_PROJET=:DESCRIPTION_PROJET, TECHNOLOGIES=:TECHNOLOGIES, METHODOLOGIE=:METHODOLOGIE, DUREE=:DUREE, SEMESTRE=:SEMESTRE, PERIODE=:PERIODE ,ID_ENS=:ID_ENS WHERE ID_PROJET='" + _ID_PROJET + "'";
            /* "UPDATE ESP_PROJET SET ID_PROJET=:ID_PROJET , NOM_PROJET=:NOM_PROJET , CODE_MODULE=:CODE_MODULE , TYPE_PROJET=:TYPE_PROJET"
             + "DESCRIPTION_PROJET=:DESCRIPTION_PROJET , DUREE_EN_MOIS=:DUREE_EN_MOIS , SEMESTRE_PROJET=:SEMESTRE_PROJET , PERIODE_PROJET=:PERIODE_PROJET"
             + "ETAT_PROJET=:ETAT_PROJET , TECHNIQUE_UTLISE=:TECHNIQUE_UTLISE , METHODOLOGIE=:METHODOLOGIE , NIVEAU_ETUDIANT=:NIVEAU_ETUDIANT"
             + "ANNEE_DEB=:ANNEE_DEB";*/

            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // Anne du debut du projet : _ANNEE_DEBUT
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);



            //le nom du projet _NOM_PROJET
            OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET", OracleDbType.Varchar2);
            prmNOM_PROJET.Value = _NOM_PROJET;
            myCommand.Parameters.Add(prmNOM_PROJET);

            //le code module : _CODE_MODULE
            OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
            prmCODE_MODULE.Value = _CODE_MODULE;
            myCommand.Parameters.Add(prmCODE_MODULE);

            //le type du projet : _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            //la description du projet :_DESCRIPTION_PROJET
            OracleParameter prmDESCRIPTION_PROJET = new OracleParameter(":DESCRIPTION_PROJET", OracleDbType.Varchar2);
            prmDESCRIPTION_PROJET.Value = _DESCRIPTION_PROJET;
            myCommand.Parameters.Add(prmDESCRIPTION_PROJET);

            //technique utilisé dans le projet : _TECHNOLOGIES
            OracleParameter prmTECHNIQUE_UTLISE = new OracleParameter(":TECHNOLOGIES", OracleDbType.Varchar2);
            prmTECHNIQUE_UTLISE.Value = _TECHNOLOGIES;
            myCommand.Parameters.Add(prmTECHNIQUE_UTLISE);


            //methodoligie utilisé dans le projet : _METHODOLOGIE
            OracleParameter prmMETHODOLOGIE = new OracleParameter(":METHODOLOGIE", OracleDbType.Varchar2);
            prmMETHODOLOGIE.Value = _METHODOLOGIE;
            myCommand.Parameters.Add(prmMETHODOLOGIE);

          

            OracleParameter prmDUREE = new OracleParameter(":DUREE", OracleDbType.Int32);
            prmDUREE.Value = _DUREE;
            myCommand.Parameters.Add(prmDUREE);

            OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE", OracleDbType.Int32);
            prmSEMESTRE.Value = _SEMESTRE;
            myCommand.Parameters.Add(prmSEMESTRE);

            OracleParameter prmPERIODE = new OracleParameter(":PERIODE", OracleDbType.Int32);
            prmPERIODE.Value = _PERIODE;
            myCommand.Parameters.Add(prmPERIODE);

            // id du projet, _ID_PROJET
            //OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            //prmID_PROJET.Value = _ID_PROJET;
            //myCommand.Parameters.Add(prmID_PROJET);

            OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
            prmID_ENS.Value = _ID_ENS;
            myCommand.Parameters.Add(prmID_ENS);

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
        //enregistrement d'un projet par groupe
        public bool create_esp_projet_par_groupe(string _ANNEE_DEB, string _NOM_PROJET, string _CODE_MODULE, string _TYPE_PROJET, string _DESCRIPTION_PROJET, string _TECHNOLOGIES, string _METHODOLOGIE, decimal _DUREE, decimal _SEMESTRE, decimal _PERIODE, string _CODE_CL)
        {
            bool result = false;
            //mySqlConnection.Open();

            string cmdQuery = "INSERT INTO ESP_PROJET_NEW ( ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, DUREE, SEMESTRE, PERIODE ,ID_GROUPE_PROJET,CODE_CL) VALUES (:ANNEE_DEB, :ID_PROJET, :NOM_PROJET, :CODE_MODULE, :TYPE_PROJET, :DESCRIPTION_PROJET, :TECHNOLOGIES, :METHODOLOGIE, :DUREE, :SEMESTRE, :PERIODE , :ID_GROUPE_PROJET,:CODE_CL)";
            //ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, NIVEAU_ETUDIANT, DUREE, SEMESTRE, PERIODE
            //string _ANNEE_DEB,string _ID_PROJET,string _NOM_PROJET,string _CODE_MODULE,string _TYPE_PROJET,string _DESCRIPTION_PROJET,string _TECHNOLOGIES,string _METHODOLOGIE,decimal _NIVEAU_ETUDIANT,decimal _DUREE,decimal _SEMESTRE,decimal _PERIODE
            //execution du requette   

            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // Anne du debut du projet : _ANNEE_DEBUT
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            // id du projet, _ID_PROJET
            decimal x = inc_id_projet() + 1;
            String _ID_PROJET = "PROJ" + x;
            OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            prmID_PROJET.Value = _ID_PROJET;
            myCommand.Parameters.Add(prmID_PROJET);



            //le nom du projet _NOM_PROJET
            OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET", OracleDbType.Varchar2);
            prmNOM_PROJET.Value = _NOM_PROJET;
            myCommand.Parameters.Add(prmNOM_PROJET);

            //le code module : _CODE_MODULE
            OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
            prmCODE_MODULE.Value = _CODE_MODULE;
            myCommand.Parameters.Add(prmCODE_MODULE);

            //le type du projet : _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            //la description du projet :_DESCRIPTION_PROJET
            OracleParameter prmDESCRIPTION_PROJET = new OracleParameter(":DESCRIPTION_PROJET", OracleDbType.Varchar2);
            prmDESCRIPTION_PROJET.Value = _DESCRIPTION_PROJET;
            myCommand.Parameters.Add(prmDESCRIPTION_PROJET);

            //technique utilisé dans le projet : _TECHNOLOGIES
            OracleParameter prmTECHNIQUE_UTLISE = new OracleParameter(":TECHNOLOGIES", OracleDbType.Varchar2);
            prmTECHNIQUE_UTLISE.Value = _TECHNOLOGIES;
            myCommand.Parameters.Add(prmTECHNIQUE_UTLISE);


            //methodoligie utilisé dans le projet : _METHODOLOGIE
            OracleParameter prmMETHODOLOGIE = new OracleParameter(":METHODOLOGIE", OracleDbType.Varchar2);
            prmMETHODOLOGIE.Value = _METHODOLOGIE;
            myCommand.Parameters.Add(prmMETHODOLOGIE);

            // le  niveau de l'etudiant : _NIVEAU_ETUDIANT
            //OracleParameter prmNIVEAU_ETUDIANT = new OracleParameter(":NIVEAU_ETUDIANT", OracleDbType.Int32);
            //prmNIVEAU_ETUDIANT.Value = _NIVEAU_ETUDIANT;
            //myCommand.Parameters.Add(prmNIVEAU_ETUDIANT);

            OracleParameter prmDUREE = new OracleParameter(":DUREE", OracleDbType.Int32);
            prmDUREE.Value = _DUREE;
            myCommand.Parameters.Add(prmDUREE);

            OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE", OracleDbType.Int32);
            prmSEMESTRE.Value = _SEMESTRE;
            myCommand.Parameters.Add(prmSEMESTRE);

            OracleParameter prmPERIODE = new OracleParameter(":PERIODE", OracleDbType.Int32);
            prmPERIODE.Value = _PERIODE;
            myCommand.Parameters.Add(prmPERIODE);

            //ID_GROUPE_PROJET
            //OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            //prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            //myCommand.Parameters.Add(prmID_GROUPE_PROJET);

            decimal xx = inc_id_projet() + 1;
            String _ID_GROUPE_PROJET = "GPROJ" + xx;
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);


            OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
            prmCODE_CL.Value = _CODE_CL;
            myCommand.Parameters.Add(prmCODE_CL);


            try
            {
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                //mySqlConnection.Close();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();

                throw;
            }

            return result;

        }
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

        //verification l'existance du projet
        public bool verif_projet(string _ANNEE_DEB, string _NOM_PROJET, string _CODE_MODULE)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                /* ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, NIVEAU_ETUDIANT, DUREE, SEMESTRE, PERIODE */
                string cmdQuery = "SELECT * FROM ESP_PROJET_NEW WHERE (ANNEE_DEB =:ANNEE_DEB) AND (NOM_PROJET = :NOM_PROJET) AND (CODE_MODULE=:CODE_MODULE)";

                OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                //DATE_SEANCE
                OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
                prmANNEE_DEB.Value = _ANNEE_DEB;
                myCommandAbsence.Parameters.Add(prmANNEE_DEB);

                //nom projet :NOM_PROJET
                OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET", OracleDbType.Varchar2);
                prmNOM_PROJET.Value = _NOM_PROJET;
                myCommandAbsence.Parameters.Add(prmNOM_PROJET);

                //code module _CODE_MODULE
                OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
                prmCODE_MODULE.Value = _CODE_MODULE;
                myCommandAbsence.Parameters.Add(prmCODE_MODULE);



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

        //verification l'existance du projet_par_groupe
        public bool verif_projet_par_groupe(string _ANNEE_DEB, string _NOM_PROJET, string _CODE_MODULE)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                /* ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, NIVEAU_ETUDIANT, DUREE, SEMESTRE, PERIODE */
                string cmdQuery = "SELECT * FROM ESP_PROJET_NEW WHERE (ANNEE_DEB =:ANNEE_DEB) AND (NOM_PROJET = :NOM_PROJET) AND (CODE_MODULE=:CODE_MODULE)";

                OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                //DATE_SEANCE
                OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
                prmANNEE_DEB.Value = _ANNEE_DEB;
                myCommandAbsence.Parameters.Add(prmANNEE_DEB);

                //nom projet :NOM_PROJET
                OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET", OracleDbType.Varchar2);
                prmNOM_PROJET.Value = _NOM_PROJET;
                myCommandAbsence.Parameters.Add(prmNOM_PROJET);

                //code module _CODE_MODULE
                OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
                prmCODE_MODULE.Value = _CODE_MODULE;
                myCommandAbsence.Parameters.Add(prmCODE_MODULE);

                //ID_GROUPE_PROJET
                //OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
                //prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
                //myCommandAbsence.Parameters.Add(prmID_GROUPE_PROJET);



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

        public List<ESP_PROJET> getIdproj(string _ANNEE_DEB, string _NOM_PROJET, string _CODE_MODULE)
        {
            List<ESP_PROJET> myList = new List<ESP_PROJET>();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                /* ANNEE_DEB, ID_PROJET, NOM_PROJET, CODE_MODULE, TYPE_PROJET, DESCRIPTION_PROJET, TECHNOLOGIES, METHODOLOGIE, NIVEAU_ETUDIANT, DUREE, SEMESTRE, PERIODE */
                string cmdQuery = "SELECT ESP_PROJET_NEW.* FROM ESP_PROJET_NEW WHERE (ANNEE_DEB =:ANNEE_DEB) AND (NOM_PROJET = :NOM_PROJET) AND (CODE_MODULE=:CODE_MODULE)";

                OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                //DATE_SEANCE
                OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
                prmANNEE_DEB.Value = _ANNEE_DEB;
                myCommandAbsence.Parameters.Add(prmANNEE_DEB);

                //nom projet :NOM_PROJET
                OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET", OracleDbType.Varchar2);
                prmNOM_PROJET.Value = _NOM_PROJET;
                myCommandAbsence.Parameters.Add(prmNOM_PROJET);

                //code module _CODE_MODULE
                OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
                prmCODE_MODULE.Value = _CODE_MODULE;
                myCommandAbsence.Parameters.Add(prmCODE_MODULE);


                mySqlConnection.Close();
                mySqlConnection.Open();
                using (OracleDataReader myReader = myCommandAbsence.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_PROJET>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_PROJET(myReader));
                        }
                    }
                }
                mySqlConnection.Close();

            }
            return myList;


        }
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------ */

        //update projet
        public bool update_esp_suivi_projet(string _ANNEE_DEB, string _ID_PROJET, string _NOM_PROJET, string _CODE_MODULE, string _TYPE_PROJET, string _DESCRIPTION_PROJET, string _TECHNOLOGIES, string _METHODOLOGIE, decimal _NIVEAU_ETUDIANT, decimal _DUREE, decimal _SEMESTRE, decimal _PERIODE)
        {
            
            bool result = false;

            string cmdQuery = "UPDATE ESP_PROJET_NEW SET ANNEE_DEB=:ANNEE_DEB, NOM_PROJET=:NOM_PROJET, CODE_MODULE=:CODE_MODULE, TYPE_PROJET=:TYPE_PROJET, DESCRIPTION_PROJET=:DESCRIPTION_PROJET, TECHNOLOGIES=:TECHNOLOGIES, METHODOLOGIE=:METHODOLOGIE, NIVEAU_ETUDIANT=:NIVEAU_ETUDIANT, DUREE=:DUREE, SEMESTRE=:SEMESTRE, PERIODE=:PERIODE WHERE ID_PROJET=:ID_PROJET";
               /* "UPDATE ESP_PROJET SET ID_PROJET=:ID_PROJET , NOM_PROJET=:NOM_PROJET , CODE_MODULE=:CODE_MODULE , TYPE_PROJET=:TYPE_PROJET"
                + "DESCRIPTION_PROJET=:DESCRIPTION_PROJET , DUREE_EN_MOIS=:DUREE_EN_MOIS , SEMESTRE_PROJET=:SEMESTRE_PROJET , PERIODE_PROJET=:PERIODE_PROJET"
                + "ETAT_PROJET=:ETAT_PROJET , TECHNIQUE_UTLISE=:TECHNIQUE_UTLISE , METHODOLOGIE=:METHODOLOGIE , NIVEAU_ETUDIANT=:NIVEAU_ETUDIANT"
                + "ANNEE_DEB=:ANNEE_DEB";*/

            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // Anne du debut du projet : _ANNEE_DEBUT
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            

            //le nom du projet _NOM_PROJET
            OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET", OracleDbType.Varchar2);
            prmNOM_PROJET.Value = _NOM_PROJET;
            myCommand.Parameters.Add(prmNOM_PROJET);

            //le code module : _CODE_MODULE
            OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
            prmCODE_MODULE.Value = _CODE_MODULE;
            myCommand.Parameters.Add(prmCODE_MODULE);

            //le type du projet : _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            //la description du projet :_DESCRIPTION_PROJET
            OracleParameter prmDESCRIPTION_PROJET = new OracleParameter(":DESCRIPTION_PROJET", OracleDbType.Varchar2);
            prmDESCRIPTION_PROJET.Value = _DESCRIPTION_PROJET;
            myCommand.Parameters.Add(prmDESCRIPTION_PROJET);

            //technique utilisé dans le projet : _TECHNOLOGIES
            OracleParameter prmTECHNIQUE_UTLISE = new OracleParameter(":TECHNOLOGIES", OracleDbType.Varchar2);
            prmTECHNIQUE_UTLISE.Value = _TECHNOLOGIES;
            myCommand.Parameters.Add(prmTECHNIQUE_UTLISE);


            //methodoligie utilisé dans le projet : _METHODOLOGIE
            OracleParameter prmMETHODOLOGIE = new OracleParameter(":METHODOLOGIE", OracleDbType.Varchar2);
            prmMETHODOLOGIE.Value = _METHODOLOGIE;
            myCommand.Parameters.Add(prmMETHODOLOGIE);

            // le  niveau de l'etudiant : _NIVEAU_ETUDIANT
            OracleParameter prmNIVEAU_ETUDIANT = new OracleParameter(":NIVEAU_ETUDIANT", OracleDbType.Int32);
            prmNIVEAU_ETUDIANT.Value = _NIVEAU_ETUDIANT;
            myCommand.Parameters.Add(prmNIVEAU_ETUDIANT);

            OracleParameter prmDUREE = new OracleParameter(":DUREE", OracleDbType.Int32);
            prmDUREE.Value = _DUREE;
            myCommand.Parameters.Add(prmDUREE);

            OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE", OracleDbType.Int32);
            prmSEMESTRE.Value = _SEMESTRE;
            myCommand.Parameters.Add(prmSEMESTRE);

            OracleParameter prmPERIODE = new OracleParameter(":PERIODE", OracleDbType.Int32);
            prmPERIODE.Value = _PERIODE;
            myCommand.Parameters.Add(prmPERIODE);

            // id du projet, _ID_PROJET
            OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            prmID_PROJET.Value = _ID_PROJET;
            myCommand.Parameters.Add(prmID_PROJET);

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

        //update projet par groupe
        public bool update_esp_suivi_projet(string _ANNEE_DEB, string _ID_PROJET, string _NOM_PROJET, string _CODE_MODULE, string _TYPE_PROJET, string _DESCRIPTION_PROJET, string _TECHNOLOGIES, string _METHODOLOGIE, decimal _NIVEAU_ETUDIANT, decimal _DUREE, decimal _SEMESTRE, decimal _PERIODE, string _ID_GROUPE_PROJET)
        {

            bool result = false;

            string cmdQuery = "UPDATE ESP_PROJET_NEW SET ANNEE_DEB=:ANNEE_DEB, NOM_PROJET=:NOM_PROJET, CODE_MODULE=:CODE_MODULE, TYPE_PROJET=:TYPE_PROJET, DESCRIPTION_PROJET=:DESCRIPTION_PROJET, TECHNOLOGIES=:TECHNOLOGIES, METHODOLOGIE=:METHODOLOGIE, NIVEAU_ETUDIANT=:NIVEAU_ETUDIANT, DUREE=:DUREE, SEMESTRE=:SEMESTRE, PERIODE=:PERIODE WHERE ID_PROJET=:ID_PROJET,ID_GROUPE_PROJET=:ID_GROUPE_PROJET";
            /* "UPDATE ESP_PROJET SET ID_PROJET=:ID_PROJET , NOM_PROJET=:NOM_PROJET , CODE_MODULE=:CODE_MODULE , TYPE_PROJET=:TYPE_PROJET"
             + "DESCRIPTION_PROJET=:DESCRIPTION_PROJET , DUREE_EN_MOIS=:DUREE_EN_MOIS , SEMESTRE_PROJET=:SEMESTRE_PROJET , PERIODE_PROJET=:PERIODE_PROJET"
             + "ETAT_PROJET=:ETAT_PROJET , TECHNIQUE_UTLISE=:TECHNIQUE_UTLISE , METHODOLOGIE=:METHODOLOGIE , NIVEAU_ETUDIANT=:NIVEAU_ETUDIANT"
             + "ANNEE_DEB=:ANNEE_DEB";*/

            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // Anne du debut du projet : _ANNEE_DEBUT
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);



            //le nom du projet _NOM_PROJET
            OracleParameter prmNOM_PROJET = new OracleParameter(":NOM_PROJET", OracleDbType.Varchar2);
            prmNOM_PROJET.Value = _NOM_PROJET;
            myCommand.Parameters.Add(prmNOM_PROJET);

            //le code module : _CODE_MODULE
            OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
            prmCODE_MODULE.Value = _CODE_MODULE;
            myCommand.Parameters.Add(prmCODE_MODULE);

            //le type du projet : _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            //la description du projet :_DESCRIPTION_PROJET
            OracleParameter prmDESCRIPTION_PROJET = new OracleParameter(":DESCRIPTION_PROJET", OracleDbType.Varchar2);
            prmDESCRIPTION_PROJET.Value = _DESCRIPTION_PROJET;
            myCommand.Parameters.Add(prmDESCRIPTION_PROJET);

            //technique utilisé dans le projet : _TECHNOLOGIES
            OracleParameter prmTECHNIQUE_UTLISE = new OracleParameter(":TECHNOLOGIES", OracleDbType.Varchar2);
            prmTECHNIQUE_UTLISE.Value = _TECHNOLOGIES;
            myCommand.Parameters.Add(prmTECHNIQUE_UTLISE);


            //methodoligie utilisé dans le projet : _METHODOLOGIE
            OracleParameter prmMETHODOLOGIE = new OracleParameter(":METHODOLOGIE", OracleDbType.Varchar2);
            prmMETHODOLOGIE.Value = _METHODOLOGIE;
            myCommand.Parameters.Add(prmMETHODOLOGIE);

            // le  niveau de l'etudiant : _NIVEAU_ETUDIANT
            OracleParameter prmNIVEAU_ETUDIANT = new OracleParameter(":NIVEAU_ETUDIANT", OracleDbType.Int32);
            prmNIVEAU_ETUDIANT.Value = _NIVEAU_ETUDIANT;
            myCommand.Parameters.Add(prmNIVEAU_ETUDIANT);

            OracleParameter prmDUREE = new OracleParameter(":DUREE", OracleDbType.Int32);
            prmDUREE.Value = _DUREE;
            myCommand.Parameters.Add(prmDUREE);

            OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE", OracleDbType.Int32);
            prmSEMESTRE.Value = _SEMESTRE;
            myCommand.Parameters.Add(prmSEMESTRE);

            OracleParameter prmPERIODE = new OracleParameter(":PERIODE", OracleDbType.Int32);
            prmPERIODE.Value = _PERIODE;
            myCommand.Parameters.Add(prmPERIODE);

            // id du projet, _ID_PROJET
            OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            prmID_PROJET.Value = _ID_PROJET;
            myCommand.Parameters.Add(prmID_PROJET);

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
        
        public List<ESP_PROJET> GetList(string codcl)
        {
            List<ESP_PROJET> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT * FROM  ESP_PROJET_NEW WHERE CODE_MODULE = '" + codcl + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_PROJET>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_PROJET(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        

        public ESP_PROJET(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_PROJET")))
            {

                _ID_PROJET = myReader.GetString(myReader.GetOrdinal("ID_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_PROJET")))
            {

                _NOM_PROJET = myReader.GetString(myReader.GetOrdinal("NOM_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_GROUPE_PROJET")))
            {

                _ID_GROUPE_PROJET = myReader.GetString(myReader.GetOrdinal("ID_GROUPE_PROJET"));
            }
            
        }

        public ESP_PROJET(string ID_PROJET, string NOM_PROJET, string ID_GROUPE_PROJET)
        {

            this._ID_PROJET = ID_PROJET;
            this._NOM_PROJET = NOM_PROJET;
            this._ID_GROUPE_PROJET = ID_GROUPE_PROJET;

        }

        public decimal inc_id_projet()
        {
            decimal x = 0;
            string cmdQuery = "SELECT COUNT(*) AS NB FROM ESP_PROJET_NEW";
            
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
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

        //incrimentation id groupe projet
        public decimal inc_id_groupe_projet2()
        {
            decimal x = 0;
            string cmdQuery = "SELECT COUNT(*) AS NB FROM ESP_GP_PROJET";
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
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



        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_PROJET> GetNNNN(string module, string classe, string typepg)
        {
            List<ESP_PROJET> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT DISTINCT ESP_PROJET_NEW.* FROM ESP_PROJET_NEW , ESP_GP_PROJET" +
                    " WHERE ESP_PROJET_NEW.CODE_MODULE = '" + module + "' AND ESP_PROJET_NEW.TYPE_PROJET='" + typepg + "' AND ESP_PROJET_NEW.CODE_CL='" + classe + "' ";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_PROJET>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_PROJET(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }
        
    }
}


