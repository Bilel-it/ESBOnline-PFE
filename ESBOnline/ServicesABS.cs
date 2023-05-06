using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace ABSEsprit
{
    public class ServicesABS
    {

        #region sing

        static ServicesABS instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static ServicesABS Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ServicesABS();
                    }

                    return ServicesABS.instance;
                }
            }

        }
        private ServicesABS() { }

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
            // myTrans = mySqlConnection.BeginTransaction();


        }

        public bool Save_esp_entete_ABS(string _CODE_MODULE, string _ANNEE_DEB, decimal _SEMESTRE, string _CODE_CL, decimal _NUM_SEANCE, string _DATE_SEANCE, string _ID_ENS, string _UTILISATEUR)
        {
            bool result = false;

            string cmdQuery = "INSERT INTO ESP_ENTETE_ABSENCE   (CODE_MODULE, ANNEE_DEB, SEMESTRE, CODE_CL, NUM_SEANCE, DATE_SEANCE, ID_ENS,  UTILISATEUR) VALUES     ('" + _CODE_MODULE + "', '" + _ANNEE_DEB + "', '" + _SEMESTRE + "', '" + _CODE_CL + "', '" + _NUM_SEANCE + "',to_date('" + _DATE_SEANCE + "','dd/MM/yy'), '" + _ID_ENS + "', '" + _UTILISATEUR + "')";
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;



            OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
            prmCODE_MODULE.Value = _CODE_MODULE;
            myCommand.Parameters.Add(prmCODE_MODULE);


            //ANNEE_DEB
            OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            prmANNEE_DEB.Value = _ANNEE_DEB;
            myCommand.Parameters.Add(prmANNEE_DEB);

            //SEMESTRE

            OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE", OracleDbType.Decimal);
            prmSEMESTRE.Value = _SEMESTRE;
            myCommand.Parameters.Add(prmSEMESTRE);

            //_CODE_CL

            OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
            prmCODE_CL.Value = _CODE_CL;
            myCommand.Parameters.Add(prmCODE_CL);


            // _NUM_SEANCE

            OracleParameter prmNUM_SEANCE = new OracleParameter(":NUM_SEANCE", OracleDbType.Decimal);
            prmNUM_SEANCE.Value = _NUM_SEANCE;
            myCommand.Parameters.Add(prmNUM_SEANCE);

            // _DATE_SEANCE

            OracleParameter prmDATE_SEANCE = new OracleParameter(":DATE_SEANCE", OracleDbType.Date);
            prmDATE_SEANCE.Value = _DATE_SEANCE;
            myCommand.Parameters.Add(prmDATE_SEANCE);

            // _ID_ENS, 

            OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
            prmID_ENS.Value = _ID_ENS;
            myCommand.Parameters.Add(prmID_ENS);

            // _UTILISATEUR

            OracleParameter prmUTILISATEUR = new OracleParameter("UTILISATEUR", OracleDbType.Varchar2);
            prmUTILISATEUR.Value = _UTILISATEUR;
            myCommand.Parameters.Add(prmUTILISATEUR);
            try
            {
                myCommand.ExecuteNonQuery();
                //myCommandnote.ExecuteNonQuery();
                // myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }

            //bool result = myCommand.ExecuteNonQuery() > 0;
            //mySqlConnection.Close();

            return result;

        }

        public bool Save_esp_ABS(string _ID_ET, string _CODE_MODULE, string _CODE_CL, string _ANNEE_DEB, decimal _NUM_SEANCE, string _DATE_SEANCE, string _ID_ENS, string _UTILISATEUR, decimal _SEMESTRE, string _JUSTIFICATION, string _CODE_JUSTIF, string _LIB_JUSTIF, string _A_CONVOQUER, string _OBSERVATION)
        {
            bool result = false;

            string cmdQuery = "INSERT INTO ESP_ABSENCE_NEW  (ID_ET, CODE_MODULE, CODE_CL, ANNEE_DEB, NUM_SEANCE, DATE_SEANCE, ID_ENS, UTILISATEUR, SEMESTRE, JUSTIFICATION, CODE_JUSTIF, LIB_JUSTIF,  A_CONVOQUER, OBSERVATION) VALUES    ('"+_ID_ET+"', '"+_CODE_MODULE+"', '"+_CODE_CL+"', '"+_ANNEE_DEB+"', '"+_NUM_SEANCE+"',to_date('"+_DATE_SEANCE+"','dd/MM/yy'), '"+_ID_ENS+"', '"+_UTILISATEUR+"','"+ _SEMESTRE+"', '"+_JUSTIFICATION+"', '"+_CODE_JUSTIF+"','"+ _LIB_JUSTIF+"',  '"+_A_CONVOQUER+"','" +_OBSERVATION+"')";
            OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

           
            //OracleParameter prmID_ET = new OracleParameter(":ID_ET", OracleDbType.Varchar2);
            //prmID_ET.Value = _ID_ET;
            //myCommand.Parameters.Add(prmID_ET);

 
            //OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
            //prmCODE_MODULE.Value = _CODE_MODULE;
            //myCommand.Parameters.Add(prmCODE_MODULE);

          
            //OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
            //prmCODE_CL.Value = _CODE_CL;
            //myCommand.Parameters.Add(prmCODE_CL);

     
            //OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            //prmANNEE_DEB.Value = _ANNEE_DEB;
            //myCommand.Parameters.Add(prmANNEE_DEB);


            //OracleParameter prmNUM_SEANCE = new OracleParameter(":NUM_SEANCE", OracleDbType.Decimal);
            //prmNUM_SEANCE.Value = _NUM_SEANCE;
            //myCommand.Parameters.Add(prmNUM_SEANCE);

            
   

            //OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
            //prmID_ENS.Value = _ID_ENS;
            //myCommand.Parameters.Add(prmID_ENS);

      

            //OracleParameter prmUTILISATEUR = new OracleParameter("UTILISATEUR", OracleDbType.Varchar2);
            //prmUTILISATEUR.Value = _UTILISATEUR;
            //myCommand.Parameters.Add(prmUTILISATEUR);


            //OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE", OracleDbType.Decimal);
            //prmSEMESTRE.Value = _SEMESTRE;
            //myCommand.Parameters.Add(prmSEMESTRE);

        

            //OracleParameter prmJUSTIFICATION = new OracleParameter("JUSTIFICATION", OracleDbType.Varchar2);
            //prmJUSTIFICATION.Value = _JUSTIFICATION;
            //myCommand.Parameters.Add(prmJUSTIFICATION);

        

            //OracleParameter prmCODE_JUSTIF = new OracleParameter("CODE_JUSTIF", OracleDbType.Varchar2);
            //prmCODE_JUSTIF.Value = _CODE_JUSTIF;
            //myCommand.Parameters.Add(prmCODE_JUSTIF);

     

            //OracleParameter prmLIB_JUSTIF = new OracleParameter("LIB_JUSTIF", OracleDbType.Varchar2);
            //prmLIB_JUSTIF.Value = _LIB_JUSTIF;
            //myCommand.Parameters.Add(prmLIB_JUSTIF);



            //OracleParameter prmA_CONVOQUER = new OracleParameter("A_CONVOQUER", OracleDbType.Varchar2);
            //prmA_CONVOQUER.Value = _A_CONVOQUER;
            //myCommand.Parameters.Add(prmA_CONVOQUER);

 

            //OracleParameter prmOBSERVATION = new OracleParameter("OBSERVATION", OracleDbType.Varchar2);
            //prmOBSERVATION.Value = _OBSERVATION;
            //myCommand.Parameters.Add(prmOBSERVATION);

            try
            {
                myCommand.ExecuteNonQuery();
                //myCommandnote.ExecuteNonQuery();
                // myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }

            //bool result = myCommand.ExecuteNonQuery() > 0;
            //mySqlConnection.Close();

            return result;
        }

        public bool Save_esp_ONBSE_ABS(string id_et, string annee_deb, string code_cl, string code_module, string idens, string dateobs, string obs)
        {
            bool result = false;

            string cmdQuery = "INSERT INTO ESP_OBSERVATION_ETUDIANT (ID_ET, ANNEE_DEB, CODE_CL, CODE_MODULE, ID_ENS, DATE_OBS, OBSERVATION) VALUES ('" + id_et + "', '" + annee_deb + "', '" + code_cl + "', '" + code_module + "', '" + idens + "', TO_DATE('" + dateobs + "','dd/MM/yy'), '" + obs + "')";

        OracleCommand myCommand = new OracleCommand(cmdQuery);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;


            try
            {
                myCommand.ExecuteNonQuery();
                //myCommandnote.ExecuteNonQuery();
                // myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }

            //bool result = myCommand.ExecuteNonQuery() > 0;
            //mySqlConnection.Close();

            return result;

        }

        public bool verifAbsence(string _CODE_MODULE, string _ID_ENS, string _CODE_CL, decimal _NUM_SEANCE, string _DATE_SEANCE)
        {
            bool exist = false;


            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();


                string cmdQuery = "SELECT * FROM ESP_ENTETE_ABSENCE WHERE(CODE_MODULE = :CODE_MODULE) AND (ID_ENS = :ID_ENS) AND (CODE_CL = :CODE_CL) AND (NUM_SEANCE = :NUM_SEANCE) AND (to_date(DATE_SEANCE ,'dd/MM/yy') =to_date('" + _DATE_SEANCE + "','dd/MM/yy'))";

                OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);

                //prmCODE_MODULEabsence

                OracleParameter prmCODE_MODULEabsence = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
                prmCODE_MODULEabsence.Value = _CODE_MODULE;
                myCommandAbsence.Parameters.Add(prmCODE_MODULEabsence);

                //ID_ENSabsence
                OracleParameter prmID_ENSabsence = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
                prmID_ENSabsence.Value = _ID_ENS;

                myCommandAbsence.Parameters.Add(prmID_ENSabsence);


                //CODE_CLabsence
                OracleParameter prmCODE_CLabsence = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
                prmCODE_CLabsence.Value = _CODE_CL;
                myCommandAbsence.Parameters.Add(prmCODE_CLabsence);

                //NUM_SEANCE
                OracleParameter prmNUM_SEANCEabsence = new OracleParameter(":NUM_SEANCE", OracleDbType.Decimal);
                prmNUM_SEANCEabsence.Value = _NUM_SEANCE;

                myCommandAbsence.Parameters.Add(prmNUM_SEANCEabsence);


                //DATE_SEANCE
                //OracleParameter prmDATE_SEANCEabsence = new OracleParameter(":DATE_SEANCE", OracleDbType.Date);
                //prmDATE_SEANCEabsence.Value = _DATE_SEANCE;

                //myCommandAbsence.Parameters.Add(prmDATE_SEANCEabsence);


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

        public bool Delete_esp_ABS(string _CODE_MODULE, string _CODE_CL, string _ANNEE_DEB, decimal _NUM_SEANCE, string _DATE_SEANCE, string _ID_ENS, decimal _SEMESTRE)
        {
            bool result = false;

            string cmdQuery1 = "delete from ESP_ABSENCE_NEW  where  CODE_MODULE ='" + _CODE_MODULE + "' AND CODE_CL='" + _CODE_CL + "' AND ANNEE_DEB='" + _ANNEE_DEB + "' AND NUM_SEANCE='" + _NUM_SEANCE + "' AND to_date(DATE_SEANCE,'dd/MM/yy')=to_date('" + _DATE_SEANCE + "','dd/MM/yy') AND ID_ENS='" + _ID_ENS + "' AND SEMESTRE='" + _SEMESTRE + "' ";
            Oracle.ManagedDataAccess.Client.OracleCommand myCommand = new OracleCommand(cmdQuery1);
            myCommand.Connection = mySqlConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.Transaction = myTrans;

            ////CODE_MODULE,
            //OracleParameter prmCODE_MODULE = new OracleParameter(":CODE_MODULE", OracleDbType.Varchar2);
            //prmCODE_MODULE.Value = _CODE_MODULE;
            //myCommand.Parameters.Add(prmCODE_MODULE);

            //// CODE_CL
            //OracleParameter prmCODE_CL = new OracleParameter(":CODE_CL", OracleDbType.Varchar2);
            //prmCODE_CL.Value = _CODE_CL;
            //myCommand.Parameters.Add(prmCODE_CL);

            ////ANNEE_DEB, 
            //OracleParameter prmANNEE_DEB = new OracleParameter(":ANNEE_DEB", OracleDbType.Varchar2);
            //prmANNEE_DEB.Value = _ANNEE_DEB;
            //myCommand.Parameters.Add(prmANNEE_DEB);


            ////NUM_SEANCE
            //OracleParameter prmNUM_SEANCE = new OracleParameter(":NUM_SEANCE", OracleDbType.Decimal);
            //prmNUM_SEANCE.Value = _NUM_SEANCE;
            //myCommand.Parameters.Add(prmNUM_SEANCE);

            //// _DATE_SEANCE

            //OracleParameter prmDATE_SEANCE = new OracleParameter(":DATE_SEANCE", OracleDbType.Date);
            //prmDATE_SEANCE.Value = _DATE_SEANCE;
            //myCommand.Parameters.Add(prmDATE_SEANCE);
            //// _ID_ENS, 

            //OracleParameter prmID_ENS = new OracleParameter(":ID_ENS", OracleDbType.Varchar2);
            //prmID_ENS.Value = _ID_ENS;
            //myCommand.Parameters.Add(prmID_ENS);


            ////SEMESTRE

            //OracleParameter prmSEMESTRE = new OracleParameter(":SEMESTRE", OracleDbType.Decimal);
            //prmSEMESTRE.Value = _SEMESTRE;
            //myCommand.Parameters.Add(prmSEMESTRE);



            try
            {
                myCommand.ExecuteNonQuery();
                //myCommandnote.ExecuteNonQuery();
                // myTrans.Commit();
                result = true;
            }
            catch (Exception)
            {
                myTrans.Rollback();
                mySqlConnection.Close();
                throw;
            }

            //bool result = myCommand.ExecuteNonQuery() > 0;
            //mySqlConnection.Close();

            return result;
        }


        public string getANNEEDEBs()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT ANNEE_DEB FROM SOCIETE";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

        public string getAnneeFiN()
        {
            string lib = "";

            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT ANNEE_FIN FROM SOCIETE";


                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();
            }
            return lib;
        }

    }
}
