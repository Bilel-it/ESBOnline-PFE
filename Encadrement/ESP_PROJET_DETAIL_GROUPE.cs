using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.ComponentModel;

namespace ESPSuiviEncadrement
{
    public class ESP_PROJET_DETAIL_GROUPE
    {
        #region sing
        static ESP_PROJET_DETAIL_GROUPE instance;
        static Object locker = new Object();
        public static ESP_PROJET_DETAIL_GROUPE Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_PROJET_DETAIL_GROUPE();
                    }

                    return ESP_PROJET_DETAIL_GROUPE.instance;
                }
            }

        }
        private ESP_PROJET_DETAIL_GROUPE() { }
        #endregion sing
        #region public private methodes


        private string _ID_PROJET;

        public string ID_PROJET
        {
            get { return _ID_PROJET; }
            set { _ID_PROJET = value; }

        }

        private string _NOM_PROJET;

        public string NOM_PROJET
        {
            get { return _NOM_PROJET; }
            set { _NOM_PROJET = value; }
        }

        private decimal _DUREE;

        public decimal DUREE
        {
            get { return _DUREE; }
            set { _DUREE = value; }
        }

        private string _TECHNOLOGIES;

        public string TECHNOLOGIES
        {
            get { return _TECHNOLOGIES; }
            set { _TECHNOLOGIES = value; }
        }

        private string _METHODOLOGIE;

        public string METHODOLOGIE
        {
            get { return _METHODOLOGIE; }
            set { _METHODOLOGIE = value; }
        }
        private string _TYPE_PROJET;
        public string TYPE_PROJET
        {
            get { return _TYPE_PROJET; }
            set { _TYPE_PROJET = value; }
        }

        private string _DESCRIPTION_PROJET;
        public string DESCRIPTION_PROJET
         {
             get { return _DESCRIPTION_PROJET; }
             set { _DESCRIPTION_PROJET = value; }
         }

         private decimal _PERIODE;
         public decimal PERIODE
         {
             get { return _PERIODE; }
             set { _PERIODE = value; }
         }
         private decimal _SEMESTRE;
         public decimal SEMESTRE
         {
             get { return _SEMESTRE; }
             set { _SEMESTRE = value; }
         }
         private decimal _NIVEAU_ETUDIANT;
         public decimal NIVEAU_ETUDIANT
         {
             get { return _NIVEAU_ETUDIANT; }
             set { NIVEAU_ETUDIANT = value; }
         }

         private string _ID_GROUPE_PROJET;
         public string ID_GROUPE_PROJET
         {
             get { return _ID_GROUPE_PROJET; }
             set { _ID_GROUPE_PROJET = value; }
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


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_PROJET_DETAIL_GROUPE> GetProj_Groupe(string id)
        {
            List<ESP_PROJET_DETAIL_GROUPE> myList = null;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT * FROM   ESP_PROJET_NEW WHERE ID_PROJET = '" + id + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {

                        myList = new List<ESP_PROJET_DETAIL_GROUPE>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_PROJET_DETAIL_GROUPE(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_PROJET_DETAIL_GROUPE> GetProjEtudiantClass_Groupe(string id, string codecl, string typep)
        {
            List<ESP_PROJET_DETAIL_GROUPE> myList = null;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_PROJET_NEW.* FROM ESP_PROJET_NEW INNER JOIN ESP_ENCADREMENT_GROUPE ON ESP_PROJET_NEW.ID_PROJET = ESP_ENCADREMENT_GROUPE.ID_PROJET AND ESP_PROJET_NEW.ANNEE_DEB = ESP_ENCADREMENT_GROUPE.ANNEE_DEB AND ESP_PROJET_NEW.TYPE_PROJET = ESP_ENCADREMENT_GROUPE.TYPE_PROJET WHERE ESP_ENCADREMENT_GROUPE.ID_ET ='" + id + "' AND ESP_ENCADREMENT_GROUPE.CODE_CL ='" + codecl + "' AND ESP_ENCADREMENT_GROUPE.TYPE_PROJET = '" + typep + "' AND ESP_PROJET_NEW.ID_GROUPE_PROJET IS NOT NULL AND ESP_ENCADREMENT.COMPORTEMENT IS NULL";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {

                        myList = new List<ESP_PROJET_DETAIL_GROUPE>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_PROJET_DETAIL_GROUPE(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_PROJET_DETAIL_GROUPE> GetProjEtudiant_Groupe(string id, string typep)
        {
            List<ESP_PROJET_DETAIL_GROUPE> myList = null;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_PROJET_NEW.* FROM ESP_PROJET_NEW, ESP_ENCADREMENT_GROUPE WHERE ESP_ENCADREMENT_GROUPE.ID_GROUPE_PROJET=ESP_PROJET_NEW.ID_GROUPE_PROJET AND ESP_ENCADREMENT_GROUPE.ID_ET ='" + id + "' AND ESP_ENCADREMENT_GROUPE.TYPE_PROJET = '" + typep + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {

                        myList = new List<ESP_PROJET_DETAIL_GROUPE>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_PROJET_DETAIL_GROUPE(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }


        
        public string GetIDProjGroupe(string NOM_PROJET)
        {
            string ID_PROJET = null;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT ESP_PROJET_NEW.ID_PROJET FROM ESP_PROJET_NEW WHERE ESP_PROJET_NEW.NOM_PROJET ='" + NOM_PROJET + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        ID_PROJET = myReader.GetString(myReader.GetOrdinal("ID_PROJET"));
                        return ID_PROJET;
                    }
                }

                mySqlConnection.Close();
            }
            return ID_PROJET;

        }



        public bool update_esp_suivi_projet_groupe(string _ANNEE_DEB, string _ID_PROJET, string _NOM_PROJET, string _CODE_MODULE, string _TYPE_PROJET, string _DESCRIPTION_PROJET, string _TECHNOLOGIES, string _METHODOLOGIE, decimal _NIVEAU_ETUDIANT, decimal _DUREE, decimal _SEMESTRE, decimal _PERIODE, string _ID_GROUPE_PROJET)
        {

            bool result = false;

            string cmdQuery = "UPDATE ESP_PROJET_NEW SET ANNEE_DEB=:ANNEE_DEB, ID_PROJET=:ID_PROJET, NOM_PROJET=:NOM_PROJET, CODE_MODULE=:CODE_MODULE, TYPE_PROJET=:TYPE_PROJET, DESCRIPTION_PROJET=:DESCRIPTION_PROJET, TECHNOLOGIES=:TECHNOLOGIES, METHODOLOGIE=:METHODOLOGIE, NIVEAU_ETUDIANT=:NIVEAU_ETUDIANT, DUREE=:DUREE, SEMESTRE=:SEMESTRE, PERIODE=:PERIODE , ID_GROUPE_PROJET=:ID_GROUPE_PROJET";
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

            // id du projet, _ID_PROJET
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

        public ESP_PROJET_DETAIL_GROUPE(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_PROJET")))
            {

                _ID_PROJET = myReader.GetString(myReader.GetOrdinal("ID_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("TYPE_PROJET")))
            {

                _TYPE_PROJET = myReader.GetString(myReader.GetOrdinal("TYPE_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_PROJET")))
            {

                _NOM_PROJET = myReader.GetString(myReader.GetOrdinal("NOM_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("DUREE")))
            {

                _DUREE = myReader.GetDecimal(myReader.GetOrdinal("DUREE"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("TECHNOLOGIES")))
            {

                _TECHNOLOGIES = myReader.GetString(myReader.GetOrdinal("TECHNOLOGIES"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("METHODOLOGIE")))
            {

                _METHODOLOGIE = myReader.GetString(myReader.GetOrdinal("METHODOLOGIE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("DESCRIPTION_PROJET")))
            {

                _DESCRIPTION_PROJET = myReader.GetString(myReader.GetOrdinal("DESCRIPTION_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("PERIODE")))
            {

                _PERIODE = myReader.GetDecimal(myReader.GetOrdinal("PERIODE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("SEMESTRE")))
            {

                _SEMESTRE = myReader.GetDecimal(myReader.GetOrdinal("SEMESTRE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NIVEAU_ETUDIANT")))
            {

                _NIVEAU_ETUDIANT = myReader.GetDecimal(myReader.GetOrdinal("NIVEAU_ETUDIANT"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_GROUPE_PROJET")))
            {

                _ID_GROUPE_PROJET = myReader.GetString(myReader.GetOrdinal("ID_GROUPE_PROJET"));
            }
            
        }
               
        public ESP_PROJET_DETAIL_GROUPE(string ID_PROJET, string NOM_PROJET)
        {

            this._ID_PROJET = ID_PROJET;
            this._TYPE_PROJET = TYPE_PROJET;
            this._NOM_PROJET = NOM_PROJET;
            this._DUREE = DUREE ; 
            this._TECHNOLOGIES = TECHNOLOGIES;
            this._METHODOLOGIE = METHODOLOGIE;
            this._DESCRIPTION_PROJET = DESCRIPTION_PROJET;
            this._PERIODE = PERIODE;
            this._SEMESTRE = SEMESTRE;
            this._NIVEAU_ETUDIANT = NIVEAU_ETUDIANT;
            this._ID_GROUPE_PROJET = ID_GROUPE_PROJET;

        }



        

       


    }
}