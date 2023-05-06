using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using ESPSuiviEncadrement;
using System.ComponentModel;
using System.Configuration;
using System.Data;
namespace PlanEtude
{
 public   class TypEpreuve
    {
         #region sing

        static TypEpreuve instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static TypEpreuve Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new TypEpreuve();
                    }

                    return TypEpreuve.instance;
                }
            }

        }
        private TypEpreuve() { }

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
        private string _CODE_STR;

        public string CODE_STR
        {
            get { return _CODE_STR; }
            set { _CODE_STR = value; }
        }
        private string _CODE_NOME;

        public string CODE_NOME
        {
            get { return _CODE_NOME; }
            set { _CODE_NOME = value; }
        }
        private string _LIB_NOME;

        public string LIB_NOME
        {
            get { return _LIB_NOME; }
            set { _LIB_NOME = value; }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public virtual List<TypEpreuve> BindEnseignant()
        {
            List<TypEpreuve> myList = null;
            OracleCommand cmd = new OracleCommand("SELECT  CODE_STR ,  CODE_NOME , LIB_NOME  FROM CODE_NOMENCLATURE WHERE CODE_STR='78'");
            myList = this.ExecuteQuery(cmd, "SELECT");

            return myList;

        }
        public virtual List<TypEpreuve> ExecuteQuery(OracleCommand cmd, string action)
        {
            List<TypEpreuve> myList = null;
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(conString))
            {

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                con.Open();
                using (OracleDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new List<TypEpreuve>();
                        while (myReader.Read())
                        {
                            myList.Add(new TypEpreuve(myReader));
                        }
                    }
                    con.Close();
                    return myList;

                }
            }
        }
         public TypEpreuve(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_STR")))
            {
                 _CODE_STR= myReader.GetString(myReader.GetOrdinal("CODE_STR"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("CODE_NOME")))
            {
                _CODE_NOME = myReader.GetString(myReader.GetOrdinal("CODE_NOME"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("LIB_NOME")))
            {
                _LIB_NOME = myReader.GetString(myReader.GetOrdinal("LIB_NOME"));

            }
        }
    }
}
