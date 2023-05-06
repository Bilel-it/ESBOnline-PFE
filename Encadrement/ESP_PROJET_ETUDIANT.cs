using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using ESPSuiviEncadrement;

namespace ESPSuiviEncadrement
{
    public class ESP_PROJET_ETUDIANT
    {
        #region sing
        static ESP_PROJET_ETUDIANT instance;
        static Object locker = new Object();
        public static ESP_PROJET_ETUDIANT Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ESP_PROJET_ETUDIANT();
                    }

                    return ESP_PROJET_ETUDIANT.instance;
                }
            }

        }
        private ESP_PROJET_ETUDIANT() { }
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

        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        //crée un projet
        public bool create_esp_projet_etudiant(string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ET, OracleDate _DATE_DEBUT, string _ETAT,
            OracleDate _DATE_SOUTENANCE, decimal _NOTE_SOUTENANCE, string _OBSERVATION)
        {
            bool result = false;

            string cmdQuery = "INSERT INTO ESP_PROJET_ETUDIANT   (ID_PROJET,ANNEE_DEB,TYPE_PROJET,ID_ET,DATE_DEBUT,ETAT,DATE_SOUTENANCE,NOTE_SOUTENANCE,OBSERVATION)" +
            "VALUES     (:ID_PROJET,:ANNEE_DEB,:TYPE_PROJET,:ID_ET,:DATE_DEBUT,:ETAT,:DATE_SOUTENANCE,:NOTE_SOUTENANCE,:OBSERVATION)";
             //ID_PROJET, ANNEE_DEB, TYPE_PROJET, ID_ET, DATE_DEBUT, ETAT, DATE_SOUTENANCE, NOTE_SOUTENANCE, OBSERVATION
            //execution du requette   
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // id du projet, _ID_PROJET
            OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            prmID_PROJET.Value = _ID_PROJET;
            myCommand.Parameters.Add(prmID_PROJET);

            // _ANNEE_DEB
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            // _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            //_ID_ET
            OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            prmID_ET.Value = _ID_ET;
            myCommand.Parameters.Add(prmID_ET);

            //_DATE_DEB
            OracleParameter prmDATE_DEBUT = new OracleParameter(":DATE_DEBUT", OracleDbType.Date);
            prmDATE_DEBUT.Value = _DATE_DEBUT;
            myCommand.Parameters.Add(prmDATE_DEBUT);

            //_ETAT
            OracleParameter prmETAT = new OracleParameter(":ETAT", OracleDbType.Varchar2);
            prmETAT.Value = _ETAT;
            myCommand.Parameters.Add(prmETAT);

            //_DATE_SOUTENANCE
            OracleParameter prmDATE_SOUTENANCE = new OracleParameter(":DATE_SOUTENANCE", OracleDbType.Date);
            prmDATE_SOUTENANCE.Value = _DATE_SOUTENANCE;
            myCommand.Parameters.Add(prmDATE_SOUTENANCE);

            //_NOTE_SOUTENANCE
            OracleParameter prmNOTE_SOUTENANCE = new OracleParameter(":NOTE_SOUTENANCE", OracleDbType.Decimal);
            prmNOTE_SOUTENANCE.Value = _NOTE_SOUTENANCE;
            myCommand.Parameters.Add(prmNOTE_SOUTENANCE);

            //_OBSERVATION
            OracleParameter prmOBSERVATION = new OracleParameter(":OBSERVATION", OracleDbType.Varchar2);
            prmOBSERVATION.Value = _OBSERVATION;
            myCommand.Parameters.Add(prmOBSERVATION);
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

        //mise a jour un projet
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        public bool update_esp_projet_etudiant(string _ID_PROJET, string _ANNEE_DEB, string _TYPE_PROJET, string _ID_ET, OracleDate _DATE_DEBUT, string _ETAT,
            OracleDate _DATE_SOUTENANCE, decimal _NOTE_SOUTENANCE, string _OBSERVATION)
        {
            bool resultUpdate = false;

            string cmdQuery = "UPDATE ESP_PROJET_ETUDIANT SET ID_PROJET=:ID_PROJET,ANNEE_DEB=:ANNEE_DEB,TYPE_PROJET=:TYPE_PROJET,ID_ET=:ID_ET,DATE_DEBUT=:DATE_DEBUT,ETAT=:ETAT,DATE_SOUTENANCE=:DATE_SOUTENANCE,NOTE_SOUTENANCE=:NOTE_SOUTENANCE,OBSERVATION=:OBSERVATION";
                /*"UPDATE ESP_PROJET SET ID_PROJET=:ID_PROJET , ANNEE_DEB=:ANNEE_DEB , TYPE_PROJET=:TYPE_PROJET , ID_ET=:ID_ET"
                + "DATE_DEB=:DATE_DEB , ETAT=:ETAT , DATE_SOUTENANCE=:DATE_SOUTENANCE , NOTE_SOUTENANCE=:NOTE_SOUTENANCE ,OBSERVATION=:OBSERVATION";*/

            //execution du requette   
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            // id du projet, _ID_PROJET
            OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
            prmID_PROJET.Value = _ID_PROJET;
            myCommand.Parameters.Add(prmID_PROJET);

            // _ANNEE_DEB
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            // _TYPE_PROJET
            OracleParameter prmTYPE_PROJET = new OracleParameter(":TYPE_PROJET", OracleDbType.Varchar2);
            prmTYPE_PROJET.Value = _TYPE_PROJET;
            myCommand.Parameters.Add(prmTYPE_PROJET);

            //_ID_ET
            OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            prmID_ET.Value = _ID_ET;
            myCommand.Parameters.Add(prmID_ET);

            //_DATE_DEB
            OracleParameter prmDATE_DEBUT = new OracleParameter(":DATE_DEBUT", OracleDbType.Date);
            prmDATE_DEBUT.Value = _DATE_DEBUT;
            myCommand.Parameters.Add(prmDATE_DEBUT);

            //_ETAT
            OracleParameter prmETAT = new OracleParameter(":ETAT", OracleDbType.Varchar2);
            prmETAT.Value = _ETAT;
            myCommand.Parameters.Add(prmETAT);

            //_DATE_SOUTENANCE
            OracleParameter prmDATE_SOUTENANCE = new OracleParameter(":DATE_SOUTENANCE", OracleDbType.Date);
            prmDATE_SOUTENANCE.Value = _DATE_SOUTENANCE;
            myCommand.Parameters.Add(prmDATE_SOUTENANCE);

            //_NOTE_SOUTENANCE
            OracleParameter prmNOTE_SOUTENANCE = new OracleParameter(":NOTE_SOUTENANCE", OracleDbType.Decimal);
            prmNOTE_SOUTENANCE.Value = _NOTE_SOUTENANCE;
            myCommand.Parameters.Add(prmNOTE_SOUTENANCE);

            //_OBSERVATION
            OracleParameter prmOBSERVATION = new OracleParameter(":OBSERVATION", OracleDbType.Varchar2);
            prmOBSERVATION.Value = _OBSERVATION;
            myCommand.Parameters.Add(prmOBSERVATION);

            try
            {
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                resultUpdate = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }
            return resultUpdate;
        }

        //verifier un projet projet
        /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        public bool verif_projet(string _ID_PROJET, string _ANNEE_DEB, string _ID_ET)
        {
            bool exist = false;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                string cmdQuery = "SELECT * FROM ESP_PROJET_ETUDIANT WHERE" +
                   "(ID_PROJET = :ID_PROJET) AND (ANNEE_DEB = :ANNEE_DEB) AND (ID_ET = :ID_ET)";
                OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                // id du projet, _ID_PROJET
                OracleParameter prmID_PROJET = new OracleParameter(":ID_PROJET", OracleDbType.Varchar2);
                prmID_PROJET.Value = _ID_PROJET;
                myCommandAbsence.Parameters.Add(prmID_PROJET);

                // _ANNEE_DEB
                OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
                prmANNEE_DEB.Value = _ANNEE_DEB;
                myCommandAbsence.Parameters.Add(prmANNEE_DEB);

                //_ID_ET
                OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
                prmID_ET.Value = _ID_ET;
                myCommandAbsence.Parameters.Add(prmID_ET);

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

         /* ------------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        //delete un encadrement du projet
        public bool delete_encadrement_ESP(string _ID_PROJET)
        {
             bool delete = false;
             using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
             {
                 string cmdQuery = "DELETE * FROM ESP_PROJET_ETUDIANT WHERE" +
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
        }
    }

  
