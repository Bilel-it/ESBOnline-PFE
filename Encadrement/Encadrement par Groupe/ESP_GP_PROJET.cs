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
    public class ESP_GP_PROJET
    {
        #region sing
        static ESP_GP_PROJET instance;
        static Object locker = new Object();
        public static ESP_GP_PROJET Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_GP_PROJET();
                    }

                    return ESP_GP_PROJET.instance;
                }
            }

        }
        private ESP_GP_PROJET() { }
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
        private string _ID_PROJET;
        private string _NOM_GROUPE;
        private string _SUJET;
        private decimal _NUM_GROUPE;
        private string _CODE_CL;
        private string _NOM_PROJET;


        public string ID_GROUPE_PROJET
        {
            get { return _ID_GROUPE_PROJET; }
            set { _ID_GROUPE_PROJET = value; }

        }

        public string ID_PROJET
        {
            get { return _ID_PROJET; }
            set { _ID_PROJET = value; }

        }

        public string NOM_GROUPE
        {
            get { return _NOM_GROUPE; }
            set { _NOM_GROUPE = value; }
        }

        public string SUJET
        {
            get { return _SUJET; }
            set { _SUJET = value; }
        }

        public decimal NUM_GROUPE
        {
            get { return _NUM_GROUPE; }
            set { _NUM_GROUPE = value; }
        }

        public string CODE_CL
        {
            get { return _CODE_CL; }
            set { _CODE_CL = value; }
        }

        public string NOM_PROJET
        {
            get { return _NOM_PROJET; }
            set { _NOM_PROJET = value; }
        }
        #endregion

        /*
        _ID_GROUPE_PROJET;
        _NOM_GROUPE;
        _SUJET;
         _NUM_GROUPE;
        _CODE_CL;
         */


        //creation d'un groupe du projet
        public bool create_groupe_projet_ESP(string _ID_GROUPE_PROJET, string _NOM_GROUPE, string _SUJET, decimal _NUM_GROUPE, string _CODE_CL)
        {
            //( string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ET,string _ID_ENS,string _CODE_CL,OracleDate _DATE_ENC,OracleTimeStamp _HEURE_DEB,OracleTimeStamp _HEURE_FIN,OracleTimeStamp _DUREE,decimal _AV_TECH,decimal _AV_ANG,decimal _AV_FR,decimal _AV_RAPPORT,decimal _AV_CC,string _COMPORTEMENT,string _REMARQUE_OBS,string _TRAVAUX_DEMANDE
            bool result = false;

            string cmdQuery = "INSERT INTO  ESP_GP_PROJET (ID_GROUPE_PROJET , NOM_GROUPE ,SUJET ,NUM_GROUPE ,CODE_CL) VALUES (:ID_GROUPE_PROJET , :NOM_GROUPE ,:SUJET ,:NUM_GROUPE ,:CODE_CL)";

            //execution du requette   
            Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // id du projet, _ID_PROJET
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);

            OracleParameter prmNOM_GROUPE = new OracleParameter(":NOM_GROUPE", OracleDbType.Varchar2);
            prmNOM_GROUPE.Value = _NOM_GROUPE;
            myCommand.Parameters.Add(prmNOM_GROUPE);

            OracleParameter prmSUJET = new OracleParameter(":SUJET", OracleDbType.Varchar2);
            prmSUJET.Value = _SUJET;
            myCommand.Parameters.Add(prmSUJET);

            OracleParameter prmNUM_GROUPE = new OracleParameter(":NUM_GROUPE", OracleDbType.Decimal);
            prmNUM_GROUPE.Value = _NUM_GROUPE;
            myCommand.Parameters.Add(prmNUM_GROUPE);

            OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
            prmCODE_CL.Value = _CODE_CL;
            myCommand.Parameters.Add(prmCODE_CL);

            

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

        //verif d'un groupe du projet
        public bool verif_Groupe_projet_ESP(string _NOM_GROUPE, decimal _NUM_GROUPE, string _CODE_CL)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                string cmdQuery = "SELECT * FROM ESP_GP_PROJET WHERE" +
                    "(NOM_GROUPE=:NOM_GROUPE)AND (NUM_GROUPE=:NUM_GROUPE) AND (CODE_CL=:CODE_CL)";
                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);

                //NOM_GROUPE
                OracleParameter prmNOM_GROUPE = new OracleParameter(":NOM_GROUPE", OracleDbType.Varchar2);
                prmNOM_GROUPE.Value = _NOM_GROUPE;
                myCommand.Parameters.Add(prmNOM_GROUPE);

                //NUMERO_GROUPE
                OracleParameter prmNUM_GROUPE = new OracleParameter(":NUM_GROUPE", OracleDbType.Decimal);
                prmNUM_GROUPE.Value = _NUM_GROUPE;
                myCommand.Parameters.Add(prmNUM_GROUPE);

                //NOM_GROUPE
                OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
                prmCODE_CL.Value = _CODE_CL;
                myCommand.Parameters.Add(prmCODE_CL);


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

        //update
        public bool update_Groupe_projet_ESp(string _ID_GROUPE_PROJET, string _NOM_GROUPE, string _SUJET, decimal _NUM_GROUPE, string _CODE_CL)
        {

            bool result = false;

            string cmdQuery = "UPDATE ESP_GP_PROJET SET " +
                "ID_ET=:ID_ET,ID_GROUPE_PROJET=:ID_GROUPE_PROJET,NOM_GROUPE=:NOM_GROUPE,DESCRIPTIO_GROUPE=:DESCRIPTIO_GROUPE,NOTE_ETUDIANT=:NOTE_ETUDIANT,NUMERO_GROUPE=:NUMERO_GROUP,ANNEE_DEB=:ANNEE_DEB";
            //execution du requette   
            Oracle.DataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            

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
        public ESP_GP_PROJET(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_GROUPE_PROJET")))
            {

                _ID_GROUPE_PROJET = myReader.GetString(myReader.GetOrdinal("ID_GROUPE_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_PROJET")))
            {

                _ID_PROJET = myReader.GetString(myReader.GetOrdinal("ID_PROJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_GROUPE")))
            {

                _NOM_GROUPE = myReader.GetString(myReader.GetOrdinal("NOM_GROUPE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("SUJET")))
            {

                _SUJET = myReader.GetString(myReader.GetOrdinal("SUJET"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NUM_GROUPE")))
            {

                _NUM_GROUPE = myReader.GetDecimal(myReader.GetOrdinal("NUM_GROUPE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_CL")))
            {

                _CODE_CL = myReader.GetString(myReader.GetOrdinal("CODE_CL"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_PROJET")))
            {

                _NOM_PROJET = myReader.GetString(myReader.GetOrdinal("NOM_PROJET"));
            }
            
        }

        //incrimentation id groupe projet
        public decimal inc_id_groupe_projet()
        {
            decimal x = 0;
            string cmdQuery = "SELECT COUNT(*) AS NB FROM ESP_GP_PROJET";
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

        //recuperer liste des groupe de projet
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_GP_PROJET> GetListGROUPE()
        {
            List<ESP_GP_PROJET> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT * from ESP_GP_PROJET";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_GP_PROJET>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_GP_PROJET(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }


        //recuperer liste des groupe par module, classe, type projet
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_GP_PROJET> GetGrouepByClasseModuleType(string module, string classe, string typepg)
        {
            List<ESP_GP_PROJET> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT ESP_GP_PROJET.*,ESP_PROJET_NEW.* FROM ESP_GP_PROJET INNER JOIN ESP_PROJET_NEW ON ESP_GP_PROJET.ID_GROUPE_PROJET = ESP_PROJET_NEW.ID_GROUPE_PROJET" +
                    " WHERE ESP_PROJET_NEW.CODE_MODULE = '" + module + "' AND ESP_PROJET_NEW.TYPE_PROJET='" + typepg + "' AND ESP_GP_PROJET.CODE_CL='"+classe+"'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_GP_PROJET>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_GP_PROJET(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }

        //recuperer liste des groupe par module type projet
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ESP_GP_PROJET> GetGrouepByModuleType(string module, string typepg)
        {
            List<ESP_GP_PROJET> myList = null;

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();

                string cmdQuery = "SELECT DISTINCT ESP_GP_PROJET.* , ESP_PROJET_NEW.*  FROM ESP_GP_PROJET INNER JOIN ESP_PROJET_NEW ON ESP_GP_PROJET.ID_GROUPE_PROJET = ESP_PROJET_NEW.ID_GROUPE_PROJET" +
                    " WHERE ESP_PROJET_NEW.CODE_MODULE = '" + module + "' AND ESP_PROJET_NEW.TYPE_PROJET='" + typepg + "'";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ESP_GP_PROJET>();
                        while (myReader.Read())
                        {
                            myList.Add(new ESP_GP_PROJET(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            }
            return myList;

        }




        //[DataObjectMethod(DataObjectMethodType.Select, true)]
        //public static List<ESP_GP_PROJET> GetNNNN(string module, string classe, string typepg)
        //{
        //    List<ESP_GP_PROJET> myList = null;

        //    using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
        //    {

        //        mySqlConnection.Open();

        //        string cmdQuery = "SELECT DISTINCT ESP_PROJET_NEW.* ,ESP_GP_PROJET.* FROM ESP_PROJET_NEW , ESP_GP_PROJET" +
        //            " WHERE ESP_PROJET_NEW.CODE_MODULE = '" + module + "' AND ESP_PROJET_NEW.TYPE_PROJET='" + typepg + "' AND ESP_PROJET_NEW.CODE_CL='" + classe + "' ";
        //        OracleCommand myCommand = new OracleCommand(cmdQuery);
        //        myCommand.Connection = mySqlConnection;
        //        myCommand.CommandType = CommandType.Text;

        //        using (OracleDataReader myReader = myCommand.ExecuteReader())
        //        {
        //            if (myReader.HasRows)
        //            {
        //                myList = new List<ESP_GP_PROJET>();
        //                while (myReader.Read())
        //                {
        //                    myList.Add(new ESP_GP_PROJET(myReader));
        //                }
        //            }
        //        }

        //        mySqlConnection.Close();
        //    }
        //    return myList;

        //}
    }
}
