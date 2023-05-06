using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ESPSuiviEncadrement
{
    public class GroupeProjet
    {
        #region sing

        static GroupeProjet instance;
        static Object locker = new Object();
        public static GroupeProjet Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new GroupeProjet();
                    }

                    return GroupeProjet.instance;
                }
            }

        }
        private GroupeProjet() { }

        #endregion

        #region public private methodes

       
        private string _ID_ET;
     
        public string ID_ET
        {
            get { return _ID_ET; }
            set { _ID_ET = value; }
        }
        
        #endregion

        public string getNomEtudiant(string id)
        {
            string y;
            string W;
            using (OracleConnection mySqlConnection = new OracleConnection(AppConfiguration.ConnectionString))
            {

                mySqlConnection.Open();
                string cmdQuery = "SELECT  NOM_ET,PNOM_ET FROM ESP_ETUDIANT WHERE  (ID_ET = '" + id + "')";
                OracleCommand myCommand = new OracleCommand(cmdQuery);
                myCommand.Connection = mySqlConnection;
                myCommand.CommandType = CommandType.Text;

                using (OracleDataReader myReader = myCommand.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        y = myReader.GetString(myReader.GetOrdinal("NOM_ET"));
                        W = myReader.GetString(myReader.GetOrdinal("PNOM_ET"));
                    }
                    else
                    {
                        y = "";
                        W = "";
                    }

                }
                mySqlConnection.Close();
            }
            return y+" "+W;
        }
        
        public GroupeProjet(OracleDataReader myReader)
        {
           

            if (!myReader.IsDBNull(myReader.GetOrdinal("ID_ET")))
            {

                _ID_ET = myReader.GetString(myReader.GetOrdinal("ID_ET"));
            }


        }

        public GroupeProjet(string ID_ET)
        {

            this._ID_ET = ID_ET;
            

        }
    }
}
