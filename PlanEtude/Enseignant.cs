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
    public class Enseignant
    {
        #region sing

        static Enseignant instance;
        static Object locker = new Object();
        //InscriptionOnLineESPRIT manager = new GestionEnquêtesEntities();
        public static Enseignant Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Enseignant();
                    }

                    return Enseignant.instance;
                }
            }

        }
        private Enseignant() { }

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
        private string _ID_ENS;

        public string ID_ENS
        {
            get { return _ID_ENS; }
            set { _ID_ENS = value; }
        }

        private string _NOM_ENS;

        public string NOM_ENS
        {
            get { return _NOM_ENS; }
            set { _NOM_ENS = value; }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public virtual List<Enseignant> BindEnseignant()
        {
            List<Enseignant> myList = null;
            OracleCommand cmd = new OracleCommand("SELECT ID_ENS, NOM_ENS FROM ESP_ENSEIGNANT WHERE (ETAT = 'A') order by nom_ens");
                    myList = this.ExecuteQuery(cmd, "SELECT");
               
            return myList;

        }
        public virtual List<Enseignant> ExecuteQuery(OracleCommand cmd, string action)
        {
            List<Enseignant> myList = null;
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
                        myList = new List<Enseignant>();
                        while (myReader.Read())
                        {
                            myList.Add(new Enseignant(myReader));
                        }
                    }
                    con.Close();
                    return myList;

                }
            }
        }
        public Enseignant(OracleDataReader myReader)
        {
            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ENS")))
            {
                _ID_ENS = myReader.GetString(myReader.GetOrdinal("ID_ENS"));

            }
            if (!myReader.IsDBNull(myReader.GetOrdinal("NOM_ENS")))
            {
                _NOM_ENS = myReader.GetString(myReader.GetOrdinal("NOM_ENS"));

            }
        }
    }
}
