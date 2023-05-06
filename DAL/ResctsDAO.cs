using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using admiss;
namespace DAL
{
    public class ResctsDAO
    {
        #region sing
        OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString);
        OracleTransaction myTrans;

        public void openconntrans()
        {
            //mySqlConnection.Open();
            //myTrans = mySqlConnection.BeginTransaction();

        }
        public string cmdQuery;
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
        static ResctsDAO instance;
        static Object locker = new Object();

        public static ResctsDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ResctsDAO();
                    }

                    return ResctsDAO.instance;
                }
            }

        }
        public ResctsDAO() { }

        public ResctsDAO(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("COEF")))
            {

                cOEF = myReader.GetDecimal(myReader.GetOrdinal("COEF"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_UE")))
            {

                cODE_UE = myReader.GetString(myReader.GetOrdinal("CODE_UE"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("DESIGNATION")))
            {

                dESIGNATION = myReader.GetString(myReader.GetOrdinal("DESIGNATION"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("LIB_UE")))
            {

                lIB_UE = myReader.GetString(myReader.GetOrdinal("LIB_UE"));
            }

            if (!myReader.IsDBNull(myReader.GetOrdinal("NB_ECTS")))
            {

                nB_ECTS = myReader.GetDecimal(myReader.GetOrdinal("NB_ECTS"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_UE")))
            {
                mOY_UE = myReader.GetDecimal(myReader.GetOrdinal("MOY_UE"));
            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("MOY_MODULE")))
            {

                mOY_MODULE = myReader.GetDecimal(myReader.GetOrdinal("MOY_MODULE"));
            }
        }

        #endregion
        #region getset
        private string cODE_UE;

        public string CODE_UE
        {
            get { return cODE_UE; }
            set { cODE_UE = value; }
        }

        private string dESIGNATION;


        public string DESIGNATION
        {
            get { return dESIGNATION; }
            set { dESIGNATION = value; }
        }private string lIB_UE;

        public string LIB_UE
        {
            get { return lIB_UE; }
            set { lIB_UE = value; }
        }
        private decimal nB_ECTS;

        public decimal NB_ECTS
        {
            get { return nB_ECTS; }
            set { nB_ECTS = value; }
        }
        private decimal cOEF;

        public decimal COEF
        {
            get { return cOEF; }
            set { cOEF = value; }
        }
        private decimal mOY_UE;

        public decimal MOY_UE
        {
            get { return mOY_UE; }
            set { mOY_UE = value; }
        }

        private decimal mOY_MODULE;

        public decimal MOY_MODULE
        {
            get { return mOY_MODULE; }
            set { mOY_MODULE = value; }
        }



        #endregion
        public string getanneedebb()
        {
            string annee = " ";

            //  openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = " select annee_deb from societe ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                annee = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return annee;
            }
        }


        public string returnCL(string id_edt)
        {
            string lib = "";

            //openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = " select code_cl,t1.id_et from esp_etudiant t1,esp_inscription t2, societe t3  WHERE etat='A' and t1.ID_ET='" + id_edt + "' and  t2.annee_deb=(select max(annee_deb) from societe) and t1.id_et=t2.id_et   ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return lib;
            }
        }
        public string Getnbects(string _Id_et)
        {
            string ects = "0";

            //  openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = " SELECT sum(nb_ects) FROM ESP_V_MOY_UE_ETUDIANT where type_moy='P' and moyenne>=10 and id_et='" + _Id_et + "'  and annee_deb=(select max(annee_deb) from societe)";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                ects = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return ects;
            }
        }
        public string GetMoy_Gen(string _Id_et, string annee)
        {
            string moy = "0";

            //openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT MOY_GENERAL FROM ESP_INSCRIPTION where ANNEE_DEB='" + annee + "' and id_et='" + _Id_et + "'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                moy = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return moy;
            }

        }
        public string GetLib_deci(string _Id_et, string annee)
        {
            string lib = "";

            // openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT LIB_DECISION_SESSION_P FROM ESP_INSCRIPTION where ANNEE_DEB='" + annee + "' and id_et='" + _Id_et + "'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return lib;
            }

        }
      
        public List<ResctsDAO> GetResFinal(string _Id_et, string annee)
        {
            List<ResctsDAO> myList = null;

            // openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = " SELECT e2.code_ue ,lib_ue,nb_ects, designation,coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue FROM ESP_V_MOY_MODULE_ETUDIANT_UE e1, ESP_V_MOY_UE_ETUDIANT e2 where   e1.id_et=e2.id_et and e1.annee_deb='" + annee + "' AND e2.annee_deb='" + annee + "' and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et + "'  and e1.type_moy='P'and e2.type_moy='P'  order by lib_ue ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ResctsDAO>();
                        while (myReader.Read())
                        {
                            myList.Add(new ResctsDAO(myReader));
                        }
                    }
                }

                mySqlConnection.Close();

                return myList;
            }

        }
        public List<ResctsDAO> GetResFinal2(string _Id_et, string annee,string code_ue)
        {
            List<ResctsDAO> myList = null;

             
                mySqlConnection.Open();

                string cmdQuery = " SELECT e2.code_ue ,lib_ue,nb_ects, designation,coef ,e1.moyenne as moy_module,e2.moyenne as moy_ue FROM ESP_V_MOY_MODULE_ETUDIANT_UE e1, ESP_V_MOY_UE_ETUDIANT e2 where   e1.id_et=e2.id_et and e1.annee_deb='" + annee + "' AND e2.annee_deb='" + annee + "' and e1.code_ue=e2.code_ue and e1.ID_ET='" + _Id_et + "'  and e1.type_moy='P'and e2.type_moy='P' AND e2.CODE_ue='" + code_ue + "' order by lib_ue ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<ResctsDAO>();
                        while (myReader.Read())
                        {
                            myList.Add(new ResctsDAO(myReader));
                        }
                    }
                }

                mySqlConnection.Close();
            //}
            return myList;

        }
        public DataTable getUE(string _Id_et, string annee)
        {


            //openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = new OracleCommand("  SELECT distinct code_ue ,lib_ue,nb_ects,moyenne as moy_ue FROM ESP_V_MOY_UE_ETUDIANT where  annee_deb='" + annee + "'   and ID_ET='" + _Id_et + "' and type_moy='P' order by lib_ue ", mySqlConnection);
                DataTable myDataTable = new DataTable();


                try
                {
                    adapter.Fill(myDataTable);

                }
                finally
                {
                    mySqlConnection.Close();
                }

                return myDataTable;
            }
        }
        public string getlcodecl(string _Id_et,string annee)
        {
            string codecl = "";

            // openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT  CODE_CL FROM ESP_INSCRIPTION where ANNEE_DEB='" + annee + "' and id_et='" + _Id_et + "'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                codecl = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return codecl;
            }
        }
        public string getTypepv( string code_cl,string annee )
        {
            string codecl = "";

            //openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();

                string cmdQuery = "SELECT  CODE_CL FROM ESP_SAISON_CLASSE where CODE_CL='" + code_cl + "' and annee_deb='" + annee + "'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                codecl = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return codecl;
            }
        }
        public string getMoyRat(string _Id_et, string annee)
        {
            string moy = "0";


            //openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT MOY_RATT FROM ESP_INSCRIPTION where ANNEE_DEB='" + annee + "' and id_et='" + _Id_et + "'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                moy = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return moy;
            }

        }
        public string getDecisionRat(string _Id_et, string annee)
        {
            string lib = "";

            // openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT LIB_DECISION_SESSION_RAT FROM ESP_INSCRIPTION where ANNEE_DEB='" + annee + "' and id_et='" + _Id_et + "'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return lib;
            }

        }
        public string getCodeDecisionRat(string _Id_et, string annee)
        {
            string lib = "";

            //  openconntrans();
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {
                mySqlConnection.Open();
                string cmdQuery = "SELECT CODE_DECISION_SESSION_RAT FROM ESP_INSCRIPTION where ANNEE_DEB='" + annee + "' and id_et='" + _Id_et + "'  ";

                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;
                lib = myCommand.ExecuteScalar().ToString();
                mySqlConnection.Close();

                return lib;
            }

        }

        public bool verifredouble(string id_et)
        {
            bool exist = false;



            mySqlConnection.Open();


            string cmdQuery = "select * from esp_inscription where annee_deb=2014 and CODE_DECISION_SESSION_RAT='02' and id_et='"+id_et+"'  ";

            OracleCommand myCommandAbsence = new OracleCommand(cmdQuery, mySqlConnection);
                              
            OracleDataReader MyReader = myCommandAbsence.ExecuteReader();

            while (MyReader.Read() && !exist)
            {
                exist = true;

                break;

            }
            MyReader.Close();
            mySqlConnection.Close();


            return exist;
        }
      
    }
}
