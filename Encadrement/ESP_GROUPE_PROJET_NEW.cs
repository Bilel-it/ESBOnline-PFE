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
    public class ESP_GROUPE_PROJET_NEW
    {
        #region sing
        static ESP_GROUPE_PROJET_NEW instance;
        static Object locker = new Object();
        public static ESP_GROUPE_PROJET_NEW Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_GROUPE_PROJET_NEW();
                    }

                    return ESP_GROUPE_PROJET_NEW.instance;
                }
            }

        }
        private ESP_GROUPE_PROJET_NEW() { }
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
        private decimal _NUM_PROJET_GROUPE;
        private string _ETAT;
        private string _REMARQUE;
        private string _ID_PROJET;



        public string ID_GROUPE_PROJET
        {
            get { return _ID_GROUPE_PROJET; }
            set { _ID_GROUPE_PROJET = value; }

        }
        public decimal NUM_PROJET_GROUPE
        {
            get { return _NUM_PROJET_GROUPE; }
            set { _NUM_PROJET_GROUPE = value; }
        }
        public string ETAT
        {
            get { return _ETAT; }
            set { _ETAT = value; }

        }
        public string REMARQUE
        {
            get { return _REMARQUE; }
            set { _REMARQUE = value; }

        }
        public string ID_PROJET
        {
            get { return _ID_PROJET; }
            set { _ID_PROJET = value; }

        }
        #endregion public private methodes

        /*******************************************************************creation*******************************************/
        public bool create_Groupe_PROJET(string _ID_GROUPE_PROJET,decimal _NUM_PROJET_GROUPE,string _ETAT , string _REMARQUE , string _ID_PROJET)
        {

            bool result = false;

            string cmdQuery = "INSERT INTO  ESP_GROUPE_PROJET_NEW (ID_GROUPE_PROJET,NUM_PROJET_GROUPE,ETAT,REMARQUE,ID_PROJET) VALUES (:ID_GROUPE_PROJET,:NUM_PROJET_GROUPE,:ETAT,:REMARQUE,:ID_PROJET)";
            //execution du requette   
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            //ID_GROUPE_PROJET
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);

            //NUM_PROJET_GROUPE
             OracleParameter prmNUM_PROJET_GROUPE = new OracleParameter(":NUM_PROJET_GROUPE", OracleDbType.Varchar2);
            prmNUM_PROJET_GROUPE.Value = _NUM_PROJET_GROUPE;
            myCommand.Parameters.Add(prmNUM_PROJET_GROUPE);

            //ETAT
             OracleParameter prmETAT = new OracleParameter(":ETAT", OracleDbType.Varchar2);
            prmETAT.Value = _ETAT;
            myCommand.Parameters.Add(prmETAT);

            //REMARQUE
             OracleParameter prmREMARQUE = new OracleParameter(":REMARQUE", OracleDbType.Varchar2);
            prmREMARQUE.Value = _REMARQUE;
            myCommand.Parameters.Add(prmREMARQUE);

            //ID_PROJET
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

        /*******************************************************************verfication************************************/
        public bool verif_Groupe_projet(string _ID_GROUPE_PROJET, decimal _NUM_PROJET_GROUPE, string _ETAT, string _REMARQUE, string _ID_PROJET)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                //ID_GROUPE_PROJET,NUM_PROJET_GROUPE,ETAT,REMARQUE,ID_PROJET
                string cmdQuery = "SELECT * FROM ESP_GROUPE_PROJET_NEW WHERE" +
                    "(ID_GROUPE_PROJET =:ID_GROUPE_PROJET) AND (NUM_PROJET_GROUPE =:NUM_PROJET_GROUPE) AND (ETAT=:ETAT)AND (REMARQUE=:REMARQUE)AND (ID_PROJET=:ID_PROJET)";
                OracleCommand myCommand = new OracleCommand(cmdQuery, mySqlConnection);


                //ID_GROUPE_PROJET
                OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
                prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
                myCommand.Parameters.Add(prmID_GROUPE_PROJET);

                //NUM_PROJET_GROUPE
                OracleParameter prmNUM_PROJET_GROUPE = new OracleParameter(":NUM_PROJET_GROUPE", OracleDbType.Varchar2);
                prmNUM_PROJET_GROUPE.Value = _NUM_PROJET_GROUPE;
                myCommand.Parameters.Add(prmNUM_PROJET_GROUPE);

                //ETAT
                OracleParameter prmETAT = new OracleParameter(":ETAT", OracleDbType.Varchar2);
                prmETAT.Value = _ETAT;
                myCommand.Parameters.Add(prmETAT);

                //REMARQUE
                OracleParameter prmREMARQUE = new OracleParameter(":REMARQUE", OracleDbType.Varchar2);
                prmREMARQUE.Value = _REMARQUE;
                myCommand.Parameters.Add(prmREMARQUE);

                //ID_PROJET
                OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
                prmID_PROJET.Value = _ID_PROJET;
                myCommand.Parameters.Add(prmID_PROJET);
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


        /********************************************************************update****************************************/

        public bool update_Groupe_PROJET(string _ID_GROUPE_PROJET, decimal _NUM_PROJET_GROUPE, string _ETAT, string _REMARQUE, string _ID_PROJET)
        {

            bool result = false;


            //ID_GROUPE_PROJET,NUM_PROJET_GROUPE,ETAT,REMARQUE,ID_PROJET
            string cmdQuery = "UPDATE ESP_GROUPE_ETUDIANT SET " +
                "ID_GROUPE_PROJET=:ID_GROUPE_PROJET,NUM_PROJET_GROUPE=:NUM_PROJET_GROUPE,ETAT=:ETAT,REMARQUE=:REMARQUE,ID_PROJET=:ID_PROJET";
            //execution du requette   
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            //ID_GROUPE_PROJET
            OracleParameter prmID_GROUPE_PROJET = new OracleParameter(":ID_GROUPE_PROJET", OracleDbType.Varchar2);
            prmID_GROUPE_PROJET.Value = _ID_GROUPE_PROJET;
            myCommand.Parameters.Add(prmID_GROUPE_PROJET);

            //NUM_PROJET_GROUPE
            OracleParameter prmNUM_PROJET_GROUPE = new OracleParameter(":NUM_PROJET_GROUPE", OracleDbType.Varchar2);
            prmNUM_PROJET_GROUPE.Value = _NUM_PROJET_GROUPE;
            myCommand.Parameters.Add(prmNUM_PROJET_GROUPE);

            //ETAT
            OracleParameter prmETAT = new OracleParameter(":ETAT", OracleDbType.Varchar2);
            prmETAT.Value = _ETAT;
            myCommand.Parameters.Add(prmETAT);

            //REMARQUE
            OracleParameter prmREMARQUE = new OracleParameter(":REMARQUE", OracleDbType.Varchar2);
            prmREMARQUE.Value = _REMARQUE;
            myCommand.Parameters.Add(prmREMARQUE);

            //ID_PROJET
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

        /***********************************************************************************************************************/
        
          
    }
}
